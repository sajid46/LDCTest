using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringProcessor.Tests
{
    public interface ICollectionProcessor
    {
        ICollection<string> Process(ICollection<string> collection);
    }

    public class StringCollectionProcessor : ICollectionProcessor
    {
        Dictionary<string, string> _charsToReplace;
        public StringCollectionProcessor(Dictionary<string, string> charsToReplace)
        {
            _charsToReplace = charsToReplace;
        }
        public ICollection<string> Process(ICollection<string> collection)
        {

            List<string> output = new List<string>();
            foreach (var item in collection)
            {
                var replacedItem = ReplaceCharacters(item);
                try
                {
                    var processedItem = RemoveDuplicates(replacedItem);
                    processedItem = processedItem.Length > 15 ? processedItem.Substring(0, 15) : processedItem;
                    output.Add(processedItem);
                }
                catch (Exception)
                {
                }
            }
            return output;
        }

        private string ReplaceCharacters(string item)
        {
            foreach (var key in _charsToReplace.Keys)
            {
                item = item.Replace(key, _charsToReplace[key]);
            }
            return item;
        }

        private string RemoveDuplicates(string item)
        {
            string _item = null;
            string duplicateCharsExpr;
            string nonEscapeableCharsExpr = "[a-z A-Z 0-9 _]";

            for (int i = 0; i < item.Length; i++)
            {
                string subStr = item.Substring(i, 1);
                if (Regex.IsMatch(subStr, nonEscapeableCharsExpr))
                {
                    duplicateCharsExpr = $"{subStr}{{2,}}";
                }
                else
                {
                    duplicateCharsExpr = $"\\{subStr}{{2,}}";
                }

                MatchCollection matches = Regex.Matches(item, duplicateCharsExpr);
                if (matches.Count > 0)
                {
                    item = item.Replace(matches[0].Value, subStr);
                }
            }
            _item = item;

            if (string.IsNullOrEmpty(_item))
            {
                throw new Exception("Ouputput string cannot be null or empty");
            }

            return _item;
        }
    }

    internal class StringProcessorValidator
    {
        internal string Process(string inputString)
        {
            string outputString = null;
            string subStr;

            if (string.IsNullOrEmpty(inputString))
            {
                throw new Exception("Input string should not be null.");
            }

            inputString = inputString.Replace("_", "");
            inputString = inputString.Replace("4", "");
            inputString = inputString.Replace("$", "£");
            outputString = inputString;
            
            string regx;
            string regxAZ = "[a-z A-Z 0-9 _]";

            for (int i = 0; i < inputString.Length; i++)
            {
                subStr = inputString.Substring(i, 1);
                if (Regex.IsMatch(subStr, regxAZ))
                {
                    regx = $"{subStr}{{2,}}";
                }
                else
                {
                    regx = $"\\{subStr}{{2,}}";
                }
                
                MatchCollection matches = Regex.Matches(inputString, regx);
                if (matches.Count > 0)
                {
                    inputString = inputString.Replace(matches[0].Value, subStr);
                }
            }

            outputString = inputString;

            if (string.IsNullOrEmpty(outputString))
            {
                throw new Exception("Ouputput string cannot be null or empty");
            }

            outputString = outputString.Length > 15
               ? outputString.Substring(0, 15)
               : outputString;

            return outputString;
        }
    }
}