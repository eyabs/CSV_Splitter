using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Splitter
{
    public class FileSplitter
    {
        //
        // private:
        //

        private string _fPath;
        private string _fName;
        private string _outPath;

        private long _numRecords;
        private long _numFilesOut;
        private long _numRecordsOut;

        private bool _initialized;
        private bool _inFileSelected;
        private bool _outPathSelected;
        private bool _fileExists;
        

        //
        // Default Constructor
        public FileSplitter()
        {
            _inFileSelected = false;
            _outPathSelected = false;
        }

        //
        // Construcors with Arguments

        public FileSplitter(string aFPath)
        {
            _fPath = aFPath;
            initialize();
        }

        public FileSplitter(string aFPath, string aOutPath)
        {
            _fPath = aFPath;
            _outPath = aOutPath;
            _outPathSelected = true;
            initialize();
        }

        private void initialize()
        {
            _fileExists = File.Exists(_fPath);
            if(_fileExists)
            {
                findFName();
                findNumRecords();
                _inFileSelected = true;
            }
            else
            {
                _inFileSelected = false;
            }
            initCheck();
        }


        private void findFName()
        {
            if (File.Exists(_fPath))
            {
                _fName = Path.GetFileNameWithoutExtension(_fPath);
            }
        }

        private void findNumRecords()
        {
            StreamReader recordCounter = new StreamReader(_fPath);
            recordCounter.ReadLine();
            string line;
            long loopCounter = 0;
            do
            {
                line = recordCounter.ReadLine();
                loopCounter++;
            } while (recordCounter.Peek() != -1);
            
            // Checked for a blank last line.
            if (String.IsNullOrWhiteSpace(line))
            {
                loopCounter -= 1;
            }
            _numRecords = loopCounter;
        }
        private bool FileExistsCheck()
        {
            return File.Exists(_fPath);
        }
        //
        // public:
        //

         /*
        {
            get { return ; }
            set {  = value; } 
        }
        */

        // Getters and Setters.
        public void setPaths(string aFPath, string aOutPath)
        {
            _fPath = aFPath;
            _outPath = aOutPath;
            initialize();
        }
        public string outPath
        {
            get { return _outPath; }
            set { _outPath = value; }
        }
        /*
        public long numFilesOut 
        {
            get 
            { 
                return _numFilesOut; 
            }
            set { _numFilesOut = value; } 
        }
        public long numRecordsOut 
        {
            get { return _numRecordsOut; }
            set { _numRecordsOut = value; } 
        }*/
        public bool initCheck()
        {
            _initialized = (_inFileSelected && _outPathSelected && _fileExists);
            return _initialized;
        }

        // Readonly Getters.
        public string fPath { get { return _fPath; } }
        public string fName { get { return _fName; } }
        public long numRecords { get { return _numRecords; } }
        public bool fileExists { get { return _fileExists; } }
        public bool inFileSelected { get { return _inFileSelected; } }
        public bool outFileSelected { get { return _outPathSelected; } }
        public long numFilesOut
        {
            get { return _numFilesOut; }
            set { _numFilesOut = value; }
        }
        public long numRecordsOut
        {
            get { return _numRecordsOut; }
            set { _numRecordsOut = value; }
        }

        public void splitEven( long aNumFilesOut, long aNumRecordsOut)
        {
            string header;
            long inputLineNum = 1;
            long numLastOutFile = _numRecords - ((aNumFilesOut - 1) * aNumRecordsOut);
            StreamReader infile = new StreamReader(_fPath);
            StreamWriter outFile;

            header = infile.ReadLine();

            for (long fileNum = 1; fileNum <= aNumFilesOut; fileNum++)
            {
                if (fileNum < aNumFilesOut)
                {
                    outFile = new StreamWriter(_outPath + "\\" + _fName + "_" + fileNum + "_" + aNumRecordsOut + ".csv");
                    outFile.WriteLine(header);
                    for (long outputLineNum = 1; outputLineNum <= aNumRecordsOut; outputLineNum++)
                    {
                        outFile.WriteLine(infile.ReadLine());
                        inputLineNum++;
                    }
                    outFile.Close();
                    outFile.Dispose();
                }
                if (fileNum == aNumFilesOut)
                {
                    outFile = new StreamWriter(_outPath + "\\" + _fName + "_" + fileNum + "_" + numLastOutFile + ".csv");
                    outFile.WriteLine(header);
                    while (infile.Peek() != -1)
                    {
                        outFile.WriteLine(infile.ReadLine());
                        inputLineNum++;
                    }
                    outFile.Close();
                    outFile.Dispose();
                }
            }
            infile.Close();
        }



    }

    public class UnevenSplitter
    {
        // Private variables.
        private long[] _splitSizes;
        private long _lastFileSize;

        //Public Variables.
        public long index { get; private set; }
        public long fileSize { get; private set; }
        //public long lastFileSize { get; private set; }
        public long avgSize { get; private set; }
        public long numFiles { get; set; }
        public long numRecords { get; set; }
        public DataTable tblUnevenSplit;


        // Private Members.
        private void init()
        {
            for (long fileLoop = 0; fileLoop < numFiles; fileLoop++)
            {
                _splitSizes[fileLoop] = avgSize;
            }
            //lastFileSize = numRecords - (numFiles - 1);
            _splitSizes[numFiles - 1] = findLastSize();
            createDataTable();
        }

        private long findAvgSize()
        {
            return Convert.ToInt64(Math.Ceiling((double)numRecords / (double)numFiles));
        }

        private void createDataTable()
        {
            // New Table.
            tblUnevenSplit = new DataTable("File Sizes");
            DataColumn column;
            DataRow row;
            string colName;

            /*
            foreach (var item in list)
            {
                if (item.index > columns)
                {
                    columns = item.index;
                }
            }*/

            // Add columns.
            colName = "File #";
            column = new DataColumn(colName);
            column.DataType = System.Type.GetType("System.Int64");
            tblUnevenSplit.Columns.Add(column);

            colName = "Number of Records";
            column = new DataColumn(colName);
            column.DataType = System.Type.GetType("System.Int64");
            tblUnevenSplit.Columns.Add(column);

            // Add Rows.
            for (long fileNum = 1; fileNum <= numFiles; fileNum++)
            {
                row = tblUnevenSplit.NewRow();
                row["File #"] = fileNum;
                row["Number of Records"] = _splitSizes[fileNum - 1];

                /*if (fileNum == numFiles)
                {
                    row["Number of Records"] = _lastFileSize;
                }*/

                tblUnevenSplit.Rows.Add(row);
            }

        }


        // Public Members.

        // Constructor.
        public UnevenSplitter(long aNumFiles, long aNumRecords)
        {
            numFiles = aNumFiles;
            numRecords = aNumRecords;
            _splitSizes = new long[aNumFiles];
            avgSize = findAvgSize();
            findLastSize();
            init();
        }

        public long getSize(long aFileNum)
        {
            return _splitSizes[aFileNum];
        }

        public long findLastSize()
        {
            // Find the total number of records in all but the last output file.
            long sumRecords = 0;
            for (long fileNum = 0; fileNum < numFiles - 1; fileNum++ )
            {
                sumRecords += _splitSizes[fileNum];
            }

            // Assign then return the number of records for the last output file.
            _lastFileSize = numRecords - sumRecords;
            _splitSizes[numFiles - 1] = _lastFileSize;
            return _lastFileSize;
        }

        public void setSize(long aFileNum, long aNumRecords)
        {
            // Check if valid file number.
            if (aFileNum >= (numFiles - 1) || aFileNum < 0 )
            {
                return;
            }
            
            // Assign the value to the array.
            _splitSizes[aFileNum] = aNumRecords;

            // Update the Data Table.
            findLastSize();
            createDataTable();
        }

        // public bool isValidSize(long, long)
        // Returns true if the new size is OK
        public bool isValidSize(long aFileNum, long aNewSize)
        {
            // Check if file size is zero, or too big
            if (aNewSize <= 0 || (aNewSize - _splitSizes[aFileNum]) >= _lastFileSize )
            {
                return false;
            }
            else 
            { 
                return true; 
            }
        }

        public int split(string aInfile, string aOutPath)
        {
            if (!File.Exists(aInfile))
            {
                return 1;
            }

            StreamReader reader = new StreamReader(aInfile);
            StreamWriter writer;

            string infileName = Path.GetFileNameWithoutExtension(aInfile);
            string extension  = Path.GetExtension(aInfile);
            string outfileName;
            string header = reader.ReadLine();

            long loopCount = 1;

            // Loop Over Each file
            foreach ( long recCount in _splitSizes)
            {
                outfileName = String.Format("{0}\\{1}_{2}_{3}{4}",
                                            aOutPath, infileName, loopCount, recCount, extension);
                writer = new StreamWriter(outfileName);

                // Write the Header.
                writer.WriteLine(header);

                // Loop over each record.
                for (long recNum = 0; recNum < recCount; recNum++)
                {
                    writer.WriteLine(reader.ReadLine());
                }
                writer.Close();
                writer.Dispose();
                loopCount++;
            }
            reader.Close();
            reader.Dispose();

            return 0;
        }

    }

    public class SortCodeSplitter : CSVParser
    {
        private string[] sortCodes = new string[] { "Y2","Y1","Y0","S","N","L",
                                                    "D","C2","C1","A","9","6",
                                                    "5","19","18","14","10","Error" };

        Assembly _sortCodeAssembly;

        public int zipIndex { get; private set;}
        private long totalCount=0;
        public List<string> threeDigitZips = new List<string>();
        public List<string> sortCode1DB = new List<string>();
        //public List<string> sortCode2 = new List<string>();
        
        public SortCodeSplitter()
        {
            //init();
            //getCodes();
        }

        private void init()
        {
            getCodes();
        }

        private void getCodes()
        {
            _sortCodeAssembly = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(_sortCodeAssembly.GetManifestResourceStream("CSV_Splitter.sortcodes.csv"));
            do
            {
                setLine(reader.ReadLine());
                sParseLine();
                threeDigitZips.Add(ArrLine[0]);
                sortCode1DB.Add(ArrLine[1]);
                //sortCode2.Add(ArrLine[2]);
            }while (reader.Peek() != -1);
            reader.Close();
            reader.Dispose();
        }

        private void findZipIndex()
        {
            int index = 0;
            foreach (string title in ArrHeader)
            {
                if (title.ToUpper().StartsWith("ZIP"))
                {
                    zipIndex = index;
                    return;
                }
                index++;
            }
        }
        /*
        public int oldSplitBySortCode1( string aInFile, string aOutPath )
        {
            inFile = aInFile;
            outPath = aOutPath;

            // Check if the file exists.
            if (!File.Exists(aInFile))
            {
                // Return an error value.
                return -1;
            }
            findFName();
            getCodes();


            // get the header.
            StreamReader headerReader = new StreamReader(inFile);
            string header = headerReader.ReadLine();
            setAndParseHeader(header);
            headerReader.Close();
            findZipIndex();


            long errorCount = 0;


            foreach (string targetCode in sortCodes)
            {
                // Initializations / Declarations.
                string recordCode;
                int codeIndex;
                string outName = String.Format("{0}\\{1}_sc{2}.csv", aOutPath, fName, targetCode);
                StreamReader reader = new StreamReader(inFile);
                StreamWriter writer = new StreamWriter(outName);
                reader.ReadLine();
                setAndParseLine(reader.ReadLine());
                writer.WriteLine(StrHeader);

                
                long recordCount = 0;
                // Read the input file.
                do
                {
                    //frm_CSV_Splitter.progressBar1.Value = 100 * codeIndex / sortCodes.Length; 
                    setAndParseLine(reader.ReadLine());
                    codeIndex = threeDigitZips.IndexOf((ArrLine[zipIndex]).Substring(0,3));
                    try
                    {
                        recordCode = sortCode1DB[codeIndex];
                    }
                    catch
                    {
                        errorCount++;
                        recordCode = "error";
                    }
                    // Write if the sortcode is found.
                    if (String.Equals(targetCode, recordCode))
                    {
                        recordCount++;
                        writer.WriteLine(StrLine);
                    }

                } while (reader.Peek() != -1);
                
                // Close the readers/writers.
                reader.Close();
                reader.Dispose();
                writer.Close();
                writer.Dispose();
                
                // update total count.
                totalCount += recordCount;

                //Delete file if no records with the specific sortcode found.
                if(recordCount == 0)
                {
                    File.Delete(outName);
                }
                else
                {

                    // Rename the file to include the record count.
                    string newName = String.Format("{0}\\{1}_sc{2}_{3}.csv", aOutPath, fName, targetCode,recordCount);
                    File.Delete(newName);
                    File.Move(outName, newName);
                }
            }

            if (errorCount!=0)
            {
                totalCount += writeErrors();
            }
            //MessageBox.Show(totalCount.ToString());
            return 0;
        }
        */
        private long writeErrors()
        {
            // Write the header and Find the Zip Code Index.
            StreamReader headerReader = new StreamReader(inFile);
            string header = headerReader.ReadLine();
            setAndParseHeader(header);
            headerReader.Close();
            findZipIndex();

            // Initializations.
            StreamReader reader = new StreamReader(inFile);
            long errorCount = 0;
            string outErrorName = String.Format("{0}\\{1}_{2}.csv", outPath, fName, "errors");
            StreamWriter errorWriter = new StreamWriter(outErrorName);
            errorWriter.WriteLine(StrHeader);
            reader.ReadLine();

            // Write Error items to file.
            do
            {
                setAndParseLine(reader.ReadLine());
                // Write if Error.
                if (threeDigitZips.IndexOf((ArrLine[zipIndex]).Substring(0, 3)) == -1)
                {
                    errorCount++;
                    errorWriter.WriteLine(StrLine);
                }

            } while (reader.Peek() != -1);

            errorWriter.Close();
            errorWriter.Dispose();
            reader.Close();
            reader.Dispose();

            // Check if any Errors.
            if(errorCount == 0)
            {
                // Delete the file for the errors if non are found.
                File.Delete(outErrorName);
            }
            else
            {
                // Write the errors to the file
                string newName = String.Format("{0}\\{1}_{2}_{3}.csv", outPath, fName, "Errors",errorCount);
                
                // Delete file with name the same as the new name.
                File.Delete(newName);
                File.Move(outErrorName, newName);
            }

            // Return the number of Errors.
            return errorCount;
        }

        public int SplitBySortCode1( string aInFile, string aOutPath )
        {
            inFile = aInFile;
            outPath = aOutPath;
            int totalRecordCount = 0;
            
            // Counts of records corresponding to each sort code.
            List<int> codeCounts = new List<int>();
            // Initialize sort code counts to 0.
            foreach (string code in sortCodes)
            {
                codeCounts.Add(0);
            }


            // Check if the file exists.
            if (!File.Exists(aInFile))
            {
                // Return an error value.
                return -1;
            }
            findFName();
            getCodes();

           createOutFiles();
            /*
            using (StreamReader reader = new StreamReader(inFile))
            {
                setAndParseHeader(reader.ReadLine());
                foreach (string code in sortCodes)
                {
                    string outName = String.Format("{0}\\{1}_sc{2}.csv", outPath, fName, code);
                    using (StreamWriter writer = new StreamWriter(outName, false))
                    {
                        writer.WriteLine(StrHeader);
                    }
                }
            }*/

            findZipIndex();

            // Start reading the file.
            using (StreamReader reader = new StreamReader(aInFile))
            {
                int sortCodeIndex;
                string zipCode;
                string sortCode;
                string outName;
                do
                {
                    setAndParseLine(reader.ReadLine());

                    zipCode = ArrLine[zipIndex];
                    sortCodeIndex = threeDigitZips.IndexOf(zipCode.Substring(0, 3));
                    try
                    {
                        sortCode = sortCode1DB[sortCodeIndex];
                    }
                    catch
                    {
                        sortCode = "Error";
                    }
                    outName = String.Format("{0}\\{1}_sc{2}.csv", aOutPath, fName, sortCode);

                    using (StreamWriter writer = new StreamWriter(outName,true))
                    {
                        writer.WriteLine(StrLine);
                    }

                    totalRecordCount++;
                } while (reader.Peek() != -1);
            }
            //MessageBox.Show(numFailed.ToString() + " Records failed to write.");
            return totalRecordCount;

        }

        private void createOutFiles()
        {

            using (StreamReader reader = new StreamReader (inFile))
            {
                setAndParseHeader(reader.ReadLine());
                foreach (string code in sortCodes)
                {
                    string outName = String.Format("{0}\\{1}_sc{2}.csv", outPath, fName, code);
                    using (StreamWriter writer = new StreamWriter(outName, false))
                    {
                        writer.WriteLine(StrHeader);
                    }
                }
            }

        }

        private int findSortCodeIndex(string aSortCode)
        {
            int index;
            for (index = 0; index < 17; index++)
            {
                if (aSortCode.Equals(sortCodes[index])) return index;
            }
            return 17;
        }


    }
}
