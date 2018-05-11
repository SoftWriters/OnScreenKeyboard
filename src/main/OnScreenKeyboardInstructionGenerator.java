package main;

import java.util.List;
import java.util.Scanner;
import utils.FileParser;
import utils.Translator;

/**
 * 
 * @author Aaron Reinard
 *
 *         Generate OnScreen keyboard instructions for media titles in provided in flat file
 * 
 */

public class OnScreenKeyboardInstructionGenerator {

  public static void main(String[] args) throws Exception {

    String file = null;
    Scanner input = new Scanner(System.in);

    try {
      System.out.print("Please enter file: ");
      file = input.next();
      input.close();

      List<String> titleList = FileParser.parseFlatFile(file);
      List<String> keyboardInstructionList = Translator.getKeyboardInstructionStringList(titleList);
      keyboardInstructionList.forEach(x -> System.out.println(x));

    } catch (Exception e) {
      throw new Exception(
          "Unable to translate keyboard instructions for " + file + ". " + e.getMessage());
    }
  }



}
