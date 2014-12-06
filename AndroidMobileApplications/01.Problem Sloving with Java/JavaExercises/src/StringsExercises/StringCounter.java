package StringsExercises;

public class StringCounter {
	
	public int CountWords(String input){
		String trimmedInput = input.trim();
		
		return trimmedInput.split("\\s+").length;
	}
}
