package com.example.mediaplayerservice;

import android.support.v7.app.ActionBarActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends ActionBarActivity implements OnClickListener{

	private Button startBtn, stopBtn;
	Intent playbackServiceIntent;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		startBtn = (Button)findViewById(R.id.startBtn);
		stopBtn = (Button)findViewById(R.id.stopBtn);
		
		startBtn.setOnClickListener(this);
		stopBtn.setOnClickListener(this);
		
		playbackServiceIntent = new Intent(this, MediaPlayerService.class);
	}

	@Override
	public void onClick(View v) {
		
		if (v.getId() == startBtn.getId()) {
			startService(playbackServiceIntent);
			
		}
		else if (v.getId() == stopBtn.getId()) {
			stopService(playbackServiceIntent);
		
		}
	}

	
}
