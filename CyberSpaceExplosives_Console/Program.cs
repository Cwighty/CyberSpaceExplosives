// See https://aka.ms/new-console-template for more information
using CyberSpaceExplosives;
var path = System.IO.File.ReadAllText(Environment.CurrentDirectory + "/../../../advent.txt");
var output = Decompressor.DecompressTwice(path);
Console.WriteLine(output.Length);