package com.limowski.app.manager;

import com.google.gson.Gson;
import com.limowski.app.manager.JSON.AppData;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.concurrent.ConcurrentHashMap;

import android.util.Log;

public class InternetUtils {

    private static String protocol = "http://";
    private static String server = "limowski.xyz";
    private static int port = 80;
    private static String directory = "/downloads";
    private static String indexListName = "/index.list";
    private static String metaName = "/Meta.json";

    private static String baseUrl = protocol + server + ":" + port + directory;
    //                              http://limowski.xyz:80/downloads

    private static String login = "anon";
    private static String password = "";

    private static HttpClient client = new DefaultHttpClient();

    public boolean hadIndex(String path) {
        try {
            String indexUrl = baseUrl + path + indexListName;
            HttpGet request = new HttpGet(indexUrl);
            HttpResponse response = client.execute(request);
            if (response.getStatusLine().toString().contains("200")) {
                return true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return false;
    }

    public ConcurrentHashMap<String, String> getFilesArray(String path) {
        ConcurrentHashMap<String, String> apps = new ConcurrentHashMap<>();

        String baseDirUrl = baseUrl + path;
        try {
            String indexUrl = baseDirUrl + indexListName;
            HttpGet request = new HttpGet(indexUrl);
            HttpResponse response = client.execute(request);
            if (response.getStatusLine().toString().contains("404")) {
                return null;
            }
            HttpEntity entity = response.getEntity();
            InputStream inputStream = entity.getContent();
            Scanner scanner = new Scanner(inputStream);
            List<String[]> names = new ArrayList<>();
            while (scanner.hasNextLine()) {
                String[] nameAndDir = scanner.nextLine().split("=");
                names.add(nameAndDir);
            }
            scanner.close();
            inputStream.close();

            Gson gson = MainActivity.gson;

            for (String[] nameAndDir : names) {
                String displayName = nameAndDir[0];
                String appDirUrl = nameAndDir[1];
                String MetaUrl = appDirUrl + metaName;
                request = new HttpGet(MetaUrl);
                response = client.execute(request);

                if (response.getStatusLine().toString().contains("404")) {
                    continue;
                }

                entity = response.getEntity();
                inputStream = entity.getContent();
                scanner = new Scanner(inputStream);
                String rawJson = "";
                while (scanner.hasNextLine()) {
                    rawJson += scanner.nextLine();
                }

                AppData app = gson.fromJson(rawJson, AppData.class);
                app.filePath = path + "/" + nameAndDir[1];
                app.hasMeta = true;
                String returnString = gson.toJson(app);
                apps.put(displayName, returnString);
                scanner.close();
                inputStream.close();
            }
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
        return apps;
    }

    public boolean downloadFile(String path, File file) {
        Log.d("HTTPD", path);
        String fileUrl = baseUrl + path;
        try {
            HttpGet request = new HttpGet(fileUrl);
            HttpResponse response = client.execute(request);
            HttpEntity entity = response.getEntity();
            OutputStream stream = new BufferedOutputStream(new FileOutputStream(file));
            entity.writeTo(stream);
            stream.close();
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }

        return true;
    }
}
