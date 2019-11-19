using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using DealOrNoDeal.Controller;
using DealOrNoDeal.Formatter;
using DealOrNoDeal.View.Dialog;

namespace DealOrNoDeal.View
{
    /// <summary>
    ///     Stores information controlling the view of the Deal or No Deal page
    /// </summary>
    /// <seealso cref="Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class DealOrNoDealPage
    {
        #region Data members

        /// <summary>
        ///     The application height
        /// </summary>
        public const int ApplicationHeight = 575;

        /// <summary>
        ///     The application width
        /// </summary>
        public const int ApplicationWidth = 600;

        private IList<Button> briefcaseButtons;
        private IList<Border> dollarAmountLabels;
        private readonly GameManager manager;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DealOrNoDealPage" /> class.
        ///     Precondition: None
        ///     Post-condition: this.manager = new GameManager()
        /// </summary>
        public DealOrNoDealPage()
        {
            this.InitializeComponent();
            this.initializeUiDataAndControls();
            this.manager = new GameManager();

            this.handleSetup();
        }

        #endregion

        #region Methods

        private async void handleSetup()
        {
            this.disableAllCases();

            var settingDialog = new StartSettingDialog();
            await settingDialog.ShowAsync();

            this.manager.SetSettings(settingDialog.SelectedGameType, settingDialog.SelectedRound);

            this.manager.PopulateBriefcases();
            this.setDollarLabelAmounts();
            this.manager.SetRounds();

            this.roundLabel.Text = OutputFormatter.FormatWelcomeMessage(settingDialog.SelectedGameType);
            this.casesToOpenLabel.Text = "Please select your case.";

            this.enableAllCases();
        }

        private void initializeUiDataAndControls()
        {
            setPageSize();

            this.briefcaseButtons = new List<Button>();
            this.dollarAmountLabels = new List<Border>();

            this.buildBriefcaseButtonCollection();
            this.buildDollarAmountLabelCollection();

            this.disableDealNoDealButtons();
        }

        private void disableDealNoDealButtons()
        {
            this.noDealButton.Visibility = Visibility.Collapsed;
            this.dealButton.Visibility = Visibility.Collapsed;
        }

        private static void setPageSize()
        {
            ApplicationView.PreferredLaunchViewSize = new Size {Width = ApplicationWidth, Height = ApplicationHeight};
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        private void buildBriefcaseButtonCollection()
        {
            this.briefcaseButtons.Clear();

            this.briefcaseButtons.Add(this.case0);
            this.briefcaseButtons.Add(this.case1);
            this.briefcaseButtons.Add(this.case2);
            this.briefcaseButtons.Add(this.case3);
            this.briefcaseButtons.Add(this.case4);
            this.briefcaseButtons.Add(this.case5);
            this.briefcaseButtons.Add(this.case6);
            this.briefcaseButtons.Add(this.case7);
            this.briefcaseButtons.Add(this.case8);
            this.briefcaseButtons.Add(this.case9);
            this.briefcaseButtons.Add(this.case10);
            this.briefcaseButtons.Add(this.case11);
            this.briefcaseButtons.Add(this.case12);
            this.briefcaseButtons.Add(this.case13);
            this.briefcaseButtons.Add(this.case14);
            this.briefcaseButtons.Add(this.case15);
            this.briefcaseButtons.Add(this.case16);
            this.briefcaseButtons.Add(this.case17);
            this.briefcaseButtons.Add(this.case18);
            this.briefcaseButtons.Add(this.case19);
            this.briefcaseButtons.Add(this.case20);
            this.briefcaseButtons.Add(this.case21);
            this.briefcaseButtons.Add(this.case22);
            this.briefcaseButtons.Add(this.case23);
            this.briefcaseButtons.Add(this.case24);
            this.briefcaseButtons.Add(this.case25);

            this.storeBriefCaseIndexInControlsTagProperty();
        }

        private void buildDollarAmountLabelCollection()
        {
            this.dollarAmountLabels.Clear();

            this.dollarAmountLabels.Add(this.label0Border);
            this.dollarAmountLabels.Add(this.label1Border);
            this.dollarAmountLabels.Add(this.label2Border);
            this.dollarAmountLabels.Add(this.label3Border);
            this.dollarAmountLabels.Add(this.label4Border);
            this.dollarAmountLabels.Add(this.label5Border);
            this.dollarAmountLabels.Add(this.label6Border);
            this.dollarAmountLabels.Add(this.label7Border);
            this.dollarAmountLabels.Add(this.label8Border);
            this.dollarAmountLabels.Add(this.label9Border);
            this.dollarAmountLabels.Add(this.label10Border);
            this.dollarAmountLabels.Add(this.label11Border);
            this.dollarAmountLabels.Add(this.label12Border);
            this.dollarAmountLabels.Add(this.label13Border);
            this.dollarAmountLabels.Add(this.label14Border);
            this.dollarAmountLabels.Add(this.label15Border);
            this.dollarAmountLabels.Add(this.label16Border);
            this.dollarAmountLabels.Add(this.label17Border);
            this.dollarAmountLabels.Add(this.label18Border);
            this.dollarAmountLabels.Add(this.label19Border);
            this.dollarAmountLabels.Add(this.label20Border);
            this.dollarAmountLabels.Add(this.label21Border);
            this.dollarAmountLabels.Add(this.label22Border);
            this.dollarAmountLabels.Add(this.label23Border);
            this.dollarAmountLabels.Add(this.label24Border);
            this.dollarAmountLabels.Add(this.label25Border);
        }

        private void setDollarLabelAmounts()
        {
            for (var i = 0; i < this.dollarAmountLabels.Count; i++)
            {
                var currentBorder = this.dollarAmountLabels.ElementAt(i);
                var textBlock = (TextBlock) currentBorder.Child;
                textBlock.Text = CurrencyFormatter.FormatNoDecimals(this.manager.GameTypeAmounts.ElementAt(i));
            }
        }

        private void storeBriefCaseIndexInControlsTagProperty()
        {
            for (var i = 0; i < this.briefcaseButtons.Count; i++)
            {
                this.briefcaseButtons[i].Tag = i;
            }
        }

        private void briefcase_Click(object sender, RoutedEventArgs e)
        {
            var sendingButton = (Button) sender;
            var sendingCaseId = getBriefcaseId(sendingButton);
            this.disableSelectedCase(sendingButton);

            if (this.manager.PlayerCaseId == -1)
            {
                this.handlePlayerCaseSelection(sendingCaseId, sendingButton);
            }
            else if (this.manager.IsFinalRound())
            {
                this.handleGameEnd(this.manager.FindBriefcaseAmountFromId(sendingCaseId));
            }
            else
            {
                this.handleGeneralCaseSelection(sendingCaseId);
            }

            this.updateCurrentRoundInformation();
        }

        private static int getBriefcaseId(ContentControl selectedBriefCase)
        {
            var id = int.Parse((string) selectedBriefCase.Content ?? throw new InvalidOperationException());
            return id - 1;
        }

        private void disableSelectedCase(Button sendingButton)
        {
            if (sendingButton == null)
            {
                throw new ArgumentNullException(nameof(sendingButton));
            }

            sendingButton.IsEnabled = false;
            sendingButton.Visibility = Visibility.Collapsed;
        }

        private void handlePlayerCaseSelection(int sendingCaseId, ContentControl sendingButton)
        {
            this.manager.SetPlayerCaseId(sendingCaseId);
            this.summaryOutput.Text = "Your case: " + sendingButton.Content;
        }

        private void handleGeneralCaseSelection(int sendingCaseId)
        {
            this.findAndGrayOutGameDollarLabel(this.manager.FindBriefcaseAmountFromId(sendingCaseId));

            this.manager.RemoveBriefcaseFromPlay(sendingCaseId);
            this.manager.DecrementCasesLeftInRound();
        }

        private void updateCurrentRoundInformation()
        {
            if (this.manager.IsFinalRound())
            {
                this.handleFinalRoundSetup();
            }
            else
            {
                this.casesToOpenLabel.Text =
                    OutputFormatter.BuildCasesRemainingToOpenOutput(this.manager.CasesRemainingInRound);

                this.roundLabel.Text = OutputFormatter.BuildTotalCasesToOpenInRoundOutput(this.manager.CurrentRound,
                    this.manager.CasesToOpenInRound);

                if (this.manager.RoundHasEnded())
                {
                    this.endOfRoundSetup();
                }
            }
        }

        private void handleFinalRoundSetup()
        {
            var finalButton = (from briefcase in this.briefcaseButtons
                               where briefcase.Visibility != Visibility.Collapsed
                               select briefcase).ToArray();
            this.manager.SetFinalCaseId(getBriefcaseId(finalButton[0]));

            this.setupFinalCases();

            this.roundLabel.Text = "This is the final round.";
            this.casesToOpenLabel.Text = "Select a case.";
        }

        private void setupFinalCases()
        {
            var finalCaseIds = this.getSortedFinalCaseIds();
            var finalCaseButtons = finalCaseIds.Select(this.findButtonFromId).ToList();

            foreach (var button in finalCaseButtons)
            {
                var parentPanel = button.Parent as StackPanel;
                parentPanel?.Children.Remove(button);
                this.middleStackPanel.Children.Add(button);
                button.Visibility = Visibility.Visible;
            }
        }

        private IEnumerable<int> getSortedFinalCaseIds()
        {
            var finalCaseIds = new List<int> {this.manager.PlayerCaseId, this.manager.FinalCaseId};
            finalCaseIds.Sort();

            return finalCaseIds;
        }

        private void endOfRoundSetup()
        {
            this.disableAllCases();
            this.enableDealNoDealButtons();

            var offer = this.manager.GetOffer;
            this.manager.AddOffer(offer);

            this.summaryOutput.Text = OutputFormatter.BuildEndOfRoundOutput(this.manager.AllOffers);
        }

        private void findAndGrayOutGameDollarLabel(int amount)
        {
            foreach (var currentDollarAmountLabel in this.dollarAmountLabels)
            {
                if (grayOutLabelIfMatchesDollarAmount(amount, currentDollarAmountLabel))
                {
                    break;
                }
            }
        }

        private static bool grayOutLabelIfMatchesDollarAmount(int amount, Border currentDollarAmountLabel)
        {
            var matched = false;

            if (currentDollarAmountLabel.Child is TextBlock dollarTextBlock)
            {
                var labelAmount = int.Parse(dollarTextBlock.Text, NumberStyles.Currency);
                if (labelAmount == amount)
                {
                    currentDollarAmountLabel.Background = new SolidColorBrush(Colors.Gray);
                    matched = true;
                }
            }

            return matched;
        }

        private void disableAllCases()
        {
            foreach (var briefcase in this.briefcaseButtons)
            {
                briefcase.IsEnabled = false;
            }
        }

        private void enableDealNoDealButtons()
        {
            this.noDealButton.Visibility = Visibility.Visible;
            this.dealButton.Visibility = Visibility.Visible;
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            this.disableDealNoDealButtons();
            this.handleGameEnd(this.manager.CurrentOffer);
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {
            this.manager.MoveToNextRound();

            this.enableAllCases();
            this.disableDealNoDealButtons();

            this.summaryOutput.Text = OutputFormatter.BuildNoDealButtonOutput(this.manager.AllOffers);

            this.updateCurrentRoundInformation();
        }

        private void enableAllCases()
        {
            foreach (var briefcase in this.briefcaseButtons)
            {
                briefcase.IsEnabled = true;
            }
        }

        private async void handleGameEnd(int caseValue)
        {
            this.summaryOutput.Text = OutputFormatter.BuildFinalRoundEndGameOutput(caseValue);

            var result = await showGameEndContentDialog();

            if (result == ContentDialogResult.Primary)
            {
                restart();
            }
            else
            {
                closeGame();
            }
        }

        private static void closeGame()
        {
            Application.Current.Exit();
        }

        private static async Task<ContentDialogResult> showGameEndContentDialog()
        {
            var gameEndDialog = new ContentDialog {
                Title = "Congratulations!",
                Content = "Play again?",
                PrimaryButtonText = "Play Again",
                CloseButtonText = "Close"
            };
            var result = await gameEndDialog.ShowAsync();

            return result;
        }

        private static async void restart()
        {
            await CoreApplication.RequestRestartAsync("");
        }

        private Button findButtonFromId(int id)
        {
            var foundButton = (from button in this.briefcaseButtons
                               where button.Content != null && int.Parse(button.Content.ToString()) == id + 1
                               select button).ToList();

            return foundButton.First();
        }

        #endregion
    }
}