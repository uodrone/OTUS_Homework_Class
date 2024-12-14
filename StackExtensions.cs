using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_Homework_Class
{
    static class StackExtensions
    {

        public static Stack Merge (this Stack stack, Stack s1, Stack s2)
        {
            for (int i = s2.StringList.Count; i > 0;  i--)
            {
                s1.StringList.Add(s2.StringList[i - 1]);
            }

            return s1;
        }
    }
}
