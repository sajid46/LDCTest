using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace StringProcessor.Tests
{
    [TestFixture]
    public class StringProcessorTests
    {
        private string inputString;
        StringProcessorValidator validator;
        ICollection<string> collection = new List<string>();

        [SetUp]
        public void Init()
        {
            inputString = "AAAc91%cWwWkLq$1ci3_848v3d__K";
            validator = new StringProcessorValidator();
        }

        /* 
         * Write C# code with unit-tests to process 
         * a collection of string values which are passed 
         * to a method which returns a collection of 
         * processed strings. The input strings may be any 
         * length and can contain any character. 
         * 
         * Output strings  must not be null 
         * or empty string, 
         * should be truncated to max length of 15 chars, 
         * and contiguous duplicate characters in the same case should  be reduced to a single character in the same case. 
         * Dollar sign ($) should be replaced with a pound sign (£), 
         * and underscores (_) should be removed
         * and number 4 should be removed. 
         * 
         * 
         * Code should be test-driven, efficient, re-usable and loosely coupled. The returned collection must not be null. */
        [Test]
        public void StringCollectionProcessor_Test()
        {


            //return will always return 15 chars
            collection.Add("AAAc91%cWwWkLq$1ci3_848v3d__KXXXX");
            collection.Add("_WWW4_b$");
            collection.Add("$$$$$");
            collection.Add("___WWWx&&");
            collection.Add("44WWWx&&");
            collection.Add("44");


            Dictionary<string, string> charsToReplace = new Dictionary<string, string>()
            {
                ["4"] = "",
                ["_"] = "",
                ["$"] = "£",
            };

            StringCollectionProcessor collectionProcessor = new StringCollectionProcessor(charsToReplace);
            var result = collectionProcessor.Process(collection);

            Assert.IsTrue(ShouldReturnMaximumOf15Characters(result.ToArray()[0]));
            Assert.IsTrue(ShouldReduceToSingleCharacter_WhenSameCaseContiguousDuplicateCharacters(result.ToArray()[1]));
            Assert.IsTrue(ShouldReplaceDollarSignWithPoundSign(result.ToArray()[2]));
            Assert.IsTrue(ShouldRemoveUnderscore(result.ToArray()[3]));
            Assert.IsTrue(ShouldRemoveNumberFour(result.ToArray()[4]));
        }

        public bool ShouldReturnMaximumOf15Characters(string input)
        {
            return input.Length <= 15;
        }

        public bool ShouldReduceToSingleCharacter_WhenSameCaseContiguousDuplicateCharacters(string input)
        {
            return input == "Wb£";
        }

        public bool ShouldReplaceDollarSignWithPoundSign(string input)
        {
            return input == "£";
        }

        public bool ShouldRemoveUnderscore(string input)
        {
            return input == "Wx&";
        }

        public bool ShouldRemoveNumberFour(string input)
        {
            return input == "Wx&";
        }

        //public bool ShouldNotBeNull(string input)
        //{
        //    return string.IsNullOrEmpty(input);
        //}



        //public void Input_ShouldNotBeNull(string input)
        //{
        //    Assert.Throws(
        //        Is.TypeOf<Exception>().And.Message.EqualTo("Input string should not be null."),
        //        delegate { validator.Process(input); });
        //}

        //[Test]
        //public void Output_ShouldNotBeNullOrEmpty()
        //{
        //    Assert.Throws(
        //        Is.TypeOf<Exception>().And.Message.EqualTo("Ouputput string cannot be null or empty"),
        //        delegate { validator.Process("_"); });
        //}

        //[Test]
        //public void Output_ShouldReturnMaximumOf15Characters()
        //{
        //    var result = validator.Process("SWASWQEWSvsfaTGsggaUIJPppou$3((76%__");
        //    Assert.IsTrue(result.Length <= 15);
        //}

        //[Test]
        //public void Output_ShouldReduceToSingleCharacter_WhenSameCaseContiguousDuplicateCharacters()
        //{
        //    var result = validator.Process(@"WWWxWWW");
        //    Assert.AreEqual(@"WxW", result);
        //}

        //[Test]
        //public void Output_ShouldReplaceDollarSignWithPoundSign()
        //{
        //    var result = validator.Process(@"$$$$$");
        //    Assert.AreEqual(@"£", result);
        //}

        //[Test]
        //public void Output_ShouldRemoveUnderscore()
        //{
        //    Assert.Throws(
        //        Is.TypeOf<Exception>().And.Message.EqualTo("Ouputput string cannot be null or empty"),
        //        delegate { validator.Process(@"___"); });

        //    var result = validator.Process(@"___WWWx&&");
        //    Assert.AreEqual(@"Wx&", result);


        //}

        //[Test]
        //public void Output_ShouldRemoveNumberFour()
        //{
        //    Assert.Throws(
        //        Is.TypeOf<Exception>().And.Message.EqualTo("Ouputput string cannot be null or empty"),
        //        delegate { validator.Process(@"44"); });

        //    var result = validator.Process(@"44WWWx&&");
        //    Assert.AreEqual(@"Wx&", result);


        //}



    }
}
