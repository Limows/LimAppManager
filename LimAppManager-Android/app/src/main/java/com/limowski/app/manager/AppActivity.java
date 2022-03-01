package com.limowski.app.manager;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.File;
import java.io.InputStreamReader;


public class AppActivity extends Activity {
    InternetUtils internetUtils = new InternetUtils();
    final String localFilePath = Environment.getExternalStorageDirectory().getPath() + "/dl.apk";
    File localFile = new File(localFilePath);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_app);

        Bundle args = getIntent().getExtras();
        final String appNameString = args.getString("name");
        final String appDirPathString = args.getString("path");
        final String appFileNameString = args.getString("file");
        final String appSizeString = args.getString("size");
        final String appDescString = args.getString("desc");
        final String appIconNameString = args.getString("icon");
        final String appShotNameString = args.getString("shot");
        final String appVersionString = args.getString("version");
        final boolean hasRoot = args.getBoolean("root");

        final String appFileString = appDirPathString + "/" + appFileNameString;
        final String appIconString = appDirPathString + "/" + appIconNameString;
        final String appShotString = appDirPathString + "/" + appShotNameString;

        DisplayMetrics displayMetrics = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(displayMetrics);
        int height = displayMetrics.heightPixels;
        int width = displayMetrics.widthPixels;
        int imageSide = (height > width) ? (width / 3) : (height / 3);

        TextView appTitleView = (TextView) findViewById(R.id.appTitleTextApp);
        TextView appVersionView = (TextView) findViewById(R.id.appVersionTextApp);
        TextView appSizeView = (TextView) findViewById(R.id.appSizeTextApp);
        TextView appDescView = (TextView) findViewById(R.id.appDescTextApp);
        ImageView imageView = (ImageView) findViewById(R.id.appImageViewApp);
        Button installButton = (Button) findViewById(R.id.installButtonApp);
        Button installSilentButton = (Button) findViewById(R.id.rootInstallButtonApp);
        Button deleteButton = (Button) findViewById(R.id.deleteButtonApp);

        installButton.setWidth(width / 2 - 5);
        installSilentButton.setWidth(width / 2 - 5);
        installSilentButton.setEnabled(hasRoot);

        appTitleView.setText(appNameString);
        appVersionView.setText(appVersionString);
        appSizeView.setText(appSizeString);
        appDescView.setText(appDescString);

        Bitmap appIconOrig = BitmapFactory.decodeResource(getResources(), R.drawable.dummy_app_icon);
        Bitmap appIcon = Bitmap.createScaledBitmap(appIconOrig, imageSide, imageSide, true);
        imageView.setImageBitmap(appIcon);

        installButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //localFile = new File(Environment.getExternalStorageDirectory().getPath() + "/dl.apk");
                downloadApkAndInstall(appFileString);
            }
        });

        installSilentButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //localFile = new File("/data/local/tmp/dl.apk");
                downloadApkAndRootInstall(appFileString);
            }
        });

        deleteButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (localFile.delete()) {
                    Toast.makeText(getApplicationContext(), R.string.file_deleted,
                            Toast.LENGTH_SHORT).show();
                } else {
                    Toast.makeText(getApplicationContext(), R.string.file_not_deleted,
                            Toast.LENGTH_LONG).show();
                }
            }
        });
    }


    private void downloadApkAndInstall(final String path) {
        Toast.makeText(getApplicationContext(), R.string.download_started, Toast.LENGTH_SHORT).show();
        new Thread(new Runnable() {
            @Override
            public void run() {
                        if (internetUtils.downloadFile(path, localFile)) {
                            Intent install = new Intent(Intent.ACTION_VIEW)
                                    .setDataAndType(Uri.fromFile(localFile), "application/vnd.android.package-archive");
                            startActivity(install);
                        } else {
                            runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    Toast.makeText(getApplicationContext(), R.string.download_error, Toast.LENGTH_LONG).show();
                                }
                            });
                }
            }
        }).start();
    }


    private void downloadApkAndRootInstall(final String path) {
        Toast.makeText(getApplicationContext(), R.string.download_started, Toast.LENGTH_SHORT).show();
        new Thread(new Runnable() {
            @Override
            public void run() {
                if (internetUtils.downloadFile(path, localFile)) {
                    DataOutputStream dataOutputStream = null;
                    BufferedReader errorReader = null;
                    try {
                        Process process = Runtime.getRuntime().exec("su");
                        dataOutputStream = new DataOutputStream(process.getOutputStream());
                        String moveCommand = "cp " + localFilePath + " /data/local/tmp/dl.apk\n";
                        dataOutputStream.writeBytes(moveCommand);
                        dataOutputStream.flush();
                        String installCommand = "pm install -r /data/local/tmp/dl.apk\n";
                        dataOutputStream.writeBytes(installCommand);
                        dataOutputStream.flush();
                        String removeFileCommand = "rm /data/local/tmp/dl.apk\n";
                        dataOutputStream.writeBytes(removeFileCommand);
                        dataOutputStream.flush();
                        dataOutputStream.writeBytes("exit\n");
                        dataOutputStream.flush();
                        process.waitFor();
                        errorReader = new BufferedReader(new InputStreamReader(process.getErrorStream()));
                        StringBuilder sb = new StringBuilder();
                        String line;
                        while ((line = errorReader.readLine()) != null){
                            sb.append(line).append('\n');
                        }
                        String output = sb.toString();
                        if (!output.contains("Failure")) {
                            runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    Toast.makeText(getApplicationContext(), "Successfully installed",
                                            Toast.LENGTH_LONG).show();
                                }
                            });

                        } else {
                            Log.d("SILENT", output);
                            runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    Toast.makeText(getApplicationContext(), "Error while installing, try regular install",
                                            Toast.LENGTH_LONG).show();
                                }
                            });

                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    } finally {
                        try {
                            if (dataOutputStream != null) {
                                dataOutputStream.close();
                            }
                            if (errorReader != null) {
                                errorReader.close();
                            }
                        } catch(Exception e) {
                            e.printStackTrace();
                        }

                    }
                } else {
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            Toast.makeText(getApplicationContext(), R.string.download_error, Toast.LENGTH_LONG).show();
                        }
                    });
                }
            }
        }).start();
    }
}
