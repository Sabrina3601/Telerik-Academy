package StringsExercises;

public class StringReverser {
	
	public String reverseString(String str){
		
		StringBuilder reversedStr = new StringBuilder();
		
		for (int i = str.length() - 1; i >= 0; i--) {
			reversedStr.append(str.charAt((i)));
		}
		
		return reversedStr.toString();
	}
}
