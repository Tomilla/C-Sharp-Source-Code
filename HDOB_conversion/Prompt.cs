using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;     //this namespace name does not exist in Mono build-in class
using System.Collections;

namespace HDOB_conversion
{

    class Prompt : Conversion
    {
        static int[] keysLimit = { 0, 6, 8, 14 };    //"15 - keys Limit, 10 - KeysLimit, 7 - Keys Limit, 2 - keys Limit" is correspond "hexadecimal, decimal, octal, binary"
        public static void featureInfo()
        {
            string s_preGuide =           //previou of user guide string
                "\nWelcome to binary world,\n" +
                "yound fellow, Please choose base numeral-format which wait to converted:\n" +
                "0)     hexadecimal.\n" +
                "1)     decimal.....\n" +
                "2)     octal.......\n" +
                "3)     binary......\n"
            ;
            string s_nextGuide =          //next of user guide string
                "\nnext, Choose one of these numeral-format that follow your ture demand:\n" +
                "a)     hexadecimal.\n" +
                "b)     decimal.....\n" +
                "c)     octal.......\n" +
                "d)     binary......\n"
            ;
            Console.Write(s_preGuide);
            /////////////////////////////////////////////////////////////////////////////////////
            int i_preSelect = 0;       //previous menu of user select
            char c_nextSelect = ' ';      //next menu of user select
            try
            {
                i_preSelect = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                if (e.Data != null)
                    errorPrompt("Option", "0\' -", " \'3");
            }
            Hashtable dict = new Hashtable();
            dict.Add(0, 'a');
            dict.Add(1, 'b');
            dict.Add(2, 'c');
            dict.Add(3, 'd');
            int i_loopCount = 4;
            foreach (int i_waitSelect in dict.Keys)
            {
                if (i_waitSelect == i_preSelect)
                {
                    int caseAddr = s_nextGuide.IndexOf(dict[i_preSelect].ToString() + ")");
                    string s_subNext = s_nextGuide.Remove(caseAddr, 20);
                    Console.WriteLine(s_subNext);
                    try
                    {
                        c_nextSelect = char.Parse(Console.ReadLine().ToLower());
                        i_loopCount = 4;
                        break;
                    }
                    catch (Exception e)
                    {
                        if (e.Data != null)
                            errorPrompt("Option", "a~d\' Or", " \'A~D");
                    }
                }
                i_loopCount--;
                if (i_loopCount == 0)
                {
                    errorPrompt("option", "0\' -", "\'1");
                }
            }
            string[] arrs_type = { "hexadecimal", "decimal", "octal", "binary" };
            switch (c_nextSelect)
            {
                case 'A':
                case 'a':       //wait build module, remember check `chr_preslect` value to decide previous menu of user selected...
                    if (i_preSelect == 1)
                    {             //DEC => HEX
                        hdobConvert(numInput(arrs_type[1]), 16, arrs_type[0]);
                    }
                    else if (i_preSelect == 2)
                    {             //OCT => HEX
                        hdobConvert(numInput(arrs_type, 2), keysLimit[2], '4', arrs_type[0]);

                    }
                    else if (i_preSelect == 3)
                    {             //BIN => HEX
                        hdobConvert(numInput(arrs_type, 3), keysLimit[3], '4', arrs_type[0]);
                    }
                    reQuery();
                    break;
                case 'B':
                case 'b':
                    if (i_preSelect == 0)
                    {             //HEX => DEC
                        hdobConvert(numInput(arrs_type, 0), 16, arrs_type[1]);
                    }
                    else if (i_preSelect == 2)
                    {             //OCT => DEC
                        hdobConvert(numInput(arrs_type, 2), 8, arrs_type[1]);
                    }
                    else if (i_preSelect == 3)
                    {             //BIN => DEC
                        hdobConvert(numInput(arrs_type[1]), 2, arrs_type[3]);
                    }
                    reQuery();
                    break;
                case 'C':
                case 'c':
                    if (i_preSelect == 0)
                    {             //HEX => OCT
                        hdobConvert(numInput(arrs_type, 0), keysLimit[0], '3', arrs_type[2]);      //ordinal ASCII Code 52, same as decimal-numeral `3`
                    }
                    else if (i_preSelect == 1)
                    {             //DEC => OCT
                        hdobConvert(numInput(arrs_type[1]), 8, arrs_type[2]);
                    }
                    else if (i_preSelect == 3)
                    {             //BIN => OCT
                        hdobConvert(numInput(arrs_type, 3), keysLimit[3], '3', arrs_type[2]);       //Debuging, test Muwaii_Cz
                    }
                    reQuery();
                    break;
                case 'D':
                case 'd':
                    if (i_preSelect == 0)
                    {             //HEX => BIN
                        hdobConvert(numInput(arrs_type, 0), keysLimit[0], '\x34', arrs_type[3]);
                    }
                    else if (i_preSelect == 1)
                    {             //DEC => BIN
                        hdobConvert(numInput(arrs_type[1]), 2, arrs_type[3]);
                    }
                    else if (i_preSelect == 2)
                    {             //OCT => BIN
                        hdobConvert(numInput(arrs_type, 2), keysLimit[2], '\x34', arrs_type[3]);
                    }
                    reQuery();
                    break;
                default:
                    Console.WriteLine("Warning: input error, please retry..");
                    featureInfo();
                    break;
            }
        }
        private static void reQuery()
        {
            System.Random rdm = new System.Random();
            int random = rdm.Next(0, 11) / 10 <= 0.1 ? (rdm.Next(10, 20) > 15 ? 0 : 1) : (rdm.Next(20, 30) > 25 ? 2 : 3);
            //          int random = rdm.Next(0, 4);
            string[] arrs_receive = new string[] {
                "The system work well, ", "Currect answer had been give you, ",
                "So quickly, ", "It's incredible, "
            };
            string str_requery =
                "Query other type number?\n" +
                "Y(y), Please tell more knowledge about number conversion.\n" +
                "N(n), Sorry, robots sir, i must go home write my homework, see you tomorrow\n"
            ;
            Console.Write("\n" + arrs_receive[random] + str_requery);
            char char_userSelect = ' ';
            try
            {
                char_userSelect = char.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                if (e.Data != null)
                    errorPrompt("Option", "Y(y)\' Or", " \'N");
            }
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
        public static void errorPrompt(string errorType, string withinBegin, string withinEnd)
        {
            Console.WriteLine("Error: \"{0}\" information should be within '{1}{2}', please check and retry.", errorType, withinBegin, withinEnd);
            featureInfo();
        }
        private static void errorJudge(string errorType, int resultCheck)
        {
            if (errorType == "decimal")
            {
                if (!(resultCheck >= 0 && resultCheck <= 9))
                    errorPrompt("decimal", "0 -", " 9");
            }
            else if (errorType == "hexadecimal")
            {
                if (!(resultCheck >= 0 && resultCheck <= 15))
                    errorPrompt("hexadecimal", "0~9\' -", " \'a~f(A~F)");
            }
            else if (errorType == "octal")
            {
                if (resultCheck < 0 || resultCheck > 8)
                    errorPrompt("octal", "0 -", " 7");
            }
            else if (errorType == "binary")
            {
                if (resultCheck != 0 && resultCheck != 1)
                    errorPrompt("binary", "0 -", " 1");
            }
        }
        private static int numInput(string numType)
        {
            Console.Write("Please input a {0} number\n{1}:", numType, numType.Substring(0, 3).ToUpper());
            int inputResult = -1;
            string str_temp = Console.ReadLine();
            //Method 01 of process input error..
            //bool judgment = int.TryParse(str_temp, out inputResult);
            //if (judgment != false) {
            //    inputResult = int.Parse(str_temp);
            //}
            //else {
            //    errorPrompt("decimal", "0", "9");
            //}
            try
            {
                inputResult = int.Parse(str_temp);
            }
            catch (Exception e)
            {
                if (e.Data != null)
                    errorJudge(numType, inputResult);
            }
            return inputResult;
        }
        private static string numInput(string[] str_numType, int offsets)
        {
            string str_temp = str_numType[offsets];
            Console.Write("Please input a {0} number\n{1}:", str_numType[offsets], str_temp.Substring(0, 3).ToUpper());
            string str_waitTest = Console.ReadLine();
            int inputResult = -1;
            str_waitTest = num_case(str_waitTest, keysLimit[offsets]);
            str_temp = str_waitTest;
            /*
             * wait Debug:
             * 1st. through slicing string `str_temp` to string `str_test`, try any items in a loop, if one value of these items not integer result in an Exception happen
             *      通过分割字符串，遂一进行整型检测，否则整串中包含的数值长度超过32bits整型的最大长度就会报错...So sad
             * 2nd. resize variable `inputResult` length as 64-bits
             */
            int barFinder = -1;
            while ((barFinder = str_temp.IndexOf("-")) != -1)
            {
                string str_test = str_temp.Substring(0, barFinder);
                try
                {
                    inputResult = int.Parse(str_test);
                    //                    inputResult = int.Parse(str_temp.Replace("-", ""));
                }
                catch (Exception e)
                {
                    if (e.Data != null)
                        errorJudge(str_numType[offsets], inputResult);
                    //throw;
                }
                str_temp = str_temp.Remove(0, barFinder + 1);
            }
            return str_waitTest;
        }
    }
}
