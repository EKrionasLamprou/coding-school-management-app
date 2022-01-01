using System;
using System.Globalization;
using Printer;

namespace Input.Fields
{
    /// <summary>
    /// Represents an input field for two dates.
    /// </summary>
    public class DateSpan : Date
    {
        private string date1;
        private string date2;

        /// <summary>
        /// The description for the second date input.
        /// </summary>
        public string Description2 { get; set; }
        public TimeSpan MinSpan { get; set; }
        public TimeSpan MaxSpan { get; set; }

        public DateSpan(string description1, string description2,
            string min, string max, string placeholder = null) :
            this(description1, description2, min, max, TimeSpan.MinValue, TimeSpan.MaxValue, placeholder) { }
        public DateSpan(string description1, string description2,
            string min, string max, TimeSpan minSpan, TimeSpan maxSpan, string placeholder = null) :
            base(description1, min, max, placeholder)
        {
            Description2 = description2;
            MinSpan = minSpan;
            MaxSpan = maxSpan;
        }

        /// <summary>
        /// Asks and returns user input as string.
        /// </summary>
        public override string GetInput()
        {
            date1 = GetDate();
            date2 = GetDate();
            return $"{date1} - {date2}";
        }

        /// <summary>
        /// The date input.
        /// </summary>
        private string GetDate()
        {
            string input;
            Console.Clear();

            if (error != null) PrintError();
            else Output.Print(lineBreaks: 1);
            error = null;

            if (date1 != null) Min = Convert.ToDateTime(date1);

            PrintDescription();
            if (Placeholder != null) PrintPlaceholder();
            input = Console.ReadLine();

            return IsValid(input) ? input : GetDate();
        }

        /// <summary>
        /// Outputs the field description on the console.
        /// </summary>
        protected override void PrintDescription()
        {
            string desc = date1 is null ? Description : Description2;
            Output.Print(desc + ": ", lineBreaks: 0);
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
            if (date1 != null)
            {
                DateTime firstDate = Convert.ToDateTime(date1);
                if (date - firstDate < MinSpan)
                {
                    error = $"The difference between the dates can't be less than {MinSpan.Days} days.";
                    return false;
                }
                if (date - firstDate > MaxSpan)
                {
                    error = $"The difference between the dates can't be more than {MaxSpan.Days} days.";
                    return false;
                }
            }
            return true;
        }
    }
}
