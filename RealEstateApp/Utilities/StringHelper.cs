using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    /// <summary>
    /// String helper class
    /// </summary>

    public static class StringHelper
    {

        /// <summary>
        /// Converts given string to integer
        /// </summary>
        /// <param name="input"> string </param>
        /// <param name="value"> Int </param>
        /// <returns> bool </returns>
        public static bool ToInt(string input, out int value)
        {
            return int.TryParse(input, out value);
        }

        /// <summary>
        /// Converts given string to double
        /// </summary>
        /// <param name="s"> string </param>
        /// <returns> bool </returns>
        public static bool ToDouble(string input, out double value)
        {
            return double.TryParse(input, out value);
        }

        /// <summary>
        /// Converts given string to int and checks if 
        /// value is between lower and higher limits.
        /// </summary>
        /// <param name="s"> string </param>
        /// <param name="lowLimit"> int </param>
        /// <param name="highLimit"> int </param>
        /// <param name="value"> int </param>
        /// <returns> bool </returns>
        public static bool StringToInt(string s, int lowLimit, int highLimit, out int value)
        {
            return int.TryParse(s, out value) && (value > lowLimit) && (value < highLimit);
        }

        /// <summary>
        /// Converts given string to double and checks if 
        /// value is between lower and higher limits.
        /// </summary>
        /// <param name="s"> string </param>
        /// <param name="lowLimit"> int </param>
        /// <param name="highLimit"> int </param>
        /// <param name="value"> int </param>
        /// <returns> bool </returns>
        public static bool StringToDouble(string s, double lowLimit, double highLimit, out double value)
        {
            return double.TryParse(s, out value) && (value > lowLimit) && (value < highLimit);
        }

    }
}
