namespace LBPRDC.Source.Views.Billing
{
    partial class BillingControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlRight = new Panel();
            pnlRightBody = new Panel();
            flowRightContent = new FlowLayoutPanel();
            label2 = new Label();
            pnlLine2 = new Panel();
            lblID = new Label();
            txtCreationDate = new TextBox();
            label1 = new Label();
            txtReleaseDate = new TextBox();
            grpBillingInformation = new GroupBox();
            txtEquipmentIncludedStatus = new TextBox();
            txtSuppliesAndEquipmentsAmount = new TextBox();
            txtSuppliesAndEquipmentsAccount = new TextBox();
            label12 = new Label();
            btnUpdateBillingInformation = new Button();
            label5 = new Label();
            txtOICandPosition = new TextBox();
            label7 = new Label();
            txtDescription = new TextBox();
            grpStatementOfAccounts = new GroupBox();
            btnUpdateRemarks = new Button();
            btnRemoveAccount = new Button();
            btnAddAccount = new Button();
            grpPurpose = new GroupBox();
            btnForRebilling = new Button();
            btnForAdjustment = new Button();
            txtStatus = new TextBox();
            label11 = new Label();
            txtBalance = new TextBox();
            label10 = new Label();
            txtNetBilling = new TextBox();
            label9 = new Label();
            txtAccountRemarks = new TextBox();
            label8 = new Label();
            txtBilledValue = new TextBox();
            btnCollectAccount = new Button();
            label6 = new Label();
            txtAmountCollected = new TextBox();
            label4 = new Label();
            txtReceiptNumber = new TextBox();
            label3 = new Label();
            txtCollectionDate = new TextBox();
            cmbStatementOfAccounts = new ComboBox();
            btnViewAccountRecord = new Button();
            pnlRightFooter = new Panel();
            flowFooterActions = new FlowLayoutPanel();
            btnCloseDetails = new Button();
            btnDuplicateBilling = new Button();
            btnView = new Button();
            pnlVLine1 = new Panel();
            pnlLeft = new Panel();
            pnlLeftBody = new Panel();
            lblClient = new Label();
            cmbClient = new ComboBox();
            btnNew = new Button();
            btnSearch = new Button();
            pnlLine1 = new Panel();
            panel1 = new Panel();
            lblRowCounter = new Label();
            txtSearch = new TextBox();
            dgvBillings = new DataGridView();
            pnlLeftFooter = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            cntxtBillingActions = new ContextMenuStrip(components);
            cntxtMenuViewVerify = new ToolStripMenuItem();
            cntxtMenuDuplicate = new ToolStripMenuItem();
            cntxtMenuRelease = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cntxtMenuUpload = new ToolStripMenuItem();
            menuUploadTimekeep = new ToolStripMenuItem();
            menuUploadAccruals = new ToolStripMenuItem();
            cntxtMenuExport = new ToolStripMenuItem();
            menuExportBilling = new ToolStripMenuItem();
            menuExportBalancing = new ToolStripMenuItem();
            menuExportLetter = new ToolStripMenuItem();
            menuExportTransmittal = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            cntxtMenuArchive = new ToolStripMenuItem();
            pnlRight.SuspendLayout();
            pnlRightBody.SuspendLayout();
            flowRightContent.SuspendLayout();
            grpBillingInformation.SuspendLayout();
            grpStatementOfAccounts.SuspendLayout();
            grpPurpose.SuspendLayout();
            pnlRightFooter.SuspendLayout();
            flowFooterActions.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlLeftBody.SuspendLayout();
            pnlLine1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillings).BeginInit();
            pnlLeftFooter.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            cntxtBillingActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(pnlRightBody);
            pnlRight.Controls.Add(pnlRightFooter);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(763, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(450, 670);
            pnlRight.TabIndex = 0;
            pnlRight.Visible = false;
            // 
            // pnlRightBody
            // 
            pnlRightBody.AutoScroll = true;
            pnlRightBody.Controls.Add(flowRightContent);
            pnlRightBody.Dock = DockStyle.Fill;
            pnlRightBody.Location = new Point(0, 0);
            pnlRightBody.Name = "pnlRightBody";
            pnlRightBody.Size = new Size(450, 610);
            pnlRightBody.TabIndex = 1;
            // 
            // flowRightContent
            // 
            flowRightContent.AutoSize = true;
            flowRightContent.Controls.Add(label2);
            flowRightContent.Controls.Add(pnlLine2);
            flowRightContent.Controls.Add(lblID);
            flowRightContent.Controls.Add(txtCreationDate);
            flowRightContent.Controls.Add(label1);
            flowRightContent.Controls.Add(txtReleaseDate);
            flowRightContent.Controls.Add(grpBillingInformation);
            flowRightContent.Controls.Add(grpStatementOfAccounts);
            flowRightContent.FlowDirection = FlowDirection.TopDown;
            flowRightContent.Location = new Point(0, 0);
            flowRightContent.Margin = new Padding(0);
            flowRightContent.Name = "flowRightContent";
            flowRightContent.Padding = new Padding(24, 24, 0, 24);
            flowRightContent.Size = new Size(433, 1260);
            flowRightContent.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(24, 24);
            label2.Margin = new Padding(0, 0, 0, 16);
            label2.Name = "label2";
            label2.Size = new Size(391, 19);
            label2.TabIndex = 28;
            label2.Text = "DETAILS";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLine2
            // 
            pnlLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine2.BorderStyle = BorderStyle.FixedSingle;
            pnlLine2.Location = new Point(24, 59);
            pnlLine2.Margin = new Padding(0, 0, 0, 16);
            pnlLine2.Name = "pnlLine2";
            pnlLine2.Size = new Size(391, 1);
            pnlLine2.TabIndex = 10;
            // 
            // lblID
            // 
            lblID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblID.AutoSize = true;
            lblID.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblID.ForeColor = SystemColors.ControlText;
            lblID.Location = new Point(24, 76);
            lblID.Margin = new Padding(0, 0, 0, 8);
            lblID.Name = "lblID";
            lblID.Size = new Size(391, 16);
            lblID.TabIndex = 30;
            lblID.Text = "Creation Date";
            // 
            // txtCreationDate
            // 
            txtCreationDate.AccessibleName = "ID";
            txtCreationDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCreationDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCreationDate.Location = new Point(24, 100);
            txtCreationDate.Margin = new Padding(0, 0, 0, 12);
            txtCreationDate.MaxLength = 100;
            txtCreationDate.Name = "txtCreationDate";
            txtCreationDate.ReadOnly = true;
            txtCreationDate.Size = new Size(391, 26);
            txtCreationDate.TabIndex = 29;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(24, 138);
            label1.Margin = new Padding(0, 0, 0, 8);
            label1.Name = "label1";
            label1.Size = new Size(391, 16);
            label1.TabIndex = 32;
            label1.Text = "Release Date";
            // 
            // txtReleaseDate
            // 
            txtReleaseDate.AccessibleName = "ID";
            txtReleaseDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtReleaseDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtReleaseDate.Location = new Point(24, 162);
            txtReleaseDate.Margin = new Padding(0, 0, 0, 12);
            txtReleaseDate.MaxLength = 100;
            txtReleaseDate.Name = "txtReleaseDate";
            txtReleaseDate.ReadOnly = true;
            txtReleaseDate.Size = new Size(391, 26);
            txtReleaseDate.TabIndex = 31;
            // 
            // grpBillingInformation
            // 
            grpBillingInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBillingInformation.Controls.Add(txtEquipmentIncludedStatus);
            grpBillingInformation.Controls.Add(txtSuppliesAndEquipmentsAmount);
            grpBillingInformation.Controls.Add(txtSuppliesAndEquipmentsAccount);
            grpBillingInformation.Controls.Add(label12);
            grpBillingInformation.Controls.Add(btnUpdateBillingInformation);
            grpBillingInformation.Controls.Add(label5);
            grpBillingInformation.Controls.Add(txtOICandPosition);
            grpBillingInformation.Controls.Add(label7);
            grpBillingInformation.Controls.Add(txtDescription);
            grpBillingInformation.Location = new Point(24, 200);
            grpBillingInformation.Margin = new Padding(0, 0, 0, 12);
            grpBillingInformation.Name = "grpBillingInformation";
            grpBillingInformation.Padding = new Padding(16, 10, 16, 8);
            grpBillingInformation.Size = new Size(391, 266);
            grpBillingInformation.TabIndex = 11;
            grpBillingInformation.TabStop = false;
            grpBillingInformation.Text = "Billing Information";
            // 
            // txtEquipmentIncludedStatus
            // 
            txtEquipmentIncludedStatus.AccessibleName = "ID";
            txtEquipmentIncludedStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEquipmentIncludedStatus.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEquipmentIncludedStatus.Location = new Point(16, 178);
            txtEquipmentIncludedStatus.Margin = new Padding(0, 0, 0, 16);
            txtEquipmentIncludedStatus.MaxLength = 100;
            txtEquipmentIncludedStatus.Name = "txtEquipmentIncludedStatus";
            txtEquipmentIncludedStatus.ReadOnly = true;
            txtEquipmentIncludedStatus.Size = new Size(359, 26);
            txtEquipmentIncludedStatus.TabIndex = 52;
            // 
            // txtSuppliesAndEquipmentsAmount
            // 
            txtSuppliesAndEquipmentsAmount.AccessibleName = "ID";
            txtSuppliesAndEquipmentsAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSuppliesAndEquipmentsAmount.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSuppliesAndEquipmentsAmount.Location = new Point(317, 21);
            txtSuppliesAndEquipmentsAmount.Margin = new Padding(0, 0, 0, 16);
            txtSuppliesAndEquipmentsAmount.MaxLength = 100;
            txtSuppliesAndEquipmentsAmount.Name = "txtSuppliesAndEquipmentsAmount";
            txtSuppliesAndEquipmentsAmount.ReadOnly = true;
            txtSuppliesAndEquipmentsAmount.Size = new Size(58, 26);
            txtSuppliesAndEquipmentsAmount.TabIndex = 50;
            txtSuppliesAndEquipmentsAmount.Visible = false;
            // 
            // txtSuppliesAndEquipmentsAccount
            // 
            txtSuppliesAndEquipmentsAccount.AccessibleName = "ID";
            txtSuppliesAndEquipmentsAccount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSuppliesAndEquipmentsAccount.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSuppliesAndEquipmentsAccount.Location = new Point(254, 21);
            txtSuppliesAndEquipmentsAccount.Margin = new Padding(0, 0, 0, 16);
            txtSuppliesAndEquipmentsAccount.MaxLength = 100;
            txtSuppliesAndEquipmentsAccount.Name = "txtSuppliesAndEquipmentsAccount";
            txtSuppliesAndEquipmentsAccount.ReadOnly = true;
            txtSuppliesAndEquipmentsAccount.Size = new Size(61, 26);
            txtSuppliesAndEquipmentsAccount.TabIndex = 48;
            txtSuppliesAndEquipmentsAccount.Visible = false;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = SystemColors.ControlText;
            label12.Location = new Point(16, 154);
            label12.Margin = new Padding(0, 0, 0, 8);
            label12.Name = "label12";
            label12.Size = new Size(246, 16);
            label12.TabIndex = 49;
            label12.Text = "Is Supplies and Equipments included?";
            // 
            // btnUpdateBillingInformation
            // 
            btnUpdateBillingInformation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdateBillingInformation.AutoSize = true;
            btnUpdateBillingInformation.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateBillingInformation.Location = new Point(300, 219);
            btnUpdateBillingInformation.Margin = new Padding(8, 0, 0, 0);
            btnUpdateBillingInformation.Name = "btnUpdateBillingInformation";
            btnUpdateBillingInformation.Size = new Size(75, 28);
            btnUpdateBillingInformation.TabIndex = 47;
            btnUpdateBillingInformation.Tag = "Update";
            btnUpdateBillingInformation.Text = "Update";
            btnUpdateBillingInformation.UseVisualStyleBackColor = true;
            btnUpdateBillingInformation.Click += UpdateOrDuplicateBilling;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(16, 26);
            label5.Margin = new Padding(0, 0, 0, 8);
            label5.Name = "label5";
            label5.Size = new Size(78, 16);
            label5.TabIndex = 42;
            label5.Text = "Description";
            // 
            // txtOICandPosition
            // 
            txtOICandPosition.AccessibleName = "ID";
            txtOICandPosition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOICandPosition.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOICandPosition.Location = new Point(16, 112);
            txtOICandPosition.Margin = new Padding(0, 0, 0, 16);
            txtOICandPosition.MaxLength = 100;
            txtOICandPosition.Name = "txtOICandPosition";
            txtOICandPosition.ReadOnly = true;
            txtOICandPosition.Size = new Size(359, 26);
            txtOICandPosition.TabIndex = 43;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlText;
            label7.Location = new Point(16, 88);
            label7.Margin = new Padding(0, 0, 0, 8);
            label7.Name = "label7";
            label7.Size = new Size(236, 16);
            label7.TabIndex = 44;
            label7.Text = "Officer-in-charge Name and Position";
            // 
            // txtDescription
            // 
            txtDescription.AccessibleName = "ID";
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Location = new Point(16, 50);
            txtDescription.Margin = new Padding(0, 0, 0, 12);
            txtDescription.MaxLength = 100;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(359, 26);
            txtDescription.TabIndex = 41;
            // 
            // grpStatementOfAccounts
            // 
            grpStatementOfAccounts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpStatementOfAccounts.Controls.Add(btnUpdateRemarks);
            grpStatementOfAccounts.Controls.Add(btnRemoveAccount);
            grpStatementOfAccounts.Controls.Add(btnAddAccount);
            grpStatementOfAccounts.Controls.Add(grpPurpose);
            grpStatementOfAccounts.Controls.Add(label11);
            grpStatementOfAccounts.Controls.Add(txtBalance);
            grpStatementOfAccounts.Controls.Add(label10);
            grpStatementOfAccounts.Controls.Add(txtNetBilling);
            grpStatementOfAccounts.Controls.Add(label9);
            grpStatementOfAccounts.Controls.Add(txtAccountRemarks);
            grpStatementOfAccounts.Controls.Add(label8);
            grpStatementOfAccounts.Controls.Add(txtBilledValue);
            grpStatementOfAccounts.Controls.Add(btnCollectAccount);
            grpStatementOfAccounts.Controls.Add(label6);
            grpStatementOfAccounts.Controls.Add(txtAmountCollected);
            grpStatementOfAccounts.Controls.Add(label4);
            grpStatementOfAccounts.Controls.Add(txtReceiptNumber);
            grpStatementOfAccounts.Controls.Add(label3);
            grpStatementOfAccounts.Controls.Add(txtCollectionDate);
            grpStatementOfAccounts.Controls.Add(cmbStatementOfAccounts);
            grpStatementOfAccounts.Controls.Add(btnViewAccountRecord);
            grpStatementOfAccounts.Location = new Point(24, 478);
            grpStatementOfAccounts.Margin = new Padding(0);
            grpStatementOfAccounts.Name = "grpStatementOfAccounts";
            grpStatementOfAccounts.Padding = new Padding(16, 10, 16, 16);
            grpStatementOfAccounts.Size = new Size(391, 691);
            grpStatementOfAccounts.TabIndex = 40;
            grpStatementOfAccounts.TabStop = false;
            grpStatementOfAccounts.Text = "Statement of Accounts";
            // 
            // btnUpdateRemarks
            // 
            btnUpdateRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdateRemarks.AutoSize = true;
            btnUpdateRemarks.Enabled = false;
            btnUpdateRemarks.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateRemarks.Location = new Point(300, 484);
            btnUpdateRemarks.Margin = new Padding(4, 0, 4, 0);
            btnUpdateRemarks.Name = "btnUpdateRemarks";
            btnUpdateRemarks.Size = new Size(75, 28);
            btnUpdateRemarks.TabIndex = 57;
            btnUpdateRemarks.Text = "Set";
            btnUpdateRemarks.UseVisualStyleBackColor = true;
            btnUpdateRemarks.Click += btnUpdateRemarks_Click;
            // 
            // btnRemoveAccount
            // 
            btnRemoveAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveAccount.AutoSize = true;
            btnRemoveAccount.Enabled = false;
            btnRemoveAccount.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveAccount.Location = new Point(138, 527);
            btnRemoveAccount.Margin = new Padding(8, 0, 0, 0);
            btnRemoveAccount.Name = "btnRemoveAccount";
            btnRemoveAccount.Size = new Size(75, 28);
            btnRemoveAccount.TabIndex = 56;
            btnRemoveAccount.Text = "Remove";
            btnRemoveAccount.UseVisualStyleBackColor = true;
            btnRemoveAccount.Visible = false;
            // 
            // btnAddAccount
            // 
            btnAddAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddAccount.AutoSize = true;
            btnAddAccount.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddAccount.Location = new Point(221, 527);
            btnAddAccount.Margin = new Padding(8, 0, 0, 0);
            btnAddAccount.Name = "btnAddAccount";
            btnAddAccount.Size = new Size(75, 28);
            btnAddAccount.TabIndex = 55;
            btnAddAccount.Text = "Add";
            btnAddAccount.UseVisualStyleBackColor = true;
            btnAddAccount.Visible = false;
            btnAddAccount.Click += btnAddAccount_Click;
            // 
            // grpPurpose
            // 
            grpPurpose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpPurpose.Controls.Add(btnForRebilling);
            grpPurpose.Controls.Add(btnForAdjustment);
            grpPurpose.Controls.Add(txtStatus);
            grpPurpose.Location = new Point(16, 566);
            grpPurpose.Margin = new Padding(0);
            grpPurpose.Name = "grpPurpose";
            grpPurpose.Padding = new Padding(16, 10, 16, 8);
            grpPurpose.Size = new Size(359, 109);
            grpPurpose.TabIndex = 11;
            grpPurpose.TabStop = false;
            grpPurpose.Text = "Status";
            // 
            // btnForRebilling
            // 
            btnForRebilling.AutoSize = true;
            btnForRebilling.Enabled = false;
            btnForRebilling.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnForRebilling.Location = new Point(223, 62);
            btnForRebilling.Margin = new Padding(8, 0, 0, 0);
            btnForRebilling.Name = "btnForRebilling";
            btnForRebilling.Size = new Size(120, 28);
            btnForRebilling.TabIndex = 58;
            btnForRebilling.Text = "For re-billing";
            btnForRebilling.UseVisualStyleBackColor = true;
            // 
            // btnForAdjustment
            // 
            btnForAdjustment.AutoSize = true;
            btnForAdjustment.Enabled = false;
            btnForAdjustment.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnForAdjustment.Location = new Point(95, 62);
            btnForAdjustment.Margin = new Padding(8, 0, 0, 0);
            btnForAdjustment.Name = "btnForAdjustment";
            btnForAdjustment.Size = new Size(120, 28);
            btnForAdjustment.TabIndex = 57;
            btnForAdjustment.Text = "For adjustment";
            btnForAdjustment.UseVisualStyleBackColor = true;
            // 
            // txtStatus
            // 
            txtStatus.AccessibleName = "Status";
            txtStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtStatus.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtStatus.Location = new Point(16, 26);
            txtStatus.Margin = new Padding(0, 0, 0, 10);
            txtStatus.MaxLength = 100;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(327, 26);
            txtStatus.TabIndex = 56;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.ControlText;
            label11.Location = new Point(16, 395);
            label11.Margin = new Padding(0, 0, 0, 8);
            label11.Name = "label11";
            label11.Size = new Size(58, 16);
            label11.TabIndex = 53;
            label11.Text = "Balance";
            // 
            // txtBalance
            // 
            txtBalance.AccessibleName = "Balance";
            txtBalance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBalance.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBalance.Location = new Point(16, 419);
            txtBalance.Margin = new Padding(0, 0, 0, 16);
            txtBalance.MaxLength = 100;
            txtBalance.Name = "txtBalance";
            txtBalance.ReadOnly = true;
            txtBalance.Size = new Size(359, 26);
            txtBalance.TabIndex = 54;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ControlText;
            label10.Location = new Point(16, 131);
            label10.Margin = new Padding(0, 0, 0, 8);
            label10.Name = "label10";
            label10.Size = new Size(69, 16);
            label10.TabIndex = 51;
            label10.Text = "Net Billing";
            // 
            // txtNetBilling
            // 
            txtNetBilling.AccessibleName = "Billed Value";
            txtNetBilling.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNetBilling.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNetBilling.Location = new Point(16, 155);
            txtNetBilling.Margin = new Padding(0, 0, 0, 16);
            txtNetBilling.MaxLength = 100;
            txtNetBilling.Name = "txtNetBilling";
            txtNetBilling.ReadOnly = true;
            txtNetBilling.Size = new Size(359, 26);
            txtNetBilling.TabIndex = 52;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(16, 461);
            label9.Margin = new Padding(0, 0, 0, 8);
            label9.Name = "label9";
            label9.Size = new Size(63, 16);
            label9.TabIndex = 49;
            label9.Text = "Remarks";
            // 
            // txtAccountRemarks
            // 
            txtAccountRemarks.AccessibleName = "Remarks";
            txtAccountRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAccountRemarks.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAccountRemarks.Location = new Point(16, 485);
            txtAccountRemarks.Margin = new Padding(0, 0, 0, 16);
            txtAccountRemarks.MaxLength = 100;
            txtAccountRemarks.Name = "txtAccountRemarks";
            txtAccountRemarks.ReadOnly = true;
            txtAccountRemarks.Size = new Size(280, 26);
            txtAccountRemarks.TabIndex = 50;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlText;
            label8.Location = new Point(16, 65);
            label8.Margin = new Padding(0, 0, 0, 8);
            label8.Name = "label8";
            label8.Size = new Size(80, 16);
            label8.TabIndex = 47;
            label8.Text = "Billed Value";
            // 
            // txtBilledValue
            // 
            txtBilledValue.AccessibleName = "Billed Value";
            txtBilledValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBilledValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBilledValue.Location = new Point(16, 89);
            txtBilledValue.Margin = new Padding(0, 0, 0, 16);
            txtBilledValue.MaxLength = 100;
            txtBilledValue.Name = "txtBilledValue";
            txtBilledValue.ReadOnly = true;
            txtBilledValue.Size = new Size(359, 26);
            txtBilledValue.TabIndex = 48;
            // 
            // btnCollectAccount
            // 
            btnCollectAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCollectAccount.AutoSize = true;
            btnCollectAccount.Enabled = false;
            btnCollectAccount.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCollectAccount.Location = new Point(300, 527);
            btnCollectAccount.Margin = new Padding(4, 0, 4, 0);
            btnCollectAccount.Name = "btnCollectAccount";
            btnCollectAccount.Size = new Size(75, 28);
            btnCollectAccount.TabIndex = 46;
            btnCollectAccount.Text = "Collect";
            btnCollectAccount.UseVisualStyleBackColor = true;
            btnCollectAccount.Click += btnUpdateAccount_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(16, 329);
            label6.Margin = new Padding(0, 0, 0, 8);
            label6.Name = "label6";
            label6.Size = new Size(118, 16);
            label6.TabIndex = 44;
            label6.Text = "Amount Collected";
            // 
            // txtAmountCollected
            // 
            txtAmountCollected.AccessibleName = "Amount Collected";
            txtAmountCollected.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAmountCollected.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAmountCollected.Location = new Point(16, 353);
            txtAmountCollected.Margin = new Padding(0, 0, 0, 16);
            txtAmountCollected.MaxLength = 100;
            txtAmountCollected.Name = "txtAmountCollected";
            txtAmountCollected.ReadOnly = true;
            txtAmountCollected.Size = new Size(359, 26);
            txtAmountCollected.TabIndex = 45;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(16, 263);
            label4.Margin = new Padding(0, 0, 0, 8);
            label4.Name = "label4";
            label4.Size = new Size(155, 16);
            label4.TabIndex = 42;
            label4.Text = "Official Receipt Number";
            // 
            // txtReceiptNumber
            // 
            txtReceiptNumber.AccessibleName = "Official Receipt Number";
            txtReceiptNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtReceiptNumber.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtReceiptNumber.Location = new Point(16, 287);
            txtReceiptNumber.Margin = new Padding(0, 0, 0, 16);
            txtReceiptNumber.MaxLength = 100;
            txtReceiptNumber.Name = "txtReceiptNumber";
            txtReceiptNumber.ReadOnly = true;
            txtReceiptNumber.Size = new Size(359, 26);
            txtReceiptNumber.TabIndex = 43;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(16, 197);
            label3.Margin = new Padding(0, 0, 0, 8);
            label3.Name = "label3";
            label3.Size = new Size(100, 16);
            label3.TabIndex = 41;
            label3.Text = "Collected Date";
            // 
            // txtCollectionDate
            // 
            txtCollectionDate.AccessibleName = "Collected Date";
            txtCollectionDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCollectionDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCollectionDate.Location = new Point(16, 221);
            txtCollectionDate.Margin = new Padding(0, 0, 0, 16);
            txtCollectionDate.MaxLength = 100;
            txtCollectionDate.Name = "txtCollectionDate";
            txtCollectionDate.ReadOnly = true;
            txtCollectionDate.Size = new Size(359, 26);
            txtCollectionDate.TabIndex = 41;
            // 
            // cmbStatementOfAccounts
            // 
            cmbStatementOfAccounts.AccessibleName = "Department";
            cmbStatementOfAccounts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatementOfAccounts.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStatementOfAccounts.FormattingEnabled = true;
            cmbStatementOfAccounts.Location = new Point(16, 27);
            cmbStatementOfAccounts.Margin = new Padding(0, 0, 0, 12);
            cmbStatementOfAccounts.Name = "cmbStatementOfAccounts";
            cmbStatementOfAccounts.Size = new Size(280, 26);
            cmbStatementOfAccounts.TabIndex = 36;
            cmbStatementOfAccounts.SelectedIndexChanged += cmbStatementOfAccounts_SelectedIndexChanged;
            // 
            // btnViewAccountRecord
            // 
            btnViewAccountRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewAccountRecord.AutoSize = true;
            btnViewAccountRecord.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewAccountRecord.Location = new Point(300, 26);
            btnViewAccountRecord.Margin = new Padding(4, 0, 0, 0);
            btnViewAccountRecord.Name = "btnViewAccountRecord";
            btnViewAccountRecord.Size = new Size(75, 28);
            btnViewAccountRecord.TabIndex = 39;
            btnViewAccountRecord.Text = "View";
            btnViewAccountRecord.UseVisualStyleBackColor = true;
            btnViewAccountRecord.Click += btnViewAccountRecord_Click;
            // 
            // pnlRightFooter
            // 
            pnlRightFooter.BackColor = SystemColors.Control;
            pnlRightFooter.Controls.Add(flowFooterActions);
            pnlRightFooter.Dock = DockStyle.Bottom;
            pnlRightFooter.Location = new Point(0, 610);
            pnlRightFooter.Name = "pnlRightFooter";
            pnlRightFooter.Size = new Size(450, 60);
            pnlRightFooter.TabIndex = 0;
            // 
            // flowFooterActions
            // 
            flowFooterActions.Controls.Add(btnCloseDetails);
            flowFooterActions.Controls.Add(btnDuplicateBilling);
            flowFooterActions.Dock = DockStyle.Right;
            flowFooterActions.FlowDirection = FlowDirection.RightToLeft;
            flowFooterActions.Location = new Point(233, 0);
            flowFooterActions.Name = "flowFooterActions";
            flowFooterActions.Padding = new Padding(15, 16, 0, 16);
            flowFooterActions.Size = new Size(217, 60);
            flowFooterActions.TabIndex = 4;
            // 
            // btnCloseDetails
            // 
            btnCloseDetails.AutoSize = true;
            btnCloseDetails.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCloseDetails.Location = new Point(127, 16);
            btnCloseDetails.Margin = new Padding(8, 0, 0, 0);
            btnCloseDetails.Name = "btnCloseDetails";
            btnCloseDetails.Size = new Size(75, 28);
            btnCloseDetails.TabIndex = 40;
            btnCloseDetails.Text = "Close";
            btnCloseDetails.UseVisualStyleBackColor = true;
            btnCloseDetails.Click += btnCloseDetails_Click;
            // 
            // btnDuplicateBilling
            // 
            btnDuplicateBilling.AutoSize = true;
            btnDuplicateBilling.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDuplicateBilling.Location = new Point(43, 16);
            btnDuplicateBilling.Margin = new Padding(8, 0, 0, 0);
            btnDuplicateBilling.Name = "btnDuplicateBilling";
            btnDuplicateBilling.Size = new Size(76, 28);
            btnDuplicateBilling.TabIndex = 41;
            btnDuplicateBilling.Tag = "Duplicate";
            btnDuplicateBilling.Text = "Duplicate";
            btnDuplicateBilling.UseVisualStyleBackColor = true;
            btnDuplicateBilling.Click += UpdateOrDuplicateBilling;
            // 
            // btnView
            // 
            btnView.AutoSize = true;
            btnView.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnView.Location = new Point(363, 16);
            btnView.Margin = new Padding(8, 0, 0, 0);
            btnView.Name = "btnView";
            btnView.Size = new Size(93, 28);
            btnView.TabIndex = 8;
            btnView.Text = "View Details";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // pnlVLine1
            // 
            pnlVLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlVLine1.Dock = DockStyle.Right;
            pnlVLine1.Location = new Point(762, 0);
            pnlVLine1.Name = "pnlVLine1";
            pnlVLine1.Size = new Size(1, 670);
            pnlVLine1.TabIndex = 1;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(pnlLeftBody);
            pnlLeft.Controls.Add(pnlLeftFooter);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(762, 670);
            pnlLeft.TabIndex = 2;
            // 
            // pnlLeftBody
            // 
            pnlLeftBody.Controls.Add(lblClient);
            pnlLeftBody.Controls.Add(cmbClient);
            pnlLeftBody.Controls.Add(btnNew);
            pnlLeftBody.Controls.Add(btnSearch);
            pnlLeftBody.Controls.Add(pnlLine1);
            pnlLeftBody.Controls.Add(lblRowCounter);
            pnlLeftBody.Controls.Add(txtSearch);
            pnlLeftBody.Controls.Add(dgvBillings);
            pnlLeftBody.Dock = DockStyle.Fill;
            pnlLeftBody.Location = new Point(0, 0);
            pnlLeftBody.Name = "pnlLeftBody";
            pnlLeftBody.Padding = new Padding(24, 24, 24, 10);
            pnlLeftBody.Size = new Size(762, 610);
            pnlLeftBody.TabIndex = 1;
            pnlLeftBody.EnabledChanged += pnlLeftBody_EnabledChanged;
            // 
            // lblClient
            // 
            lblClient.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblClient.AutoSize = true;
            lblClient.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblClient.ForeColor = Color.Black;
            lblClient.Location = new Point(24, 29);
            lblClient.Margin = new Padding(3, 0, 3, 2);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(48, 16);
            lblClient.TabIndex = 27;
            lblClient.Text = "Client";
            // 
            // cmbClient
            // 
            cmbClient.AccessibleName = "Client";
            cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClient.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(81, 24);
            cmbClient.Margin = new Padding(6, 3, 3, 12);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(216, 26);
            cmbClient.TabIndex = 26;
            cmbClient.SelectedIndexChanged += cmbClient_SelectedIndexChanged;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNew.AutoSize = true;
            btnNew.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnNew.Location = new Point(660, 23);
            btnNew.Margin = new Padding(8, 0, 0, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 28);
            btnNew.TabIndex = 8;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(531, 23);
            btnSearch.Margin = new Padding(4, 0, 8, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 28);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // pnlLine1
            // 
            pnlLine1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLine1.BorderStyle = BorderStyle.FixedSingle;
            pnlLine1.Controls.Add(panel1);
            pnlLine1.Location = new Point(24, 66);
            pnlLine1.Margin = new Padding(0, 0, 0, 16);
            pnlLine1.Name = "pnlLine1";
            pnlLine1.Size = new Size(710, 1);
            pnlLine1.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(-1, 0);
            panel1.Margin = new Padding(0, 0, 0, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(706, 1);
            panel1.TabIndex = 10;
            // 
            // lblRowCounter
            // 
            lblRowCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRowCounter.AutoSize = true;
            lblRowCounter.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblRowCounter.ForeColor = SystemColors.GrayText;
            lblRowCounter.Location = new Point(20, 584);
            lblRowCounter.Margin = new Padding(0, 8, 0, 0);
            lblRowCounter.Name = "lblRowCounter";
            lblRowCounter.Size = new Size(45, 16);
            lblRowCounter.TabIndex = 1;
            lblRowCounter.Text = "Count";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(308, 24);
            txtSearch.Margin = new Padding(0, 0, 4, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(215, 26);
            txtSearch.TabIndex = 1;
            txtSearch.KeyUp += txtSearch_KeyUp;
            // 
            // dgvBillings
            // 
            dgvBillings.AllowUserToAddRows = false;
            dgvBillings.AllowUserToDeleteRows = false;
            dgvBillings.AllowUserToOrderColumns = true;
            dgvBillings.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dgvBillings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBillings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBillings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBillings.BackgroundColor = SystemColors.Window;
            dgvBillings.BorderStyle = BorderStyle.Fixed3D;
            dgvBillings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBillings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBillings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBillings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillings.EditMode = DataGridViewEditMode.EditOnF2;
            dgvBillings.GridColor = SystemColors.Control;
            dgvBillings.Location = new Point(24, 83);
            dgvBillings.Margin = new Padding(0);
            dgvBillings.MultiSelect = false;
            dgvBillings.Name = "dgvBillings";
            dgvBillings.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvBillings.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvBillings.RowHeadersVisible = false;
            dgvBillings.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvBillings.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvBillings.RowTemplate.Height = 41;
            dgvBillings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillings.Size = new Size(710, 493);
            dgvBillings.TabIndex = 4;
            dgvBillings.VirtualMode = true;
            dgvBillings.CellMouseClick += dgvBillings_CellMouseClick;
            dgvBillings.SelectionChanged += dgvBillings_SelectionChanged;
            // 
            // pnlLeftFooter
            // 
            pnlLeftFooter.BackColor = SystemColors.Control;
            pnlLeftFooter.Controls.Add(flowLayoutPanel1);
            pnlLeftFooter.Dock = DockStyle.Bottom;
            pnlLeftFooter.Location = new Point(0, 610);
            pnlLeftFooter.Name = "pnlLeftFooter";
            pnlLeftFooter.Size = new Size(762, 60);
            pnlLeftFooter.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnView);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(283, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(23, 16, 0, 16);
            flowLayoutPanel1.Size = new Size(479, 60);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // cntxtBillingActions
            // 
            cntxtBillingActions.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cntxtBillingActions.Items.AddRange(new ToolStripItem[] { cntxtMenuViewVerify, cntxtMenuDuplicate, cntxtMenuRelease, toolStripSeparator1, cntxtMenuUpload, cntxtMenuExport, toolStripSeparator2, cntxtMenuArchive });
            cntxtBillingActions.Name = "cntxtBillingActions";
            cntxtBillingActions.Size = new Size(181, 170);
            // 
            // cntxtMenuViewVerify
            // 
            cntxtMenuViewVerify.Name = "cntxtMenuViewVerify";
            cntxtMenuViewVerify.Size = new Size(180, 22);
            cntxtMenuViewVerify.Text = "View/Adjust";
            cntxtMenuViewVerify.Click += cntxtMenuViewVerify_Click;
            // 
            // cntxtMenuDuplicate
            // 
            cntxtMenuDuplicate.Name = "cntxtMenuDuplicate";
            cntxtMenuDuplicate.Size = new Size(180, 22);
            cntxtMenuDuplicate.Text = "Duplicate";
            cntxtMenuDuplicate.Visible = false;
            // 
            // cntxtMenuRelease
            // 
            cntxtMenuRelease.Name = "cntxtMenuRelease";
            cntxtMenuRelease.Size = new Size(180, 22);
            cntxtMenuRelease.Text = "Release";
            cntxtMenuRelease.Click += cntxtMenuRelease_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // cntxtMenuUpload
            // 
            cntxtMenuUpload.DropDownItems.AddRange(new ToolStripItem[] { menuUploadTimekeep, menuUploadAccruals });
            cntxtMenuUpload.Name = "cntxtMenuUpload";
            cntxtMenuUpload.Size = new Size(180, 22);
            cntxtMenuUpload.Text = "Upload";
            // 
            // menuUploadTimekeep
            // 
            menuUploadTimekeep.Name = "menuUploadTimekeep";
            menuUploadTimekeep.Size = new Size(152, 22);
            menuUploadTimekeep.Text = "Timekeep File";
            menuUploadTimekeep.Click += menuUploadTimekeep_Click;
            // 
            // menuUploadAccruals
            // 
            menuUploadAccruals.Name = "menuUploadAccruals";
            menuUploadAccruals.Size = new Size(152, 22);
            menuUploadAccruals.Text = "Accruals File";
            menuUploadAccruals.Click += menuUploadAccruals_Click;
            // 
            // cntxtMenuExport
            // 
            cntxtMenuExport.DropDownItems.AddRange(new ToolStripItem[] { menuExportBilling, menuExportBalancing, menuExportLetter, menuExportTransmittal });
            cntxtMenuExport.Name = "cntxtMenuExport";
            cntxtMenuExport.Size = new Size(180, 22);
            cntxtMenuExport.Text = "Export";
            // 
            // menuExportBilling
            // 
            menuExportBilling.Name = "menuExportBilling";
            menuExportBilling.Size = new Size(198, 22);
            menuExportBilling.Text = "Billing Register Report";
            menuExportBilling.Click += menuExportBilling_Click;
            // 
            // menuExportBalancing
            // 
            menuExportBalancing.Name = "menuExportBalancing";
            menuExportBalancing.Size = new Size(198, 22);
            menuExportBalancing.Text = "Balancing Report";
            menuExportBalancing.Click += menuExportBalancing_Click;
            // 
            // menuExportLetter
            // 
            menuExportLetter.Name = "menuExportLetter";
            menuExportLetter.Size = new Size(198, 22);
            menuExportLetter.Text = "Billing Letter";
            // 
            // menuExportTransmittal
            // 
            menuExportTransmittal.Name = "menuExportTransmittal";
            menuExportTransmittal.Size = new Size(198, 22);
            menuExportTransmittal.Text = "Transmittal Report";
            menuExportTransmittal.Click += menuExportTransmittal_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // cntxtMenuArchive
            // 
            cntxtMenuArchive.Name = "cntxtMenuArchive";
            cntxtMenuArchive.Size = new Size(180, 22);
            cntxtMenuArchive.Text = "Archive";
            cntxtMenuArchive.Click += cntxtMenuArchive_Click;
            // 
            // BillingControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(pnlLeft);
            Controls.Add(pnlVLine1);
            Controls.Add(pnlRight);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "BillingControl";
            Size = new Size(1213, 670);
            VisibleChanged += BillingControl_VisibleChanged;
            pnlRight.ResumeLayout(false);
            pnlRightBody.ResumeLayout(false);
            pnlRightBody.PerformLayout();
            flowRightContent.ResumeLayout(false);
            flowRightContent.PerformLayout();
            grpBillingInformation.ResumeLayout(false);
            grpBillingInformation.PerformLayout();
            grpStatementOfAccounts.ResumeLayout(false);
            grpStatementOfAccounts.PerformLayout();
            grpPurpose.ResumeLayout(false);
            grpPurpose.PerformLayout();
            pnlRightFooter.ResumeLayout(false);
            flowFooterActions.ResumeLayout(false);
            flowFooterActions.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeftBody.ResumeLayout(false);
            pnlLeftBody.PerformLayout();
            pnlLine1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBillings).EndInit();
            pnlLeftFooter.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            cntxtBillingActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRight;
        private Panel pnlVLine1;
        private Panel pnlLeft;
        private Panel pnlRightFooter;
        private Panel pnlLeftFooter;
        private FlowLayoutPanel flowFooterActions;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnNew;
        private DataGridView dgvBillings;
        private Panel pnlLeftBody;
        private TextBox txtSearch;
        private Label lblRowCounter;
        private Panel pnlLine1;
        private Button btnSearch;
        private Button btnUpload;
        private Button btnVerify;
        private Button btnArchive;
        private Button btnExport;
        private ContextMenuStrip cntxtBillingActions;
        private ToolStripMenuItem cntxtMenuViewVerify;
        private ToolStripMenuItem cntxtMenuUpload;
        private ToolStripMenuItem menuUploadTimekeep;
        private ToolStripMenuItem menuUploadAccruals;
        private ToolStripMenuItem cntxtMenuExport;
        private ToolStripMenuItem menuExportBilling;
        private ToolStripMenuItem menuExportBalancing;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem archiveToolStripMenuItem;
        private ToolStripMenuItem cntxtMenuArchive;
        private ToolStripMenuItem lockToolStripMenuItem;
        private ToolStripMenuItem billingLetterToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem menuExportLetter;
        private Panel pnlRightBody;
        private Panel pnlLine2;
        private Panel panel1;
        private Label label2;
        private TextBox txtCreationDate;
        private Label lblID;
        private Label label1;
        private TextBox txtReleaseDate;
        private Button btnViewAccountInformation;
        private Button btnCloseDetails;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox txtCollectionDate;
        private Label label6;
        private TextBox txtAmountCollected;
        private Label label4;
        private TextBox txtReceiptNumber;
        private ToolStripMenuItem cntxtMenuRelease;
        private Button btnCollectAccount;
        private ToolStripMenuItem cntxtMenuDuplicate;
        private Label label5;
        private TextBox txtDescription;
        private FlowLayoutPanel flowRightContent;
        private Label label7;
        private TextBox txtOICandPosition;
        private GroupBox groupBox2;
        private Button btnUpdateBillingInformation;
        private Label label8;
        private TextBox txtBilledValue;
        private Label label9;
        private TextBox txtAccountRemarks;
        private Button btnViewAccountRecord;
        public ComboBox cmbStatementOfAccounts;
        private Label label10;
        private TextBox txtNetBilling;
        private GroupBox grpBillingInformation;
        private GroupBox grpStatementOfAccounts;
        private Label label11;
        private TextBox txtBalance;
        private TextBox txtStatus;
        private GroupBox grpPurpose;
        private Button btnForRebilling;
        private Button btnForAdjustment;
        private ToolStripMenuItem menuExportTransmittal;
        private Button btnAddAccount;
        private Button btnRemoveAccount;
        public Button btnView;
        private TextBox txtSuppliesAndEquipmentsAmount;
        private Label label12;
        private TextBox txtSuppliesAndEquipmentsAccount;
        private Label label13;
        private Button btnUpdateRemarks;
        private ComboBox cmbClient;
        private Label lblClient;
        private TextBox txtEquipmentIncludedStatus;
        private Button btnDuplicateBilling;
    }
}
