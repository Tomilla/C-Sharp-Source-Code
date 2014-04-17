using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace hexDecOctBinConversion
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
            switch (c_nextSelect)   //pass debug
            {
                case 'A':
                case 'a':       //wait build module, remember check `chr_preslect` value to decide previous menu of user selected...
                    if (i_preSelect == 1) {             //DEC => HEX
                        hdobConvert(numInput(arrs_type[1]), 16, arrs_type[0]);
                    }
                    else if (i_preSelect == 2) {             //OCT => HEX
                        hdobConvert(numInput(arrs_type, 2), keysLimit[2], '4', arrs_type[0]);

                    }
                    else if (i_preSelect == 3) {             //BIN => HEX
                        hdobConvert(numInput(arrs_type, 3), keysLimit[3],'4', arrs_type[0]);
                    }
                    reQuery();
                    break;
                case 'B':
                case 'b':
                    if (i_preSelect == 0) {             //HEX => DEC
                        hdobConvert(numInput(arrs_type, 0), 16, arrs_type[1]);
                    }
                    else if (i_preSelect == 2) {             //OCT => DEC
                        hdobConvert(numInput(arrs_type, 2), 8, arrs_type[1]);
                    }
                    else if (i_preSelect == 3) {             //BIN => DEC
                        hdobConvert(numInput(arrs_type[1]), 2, arrs_type[3]);
                    }
                    reQuery();
                    break;
                case 'C':
                case 'c':
                    if (i_preSelect == 0) {             //HEX => OCT
                        hdobConvert(numInput(arrs_type, 0), keysLimit[0], '3', arrs_type[2]);      //ordinal ASCII Code 52, same as decimal-numeral `3`
                    }
                    else if (i_preSelect == 1) {             //DEC => OCT
                        hdobConvert(numInput(arrs_type[1]), 8, arrs_type[2]);
                    }
                    else if (i_preSelect == 3) {             //BIN => OCT
                        hdobConvert(numInput(arrs_type, 3), keysLimit[3], '3', arrs_type[2]);
                    }
                    reQuery();
                    break;
                case 'D':
                case 'd':
                    if (i_preSelect == 0) {             //HEX => BIN
                        hdobConvert(numInput(arrs_type, 0), keysLimit[0], '\x34', arrs_type[3]);
                    }
                    else if (i_preSelect == 1) {             //DEC => BIN
                        hdobConvert(numInput(arrs_type[1]), 2, arrs_type[3]);
                    }
                    else if (i_preSelect == 2) {             //OCT => BIN
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
    class Conversion
    {
        static int maxsize = 100;              //this variable decide array 'arrs_stack' length
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
                    if (keysLimit != 14) {        //num_tmp not contain binary-numeral 
                        while (num_tmp != 0) {
                            arri_stack[++top] = num_tmp % 2;
                            num_tmp /= 2;
                        }
                    }
                    else {
                        arri_stack[++top] = num_tmp;
                    } 
                waitCvt = waitCvt.Remove(0, barAddr + 1);
            }
            if (keysLimit != 14) {        //num_tmp not contain binary-numeral 
                for (num_tmp = int.Parse(waitCvt); num_tmp != 0; num_tmp /= 2) {
                    arri_stack[++top] = num_tmp % 2;
                }
            }
            else {
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
            string str_temp = "";
            while ((barAddr = waitList.IndexOf("-")) != -1)
            {
                str_temp = waitList.Substring(0, barAddr);
                sumResult += int.Parse(str_temp) * (int)(System.Math.Pow(demand, iterate++));
                waitList = waitList.Remove(0, barAddr + 1);
            }
            sumResult += int.Parse(waitList) * (int)(System.Math.Pow(demand, iterate));    //Method 2 of sumResult
            Console.Write("The fllowing is {0}-number that after transfrom:\n{1}:", numType, numType.Substring(0, 3).ToUpper());
            Console.Write(Convert.ToString(sumResult));
            Console.WriteLine();
        }
        public static void hdobConvert(int waitQuence, int demand, string numType)
        {
            int top = maxsize;
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
                //                bigEndian = arrs_stack[top--];
                //                Console.Write(Convert.ToString(bigEndian));
            }
            Console.WriteLine();
        }
    }
    class Problem : Prompt
    {
        static void Main(string[] args)
        {
            //this is function invoke areas
            featureInfo();
            Console.WriteLine("Press <Enter> key to leave...");
            Console.ReadLine();
        }
    }
}

