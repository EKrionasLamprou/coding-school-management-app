using System;
using System.Globalization;

namespace Input.Fields
{
    /// <summary>
    /// Represents an input field for date.
    /// </summary>
    public class Date : Field
    {
        /// <summary>
        /// The minimum valid input value.
        /// </summary>
        public DateTime Min { get; set; }
        /// <summary>
        /// The maximum valid input value.
        /// </summary>
        public DateTime Max { get; set; }

        public Date(string description, string min, string max, string placeholder = null)
            : this(description, Convert.ToDateTime(min), Convert.ToDateTime(max), placeholder) { }
        public Date(string description, DateTime min, DateTime max, string placeholder = null)
            : base(description, placeholder)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Returns true if all the validation criteria are met.
        /// </summary>
        protected override bool IsValid(string input)
        {
            DateTime date;
            string format = "dd/MM/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;

            try
            {
                date = DateTime.ParseExact(input, format, provider);
            }
            catch (Exception)
            {
                error = $"The date format must be: DD/MM/YYYY.";
                return false;
            }
            if (date < Min)
            {
                error = $"The input date can't be earlier than {Min.ToString(format)}.";
                return false;
            }
            if (date > Max)
            {
                error = $"The input date can't be later than {Max.ToString(format)}.";
                return false;
            }
            return true;
        }
    }
}
