using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HDOB_conversion
{
    class Conversion
    {
        static int maxsize = 128;              //this variable decide array 'arrs_stack' length
        public static string num_case(object numOrCase, int keysLimit)
        {
            string[] arrs_dict = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Hashtable dict = new Hashtable();
            for (int temp_i = 0; temp_i < 16 - keysLimit; temp_i++)
                dict.Add(temp_i, arrs_dict[temp_i]);
            string numeral = numOrCase as string;
            if (numeral == null)
                return (Convert.ToString(dict[Convert.ToInt32(numOrCase)])).ToUpper();
            else
            {
                int matchCount = 0;
                string caseOutp = "";
                string subCaseInp = "";
                string caseInp = numOrCase.ToString().ToLower();
                for (int temp_i = caseInp.Length - 1; temp_i >= 0; temp_i--)
                {
                    if (caseInp.Length >= 2)
                        subCaseInp = caseInp.Substring(caseInp.Length - 1);
                    else
                        subCaseInp = caseInp;
                    matchCount = 16 - keysLimit;
                    foreach (int keysValue in dict.Keys)
                    {
                        if (subCaseInp == dict[keysValue].ToString())
                        {
                            caseOutp += keysValue.ToString();
                            caseOutp += "-";
                            break;
                        }
                        matchCount--;
                        if (matchCount == 0)
                        {
                            if (keysLimit == 0)
                                Prompt.errorPrompt("hexadecimal", "0~9\' -", " \'a~f(A~F)");
                            if (keysLimit == 8)
                                Prompt.errorPrompt("octal", "0 -", " 7");
                            if (keysLimit == 14)
                                Prompt.errorPrompt("binary", "0 -", " 1");
                        }
                    }
                    caseInp = caseInp.Remove(caseInp.Length - 1);
                }
                caseOutp = caseOutp.Trim().TrimEnd('-');               //Method 2 of get case-input
                return caseOutp;
            }
        }
        public static void hdobConvert(string waitCvt, int keysLimit, char slice, string numType)
        {
            int top = -1;
            int barAddr = 0;
            int num_tmp = 0;
            int[] arri_stack = new int[maxsize];
            while ((barAddr = waitCvt.IndexOf("-")) != -1)
            {
                num_tmp = int.Parse(waitCvt.Substring(0, barAddr));
                if (keysLimit != 14)
                {        //num_tmp not contain binary-numeral 
                    while (num_tmp != 0)
                    {
                        arri_stack[++top] = num_tmp % 2;
                        num_tmp /= 2;
                    }
                }
                else
                {
                    arri_stack[++top] = num_tmp;
                }
                waitCvt = waitCvt.Remove(0, barAddr + 1);
            }
            if (keysLimit != 14)
            {        //num_tmp not contain binary-numeral 
                for (num_tmp = int.Parse(waitCvt); num_tmp != 0; num_tmp /= 2)
                {
                    arri_stack[++top] = num_tmp % 2;
                }
            }
            else
            {
                arri_stack[++top] = num_tmp;
            }
            Console.Write("The fllowing is {0}-number that after transfrom:\n{1}:", numType, numType.Substring(0, 3).ToUpper());
            int curLen = 1;         //  Alias of variable 'current Length', current Length imply output 'target string' length
            if (numType == "binary")
            {
                while (top != -1)
                {
                    Console.Write(arri_stack[top--].ToString());
                    if (curLen % int.Parse(slice.ToString()) == 0)
                    {  //here we can implicitly convert `char` type to `string` type with use "Convert.ToInt32(slice)" statement.
                        Console.Write(" ");
                    }
                    curLen++;
                }
            }

            if (numType == "octal" || numType == "hexadecimal")
            {
                num_tmp = 0;
                int iterate = 0;
                int bottom = 0;     //read Array `arri_stack` from bottom.
                int power = 0;
                string[] arrs_temp = new string[top / int.Parse(slice.ToString()) + 1];       //assign appropriate RAM space to Array `arrs_temp` //top / 3 + 1
                while ((top + 1) % int.Parse(slice.ToString()) != 0)
                {    //completion `arri_stack until` element count can be divisible by `slice`
                    ++top;
                    arri_stack[top] = 0;      //it's optional
                }
                while (bottom <= top)
                {
                    num_tmp += arri_stack[bottom++] * (int)System.Math.Pow(2, power);
                    if (curLen % int.Parse(slice.ToString()) == 0)
                    {
                        if (numType == "octal")
                        {
                            arrs_temp[iterate] = num_tmp.ToString();
                        }
                        else if (numType == "hexadecimal")
                        {
                            arrs_temp[iterate] = num_case(num_tmp, 0);
                        }
                        num_tmp = 0;
                        power = -1;
                        ++iterate;
                    }
                    power++;
                    curLen++;
                }
                //Digit grouping. i.e:3 777 777..
                while (iterate % int.Parse(slice.ToString()) != 0)
                {
                    Array.Resize(ref arrs_temp, ++iterate);
                }
                //Reverse input Array 'arrs_temp'
                Array.Reverse(arrs_temp);
                curLen = 1;     //reset current Length as zero, since this is a way to implement programer-friendly
                bottom = 0;
                while (bottom < iterate)
                {
                    Console.Write(arrs_temp[bottom++]);
                    if (curLen % int.Parse(slice.ToString()) == 0)
                    {
                        Console.Write(" ");
                    }
                    curLen++;
                }
            }
            Console.WriteLine();
        }
        public static void hdobConvert(string waitList, int demand, string numType)
        {
            int sumResult = 0;
            int barAddr = 0;
            int iterate = 0;
            //int top = -1;
            //int curLen = 1;
            string s_temp = "";
            while ((barAddr = waitList.IndexOf("-")) != -1)
            {
                s_temp = waitList.Substring(0, barAddr);
                sumResult += int.Parse(s_temp) * (int)(System.Math.Pow(demand, iterate++));
                waitList = waitList.Remove(0, barAddr + 1);
            }
            sumResult += int.Parse(waitList) * (int)(System.Math.Pow(demand, iterate));    //Method 2 of sumResult
            Console.Write("The fllowing is {0}-number that after transfrom:\n{1}:", numType, numType.Substring(0, 3).ToUpper());
            s_temp = Convert.ToString(sumResult);
            Console.Write(s_temp);
            //string[] arrs_temp = new string[maxsize];
            //while (!false) {
            //    if (s_temp == "") {
            //        break;
            //    }
            //    arrs_temp[++top] = s_temp.Substring(s_temp.Length - 1);
            //    s_temp = s_temp.Remove(s_temp.Length - 1);
            //}
            //while (top != -1) {
            //    Console.Write(arrs_temp[top--]);
            //    if (curLen % 3 == 0)
            //    {
            //        Console.Write(",");
            //    }
            //    curLen++;
            //}
            Console.WriteLine();
        }
        public static void hdobConvert(int waitQuence, int demand, string numType)
        {
            int top = maxsize;
            int curLen = 1;
            string[] arrs_stack = new string[maxsize];
            while (waitQuence != 0)
            {
                arrs_stack[--top] = waitQuence % demand < 9 ? Convert.ToString(waitQuence % demand) : num_case(waitQuence % demand, 0);
                waitQuence /= demand;
            }
            Console.Write("The fllowing is {0}-number that after transfrom:\n{1}:", numType, numType.Substring(0, 3).ToUpper());
            while (top != maxsize)
            {
                Console.Write(arrs_stack[top++]);
                if (curLen % 4 == 0)        //each 4 row print a 'space' show as digit group, result in user friendly and more readability
                    Console.Write(" ");
                curLen++;
                //                bigEndian = arrs_stack[top--];
                //                Console.Write(Convert.ToString(bigEndian));
            }
            Console.WriteLine();
        }
    }
}
