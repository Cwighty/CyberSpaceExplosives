// See https://aka.ms/new-console-template for more information
using CyberSpaceExplosives;
var output = Decompressor.Decompress(System.IO.File.ReadAllText(Environment.CurrentDirectory + "/../../../advent.txt"));
Console.WriteLine(output.Length);