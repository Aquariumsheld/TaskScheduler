namespace Explorer_Dialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OpenFile();
        }
        private static string OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Anwendungen (*.exe)|*.exe";
                openFileDialog.Title = "Wählen Sie eine Anwendung";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return string.Empty;
        }
    }
}
