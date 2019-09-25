package parser.components;

/**
 * Manages keyboard related information. Gives directions on how to
 * move between characters via DVR commands.
 *
 * The keyboard is a 2D Array of characters with a cursor pointed
 * at the current character.
 *
 */
public class Keyboard {

    private int cursorRow, cursorCol;
    private char[][] keyboard;

    public Keyboard() {
        initializeKeyboard();
        resetCursor();
    }

    /**
     * Initializes keyboard's values
     *
     */
    private void initializeKeyboard() {
        this.keyboard = new char[][] {
                {'A', 'B', 'C', 'D', 'E', 'F'},
                {'G', 'H', 'I', 'J', 'K', 'L'},
                {'M', 'N', 'O', 'P', 'Q', 'R'},
                {'S', 'T', 'U', 'V', 'W', 'X'},
                {'Y', 'Z', '1', '2', '3', '4'},
                {'5', '6', '7', '8', '9', '0'},
        };
    }

    /**
     * Moves cursor for keyboard
     * @param rowOffset
     * @param colOffset
     */
    private void moveCursor(int rowOffset, int colOffset) {
        this.cursorRow += rowOffset;
        this.cursorCol += colOffset;
    }

    /**
     * Used to place 0-9 into our keyboard after Z
     *
     * To search for a digit, we modify the digit's ASCII value to appear
     * after the Z in our keyboard.
     *
     * @param c
     * @return
     */
    private char mapDigitToKeyboard(char c) {
        if (c == '0')
            // '0' Needs to be placed after '9'
            c += 10;

        return (char) (c + 42);
    }

    /**
     * Convert the character to an ASCII format searchable by our keyboard
     * @param c
     * @return
     */
    private char mapCommandToKeyboard(char c) {
        return (Character.isDigit(c) ? mapDigitToKeyboard(c) : Character.toUpperCase(c));
    }

    /**
     * Gets current character at the cursor.
     *
     * If it's a digit, map it to our ascii format above to allow
     * for searching.
     *
     * @return
     */
    private char getCurrentCharacter() {
        char c = this.keyboard[cursorRow][cursorCol];
        if(Character.isDigit(c))
            return mapDigitToKeyboard(c);
        return c;
    }

    /**
     * Sets cursor to row = 0 col = 0
     */
    public void resetCursor() {
        this.cursorRow = 0;
        this.cursorCol = 0;
    }

    /**
     * Verify the command is A-Z or 0-9 and in our keyboard
     * @param command
     * @return
     */
    private boolean isValidCharacter(char command) {
        return (65 <= command && command <= 101);
    }

    /**
     * Gets directions for a single character
     *
     * To search for a letter, we compare the ASCII value of the letter
     * with the ASCII values in our keyboard to mathematically determine
     * the path.
     *
     * @param command
     * @return
     */
    public String processCharacter(char command) {
        if(command == ' ')
            return "S";

        command = mapCommandToKeyboard(command);
        if(!isValidCharacter(command)) {
            System.out.println("Invalid command received. Exiting...");
            System.exit(0);
        }

        // Determine left/right
        int cursorXPosition = (getCurrentCharacter() - 65) % 6;
        int commandXPosition = (command - 65) % 6;
        int colDistance = commandXPosition - cursorXPosition;

        String colCharacter = (colDistance > 0) ? "R" : "L";
        moveCursor(0, colDistance);

        // Determine up/down
        int rowDistance = (command - getCurrentCharacter()) / 6;
        String rowCharacter = (rowDistance > 0) ? "D" : "U";
        moveCursor(rowDistance, 0);

        // Output directions string
        String outputCommand = "";
        for (int i = 0; i < Math.abs(rowDistance); i++)
            outputCommand += rowCharacter + ",";
        for (int i = 0; i < Math.abs(colDistance); i++)
            outputCommand += colCharacter + ",";

        outputCommand += "#";
        return outputCommand;
    }


}
