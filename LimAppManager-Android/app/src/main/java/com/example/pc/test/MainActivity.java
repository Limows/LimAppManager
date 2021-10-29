package com.example.pc.test;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.os.Build;
import android.os.Environment;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import org.apache.commons.net.ftp.FTP;
import org.apache.commons.net.ftp.FTPClient;
import org.apache.commons.net.ftp.FTPFile;

import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.InetAddress;
import java.util.ArrayList;
import java.util.List;


public class MainActivity extends Activity {
    Spinner spinner;
    List<String> apps = new ArrayList<>();
    File savedFile;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        String SdkVersion = "unknown";

        try {
            SdkVersion = Build.VERSION.SDK;
        } catch (Exception e) {
            e.printStackTrace();
        }

        TextView textView = (TextView) findViewById(R.id.textView);
        String text = "Release: " + Build.VERSION.RELEASE + "\nSDK: " + SdkVersion +
                "\nIncremental: " + Build.VERSION.INCREMENTAL + "\nHas root: ";
        boolean root = new File("/system/bin/su").exists() || new File("/system/xbin/su").exists();
        text += root ? "Yes" : "No";

        textView.setText(text);

        spinner = (Spinner) findViewById(R.id.spinner);

        Log.d("TAG", "Hello");

        runInThread("", false);

        Button installButton = (Button) findViewById(R.id.install);
        Button deleteFile = (Button) findViewById(R.id.delete);
        Button silentInstallButton = (Button) findViewById(R.id.silent_install);
        silentInstallButton.setEnabled(false); // TODO set by (root);

        installButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                runInThread(spinner.getSelectedItem().toString(), false);
            }
        });

        silentInstallButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                runInThread(spinner.getSelectedItem().toString(), true);
            }
        });

        deleteFile.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (savedFile.delete()) {
                    Toast.makeText(getApplicationContext(), "File has been deleted",
                            Toast.LENGTH_SHORT).show();
                } else {
                    Toast.makeText(getApplicationContext(), "File has NOT been deleted",
                            Toast.LENGTH_LONG).show();
                }
            }
        });


    }

    private void runInThread(final String fileName, final boolean rootInstall) {
        new Thread(new Runnable() {
            @Override
            public void run() {
                connectAndGetFile(fileName, rootInstall);
            }
        }).start();

    }

    private void connectAndGetFile(String fileName, boolean rootInstall) {
        FTPClient client = new FTPClient();
        try {
            client.connect(InetAddress.getByName("limowski.xyz"), 2121);
            client.enterLocalPassiveMode();
            client.login("anon", "");
            client.changeWorkingDirectory("/Android API3");
            if(fileName.equals("")) {
                FTPFile[] files = client.listFiles();
                for (FTPFile file : files) {
                    apps.add(file.getName());
                }
                final ArrayAdapter<String> adp = new ArrayAdapter<>(this,
                        android.R.layout.simple_spinner_item, apps);
                adp.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        spinner.setAdapter(adp);
                    }
                });
            } else {
                client.setFileType(FTP.BINARY_FILE_TYPE);
                String filePath = "/Android API3/" + fileName;
                String localFileName = Environment.getExternalStorageDirectory().getPath()
                        + '/' + fileName;
                savedFile = new File(localFileName);
                OutputStream stream = new BufferedOutputStream(new FileOutputStream(savedFile));
                client.retrieveFile(filePath, stream);
                stream.close();
                if (rootInstall) {
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            Toast.makeText(getApplicationContext(), "Start installing silently",
                                    Toast.LENGTH_SHORT).show();
                        }
                    });
                    DataOutputStream dataOutputStream = null;
                    BufferedReader errorReader = null;
                    try {
                        Process process = Runtime.getRuntime().exec("su");
                        dataOutputStream = new DataOutputStream(process.getOutputStream());
                        String command = "pm install -r " + localFileName + "\n";
                        dataOutputStream.writeBytes(command);
                        //dataOutputStream.write(command.getBytes(Charset.forName("utf-8")));
                        dataOutputStream.flush();
                        dataOutputStream.writeBytes("exit\n");
                        dataOutputStream.flush();
                        process.waitFor();
                        errorReader = new BufferedReader(new InputStreamReader(process.getErrorStream()));
                        StringBuilder sb = new StringBuilder();
                        String line;
                        while ((line = errorReader.readLine()) != null){
                            sb.append(line);
                        }
                        String output = sb.toString();
                        if (!output.contains("Failure")) {
                            runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    Toast.makeText(getApplicationContext(), "Successfully installed",
                                            Toast.LENGTH_SHORT).show();
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
                    Intent install = new Intent(Intent.ACTION_VIEW)
                            .setDataAndType(Uri.fromFile(savedFile),
                                    "application/vnd.android.package-archive");
                    startActivity(install);
                }

            }
            client.disconnect();
        } catch (Exception e) {
            e.printStackTrace();
            Toast.makeText(getApplicationContext(), "Error while connecting to server",
                    Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
