namespace KeyboardWalker
{
    public class FindPattern
    {
        private string[,] _keyboardLayout = new string[6, 6]
        {
            {"A", "B", "C", "D", "E", "F" },            // 65 - 70
            {"G", "H", "I", "J", "K", "L" },            // 71 - 76
            {"M", "N", "O", "P", "Q", "R" },            // 77 - 82
            {"S", "T", "U", "V", "W", "X" },            // 83 - 88
            {"Y", "Z", "1", "2", "3", "4" },            // 89 - 90, 49 - 52
            {"5", "6", "7", "8", "9", "0" }             // 53 - 57, 48
        };

        public FindPattern(string[,] keyboardLayout = null)
        {
            // Check to see if a new keyboard layout was given
            if (keyboardLayout == null)
            {
                _keyboardLayout = keyboardLayout;
            }
        }
    }
}
