public class Point {

    /**
     * The coordinate pair of this object
     */
    private int i;
    private int j;

    /**
     * Default constructor initializes both to 0
     */
    public Point() {
        i = 0;
        j = 0;
    }

    /**
     * Getters and setters for both i and j
     */
    int getI() {
        return i;
    }

    int getJ() {
        return j;
    }

    void setI(int i) {
        this.i = i;
    }

    void setJ(int j) {
        this.j = j;
    }
}
