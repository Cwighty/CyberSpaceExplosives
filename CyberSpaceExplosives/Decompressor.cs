using System.Text.RegularExpressions;
using System.Linq;

namespace CyberSpaceExplosives
{
    public class Decompressor
    {
        private string answer;
        private string fromFile;
        private int parenthesisCount = 1;

        public Decompressor(string path)
        {
            string filePath = Environment.CurrentDirectory+ @"../../../../"+  path;
            this.fromFile = System.IO.File.ReadAllLines(filePath)[0];
        }
        public Decompressor()
        {

        }
        public void SetFromFile(string fromfile)
        {
            this.fromFile = fromfile;
        }
        public static (int numNextChars, int numOfRep) CommandBlockOperation(string commandBlock)
        {
            string numChar = "";
            string numRepeats = "";
            int i = 0;

            while (commandBlock[i] != 'x')
            {
                numChar += commandBlock[i];
                i++;
            }
            i++;
            while (i < commandBlock.Length)
            {
                numRepeats += commandBlock[i];
                i++;
            }

            return (Convert.ToInt32(numChar), Convert.ToInt32(numRepeats));
        }
        public void Decompress()
        {

            int i = 0;
            (int nextCharCount, int numReps) NextCharsandReps;

            while (i < this.fromFile.Length)
            {
                if (this.fromFile[i] == '(')
                {
                    i++;
                    string commandBlock = "";
                    while (this.fromFile[i] != ')')
                    {
                        commandBlock += this.fromFile[i];
                        i++;
                    }
                    i++;

                    NextCharsandReps = CommandBlockOperation(commandBlock);

                    string charsToRepeat = "";
                    int j = 0;
                    while (j < NextCharsandReps.nextCharCount)
                    {
                        charsToRepeat += this.fromFile[i];
                        j++;
                        i++;
                    }


                    for (j = 0; j < NextCharsandReps.numReps; j++)
                    {
                        this.answer += charsToRepeat;
                    }
                }
                else
                {
                    this.answer += this.fromFile[i];
                    i++;
                }

            }
        }

        public void DecompressUntilNoMoreCommandBlocks()
        {
            this.answer = "";
            Decompress();
            CountParenthesisPairs();
            
            while(this.parenthesisCount != 0)
            {
                if(this.parenthesisCount > 0)
                 {
                    this.fromFile = this.answer;
                    this.answer = "";
                    Decompress();
                 }
                CountParenthesisPairs();
            }

        }

        public void CountParenthesisPairs()
        {
            int parenthesisCount = 0;
            for (int i = 0; i < this.fromFile.Length; i++)
            {
                if (this.fromFile[i] == '(')
                {
                    parenthesisCount++;
                }
            }
            this.parenthesisCount = parenthesisCount;
        }
        public int GetLengthOfDecompressedString()
        {
            return this.answer.Length;
        }

        public string GetDeompressedString()
        {
            return this.answer;
        }
    }
}