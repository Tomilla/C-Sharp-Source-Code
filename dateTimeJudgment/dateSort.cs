using System;
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
}
