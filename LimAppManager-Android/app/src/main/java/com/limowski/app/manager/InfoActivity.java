package com.limowski.app.manager;

import android.app.Activity;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;


public class InfoActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_info);

        Bundle args = getIntent().getExtras();
        boolean root = args.getBoolean("root");
        String SdkVersion = Build.VERSION.SDK;

        Button backButton = (Button) findViewById(R.id.backButtonInfo);
        backButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        final TextView textView = (TextView) findViewById(R.id.infoTextView);
        final String text = "Manager version: " + getString(R.string.app_version) +
                "\nRelease: " + Build.VERSION.RELEASE + "\nSDK: " + SdkVersion +
                "\nIncremental: " + Build.VERSION.INCREMENTAL + "\nHas root: " + (root ? "Yes" : "No");

        textView.setText(text);
    }
}
