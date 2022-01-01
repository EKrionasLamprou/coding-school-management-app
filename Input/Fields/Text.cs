namespace Input.Fields
{
    /// <summary>
    /// Represents an input field for text.
    /// </summary>
    public class Text : Field
    {
        /// <summary>
        /// The minimum valid input value.
        /// </summary>
        public int Min { get; set; }
        /// <summary>
        /// The maximum valid input value.
        /// </summary>
        public int Max { get; set; }

        public Text(string description, int min = 0, int max = 100, string placeholder = null)
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
            if (input.Length < Min)
            {
                error = $"The input text length can't be less than {Min} characters.";
                return false;
            }
            if (input.Length > Max)
            {
                error = $"The input text length can't be more than {Max} characters.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                error = "The input text must not contain only whitespaces.";
                return false;
            }
            return true;
        }
    }
}
