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
            var decompressedString = "";
            var pattern = new Regex(@"[(]([\d])[x]([\d])[)]");
            var matches = pattern.Matches(input);
            var newInput = pattern.Replace(input, x => "");
            var selection = "";
            if(matches.Count > 0)
            {
                var match = matches[0].Groups.Values.Where(x=> !x.Value.Contains("x"));
                var counts = match.Select(x => Convert.ToInt32(x.Value)).ToList();
                var selectionCount = counts[0];
                var repetitionCount = counts[1];
                for(int sel = 0; sel < selectionCount; sel++)
                {
                    selection += newInput[sel];
                }
                for(int rep = 0; rep < repetitionCount; rep++)
                {
                    decompressedString += selection;
                }


            return decompressedString;
            }
            return input;
        }
    }
}