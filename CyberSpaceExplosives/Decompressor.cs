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
                    var selectionParse = "";
                    var repetitionParse = "";
                    index++;
                    while(input[index] != 'x')
                    {
                        selectionParse += input[index];
                        index++;
                    }
                    index++;
                    while(input[index] != ')')
                    {
                        repetitionParse += input[index];
                        index++;
                    }
                    index++;
                    var selection = "";
                    var selectionCount = ConvertToInt(selectionParse);
                    for(int sel = index; sel < index + selectionCount; sel++ )
                    {
                        selection += input[sel];
                    }
                    index += selectionCount;
                    for(int rep = 0; rep < ConvertToInt(repetitionParse); rep++)
                    {
                        decompressedString += selection;
                    }
                }
                if(index < input.Length)
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


        private static int ConvertToInt(string parse)
        {
            return Convert.ToInt32(parse);
        }
    }
}