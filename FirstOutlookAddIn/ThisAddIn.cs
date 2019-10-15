using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Diagnostics;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FirstOutlookAddIn
{
    public partial class ThisAddIn
    {
        Outlook.Inspectors inspectors;
        List<Outlook.AppointmentItem> outlookItemsList = new List<Outlook.AppointmentItem>();
        List<string> userInputRows = new List<string>();
        DateTime start = new DateTime();
        DateTime end = new DateTime();
        List<string> listOfStartTimes = new List<string>();
        private MyUserControl myUserControl1;
        private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;
        List<string> listOfObjects = new List<string>();
        List<string> listOfTasks = new List<string>();
        List<SummarizedDate> result = new List<SummarizedDate>();
        DescriptionSearchObject dso = new DescriptionSearchObject();

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            CreateUI();
            //DemoAppointmentsInRange();
            //ExportToExcel();
            //inspectors = this.Application.Inspectors;
            //inspectors.NewInspector +=
            //new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);

        }

        public void CreateUI()
        {
            myUserControl1 = new MyUserControl();
            myCustomTaskPane = this.CustomTaskPanes.Add(myUserControl1, "Fabify");
            myCustomTaskPane.Visible = true;
        }

        public List<string> GetObjectsList()
        {
            return listOfObjects;
        }

        public List<string> GetTasksList()
        {
            return listOfTasks;
        }

        public void SetObjectList(string stringToBeAdded, List<string> objectList)
        {
            objectList.Add(stringToBeAdded);
        }

        public void DemoAppointmentsInRange(string startDate, string endDate, bool searchUsingCategory)
        {
            Outlook.Folder calFolder =
                Application.Session.GetDefaultFolder(
                Outlook.OlDefaultFolders.olFolderCalendar)
                as Outlook.Folder;

            start = Convert.ToDateTime(startDate);
            end = Convert.ToDateTime(endDate);

            Outlook.Items rangeAppts = GetAppointmentsInRange(calFolder, start, end);

            List<string> tempStartTimeList = new List<string>();

            if (rangeAppts != null)
            {

                foreach (Outlook.AppointmentItem appt in rangeAppts)
                {
                    //foreach()
                    Debug.WriteLine("Subject: " + appt.Subject
                        + " Start: " + appt.Start.ToString("g")
                        + " Duration: " + appt.Duration.ToString("g") + " min");

                    outlookItemsList.Add(appt);
                    tempStartTimeList.Add(appt.Start.ToString().Substring(0, 10));
                    
                }

            }
            //var res = outlookItemsList.Sum(x => x.Duration);
            //var res2 = outlookItemsList.Select(x => x.Start).Distinct();

            IEnumerable<string> result = tempStartTimeList.Distinct();

            listOfStartTimes.Clear();

            foreach (string s in result)
                listOfStartTimes.Add(s);

        }

        /// <summary>
        /// Get recurring appointments in date range.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns>Outlook.Items</returns>
        private Outlook.Items GetAppointmentsInRange(Outlook.Folder folder, DateTime startTime, DateTime endTime)
        {
            string filter = "[Start] >= '"
                + startTime.ToString("g")
                + "' AND [End] <= '"
                + endTime.ToString("g") + "'";
            Debug.WriteLine(filter);
            try
            {
                Outlook.Items calItems = folder.Items;
                calItems.IncludeRecurrences = true;
                calItems.Sort("[Start]", Type.Missing);
                Outlook.Items restrictItems = calItems.Restrict(filter);
                if (restrictItems.Count > 0)
                {
                    return restrictItems;
                }
                else
                {
                    return null;
                }
            }
            catch { return null; }
        }

        //TODO: Modify User Path with below method
        public string ModifyUserPath (string userPath)
        {

            throw new NotImplementedException();
            string returnString = userPath;

            foreach(char c in userPath)
            {
                if(c == '/')
                    returnString.Insert(userPath.IndexOf(c) + 1, "/");
            }

            return returnString;
        }

        public void ExportToExcel(string userSavePath) {

        Microsoft.Office.Interop.Excel.Application excelApplicaton = new Microsoft.Office.Interop.Excel.Application();

            if (excelApplicaton == null)
                MessageBox.Show("An error was registered when testing Excel installation. Please verify that Excel is correctly installed :------)");

            object misValue = System.Reflection.Missing.Value;

            Workbook excelWorkBook = excelApplicaton.Workbooks.Add(misValue);

            Worksheet excelWorkSheet = (Worksheet)excelWorkBook.Worksheets.get_Item(1);

            excelWorkSheet.Cells[1, 2] = "This report was printed " + DateTime.Now;
            excelWorkSheet.Cells[3, 2] = "This Excel is a report from scanning your Outlook calendar between the following dates: " + start.Date.ToString("dd-MM-yyyy") + " to " + end.Date.ToString("dd-MM-yyyy");
            excelWorkSheet.Cells[6, 3] = "Object";
            excelWorkSheet.Cells[6, 4] = "Task";
            excelWorkSheet.Cells[6, 5] = "Total";

            result = outlookItemsList.GroupBy(x => new { x.Start.Date, BusinessObject = x.Categories }).Select(z => new SummarizedDate { Date = z.First().Start.Date, SummarizedTime = z.Sum(c => c.Duration), BuesinessObject = z.First().Categories }).ToList();
            //result = outlookItemsList.GroupBy(x => x.Start.Date).Select(z => new SummarizedDate { Date = z.First().Start.Date, SummarizedTime = z.Sum(c => c.Duration), BuesinessObject = z.First().Categories }).ToList();
            //need this to be able to sort out per category instead. have to implement this at all places

            int taskCounter = 0;
            int objectCounter = 7;

            //prints workobjects and tasks into excel
            foreach (string workObject in listOfObjects)
            {

                objectCounter += 2;
                taskCounter++;
                //excelWorkSheet.Cells[objectCounter - 1, 3] = " ";
                excelWorkSheet.Cells[objectCounter, 3] = workObject;
                taskCounter = objectCounter;

                foreach (string taskObject in listOfTasks)
                {
                    excelWorkSheet.Cells[taskCounter, 4] = taskObject;
                    taskCounter++;
                    objectCounter++;
                }

                excelWorkSheet.Cells[taskCounter + 1, 4] = "Total";

            }

            int startTimeCounter = 0;

            //All dates that are to be included into excel
            for (int j = 6; j < listOfStartTimes.Count + 6; j++)
            {
                excelWorkSheet.Cells[6, j] = listOfStartTimes[startTimeCounter];
                startTimeCounter++;

                //var joined = outlookItemsList.Join(listOfStartTimes, x => x.Start.Date, y => Convert.ToDateTime(y), (x, y) => new JointDateOutlookItem { JoinedDate = x,  });
                //(x, y) => new Classname { prop1 = y.name, prop2 = y.key } exempelvis
            }

            //todo: write function to add dates to Excel

            for(int i = 0; i > result.Count; i++)
            {
                
            }

            foreach (SummarizedDate s in result)
            {
                //if()
                //TODO:continue here
                Range currentFind = null;
                Range firstFind = null;


                //TODO: Idea: write code in following way: input fields in UI gets input business objects, while the currentFind variable searches for the FIRST PART of user category.
                //TODO: implement something to separate the category string. Format is e.g. Grow - Development.
                //TODO: right now business task is separated with LINQ right into the result variable.
                Range Fruits = excelApplicaton.get_Range("C5", "C10");
                // You should specify all these parameters every time you call this method,
                // since they can be overridden in the user interface. 
                currentFind = Fruits.Find("Grow", missing,
                     XlFindLookIn.xlValues, XlLookAt.xlPart,
                     XlSearchOrder.xlByRows, XlSearchDirection.xlNext, false,
                    missing, missing);

                while (currentFind != null)
                {
                    // Keep track of the first range you find. 
                    if (firstFind == null)
                    {
                        firstFind = currentFind;
                    }

                    // If you didn't move to a new range, you are done.
                    else if (currentFind.get_Address(XlReferenceStyle.xlA1)
                            == firstFind.get_Address(XlReferenceStyle.xlA1))
                    {
                        break;
                    }

                    currentFind.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    currentFind.Font.Bold = true;

                    currentFind = Fruits.FindNext(currentFind);

                    string test1 = currentFind.Value2;
                    string test4 = Convert.ToString(currentFind.Cells);
                    string test2 = currentFind.Value;
                }
            }

            try
            {
                excelWorkBook.SaveAs(userSavePath + "/myFabReport", XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                excelWorkBook.Close(true, misValue, misValue);
                excelApplicaton.Quit();

                Marshal.ReleaseComObject(excelWorkSheet);
                Marshal.ReleaseComObject(excelWorkBook);
                Marshal.ReleaseComObject(excelApplicaton);

                MessageBox.Show("An Excel file has been created at " + userSavePath);
            }
            catch (COMException)
            {
                MessageBox.Show("Something went wrong. Either you have an old file with the same name open before running OR chose No at the last prompt when asked to save the Excel.");
            }
        }

        public string GetCellRow(string startRow, string endRow, string startColumn, string endColumn)
        {

            string foundResult = "";

            return foundResult;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new EventHandler(ThisAddIn_Startup);
        }
        
        #endregion
    }

    public class SummarizedDate
    {
        public DateTime Date { get; set; }
        public int SummarizedTime { get; set; }
        public string BuesinessObject { get; set; }
        public string BusinessTask { get; set; }

        public SummarizedDate() { }

        //public int ConvertToHours (int minutes)
        //{
        //    int hours = minutes / 60;
        //    return hours;
        //}

    }

    public class DescriptionSearchObject
    {
        public DateTime Date { get; set; }
        public string WorkObject { get; set; }
        public string WorkTask { get; set; }
        public int Duration { get; set; }

    }
}
