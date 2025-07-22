using System;

class Program
{
    static void Main()
    {
        string input = "welcome to dotnet programming";
        string[] words = input.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (i % 2 != 0) // Reverse alternate words (odd indices)
            {
                char[] charArray = words[i].ToCharArray();
                Array.Reverse(charArray);
                words[i] = new string(charArray);
            }
        }

        string result = string.Join(" ", words);
        Console.WriteLine(result);
    }
}
