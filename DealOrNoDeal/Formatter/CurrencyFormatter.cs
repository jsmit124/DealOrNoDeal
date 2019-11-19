namespace DealOrNoDeal.Formatter
{
    /// <summary>
    ///     Manages formatting int values to currency format.
    /// </summary>
    public static class CurrencyFormatter
    {
        #region Methods

        /// <summary>
        ///     Formats the specified value to currency standards with two decimals.
        ///     Precondition: None
        ///     Post-Condition: None
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>The formatted value with two decimals</returns>
        public static string FormatTwoDecimals(double value)
        {
            return value.ToString("C2");
        }

        /// <summary>
        ///     Formats the specified value to currency standard with no decimals.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>The formatted value with no decimals</returns>
        public static string FormatNoDecimals(int value)
        {
            return value.ToString("C0");
        }

        #endregion
    }
}