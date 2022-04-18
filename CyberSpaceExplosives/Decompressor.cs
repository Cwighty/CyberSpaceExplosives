using System.Text.RegularExpressions;
using System.Linq;

namespace CyberSpaceExplosives
{
    public class Decompressor
    {
        public static string Decompress(string input)
        {
            var decompressedString = "";

            for (int index = 0; index < input.Length; index++)
            {
                if(input[index] == '(')
                {
                    string selectionParse = "", repetitionParse = "";
                    index++;
                    while (input[index] != 'x')
                    {
                        selectionParse += input[index];
                        index++;
                    }
                    index++;
                    while (input[index] != ')')
                    {
                        repetitionParse += input[index];
                        index++;
                    }
                    index++;
                    var selection = MakeSelection(input, index, selectionParse);
                    index += selection.Length;
                    decompressedString += RepeatSelection(repetitionParse, selection);
                }
                if (index < input.Length)
                {
                    if(input[index] == '(')
                    {
                        index--;
                        continue;
                    }
                    decompressedString += input[index];  
                }
            }
            return decompressedString; 
        }

        private static string MakeSelection(string input, int currentIndex, string selectionSize)
        {
            var selection = "";
            var selectionCount = Convert.ToInt32(selectionSize);
            for (int sel = currentIndex; sel < currentIndex + selectionCount; sel++)
            {
                selection += input[sel];
            }
            return selection;
        }

        private static string RepeatSelection(string repetitionParse, string selection)
        {
            var decompressedString = "";
            for (int rep = 0; rep < Convert.ToInt32(repetitionParse); rep++)
            {
                decompressedString += selection;
            }
            return decompressedString;
        }

        public static string DecompressTwice(string input)
        {
            return (Decompress(Decompress(input)));
        }
    }
}