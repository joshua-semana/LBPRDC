using LBPRDC.Source.Config;
using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.Categories
{
    public partial class PositionRatesHistory : Form
    {
        public int PositionID { get; set; } = -1;

        public PositionRatesHistory()
        {
            InitializeComponent();
        }

        private void PositionRatesHistory_Load(object sender, EventArgs e)
        {
            if (PositionID != -1)
            {
                PopulateBasicInformation();
                PopulateTableInformation();
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private async void PopulateBasicInformation()
        {
            var positions = await PositionService.GetAllItems();
            var positionData = positions.First(f => f.ID == PositionID);
            txtID.Text = positionData.ID.ToString();
            txtName.Text = $"{positionData.Code} - {positionData.Name}";
        }

        private void PopulateTableInformation()
        {
            var historyList = PositionService.GetRatesHistoryByID(PositionID);
            dgvHistory.DataSource = historyList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
