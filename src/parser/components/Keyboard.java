package parser.components;

public class Keyboard {

    private int cursorRow, cursorCol;
    private char[][] keyboard;

    public Keyboard() {
        initializeKeyboard();
    }

    private void initializeKeyboard() {
        this.resetCursor();
        this.keyboard = new char[][] {
                {'A', 'B', 'C', 'D', 'E', 'F'},
                {'G', 'H', 'I', 'J', 'K', 'L'},
                {'M', 'N', 'O', 'P', 'Q', 'R'},
                {'S', 'T', 'U', 'V', 'W', 'X'},
                {'Y', 'Z', '1', '2', '3', '4'},
                {'5', '6', '7', '8', '9', '0'},
        };
    }

    private boolean isValidCharacter(char command) {
        return (65 <= command && command <= 101);
    }

    /**
     * Gets directions for a single character
     * @param command
     * @return
     */
    public String processCharacter(char command) {
        if(command == ' ')
            return "S";

        command = mapCommandToKeyboard(command);
        if(!isValidCharacter(command)) {
            System.out.println("INVALID COMMAND ENTERED!");
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

        // Parse string
        String outputCommand = "";
        for (int i = 0; i < Math.abs(rowDistance); i++)
            outputCommand += rowCharacter + ",";
        for (int i = 0; i < Math.abs(colDistance); i++)
            outputCommand += colCharacter + ",";

        outputCommand += "#";
        return outputCommand;
    }

    /**
     * Determine whether to convert a letter to upper case or map a digit to our custom ascii
     * @param c
     * @return
     */
    private char mapCommandToKeyboard(char c) {
        return (Character.isDigit(c) ? mapDigitToKeyboard(c) : Character.toUpperCase(c));
    }

    /**
     * Fits 0-9 into our array after Z by using our own ASCII
     * @param c
     * @return
     */
    private char mapDigitToKeyboard(char c) {
        // 0 Needs to come after 9
        if (c == '0')
            c += 10;
        return (char) (c + 42);
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
     * Gets current character at the cursor.
     * If it's a digit, map it to our custom ascii
     * @return
     */
    private char getCurrentCharacter() {
        char c = this.keyboard[cursorRow][cursorCol];
        if(Character.isDigit(c))
            return mapDigitToKeyboard(c);
        return c;
    }

    /**
     * Sets cursor to 0,0
     */
    public void resetCursor() {
        this.cursorRow = 0;
        this.cursorCol = 0;
    }
}
