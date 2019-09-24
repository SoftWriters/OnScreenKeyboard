package parser;

import parser.components.Keyboard;

public class VoiceParser {

    private Keyboard keyboard;

    public VoiceParser() {
        this.keyboard = new Keyboard();
    }

    public String parseDirectionsForPhrase(String line) {
        String outputCommand = "";
        for(char c : line.toCharArray())
            outputCommand += getDirectionsForCharacter(c) + ",";
        return outputCommand;
    }


    private String getDirectionsForCharacter(char c) {
        return keyboard.processCharacter(c);
    }
}
