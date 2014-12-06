package com.example.activitieshw;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;

public class SecondActivity extends Activity{
	
	private EditText output;
	
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_second);
		
		output = (EditText)findViewById(R.id.editOutput);
		
		Intent intent = this.getIntent();
		
		String getInput = intent.getStringExtra("textInput");
		
		output.setText(getInput);
	}
}
