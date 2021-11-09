package com.limowski.app.manager;

import android.app.Activity;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.concurrent.ConcurrentHashMap;


public class MainActivity extends Activity {
    ListView listView;
    ProgressBar progressBar;
    Button reconnectButton;
    InternetUtils internetUtils = new InternetUtils();
    ConcurrentHashMap<String, String> appsData;
    final int SDK_INT = Integer.parseInt(Build.VERSION.SDK);
    final boolean hasRoot = isRoot();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        listView = (ListView) findViewById(R.id.listView);
        progressBar = (ProgressBar) findViewById(R.id.progressBar);
        reconnectButton = (Button) findViewById(R.id.buttonReconnect);

        fillListView();

        reconnectButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                progressBar.setVisibility(View.VISIBLE);
                reconnectButton.setVisibility(View.INVISIBLE);
                fillListView();
            }
        });

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View item, int position, long id) {
                String appName = ((TextView) item).getText().toString();
                Intent intent = new Intent(MainActivity.this, AppActivity.class);
                try {
                    Gson gson = new Gson();
                    AppData appData = gson.fromJson(appsData.get(appName), AppData.class);

                    String sizeStr, descStr, iconPathStr, shotPathStr, fileNameStr, versionStr, filePath;
                    sizeStr = appData.size + " MB";
                    filePath = appData.filePath;
                    fileNameStr = appData.fileName;
                    if (appData.hasMeta) {
                        descStr = appData.description;
                        iconPathStr = appData.iconName;
                        shotPathStr = appData.shotName;
                        versionStr = appData.appVersion;
                    } else {
                        descStr = getString(R.string.no_desc);
                        iconPathStr = "";
                        shotPathStr = "";
                        versionStr = "-";
                    }

                    if (descStr.equals("")) {
                        descStr = getString(R.string.no_desc);
                    }

                    intent.putExtra("name", appName);
                    intent.putExtra("path", filePath);
                    intent.putExtra("file", fileNameStr);
                    intent.putExtra("size", sizeStr);
                    intent.putExtra("desc", descStr);
                    intent.putExtra("icon", iconPathStr);
                    intent.putExtra("shot", shotPathStr);
                    intent.putExtra("version", versionStr);
                    intent.putExtra("root", hasRoot);
                } catch (Exception e) {
                    e.printStackTrace();
                    Toast.makeText(getApplicationContext(), "Error", Toast.LENGTH_SHORT).show();
                    return;
                }
                startActivity(intent);
            }
        });
    }

    private void fillListView() {
        new Thread(new Runnable() {
            @Override
            public void run() {

                appsData = internetUtils.getFilesArray("/Android_API3");

                if (appsData == null || appsData.isEmpty()) {
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            Toast.makeText(getApplicationContext(), R.string.error_connection, Toast.LENGTH_LONG).show();
                            progressBar.setVisibility(View.INVISIBLE);
                            reconnectButton.setVisibility(View.VISIBLE);
                        }
                    });
                    return;
                }
                ArrayList<String> apps = new ArrayList<>();
                for (String i : appsData.keySet()) {
                    apps.add(i);
                }
                final ArrayAdapter<String> adapter = new ArrayAdapter<>(getApplicationContext(), android.R.layout.simple_list_item_1, apps);
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        listView.setAdapter(adapter);
                        progressBar.setVisibility(View.INVISIBLE);
                    }
                });
            }
        }).start();

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

        switch (id) {
            case (R.id.action_info):
                Intent infoIntent = new Intent(MainActivity.this, InfoActivity.class);
                infoIntent.putExtra("root", hasRoot);
                startActivity(infoIntent);
                return true;
            /*case (R.id.action_donate):
                Intent donateIntent = new Intent(MainActivity.this, DonateActivity.class);
                startActivity(donateIntent);
                return true;*/
            case (R.id.action_exit):
                finish();
                return true;
        }

        return super.onOptionsItemSelected(item);
    }

    private boolean isRoot () {
        boolean root = false;
        try {
            Process su = Runtime.getRuntime().exec("su");
            DataOutputStream os = new DataOutputStream(su.getOutputStream());
            BufferedReader br = new BufferedReader(new InputStreamReader(su.getInputStream()));
            if (os != null && br != null) {
                os.writeBytes("id\n");
                os.flush();
                String id = br.readLine();
                if (id != null && id.contains("uid=0")) {
                    root = true;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return root;
    }
}
