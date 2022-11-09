// See https://aka.ms/new-console-template for more information
using clHuffmanCode;
using System.Collections;
Encrypter Encrypter = new();
Console.WriteLine("Hello, World! ");
string input = File.ReadAllText(@"C:\\Users\\DM\\Desktop\\cranshaw.txt");
input = Encrypter.CountChars(input);
var dict = Encrypter.CreateCode();
List<string> tree = Encrypter.WriteTree(dict);
List<byte> bytes = Encrypter.CreateBinary(input, dict);
File.WriteAllLines("C:\\Users\\DM\\Desktop\\tree.huff", tree.ToArray());
File.WriteAllBytes("C:\\Users\\DM\\Desktop\\text.huff", bytes.ToArray());
File.WriteAllText("C:\\Users\\DM\\Desktop\\decrypted.txt", Encrypter.Decode("C:\\Users\\DM\\Desktop\\tree.huff", "C:\\Users\\DM\\Desktop\\text.huff"));
Console.ReadLine();
