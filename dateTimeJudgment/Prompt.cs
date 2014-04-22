using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//using System.Threading.Tasks;

namespace Date_and_Time_Judgment_CA
{
    class Prompt
    {
        public void prompt_error(string errorReason, string withinBengin, string withinEnd)
        {
            Console.WriteLine("Error: \"{0}\" information should be within '{1}-{2}', please check and retry.", errorReason, withinBengin, withinEnd);
            Console.ReadLine();
            return;
        }
    }
}
