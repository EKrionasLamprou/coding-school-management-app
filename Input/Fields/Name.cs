using System.Text.RegularExpressions;

namespace Input.Fields
{
    /// <summary>
    /// Represents an input field for names.
    /// </summary>
    public class Name : Text
    {
        public Name(string description, int min = 0, int max = 100, string placeholder = null)
            : base(description, min, max, placeholder) {}

        /// <summary>
        /// Returns true if all the validation criteria are met.
        /// </summary>
        protected override bool IsValid(string input)
        {
            Regex rgx = new Regex(@"^[a-z -']+$", RegexOptions.IgnoreCase);

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
            if (!rgx.IsMatch(input))
            {
                error = "The input text must contain only latin characters, spaces or dashes.";
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
