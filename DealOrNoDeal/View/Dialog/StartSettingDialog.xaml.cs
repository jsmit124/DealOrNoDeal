using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DealOrNoDeal.View.Dialog
{
    /// <summary>
    ///     Stores information for the StartSettingDialog
    /// </summary>
    /// <seealso cref="ContentDialog" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class StartSettingDialog
    {
        #region Data members

        private readonly ObservableCollection<int> roundTypes;
        private readonly ObservableCollection<string> gameTypes;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the selected round.
        /// </summary>
        /// <value>
        ///     The selected round.
        /// </value>
        public int SelectedRound { get; private set; }

        /// <summary>
        ///     Gets the type of the selected game.
        /// </summary>
        /// <value>
        ///     The type of the selected game.
        /// </value>
        public string SelectedGameType { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="StartSettingDialog" /> class.
        /// </summary>
        public StartSettingDialog()
        {
            this.InitializeComponent();
            this.roundTypes = new ObservableCollection<int>();
            this.gameTypes = new ObservableCollection<string>();
            this.SelectedRound = -1;
            this.SelectedGameType = "";
            this.setupDropdowns();
        }

        #endregion

        #region Methods

        private void setupDropdowns()
        {
            this.roundTypes.Add(7);
            this.roundTypes.Add(10);
            this.roundTypes.Add(13);
            this.gameTypes.Add("Syndicated");
            this.gameTypes.Add("Regular");
            this.gameTypes.Add("Mega");
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var selectedType = this.gameTypeComboBox.SelectedItem;
            var selectedRound = this.roundAmountComboBox.SelectedItem;

            if (selectedType != null && selectedRound != null)
            {
                this.SelectedGameType = selectedType.ToString();
                this.SelectedRound = int.Parse(selectedRound.ToString());
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Application.Current.Exit();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.roundAmountComboBox.SelectedItem != null && this.gameTypeComboBox.SelectedItem != null)
            {
                IsPrimaryButtonEnabled = true;
            }
        }

        #endregion
    }
}