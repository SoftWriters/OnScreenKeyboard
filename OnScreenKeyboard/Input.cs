using System;

namespace SoftWriters {
    public class Input {
        public static Input UP = new Input("UP", keyboard => keyboard.MoveCursor(new Position(0, 1)));
        public static Input DOWN = new Input("DOWN", keyboard => keyboard.MoveCursor(new Position(0, -1)));
        public static Input LEFT = new Input("LEFT", keyboard => keyboard.MoveCursor(new Position(-1, 0)));
        public static Input RIGHT = new Input("RIGHT", keyboard => keyboard.MoveCursor(new Position(1, 0)));
        public static Input SPACE = new Input("SPACE", keyboard => keyboard.AddSpace());
        public static Input SELECT = new Input("SELECT", keyboard => keyboard.AddKeyAtCursor());

        private string name;
        private Action<Keyboard> keyboardAction;

        public Input(string name, Action<Keyboard> keyboardAction) {
            this.name = name;
            this.keyboardAction = keyboardAction;
        }

        public void Trigger(Keyboard keyboard) {
            keyboardAction(keyboard);
        }
    }
}