//string str_nocite=
//    "\t\t\t\tNOCICE\n\n" +
//    "Please be informed that office safety training section will be conducted from\n" +
//    "2:30 to 4:30 this Friday afternoon in Conference Room 109.\n\n" +
//    "All staff are require to come, handouts will available after the section.\n\n" +
//    "\t\t\t\t\t\t\t\tJacky Tam\n" +
//    "\t\t\t\t\t\t\t\toffice manager\n" +
//    "\t\t\t\t\t\t\t\tJuly 15, 2009"
//;
//Console.WriteLine(str_nocite);

//Method backup of HEX => BIN
//top = -1;
//int barAddr = 0;
//int num_tmp = 0;
//int[] arri_stack = new int[maxsize];
//while ((barAddr = waitCvt.IndexOf("-")) != -1) {
//    num_tmp = int.Parse(waitCvt.Substring(0, barAddr));
//    while (num_tmp != 0) {
//        arri_stack[++top] = num_tmp % int.Parse(demand);
//        num_tmp /= int.Parse(demand);
//    }
//    waitCvt = waitCvt.Remove(0, barAddr + 1);
//}
//for (num_tmp = int.Parse(waitCvt); num_tmp != 0; num_tmp /= int.Parse(demand)) {
//    arri_stack[++top] = num_tmp % int.Parse(demand);
//}
//if (numType == "binary") {
//    int split = 1;
//    while (top != -1) {
//        Console.Write(arri_stack[top--].ToString());
//        if (split % 4 == 0) {
//            Console.Write(" ");
//        }
//        split++;
//    }
//}

//tradition solution of user guide
//            string str_guide =
//                "\nWhat can i do for you, yound fellow?\n" +
//                "a)     convert decimal to hexadecimal-number.\n" +
//                "b)     reverse a) conversion.\n" +
//                "c)     convert decimal to octal-number.\n" +
//                "d)     reverse c) conversion.\n" +
//                "e)     convert decimal to binay-number.\n" +
//                "f)     reverse e) conversion.\n" +
//                "g)     convert hexadecimal to octal-number.\n" +
//                "h)     reverse g) conversion.\n" +
//                "i)     convert hexadecimal to binary-number.\n" +
//                "j)     reverse i) conversion.\n" +
//                "k)     convert octal to binary.\n" +
//                "l)     reverse k) conversion.\n"
//            ;
//            Console.WriteLine(str_guide);
//            char char_userSelect = ' ';
//            try {
//                char_userSelect = char.Parse(Console.ReadLine());
//            }
//            catch (Exception e) {
//                if (e.Data != null)
//                    errorPrompt("Option", "a~i\' Or", " \'A~I");
//            }
//            string[] arrs_type = {"hexadecimal", "decimal", "octal", "binary"};
//            switch (char_userSelect) {
//                case 'A':
//                case 'a':
//                    hdobConvert(numInput(arrs_type[1]), 16, arrs_type[0]);                  //DEC => HEX
//                    reQuery();
//                    break;
//                case 'B':
//                case 'b':
//                    hdobConvert(numInput(arrs_type, 0), 16, arrs_type[1]);                  //HEX => DEC
//                    reQuery();
//                    break;
//                case 'C':
//                case 'c':
//                    hdobConvert(numInput(arrs_type[1]), 8, arrs_type[2]);                   //DEC => OCT
//                    reQuery();
//                    break;
//                case 'D':
//                case 'd':
//                    hdobConvert(numInput(arrs_type, 2), 8, arrs_type[1]);                   //OCT => DEC
//                    reQuery();
//                    break;
//                case 'E':
//                case 'e':
//                    hdobConvert(numInput(arrs_type[1]), 2, arrs_type[3]);                   //DEC => BIN
//                    reQuery();
//                    break;
//                case 'F':
//                case 'f':
//                    hdobConvert(numInput(arrs_type, 3), 2, arrs_type[1]);                   //BIN => DEC
//                    reQuery();
//                    break;
//                case 'G':
//                case 'g':
//                    hdobConvert(numInput(arrs_type, 0), '\x33', arrs_type[2]);              //HEX => OCT
//                    reQuery();
//                    break;
//                case 'H':
//                case 'h':
//                    hdobConvert(numInput(arrs_type, 2), '\x34', arrs_type[0]);              //OCT => HEX
//                    reQuery();
//                    break;
//                case 'I':
//                case 'i':
//                    hdobConvert(numInput(arrs_type, 0), '\x34', arrs_type[3]);              //HEX => BIN
//                    reQuery();
//                    break;
//                case 'L':
//                    hdobConvert(numInput(arrs_type, 3), '\x34', arrs_type[0]);              //BIN => HEX    ***wait debug
//                    break;
//                default:
//                    Console.WriteLine("Warning: input error, please retry..");
//                    featureInfo();
//                    break;
//            }
