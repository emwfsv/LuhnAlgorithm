using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuhnAlgorythms
{
    public class LuhnAlgorythm
    {
        private Exception ExceptionMessage { set; get; }
        public bool CheckIfPersonalIdIsCorrect (string personalNumber)
        {
            //This function will determine if the Swedish personal number entered with or without '-' is correct or not
            //Function is using the Luhn Algorythm and /10 to check if correct or not.
            //https://sv.wikipedia.org/wiki/Luhn-algoritmen
            //

            //Variables
            List<string> notAllowedSigns = new List<string>() { "*", " ", "-", "_" };
            string _personalNumber = personalNumber;
            string _personalNumberLuhnCalculated;

            //Remove unwanted signs from entered number
            _personalNumber = RemoveUnwantedSigns(notAllowedSigns, _personalNumber);

            //A check of the entered length is done
            //This function requires that the input number must be 10 numbers long
            if (_personalNumber.Length != 10)
            {
                ExceptionMessage = new FormatException("The length of the swedish personal number is not correct. It should contain 10 digits!!!");
                throw ExceptionMessage;
            }
            else
            {
                ExceptionMessage = null;
            }

            //Every odd number is multiplied with one.
            //Every even number is multiplied with two.
            //Returned value as string
            _personalNumberLuhnCalculated = OddEvenMulitplication(_personalNumber);

            //All number from LSB to MSB will be added together as single numbers (0 - 9)
            //Number is the divided by 10.
            //If last number in int = 0 it is considered to be a valid personal number.
            var validPersonalNumber = PossibleToDivideByTen(_personalNumberLuhnCalculated);
 
            //Return false if not a valid number.
            //return 'true' if it is a valid number.
            return validPersonalNumber;

        }

        public bool CheckIfIccIdIsCorrect(string iccIdNumber)
        {
            //This function checks if the ICCID number from a SIM card is correct according to its checksum.
            //ICCID is up to digit 22 long(LSB) is the checksum of the calculation.

            //Variables
            bool validiccIdNumber = false;

            //Lets check the number if it contains charcters
            if (iccIdNumber.All(x => char.IsNumber(x)))
            {
                if (iccIdNumber.Length > 22)
                {
                    ExceptionMessage = new FormatException("The length of the ICCID is not correct. It should not contain more then 22 digits!!!");
                    throw ExceptionMessage;
                }

                //Every odd number is multiplied with one.
                //Every even number is multiplied with two.
                //Returned value as string
                var _iccIdNumberLuhnCalculated = OddEvenMulitplication(iccIdNumber);

                //All number from LSB to MSB will be added together as single numbers (0 - 9)
                //Number is the divided by 10.
                //If last number in int = 0 it is considered to be a valid personal number.
                validiccIdNumber = PossibleToDivideByTen(_iccIdNumberLuhnCalculated);
 
                //Return false if not a valid number.
                //return 'true' if it is a valid number.
            }
            else
            {
                ExceptionMessage = new FormatException("ICCID contains a letter!!!");
                throw ExceptionMessage;
            }
            return validiccIdNumber;
         }

        /// <summary>
        /// This function will check wether the OCR number is correct or not by using the Luhn algorythm
        /// </summary>
        /// <param name="OcrNumberToCheck"></param>
        /// <returns></returns>
        public bool CheckIfOcrIsCorrect(string OcrNumberToCheck)
        {
            //This function will check the OCR number so that it is correct according to its checksum.

            //Variables
            bool validOcr = false;


            if (OcrNumberToCheck.All(x => char.IsNumber(x)))
            {
                //Every odd number is multiplied with one.
                //Every even number is multiplied with two.
                //Returned value as string
                var _iccOcrLuhnCalculated = OddEvenMulitplication(OcrNumberToCheck);

                //All number from LSB to MSB will be added together as single numbers (0 - 9)
                //Number is the divided by 10.
                //If last number in int = 0 it is considered to be a valid personal number.
                validOcr = PossibleToDivideByTen(_iccOcrLuhnCalculated);

                //Return false if not a valid number.
                //return 'true' if it is a valid number.
            }
            else
            {
                FormatException exceptionMessage = new FormatException("OCR contains a letter!!!");
                throw exceptionMessage;
            }
            return validOcr;

        }


        ////////////////////////////////
        //Private Functions
        ////////////////////////////////

        /// <summary>
        /// This function will remove any unwanted signs from the entered number series.
        /// string[] need to contain all signs that should be removed.
        /// </summary>
        /// <param name="notAllowedSigns"></param>
        /// <param name="_numberToAnalyze"></param>
        /// <returns></returns>
        private static string RemoveUnwantedSigns(List<string> notAllowedSigns, string _numberToAnalyze)
        {
            //Removal of unwanted signs are removed.
            foreach(var sign in notAllowedSigns)
            {
                _numberToAnalyze = _numberToAnalyze.Replace(sign, "");
            }
            return _numberToAnalyze;
        }

        private static string OddEvenMulitplication(string numberForCalculation)
        {

            ///Every odd number is multiplied with 1 and every even number is multiplied with 2.
            //Convert the number to a string and add to a totalsum string.
            //Will start with LSB and end with MSB

            //Constructor for private function
            bool _even = false;
            int _partsum;// = 0;
            string _totalSum = "";

            for (int _i = 1; _i <= numberForCalculation.Length; _i++)
            {

                _partsum = int.Parse(numberForCalculation.Substring(numberForCalculation.Length - _i, 1));

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

        private static bool PossibleToDivideByTen(string valueToCalculate)
        {
            //Variables
            bool _returnValue = false;
            int result = 0;
            string evaluationResult = "";

            for (int _i = 0; _i < valueToCalculate.Length; _i++)
            {
                //Måste räkna ut summan av addition på varje tal!!!!
                result += Convert.ToInt16(valueToCalculate.Substring(_i,1));
            }


            //The result should be pssoble to divid by 10
            //Check the last digit in the final result so that it is a '0'

            evaluationResult = result.ToString();
            int length = evaluationResult.Length;

            if (evaluationResult.Substring(length - 1, 1) == "0")
            {
                _returnValue = true;
            }
            else
                _returnValue = false;

            return _returnValue;
        }

    }
}
