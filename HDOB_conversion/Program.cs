using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDOB_conversion
{
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
