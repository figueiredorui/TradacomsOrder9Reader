using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev.EDI
{
    class TradacomsParser
    {
        private char[] delimiterSeg = { '\'' };
        private char[] delimiterDataElem = { '=', '+' };
        private char[] delimiterDataSubElem = { ':' };

        private string _fileContent = string.Empty;

        public TradacomsParser(string fileMessage)
        {
            _fileContent = fileMessage;
        }

        public SegmentList ParseMessage()
        {
            SegmentList segList = new SegmentList();

            string[] fileSegments = _fileContent.Split(delimiterSeg);

            foreach (string str in fileSegments)
            {
                Segment seg = ParseSegment(str);

                segList.Add(seg);
            }

            return segList;
        }

        private Segment ParseSegment(string _segment)
        {
            string[] strSeg = _segment.Split(delimiterDataElem);

            Segment seg = new Segment();
            
            for (Int32 i = 0; i < strSeg.Length; i++)
            {
                if (i == 0)
                {	
                    // get segmentName
                    seg.SegmentName = strSeg[i];
                    continue;
                }

                string[] strDataElem = strSeg[i].Split(delimiterDataSubElem);

                DataElement dataElem = new DataElement();

                for (Int32 j = 0; j < strDataElem.Length; j++)
                {
                    DataSubElement dataSubElem = new DataSubElement();
                    dataSubElem.Value = strDataElem[j];
                    dataElem.DataSubElement.Add(dataSubElem);
                }

                seg.DataElement.Add(dataElem);
            }

            return seg;
        }
    }

    public class SegmentList : List<Segment>
    {
        public SegmentList()
        {
            
        }

    }

    public class Segment
    {
        private string segmentError = string.Empty;

        private string segmentName = string.Empty;
        private List<DataElement> dataElementLst = null;

        public Segment()
        {
            dataElementLst = new List<DataElement>();
        }

        public string SegmentName
        {
            get { return segmentName; }
            set { segmentName = value; }
        }

        public List<DataElement> DataElement
        {
            get { return dataElementLst; }
            set { dataElementLst = value; }
        }

        public string SegmentError
        {
            get { return segmentError; }
        }

        public string GetDataElement(int position)
        {
            return GetDataElement(position, 0);
        }

        public string GetDataElement(int position, int subPosition)
        {
            try
            {
                return dataElementLst[position].DataSubElement[subPosition].Value;
            }
            catch
            {
                segmentError = string.Format("{0} - Element [{1},{2}] not found.", segmentName, position, subPosition);
                return "";
            }

        }

       

    }

    public class DataElement
    {
        private List<DataSubElement> dataSubElementLst = null;

        public DataElement()
        {
            dataSubElementLst = new List<DataSubElement>();
        }

        public List<DataSubElement> DataSubElement 
        {
            get { return dataSubElementLst; }
            set { dataSubElementLst = value; } 
        }

    }

    public class DataSubElement
    {
        private string _value = string.Empty;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public DataSubElement()
        {
        }
    }
}
