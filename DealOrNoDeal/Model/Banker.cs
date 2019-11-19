using System;
using System.Collections.Generic;
using System.Linq;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Represents the Banker
    /// </summary>
    public class Banker
    {
        #region Properties

        /// <summary>
        ///     Gets the offers.
        /// </summary>
        /// <value>
        ///     The offers.
        /// </value>
        public ICollection<double> Offers { get; }

        /// <summary>
        ///     Gets the current offer.
        /// </summary>
        /// <value>
        ///     The current offer.
        /// </value>
        public int CurrentOffer => Convert.ToInt32(this.Offers.Last());

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Banker" /> class.
        ///     Precondition: None
        ///     Post-condition: this.Offers = new List
        /// </summary>
        public Banker()
        {
            this.Offers = new List<double>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Calculates the banker's offer.
        ///     Precondition: None
        ///     Post-condition: this.offers.Add(formattedOffer)
        /// </summary>
        /// <param name="amountsLeftInPlay">The amounts left in play.</param>
        /// <param name="casesToOpenNextRound">The cases to open next round.</param>
        /// <returns>The banker's offer</returns>
        public double CalculateOffer(List<int> amountsLeftInPlay, int casesToOpenNextRound)
        {
            var totalLeftInPlay = amountsLeftInPlay.Sum();
            var offer = totalLeftInPlay / casesToOpenNextRound / amountsLeftInPlay.Count;
            var formattedOffer = formatOfferToNearest100(offer);

            return formattedOffer;
        }

        private static double formatOfferToNearest100(int offer)
        {
            return Math.Round(Convert.ToDouble(offer) / 100d, 0) * 100;
        }

        /// <summary>
        ///     Adds the offer to the list of offers.
        /// </summary>
        /// <param name="offer">The offer.</param>
        public void AddOffer(double offer)
        {
            this.Offers.Add(offer);
        }

        #endregion
    }
}