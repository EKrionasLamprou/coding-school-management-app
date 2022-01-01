using System;

namespace Input.Fields
{
    /// <summary>
    /// Represents an input field for integer numbers.
    /// </summary>
    public class Number : Field
    {
        /// <summary>
        /// The minimum valid input value.
        /// </summary>
        public int Min { get; set; }
        /// <summary>
        /// The maximum valid input value.
        /// </summary>
        public int Max { get; set; }
        /// <summary>
        /// True if the field should allow the user to enter empty input.
        /// </summary>
        public bool AllowEmpty { get; set; }

        public Number(string description, int max, bool allowEmpty = false, string placeholder = null)
            : this(description, 0, max, allowEmpty, placeholder) { }
        public Number(string description, int min, int max, bool allowEmpty = false, string placeholder = null)
            : base(description, placeholder)
        {
            Min = min;
            Max = max;
            AllowEmpty = allowEmpty;
        }

        /// <summary>
        /// Returns true if all the validation criteria are met.
        /// </summary>
        protected override bool IsValid(string input)
        {
            int num;

            if (string.IsNullOrEmpty(input))
            {
                return true;
            }
            if (!Int32.TryParse(input, out num))
            {
                error = $"The input must be numberic value.";
                return false;
            }
            if (num < Min)
            {
                error = $"The input number can't be less than {Min}.";
                return false;
            }
            if (num > Max)
            {
                error = $"The input number can't be more than {Max}.";
                return false;
            }
            return true;
        }
    }
}
