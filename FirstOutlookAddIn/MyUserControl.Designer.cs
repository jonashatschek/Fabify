namespace FirstOutlookAddIn
{
    partial class MyUserControl
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
            this.components = new System.ComponentModel.Container();
            this.datePickCalendar = new System.Windows.Forms.MonthCalendar();
            this.SearchCalendar_btn = new System.Windows.Forms.Button();
            this.objectsListView = new System.Windows.Forms.ListView();
            this.addObject_textBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addObject_btn = new System.Windows.Forms.Button();
            this.categoryBtn = new System.Windows.Forms.RadioButton();
            this.descriptionBtn = new System.Windows.Forms.RadioButton();
            this.folderBrowser_dlg = new System.Windows.Forms.FolderBrowserDialog();
            this.folderPath_txtbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addTask_btn = new System.Windows.Forms.Button();
            this.addTask_textBox = new System.Windows.Forms.TextBox();
            this.tasksListview = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // datePickCalendar
            // 
            this.datePickCalendar.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.datePickCalendar.Location = new System.Drawing.Point(9, 9);
            this.datePickCalendar.MaxSelectionCount = 61;
            this.datePickCalendar.Name = "datePickCalendar";
            this.datePickCalendar.ShowWeekNumbers = true;
            this.datePickCalendar.TabIndex = 0;
            this.datePickCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.datePickCalendar_DateChanged);
            // 
            // SearchCalendar_btn
            // 
            this.SearchCalendar_btn.Location = new System.Drawing.Point(5, 746);
            this.SearchCalendar_btn.Name = "SearchCalendar_btn";
            this.SearchCalendar_btn.Size = new System.Drawing.Size(247, 51);
            this.SearchCalendar_btn.TabIndex = 1;
            this.SearchCalendar_btn.Text = "Fabify my calendar ;)";
            this.SearchCalendar_btn.UseVisualStyleBackColor = true;
            this.SearchCalendar_btn.Click += new System.EventHandler(this.SearchCalendar_btn_Click);
            // 
            // objectsListView
            // 
            this.objectsListView.Location = new System.Drawing.Point(8, 358);
            this.objectsListView.Name = "objectsListView";
            this.objectsListView.Size = new System.Drawing.Size(241, 40);
            this.objectsListView.TabIndex = 2;
            this.objectsListView.UseCompatibleStateImageBehavior = false;
            this.objectsListView.View = System.Windows.Forms.View.List;
            this.objectsListView.SelectedIndexChanged += new System.EventHandler(this.objectsListView_SelectedIndexChanged);
            // 
            // addObject_textBox
            // 
            this.addObject_textBox.Location = new System.Drawing.Point(9, 332);
            this.addObject_textBox.Name = "addObject_textBox";
            this.addObject_textBox.Size = new System.Drawing.Size(144, 20);
            this.addObject_textBox.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // addObject_btn
            // 
            this.addObject_btn.Location = new System.Drawing.Point(160, 332);
            this.addObject_btn.Name = "addObject_btn";
            this.addObject_btn.Size = new System.Drawing.Size(91, 23);
            this.addObject_btn.TabIndex = 5;
            this.addObject_btn.Text = "Add object";
            this.addObject_btn.UseVisualStyleBackColor = true;
            this.addObject_btn.Click += new System.EventHandler(this.addObject_btn_Click);
            // 
            // categoryBtn
            // 
            this.categoryBtn.AutoSize = true;
            this.categoryBtn.Location = new System.Drawing.Point(7, 685);
            this.categoryBtn.Name = "categoryBtn";
            this.categoryBtn.Size = new System.Drawing.Size(155, 17);
            this.categoryBtn.TabIndex = 9;
            this.categoryBtn.TabStop = true;
            this.categoryBtn.Text = "Look at item color/category";
            this.categoryBtn.UseVisualStyleBackColor = true;
            // 
            // descriptionBtn
            // 
            this.descriptionBtn.AutoSize = true;
            this.descriptionBtn.Location = new System.Drawing.Point(7, 708);
            this.descriptionBtn.Name = "descriptionBtn";
            this.descriptionBtn.Size = new System.Drawing.Size(136, 17);
            this.descriptionBtn.TabIndex = 10;
            this.descriptionBtn.TabStop = true;
            this.descriptionBtn.Text = "Look in item description";
            this.descriptionBtn.UseVisualStyleBackColor = true;
            // 
            // folderPath_txtbox
            // 
            this.folderPath_txtbox.Location = new System.Drawing.Point(7, 498);
            this.folderPath_txtbox.Name = "folderPath_txtbox";
            this.folderPath_txtbox.ReadOnly = true;
            this.folderPath_txtbox.Size = new System.Drawing.Size(243, 20);
            this.folderPath_txtbox.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 524);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Choose target folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 665);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Searches in format [Object]-[Task], e.g. \"Grow-dev\"";
            // 
            // addTask_btn
            // 
            this.addTask_btn.Location = new System.Drawing.Point(160, 411);
            this.addTask_btn.Name = "addTask_btn";
            this.addTask_btn.Size = new System.Drawing.Size(91, 23);
            this.addTask_btn.TabIndex = 18;
            this.addTask_btn.Text = "Add task";
            this.addTask_btn.UseVisualStyleBackColor = true;
            this.addTask_btn.Click += new System.EventHandler(this.addTask_btn_Click);
            // 
            // addTask_textBox
            // 
            this.addTask_textBox.Location = new System.Drawing.Point(9, 411);
            this.addTask_textBox.Name = "addTask_textBox";
            this.addTask_textBox.Size = new System.Drawing.Size(144, 20);
            this.addTask_textBox.TabIndex = 17;
            // 
            // tasksListview
            // 
            this.tasksListview.Location = new System.Drawing.Point(8, 437);
            this.tasksListview.Name = "tasksListview";
            this.tasksListview.Size = new System.Drawing.Size(241, 44);
            this.tasksListview.TabIndex = 16;
            this.tasksListview.UseCompatibleStateImageBehavior = false;
            this.tasksListview.View = System.Windows.Forms.View.List;
            // 
            // MyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addTask_btn);
            this.Controls.Add(this.addTask_textBox);
            this.Controls.Add(this.tasksListview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.folderPath_txtbox);
            this.Controls.Add(this.descriptionBtn);
            this.Controls.Add(this.categoryBtn);
            this.Controls.Add(this.addObject_btn);
            this.Controls.Add(this.addObject_textBox);
            this.Controls.Add(this.objectsListView);
            this.Controls.Add(this.SearchCalendar_btn);
            this.Controls.Add(this.datePickCalendar);
            this.Name = "MyUserControl";
            this.Size = new System.Drawing.Size(264, 800);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar datePickCalendar;
        private System.Windows.Forms.Button SearchCalendar_btn;
        private System.Windows.Forms.ListView objectsListView;
        private System.Windows.Forms.TextBox addObject_textBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button addObject_btn;
        private System.Windows.Forms.RadioButton categoryBtn;
        private System.Windows.Forms.RadioButton descriptionBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser_dlg;
        private System.Windows.Forms.TextBox folderPath_txtbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addTask_btn;
        private System.Windows.Forms.TextBox addTask_textBox;
        private System.Windows.Forms.ListView tasksListview;
    }
}
