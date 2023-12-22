using System;
using System.Collections.Generic;

List<string> words = new List<string>();
            
Console.WriteLine("Enter the words:");
while (true)
{
    string input = Console.ReadLine();
    if (input == "")
        break;
    words.Add(input);
}

string longword = words[0], shortword = words[0];
for (int i = 0; i < words.Count; i++)
{
    if (words[i].Length > longword.Length)
        longword = words[i];
    if (words[i].Length < shortword.Length)
        shortword = words[i];
}
Console.WriteLine($"The longest word is \"{longword}\", the shortest word is \"{shortword}\".");