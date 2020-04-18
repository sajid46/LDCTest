using System;

namespace LDCReFormatedStringReturn
{
    internal class LDCStringManipulation
    {
        private string outputstring;
        private int pos;
        private string str;

        internal object ReturnString(string inputString)
        {
            inputString = inputString.Replace("$", "£").Replace("_", "").Replace("4", "£");

            while (inputString.Length>0)
            {
                str = inputString.Substring(pos, 1);
                inputString = inputString.Replace(str, "");
                outputstring += str;
            }
            return outputstring;
        }
    }
}