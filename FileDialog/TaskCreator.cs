
using TaskClasses;
using System.Diagnostics;

namespace FileDialog;

public partial class TaskCreator : Form
{
    /// <summary>
    /// Array mit allen möglichen Prioritäten, die zur Auswahl stehen.
    /// </summary>
    private string[] _prioritys =
    {
        "sehr wichtig",
        "wichtig",
        "normal",
        "unwichtig",
        "sehr unwichtig"
    };

    /// <summary>
    /// Array mit allen möglichen Zeit-Einheiten, welche zur Auswahl stehen.
    /// </summary>
    private UnitFactors[] _units =
    {
        UnitFactors.Sekunden,
        UnitFactors.Minuten,
        UnitFactors.Stunden,
        UnitFactors.Tage,
        UnitFactors.Wochen
    };

    /// <summary>
    /// Werte die für das Erstellen einer neuen Task gebraucht werden.
    /// </summary>
    #region Werte für neuen Task
    private string _taskName = "";
    private string _taskFilePath = "";
    private DateTime _taskDateTime = DateTime.Now;
    private int _taskPriority = 3;
    private bool _taskIsRecurring = false;
    private TimeSpan? _taskInterval = null;
    #endregion

    /// <summary>
    /// Das Scheduler-Objekt, für das eine neue Task erstellt wird.
    /// </summary>
    private TaskScheduler Scheduler { get; set; }

    /// <summary>
    /// Konstruktor des Task-Erstellers.
    /// </summary>
    public TaskCreator(TaskScheduler taskScheduler)
    {
        Scheduler = taskScheduler;

        InitializeComponent();

        #region Fill Prioritys
        foreach (var item in _prioritys)
        {
            priority.Items.Add(item);
        }
        #endregion

        #region Fill Units
        foreach (var item in _units)
        {
            units.Items.Add(item);
        }
        #endregion

        _taskDateTime = date.Value;
        saveButton.Enabled = false;
    }

    /// <summary>
    /// Enumeration für alle möglichen Zeit-Einheiten.
    /// </summary>
    private enum UnitFactors
    {
        Sekunden = 1,
        Minuten = 60,
        Stunden = 3600,
        Tage = 86400,
        Wochen = 604800
    }

    /// <summary>
    /// Prüft alle Bedingungen, ob der Save-Button aktiviert oder Deaktiviert werden muss.
    /// Wird nach jeder Wertänderung eines Eingabe-Feldes aufgerufen.
    /// </summary>
    private void UpdateSaveButton()
    {
        switch (_taskIsRecurring)
        {
            case true:
                if (_taskName != null &&
                    _taskFilePath != null &&
                    _taskInterval != null) saveButton.Enabled = true;
                else
                {
                    saveButton.Enabled = false;
                }
                break;
            case false:
                if (_taskName != null &&
                    _taskFilePath != null) saveButton.Enabled = true;
                else
                {
                    saveButton.Enabled = false;
                }
                break;
        }
    }

    /// <summary>
    /// Wandelt die ausgewählte string-Priorität in einen Integer um und gibt diesen zurück.
    /// </summary>
    /// <param name="selectedPriority">string-Priorität</param>
    /// <returns>Integer</returns>
    private int ConvertPriority(string selectedPriority)
    {
        int result = 3;

        switch (selectedPriority)
        {
            case "sehr wichtig":
                result = 1;
                break;
            case "wichtig":
                result = 2;
                break;
            case "normal":
                result = 3;
                break;
            case "unwichtig":
                result = 4;
                break;
            case "sehr unwichtig":
                result = 5;
                break;
            default:
                break;
        }

        return result;
    }

    private void Name_TextChanged(object sender, EventArgs e)
    {
        _taskName = name.Text;

        UpdateSaveButton();
    }

    private void FilePath_TextChanged(object sender, EventArgs e)
    {
        _taskFilePath = filePath.Text;

        UpdateSaveButton();
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

        UpdateSaveButton();
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
        Application.Exit();
    }

    private void SaveButton_MouseClick(object sender, MouseEventArgs e)
    {
        var task = new OwnTask(_taskName,
            _taskFilePath,
            _taskDateTime,
            _taskPriority,
            _taskIsRecurring,
            _taskInterval);

        Scheduler.ScheduleTask(task);
    }

    private void DateTime_ValueChanged(object sender, EventArgs e)
    {
        _taskDateTime = date.Value;

        UpdateSaveButton();
    }

    private void Priority_SelectedIndexChanged(object sender, EventArgs e)
    {
        _taskPriority = ConvertPriority(priority.SelectedText);

        UpdateSaveButton();
    }

    private void Interval_TextChanged(object sender, EventArgs e)
    {
        if (units.SelectedItem != null && int.TryParse(interval.Text, out int value))
        {
            int interval = value * (int)units.SelectedItem;

            _taskInterval = new TimeSpan(interval * 1000000000);
        }

        UpdateSaveButton();
    }

    private void Units_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (units.SelectedItem != null && int.TryParse(interval.Text, out int value))
        {
            int interval = value * (int)units.SelectedItem;

            _taskInterval = new TimeSpan(interval * 1000000000);
        }

        UpdateSaveButton();
    }
}
