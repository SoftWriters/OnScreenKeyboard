import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Scanner;

/**
 * The driver class for this program, takes file input, reads it
 * and outputs scripted version of each line
 */
public class KeyboardScripter {

    public static void main(String[] args) {

        // Strings to be used to access files
        String rootPath = "/Users/michaelbarton/IdeaProjects/OnScreenKeyboard/src/";
        String keyboardLayoutsPath = "keyboardLayouts/";
        String inputFilesPath = "inputFiles/";
        String alphabeticalFileName = "alphabeticalLayout.txt";
        String qwertyFileName = "qwertyLayout.txt";

        // Other attributes needed for main
        Scanner sc = new Scanner(System.in);
        String keyboardType, scriptFileName;
        char[][] keyboardLayout;
        Keyboard keyboard;

        // Print welcome message and determine keyboard type
        System.out.println("Welcome to KeyboardScripter!");

        do {
            System.out.print("Enter which kind of keyboard you'd like to use (\'alphabetical\' or \'qwerty\'): ");
            keyboardType = sc.nextLine();
        } while (!keyboardType.equals("alphabetical") && !keyboardType.equals("qwerty"));

        // Create Keyboard based on keyboard type inputted from user
        if(keyboardType.equals("alphabetical")) {
            keyboardLayout = createKeyboardLayout(rootPath + keyboardLayoutsPath + alphabeticalFileName);
        } else {
            keyboardLayout = createKeyboardLayout(rootPath + keyboardLayoutsPath + qwertyFileName);
        }

        keyboard = new Keyboard(keyboardLayout);

        System.out.println("\nHere's what your keyboard looks like!");
        print2DArray(keyboardLayout);

        // Obtain file name to read through and script
        System.out.print("\nEnter the file name that you would like to script: ");
        scriptFileName = sc.nextLine();

        System.out.println("\nResults:\n");

        // Open file, read through and script each line
        try {
            BufferedReader br = new BufferedReader(new FileReader(new File(rootPath + inputFilesPath + scriptFileName)));

            String str;
            while ((str = br.readLine()) != null) {
                System.out.println("\"" + str + "\" scripts to: ");
                System.out.println(keyboard.scriptLine(str) + "\n");
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    /**
     * Reads in the keyboard layout from the file and converts it into a double array of characters
     * @param fileName - name of the file to read from
     * @return double array of characters
     */
    static char[][] createKeyboardLayout(String fileName) {

        // Must use a list as we don't know the size yet
        ArrayList<ArrayList<Character>> table = new ArrayList<>();

        // Read the lines into "table"
        try {
            BufferedReader br = new BufferedReader(new FileReader(new File(fileName)));

            String str;
            while ((str = br.readLine()) != null)
                table.add(parseCharacters(str));

        } catch (Exception e) {
            e.printStackTrace();
        }

        // Create the double char array based on dimensions of "table"
        int rows = table.size();
        int columns = table.get(0).size();
        char[][] layout = new char[rows][columns];

        // Extract out all characters from table into the double char array "layout"
        for(int i = 0; i < rows; i++) {
            for(int j = 0; j < columns; j++) {
                layout[i][j] = table.get(i).get(j);
            }
        }

        return layout;
    }

    /**
     * Splits up a line of characters into a list based on a space regex
     * @param str - the line of characters to split up, each token should be a string of length 1
     * @return an ArrayList of characters representing a split version of str
     */
    private static ArrayList<Character> parseCharacters(String str) {
        ArrayList<Character> characters = new ArrayList<>();

        String[] splitString = str.split(" ");

        for(String s : splitString) {
            characters.add(s.charAt(0));
        }

        return characters;
    }

    /**
     * Prints out any char[][] array
     * @param array - the double array to print out
     */
    private static void print2DArray(char[][] array) {
        for(char[] row : array) {
            for (char element : row) {
                System.out.print(element + " ");
            }
            System.out.println();
        }
    }

}
