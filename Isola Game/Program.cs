using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isola_Game
{
    class Program
    {
        private List<int> SquarePosition
        {
            get; set;
        }
        private int MatrixLength
        {
            get;
            set;
        }
        public Program()
        {
            this.SquarePosition = new List<int>();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ParseInput();
        }
        private void ParseInput()
        {
            AddtoList();
            for (int i = 1; i < MatrixLength; i++)
            {
                if (!AddtoList()) {
                    i = i - 1; ;
                    ClearConsole();
                }
            }
        }

        private void ClearConsole()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        private bool AddtoList()
        {
            bool addSuccess = false;
            string inputstring = Console.ReadLine();
            List<int> tempInput = inputstring.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(item => int.Parse(item))
                                 .ToList();
            if (!ValidateInput(tempInput))
            {
                addSuccess=false;
            }
            else
            {
                addSuccess = true;
                if (SquarePosition.Count == 0)
                {
                    MatrixLength = tempInput.Count;
                }
                SquarePosition.AddRange(tempInput);
            }
            return addSuccess;
        }

        private bool ValidateInput(List<int> input)
        {
            bool isValid = false;
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (input[i] == j)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }
    }
}
