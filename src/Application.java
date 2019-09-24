import parser.VoiceParser;

import java.io.FileNotFoundException;
import java.util.List;

public class Application {

    public static void main(String[] args) {

        List<String> inputFileLines;
        try {
            inputFileLines = InputReader.getLinesFromFile("input.txt");
        } catch (FileNotFoundException e) {
            System.out.println("Could not find that file!");
            return;
        }

        VoiceParser parser = new VoiceParser();
        for(String line : inputFileLines) {
            String output = parser.parseDirectionsForPhrase(line);
            System.out.println(line + ": " + output);
        }
    }

}
