package com.limowski.app.manager;

import com.google.gson.Gson;

import org.apache.commons.net.ftp.FTP;
import org.apache.commons.net.ftp.FTPClient;
import org.apache.commons.net.ftp.FTPFile;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetAddress;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.concurrent.ConcurrentHashMap;

public class InternetUtils {

    public ConcurrentHashMap<String, String> getFilesArray(String path) {
        ConcurrentHashMap<String, String> apps = new ConcurrentHashMap<>();
        FTPClient client = new FTPClient();
        try {
            InetAddress address = InetAddress.getByName("limowski.xyz");
            client.connect(address, 2121);
            client.enterLocalPassiveMode();
            client.login("anon", "");

            client.setFileType(FTP.ASCII_FILE_TYPE);
            client.changeWorkingDirectory(path);
            InputStream inputStreamNames = client.retrieveFileStream("index.list");
            Scanner scannerNames = new Scanner(inputStreamNames);
            List<String[]> names = new ArrayList<>();
            while (scannerNames.hasNextLine()) {
                String[] nameAndDir = scannerNames.nextLine().split("=");
                names.add(nameAndDir);
            }
            scannerNames.close();
            inputStreamNames.close();
            client.completePendingCommand();

            if (!client.isConnected()) {
                client.connect(address, 2121);
                client.enterLocalPassiveMode();
                client.login("anon", "");
            }
            Gson gson = new Gson();
            for (String[] nameAndDir : names) {
                String displayName = nameAndDir[0];
                String dirName = path + '/' + nameAndDir[1];
                client.changeWorkingDirectory(dirName);
                FTPFile[] dirFiles = client.listFiles();
                boolean isMeta = false;
                String fileNameApk = "";
                for (FTPFile file : dirFiles) {
                    if (file.getName().endsWith(".apk")) {
                        fileNameApk = file.getName();
                    } else if (file.getName().equals("Meta.json")) {
                        isMeta = true;
                    }
                }

                if (isMeta) {
                    InputStream inputStreamMeta = client.retrieveFileStream(dirName+"/Meta.json");
                    Scanner scannerMeta = new Scanner(inputStreamMeta);
                    String rawJson = "";
                    while (scannerMeta.hasNextLine()) {
                        rawJson += scannerMeta.nextLine();
                    }
                    AppData app = gson.fromJson(rawJson, AppData.class);
                    app.filePath = dirName;
                    app.hasMeta = true;

                    String returnString = gson.toJson(app);

                    apps.put(displayName, returnString);
                    scannerMeta.close();
                    inputStreamMeta.close();
                    client.completePendingCommand();
                } else {
                    AppData app = new AppData();
                    app.system = "Android";
                    app.fileName = fileNameApk;
                    app.filePath = dirName;
                    app.size = 0.0;
                    app.hasMeta = false;
                    String returnString = gson.toJson(app);
                    apps.put(displayName, returnString);
                }

            }
            client.disconnect();
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }

        return apps;
    }

    public boolean downloadFile(String path, File file) {
        FTPClient client = new FTPClient();
        try {
            client.connect(InetAddress.getByName("limowski.xyz"), 2121);
            client.enterLocalPassiveMode();
            client.login("anon", "");
            client.setFileType(FTP.BINARY_FILE_TYPE);
            OutputStream stream = new BufferedOutputStream(new FileOutputStream(file));
            client.retrieveFile(path, stream);
            stream.close();
            client.disconnect();
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }

        return true;
    }
}
