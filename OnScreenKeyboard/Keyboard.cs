namespace SoftWriters {
    public class Keyboard {
        public static string[] KeyLayout { get; } = new string[] {
            "ABCDEF",
            "GHIJKL",
            "MNOPQR",
            "STUVWX",
            "YZ1234",
            "567890"
        };

        public static int ColumnCount = KeyLayout[0].Length;
        public static int RowCount = KeyLayout.Length;

        // In a real application, the Keyboard wouldn't hold the text
        // but would likely pass keys to another class that would build up a string
        // (e.g., something like Reactive Extensions for event passing)
        public string Text { get; set; }

        private Position InitialPosition = new Position(0, 0);
        private Position cursor;

        public Keyboard() {
            Reset();
        }

        public void Reset() {
            cursor = InitialPosition;
            Text = "";
        }

        // Handles wrap-around cases
        public void MoveCursor(Position movement) {
            // Since origin is in upper-left corner, all Y values are <= 0 and 
            // all X values are >= 0. Therefore, Y wrap-around check subtracts the RowCount, to ensure
            // value is in range and negative
            cursor = new Position(
                (cursor.X + movement.X + ColumnCount) % ColumnCount, 
                (cursor.Y + movement.Y - RowCount) % RowCount
            );
        }

        public void AddKeyAtCursor() {
            Text += keyFromPosition(cursor);
        }

        private char keyFromPosition(Position position) {
            // Since the origin point is the upper-left corner, all Y values are <= 0.
            // Invert Y before accessing correct row.
            return KeyLayout[-position.Y][position.X];
        }

        public void AddSpace() {
            Text += " ";
        }
    }

}

