using CyberSpaceExplosives;

string final = Decompressor.Decompress(System.IO.File.ReadAllText(Environment.CurrentDirectory + "/../../../advent.txt"));

Console.WriteLine(final.Length);