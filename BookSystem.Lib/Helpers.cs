using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace BookSystem.Lib
{
    public class Helpers
    {  

        public static string ReadString(string caption,bool required=false)
        {
            l1:
            Console.Write(caption);

            Console.ForegroundColor = ConsoleColor.Cyan;

            string value = Console.ReadLine();

            Console.ResetColor();

            if (required && string.IsNullOrWhiteSpace(value))
            {
                Printerror("Bosh buraxila bilmez");
                goto l1; 

            }

            return value;

        }


        public static int ReadInt(string caption,int minValue = 0)
        {
            l1:

            Console.Write(caption);

            Console.ForegroundColor = ConsoleColor.Cyan;

            string  value = Console.ReadLine();

            Console.ResetColor();

            if (!int.TryParse(value,out int number))
            {
                Printerror("Duzgun reqem daxil edilmeyib");
                goto l1;

            }
            else if (number < minValue)
            {
                Printerror($"Minimal {minValue} daxil edile biler");

                goto l1;
            }

            return number;
        }

        public static double ReadDouble(string caption, double minValue = 0)
        {
        l1:

            Console.Write(caption);

            Console.ForegroundColor = ConsoleColor.Cyan;

            string value = Console.ReadLine();

            Console.ResetColor();

            if (!double.TryParse(value, out double number))
            {
                Printerror("Duzgun reqem daxil edilmeyib");
                goto l1;

            }
            else if (number < minValue)
            {
                Printerror($"Minimal {minValue} daxil edile biler");

                goto l1;
            }

            return number;
        }

        public static MenuStates ReadMenu(string caption)
        {        
            l2:
            Console.Write(caption);

            string value = Console.ReadLine();
             
            if (!Enum.TryParse(value,out MenuStates menu))
            {
                Printerror("Bele menu movcud deyil");
                goto l2;
            }

            bool success=Enum.IsDefined(typeof(MenuStates), menu);

            if (!success)
            {
                Printerror("Bele menu movcud deyil");
                goto l2;
            }

            return menu;
            
        }


        public static void Printerror(string message)
        {
            Console.ForegroundColor= ConsoleColor.DarkRed;

            Console.WriteLine(message);

            Console.ResetColor();

        }

        public static void Init(string AppName)
        {
            Console.Title =AppName;

            Console.OutputEncoding = Encoding.Unicode;

            Console.InputEncoding = Encoding.Unicode;

            CultureInfo ci = new CultureInfo("az-Latn-Az");

            ci.NumberFormat.NumberDecimalSeparator = ".";

            ci.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";

            ci.DateTimeFormat.LongDatePattern = "dd.MM.yyyy HH:mm";

            ci.DateTimeFormat.LongTimePattern = "HH:MM:ss";

            ci.DateTimeFormat.ShortTimePattern = "HH:mm";

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public static void PrintMenu()
        {
            Console.WriteLine("----------------------Menu----------------------");

            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (var item in Enum.GetValues(typeof(MenuStates)))
            {
                Console.WriteLine($"{((byte)item).ToString().PadLeft(2)}.{item}");
            }

            Console.WriteLine("------------------------------------------------");

            Console.ResetColor();
        }





    }
}
