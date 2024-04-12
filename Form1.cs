using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace AppTracker
{
    public partial class Form1 : Form
    {
        /*
           logs format:
           app name;total seconds;time since last run;list of name variants
        
            var unixt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var time = DateTimeOffset.FromUnixTimeSeconds(unixt);

       */
        private static Dictionary<string, ProcessItem> LoggedItems = new Dictionary<string, ProcessItem>();
        private static Dictionary<int, ProcessItem> ProcessesDict = new Dictionary<int, ProcessItem>();
        private static List<Process> ProcessesList = new List<Process>();
        private static string logFile = @"C:\C\APP\AppTracker.log";
        private List<string> logLines = new List<string>();
        private int updateTickrate = 1000;
        #region utilities
        private static void clog(string in_)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("hhmmss:fff")}] {in_}");
        }
        private static List<string> ReadCsv(string filename, int lineCount = -1)
        {
            clog("WriteCsv");
            var output = new List<string>();

            using (var reader = new StreamReader(filename))
            {
                var line = "";
                int j = -1;
                while (line != null)
                {
                    j++;
                    if (lineCount != -1)
                        if (j == lineCount)
                            return output;

                    line = reader.ReadLine();
                    output.Add(line);
                }

                if (output.Last() == null)
                    output.RemoveAt(output.Count - 1);
            }

            Console.WriteLine($"Read {output.Count} lines.");

            return output;
        }
        private static void WriteCsv(List<string> in_, string file)
        {
            clog("WriteCsv");

            var fileOut = new FileInfo(file);
            if (File.Exists(file))
                File.Delete(file);

            Console.WriteLine($"Writing {in_.Count} lines to {file}.");

            int i = -1;
            try
            {
                using (var csvStream = fileOut.OpenWrite())
                using (var csvWriter = new StreamWriter(csvStream))
                {
                    foreach (var a in in_)
                    {
                        csvStream.Position = csvStream.Length;
                        csvWriter.WriteLine(a);
                        i++;
                    }
                }
            }
            catch
            { }
        }
        #endregion
        private class ProcessItem
        {
            public string name;
            public string desc;
            public long time;
            public long last;
            public int id;
        }
        private enum dbCol : byte
        {
            name = 0,
            desc = 1,
            last = 2,
            time = 3,
            id = 4,
            timems = 5
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            clog("Form1_Load");

            timer1.Stop();
            timer1.Enabled = false;

            readLogs();

            buttonRefreshProcessList_Click(null, null);

            timer1.Interval = updateTickrate;
            timer1.Start();
            timer1.Enabled = true;

        }
        private void readLogs()
        {
            if (!File.Exists(logFile))
                File.CreateText(logFile);

            var lines = ReadCsv(logFile);
            clog($"Logs[{lines.Count}]");

            foreach (var l in lines)
            {
                var items = l.Split(";".ToCharArray()[0]);
                var name = items[0];
                Int64.TryParse(items[1], System.Globalization.NumberStyles.Integer, null, out Int64 last);
                Int64.TryParse(items[2], System.Globalization.NumberStyles.Integer, null, out Int64 time);
                var desc = items[3];

                var ProcessItem1 = new ProcessItem
                {
                    name = name,
                    desc = desc,
                    id = 0,
                    last = last,
                    time = time
                };

                LoggedItems.Add(name, ProcessItem1);
                clog($"Add to LoggedItems[{LoggedItems.Count}]: name;{ProcessItem1.last};{ProcessItem1.time};{ProcessItem1.desc}");

            }

            updateDatagridNew();

        }
        private void updateDatagridNew()
        {
            clog("updateDatagridNew");
            dataGridView1.Rows.Clear();

            int i = 0;
            foreach (var item in LoggedItems)
            {
                dataGridView1.Rows.Add(item.Key);
                dataGridView1.Rows[i].Cells[(int)dbCol.name].Value = item.Value.name;
                dataGridView1.Rows[i].Cells[(int)dbCol.desc].Value = item.Value.desc;
                dataGridView1.Rows[i].Cells[(int)dbCol.last].Value = item.Value.last;
                dataGridView1.Rows[i].Cells[(int)dbCol.time].Value = $"{(TimeSpan.FromMilliseconds(item.Value.time))}";
                dataGridView1.Rows[i].Cells[(int)dbCol.id].Value = item.Value.id;
                dataGridView1.Rows[i].Cells[(int)dbCol.timems].Value = item.Value.time;

                i++;
            }

        }
        private void buttonRefreshProcessList_Click(object sender, EventArgs e)
        {
            clog("buttonRefreshProcessList_Click");

            listBox1.Items.Clear();
            ProcessesDict.Clear();

            // read apps
            var allProcesses = Process.GetProcesses();

            int i = 0;
            foreach (var process in allProcesses)
            {
                var ProcessItem1 = new ProcessItem();

                try
                {
                    ProcessItem1 = new ProcessItem
                    {
                        name = process.ProcessName,
                        desc = process.MainModule.ModuleName,
                        id = process.Id,
                        last = 0,
                        time = 0
                    };

                    ProcessesDict.Add(i, ProcessItem1);
                    var proco = $"" +
                        $"{i:D8};" +
                        $"{ProcessItem1.id:X8};" +
                        $"{ProcessItem1.name};" +
                        $"{ProcessItem1.desc};" +
                        $"{ProcessItem1.last};" +
                        $"{ProcessItem1.time}";

                    listBox1.Items.Add(proco);

                    i++;
                }
                catch
                {
                    // clog($"Failed to read process details for: {process.ProcessName}");
                }
            }
        }
        private void buttonAddApp_Click(object sender, EventArgs e)
        {
            clog("buttonAddApp_Click");

            var id = listBox1.SelectedIndex;
            var proco = ProcessesDict[id];
            if (!LoggedItems.ContainsKey(proco.name))
                LoggedItems.Add(proco.name, proco);

            updateDatagridNew();

            dumpLoggedItems();

        }
        private void dumpLoggedItems()
        {
            clog("dumpLoggedItems");

            foreach (var item in LoggedItems)
            {
                var ProcessItem1 = item.Value;
                var procoLogLines = $"{ProcessItem1.name};{ProcessItem1.last};{ProcessItem1.time};{ProcessItem1.desc}";
                logLines.Add(procoLogLines);

            }

            WriteCsv(logLines, logFile);
            logLines = new List<string>();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // clog("timer1_Tick");

            updateDatagridExistingItems();

        }
        private void updateDatagridExistingItems()
        {
            // clog("updateDatagridExistingItems");

            var allProcesses = Process.GetProcesses();

            foreach (var loggedItem in LoggedItems)
            {
                foreach (var process in allProcesses)
                {
                    if (loggedItem.Key == process.ProcessName)
                    {
                        loggedItem.Value.time += updateTickrate;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[(int)dbCol.name].Value == loggedItem.Key)
                            {
                                Int64.TryParse(dataGridView1.Rows[i].Cells[(int)dbCol.timems].Value.ToString(), out long res);

                                dataGridView1.Rows[i].Cells[(int)dbCol.timems].Value = res + updateTickrate;

                                dataGridView1.Rows[i].Cells[(int)dbCol.time].Value = TimeSpan.FromMilliseconds(res + updateTickrate);

                            }
                        }

                        goto skip1;
                    }
                }

            skip1:
                ;

            }

            // dataGridView1.Refresh();

        }

        private void timerSavelogs_Tick(object sender, EventArgs e)
        {
            clog("timerSavelogs_Tick");

            dumpLoggedItems();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            clog("Form1_FormClosed");

            dumpLoggedItems();
        }
    }
}