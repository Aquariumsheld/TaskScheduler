using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDialog
{
    public partial class TaskCreator : Form
    {
        private string[] _prioritys =
        {
            "sehr wichtig",
            "wichtig",
            "normal",
            "unwichtig",
            "sehr unwichtig"
        };

        private UnitFactors[] _units =
        {
            UnitFactors.Sekunden,
            UnitFactors.Minuten,
            UnitFactors.Stunden,
            UnitFactors.Tage,
            UnitFactors.Wochen
        };

        private bool _exists = true;

        #region Werte für neuen Task
        private string? _taskName = null;
        private string? _taskFilePath = null;
        private DateTime? _taskDateTime = null;
        private int? _taskPriority = null;
        private bool _taskIsRecurring = false;
        private TimeSpan? _taskInterval = null;
        #endregion

        public TaskCreator()
        {
            InitializeComponent();

            #region Fill Prioritys
            foreach (var item in _prioritys)
            {
                priority.Items.Add(item);
            }

            priority.Items.Add("Priorität");
            #endregion

            #region Fill Units
            foreach (var item in _units)
            {
                units.Items.Add(item);
            }

            units.Items.Add("Einheit");
            #endregion

            Task.Run(ChangeValuesAsync);
            Task.Run(UpdateSaveButton);
        }

        private void Priority_DropDown(object sender, EventArgs e)
        {
            priority.Items.Remove("Priorität");
        }

        private void Units_DropDown(object sender, EventArgs e)
        {
            units.Items.Remove("Einheit");
        }

        private void IsRecurring_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_taskIsRecurring)
            {
                case true:
                    _taskIsRecurring = false;
                    interval.Enabled = false;
                    units.Enabled = false;
                    break;
                case false:
                    _taskIsRecurring = true;
                    interval.Enabled = true;
                    units.Enabled = true;
                    break;
                default:
            }
        }

        private void ActionButton_MouseClick(object sender, MouseEventArgs e)
        {
            actionDialog.Filter = "(*.exe)|*.exe|All files (*.*)|*.*";
            actionDialog.ShowDialog();
            filePath.Text = actionDialog.FileName;

            _taskFilePath = filePath.Text;
        }

        private void CancelButton_MouseClick(object sender, MouseEventArgs e)
        {
            _exists = false;
            Application.Exit();
        }

        private void SaveButton_MouseClick(object sender, MouseEventArgs e)
        {
            //todo neuen Task erstellen und der Queue hinzufügen
        }
        private void SaveButton_EnabledChanged(object sender, EventArgs e)
        {
            switch (Enabled)
            {
                case true:
                    break;
                case false:
                    break;
            }
        }

        private enum UnitFactors
        {
            Sekunden = 1,
            Minuten = 60,
            Stunden = 3600,
            Tage = 86400,
            Wochen = 604800
        }

        //private async Task UpdateSaveButton()
        //{
        //    while (_exists)
        //    {
        //        switch (_taskIsRecurring)
        //        {
        //            case true:
        //                break;
        //            case false:
        //                break;
        //        }
        //    }
        //}

        private async Task ChangeValuesAsync()
        {
            while (_exists)
            {
                _taskName = name.Text;
                _taskDateTime = date.Value;

                if (priority.SelectedItem != null)
                    _taskPriority = ConvertPriority(priority.SelectedItem.ToString());

                if (units.SelectedItem != null)
                {
                    if (int.TryParse(interval.Text, out int value))
                        _taskInterval = new TimeSpan(value * Convert.ToInt32(units.SelectedItem));
                }
            }
        }

        private int? ConvertPriority(string? priority)
        {
            switch (priority)
            {
                case "sehr wichtig":
                    return 1;
                case "wichtig":
                    return 2;
                case "normal":
                    return 3;
                case "unwichtig":
                    return 4;
                case "sehr unwichtig":
                    return 5;
                default:
                    return null;
            }
        }
    }
}
