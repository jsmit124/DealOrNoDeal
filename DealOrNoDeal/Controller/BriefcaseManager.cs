using System;
using System.Collections.Generic;
using System.Linq;
using DealOrNoDeal.Model;

namespace DealOrNoDeal.Controller
{
    /// <summary>
    ///     Handles the management of briefcases
    /// </summary>
    public class BriefcaseManager
    {
        #region Data members

        private readonly ICollection<int> syndicatedAmounts = new List<int> {
            0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 2500, 5000, 10000, 25000, 50000, 75000, 100000,
            150000, 200000, 250000, 350000, 500000
        };

        private readonly ICollection<int> regularAmounts = new List<int> {
            0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000, 50000, 75000, 100000,
            200000, 300000, 400000, 500000, 750000, 1000000
        };

        private readonly ICollection<int> megaAmounts = new List<int> {
            0, 100, 500, 1000, 2500, 5000, 7500, 10000, 20000, 30000, 40000, 50000, 75000, 100000, 225000, 400000,
            500000, 750000, 1000000, 2000000, 3000000, 4000000, 5000000, 6000000, 8500000, 10000000
        };

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the chosen game type amounts.
        /// </summary>
        /// <value>
        ///     The chosen game type amounts.
        /// </value>
        public ICollection<int> ChosenGameTypeAmounts { get; private set; }

        /// <summary>
        ///     Gets the briefcases.
        /// </summary>
        /// <value>
        ///     The briefcases.
        /// </value>
        public List<Briefcase> Briefcases { get; private set; }

        /// <summary>
        ///     Gets the final case id.
        /// </summary>
        /// <value>
        ///     The final case id.
        /// </value>
        public int FinalCaseId { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Populates the Briefcases.
        ///     Precondition: None
        ///     Post-condition: this.Briefcases.briefcase.DollarAmount == this.ChosenGameAmounts.ElementAt(Random.Next())
        /// </summary>
        /// <param name="gameType">Type of the game.</param>
        /// <returns>The list populated with specified amounts based on game type.</returns>
        public void PopulateBriefcases(string gameType)
        {
            var random = new Random();
            const int totalBriefcases = 26;
            var outputCases = new List<Briefcase>();

            this.setGameTypeAmounts(gameType);

            var amounts = this.ChosenGameTypeAmounts.ToList();
            for (var i = 1; i <= totalBriefcases; i++)
            {
                var randomNumber = random.Next(0, amounts.Count);
                var currentBriefcase = new Briefcase(i - 1, amounts.ElementAt(randomNumber));
                outputCases.Add(currentBriefcase);
                amounts.RemoveAt(randomNumber);
            }

            this.Briefcases = outputCases;
        }

        private void setGameTypeAmounts(string gameType)
        {
            switch (gameType.ToLower())
            {
                case "syndicated":
                    this.ChosenGameTypeAmounts = this.syndicatedAmounts.ToList();
                    break;
                case "mega":
                    this.ChosenGameTypeAmounts = this.megaAmounts.ToList();
                    break;
                default:
                    this.ChosenGameTypeAmounts = this.regularAmounts.ToList();
                    break;
            }
        }

        /// <summary>
        ///     Removes the briefcase from play.
        ///     Precondition: this.Briefcases.Count != 0
        ///     Post-condition: Removes briefcase from this.Briefcase where briefcase.Id == id
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Finds the briefcase from the input id and removes it</returns>
        public void RemoveBriefcase(int id)
        {
            this.Briefcases.RemoveAll(removalCase => removalCase.Id == id);
        }

        /// <summary>
        ///     Finds the briefcase amount from id.
        ///     Precondition: this.Briefcases.Count != 0
        ///     Post-condition: None
        /// </summary>
        /// <param name="inputId">The input id.</param>
        /// <returns>The amount found in the briefcase with the matching id</returns>
        public int FindBriefcaseAmountFromId(int inputId)
        {
            var foundCase = this.Briefcases.Find(briefcase => briefcase.Id == inputId);

            return foundCase.DollarAmount;
        }

        /// <summary>
        ///     Sets the final case id.
        ///     Precondition: None
        ///     Post-condition: this.finalCaseId = id
        /// </summary>
        /// <param name="id">The id of the final case.</param>
        public void SetFinalCaseId(int id)
        {
            this.FinalCaseId = id;
        }

        #endregion
    }
}