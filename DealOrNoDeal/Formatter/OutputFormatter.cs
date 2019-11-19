using System;
using System.Collections.Generic;
using System.Linq;
using DealOrNoDeal.Utility;

namespace DealOrNoDeal.Formatter
{
    /// <summary>
    ///     Stores information for handling formatting output
    /// </summary>
    public static class OutputFormatter
    {
        #region Methods

        /// <summary>
        ///     Builds the no deal button output.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <param name="offers">The offers.</param>
        /// <returns>The formatted output when no deal button is pressed</returns>
        public static string BuildNoDealButtonOutput(ICollection<double> offers)
        {
            return formatMaxMinAvgOfferOutput(offers)
                   + Environment.NewLine + "Last Offer: " + CurrencyFormatter.FormatTwoDecimals(offers.Last());
        }

        /// <summary>
        ///     Builds the final round end game output.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <param name="value">The value of the case.</param>
        /// <returns>The formatted output for the final round end of game output</returns>
        public static string BuildFinalRoundEndGameOutput(int value)
        {
            var formattedValue = CurrencyFormatter.FormatTwoDecimals(value);

            return "Congrats! You win " + formattedValue + Environment.NewLine +
                   Environment.NewLine + "GAME OVER";
        }

        /// <summary>
        ///     Builds the end of round output.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <param name="offers">The offers.</param>
        /// <returns>The formatted output for the end of round summary.</returns>
        public static string BuildEndOfRoundOutput(ICollection<double> offers)
        {
            return formatMaxMinAvgOfferOutput(offers) + Environment.NewLine
                                                      + "Current Offer: " +
                                                      CurrencyFormatter.FormatTwoDecimals(offers.Last())
                                                      + Environment.NewLine + "Deal or No Deal?";
        }

        /// <summary>
        ///     Builds the total cases to open in round output.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <param name="round">The round number.</param>
        /// <param name="casesToOpen">The number of cases to open.</param>
        /// <returns>The formatted output for total cases to open in the current round.</returns>
        public static string BuildTotalCasesToOpenInRoundOutput(int round, int casesToOpen)
        {
            return "Round " + round + ": " + casesToOpen + " "
                   + StringManipulator.FormatSingleMultiple(casesToOpen, "cases") + " to open.";
        }

        /// <summary>
        ///     Builds the cases remaining to open output.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <param name="remainingCases">The number of remaining cases.</param>
        /// <returns>The formatted output for the number of remaining cases to open in the round.</returns>
        public static string BuildCasesRemainingToOpenOutput(int remainingCases)
        {
            return remainingCases + " more " + StringManipulator.FormatSingleMultiple(remainingCases, "cases")
                   + " to open.";
        }

        private static string formatMaxMinAvgOfferOutput(ICollection<double> offers)
        {
            return "Offers: Max: " + CurrencyFormatter.FormatTwoDecimals(offers.Max()) + ";"
                   + " Min: " + CurrencyFormatter.FormatTwoDecimals(offers.Min())
                   + Environment.NewLine + "        Average: " + CurrencyFormatter.FormatTwoDecimals(offers.Average());
        }

        /// <summary>
        ///     Formats the welcome message.
        /// </summary>
        /// <param name="gameType">Type of the game.</param>
        /// <returns>The formatted welcome message</returns>
        public static string FormatWelcomeMessage(string gameType)
        {
            return "Welcome to " + gameType + " Deal or No Deal!";
        }

        #endregion
    }
}