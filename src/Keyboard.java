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
    public String scriptLine(String input) {
        return input;
    }
}
