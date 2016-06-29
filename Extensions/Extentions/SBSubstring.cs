namespace Extensions
{
    using System;
    using System.Numerics;
    using System.Text;

    // Problem 1. StringBuilder.Substring
    public static class SBSubstring
    {
        public static StringBuilder Substring(this StringBuilder text, int startIndex, int length)
        {
            var substringB = new StringBuilder();

            for (int i = startIndex; i < startIndex + length; i++)
            {
                substringB.Append(text[i]);
            }

            return substringB;
        }
    }
}
