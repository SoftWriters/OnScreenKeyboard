package screen;

/**
 * 
 * @author Aaron Reinard
 *
 */
public class Key {

  private String value;
  private Coordinates coordinates;

  public Key(String character, Coordinates values) {
    setValue(character);
    setCoordinates(values);
  }

  public String getValue() {
    return value;
  }

  public void setValue(String value) {
    this.value = value;
  }

  public Coordinates getCoordinates() {
    return coordinates;
  }

  public void setCoordinates(Coordinates values) {
    this.coordinates = values;
  }

}
