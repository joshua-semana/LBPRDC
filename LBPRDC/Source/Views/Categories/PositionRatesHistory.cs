using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.Categories
{
    public partial class PositionRatesHistory : Form
    {
        public int? PositionID { get; set; }

        public PositionRatesHistory()
        {
            InitializeComponent();
        }

        private void PositionRatesHistory_Load(object sender, EventArgs e)
        {
            if (PositionID != null)
            {
                PopulateBasicInformation();
                PopulateTableInformation();
            }
            else
            {
                MessageBox.Show("There seems to be a problem loading the data. Please try again.", "Error Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void PopulateBasicInformation()
        {
            var positionData = PositionService.GetAllItems().First(f => f.ID == PositionID);
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
