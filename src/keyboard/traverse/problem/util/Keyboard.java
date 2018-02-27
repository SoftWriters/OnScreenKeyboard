package keyboard.traverse.problem.util;

public class Keyboard {
	      
	//Single dim array defining the keyboard used for searching
   private final String [] keyboardOneD = new String [] 
	   {"A","B","C","D","E","F",
	   "G","H","I","J","K","L",
	   "M","N","O","P","Q","R",
	   "S","T","U","V","W","X",
	   "Y","Z","1","2","3","4",
	   "5","6","7","8","9","0"};
   
   private String searchString;
   
	/**
	 * Default Constructor
	 */
	public Keyboard () {
		
		this.searchString = "";
	}
	
   /**
    * Constructor that accepts a initial search string.
    * @param tempSearchString
    */
	public Keyboard (String tempSearchString) {
		
		this.searchString = tempSearchString;
	}
	
	/**
	 * Method that sets the value of the search text
	 * @param textEntered value of the text to be search for
	 */
	public void enterKeyboardText(String textEntered) {
		
		this.searchString = textEntered;
	}
	
	/**
	 * Method builds the directional instructions for the search string defined by 'searchString' in this class
	 * @return String of directional instructions
	 */
	public String printKeyboardDirections() {
		
		StringBuilder directions = new StringBuilder();
		int lastPosition = 0;
		int newPosition = 0;
		
		if (this.searchString.length() >= 1)
		{
			for (int i =0; i < this.searchString.length(); i++) 
			{
				newPosition = findKeyboardLetterPosition(Character.toString(this.searchString.charAt(i)));
				
				if (newPosition != -1 || Character.toString(this.searchString.charAt(i)).equals(" "))
				{
					directions.append(generateDirections(lastPosition,newPosition,Character.toString(this.searchString.charAt(i))));
					lastPosition = newPosition;
				}
			}
			
			return this.searchString.length() == 0 ? directions.toString() : directions.toString().substring(0, directions.toString().length() -1);
		}
		
		return "";
	}
	
	/**
	 * Method returns directional instructions for a single search String character.
	 * @param lastPos last position of the cursor
	 * @param currentPos current position of the cursor on the desired search character
	 * @param searchCharacter single character represented as a String
	 * @return
	 */
	private String generateDirections(int lastPos, int currentPos, String searchCharacter) {
		
		StringBuilder letterDirections = new StringBuilder();
		
		//if we read in a space, return "S"
		if (searchCharacter.equals(" ")) {
			letterDirections.append("S,");
		}
		else {
			
			//calculate the number of down movements.
			if (lastPos < currentPos) {
				
				for (int downs = 0; downs < (Math.floor((Math.abs(lastPos-currentPos)) / 6)); downs++) { letterDirections.append("D,");}
			}
			
			//calculate the number of up movements.
			else if (lastPos > currentPos) {
				
				for (int downs = 0; downs < (Math.ceil((Math.abs(lastPos-currentPos)) / 6)); downs++) { letterDirections.append("U,");}
			}
		}
		
		//if directions were produced for the found letter, end with selection command '#'
		letterDirections.append(letterDirections.length() > 0 ? "#,": "");
		
		return letterDirections.toString();
		
	}
	
	/**
	 * Method performs iterative binary search and returns the position of a given found character, -1 if not found
	 * @param keyString Search string
	 * @return Integer position of a given found character, -1 if not found
	 */
	private int findKeyboardLetterPosition(String keyString) { 
		int low = 0; 
		int high = this.keyboardOneD.length - 1; 
		
		while (high >= low) 
		{ 
			int middle = (low + high) / 2; 
		
			if (this.keyboardOneD[middle].equals(keyString))
			{ 
				return middle; 
			} 
			else if (this.keyboardOneD[middle].compareTo(keyString) < 0) 
			{ 
				low = middle + 1; 
			} 
			else if (this.keyboardOneD[middle].compareTo(keyString) > 0) 
			{ 
				high = middle - 1; 
			} 
		} 
		
		return -1; 	
	}
}
