using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CriticalProcessManager
{
    public partial class Form1 : Form
    {
        private static List<ListViewItem> items = new List<ListViewItem>();

        public Form1()
        {
            InitializeComponent();
        }

        public int LoadProcess(out string errorMessage)
        {
            errorMessage = null;

            SetCriticalProcessClass.CriticalProcessInfo[] cInfoList;

            processListView.Items.Clear();
            items.Clear();

            try
            {
                cInfoList= SetCriticalProcessClass.FindCriticalProcess();
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while loading the list : " + ex.Message;

                return 1;
            }

            foreach (SetCriticalProcessClass.CriticalProcessInfo cInfo in cInfoList)
            {
                if (!string.IsNullOrEmpty(cInfo.pName))
                {
                    ListViewItem item = new ListViewItem(cInfo.pName);
                    item.SubItems.Add(cInfo.pid.ToString());
                    item.SubItems.Add(cInfo.isCritical ? "Critical" : "Normal");
                    processListView.Items.Add(item);

                    items.Add(item);
                }
            }

            return 0;
        }

        private int SetCriticalProcess(int isCritical, out string message)
        {
            message = null;

            foreach (ListViewItem selectedItem in processListView.SelectedItems)
            {
                string processName = selectedItem.SubItems[0].Text;
                string isCriticalString = isCritical == 0 ? "normal" : "critical";

                int.TryParse(selectedItem.SubItems[1].Text, out int pid);

                try
                {
                    SetCriticalProcessClass.SetCriticalProcess(pid, isCritical);

                    message =
                        $"Successfully configured as a {isCriticalString} process\r\n" +
                        $"Process Name : {processName}\r\n" +
                        $"PID : {pid}";

                    return 0;
                }
                catch (Exception ex)
                {
                    message =
                        $"An error occurred while setting as a {isCriticalString} process : {ex.Message}\r\n" +
                        $"Process Name : {processName}\r\n" +
                        $"PID : {pid}";
                }
            }

            return 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string errorMessage = null;

            if (LoadProcess(out errorMessage) != 0)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            string errorMessage = null;

            if (LoadProcess(out errorMessage) != 0)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            processListView.Items.Clear();
            processListView.Items.AddRange(items.ToArray());

            if (filterComboBox.SelectedIndex != 0)
            {
                for (int i = processListView.Items.Count - 1; i >= 0; i--)
                {
                    if (processListView.Items[i].SubItems[2].Text + " Process" != filterComboBox.SelectedItem.ToString())
                    {
                        processListView.Items.RemoveAt(i);
                    }
                }
            }
        }

        private void criticalProcessToolStrip_Click(object sender, EventArgs e)
        {
            string dialogTitle;
            MessageBoxIcon mbIcon;

            string message = null;

            int result = SetCriticalProcess(1, out message);

            dialogTitle = result != 1 ? "Success" : "Error";
            mbIcon = result != 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error;

            MessageBox.Show(message, dialogTitle, MessageBoxButtons.OK, mbIcon);
        }

        private void normalProcessToolStrip_Click(object sender, EventArgs e)
        {
            string dialogTitle;
            MessageBoxIcon mbIcon;

            string message = null;

            int result = SetCriticalProcess(0, out message);

            dialogTitle = result != 1 ? "Success" : "Error";
            mbIcon = result != 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error;

            MessageBox.Show(message, dialogTitle, MessageBoxButtons.OK, mbIcon);
        }

        private void killToolStrip_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in processListView.SelectedItems)
            {
                string processName = selectedItem.SubItems[0].Text;

                int.TryParse(selectedItem.SubItems[1].Text, out int pid);

                try
                {
                    SetCriticalProcessClass.KillCriticalProcess(pid);

                    string successMessage =
                        "Successfully killed critical process.\r\n" +
                        $"Process Name : {processName}\r\n" +
                        $"PID : {pid}";

                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string errorMessage =
                        $"An error occurred while killing a critical process : {ex.Message}\r\n" +
                        $"Process Name : {processName}\r\n" +
                        $"PID : {pid}";

                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void reloadToolStrip_Click(object sender, EventArgs e)
        {
            string errorMessage = null;

            if (LoadProcess(out errorMessage) != 0)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createToolStrip_Click(object sender, EventArgs e)
        {
            NewProcessForm newProcessForm = new NewProcessForm();
            newProcessForm.ShowDialog();
        }
    }
}
