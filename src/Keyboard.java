/**
 * We use an abstract class for Keyboard for future possibilities of different keyboard layouts
 * that a user wants to script input for
 */
public class Keyboard {

    /**
     * The keyboard mapping to use for scripting the lines from input files
     */
    private char[][] keyboardLayout;

    /**
     * Constructor for this class, sets value of keyboard
     * @param keyboardLayout - the keyboard mapping to be used for this instance of Keyboard
     */
    public Keyboard(char[][] keyboardLayout) {
        this.keyboardLayout = keyboardLayout;
    }

    /**
     * Takes the input and determines the script necessary to obtain that input
     * @param input - a String to convert into a script
     * @return a String with the script representing how to obtain the input for this particular keyboard
     */
    String scriptLine(String input) {
        // Initializes the builder string and converts input to uppercase to match the keyboard layouts
        String result = "";
        String uppercase = input.toUpperCase();

        // The Point objects we will use to store locations and calculate the paths
        Point initial = new Point();
        Point destination = new Point();

        // Iterate through each character in the string, performing the correct conversions on each
        for(int i = 0; i < uppercase.length(); i++) {
            char letter = uppercase.charAt(i);

            if(letter == ' ')
                // A space
                result += 'S';
            else if(keyboardContains(letter)) {
                // A character inside the keyboard
                result += scriptLetter(letter, initial, destination);
            } else {
                // Not a character inside the keyboard - error
                result += 'E';
            }

            if(i < uppercase.length() - 1)
                result += ",";
        }

        return result;
    }

    /**
     * Takes letterToScript and converts it to a sequence of U, D, L and R's, ending with a #
     * @param letterToScript - the letter to convert
     * @return a string formatted as explained above
     */
    private String scriptLetter(char letterToScript, Point initialPoint, Point destinationPoint) {
        String script = "";

        // Sets the correct location of the destination of the letter we are now searching for
        setDestinationPoint(letterToScript, destinationPoint);

        // Calculate the displacement (the path)
        int verticalDisplacement = destinationPoint.getI() - initialPoint.getI();
        int horizontalDisplacement = destinationPoint.getJ() - initialPoint.getJ();

        // Based on value of displacement, add appropriate letters to the string we are building
        if(verticalDisplacement < 0) {
            verticalDisplacement *= -1;
            script += addLetters(verticalDisplacement, 'U');
        } else {
            script += addLetters(verticalDisplacement, 'D');
        }

        if(horizontalDisplacement < 0) {
            horizontalDisplacement *= -1;
            script += addLetters(horizontalDisplacement, 'L');
        } else {
            script += addLetters(horizontalDisplacement, 'R');
        }

        script += "#";

        // Current destination point becomes initial point for the next letter (represents the cursor)
        initialPoint.setI(destinationPoint.getI());
        initialPoint.setJ(destinationPoint.getJ());

        return script;
    }

    /**
     * Builds a string consisting of toAdd repeated numTimes times with commas in following each time
     * @param numTimes - the number of times to add the character
     * @param toAdd - the character to add to the string we are building
     * @return a String formatted as explained above
     */
    private String addLetters(int numTimes, char toAdd) {
        String builder = "";

        for(int i = 0; i < numTimes; i++)
            builder += toAdd + ",";

        return builder;
    }

    /**
     * Searches for letterToFind in keyboardLayout and sets the location of it in pointToSet
     * @param letterToFind - the letter whose location we are searching for
     * @param pointToSet - the Point whose location we will set to match letterToFind, represents the destination
     */
    private void setDestinationPoint(char letterToFind, Point pointToSet) {
        for(int i = 0; i < keyboardLayout.length; i++) {
            for(int j = 0; j < keyboardLayout[0].length; j++) {
                if(letterToFind == keyboardLayout[i][j]) {
                    pointToSet.setI(i);
                    pointToSet.setJ(j);
                }
            }
        }
    }

    /**
     * Checks if keyboardLayout contains letterToCheck
     * @param letterToCheck - the letter desired in the keyboard
     * @return true if keyboardLayout contains letterToCheck, false otherwise
     */
    private boolean keyboardContains(char letterToCheck) {
        for(char[] row : keyboardLayout) {
            for(char c : row) {
                if(c == letterToCheck)
                    return true;
            }
        }

        return false;
    }
}
