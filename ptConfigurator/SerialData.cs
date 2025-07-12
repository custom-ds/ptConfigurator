using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptConfigurator
{
    class SerialData
    {
        string m_strComInputBuffer;
        byte[] m_byComInputBuffer;

        private string[] m_aryComHistory = new string[1000];
        private bool m_bHistoryWrap = false;
        private int m_iHistoryEnd = -1;
        private bool m_bHistoryUpdated = true;


        private void collectSerialData(byte[] byInput)
        {
            string strIncoming = "";

            for (int i = 0; i < byInput.Length; i++)
            {
                char c = Convert.ToChar(byInput[i]);
                switch (c)
                {
                    case '\r':
                        //just put a newline char at the end of each line - drop \r's
                        strIncoming += "\n";
                        break;
                    case '\n':
                        strIncoming += "\n";
                        break;
                    default:
                        //parse out any non-printable chars

                        if (c >= ' ' && c <= '~')
                        {
                            strIncoming += Convert.ToString(c);
                        }
                        break;
                }
            }

            try
            {
                //do something with this new text-data
                //Console.WriteLine("Trying to do something with the TNC data");


                if (strIncoming != "")
                {
                    // we have some data - append it on to the end of the master (static) buffer

                    m_strComInputBuffer += strIncoming;

                    bool bFound = true;         //assume there's a line here
                    while (bFound)
                    {
                        int iPos = m_strComInputBuffer.IndexOf("\n");

                        if (iPos >= 1)
                        {
                            //we found something - leave the flag as true
                            string strTempLine = m_strComInputBuffer.Substring(0, iPos);

                            if (m_strComInputBuffer.Length > (iPos + 1))
                            {
                                // there's still some data left in here
                                m_strComInputBuffer = m_strComInputBuffer.Substring(iPos + 1);
                            }
                            else
                            {
                                //The member-buffer is empty - clear it out
                                m_strComInputBuffer = "";
                            }


                            this.pushFIFO(strTempLine);     //add this line to the TNC console view.

                        }
                        else
                        {
                            if (iPos == 0)
                            {
                                //the newline was at char 0 - just throw away the first char

                                if (m_strComInputBuffer.Length == 1)
                                {
                                    //that's all that was in the buffer - ditch it
                                    m_strComInputBuffer = "";
                                }
                                else
                                {
                                    m_strComInputBuffer = m_strComInputBuffer.Substring(1);
                                }
                            }
                            else
                            {
                                //iPos was < 0 - no newlines found
                                bFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void pushFIFO(string strLine)
        {
            this.m_iHistoryEnd++;
            if (this.m_iHistoryEnd >= 1000)
            {
                //we've wrapped around
                this.m_bHistoryWrap = true;
                this.m_iHistoryEnd = 0;
            }

            this.m_aryComHistory[this.m_iHistoryEnd] = strLine;
            this.m_bHistoryUpdated = true;      //set the flag that there's new history to see
        }

        public string getComHistory()
        {
            string strOut = "";

            this.m_bHistoryUpdated = false;     //reset the flag that history has already been viewed

            if (this.m_iHistoryEnd < 0) return "";      //there was no history - don't go any further

            ///TODO: Double check this logic for the counts.  We might be reproducing the first, middle or last entry.  
            if (this.m_bHistoryWrap)
            {
                //we've wrapped around, so pick up the bottom half of the array first
                for (int i = this.m_iHistoryEnd + 1; i < 1000; i++)
                {
                    strOut += this.m_aryComHistory[i] + "\r\n";
                }
            }

            for (int i = 0; i <= this.m_iHistoryEnd; i++)
            {
                strOut += this.m_aryComHistory[i] + "\r\n";
            }

            return strOut;
        }

        public bool NewHistory
        {
            get { return this.m_bHistoryUpdated; }
        }
    }
}
