using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Splitter
{
    public partial class frm_CSV_Splitter : Form
    {
        //
        // Private Variables.
        //
        private string filePath;
        private string fileName;
        private string outfileFolder;
        private bool inFileIsSelected;
        private bool outFolderIsSelected;
        private long defaultNumItems;
        private long totalNumRecords;
        private long numFiles;
        private long numPerFile;
        private int splitType;

        //public List<long> unevenIndex;
        //public List<long> unevenFileRecordNums;
        
        //
        // Private Object Declarations.
        //
        private FileSplitter infile;
        private UnevenSplitter uSplit;
        private SortCodeSplitter cSplit;

        //
        // Initializing the form.
        //
        public frm_CSV_Splitter()
        {
            InitializeComponent();
            inFileIsSelected = false;
            outFolderIsSelected = false;
            defaultNumItems = 1;
            numFiles = 1;
            txt_numItems.Text = defaultNumItems.ToString();
            numPerFile = 1;
            //numPerFile = (long)Math.Floor(numItems() / (double)numFiles);
            numUD_numFiles.Value = 1;
            numUD_numPerFile.Value = numPerFile;
        }

        //
        // These concern the number of files, records, etc.
        //
        private long findNumRecords(string aFilePath)
        {
            long numLines = 0;
            StreamReader inFile = new StreamReader(aFilePath);
            do
            {
                inFile.ReadLine();
                numLines++;
            } while (inFile.Peek() != -1);
            numLines--;
            totalNumRecords = numLines;
            inFile.Close();
            inFile.Dispose();
            return numLines;
        }
        public long numItems()
        {
            return Convert.ToInt64(txt_numItems.Text);
        }
        public long findNumPerFile()
        {
            numPerFile = (long)Math.Ceiling((double)infile.numRecords / (double) numFiles);
            //numFiles = (long)Math.Ceiling((double)infile.numRecords / (double)numPerFile);
            return numPerFile;
        }
        public long findNumFiles()
        {
            numFiles = (long)Math.Ceiling( (double) infile.numRecords / (double)numPerFile);
            //numPerFile = (long)Math.Ceiling( (double) infile.numRecords / (double) numFiles);
            return numFiles;
        }

        // Update the num files / num per file for even split
        private void numUD_numFiles_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numUD_numPerFile.ValueChanged -= new System.EventHandler(numUD_numPerFile_ValueChanged);
                numFiles = Convert.ToInt64(numUD_numFiles.Value);
                numUD_numPerFile.Value = findNumPerFile();
                numUD_numPerFile.ValueChanged += new System.EventHandler(numUD_numPerFile_ValueChanged);
            }
            catch
            {
                numUD_numPerFile.ValueChanged += new System.EventHandler(numUD_numPerFile_ValueChanged);                
                return;
            }
        }
        private void numUD_numPerFile_ValueChanged(object sender, EventArgs e)
        {
            //numUD_numFiles.Value = numUD_numFiles.Value;
            numUD_numFiles.ValueChanged -= new System.EventHandler(numUD_numFiles_ValueChanged);
            numPerFile = Convert.ToInt64(numUD_numPerFile.Value);
            numPerFile = (numPerFile > infile.numRecords) ? infile.numRecords : numPerFile;            
            numPerFile = (numPerFile < 1) ? 1 : numPerFile;

            //numPerFile = Convert.ToInt64(numUD_numPerFile.Value);
            findNumFiles();
            if (numFiles <= numUD_numFiles.Maximum)
            {
                numUD_numFiles.Value = numFiles;
            }
            else
            {
                numFiles = (long)numUD_numFiles.Maximum;
                numUD_numFiles.Value = numFiles;
                findNumPerFile();
            }
            numUD_numPerFile.Value = numPerFile;
            numUD_numFiles.ValueChanged += new System.EventHandler(numUD_numFiles_ValueChanged);
        }

        // Create the DataGridView for the uneven split.
        private void createDGV(UnevenSplitter aSplitDetails)
        {
            dgvUnevenSplit.DataSource = aSplitDetails.tblUnevenSplit;
            dgvUnevenSplit.Columns["File #"].ReadOnly = true;
            dgvUnevenSplit[1, dgvUnevenSplit.RowCount - 1].ReadOnly = true;
        }        
        
        // Functions which call the file splitting methods
        private void splitEven()
        {
            
            FileSplitter fs = new FileSplitter(filePath, outfileFolder);

            DialogResult dialogResult = MessageBox.Show("Split " + fileName + " into " + numFiles.ToString()
                                                        + " files with " + numPerFile.ToString() + " Items each?",
                                                        "Continue?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                fs.splitEven(numFiles, numPerFile);
                MessageBox.Show("Split Complete.");
                //split();

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }
        private void splitUneven()
        {
            uSplit.split(filePath, outfileFolder);
        }
        private void splitSC1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            cSplit.SplitBySortCode1(filePath, outfileFolder);
            stopwatch.Stop();
            MessageBox.Show(String.Format("Time Elapsed: {0}", stopwatch.Elapsed));
        }
        

        //
        // Event Handling methods.
        //
        private void btn_split_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            if (inFileIsSelected && outFolderIsSelected)
            {
                
                switch(splitType)
                {
                    case 1:
                        splitEven();
                        break;
                    case 2:
                        MessageBox.Show("Splitting by Specified Size.");
                        splitUneven();
                        MessageBox.Show("Done!");
                        break;
                    case 3:
                        
                        MessageBox.Show("Splitting by Sortcodes.");
                        splitSC1();
                        MessageBox.Show("Done!");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (!inFileIsSelected)
                {
                    MessageBox.Show("No Input File Selected.", "Error");
                }
                if (!outFolderIsSelected)
                {
                    MessageBox.Show("No Output Folder Selected.", "Error");
                }
            }
            this.UseWaitCursor = false;
                
        }

        private void frm_CSV_Splitter_Load(object sender, EventArgs e)
        {
            splitType = 1;
        }

        private void btn_SelectCSV_Click(object sender, EventArgs e)
        {
            if (ofd_inputCSV.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd_inputCSV.FileName;                
                
                txt_infile.Text = filePath;

                double numLines = findNumRecords(filePath);

                txt_numItems.Text = numLines.ToString();

                fileName = filePath.Split(new char[] { '\\' }).Last();
                frm_CSV_Splitter.ActiveForm.Text = "CSV Splitter (" + fileName + ")";

                inFileIsSelected = true;

                infile = new FileSplitter(filePath);
                cSplit = new SortCodeSplitter();
                
                numPerFile = infile.numRecords;
                numFiles = 1;
                numUD_numPerFile.Value = numPerFile;
                numUD_numFiles.Value = numFiles;

                tabcSplitOpts.Enabled = true;

            }
        }
        
        private void btn_selectOutPath_Click(object sender, EventArgs e)
        {
            if (fbd_outputFolder.ShowDialog() == DialogResult.OK)
            {
                outfileFolder = fbd_outputFolder.SelectedPath;
                txt_outFolder.Text = outfileFolder;
                outFolderIsSelected = true;

                infile.outPath = outfileFolder;
                infile.initCheck();
            }

        }
        
        private void txt_numItems_TextChanged(object sender, EventArgs e)
        {
            //numUD_numFiles.Value = 1;
            //numUD_numPerFile.Value = numItems();
        }


        /*private DataTable createDataTable(UnevenSplitter aSplitDetails)
        {
            // New Table.
            DataTable table = new DataTable("File Sizes");
            DataColumn column;
            DataRow row;
            string colName;

            // Get Max Columns.
            long numCols = aSplitDetails.numFiles;

            // Add columns.
            colName = "File #";
            column = new DataColumn(colName);
            column.DataType = System.Type.GetType("System.Int64");
            table.Columns.Add(column);

            colName = "Number of Records";
            column = new DataColumn(colName);
            column.DataType = System.Type.GetType("System.Int64");
            table.Columns.Add(column);

            // Add Rows.
            for (long fileNum = 1; fileNum <= numCols; fileNum++)
            {
                row = table.NewRow();
                row["File #"] = fileNum;
                row["Number of Records"] = aSplitDetails.avgSize;
                
                if (fileNum == numCols)
                {
                    row["Number of Records"] = aSplitDetails.findLastSize();
                }
                    
                table.Rows.Add(row);
            }

            return table;


        }
        */

        private void tabEvenSplit_Enter(object sender, EventArgs e)
        {
            splitType = 1;
        }
        private void tabSplitUnevenly_Enter(object sender, EventArgs e)
        {
            splitType = 2;
            if (inFileIsSelected)
            {
                uSplit = new UnevenSplitter((long) numOutFilesUneven.Value, infile.numRecords);
                createDGV(uSplit);
            }
        }
        private void tabSplitSortCode_Enter(object sender, EventArgs e)
        {
            splitType = 3;
        }
        
        private void numOutFilesUneven_ValueChanged(object sender, EventArgs e)
        {
            if (inFileIsSelected)
            {
                uSplit = new UnevenSplitter((long) numOutFilesUneven.Value, infile.numRecords);
                createDGV(uSplit);
            }
        }
        
        private void dgvUnevenSplit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dgvUnevenSplit[1,e.RowIndex]);
            dgvUnevenSplit.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvUnevenSplit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            long _index = Convert.ToInt64(e.RowIndex);
            long _val = Convert.ToInt64(dgvUnevenSplit.CurrentCell.Value);
            //MessageBox.Show(dgvUnevenSplit.CurrentCell.Value.ToString());
            uSplit.setSize(_index, _val);
            createDGV(uSplit);
        }

        private void dgvUnevenSplit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dgvUnevenSplit_KeyPress);
        }

        private void dgvUnevenSplit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(),@"\d") && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvUnevenSplit_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            long _value = Convert.ToInt64(e.FormattedValue);
            var _ri = e.RowIndex;
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dgvUnevenSplit.Rows[e.RowIndex].ErrorText = "Value must not be empty";
                e.Cancel = true;
            }
            else if (e.ColumnIndex == 1)
            {
                if(!uSplit.isValidSize((long) e.RowIndex, _value))
                {
                    dgvUnevenSplit.Rows[e.RowIndex].ErrorText = "Not a valid number of records";
                    e.Cancel = true;
                }

            }
        }



    }
}
