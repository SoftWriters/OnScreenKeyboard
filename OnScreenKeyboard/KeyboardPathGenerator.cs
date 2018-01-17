using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftWriters {
    public class KeyboardPathGenerator {
        private static Regex validInputCharacter = new Regex("[a-zA-Z0-9]", RegexOptions.Compiled);
        private static Dictionary<char, Position> keyPositions = generateLookupTable();
        private Position InitialPosition = new Position(0, 0);
        private Position cursor;
        

        public KeyboardPathGenerator() {
            Reset();
        }

        public void Reset() {
            cursor = InitialPosition;
        }

        public string GenerateShorthandFrom(string testCase) {
            Reset();
            if(testCase == "") {
                return "";
            }

            List<string> shorthand = new List<string>();
            for(var i = 0; i < testCase.Length; i++) {
                var character = toUpperCase(testCase[i]);
                if (character == ' ') {
                    shorthand.Add("S");
                }
                else if (!validInputCharacter.IsMatch(character.ToString())) {
                    return "Invalid input: " + testCase;
                }
                else {
                    shorthand.Add(shorthandForMoveTo(character));
                }
            }

            return String.Join(",", shorthand);
        }

        //Assumes validated input
        private string shorthandForMoveTo(char character) {
            var characterPosition = keyPositions[character];
            var distance = characterPosition - cursor;

            cursor = characterPosition;

            var shorthand = "";
            if(distance.Y > 0) {
                shorthand += optimizedDirection('D', 'U', distance.Y, Keyboard.RowCount);
            }
            else if(distance.Y < 0) {
                shorthand += optimizedDirection('U', 'D', -distance.Y, Keyboard.RowCount);
            }
            if(distance.X > 0) {
                shorthand += optimizedDirection('R', 'L', distance.X, Keyboard.ColumnCount);
            }
            else if(distance.X < 0) {
                shorthand += optimizedDirection('L', 'R', -distance.X, Keyboard.ColumnCount);
            }

            if (shorthand == "") {
                return "#";
            }
            else {
                return String.Join(",", shorthand.ToCharArray()) + ",#";
            }
        }

        
        private string optimizedDirection(char forward, char backward, int distance, int dimensionSize) {
            if (distance == 0) return "";

            if(distance <= dimensionSize / 2.0) {
                return new string(forward, distance);
            }
            else {
                return new string(backward, dimensionSize - distance);
            }
        }

        // Assumes character is on keyboard
        private static Dictionary<char, Position> generateLookupTable() {
            var table = new Dictionary<char, Position>();
            for(var i = 0; i < Keyboard.RowCount; i++) {
                for(var j = 0; j < Keyboard.ColumnCount; j++) {
                    // Positions are x,y, so positions use j,i indexes
                    table.Add(Keyboard.KeyLayout[i][j], new Position(j, i));
                }
            }
            return table;
        }

        private static char toUpperCase(char character) {
            return character.ToString().ToUpper()[0];
        }
    }
}
