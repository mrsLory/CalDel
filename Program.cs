using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type your first integer:");
            string a = Console.ReadLine();
            Console.WriteLine("Type your second integer:");
            string b = Console.ReadLine();
            Console.WriteLine("Type precision of dividing (number of digits after point):");
            int prec = Convert.ToInt32(Console.ReadLine());
            divide(a, b, prec);
            Console.ReadLine();
        }

        static string removeZeroes(string a)
        {
            while (a.StartsWith("0") && a.IndexOf(".") != 1)
                a = a.Substring(1);
            return a;
        }

        static int divide(string a, string b, int prec)
        {

            //At first we need to 
            int a_fraq = 0;
            int b_fraq = 0;
            if (a.IndexOf('.') > -1)
            {
                while (a.EndsWith("0"))
                {
                    a = a.Remove(a.Length - 1);
                }
                a_fraq = a.Length - a.IndexOf('.') - 1;
            }
            if (b.IndexOf('.') > -1)
            {
                while (b.EndsWith("0"))
                {
                    b = b.Remove(b.Length - 1);
                }
                b_fraq = b.Length - b.IndexOf('.') - 1;
            }

            int fraq_diff = a_fraq - b_fraq;
            while (fraq_diff != 0)
            {
                if (fraq_diff > 0)
                {
                    b += '0';
                    fraq_diff--;
                }
                else
                {
                    a += '0';
                    fraq_diff++;
                }
            }
            a = a.Replace(".", "");
            b = b.Replace(".", "");


            //-------------------
            string result = "";
            int a_pointer = 0;
            int a_int = Convert.ToInt32(a);
            int b_int = Convert.ToInt32(b);


            if (a.Length >= b.Length)
            {
                a_pointer = b.Length;
                a_int = Convert.ToInt32(a.Substring(0, a_pointer));
                b_int = Convert.ToInt32(b);
                //Console.WriteLine(a_int);

                while (a_pointer <= a.Length)
                {
                    int i = 0;
                    while (b_int * (i + 1) <= a_int)
                    {
                        i++;
                    }
                    Console.Write(i);
                    Console.Write(" * ");
                    Console.Write(b_int);
                    Console.Write(" = ");
                    Console.WriteLine(i * b_int);
                    Console.Write(a_int);
                    Console.Write(" - ");
                    Console.Write(i * b_int);
                    Console.Write(" =  ");
                    a_int -= i * b_int;
                    Console.WriteLine(a_int);

                    result += Convert.ToString(i);
                    if (a_pointer != a.Length) a_int = (a_int * 10) + (a[a_pointer] - '0');
                    a_pointer++;

                }
            }

            result = removeZeroes(result);

            if (result == "") result = "0";
            result += ".";

            for (int j = 0; j < prec; j++)
            {

                a_int *= 10;
                int i = 0;
                while (b_int * (i + 1) <= a_int)
                {
                    i++;
                }
                Console.Write(i);
                Console.Write(" * ");
                Console.Write(b_int);
                Console.Write(" = ");
                Console.WriteLine(i * b_int);
                Console.Write(a_int);
                Console.Write(" - ");
                Console.Write(i * b_int);
                Console.Write(" =  ");
                a_int -= i * b_int;
                Console.WriteLine(a_int);

                result += Convert.ToString(i);
                a_pointer++;

            }

            Console.WriteLine(result);
            //Console.WriteLine(b);
            return 0;
        }
    }
}
