namespace Input.Fields
{
    /// <summary>
    /// Represents an input field for floats.
    /// </summary>
    public class FloatNum : Field
    {
        /// <summary>
        /// The minimum valid input value.
        /// </summary>
        public float Min { get; set; }
        /// <summary>
        /// The maximum valid input value.
        /// </summary>
        public float Max { get; set; }

        public FloatNum(string description, float max, string placeholder = null)
            : this(description, 0, max, placeholder) { }
        public FloatNum(string description, float min, float max, string placeholder = null)
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
            float num;

            if (!float.TryParse(input, out num))
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
