package com.example.gpstests;

import android.support.v7.app.ActionBarActivity;
import android.app.Activity;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Toast;

public class MainActivity extends Activity {

	private MyLocationListener locationListener;
	private LocationManager locManager;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		locationListener = new MyLocationListener();
		locManager = (LocationManager) getSystemService(LOCATION_SERVICE);
	}
	
	
	
	@Override
	protected void onResume() {
		
		super.onResume();
		locManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 1000, 1000, locationListener);
	}



	private class MyLocationListener implements LocationListener{

		@Override
		public void onLocationChanged(Location loc) {
			
			if (loc != null) {
				Toast.makeText(getBaseContext(), 
						"Location changed: lat-" + loc.getLatitude()
						+ "long-" + loc.getLongitude(), Toast.LENGTH_LONG).show();
			}
			
		}

		@Override
		public void onProviderDisabled(String prov) {
			Toast.makeText(getBaseContext(), 
					"Provider " + "disabled",Toast.LENGTH_LONG).show();
			
		}

		@Override
		public void onProviderEnabled(String prov) {
			Toast.makeText(getBaseContext(), 
					"Provider " + "enabled",Toast.LENGTH_LONG).show();
			
		}

		@Override
		public void onStatusChanged(String arg0, int arg1, Bundle arg2) {
			String status = "";
			
			switch (arg1) {
			case android.location.LocationProvider.AVAILABLE:
				status = "avaliable";
				break;
			case android.location.LocationProvider.TEMPORARILY_UNAVAILABLE:
				status = "temporary unavaliable";
				break;
			case android.location.LocationProvider.OUT_OF_SERVICE:
				status = "out of service";
				break;
			default:
				break;
			}
			
			Toast.makeText(getBaseContext(), arg0 + "status: " + status, Toast.LENGTH_LONG).show();
			
		}
		
	}
}
