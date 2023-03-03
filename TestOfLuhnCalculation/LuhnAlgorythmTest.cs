using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuhnAlgorythms;

namespace TestOfLuhnCalculation
{
    [TestClass]
    public class SwedishPersonalNumber
    {
        LuhnAlgorythm _pn = new LuhnAlgorythm();

        [TestMethod]
        public void CheckCorrectPN()
        {
            Assert.AreEqual(true, _pn.CheckIfPersonalIdIsCorrect("6408233234"));
        }

        [TestMethod]
        public void CheckIncorrectPN()
        {
            Assert.AreEqual(false, _pn.CheckIfPersonalIdIsCorrect("6408233235"));
        }

        [TestMethod]
        public void CheckCorrectPNWithSigns()
        {
            Assert.AreEqual(true, _pn.CheckIfPersonalIdIsCorrect("640823-3234"));
        }

        [TestMethod]
        public void CheckExceptionToLong()
        {
            try
            {
                _pn.CheckIfPersonalIdIsCorrect("64082332349");  //To long number
            }
            catch(Exception ex)
            {
                Assert.AreEqual("The length of the swedish personal number is not correct. It should contain 10 digits!!!", ex.Message);
            }
        }

        [TestMethod]
        public void CheckExceptionToShort()
        {
            try
            {
                _pn.CheckIfPersonalIdIsCorrect("640823323");  //To short number
            }
            catch(Exception ex)
            {

                Assert.AreEqual("The length of the swedish personal number is not correct. It should contain 10 digits!!!", ex.Message);
            }
        }
    }
    [TestClass]
    public class IccIdNumber
    {
        LuhnAlgorythm _iccId = new LuhnAlgorythm();

        [TestMethod]
        public void CheckValidIccIdTwentyTwoDigits()
        {
            Assert.AreEqual(true, _iccId.CheckIfIccIdIsCorrect("8946071612600065785675"));
        }

        [TestMethod]
        public void CheckInCorrectIccIdTwentyTwoDigits()
        {
            Assert.AreEqual(false, _iccId.CheckIfIccIdIsCorrect("8946071612600065785670"));
        }

        [TestMethod]
        public void IncorrectIccIdWithLetter()
        {
            try
            {
                Assert.AreEqual(false, _iccId.CheckIfIccIdIsCorrect("89460716126000657856T5"));
            }
            catch(Exception ex)
            {
                Assert.AreEqual("ICCID contains a letter!!!", ex.Message);
            }
        }

        [TestMethod]
        public void ToLongIccId()
        {
            try
            {
                Assert.AreEqual(false, _iccId.CheckIfIccIdIsCorrect("89460716126000657856750"));
            }
            catch(Exception ex)
            {
                Assert.AreEqual("The length of the ICCID is not correct. It should not contain more then 22 digits!!!", ex.Message);
            }
        }
    }
    [TestClass]
    public class OCRNumber
    {
        LuhnAlgorythm _ocr = new LuhnAlgorythm();

        [TestMethod]
        public void CheckCorrectOCR()
        {
            Assert.AreEqual(true, _ocr.CheckIfOcrIsCorrect("4015115100"));
        }

        [TestMethod]
        public void CheckIncorrectOCR()
        {
            Assert.AreEqual(false, _ocr.CheckIfOcrIsCorrect("40151151001"));
        }

        [TestMethod]
        public void IncorrectOcrIdWithLetter()
        {
            try
            {
                Assert.AreEqual(false, _ocr.CheckIfOcrIsCorrect("4015I15100"));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("OCR contains a letter!!!", ex.Message);
            }
        }
    }
}
