using System;
using System.Text.RegularExpressions;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex rx = new Regex(@"\<[a-z]+\>\w+.\w*\</[a-z]+\>");
                       
            string text = "K této knize se svět chová velice <capital>laskavě</capital>. Jen z různých edicí vydaných v <red>Anglii</red> se už prodalo přes půldruhého miliónu výtisků" +
                 ". A v <hide>Chicagu</hide> se mi už před mnoha lety dostalo ujištění - z úst jistého podnikavého piráta nyní v. v. - že víc než <highlight>milión výtisků</highlight> se " +
                 "prodalo ve <green>Spojených státech</green>.";

            MatchCollection matches = rx.Matches(text);
            

            int matchCounter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '<') { Console.Write(text[i]); }
                else
                {
                    Divider(matches[matchCounter].ToString());
                    i = i + matches[matchCounter].Length;
                    matchCounter++;
                }
            }
            Console.ReadLine();
            
            
            
        }
        public static string Divider(string s)
        {
            if (s.Contains("<capital>"))               
            {
                Capital(s);
            }            
            else if (s.Contains("<red>"))
            {
                RedColor(s);
            }            
            else if (s.Contains("<green>"))
            {
                GreenColor(s);
            }            
            else if (s.Contains("<hide>"))
            {
                Hide(s);
            }           
            else if (s.Contains("<highlight>"))
            {
                Highlight(s);
            }
            return s;
        }
        public static string Capital(string s)
        {
            s = s.Remove(0, 9);
            s = s.Remove(s.IndexOf('<'), 10);
            Console.Write(s.ToUpper());
            return s.ToUpper();
        }
        public static string RedColor(string s)
        {
            s = s.Remove(0, 5);
            s = s.Remove(s.IndexOf('<'), 6);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(s);
            Console.ForegroundColor = ConsoleColor.White;
            return s;
        }
        public static string GreenColor(string s)
        {
            s = s.Remove(0, 7);
            s = s.Remove(s.IndexOf('<'), 8);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s);
            Console.ForegroundColor = ConsoleColor.White;
            return s;
        }
        public static string Hide(string s)
        {
            s = s.Remove(0, 3);
            s = s.Remove(s.IndexOf('<'), 4);
            foreach (char item in s)
            {
                Console.Write('*');
            }
            return s;
        }
        public static string Highlight(string s)
        {
            s = s.Remove(0, 11);
            s = s.Remove(s.IndexOf('<'), 12);
            Console.Write("*** " + s.ToUpper() + " ***");
            return s;
        }
    }
}
