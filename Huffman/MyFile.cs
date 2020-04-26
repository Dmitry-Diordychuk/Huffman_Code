using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Huffman
{
    public class MyFile
    {
        public List<string> Content = new List<string>();
        public string Path { get; set; }
        public MyFile(string path)
        {
            Path = path;
            using( StreamReader reader = new StreamReader( Path ) )
            {
                while( reader.Peek() > 0 )
                {
                    Content.Add(reader.ReadLine());
                }
            }
        }

        public void WriteToMyFile(List<string> text)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                foreach (var str in text)
                {
                    writer.WriteLine(str);
                }
            }
        }

        public override string ToString()
        {
            string str;

            str = "";
            foreach (var el in Content)
            {
                str = str + el;
            }
            return str;
        }
    }
}
