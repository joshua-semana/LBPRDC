using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LBPRDC.Source.Views
{
    public partial class frmServerSetup : Form
    {
        public frmServerSetup()
        {
            InitializeComponent();
        }

        private void frmServerSetup_Load(object sender, EventArgs e)
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["DbConnection"];

            if (connectionStringSettings != null)
            {
                string connection = connectionStringSettings.ConnectionString;
                string serverName = new SqlConnectionStringBuilder(connection).DataSource;
                string databaseName = new SqlConnectionStringBuilder(connection).InitialCatalog;
                string userId = new SqlConnectionStringBuilder(connection).UserID;
                string password = new SqlConnectionStringBuilder(connection).Password;

                txtServerName.Text = serverName;
                txtDatabaseName.Text = databaseName;
                txtUserID.Text = userId;
                txtPassword.Text = password;
            }
        }

        private async Task<bool> CheckSqlConnectionAsync(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return Services.ExceptionHandler.HandleException(ex);
                }
            }
        }

        private async void btnTestConnection_Click(object sender, EventArgs e)
        {
            string serverName = txtServerName.Text;
            string databaseName = txtDatabaseName.Text;
            string userId = txtUserID.Text;
            string password = txtPassword.Text;

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userId};Password={password};";

            btnAction.Enabled = false;
            btnTestConnection.Enabled = false;
            btnTestConnection.Text = "Checking...";

            bool isConnected = await CheckSqlConnectionAsync(connectionString);

            if (isConnected)
            {
                MessageBox.Show("Connection successful.", "Connection Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnAction.Enabled = true;
            btnTestConnection.Enabled = true;
            btnTestConnection.Text = "Test Connection";
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (IsUserAdministrator())
            {
                Utilities.ControlUtils.ToggleInputState(grpControls);

                btnAction.Text = (btnAction.Text == "Edit") ? "Cancel" : "Edit";
                btnApply.Enabled = (btnAction.Text == "Cancel");
                btnTestConnection.Enabled = (btnAction.Text == "Edit");
            }
            else
            {
                DialogResult result = MessageBox.Show("To perform this action, this software requires administrator privileges. " +
                    "Do you want to restart this software with administrator privileges?", "Administrator Privileges Required", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    RunAsAdmin();
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            UpdateAppConfig();
            MessageBox.Show("Settings saved successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Utilities.ControlUtils.ToggleInputState(grpControls);

            btnAction.Text = "Edit";
            btnApply.Enabled = false;
            btnTestConnection.Enabled = true;
        }

        private void UpdateAppConfig()
        {
            string serverName = txtServerName.Text;
            string databaseName = txtDatabaseName.Text;
            string userId = txtUserID.Text;
            string password = txtPassword.Text;

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringSettings = config.ConnectionStrings.ConnectionStrings["DbConnection"];

            if (connectionStringSettings != null)
            {
                connectionStringSettings.ConnectionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userId};Password={password};";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        private bool IsUserAdministrator()
        {
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(user);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RunAsAdmin()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Application.ExecutablePath,
                Verb = "runas"
            };

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            Application.Exit();
        }
    }
}
