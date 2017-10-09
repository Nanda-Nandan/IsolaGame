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
            if (!AddtoList())
            {
                ClearConsole();
            }
            for (int i = 1; i < MatrixLength; i++)
			{
				if (!AddtoList()) {
					i = i - 1;
					ClearConsole();
				}
			}
		}

		private void ClearConsole()
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop-1);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLineCursor-1);
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
            bool isValid = true;
            if (MatrixLength != 0 && input.Count != MatrixLength)
            {
                isValid = false;
            }
            else
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (!Enumerable.Range(0, 3).Contains(input[i]))
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            return isValid;
        }
    }
}
