package com.limowski.app.manager;

import android.app.Activity;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;


public class InfoActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_info);

        boolean root = MainActivity.hasRoot;
        String SdkVersion = String.valueOf(MainActivity.SDK_INT);

        Button backButton = (Button) findViewById(R.id.backButtonInfo);
        backButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        final TextView textView = (TextView) findViewById(R.id.infoTextViewInfo);
        final String text = "Manager version: " + getString(R.string.app_version) +
                "\nRelease: " + Build.VERSION.RELEASE + "\nSDK: " + SdkVersion +
                "\nIncremental: " + Build.VERSION.INCREMENTAL + "\nHas root: " + (root ? "Yes" : "No") + '\n';

        textView.setText(text);
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)  {
        if (keyCode == KeyEvent.KEYCODE_BACK) {
            Log.d("BACK", String.valueOf(event.getRepeatCount()));
        }
        if (keyCode == KeyEvent.KEYCODE_BACK && event.getRepeatCount() == 0) {
            //finish();
            return true;
        }
        return super.onKeyDown(keyCode, event);
    }
}
