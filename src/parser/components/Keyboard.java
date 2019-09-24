package parser.components;

public class Keyboard {

    private int cursorRow, cursorCol;
    private char[][] keyboard;

    public Keyboard() {
        initializeKeyboard();
    }

    private void initializeKeyboard() {
        this.cursorRow = 0;
        this.cursorCol = 0;
        this.keyboard = new char[][] {
                {'A', 'B', 'C', 'D', 'E', 'F'},
                {'G', 'H', 'I', 'J', 'K', 'L'},
                {'M', 'N', 'O', 'P', 'Q', 'R'},
                {'S', 'T', 'U', 'V', 'W', 'X'},
                {'Y', 'Z', '1', '2', '3', '4'},
                {'5', '6', '7', '8', '9', '0'},
        };
    }

    public String processCharacter(char command) {
        if(command == ' ')
            return "S,";

        command = mapCommandToKeyboard(command);

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
     * Convert a letter to upper case or digit to map after Z
     * @param c
     * @return
     */
    private char mapCommandToKeyboard(char c) {
        return (Character.isDigit(c) ? mapDigitToKeyboard(c) : Character.toUpperCase(c));
    }

    private char mapDigitToKeyboard(char c) {
        return (char) (c + 42);
    }

    private void moveCursor(int rowOffset, int colOffset) {
        this.cursorRow += rowOffset;
        this.cursorCol += colOffset;
    }

    private char getCurrentCharacter() {
        char c = this.keyboard[cursorRow][cursorCol];
        if(Character.isDigit(c))
            return mapDigitToKeyboard(c);
        return c;
    }
}
