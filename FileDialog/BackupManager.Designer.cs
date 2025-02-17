namespace BackupTool
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Steuerelemente
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.TextBox textBoxSourceFolder;
        private System.Windows.Forms.Button buttonBrowseSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox textBoxDestinationFolder;
        private System.Windows.Forms.Button buttonBrowseDestination;
        private System.Windows.Forms.Label labelBackupType;
        private System.Windows.Forms.ComboBox comboBoxBackupType;
        private System.Windows.Forms.Label labelAutomation;
        private System.Windows.Forms.ComboBox comboBoxAutomation;
        private System.Windows.Forms.Button buttonBackupStart;
        private System.Windows.Forms.Button buttonStopAutomation;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSource = new System.Windows.Forms.Label();
            this.textBoxSourceFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseSource = new System.Windows.Forms.Button();
            this.labelDestination = new System.Windows.Forms.Label();
            this.textBoxDestinationFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseDestination = new System.Windows.Forms.Button();
            this.labelBackupType = new System.Windows.Forms.Label();
            this.comboBoxBackupType = new System.Windows.Forms.ComboBox();
            this.labelAutomation = new System.Windows.Forms.Label();
            this.comboBoxAutomation = new System.Windows.Forms.ComboBox();
            this.buttonBackupStart = new System.Windows.Forms.Button();
            this.buttonStopAutomation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(150, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(134, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Backup Tool";
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(30, 70);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(67, 13);
            this.labelSource.TabIndex = 1;
            this.labelSource.Text = "Quellordner:";
            // 
            // textBoxSourceFolder
            // 
            this.textBoxSourceFolder.Location = new System.Drawing.Point(30, 90);
            this.textBoxSourceFolder.Name = "textBoxSourceFolder";
            this.textBoxSourceFolder.Size = new System.Drawing.Size(400, 20);
            this.textBoxSourceFolder.TabIndex = 2;
            // 
            // buttonBrowseSource
            // 
            this.buttonBrowseSource.Location = new System.Drawing.Point(440, 88);
            this.buttonBrowseSource.Name = "buttonBrowseSource";
            this.buttonBrowseSource.Size = new System.Drawing.Size(100, 23);
            this.buttonBrowseSource.TabIndex = 3;
            this.buttonBrowseSource.Text = "Durchsuchen...";
            this.buttonBrowseSource.UseVisualStyleBackColor = true;
            this.buttonBrowseSource.Click += new System.EventHandler(this.buttonBrowseSource_Click);
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(30, 130);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(63, 13);
            this.labelDestination.TabIndex = 4;
            this.labelDestination.Text = "Zielordner:";
            // 
            // textBoxDestinationFolder
            // 
            this.textBoxDestinationFolder.Location = new System.Drawing.Point(30, 150);
            this.textBoxDestinationFolder.Name = "textBoxDestinationFolder";
            this.textBoxDestinationFolder.Size = new System.Drawing.Size(400, 20);
            this.textBoxDestinationFolder.TabIndex = 5;
            // 
            // buttonBrowseDestination
            // 
            this.buttonBrowseDestination.Location = new System.Drawing.Point(440, 148);
            this.buttonBrowseDestination.Name = "buttonBrowseDestination";
            this.buttonBrowseDestination.Size = new System.Drawing.Size(100, 23);
            this.buttonBrowseDestination.TabIndex = 6;
            this.buttonBrowseDestination.Text = "Durchsuchen...";
            this.buttonBrowseDestination.UseVisualStyleBackColor = true;
            this.buttonBrowseDestination.Click += new System.EventHandler(this.buttonBrowseDestination_Click);
            // 
            // labelBackupType
            // 
            this.labelBackupType.AutoSize = true;
            this.labelBackupType.Location = new System.Drawing.Point(30, 190);
            this.labelBackupType.Name = "labelBackupType";
            this.labelBackupType.Size = new System.Drawing.Size(64, 13);
            this.labelBackupType.TabIndex = 7;
            this.labelBackupType.Text = "Backup-Typ:";
            // 
            // comboBoxBackupType
            // 
            this.comboBoxBackupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBackupType.FormattingEnabled = true;
            this.comboBoxBackupType.Items.AddRange(new object[] {
            "Vollständig",
            "Inkrementell",
            "Differenziell",
            "Syncronisieren"});
            this.comboBoxBackupType.Location = new System.Drawing.Point(30, 210);
            this.comboBoxBackupType.Name = "comboBoxBackupType";
            this.comboBoxBackupType.Size = new System.Drawing.Size(200, 21);
            this.comboBoxBackupType.TabIndex = 8;
            // 
            // labelAutomation
            // 
            this.labelAutomation.AutoSize = true;
            this.labelAutomation.Location = new System.Drawing.Point(30, 250);
            this.labelAutomation.Name = "labelAutomation";
            this.labelAutomation.Size = new System.Drawing.Size(80, 13);
            this.labelAutomation.TabIndex = 9;
            this.labelAutomation.Text = "Automatisierung:";
            // 
            // comboBoxAutomation
            // 
            this.comboBoxAutomation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutomation.FormattingEnabled = true;
            this.comboBoxAutomation.Items.AddRange(new object[] {
            "Manuell",
            "Geplant",
            "Echtzeit"});
            this.comboBoxAutomation.Location = new System.Drawing.Point(30, 270);
            this.comboBoxAutomation.Name = "comboBoxAutomation";
            this.comboBoxAutomation.Size = new System.Drawing.Size(200, 21);
            this.comboBoxAutomation.TabIndex = 10;
            // 
            // buttonBackupStart
            // 
            this.buttonBackupStart.Location = new System.Drawing.Point(30, 310);
            this.buttonBackupStart.Name = "buttonBackupStart";
            this.buttonBackupStart.Size = new System.Drawing.Size(120, 30);
            this.buttonBackupStart.TabIndex = 11;
            this.buttonBackupStart.Text = "Backup starten";
            this.buttonBackupStart.UseVisualStyleBackColor = true;
            this.buttonBackupStart.Click += new System.EventHandler(this.buttonBackupStart_Click);
            // 
            // buttonStopAutomation
            // 
            this.buttonStopAutomation.Location = new System.Drawing.Point(170, 310);
            this.buttonStopAutomation.Name = "buttonStopAutomation";
            this.buttonStopAutomation.Size = new System.Drawing.Size(120, 30);
            this.buttonStopAutomation.TabIndex = 12;
            this.buttonStopAutomation.Text = "Automatisierung stoppen";
            this.buttonStopAutomation.UseVisualStyleBackColor = true;
            this.buttonStopAutomation.Click += new System.EventHandler(this.buttonStopAutomation_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(564, 361);
            this.Controls.Add(this.buttonStopAutomation);
            this.Controls.Add(this.buttonBackupStart);
            this.Controls.Add(this.comboBoxAutomation);
            this.Controls.Add(this.labelAutomation);
            this.Controls.Add(this.comboBoxBackupType);
            this.Controls.Add(this.labelBackupType);
            this.Controls.Add(this.buttonBrowseDestination);
            this.Controls.Add(this.textBoxDestinationFolder);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.buttonBrowseSource);
            this.Controls.Add(this.textBoxSourceFolder);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.labelTitle);
            this.Name = "Form1";
            this.Text = "Backup Tool";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
