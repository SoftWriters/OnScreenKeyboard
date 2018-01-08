using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class OnScreenKeyboardService : IOnScreenKeyboard
    {
        public KeyboardViewModel ProcessInputFile(HttpPostedFileBase file)
        {
            string[] keyboard = BuildKeyboard();

            string result = new StreamReader(file.InputStream).ReadToEnd();

            if (!string.IsNullOrEmpty(result))
            {
                result = result.ToUpper();
            }

            string dvrMap = MapToKeyboard(keyboard,result);

            KeyboardViewModel vm = new KeyboardViewModel
            {
                DvrProgramming = dvrMap,
                FileName = file.FileName,
                FileContents = result
            };

            return vm;
        }

        private string[] BuildKeyboard()
        {
            String input = "ABCDEF\nGHIJKL\nMNOPQR\nSTUVWX\nYZ1234\n567890";
           
            return input.Split(new[] { '\n' });
        }

        private string MapToKeyboard(string[] keyboard, string fileContents)
        {
            bool start = true;
            int seedIndex = -1;
            int seedPosition = -1;
            string dvrPath = "";

            foreach (var letter in fileContents)
            {
                int index = 0;
                int position = 0;

                if (!letter.ToString().Any(Char.IsWhiteSpace))
                {
                    index = keyboard.Select((s, i) => new { Index = i, Value = s })
                    .Where(t => string.IsNullOrWhiteSpace(letter.ToString()) || t.Value.IndexOf(letter) != -1)
                    .Select(t => t.Index)
                    .Single();

                    //TODO:Validate index
                    position = keyboard[index].IndexOf(letter);
                }

                //We've reached a space
                if (index == 0 && position == 0)
                {
                    dvrPath += "S,";
                    continue;
                }

                if (start)
                {
                    dvrPath += BuildMapping(0, 0, index, position);
                    seedIndex = index;
                    seedPosition = position;
                    start = false;
                }
                else
                {
                    dvrPath += BuildMapping(seedIndex, seedPosition, index, position);
                    seedIndex = index;
                    seedPosition = position;
                }

            }

            return dvrPath;
        }

        private string BuildMapping(int seedIndex, int seedPosition, int index, int position)
        {
            string dvrPath = "";

            if (seedIndex == -1)
            {
                for (int i = 0; i < index; i++)
                {
                    dvrPath += "D,";
                }

                for (int i = 0; i < position; i++)
                {
                    dvrPath += "R,";
                }
                dvrPath += "#,";
            }
            else
            {
                //We need to go lower on the keyboard
                if (seedIndex < index)
                {
                    for (int i = seedIndex; i < index; i++)
                    {
                        dvrPath += "D,";
                    }
                }
                else if (seedIndex > index) //Letter is previous to last 
                {
                    for (int i = seedIndex; i > index; i--)
                    {
                        dvrPath += "U,";
                    }
                }

                if (seedPosition < position)
                {
                    for (int i = seedPosition; i < position; i++)
                    {
                        dvrPath += "R,";
                    }
                }
                else
                {
                    for (int i = seedPosition; i > position; i--)
                    {
                        dvrPath += "L,";
                    }
                }

                dvrPath += "#,";
            }

            return dvrPath;
        }

    }
}