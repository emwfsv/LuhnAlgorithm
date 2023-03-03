using System;
using System.Collections.Generic;
using System.Linq;

namespace LuhnAlgorithms
{
    public class LuhnAlgorithm
    {
        /// <summary>
        /// This function will determine if the Swedish personal number entered with or without '-' is correct or not
        /// Function is using the Luhn Algorythm and /10 to check if correct or not.
        /// https://sv.wikipedia.org/wiki/Luhn-algoritmen
        /// </summary>
        /// <param name="personalNumber">Swedish "Personnummer"</param>
        /// <returns></returns>
        /// <exception cref="FormatException">Returns exception if the length is wrong</exception>
        public bool CheckPersonalIdNumber(string personalNumber)
        {
            //Variables
            var notAllowedSigns = new List<string>() { "*", " ", "-", "_" };

            //Remove unwanted signs from entered number
            var _pn = RemoveUnwantedSigns(notAllowedSigns, personalNumber);

            //A check of the entered length is done
            //This function requires that the input number must be 10 numbers long
            if (_pn.Length != 10)
            {
                throw new FormatException("The length of the swedish personal number is not correct. It should contain 10 digits!!!");
            }

            //Every odd number is multiplied with one.
            //Every even number is multiplied with two.
            //Returned value as string
            var _personalNumberLuhnCalculated = OddEvenMulitplication(_pn);

            //All number from LSB to MSB will be added together as single numbers (0 - 9)
            //Number is then divided by 10.
            //If last number in int = 0 it is considered to be a valid personal number.
            return PossibleToDivideByTen(_personalNumberLuhnCalculated);

        }

        /// <summary>
        /// This function checks if the ICCID number from a SIM card is correct according to its checksum.
        /// ICCID is up to digit 22 long(LSB) is the checksum of the calculation.
        /// </summary>
        /// <param name="iccIdNumber">ICCID number</param>
        /// <returns>Return whether a ICCID is correct or not</returns>
        /// <exception cref="FormatException">Returns exception if ICCID is longer then 22 signs</exception>
        public bool CheckIccId(string iccIdNumber)
        {
            //Lets check the number if it contains charcters
            if (iccIdNumber.All(x => char.IsNumber(x)))
            {
                if (iccIdNumber.Length > 22)
                {
                    throw new FormatException("The length of the ICCID is not correct. It should not contain more then 22 digits!!!");
                }

                //Every odd number is multiplied with one.
                //Every even number is multiplied with two.
                //Returned value as string
                var _iccIdNumberLuhnCalculated = OddEvenMulitplication(iccIdNumber);

                //All number from LSB to MSB will be added together as single numbers (0 - 9)
                //Number is the divided by 10.
                //If last number in int = 0 it is considered to be a valid personal number.
                return PossibleToDivideByTen(_iccIdNumberLuhnCalculated);
            }
            else
            {
                throw new FormatException("ICCID contains a letter!!!");
            }
        }

        /// <summary>
        /// This function will check wether the OCR number is correct or not by using the Luhn algorythm
        /// </summary>
        /// <param name="OcrNumberToCheck"></param>
        /// <returns></returns>
        public bool CheckOcr(string OcrNumberToCheck)
        {
            if (OcrNumberToCheck.All(x => char.IsNumber(x)))
            {
                //Every odd number is multiplied with one.
                //Every even number is multiplied with two.
                //Returned value as string
                var _iccOcrLuhnCalculated = OddEvenMulitplication(OcrNumberToCheck);

                //All number from LSB to MSB will be added together as single numbers (0 - 9)
                //Number is the divided by 10.
                //If last number in int = 0 it is considered to be a valid personal number.
                return PossibleToDivideByTen(_iccOcrLuhnCalculated);
            }
            else
            {
                throw new FormatException("OCR contains a letter!!!");
            }
        }

        //===================================
        //          Private Functions
        //===================================

        /// <summary>
        /// This function will remove any unwanted signs from the entered number series.
        /// string[] need to contain all signs that should be removed.
        /// </summary>
        /// <param name="notAllowedSigns">List of not allowed signs</param>
        /// <param name="_numberToAnalyze"></param>
        /// <returns></returns>
        private string RemoveUnwantedSigns(List<string> notAllowedSigns, string _numberToAnalyze)
        {
            //Removal of unwanted signs are removed.
            foreach(var sign in notAllowedSigns)
            {
                _numberToAnalyze = _numberToAnalyze.Replace(sign, "");
            }
            return _numberToAnalyze;
        }

        /// <summary>
        /// Every odd number is multiplied with 1 and every even number is multiplied with 2.
        /// Convert the number to a string and add to a totalsum string.
        /// Will start with LSB and end with MSB
        /// </summary>
        /// <param name="numberForCalculation"></param>
        /// <returns></returns>
        private string OddEvenMulitplication(string numberForCalculation)
        {
            //Constructor for private function
            bool _even = false;
            string _totalSum = "";

            for (int _i = 1; _i <= numberForCalculation.Length; _i++)
            {

                var _partsum = int.Parse(numberForCalculation.Substring(numberForCalculation.Length - _i, 1));

                if (_even == true)
                {
                    _partsum = _partsum * 2;
                }

                if (_even == false)
                {
                    _partsum = _partsum * 1;
                }

                _totalSum = _partsum.ToString() + _totalSum;
                _even = !_even;
            }

            return _totalSum;
        }

        private bool PossibleToDivideByTen(string valueToCalculate)
        {
            //Variables
            int result = 0;

            for (int _i = 0; _i < valueToCalculate.Length; _i++)
            {
                //Need to calculate the sum on every number.
                result += Convert.ToInt16(valueToCalculate.Substring(_i,1));
            }

            //The result should be possible to divid by 10
            //Check the last digit in the final result so that it is a '0'
            return result.ToString().Substring(result.ToString().Length - 1, 1) == "0" ? true : false;

        }
    }
}
