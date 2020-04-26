using System;
using System.IO;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            MyFile     text;

            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("Нажмите F1 для кодирования.");
                Console.WriteLine("Нажмите F2 для декодирования.");
                Console.WriteLine("Нажмите q для выхода.");
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.F1:
                        Console.WriteLine("Текст берется из файла text.txt. И кодируется в файл codedText.txt");
                        text = new MyFile("./text.txt");
                        HuffmanAlgo.Init(text);
                        break;
                    case ConsoleKey.F2:
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
