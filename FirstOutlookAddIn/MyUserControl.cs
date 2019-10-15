using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FirstOutlookAddIn
{

    public partial class MyUserControl : UserControl
    {
        public List<string> listOfWorkObjects = new List<string>();
        public string startDate;
        public string endDate;
        public string userPath;
        //public List<string> tasksList = new List<string>();
        public MyUserControl()
        {
            InitializeComponent();
        }

        //public List<string> GetObjectsList()
        //{
        //    return listOfObjects;
        //}

        private void SearchCalendar_btn_Click(object sender, EventArgs e)
        {
            if (categoryBtn.Checked) {
                Globals.ThisAddIn.DemoAppointmentsInRange(startDate, endDate, true);
                Globals.ThisAddIn.ExportToExcel(userPath);
            }
            else if (descriptionBtn.Checked)
            {
                Globals.ThisAddIn.DemoAppointmentsInRange(startDate, endDate, false);
                Globals.ThisAddIn.ExportToExcel(userPath);
            }
            else
                MessageBox.Show("Please specify how to search the calendar.");

        }

        private void addObject_btn_Click(object sender, EventArgs e)
        {
            List<string> listOfObjects = Globals.ThisAddIn.GetObjectsList();
            //TeamObject teamObject = new TeamObject { objectName = addObject_textBox.Text };

            if (!listOfObjects.Contains(addObject_textBox.Text))
            {
                Globals.ThisAddIn.SetObjectList(addObject_textBox.Text, listOfObjects);
                //listOfObjects.Add(addObject_textBox.Text);
                objectsListView.Items.Add(addObject_textBox.Text);
            }
            else
                MessageBox.Show("Havn't you already added this Object, friend?");
           
        }

        private void datePickCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            startDate = datePickCalendar.SelectionRange.Start.ToString();
            endDate = datePickCalendar.SelectionRange.End.ToString();
            Debug.WriteLine("start: " + startDate + ", end: " + endDate);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(folderBrowser_dlg.ShowDialog() == DialogResult.OK)
            {
                folderPath_txtbox.Text = folderBrowser_dlg.SelectedPath;
                userPath = folderBrowser_dlg.SelectedPath;
            }
        }

        private void objectsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addTask_btn_Click(object sender, EventArgs e)
        {
            List<string> listOfTasks = Globals.ThisAddIn.GetTasksList();
            //TeamObject teamObject = new TeamObject { objectName = addObject_textBox.Text };

            if (!listOfTasks.Contains(addTask_textBox.Text))
            {
                Globals.ThisAddIn.SetObjectList(addTask_textBox.Text, listOfTasks);
                //listOfObjects.Add(addObject_textBox.Text);
                tasksListview.Items.Add(addTask_textBox.Text);
                
            }
            else
                MessageBox.Show("Havn't you already added this Task, friend?");
        }
    }

}
