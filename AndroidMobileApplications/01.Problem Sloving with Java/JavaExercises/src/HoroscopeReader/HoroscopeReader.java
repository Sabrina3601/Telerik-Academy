package HoroscopeReader;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.URL;

public class HoroscopeReader {

	public static void main(String[] args) throws Exception{
		URL urlStr = new URL("http://www.astrologyzone.com/forecasts/monthly/scorpio.php");
		
		BufferedReader reader = new BufferedReader(
				new InputStreamReader(urlStr.openStream()));
		
		String input = reader.readLine();
		
		while (input != null) {
			System.out.println(input);
			
			input = reader.readLine();
		}
		reader.close();
		

	}

}
