import parser.VoiceParser;

import java.io.FileNotFoundException;
import java.util.List;

/**
 * Shows how to combine input and parser module into one application.
 * Easily replacable with other parts of system.
 */
public class Application {

    /**
     * Run example application for translation
     * Supply one argument with the file name to translate
     * @param args
     */
    public static void main(String[] args) {

        // Get lines to translate
        List<String> inputFileLines;
        try {
            inputFileLines = InputReader.getLinesFromFile(args[0]);
        } catch (FileNotFoundException e) {
            System.out.println("Could not find that file!");
            return;
        }

        VoiceParser parser = new VoiceParser();

        // Parse/Translate every line
        for(String line : inputFileLines) {
            String output = parser.parseDirectionsForPhrase(line);
            System.out.println(line + ": " + output);
        }
    }

}
