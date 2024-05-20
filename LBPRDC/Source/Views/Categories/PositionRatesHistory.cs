using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace LBPRDC.Source.Views.Categories
{
    public partial class PositionRatesHistory : Form
    {
        public string PositionCode { get; set; } = "";
        public string PositionName { get; set; } = "";
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

        private void PopulateBasicInformation()
        {
            txtID.Text = PositionID.ToString();
            txtName.Text = $"{PositionCode} - {PositionName}";
        }

        private async void PopulateTableInformation()
        {
            var historyList = await PositionService.GetRatesHistoryByID(PositionID);

            historyList[0].Indicator = ">";

            dgvHistory.DataSource = historyList;

            dgvHistory.Columns["ID"].Visible = false;
            dgvHistory.Columns["PositionID"].Visible = false;
            dgvHistory.Columns["Indicator"].HeaderText = "";
            dgvHistory.Columns["DailySalaryRate"].HeaderText = "Salary Rate (Daily)";
            dgvHistory.Columns["DailyBillingRate"].HeaderText = "Billing Rate (Daily)";
            dgvHistory.Columns["MonthlySalaryRate"].HeaderText = "Salary Rate (Monthly)";
            dgvHistory.Columns["MonthlyBillingRate"].HeaderText = "Billing Rate (Monthly)";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
