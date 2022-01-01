namespace SCS.Entities
{
    /// <summary>
    /// Represents the stream of a course.
    /// </summary>
    public class Stream
    {
        /// <summary>
        /// The stream's number.
        /// </summary>
        public short Order { get; private set; }

        public Stream(short order)
        {
            Order = order;
        }

        /// <summary>
        /// Returns a string of the stream in the form of CB{Order}.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"CB{Order}";
    }
}
