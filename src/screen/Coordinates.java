package screen;

/**
 * 
 * @author Aaron Reinard
 *
 * Contains coordinates used for keyboard navigation instructions
 * 
 */
public class Coordinates {

  private int x;
  private int y;

  public Coordinates(int x, int y) {
    this.x = x;
    this.y = y;

  }

  public int getX() {
    return x;
  }

  public void setX(int value) {
    this.x = value;
  }

  public int getY() {
    return y;
  }

  public void setY(int value) {
    this.y = value;
  }

}
