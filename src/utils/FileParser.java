package utils;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.function.Function;
import java.util.stream.Collectors;

public class FileParser {

  /**
   * 
   * @param filePath inputFile
   * @return list of strings parsed from flat file
   * @throws IOException
   */
  public static List<String> parseFlatFile(String filePath) throws IOException {
    List<String> resultList = new ArrayList<String>();
    try {
      File input = new File(filePath);
      InputStream inputStream = new FileInputStream(input);
      BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
      resultList = reader.lines().map(mapToString).collect(Collectors.toList());
      reader.close();
    } catch (Exception e) {
      throw new IOException("unable to parse file " + filePath + "; " + e.getMessage());
    }
    return resultList;
  }

  private static Function<String, String> mapToString = (line) -> {
    String items[] = line.split("\\r?\\n");
    String item = items[0];
    return item;

  };

}
