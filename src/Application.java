import parser.VoiceParser;

import java.io.FileNotFoundException;
import java.util.List;

/**
 * Combines input and parser module into one application
 */
public class Application {

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

        // Translate every line
        for(String line : inputFileLines) {
            String output = parser.parseDirectionsForPhrase(line);
            System.out.println(line + ": " + output);
        }
    }

}
