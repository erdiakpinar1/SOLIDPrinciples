using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace DotNetDesignPatternDemos.SOLID.SRP
{
    // Her component tek bir amac icin degistirilmeli ve her component'in tek bir gorevi olmali

    // just stores a couple of journal entries and ways of
    // working with them
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // breaks single responsibility principle
        //public void Save(string filename, bool overwrite = false)
        //{
        //    File.WriteAllText(filename, ToString());
        //}

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            WriteLine(j); //j bir objedir içerisine eklediğimiz stringler addEntry methodu çağrılarak başına counter ve yanıan text olarak eklendi. ve içinde string olduğu için override methoduna girer ve artık text halinde ekrana yazdırma işlemi

            var p = new Persistence(); // classtan instance oluşturuludu.
            var filename = @"c:\temp\journal.txt";
            p.Save(filename, j);
            Process.Start(filename);
        }
    }
    public class Persistence
    {
        public void Save(string filename, Journal j, bool overwrite = false)
        {
            File.WriteAllText(filename, j.ToString());
        }
    }
}

