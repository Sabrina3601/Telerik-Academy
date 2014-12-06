package com.example.mediaplayerservice;

import java.io.IOException;

import android.app.Service;
import android.content.Intent;
import android.media.AudioManager;
import android.media.MediaPlayer;
import android.media.MediaPlayer.OnCompletionListener;
import android.os.IBinder;

public class MediaPlayerService extends Service implements OnCompletionListener{

	MediaPlayer player;
	@Override
	public IBinder onBind(Intent intent) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void onCreate() {
		super.onCreate();
		player = new MediaPlayer();
		player.setVolume(100, 100);
		player.setLooping(true);
	}
	
	@Override
	public void onDestroy() {
		player.stop();
		
		//player.release();
	}

	@Override
	public int onStartCommand(Intent intent, int flags, int startId) {

		if (!player.isPlaying()) {
			player.setAudioStreamType(AudioManager.STREAM_MUSIC);  
			try {
				//player.setDataSource();
			} catch (IllegalArgumentException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (SecurityException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (IllegalStateException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}  
			try {
				player.prepare();
			} catch (IllegalStateException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} // might take long! (for buffering, etc)  
			player.start();  
		}
		
		return 1;
	}

	@Override
	public void onCompletion(MediaPlayer mp) {
		stopSelf();
		
	}
	

}
