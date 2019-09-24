package parser;

import parser.components.Keyboard;

/**
 * A module that can be used to translate phrases into DVR commands
 */
public class VoiceParser {

    private Keyboard keyboard;

    public VoiceParser() {
        this.keyboard = new Keyboard();
    }

    /**
     * Parses directions for an entire line
     * @param line
     * @return
     */
    public String parseDirectionsForPhrase(String line) {
        String outputCommand = "";

        // Get directions for each character
        for(char c : line.toCharArray())
            outputCommand += getDirectionsForCharacter(c) + ",";

        outputCommand = outputCommand.substring(0, outputCommand.length() - 1);

        // Reset cursor for future lines
        keyboard.resetCursor();
        return outputCommand;
    }

    private String getDirectionsForCharacter(char c) {
        return keyboard.processCharacter(c);
    }
}
