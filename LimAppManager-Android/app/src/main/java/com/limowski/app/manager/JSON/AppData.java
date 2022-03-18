package com.limowski.app.manager.JSON;

import com.google.gson.annotations.SerializedName;

public class AppData {
    @SerializedName("System")
    public String system;
    @SerializedName("Name")
    public String appName;
    @SerializedName("PackageName")
    public String fileName;
    @SerializedName("Description")
    public String description;
    @SerializedName("IsCompressed")
    public boolean isCompressed;
    @SerializedName("Hash")
    public String hash;
    @SerializedName("IconName")
    public String iconName;
    @SerializedName("ShotName")
    public String shotName;
    @SerializedName("Size")
    public double size;
    @SerializedName("Maintainer")
    public String maintainer;
    @SerializedName("Origin")
    public String origin;
    @SerializedName("Version")
    public String appVersion;
    @SerializedName("HasMeta")
    public boolean hasMeta;

    // Internal JSON field
    public String filePath;

}
