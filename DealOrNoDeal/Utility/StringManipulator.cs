namespace DealOrNoDeal.Utility
{
    /// <summary>
    ///     Manipulates strings
    /// </summary>
    public static class StringManipulator
    {
        #region Methods

        /// <summary>
        ///     Formats the string by adding or removing the 's' at the end of the string
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="word">The word.</param>
        /// <returns>The formatted string</returns>
        public static string FormatSingleMultiple(int count, string word)
        {
            var output = word;

            if (count == 1 && word.EndsWith("s"))
            {
                output = word.Remove(word.Length - 1);
            }

            return output;
        }

        #endregion
    }
}