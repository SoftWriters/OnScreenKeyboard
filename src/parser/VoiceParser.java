package parser;

import parser.components.Keyboard;

public class VoiceParser {

    private Keyboard keyboard;

    public VoiceParser() {
        this.keyboard = new Keyboard();
    }

    public String parseDirectionsForPhrase(String line) {
        return "";
    }


    private String getDirectionsForCharacter(char c) {
        return keyboard.processCharacter(c);
    }
}
