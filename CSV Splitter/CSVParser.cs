using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSV_Splitter
{
    public class CSVParser
    {
        // TO DO:
        // Add parsing to dictionary.
        // Add exception handling.

        //
        // Getters/Setters.
        private Regex rxCommaDelim = new Regex(@",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))", RegexOptions.Compiled);
        private char commaDelim = ',';

        public string inFile { get; set; }
        public string outPath { get; set; }
        public string fName { get; set; }

        public string StrHeader { get; private set; }
        public string[] ArrHeader { get; private set; }
        public string StrLine { get; private set; }
        public string[] ArrLine { get; private set; }

        //
        // Constructors;

        public CSVParser()
        {

        }

        public CSVParser(string aInFilePath)
        {
            inFile = aInFilePath;
        }

        //
        // Members.

        public void setLine (string aLine)
        {
            StrLine = aLine;
        }

        public void setAndParseLine(string aLine)
        {
            StrLine = aLine;
            fParseLine();
        }

        public void setAndParseHeader (string aHeader)
        {
            StrHeader = aHeader;
            ArrHeader = rxCommaDelim.Split(StrHeader);
            
            int loop = 0;
            foreach (string record in ArrHeader)
            {
                ArrHeader[loop] = record.Trim('\"');
                loop++;
            }
        }
        
        // sParseLine()
        // Simple parsing, does not check for quotes containing commas, nor trim quotes.
        // Converts StrLine to an array as ArrLine
        public void sParseLine()
        {
            ArrLine = StrLine.Split(commaDelim);
        }

        // fParseLine()
        // Full Parsing. Ignores commas within records and trims quotes surrounding records.
        // Converts StrLine to an array as ArrLine
        public void fParseLine()
        {
            ArrLine = rxCommaDelim.Split(StrLine);

            int loop = 0;
            foreach (string record in ArrLine)
            {
                ArrLine[loop] = record.Trim('\"');
                loop++;
            }
        }

        public void findFName()
        {
            if (File.Exists(inFile))
            {
                fName = Path.GetFileNameWithoutExtension(inFile);
            }
        }

        public long findNumRecords()
        {
            // Checked if file exists

            if (!File.Exists(inFile))
            {
                return 0;
            }

            long loopCounter = 0;
            string line;
            StreamReader reader = new StreamReader(inFile);
            
            // Count the number of lines;
            do
            {
                line = reader.ReadLine();
                loopCounter++;
            } while (reader.Peek() != -1);

            // Decrement count if last line is blank.
            if (String.IsNullOrWhiteSpace(line))
            {
                loopCounter--;
            }
            reader.Close();
            return loopCounter;
        }
    }
}
