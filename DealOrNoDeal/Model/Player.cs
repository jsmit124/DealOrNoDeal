namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Stores information for the player object
    /// </summary>
    public class Player
    {
        #region Properties

        /// <summary>
        ///     Gets the player case id.
        /// </summary>
        /// <value>
        ///     The player case id.
        /// </value>
        public int PlayerCaseId { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        ///     Precondition: None
        ///     Post-condition: this.PlayerCaseId = caseId
        /// </summary>
        /// <param name="caseId">The player case id.</param>
        public Player(int caseId)
        {
            this.PlayerCaseId = caseId;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Sets the player case ID.
        ///     Precondition: None
        ///     Post-condition: this.PlayerCaseId == id
        /// </summary>
        /// <param name="caseId">The case's ID.</param>
        public void SetPlayerCaseId(int caseId)
        {
            this.PlayerCaseId = caseId;
        }

        #endregion
    }
}