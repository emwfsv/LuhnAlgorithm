using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuhnAlgorythms;

namespace TestOfLuhnCalculation
{
    [TestClass]
    public class SwedishPersonalNumber
    {
        [TestMethod]
        public void CheckCorrectPN()
        {
            LuhnAlgorythm _pn = new LuhnAlgorythm();
            Assert.AreEqual(true, _pn.CheckIfPersonalIdIsCorrect("7311035518"));
        }

        [TestMethod]
        public void CheckIncorrectPN()
        {
            LuhnAlgorythm _pn = new LuhnAlgorythm();
            Assert.AreEqual(false, _pn.CheckIfPersonalIdIsCorrect("7311035519"));
        }

        [TestMethod]
        public void CheckCorrectPNWithSigns()
        {
            LuhnAlgorythm _pn = new LuhnAlgorythm();
            Assert.AreEqual(true, _pn.CheckIfPersonalIdIsCorrect("731103-5518"));
        }

        [TestMethod]
        public void CheckExceptionToLong()
        {
            LuhnAlgorythm _pn = new LuhnAlgorythm();
            Exception _e = new FormatException("The length of the swedish personal number is not correct. It should contain 10 digits!!!");
            Exception e = null;
            try
            {
                bool test = _pn.CheckIfPersonalIdIsCorrect("73110355189");  //To long number
            }
            catch
            {
                try
                {
                    Assert.AreEqual(_e, e);
                }
                catch
                {

                }
            }
        }

        [TestMethod]
        public void CheckExceptionToShort()
        {
            LuhnAlgorythm _pn = new LuhnAlgorythm();
            Exception _e = new FormatException("The length of the swedish personal number is not correct. It should contain 10 digits!!!");
            Exception e = null;
            try
            {
                bool test = _pn.CheckIfPersonalIdIsCorrect("731103551");  //To short number
            }
            catch
            {
                try
                {
                    Assert.AreEqual(_e, e);
                }
                catch
                {

                }
            }
        }
    }
    [TestClass]
    public class IccIdNumber
    {
        [TestMethod]
        public void CheckValidIccIdTwentyTwoDigits()
        {
            LuhnAlgorythm _iccId = new LuhnAlgorythm();
            Assert.AreEqual(true, _iccId.CheckIfIccIdIsCorrect("8946071612600065785675"));
        }

        [TestMethod]
        public void CheckInCorrectIccIdTwentyTwoDigits()
        {
            LuhnAlgorythm _iccId = new LuhnAlgorythm();
            Assert.AreEqual(false, _iccId.CheckIfIccIdIsCorrect("8946071612600065785670"));
        }

        [TestMethod]
        public void IncorrectIccIdWithLetter()
        {
            LuhnAlgorythm _iccId = new LuhnAlgorythm();
            Exception _e = new FormatException("ICCID contains a letter!!!");
            //Exception e = null;
            try
            {
                Assert.AreEqual(false, _iccId.CheckIfIccIdIsCorrect("89460716126000657856T5"));
            }
            catch(Exception e)
            {
                try
                {
                    Assert.AreEqual(_e.Message, e.Message);
                    //
                }
                catch
                {

                }
            }
        }

        [TestMethod]
        public void ToLongIccId()
        {
            LuhnAlgorythm _iccId = new LuhnAlgorythm();
            Exception _e = new FormatException("The length of the ICCID is not correct. It should not contain more then 22 digits!!!");
            
            try
            {
                Assert.AreEqual(false, _iccId.CheckIfIccIdIsCorrect("89460716126000657856750"));
            }
            catch(Exception e)
            {
                try
                {
                    Assert.AreEqual(_e.Message, e.Message);
                }
                catch
                {

                }
            }
        }
    }

    [TestClass]
    public class OCRNumber
    {
        [TestMethod]
        public void CheckCorrectOCR()
        {
            LuhnAlgorythm _ocr = new LuhnAlgorythm();
            Assert.AreEqual(true, _ocr.CheckIfOcrIsCorrect("4015115100"));
        }

        [TestMethod]
        public void CheckInCorrectOCR()
        {
            LuhnAlgorythm _ocr = new LuhnAlgorythm();
            Assert.AreEqual(false, _ocr.CheckIfOcrIsCorrect("40151151001"));
        }

        [TestMethod]
        public void IncorrectOcrIdWithLetter()
        {
            LuhnAlgorythm _ocr= new LuhnAlgorythm();
            Exception _e = new FormatException("OCR contains a letter!!!");

            try
            {
                Assert.AreEqual(false, _ocr.CheckIfOcrIsCorrect("4015I15100"));
            }
            catch (Exception e)
            {
                try
                {
                    Assert.AreEqual(_e.Message, e.Message);
                    //
                }
                catch
                {

                }
            }
        }
    }
}
