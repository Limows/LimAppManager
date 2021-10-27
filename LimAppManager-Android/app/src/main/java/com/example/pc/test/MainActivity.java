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
import java.io.File;
import java.io.FileOutputStream;
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

        TextView tv = (TextView) findViewById(R.id.textView);
        String text = "Release: " + Build.VERSION.RELEASE + "\nSDK: " + Build.VERSION.SDK +
                "\nIncremental: " + Build.VERSION.INCREMENTAL;
        tv.setText(text);

        spinner = (Spinner) findViewById(R.id.spinner);

        Log.d("TAG", "Hello");

        connect_and_get_file("");

        Button installButton = (Button) findViewById(R.id.install);
        Button deleteFile = (Button) findViewById(R.id.delete);

        installButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                connect_and_get_file(spinner.getSelectedItem().toString());
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

    private void connect_and_get_file(String fileName) {
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
                ArrayAdapter<String> adp = new ArrayAdapter<String>(this,
                        android.R.layout.simple_spinner_item, apps);
                adp.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner.setAdapter(adp);
            } else {
                client.setFileType(FTP.BINARY_FILE_TYPE);
                String filePath = "/Android API3/" + fileName;
                String localFileName = Environment.getExternalStorageDirectory().getPath()
                        + '/' + fileName;
                savedFile = new File(localFileName);
                OutputStream stream = new BufferedOutputStream(new FileOutputStream(savedFile));
                client.retrieveFile(filePath, stream);
                stream.close();

                Intent install = new Intent(Intent.ACTION_VIEW)
                        .setDataAndType(Uri.fromFile(savedFile),
                                "application/vnd.android.package-archive");
                startActivity(install);

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
