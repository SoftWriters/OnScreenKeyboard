package utils;

import java.util.ArrayList;
import java.util.List;
import screen.Coordinates;
import screen.Keyboard;

/**
 * 
 * @author Aaron Reinard
 *
 *         Translate class accepts flat file, and provides methods to generate keyboard instructions
 */

public class Translator {

  private static Keyboard keyboard = new Keyboard();

  /**
   * @return returns list of character string instructions for keyboard
   * @throws Exception
   */
  public static List<String> getKeyboardInstructionStringList(List<String> titles)
      throws Exception {
    List<String> navigationList = new ArrayList<String>();
    for (String title : titles) {
      navigationList.add(getKeyboardInstructionString(title));
    }
    return navigationList;
  }

  /**
   * 
   * @param title media title to be formatted into keyboard character instructions
   * @return formatted keyboard character instructions
   * @throws Exception
   */
  public static String getKeyboardInstructionString(String title) throws Exception {

    // remove unsupported special characters
    title = getFormattedTitle(title);

    String result = "";
    String startValue = "A";
    String endValue = "";

    try {
      for (int i = 0; i < title.length(); i++) {
        endValue = String.valueOf(title.charAt(i));
        result += getSingleCharacterKeybordInstructions(startValue, endValue) + ",";
        if (!endValue.equals(" ")) {
          startValue = endValue;
        } else {
          endValue = startValue;
        }
      }
    } catch (Exception e) {
      throw new Exception("Unable to parse title " + e.getMessage());

    }
    return result.substring(0, result.length() - 1);
  }

  /**
   * creates a set of keyboard charater instructions to navigate between two keys
   * 
   * @param startValue starting character
   * @param endValue
   * @return keyboard instructions to navigate between characters
   * @throws Exception
   */
  private static String getSingleCharacterKeybordInstructions(String startValue, String endValue)
      throws Exception {

    String result = null;

    // if space, don't calculate coordinateDiff, just use 'S'
    if (endValue.equals(" ")) {
      result = "S";
    } else {
      Coordinates startCoordinates = keyboard.getKey(startValue).getCoordinates();
      Coordinates endCoordinates = keyboard.getKey(endValue).getCoordinates();
      Coordinates coordinateDiff = getCoordinateDiff(startCoordinates, endCoordinates);

      String yNavigationString = getSingleCharacterYKeyboardInstructions(coordinateDiff.getY());
      String xNavigationString = getSingleCharacterXKeyboardInstructions(coordinateDiff.getX());
      result = yNavigationString + xNavigationString + "#";
    }
    return result;

  }

  /**
   * creates a horizontal set of keyboard instructions based on integer
   * 
   * @param diff number of character movements required
   * @return a horizontal set of keyboard instructions based on integer
   * 
   */
  private static String getSingleCharacterXKeyboardInstructions(int diff) {

    String result = "";

    for (int i = 0; i < Math.abs(diff); i++) {
      result += getKeyboardInstructionCharacter(diff, "X");
    }

    return result;

  }

  /**
   * creates a vertical set of keyboard instructions based on integer
   * 
   * @param diff number of character movements required
   * @return a horizontal set of keyboard instructions based on integer
   * 
   */
  private static String getSingleCharacterYKeyboardInstructions(int diff) {

    String result = "";

    for (int i = 0; i < Math.abs(diff); i++) {
      result += getKeyboardInstructionCharacter(diff, "Y");
    }

    return result;

  }

  /**
   * 
   * @param direction of navigation
   * @param coordinateType X or Y axis
   * @return character value required for keyboard instructions
   */
  private static String getKeyboardInstructionCharacter(int diff, String coordinateType) {

    String plusValue = null;
    String minusValue = null;

    if (coordinateType.equalsIgnoreCase("X")) {
      plusValue = "L,";
      minusValue = "R,";
    } else {
      plusValue = "U,";
      minusValue = "D,";
    }

    if (diff == 0) {
      return "";
    } else if (diff < 0) {
      return minusValue;
    } else {
      return plusValue;
    }

  }

  /**
   * 
   * @param title
   * @return title with replaced non-alpha numeric characters
   */
  public static String getFormattedTitle(String title) {
    String result = title.replaceAll("[^A-Za-z0-9 ]", "");
    return result;
  }

  /**
   * 
   * @param startCoordinates starting key
   * @param endCoordinates ending key
   * @return difference in keyboard coordinates between two keys
   */
  private static Coordinates getCoordinateDiff(Coordinates startCoordinates,
      Coordinates endCoordinates) {
    int xDiff = startCoordinates.getX() - endCoordinates.getX();
    int yDiff = startCoordinates.getY() - endCoordinates.getY();
    return new Coordinates(xDiff, yDiff);
  }



}
