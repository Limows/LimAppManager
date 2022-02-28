package com.limowski.app.manager.JSON;

import com.google.gson.annotations.SerializedName;

public class AppData {
    @SerializedName("System")
    public String system;
    @SerializedName("Name")
    public String appName;
    @SerializedName("FileName")
    public String fileName;
    @SerializedName("FilePath")
    public String filePath;
    @SerializedName("Description")
    public String description;
    @SerializedName("IsCompressed")
    public boolean isCompressed;
    @SerializedName("IcoName")
    public String iconName;
    @SerializedName("ShotName")
    public String shotName;
    @SerializedName("Size")
    public double size;
    @SerializedName("Mainteiner")
    public String maintainer;
    @SerializedName("Origin")
    public String origin;
    @SerializedName("Version")
    public String appVersion;
    @SerializedName("HasMeta")
    public boolean hasMeta;

}
