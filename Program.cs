/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_judgment_Progrom
{
    class Program
    {
        static void Main(string[] args)
        {
            int []ymd = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            int leap, sum;
            leap = sum = 0;
            
            Console.Write("Please input current year, month, and day intermation:\n");
            int year = Convert.ToInt16(Console.ReadLine());
            if (year % 4 == 0 || year % 100 == 0 && year % 400 == 0)
                leap = 1;
            else
                leap = 0;

            int month = Convert.ToInt16(Console.ReadLine());
            if (!(0 < month && month <= 12))
            {
                Console.WriteLine("intput month number illegal, please checked");
                Console.ReadLine();
                return;
            }

            int day = Convert.ToInt16(Console.ReadLine());
            if (!(0 < day && day <= 31))
            {
                Console.WriteLine("intput day number illegal, please checked");
                Console.ReadLine();
                return;
            }

            for(int num = 0; num < month; ++num)
            {
                sum += ymd[num];
            }
            sum = leap != 0 ? sum += day + 1 : sum += day;
            Console.WriteLine("Now Date is NO." + sum.ToString() + " day of " + year.ToString() + " year.");
            Console.ReadLine();
        }
    }
}
*/
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Date_judgment_Progrom
{

    class Datesort
    {
        public int i = 0;
        public int t = 0;
        public int sort(int year, int month, int day)
        {
/*
            for (i = 1; i < month; i++) {
                if (i <= 7) {
                    if (i % 2 != 0)
                        t += 31;
                    else if (i == 2) {
                        if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) {
                            t += 29;
                        }
                        else {
                            t += 28;
                        }
                    }
                    else
                        t += 30;
                }
                else {
                    if (i % 2  != 0)
                        t += 30;
                    else
                        t += 31;
                }
            }
            return t += day;
*/
            for(++i; i < month; i++) {
                if ((i == 1) || (i == 3) || (i == 5) || (i == 7) || (i == 8) || (i == 10) || (i == 12))
                    t += 31;
                else if (i == 2) {
                    if (year % 4 == 0 || year % 100 == 0 && year % 400 == 0)
                        t += 29;
                    else
                        t += 28;
                }
                else
                    t += 30;
            }
            return t += day;
        }
    }
    class Dateinput : Datesort
    {
        public void sort()
        {
                    
        }
    }
    class program_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input date information,Note that the input format is YYYY-MM-DD:");
            int n, day, month, year;
            n = day = month = year = 0;
            string dmy = Console.ReadLine();
            string []dmy_array = dmy.Split('-');
            foreach (string temp in dmy_array)
            {
                if (n == 0)
                    year = int.Parse(temp.Trim());
                if (n == 1)
                    month = int.Parse(temp.Trim());
                if (n == 2) {
                    day = int.Parse(temp.Trim());
                for(++i; i < month; i++) {
                if ((i == 1) || (i == 3) || (i == 5) || (i == 7) || (i == 8) || (i == 10) || (i == 12)) {
                        if (day < 1 || 31 < day) {
                        Console.WriteLine("Error: User enter day number should be within '1-31', please check it.");
                        return;
                        }
                    }
                else if (i == 2) {
                    if (year % 4 == 0 || year % 100 == 0 && year % 400 == 0)
                        t += 29;
                    else
                        t += 28;
                }
                else
                    t += 30;
            }
                    if (day < 1 || 31 < day) {
                        Console.WriteLine("Error: User enter day number should be within '1-31', please check it.");
                        return;
                    }    
                }     
                n++;
            }
            
            Datesort ds = new Datesort();
            n = ds.sort(year, month, day);
/*
            switch (month) {
                case 12:
                    day += 30;
                case 11:
                    day += 31;
                case 10:
                    day += 30;
                case 9:
                    day += 31;
                case 8:
                    day += 31;
                case 7:
                    day += 30;
                case 6:
                    day += 31;
                case 5:
                    day += 30;
                case 4:
                    day += 31;
                case 3:
                    day += 28;
                case 2:
                    day += 31;
                case 1:
                    day += 0;
                default:
                    Console.WriteLine("Error: User input month number should be within '1-12', plese check it.");
                    break;
            }

            Console.WriteLine("Now date is NO.{0} day of {1} year.",
              ((year % 4 == 0 || year % 100 == 0 && year % 400 == 0) ? day += 1 : day), year);

*/
            Console.WriteLine("Now date is NO.{0} day of {1} year.",
                             n, year);
            Console.ReadLine();
        }
    }

/*
    class Program_2
    {
        static void Main(string[] args)
        {
            int []ymd = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            int num, sum;
            sum = num = 0;
//            int leap = 0;

            Console.Write("Please input current year, month, and day intermation:\n");
            int year = Convert.ToInt16(Console.ReadLine());
            if (year % 4 == 0 || year % 100 == 0 && year % 400 == 0)
                ymd[2] = 29;

            int month = Convert.ToInt16(Console.ReadLine());
            if (!(0 < month && month <= 12))
            {
                Console.WriteLine("intput month number illegal, please check it.");

                Console.ReadLine();
                return;
            }

            int day = Convert.ToInt16(Console.ReadLine());
            if (!(0 < day && day <= 31))
            {
                Console.WriteLine("intput day number illegal, please check.");
                Console.ReadLine();
                return;
            }

            for(; num < month; num++)
            {
                sum += ymd[num];
            }
//            sum = leap != 0 ? sum += day + 1 : sum += day;
            sum += day;
            Console.WriteLine("Now Date is NO." + sum.ToString() + " day of " + year.ToString() + " year.");
            Console.ReadLine();
        }
    }
*/
