using System.Text.RegularExpressions;
using System.Linq;

namespace CyberSpaceExplosives
{
    public class Decompressor
    {
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
        public static string Decompress(string input)
        {
            string answer = "";
            int i = 0;
            (int nextCharCount, int numReps) NextCharsandReps;

            while (i < input.Length)
            {
                if (input[i] == '(')
                {
                    i++;
                    string commandBlock = "";
                    while (input[i] != ')')
                    {
                        commandBlock += input[i];
                        i++;
                    }
                    i++;

                    NextCharsandReps = CommandBlockOperation(commandBlock);

                    string charsToRepeat = "";
                    int j = 0;
                    while (j < NextCharsandReps.nextCharCount)
                    {
                        charsToRepeat += input[i];
                        j++;
                        i++;
                    }


                    for (j = 0; j < NextCharsandReps.numReps; j++)
                    {
                        answer += charsToRepeat;
                    }
                }
                else
                {
                    answer += input[i];
                    i++;
                }

            }
            return answer;
        }
    }
}