using System.Windows.Forms;
using System.Drawing;

namespace FileDialog
{
    partial class TaskCreator
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            name = new TextBox();
            interval = new TextBox();
            actionButton = new Button();
            actionDialog = new OpenFileDialog();
            date = new DateTimePicker();
            priority = new ComboBox();
            isRecurring = new CheckBox();
            units = new ComboBox();
            filePath = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // name
            // 
            name.Location = new Point(7, 7);
            name.Name = "name";
            name.Size = new Size(323, 23);
            name.TabIndex = 0;
            name.Text = "Name";
            name.TextChanged += Name_TextChanged;
            // 
            // interval
            // 
            interval.Enabled = false;
            interval.Location = new Point(130, 124);
            interval.Name = "interval";
            interval.Size = new Size(116, 23);
            interval.TabIndex = 0;
            interval.TextChanged += Interval_TextChanged;
            // 
            // actionButton
            // 
            actionButton.FlatStyle = FlatStyle.Flat;
            actionButton.Location = new Point(230, 40);
            actionButton.Name = "actionButton";
            actionButton.Size = new Size(100, 25);
            actionButton.TabIndex = 0;
            actionButton.Text = "Auswählen";
            actionButton.MouseClick += ActionButton_MouseClick;
            // 
            // date
            // 
            date.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            date.Format = DateTimePickerFormat.Custom;
            date.Location = new Point(150, 90);
            date.Name = "date";
            date.Size = new Size(180, 23);
            date.TabIndex = 0;
            date.ValueChanged += DateTime_ValueChanged;
            // 
            // priority
            // 
            priority.DropDownStyle = ComboBoxStyle.DropDownList;
            priority.Location = new Point(7, 90);
            priority.Name = "priority";
            priority.Size = new Size(121, 23);
            priority.TabIndex = 0;
            priority.DropDown += Priority_DropDown;
            priority.SelectedIndexChanged += Priority_SelectedIndexChanged;
            // 
            // isRecurring
            // 
            isRecurring.Font = new Font("Segoe UI", 8F);
            isRecurring.Location = new Point(7, 124);
            isRecurring.Name = "isRecurring";
            isRecurring.Size = new Size(104, 24);
            isRecurring.TabIndex = 0;
            isRecurring.Text = "wiederkehrend";
            isRecurring.MouseClick += IsRecurring_MouseClick;
            // 
            // units
            // 
            units.DropDownStyle = ComboBoxStyle.DropDownList;
            units.Enabled = false;
            units.Location = new Point(244, 124);
            units.Name = "units";
            units.Size = new Size(86, 23);
            units.TabIndex = 1;
            units.DropDown += Units_DropDown;
            units.SelectedIndexChanged += Units_SelectedIndexChanged;
            // 
            // filePath
            // 
            filePath.Location = new Point(7, 41);
            filePath.Name = "filePath";
            filePath.ReadOnly = true;
            filePath.Size = new Size(208, 23);
            filePath.TabIndex = 2;
            filePath.Text = "Dateipfad";
            filePath.TextChanged += FilePath_TextChanged;
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Location = new Point(215, 176);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 3;
            saveButton.Text = "Speichern";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.MouseClick += SaveButton_MouseClick;
            // 
            // cancelButton
            // 
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point(47, 176);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Abbrechen";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.MouseClick += CancelButton_MouseClick;
            // 
            // TaskCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 219);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(filePath);
            Controls.Add(units);
            Controls.Add(name);
            Controls.Add(actionButton);
            Controls.Add(interval);
            Controls.Add(priority);
            Controls.Add(isRecurring);
            Controls.Add(date);
            Margin = new Padding(0);
            Name = "TaskCreator";
            Text = "Task erstellen";
            ResumeLayout(false);
            PerformLayout();
        }

        #region Deklarierung der Components
        private TextBox name;
        private TextBox interval;
        private Button actionButton;
        private OpenFileDialog actionDialog;
        private DateTimePicker date;
        private ComboBox priority;
        private CheckBox isRecurring;
        private ComboBox units;
        private TextBox filePath;
        private Button saveButton;
        private Button cancelButton;
        #endregion
    }
}