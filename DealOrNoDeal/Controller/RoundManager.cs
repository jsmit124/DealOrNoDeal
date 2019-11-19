using System.Collections.Generic;
using System.Linq;

namespace DealOrNoDeal.Controller
{
    /// <summary>
    ///     Manages the rounds for the game
    /// </summary>
    public class RoundManager
    {
        #region Data members

        private int finalRound;

        private readonly ICollection<int> casesToOpenIn7Rounds = new List<int> {
            8, 6, 4, 3, 2, 1, 1
        };

        private readonly ICollection<int> casesToOpenIn10Rounds = new List<int> {
            6, 5, 4, 3, 2, 1, 1, 1, 1, 1
        };

        private readonly ICollection<int> casesToOpenIn13Rounds = new List<int> {
            7, 5, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
        };

        private ICollection<int> chosenCasesToOpenInRound;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the number of cases to open in the current round.
        /// </summary>
        /// <value>
        ///     The number of cases to open in the current round.
        /// </value>
        public int CasesToOpenInRound { get; private set; }

        /// <summary>
        ///     Gets the cases remaining in round.
        /// </summary>
        /// <value>
        ///     The cases remaining in round.
        /// </value>
        public int CasesRemainingInRound { get; private set; }

        /// <summary>
        ///     Gets the current round.
        /// </summary>
        /// <value>
        ///     The current round.
        /// </value>
        public int CurrentRound { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RoundManager" /> class.
        ///     Precondition: None
        ///     Post-condition: this.CurrentRound == 1
        /// </summary>
        public RoundManager()
        {
            this.CurrentRound = 1;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Post-condition: Round == Round@prev + 1 &&
        ///     CasesRemainingInRound == (number of cases to open in the next round)
        /// </summary>
        public void MoveToNextRound()
        {
            this.CurrentRound++;

            this.CasesToOpenInRound = this.chosenCasesToOpenInRound.ElementAt(this.CurrentRound - 1);
            this.CasesRemainingInRound = this.CasesToOpenInRound;
        }

        /// <summary>
        ///     Decrements the cases left in round.
        ///     Precondition: this.CasesRemainingInRound != 0
        ///     Post-condition: this.CasesRemainingInRound--
        /// </summary>
        public void DecrementCasesLeftInRound()
        {
            this.CasesRemainingInRound--;
        }

        /// <summary>
        ///     Determines whether the player has reached the final round.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <returns>
        ///     <c>true</c> if this.CurrentRound == this.ChosenRoundAmounts.Count; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFinalRound()
        {
            return this.CurrentRound == this.finalRound;
        }

        /// <summary>
        ///     Determines if the round has ended.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <returns>true if round is over (casesRemainingInRound == 0), false otherwise</returns>
        public bool RoundHasEnded()
        {
            return this.CasesRemainingInRound == 0;
        }

        /// <summary>
        ///     Setups the rounds.
        ///     Precondition: None
        ///     Post-condition: if rounds == 7, this.chosenCasesToOpenInRound == casesToOpenIn7Rounds
        ///     || if rounds == 10, this.chosenCasesToOpenInRound == casesToOpenIn10Rounds
        ///     || if rounds == 13, this.chosenCasesToOpenInRound == casesToOpenIn13Rounds
        /// </summary>
        /// <param name="rounds">The amount of rounds chosen for the game.</param>
        public void SetupRounds(int rounds)
        {
            switch (rounds)
            {
                case 7:
                    this.chosenCasesToOpenInRound = this.casesToOpenIn7Rounds;
                    break;
                case 13:
                    this.chosenCasesToOpenInRound = this.casesToOpenIn13Rounds;
                    break;
                default:
                    this.chosenCasesToOpenInRound = this.casesToOpenIn10Rounds;
                    break;
            }

            this.finalRound = this.chosenCasesToOpenInRound.Count;
            this.CasesToOpenInRound = this.chosenCasesToOpenInRound.First();
            this.CasesRemainingInRound = this.chosenCasesToOpenInRound.First();
        }

        #endregion
    }
}