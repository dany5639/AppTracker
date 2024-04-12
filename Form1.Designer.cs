namespace AppTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonAddApp = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            dataGridView1 = new DataGridView();
            ColumnName = new DataGridViewTextBoxColumn();
            ColumnSubname = new DataGridViewTextBoxColumn();
            ColumnLastRun = new DataGridViewTextBoxColumn();
            ColumnTime = new DataGridViewTextBoxColumn();
            ColumnId = new DataGridViewTextBoxColumn();
            ColumnTimems = new DataGridViewTextBoxColumn();
            buttonRefreshProcessList = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            Tracker = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            timerSavelogs = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            Tracker.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAddApp
            // 
            buttonAddApp.Location = new Point(93, 11);
            buttonAddApp.Name = "buttonAddApp";
            buttonAddApp.Size = new Size(75, 23);
            buttonAddApp.TabIndex = 0;
            buttonAddApp.Text = "Add app";
            buttonAddApp.UseVisualStyleBackColor = true;
            buttonAddApp.Click += buttonAddApp_Click;
            // 
            // button2
            // 
            button2.Location = new Point(174, 11);
            button2.Name = "button2";
            button2.Size = new Size(114, 23);
            button2.TabIndex = 2;
            button2.Text = "Remove following:";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(294, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1032, 23);
            textBox1.TabIndex = 3;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(6, 6);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1300, 664);
            listBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnName, ColumnSubname, ColumnLastRun, ColumnTime, ColumnId, ColumnTimems });
            dataGridView1.Location = new Point(6, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1294, 654);
            dataGridView1.TabIndex = 4;
            // 
            // ColumnName
            // 
            ColumnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnName.HeaderText = "Name";
            ColumnName.Name = "ColumnName";
            ColumnName.Width = 64;
            // 
            // ColumnSubname
            // 
            ColumnSubname.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnSubname.HeaderText = "Subname";
            ColumnSubname.Name = "ColumnSubname";
            ColumnSubname.Width = 82;
            // 
            // ColumnLastRun
            // 
            ColumnLastRun.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnLastRun.HeaderText = "Last run";
            ColumnLastRun.Name = "ColumnLastRun";
            ColumnLastRun.Width = 74;
            // 
            // ColumnTime
            // 
            ColumnTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnTime.HeaderText = "Time";
            ColumnTime.Name = "ColumnTime";
            ColumnTime.Width = 58;
            // 
            // ColumnId
            // 
            ColumnId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnId.HeaderText = "ID";
            ColumnId.Name = "ColumnId";
            ColumnId.Width = 43;
            // 
            // ColumnTimems
            // 
            ColumnTimems.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColumnTimems.HeaderText = "Time ms";
            ColumnTimems.Name = "ColumnTimems";
            ColumnTimems.Width = 77;
            // 
            // buttonRefreshProcessList
            // 
            buttonRefreshProcessList.Location = new Point(12, 12);
            buttonRefreshProcessList.Name = "buttonRefreshProcessList";
            buttonRefreshProcessList.Size = new Size(75, 23);
            buttonRefreshProcessList.TabIndex = 5;
            buttonRefreshProcessList.Text = "Refresh";
            buttonRefreshProcessList.UseVisualStyleBackColor = true;
            buttonRefreshProcessList.Click += buttonRefreshProcessList_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Tracker
            // 
            Tracker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Tracker.Controls.Add(tabPage1);
            Tracker.Controls.Add(tabPage2);
            Tracker.Location = new Point(12, 41);
            Tracker.Name = "Tracker";
            Tracker.SelectedIndex = 0;
            Tracker.Size = new Size(1314, 694);
            Tracker.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1306, 666);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tracker";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(listBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1306, 666);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Processes";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // timerSavelogs
            // 
            timerSavelogs.Enabled = true;
            timerSavelogs.Interval = 60000;
            timerSavelogs.Tick += timerSavelogs_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 747);
            Controls.Add(Tracker);
            Controls.Add(buttonRefreshProcessList);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(buttonAddApp);
            Name = "Form1";
            Text = "AppTracker";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            Tracker.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddApp;
        private Button button2;
        private TextBox textBox1;
        private ListBox listBox1;
        private DataGridView dataGridView1;
        private Button buttonRefreshProcessList;
        private System.Windows.Forms.Timer timer1;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnSubname;
        private DataGridViewTextBoxColumn ColumnLastRun;
        private DataGridViewTextBoxColumn ColumnTime;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnTimems;
        private TabControl Tracker;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private System.Windows.Forms.Timer timerSavelogs;
    }
}