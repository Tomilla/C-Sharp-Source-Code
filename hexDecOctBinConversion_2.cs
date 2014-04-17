using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace hexDecOctBinConversion
{
    class Prompt : Conversion {
        public static void featureInfo() {
            string str_guide =
                "\nWhat can i do for you, yound fellow?\n" +
                "a)     convert decimal to hexdecimal-number.\n" +
                "b)     reverse a) conversion.\n" +
                "c)     convert decimal to octal-number.\n" +
                "d)     reverse c) conversion.\n" +
                "e)     convert decimal to binay-number.\n" +
                "f)     reverse e) conversion.\n"
            ;
            Console.WriteLine(str_guide);
            char char_userSelect = char.Parse(Console.ReadLine());
            string[] arrs_temp = { "hexdecimal", "octal", "binary" };
            switch (char_userSelect) {
                case 'a':
                    hdobConvert(numInput("decimal"), 16, "hexdecimal");
                    reQuery();
                    break;
                case 'b':
                    hdobConvert(numInput(arrs_temp, 0), 16, "decimal");
                    reQuery();
                    break;
                case 'c':
                    hdobConvert(numInput("decimal"), 8, "octal");
                    reQuery();
                    break;
                case 'd':
                    hdobConvert(numInput(arrs_temp, 1), 8, "octal");
                    reQuery();
                    break;
                case 'e':
                    hdobConvert(numInput("decimal"), 2, "binary");
                    reQuery();
                    break;
                case 'f':
                    hdobConvert(numInput(arrs_temp, 2), 2, "binary");
                    reQuery();
                    break;
                default:
                    Console.WriteLine("Warning: input error, please retry..");
                    featureInfo();
                    break;
            }
        }
        private static void reQuery() {
            System.Random rdm = new System.Random();
            int random = rdm.Next(0, 11) / 10 <= 0.1 ? (rdm.Next(10, 20) > 15 ? 0 : 1) : (rdm.Next(20, 30) > 25 ? 2 : 3);
            //          int random = rdm.Next(0, 4);
            string[] arrs_receive = new string[] {
                "The system work well, ", "Currect answer had been give you, ",
                "So quickly, ", "It's incredible, "
            };
            string str_requery =
                "Query other type number?\n" +
                "Y(y), please tell more knowledge about number conversion.\n" +
                "N(n), Sorry, old sir, i must go home write my homework, see you tomorrow\n"
            ;
            Console.Write("\n\n" + arrs_receive[random] + str_requery);
            char char_userSelect = Convert.ToChar(Console.ReadLine());
            if (char_userSelect == 'Y' || char_userSelect == 'y')
                featureInfo();
            else if (char_userSelect == 'N' || char_userSelect == 'n')
                return;
            else
            {
                Console.WriteLine("Warning:Input error, Please retry..");
                reQuery();
            }
        }
        private static void errorPrompt(string errorType, string withinBegin, string withinEnd) {
            Console.WriteLine("Error: \"{0}\" information should be within '{1}-{2}', please check and retry.", errorType, withinBegin, withinEnd);
            reQuery();
        }
        private static void errorJudge(string errorType, int resultCheck) {
            if (errorType == "decimal") {
                if (!(resultCheck >=0 && resultCheck <= 9))
                    errorPrompt("decimal", "0", "9");
            }
            else if (errorType == "hexdecimal") {
                if (!(resultCheck >=0 && resultCheck <= 15))
                    errorPrompt("hexdecimal", "0-9", "a~f(A~F)");
            }
            else if (errorType == "octal") {
                if (resultCheck < 0 || resultCheck > 8)
                    errorPrompt("octal", "0", "8");
            }
            else if (errorType == "binary") {
                if (resultCheck != 0 && resultCheck != 1)
                    errorPrompt("binary", "0", "1");
            }
        }
        private static int numInput(string numType) {
            Console.Write("Please input a {0} number\n{1}:", numType, numType.Substring(0, 3).ToUpper());
            int inputResult = int.Parse(Console.ReadLine());
            errorJudge(numType, inputResult);
            return inputResult;
        }
        private static string numInput(string[] str_numType, int offsets) {
            string str_temp = str_numType[offsets];
            Console.Write("Please input a {0} number\n{1}:", str_numType[offsets], str_temp.Substring(0, 3).ToUpper());
            str_temp = num_case(Console.ReadLine());
//////////            errorJudge(str_numType[offsets], (int)(str_temp.Split('-')));
            return str_temp;
        }
    }
    class Conversion {
        public static string num_case(object numOrCase) {
            Hashtable dict = new Hashtable();
            for (int temp_i = 0; temp_i < 10; temp_i++)
                dict.Add(temp_i, temp_i.ToString());
            dict.Add(10, "a");
            dict.Add(11, "b");
            dict.Add(12, "c");
            dict.Add(13, "d");
            dict.Add(14, "e");
            dict.Add(15, "f");
            
            string numeral = numOrCase as string;
            if (numeral == null)
                return (Convert.ToString(dict[numeral])).ToUpper();
            else {
                string caseOutp = "";
                string subCaseInp = "";
                string caseInp = numOrCase.ToString().ToLower();
                for (int temp_i = caseInp.Length - 1; temp_i >= 0; temp_i--) {
                    if (caseInp.Length >= 2)
                        subCaseInp = caseInp.Substring(caseInp.Length - 1);
                    else
                        subCaseInp = caseInp;
                    foreach (int keysValue in dict.Keys) {
                        if (subCaseInp == dict[keysValue].ToString()) {
                            caseOutp += keysValue.ToString();
                            caseOutp += "-";
                            break;
                        }
                    }
                    caseInp = caseInp.Remove(caseInp.Length - 1);
                }
                //                caseOutp.Trim().TrimEnd("-");               //Method 2 of get case-input
                return caseOutp;
            }
        }
        public static void hdobConvert(string waitCvt, int demand, string numType) {
            int sumResult = 0;
            int barAddr = 0;
            int iterate = 0;
            string str_temp = "";
            while ((barAddr = waitCvt.IndexOf("-")) != -1) {
                str_temp = waitCvt.Substring(0, barAddr);
                sumResult += int.Parse(str_temp) * (int)(System.Math.Pow(demand, iterate++));
                waitCvt = waitCvt.Remove(0, barAddr + 1);
            }
            //            sumResult += int.Parse(waitCvt) * int.Parse(System.Math.Pow(demand, iterate));    llMethod 2 of sumResult
            Console.Write("The fllowing is {0}-number that after transfrom:\n{1}:", numType, numType.Substring(0, 3).ToUpper());
            Console.Write(Convert.ToString(sumResult));
        }
        public static void hdobConvert(int waitQuence, int demand, string numType) {
            int maxsize = 100;              //this variable decide array 'arrs_stack' length
            int top = maxsize;
            string[] arrs_stack = new string[maxsize];
            while (waitQuence != 0) {
                arrs_stack[--top] = waitQuence % demand < 9 ? Convert.ToString(waitQuence % demand) : num_case(waitQuence % demand);
                waitQuence /= demand;
            }
            Console.Write("The fllowing is {0}-number that after transfrom:\n{1}:", numType, numType.Substring(0, 3).ToUpper());
            while (top != maxsize) {
                Console.Write(arrs_stack[top++]);
                //                bigEndian = arrs_stack[top--];
                //                Console.Write(Convert.ToString(bigEndian));
            }
            Console.WriteLine();
        }
    }
    class Problem : Prompt {
        static void Main(string[] args) {
            //this is function invoke areas
            featureInfo();
            Console.WriteLine("Press <Enter> key to leave...");
            Console.ReadLine();
        }
    }
}
