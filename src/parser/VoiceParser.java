package parser;

import parser.components.Keyboard;

/**
 * A module that can be used to translate phrases into DVR commands
 */
public class VoiceParser {

    /**
     * Keyboard to allow for translating text
     */
    private Keyboard keyboard;

    public VoiceParser() {
        this.keyboard = new Keyboard();
    }

    /**
     * Parse directions for a single character
     * @param c
     * @return
     */
    private String getDirectionsForCharacter(char c) {
        return keyboard.processCharacter(c);
    }

    /**
     * Parses directions for an entire line
     * @param phrase
     * @return
     */
    public String parseDirectionsForPhrase(String phrase) {
        String outputCommand = "";

        // Get directions for each character in the phrase
        for(char c : phrase.toCharArray())
            outputCommand += getDirectionsForCharacter(c) + ",";

        outputCommand = outputCommand.substring(0, outputCommand.length() - 1);

        // Reset cursor for future phrases
        keyboard.resetCursor();
        return outputCommand;
    }

}
