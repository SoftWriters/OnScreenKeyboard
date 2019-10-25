import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

class KeyboardTester {

    private static Keyboard alphabeticalKeyboard;
    private static Keyboard qwertyKeyboard;

    @BeforeAll
    static void setUpKeyboards() {
        String rootPath = "/Users/michaelbarton/IdeaProjects/OnScreenKeyboard/src/keyboardLayouts/";
        String alphabeticalFileName = "alphabeticalLayout.txt";
        String qwertyFileName = "qwertyLayout.txt";

        // Create both Keyboards
        char[][] alphabeticalKeyboardLayout = KeyboardScripter.createKeyboardLayout(rootPath +
                alphabeticalFileName);
        char[][] qwertyKeyboardLayout = KeyboardScripter.createKeyboardLayout(rootPath + qwertyFileName);

        alphabeticalKeyboard = new Keyboard(alphabeticalKeyboardLayout);
        qwertyKeyboard = new Keyboard(qwertyKeyboardLayout);
    }

    /**
     * All Alphabetical keyboard tests
     */
    @Test
    void emptyLineAlphabetical() {
        assertEquals("", alphabeticalKeyboard.scriptLine(""));
    }

    @Test
    void selectAndDoneAlphabetical() {
        assertEquals("#", alphabeticalKeyboard.scriptLine("A"));
    }

    @Test
    void bottomRightAlphabetical() {
        assertEquals("D,D,D,D,D,R,R,R,R,R,#", alphabeticalKeyboard.scriptLine("0"));
    }

    @Test
    void singleErrorAlphabetical() {
        assertEquals("E", alphabeticalKeyboard.scriptLine("+"));
    }

    @Test
    void singleSpaceAlphabetical() {
        assertEquals("S", alphabeticalKeyboard.scriptLine(" "));
    }

    @Test
    void allLettersAlphabetical() {
        assertEquals("D,D,#,U,R,R,#,U,#,D,L,#,U,L,#,R,R,R,R,#,D,R,#",
                alphabeticalKeyboard.scriptLine("Michael"));
    }

    @Test
    void lettersAndSpacesAlphabetical() {
        assertEquals("D,R,#,U,R,R,R,#,D,D,R,#,U,U,L,#,S,D,D,D,#,U,U,U,#,S,D,L,L,L,L,#,D,R,R,#,S,D,L,L,#,R,#" +
                        ",U,U,U,R,R,R,#,#,D,R,#,U,L,#,D,D,R,#,D,L,L,L,L,L,#",
                alphabeticalKeyboard.scriptLine("Here we go Steelers"));
    }

    @Test
    void lettersAndErrorsAlphabetical() {
        assertEquals("D,D,R,R,R,#,U,L,#,D,R,R,R,#,U,U,L,L,L,L,L,#,D,D,D,R,#,U,U,U,R,R,R,#,D,D,D,L,L,L,L,#," +
                "E,U,R,R,R,#,U,U,R,#,D,D,L,L,L,#,U,L,#,D,D,R,R,#,U,U,#,D,L,#,D,L,#",
                alphabeticalKeyboard.scriptLine("Pirates/Penguins"));
    }

    @Test
    void spacesAndErrorsAlphabetical() {
        assertEquals("E,E,E,E,E,S,E,E,E,E,E,E,E", alphabeticalKeyboard.scriptLine("@@#$! #@$%^*%"));
    }

    @Test
    void lettersSpacesAndErrorsAlphabetical() {
        assertEquals("D,R,R,R,R,R,#,U,L,#,D,D,D,L,L,L,#,E,L,#,S,U,U,#,D,R,R,#,S,R,#,U,U,R,#,D,D,L,L,L,#" +
                ",D,L,#,E", alphabeticalKeyboard.scriptLine("Let's go Pens!"));
    }

