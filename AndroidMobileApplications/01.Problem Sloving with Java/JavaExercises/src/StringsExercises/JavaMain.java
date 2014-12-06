package StringsExercises;

//Reverse a String – Enter a string and the program will reverse it 
//and print it out.
//Count Words in a String – Counts the number of individual words in a string. 
//For added complexity read these strings in from a text file 
//and generate a summary.

public class JavaMain {
	 public static void main(String[] args) {
		StringReverser reverser = new StringReverser();
		
		String reversed = reverser.reverseString("string");
		
		System.out.println(reversed);
		
		StringCounter strCounter = new StringCounter();
		
		int wordsCount = strCounter.CountWords("Count these words");
		
		System.out.println(wordsCount);
	}
}
