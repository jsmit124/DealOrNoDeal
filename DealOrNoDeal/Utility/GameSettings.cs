namespace DealOrNoDeal.Utility
{
    /// <summary>
    ///     Stores information for the settings of the game
    /// </summary>
    public class GameSettings
    {
        #region Properties

        /// <summary>
        ///     Gets the game type.
        /// </summary>
        /// <value>
        ///     The game type.
        /// </value>
        public string Type { get; }

        /// <summary>
        ///     Gets the number of rounds.
        /// </summary>
        /// <value>
        ///     The number of rounds.
        /// </value>
        public int Rounds { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameSettings" /> class.
        ///     Precondition: None
        ///     Post-condition: this.Type == gameType && this.Rounds == roundAmount
        /// </summary>
        /// <param name="gameType">Type of the game.</param>
        /// <param name="roundAmount">The round amount.</param>
        public GameSettings(string gameType, int roundAmount)
        {
            this.Type = gameType;
            this.Rounds = roundAmount;
        }

        #endregion
    }
}