    @Test
    void lettersSpacesAndNumbersAlphabetical() {
        assertEquals("D,D,D,#,R,#,U,U,U,R,R,R,#,#,D,R,#,U,L,#,D,D,R,#,D,L,L,L,L,L,#,S,U,U,U,#,D,D,R,R,R," +
                "R,R,#,U,U,L,#,S,D,D,L,L,L,#,D,R,#,U,L,L,#,U,U,R,#,R,R,R,#,D,D,R,#,S,D,D,L,L,L,#",
                alphabeticalKeyboard.scriptLine("Steelers are number 1"));
    }



    /**
     * All Qwerty keyboard tests
     */
    @Test
    void emptyLineQwerty() {
        assertEquals("", qwertyKeyboard.scriptLine(""));
    }

    @Test
    void selectAndDoneQwerty() {
        assertEquals("#", qwertyKeyboard.scriptLine("Q"));
    }

    @Test
    void bottomRightQwerty() {
        assertEquals("D,D,R,R,R,R,R,R,R,R,R,R,R,#", qwertyKeyboard.scriptLine("9"));
    }

    @Test
    void singleErrorQwerty() {
        assertEquals("E", qwertyKeyboard.scriptLine("+"));
    }

    @Test
    void singleSpaceQwerty() {
        assertEquals("S", qwertyKeyboard.scriptLine(" "));
    }

    @Test
    void allLettersQwerty() {
        assertEquals("D,D,R,R,R,R,R,R,#,U,U,R,#,D,D,L,L,L,L,L,#,U,R,R,R,#,L,L,L,L,L,#,U,R,R,#,D,R,R,R,R,R,R,#",
                qwertyKeyboard.scriptLine("Michael"));
    }

    @Test
    void lettersAndSpacesQwerty() {
        assertEquals("D,R,R,R,R,R,#,U,L,L,L,#,R,#,L,#,S,L,#,R,#,S,D,R,R,#,U,R,R,R,R,#,S,D,L,L,L,L,L,L,L," +
                        "#,U,R,R,R,#,L,L,#,#,D,R,R,R,R,R,R,#,U,L,L,L,L,L,L,#,R,#,D,L,L,#",
                qwertyKeyboard.scriptLine("Here we go Steelers"));
    }

    @Test
    void lettersAndErrorsQwerty() {
        assertEquals("R,R,R,R,R,R,R,R,R,#,L,L,#,L,L,L,L,#,D,L,L,L,#,U,R,R,R,R,#,L,L,#,D,L,#,E,U,R,R,R,R,R," +
                        "R,R,R,#,L,L,L,L,L,L,L,#,D,D,R,R,R,#,U,L,#,U,R,R,#,R,#,D,D,L,L,#,U,L,L,L,L,#",
                qwertyKeyboard.scriptLine("Pirates/Penguins"));
    }

    @Test
    void spacesAndErrorsQwerty() {
        assertEquals("E,E,E,E,E,S,E,E,E,E,E,E,E", qwertyKeyboard.scriptLine("@@#$! #@$%^*%"));
    }

    @Test
    void lettersSpacesAndErrorsQwerty() {
        assertEquals("D,R,R,R,R,R,R,R,R,#,U,L,L,L,L,L,L,#,R,R,#,E,D,L,L,L,#,S,R,R,R,#,U,R,R,R,R,#,S,R," +
                "#,L,L,L,L,L,L,L,#,D,D,R,R,R,#,U,L,L,L,L,#,E", qwertyKeyboard.scriptLine("Let's go Pens!"));
    }

    @Test
    void lettersSpacesAndNumbersQwerty() {
        assertEquals("D,R,#,U,R,R,R,#,L,L,#,#,D,R,R,R,R,R,R,#,U,L,L,L,L,L,L,#,R,#,D,L,L,#,S,L,#,U,R,R,R" +
                ",#,L,#,S,D,D,R,R,R,#,U,U,R,#,D,D,#,L,L,#,U,U,L,L,#,R,#,S,R,R,R,R,R,R,R,R,#",
                qwertyKeyboard.scriptLine("Steelers are number 1"));
    }

}
