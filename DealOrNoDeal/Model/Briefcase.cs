namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Stores information for the Briefcase class
    /// </summary>
    public class Briefcase
    {
        #region Properties

        /// <summary>
        ///     Gets the Briefcase ID.
        /// </summary>
        /// <value>
        ///     The Briefcase ID.
        /// </value>
        public int Id { get; }

        /// <summary>
        ///     Gets the dollar amount.
        /// </summary>
        /// <value>
        ///     The dollar amount.
        /// </value>
        public int DollarAmount { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Briefcase" /> class.
        ///     Precondition: None
        ///     Post-condition: this.Id = id && this.DollarAmount = dollarAmount
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="dollarAmount">The dollar amount.</param>
        public Briefcase(int id, int dollarAmount)
        {
            this.Id = id;
            this.DollarAmount = dollarAmount;
        }

        #endregion
    }
}