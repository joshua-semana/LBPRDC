using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views
{
    public partial class PayFrequencyForm : Form
    {
        public int PayFrequencyID = 0;

        public PayFrequencyForm()
        {
            InitializeComponent();
        }

        private async void PayFrequencyForm_Load(object sender, EventArgs e)
        {
            var payFrequencies = await PayFrequencyService.GetAllItems();

            if (!payFrequencies.Any())
            {
                MessageBox.Show("Unable to get pay frequencies. Please call an administrator to setup pay frequencies for this system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var clients = await ClientService.GetItems();

            var isFirstRadioButton = true;

            foreach (var payFrequency in payFrequencies)
            {
                RadioButton radioButton = new()
                {
                    Tag = payFrequency.ID,
                    Text = payFrequency.Name,
                    Font = new Font(this.Font, FontStyle.Bold),
                    AutoSize = true
                };

                radioButton.Click += new EventHandler(RadioButton_Click);

                flowPayFrequencies.Controls.Add(radioButton);

                if (isFirstRadioButton)
                {
                    radioButton.PerformClick();
                    radioButton.Checked = true;
                    isFirstRadioButton = false;
                }

                var clientList = clients
                    .Where(w => w.PayFrequencyID == payFrequency.ID)
                    .Select(s => s.Name)
                    .ToList();

                if (!clientList.Any()) continue;

                Label lbl = new()
                {
                    Text = $"Clients: {string.Join(", ", clientList)}.",
                    AutoSize = true,
                    AutoEllipsis = true
                };
                flowPayFrequencies.Controls.Add(lbl);
            }
        }

        private void RadioButton_Click(object? sender, EventArgs e)
        {
            if (sender is not RadioButton radioButton)
            {
                PayFrequencyID = 0;
                return;
            }

            PayFrequencyID = Convert.ToInt32(radioButton.Tag);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            PayFrequencyService.SetPayFrequencyID(PayFrequencyID);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
