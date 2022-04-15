using System.Text.RegularExpressions;
using System.Linq;

namespace CyberSpaceExplosives
{
    public class Decompressor
    {
        public string function()
        {
            return null;
        }
        public static string Decompress(string input)
        {
            var pattern = new Regex(@"[(][\d][x][\d][)]");
            var matches = pattern.Matches(input);
            var selectionPattern = new Regex(@"[)](.*)");
            var selection = selectionPattern.Matches(input)[0].Value.ToString();
            var selectionCount = 0;
            var repetitionCount = 0;
            if (matches.Count > 0)
            {
                selectionCount = Convert.ToInt32(matches[0].Value.ToString()[1].ToString());
                repetitionCount = Convert.ToInt32(matches[0].Value.ToString()[3].ToString());
            }
            var finalString = "";
            
            
            bool insideMarker = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    insideMarker = true;
                    
                }
                if (insideMarker)
                {
                    for (int k = 0; k < repetitionCount; k++)
                    {
                        finalString += selection[1];
                    }
                }
                if(input[i] == ')')
                {
                    insideMarker = false;
                }
                if(!insideMarker)
                    finalString += input[i];
            }

            return finalString;


        }
    }
}