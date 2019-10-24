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
        String rootPath = "/Users/michaelbarton/IdeaProjects/OnScreenKeyboard/src/";
        String alphabeticalFileName = "alphabeticalLayout.txt";
        String qwertyFileName = "qwertyLayout.txt";

        Scanner sc = new Scanner(System.in);
        String keyboardType, scriptFileName;

        char[][] keyboardLayout;
        Keyboard keyboard;

        System.out.println("Welcome to KeyboardScripter!");

        do {
            System.out.print("Enter which kind of keyboard you'd like to use (\'alphabetical\' or \'qwerty\'): ");
            keyboardType = sc.nextLine();
        } while (!keyboardType.equals("alphabetical") && !keyboardType.equals("qwerty"));

        if(keyboardType.equals("alphabetical")) {
            keyboardLayout = createKeyboardLayout(rootPath + alphabeticalFileName);
        } else {
            keyboardLayout = createKeyboardLayout(rootPath + qwertyFileName);
        }

        keyboard = new Keyboard(keyboardLayout);

        System.out.print("\nEnter the file name that you would like to script: ");
        scriptFileName = sc.nextLine();

        try {
            BufferedReader br = new BufferedReader(new FileReader(new File(rootPath + scriptFileName)));

            String str;
            while ((str = br.readLine()) != null)
                System.out.println(keyboard.scriptLine(str));
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    private static char[][] createKeyboardLayout(String fileName) {
        ArrayList<ArrayList<Character>> table = new ArrayList<>();

        try {
            BufferedReader br = new BufferedReader(new FileReader(new File(fileName)));

            String str;
            while ((str = br.readLine()) != null)
                table.add(parseCharacters(str));

        } catch (Exception e) {
            e.printStackTrace();
        }

        int rows = table.size();
        int columns = table.get(0).size();

        char[][] layout = new char[rows][columns];

        for(int i = 0; i < rows; i++) {
            for(int j = 0; j < columns; j++) {
                layout[i][j] = table.get(i).get(j);
            }
        }

        return layout;
    }

    private static ArrayList<Character> parseCharacters(String str) {
        ArrayList<Character> characters = new ArrayList<>();

        String[] splitString = str.split(" ");

        for(String s : splitString) {
            characters.add(s.charAt(0));
        }

        return characters;
    }

}
