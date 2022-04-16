using System.Text.RegularExpressions;
using System.Linq;

namespace CyberSpaceExplosives
{
    public class Decompressor
    {
        public static string Decompress(string input)
        {
            int selectionCount = 0;
            int repetitionCount = 0;
            string finalString = "";
            string tempString = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    string selections = "";
                    string repetitions = "";
                    i++;
                    while (input[i] != 'x')
                    {
                        selections += input[i];
                        i++;
                    }
                    i++;
                    while (input[i] != ')')
                    {
                        repetitions += input[i];
                        i++;
                    }
                    i++;

                    selectionCount = Convert.ToInt32(selections);
                    repetitionCount = Convert.ToInt32(repetitions);

                    for (int j = i; j < i + selectionCount; j++)
                    {
                        tempString += input[j];
                    }
                    i += selectionCount;
                    for (int k = 0; k < repetitionCount; k++)
                    {
                        finalString += tempString;
                    }
                    tempString = "";
                }
                if (i < input.Length)
                {
                    if (input[i] == '(')
                    {
                        i--;
                        continue;
                    }
                    finalString += input[i];
                }
            }
            return finalString;
        }
    }
}