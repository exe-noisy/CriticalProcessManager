using System;
using System.Windows.Forms;
using static CriticalProcessManager.SetCriticalProcessClass;

namespace CriticalProcessManager
{
    public partial class NewProcessForm : Form
    {
        string fileName;

        public NewProcessForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                pathTextBox.Text = fileName;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            CriticalProcessInfo info;
            try
            {
                info = CreateCriticalProcess(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while starting a critical process : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message =
                $"Critical process started successfully.\r\n" +
                $"Process Name : {info.pName}\r\n" +
                $"PID : {info.pid}";
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
