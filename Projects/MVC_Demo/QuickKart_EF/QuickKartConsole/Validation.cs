using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuickKartConsole
{
    public class Validation
    {
        public bool IsNull(string input)
        {

            if (String.IsNullOrEmpty(input))
            {
                return false;
            }

            return true;

        }

        public bool IsInteger(string input)
        {
            try
            {
                int i = Convert.ToInt32(input);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool IsDecimal(string input)
        {
            try
            {
                decimal i = Convert.ToDecimal(input);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool IsLong(string input)
        {
            try
            {
                long i = Convert.ToInt64(input);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool IsChar(string input)
        {
            try
            {
                char i = Convert.ToChar(input);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool IsDate(string input)
        {
            try
            {
                DateTime i = Convert.ToDateTime(input);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool IsByte(string input)
        {
            try
            {
                byte i = Convert.ToByte(input);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool IsInt16(string input)
        {
            try
            {
                int i = Convert.ToInt16(input);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool ValidateGreaterThanZero(string input)
        {

            if (IsDecimal(input))
            {
                decimal val = Convert.ToDecimal(input);
                if (val > 0)
                    return true;
                return false;
            }
            else if (IsInteger(input))
            {
                int val = Convert.ToInt32(input);
                if (val > 0)
                    return true;
                return false;

            }
            else
                return false;

        }

        public bool ValidateFutureDate(string input)
        {

            if (IsDate(input))
            {
                DateTime val = Convert.ToDateTime(input);
                if (val > System.DateTime.Now)
                    return true;
                return false;
            }
            return false;

        }

        public bool ValidatePastDate(string input)
        {

            if (IsDate(input))
            {
                DateTime val = Convert.ToDateTime(input);
                if (val < System.DateTime.Now)
                    return true;
                return false;
            }
            return false;

        }

        public bool ValidateGender(string input)
        {
            char gender = Convert.ToChar(input);
            if (gender == 'F' || gender == 'M' || gender == 'f' || gender == 'm')
            {

                return true;
            }
            return false;
        }
        public bool ValidateProductId(string input)
        {

            string pattern = "^P{1}\\d+";
            return Regex.IsMatch(input, pattern);


        }


    }
}
