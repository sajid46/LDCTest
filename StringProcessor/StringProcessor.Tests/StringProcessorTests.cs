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
            ICollection<string> collection = new List<string>();
            collection.Add("WWW_4$");
            collection.Add("_4");
            collection.Add("AAAc91%cWwWkLq$1ci3_848v3d__K");
            collection.Add("848");


            Dictionary<string, string> charsToReplace = new Dictionary<string, string>()
            {
                ["4"] = "",
                ["_"] = "",
                ["$"] = "£",
            };

            StringCollectionProcessor collectionProcessor = new StringCollectionProcessor(charsToReplace);
            var result = collectionProcessor.Process(collection);
            Assert.IsTrue(result.FirstOrDefault() == "W£");

            Assert.IsTrue(result.ToArray()[1] == "Ac91%cWwWkLq£1c");
            Assert.IsTrue(result.ToArray()[2] == "8");
            //Ac91%cWwWkLq£1c
            //Ac91%cWwWkLq£1c
        }



        [Test]
        public void Input_ShouldNotBeNull()
        {
            Assert.Throws(
                Is.TypeOf<Exception>().And.Message.EqualTo("Input string should not be null."),
                delegate { validator.Process(null); });
        }

        [Test]
        public void Output_ShouldNotBeNullOrEmpty()
        {
            Assert.Throws(
                Is.TypeOf<Exception>().And.Message.EqualTo("Ouputput string cannot be null or empty"),
                delegate { validator.Process("_"); });
        }

        [Test]
        public void Output_ShouldReturnMaximumOf15Characters()
        {
            var result = validator.Process("SWASWQEWSvsfaTGsggaUIJPppou$3((76%__");
            Assert.IsTrue(result.Length <= 15);
        }

        [Test]
        public void Output_ShouldReduceToSingleCharacter_WhenSameCaseContiguousDuplicateCharacters()
        {
            var result = validator.Process(@"WWWxWWW");
            Assert.AreEqual(@"WxW", result);
        }

        [Test]
        public void Output_ShouldReplaceDollarSignWithPoundSign()
        {
            var result = validator.Process(@"$$$$$");
            Assert.AreEqual(@"£", result);
        }

        [Test]
        public void Output_ShouldRemoveUnderscore()
        {
            Assert.Throws(
                Is.TypeOf<Exception>().And.Message.EqualTo("Ouputput string cannot be null or empty"),
                delegate { validator.Process(@"___"); });

            var result = validator.Process(@"___WWWx&&");
            Assert.AreEqual(@"Wx&", result);


        }

        [Test]
        public void Output_ShouldRemoveNumberFour()
        {
            Assert.Throws(
                Is.TypeOf<Exception>().And.Message.EqualTo("Ouputput string cannot be null or empty"),
                delegate { validator.Process(@"44"); });

            var result = validator.Process(@"44WWWx&&");
            Assert.AreEqual(@"Wx&", result);


        }



    }
}
