package screen;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Aaron Reinard
 *
 * Keyboard dictionary containing keyset and coordinates
 * 
 */

public class Keyboard {

  private List<Key> keys = null;

  public Keyboard() {
    this.keys = setKeys();
  }

  public List<Key> getKeys() {
    return keys;
  }

  public Key getKey(String value) {
    Key result = null;
    for (Key keyMap : getKeys()) {
      if (keyMap.getValue().equalsIgnoreCase(value)) {
        result = keyMap;
        break;
      }
    }
    return result;
  }


  private List<Key> setKeys() {

    List<Key> keyList = new ArrayList<Key>();
    List<String> lines = new ArrayList<String>();

    lines.add("ABCDEF");
    lines.add("GHIJKL");
    lines.add("MNOPQR");
    lines.add("STUVWX");
    lines.add("YZ1234");
    lines.add("567890");

    int yInt = 0;
    for (String line : lines) {
      for (int xInt = 0; xInt < line.length(); xInt++) {
        String value = String.valueOf(line.charAt(xInt));
        Coordinates coordinates = new Coordinates(xInt, yInt);
        keyList.add(new Key(value, coordinates));
      }
      yInt++;
    }
    return keyList;
  }

}
