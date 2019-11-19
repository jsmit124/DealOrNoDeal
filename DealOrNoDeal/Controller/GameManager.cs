using System.Collections.Generic;
using System.Linq;
using DealOrNoDeal.Model;
using DealOrNoDeal.Utility;

namespace DealOrNoDeal.Controller
{
    /// <summary>Manages the actual game play.</summary>
    public class GameManager
    {
        #region Data members

        private readonly Banker bank;
        private readonly RoundManager roundManager;
        private readonly BriefcaseManager briefcaseManager;
        private GameSettings settings;
        private readonly Player player;

        #endregion

        #region Properties

        private IEnumerable<Briefcase> Briefcases => this.briefcaseManager.Briefcases.ToList();

        /// <summary>
        ///     Gets the current round.
        /// </summary>
        /// <value>
        ///     The current round.
        /// </value>
        public int CurrentRound => this.roundManager.CurrentRound;

        /// <summary>
        ///     Gets all offers.
        /// </summary>
        /// <value>
        ///     All offers.
        /// </value>
        public ICollection<double> AllOffers => this.bank.Offers;

        /// <summary>
        /// Gets the current offer.
        /// </summary>
        /// <value>
        /// The current offer.
        /// </value>
        public int CurrentOffer => this.bank.CurrentOffer;

        /// <summary>
        ///     Gets the number of cases to open in the current round.
        /// </summary>
        /// <value>
        ///     The number of cases to open in the current round.
        /// </value>
        public int CasesToOpenInRound => this.roundManager.CasesToOpenInRound;

        /// <summary>
        ///     Gets the player case ID.
        /// </summary>
        /// <value>
        ///     The player case ID.
        /// </value>
        public int PlayerCaseId => this.player.PlayerCaseId;

        /// <summary>
        ///     Gets the game type amounts.
        /// </summary>
        /// <value>
        ///     The game type amounts.
        /// </value>
        public List<int> GameTypeAmounts => this.briefcaseManager.ChosenGameTypeAmounts.ToList();

        /// <summary>
        ///     Gets the cases remaining in round.
        /// </summary>
        /// <value>
        ///     The cases remaining in round.
        /// </value>
        public int CasesRemainingInRound => this.roundManager.CasesRemainingInRound;

        /// <summary>
        ///     Gets the final case ID.
        /// </summary>
        /// <value>
        ///     The final case ID.
        /// </value>
        public int FinalCaseId => this.briefcaseManager.FinalCaseId;

        /// <summary>
        ///     Gets the banker's offer.
        ///     Precondition: amountsLeftInPlay != 0
        ///     Post-condition:None
        /// </summary>
        /// <returns>Returns the banker's offer</returns>
        public double GetOffer =>
            this.bank.CalculateOffer((from briefcase in this.Briefcases select briefcase.DollarAmount).ToList(),
                this.CasesToOpenInRound);

        #endregion

        #region Constructors

        /// <summary Briefcase="();">
        ///     Initializes a new instance of the <see cref="GameManager" /> class.
        ///     Precondition: None
        ///     Post-condition: this.PlayerCaseId = -1
        /// </summary>
        public GameManager()
        {
            this.player = new Player(-1);
            this.bank = new Banker();
            this.roundManager = new RoundManager();
            this.briefcaseManager = new BriefcaseManager();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Removes the specified briefcase from play.
        ///     Precondition: this.briefcases.Count != 0
        ///     Post-condition: Briefcase is removed from this.briefcaseManager.Briefcases if foundCase.Id == id
        /// </summary>
        /// <param name="id">The id of the briefcase to remove from play.</param>
        /// <returns>Dollar amount stored in the case, or -1 if case not found.</returns>
        public void RemoveBriefcaseFromPlay(int id)
        {
            this.briefcaseManager.RemoveBriefcase(id);
        }

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Post-condition: Round == Round@prev + 1 &&
        ///     CasesRemainingInRound == (number of cases to open in the next round)
        /// </summary>
        public void MoveToNextRound()
        {
            this.roundManager.MoveToNextRound();
        }

        /// <summary>
        ///     Populates the briefcases.
        ///     Precondition: None
        ///     Post-condition: briefcaseManager.Briefcases.DollarAmount == random dollar amount from chosen dollar amounts
        /// </summary>
        public void PopulateBriefcases()
        {
            this.briefcaseManager.PopulateBriefcases(this.settings.Type);
        }

        /// <summary>
        ///     Finds the briefcase dollar amount from id.
        ///     Precondition: this.Briefcases.Count != 0
        ///     Post-condition: None
        /// </summary>
        /// <param name="inputId">The input id.</param>
        /// <returns>The dollar amount of the case found from searching for ID</returns>
        public int FindBriefcaseAmountFromId(int inputId)
        {
            return this.briefcaseManager.FindBriefcaseAmountFromId(inputId);
        }

        /// <summary>
        ///     Decrements the cases left in round.
        ///     Precondition: this.briefcases.Count != 0
        ///     Post-condition: this.roundManager.CasesLeftInRound--
        /// </summary>
        public void DecrementCasesLeftInRound()
        {
            this.roundManager.DecrementCasesLeftInRound();
        }

        /// <summary>
        ///     Determines if the round has ended.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <returns>true if round is over (casesRemainingInRound == 0), false otherwise</returns>
        public bool RoundHasEnded()
        {
            return this.roundManager.RoundHasEnded();
        }

        /// <summary>
        ///     Sets the player case ID.
        ///     Precondition: None
        ///     Post-condition: this.PlayerCaseId == id
        /// </summary>
        /// <param name="id">The case's ID.</param>
        public void SetPlayerCaseId(int id)
        {
            this.player.SetPlayerCaseId(id);
        }

        /// <summary>
        ///     Determines whether the player has reached the final round.
        ///     Precondition: None
        ///     Post-condition: None
        /// </summary>
        /// <returns>
        ///     <c>true</c> if this.CurrentRound == this.roundManager.CasesLeftToOpen == 0; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFinalRound()
        {
            return this.roundManager.IsFinalRound();
        }

        /// <summary>
        ///     Sets the final case id.
        ///     Precondition: this.briefcases.Count != 0
        ///     Post-condition: this.finalCaseId = id
        /// </summary>
        /// <param name="id">The id of the final case.</param>
        public void SetFinalCaseId(int id)
        {
            this.briefcaseManager.SetFinalCaseId(id);
        }

        /// <summary>
        ///     Sets the settings.
        ///     Precondition: None
        ///     Post-condition: this.settings.gameType == gameType && this.settings.roundAmount == roundAmount
        /// </summary>
        /// <param name="gameType">Type of the game.</param>
        /// <param name="roundAmount">The round amount.</param>
        public void SetSettings(string gameType, int roundAmount)
        {
            this.settings = new GameSettings(gameType, roundAmount);
        }

        /// <summary>
        ///     Sets the rounds.
        ///     Precondition: this.settings != null
        ///     Post-condition: this.roundManager.RoundAmount == this.settings.Rounds
        /// </summary>
        public void SetRounds()
        {
            this.roundManager.SetupRounds(this.settings.Rounds);
        }

        /// <summary>
        ///     Adds the offer to the collection of offers.
        /// </summary>
        /// <param name="offer">The offer.</param>
        public void AddOffer(double offer)
        {
            this.bank.AddOffer(offer);
        }

        #endregion
    }
}