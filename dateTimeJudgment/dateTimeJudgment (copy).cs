﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//using System.Threading.Tasks;

namespace Date_and_Time_Judgment_CA
{
    class Datesort
    {
        public int i = 0;
        public long lt = 0;
        public int it = 0;
        public int yearRecurse(int years)
        {
            int temporarily;
            if (years == 1)
                temporarily = 365;
            else
            {
                int leap = years % 4 == 0 && years % 100 != 0 || years % 400 == 0 ? 366 : 365;
                temporarily = yearRecurse(years - 1) + leap;
            }
            return temporarily;
        }
        public int sort(int year, int month, int day)
        {
            for (++i, it = 0; i < month; i++)
            {
                if ((i == 1) || (i == 3) || (i == 5) || (i == 7) || (i == 8) || (i == 10) || (i == 12))
                    it += 31;
                else if (i == 2)
                {
                    if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                        it += 29;
                    else
                        it += 28;
                }
                else
                    it += 30;
            }
            i = 0;
            return it += day;
        }
        public void sort(int year, int month, int day, int days)
        {
            int leap = 0;
            int monthNum = 1;
            int afterD = days;
            afterD += sort(year, month, day);
            int[]monthD = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            for (it = 0; afterD >= 365; it++) {
                if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) {
                    leap = 1;
                    afterD -= 366;
                    year += 1;
                }
                else {
                    leap = 0;
                    afterD -= 365;
                    year += 1;
                }
            }
            if (leap == 1) {
                for (;afterD >= monthD[2] && monthNum < 12; monthNum++)
                    if (afterD - monthD[monthNum] >= 1)
                        afterD -= monthD[monthNum];
                    else break;
                day = afterD;
                month = monthNum;
            }
            else {
                if (year % 4 == 0 || year % 100 == 0 && year % 400 == 0)
                    monthD[2] = 29;
                for (; afterD >= monthD[2] && monthNum < 12; monthNum++)
                    if (afterD - monthD[monthNum] >= 1)
                        afterD -= monthD[monthNum];
                    else break;
                day = afterD;
                month = monthNum;
            }
            Console.WriteLine("after {0} da{1} is {2} year {3} month {4} day.", days, days !=1 ? "ys": "y", year, month, day);
        }
        public void sort(int year, int month, int day, int hour, int minite)
        {
            int week = yearRecurse(year-1) + sort(year, month, day);
  //Method 1
  //          for (int years = --year; years >= 1; years--) {
  //              if (years % 4 == 0 && years % 100 != 0 || years % 400 == 0)
  //                  week += 366;
  //              else
  //                  week += 365;
  //          }

            Hashtable ht = new Hashtable();
            ht.Add(0, "Sun");
            ht.Add(1, "Mon");
            ht.Add(2, "Tues");
            ht.Add(3, "Wednes");
            ht.Add(4, "Thurs");
            ht.Add(5, "Fri");
            ht.Add(6, "Satur");
            ht.Add(7, "Sun");
            week %= 7;       //0001 year's firstdays is start form sunday, so do that.
            Console.WriteLine("{0}day of this week, after {1} hour {2} minite is {3}day...", ht[week], 23 - hour, 60 - minite, ht[week+1]);
            week = 0;
        }
        public void sort(int year, int month, int day, int hour, int minite, long second)
        {
            int si;
            for (si = 0, lt = 0; si < sort(year, month, day); si++)
                lt += 24 * 60 * 60;
            for(si = 0; si < hour; si++)
                lt += 60 * 60;
            for(si = 0; si < minite; si++)
                lt += 60;
            si = 0;
            lt += second;
            Console.WriteLine("That time is NO.{0} second of {1} year.", lt, year);
            Console.ReadLine();
        }
    }
    class Prompt
    {
        public void prompt_error(string errorReason, string withinBengin, string withinEnd)
        {
            Console.WriteLine("Error: \"{0}\" information should be within '{1}-{2}', please check and retry.", errorReason, withinBengin, withinEnd);
            Console.ReadLine();
            return;
        }
    }

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
                            if (!(hour >= 0 && 24 >= hour)) {
                                tips.prompt_error("hour", "1", "59");
                                input_hmt();
                            }
                            break;
                        case 1:
                            minite = Convert.ToInt16(temp.Trim());
                            if (!(minite >= 0 && 60 >= minite)) {
                                tips.prompt_error("minite", "1", "59");
                                input_hmt();
                            }
                            break;
                        case 2:
                            second = Convert.ToInt16(temp.Trim());
                            if (!(second >= 0 && 60 >= second)) {
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
/////////////////////////////////////BACKUP CODE//////////////////////////////////


//class Program_2
//{
//    static void Main(string[] args)
//    {
//        int[] ymd = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
//        int num, sum;
//        sum = num = 0;
//        //            int leap = 0;

//        Console.Write("Please input current year, month, and day intermation:\n");
//        int year = Convert.ToInt16(Console.ReadLine());
//        if (year % 4 == 0 || year % 100 == 0 && year % 400 == 0)
//            ymd[2] = 29;

//        int month = Convert.ToInt16(Console.ReadLine());
//        if (!(0 < month && month <= 12))
//        {
//            Console.WriteLine("intput month number illegal, please check it.");

//            Console.ReadLine();
//            return;
//        }

//        int day = Convert.ToInt16(Console.ReadLine());
//        if (!(0 < day && day <= 31))
//        {
//            Console.WriteLine("intput day number illegal, please check.");
//            Console.ReadLine();
//            return;
//        }

//        for (; num < month; num++)
//        {
//            sum += ymd[num];
//        }
//        //            sum = leap != 0 ? sum += day + 1 : sum += day;
//        sum += day;
//        Console.WriteLine("Now Date is NO." + sum.ToString() + " day of " + year.ToString() + " year.");
//        Console.ReadLine();
//    }
//}

//Another Method: Sum of all day of ****year **month ** day
//            for (i = 1; i < month; i++)
//            {
//                if (i <= 7)
//                {
//                    if (i % 2 != 0)
//                        it += 31;
//                    else if (i == 2)
//                    {
//                        if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
//                        {
//                            it += 29;
//                        }
//                        else
//                        {
//                            it += 28;
//                        }
//                    }
//                    else
//                        it += 30;
//                }
//                else
//                {
//                    if (i % 2 != 0)
//                        it += 30;
//                    else
//                        it += 31;
//                }
//            }
//            return it += day;

//ANOTHER METHOD: sum all days of current year.
//           switch (month) {
//               case 12:
//                   day += 30;
//               case 11:
//                   day += 31;
//               case 10:
//                   day += 30;
//               case 9:
//                   day += 31;
//               case 8:
//                   day += 31;
//               case 7:
//                   day += 30;
//               case 6:
//                   day += 31;
//               case 5:
//                   day += 30;
//               case 4:
//                   day += 31;
//               case 3:
//                   day += 28;
//               case 2:
//                   day += 31;
//               case 1:
//                   day += 0;
//               default:
//                   Console.WriteLine("Error: User input month number should be within '1-12', plese check it.");
//                   break;
//           }
//           Console.WriteLine("Now date is NO.{0} day of {1} year.",
//             ((year % 4 == 0 || year % 100 == 0 && year % 400 == 0) ? day += 1 : day), year);
