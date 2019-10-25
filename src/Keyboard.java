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
        String result = "";
        String uppercase = input.toUpperCase();

        Point initial = new Point();
        Point destination = new Point();

        for(int i = 0; i < uppercase.length(); i++) {
            char letter = uppercase.charAt(i);

            if(letter == ' ')
                result += 'S';
            else if(keyboardContains(letter)) {
                result += scriptLetter(letter, initial, destination);
            } else {
                result += 'E';
            }

            if(i < uppercase.length() - 1)
                result += ",";
        }

        return result;
    }

    /**
     *
     * @param letterToScript
     * @return
     */
    private String scriptLetter(char letterToScript, Point initialPoint, Point destinationPoint) {
        String script = "";

        setDestinationPoint(letterToScript, destinationPoint);

        int verticalDisplacement = destinationPoint.getI() - initialPoint.getI();
        int horizontalDisplacement = destinationPoint.getJ() - initialPoint.getJ();

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

        initialPoint.setI(destinationPoint.getI());
        initialPoint.setJ(destinationPoint.getJ());

        return script;
    }

    /**
     *
     * @param numTimes
     * @param toAdd
     * @return
     */
    private String addLetters(int numTimes, char toAdd) {
        String builder = "";

        for(int i = 0; i < numTimes; i++)
            builder += toAdd + ",";

        return builder;
    }

    /**
     *
     * @param letterToFind
     * @param pointToSet
     * @return
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
     *
     * @param letterToCheck
     * @return
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
