using CyberSpaceExplosives;
var decompressor = new Decompressor("input.txt");

decompressor.Decompress();
Console.WriteLine($"First Part:\t{decompressor.GetLengthOfDecompressedString()}");

Console.WriteLine("\n\n");

decompressor.DecompressUntilNoMoreCommandBlocks();
Console.WriteLine($"Second Part:\t{decompressor.GetLengthOfDecompressedString()}");

