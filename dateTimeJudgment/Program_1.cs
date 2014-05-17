using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//using System.Threading.Tasks;

namespace Date_and_Time_Judgment_CA
{
    class Program_1
    {
        public static int n, day, month, year;
        public static int m, hour, minite;
        public static long second = 0;

        class Dateio
        {
            Prompt tips = new Prompt();
            public void input_ymd()
            {
                Console.WriteLine("Please input date information, Note that the input format is 'YYYY MM DD':");
                n = day = month = year = 0;
                string dmy = Console.ReadLine();
                string[] dmy_array = dmy.Split(' ');
                foreach (string temp in dmy_array)
                {
                    if (n == 0) {
                        year = int.Parse(temp.Trim());
                        if (!(year >= 1 && year <= (int)(System.Math.Pow(2, 15) - 1))) {
                            tips.prompt_error("year", "1", (System.Math.Pow(2, 15) - 1).ToString());
                            input_ymd();
                        }
                    }
                    if (n == 1)
                    {
                        month = int.Parse(temp.Trim());
                        if (!(month >= 1 && 12 >= month)) {
                            tips.prompt_error("month", "1","12");
                            input_ymd();
                        }
                    }
                    if (n == 2)
                    {
                        day = int.Parse(temp.Trim());
                        if ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 10) || (month == 12))
                        {
                            if (!(day >= 1 && 31 >= day)) {
                                tips.prompt_error("day", "1", "31");
                                input_ymd();
                            }
                        }
                        else if (month == 2)
                        {
                            if (year % 4 == 0 || year % 100 == 0 && year % 400 == 0)
                            {
                                if (!(day >= 1 && 29 >= day)) {
                                    tips.prompt_error("day", "1", "29");
                                    input_ymd();
                                }
                            }
                            else
                            {
                                if (!(day >= 1 && 28 >= day)) {
                                    tips.prompt_error("day", "1", "28");
                                    input_ymd();
                                }
                            }
                        }
                        else
                        {
                            if (!(day >= 1 && 30 >= day)) {
                                tips.prompt_error("day", "1", "30");
                                input_ymd();
                            }
                        }
                    n++;
                }
            }
            public void input_hmt()
            {
                Console.WriteLine("Please input time information, Note that the input format is 'HH:MM:SS':");
                //                int m, hour, minite;
                //                long second = 0;
                m = hour = minite = 0;
                string hms = Console.ReadLine();
                string[] hms_array = hms.Split(':');
                foreach (string temp in hms_array)
                {
                    switch (m)
                    {
                        case 0:
                            hour = Convert.ToInt16(temp.Trim());
                            if (!(hour >= 0 && 23 >= hour)) {
                                tips.prompt_error("hour", "1", "23");
                                input_hmt();
                            }
                            break;
                        case 1:
                            minite = Convert.ToInt16(temp.Trim());
                            if (!(minite >= 0 && 59 >= minite)) {
                                tips.prompt_error("minite", "1", "59");
                                input_hmt();
                            }
                            break;
                        case 2:
                            second = Convert.ToInt16(temp.Trim());
                            if (!(second >= 0 && 59 >= second)) {
                                tips.prompt_error("second", "1", "59");
                                input_hmt();
                            }
                            break;
                        default:
                            break;
                    }
                    m++;
                }
            }
        }
        public static void followInfo()
        {
            Dateio dio = new Dateio();
            Datesort ds = new Datesort();
            String tabInfo =
                "what can i do for you? young student!\n" +
                //Please choose what you want to Query?\n" +
                "a.\tDay of year.\n" +
                "b.\tSecond of years.\n" +
                "c.\tDay of week.\n" +
                "d.\tAfter *** days is ****year **month **day.";
            Console.WriteLine(tabInfo);
            char tabSelect = Convert.ToChar(Console.ReadLine());
            switch (tabSelect)
            {
                case 'a':
                    dio.input_ymd();
                    Console.WriteLine("Now date is NO.{0} day of {1} year.", ds.sort(year, month, day), year);
                    break;
                case 'b':
                    dio.input_ymd();
                    dio.input_hmt();
                    ds.sort(year, month, day, hour, minite, second);
                    break;
                case 'c':
                    dio.input_ymd();
                    dio.input_hmt();
                    ds.sort(year, month, day, hour, minite);
                    break;
                case 'd':
                    dio.input_ymd();
                    Console.WriteLine("Please enter a after-nowday-number that the day belong witch year of witch month of witch day...");
                    int days = Convert.ToInt16(Console.ReadLine());
                    ds.sort(year, month, day, days);
                    break;
                default:
                    Console.WriteLine("Error: please choose one option of letter'a-d'");
                    break;
            }
        }
        public static void reQuery()
        {
            string requeryTabstr =
                "\nCompute Success!\nDo you want to re-query other information?!\n" +
                "Y or y:\t---->\tback to main interface!\n" +
                "N or n:\t---->\tquit this program, Goodbye :)";
            Console.WriteLine(requeryTabstr);
            char requerySelect = char.Parse(Console.ReadLine());
            if (requerySelect == 'Y' || requerySelect == 'y')
                followInfo();
            else if (requerySelect == 'N' || requerySelect == 'n')
                return;
            else {
                Console.WriteLine("Error: enter letter illegal, please,");
            }
        }
        static void Main(string[] args)
        {
            followInfo();
            reQuery();
            Console.WriteLine("Press <Enter> key to quit...");
            Console.ReadLine();
        }
    }
}
