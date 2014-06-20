using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Dev.EDI
{
    class Order9Reader
    {
        private string _fileName;
        private List<string> errorLst;

        public Order9Reader(string fileName)
        {
            errorLst = new List<string>();
            _fileName = fileName;
            
        }

        public List<string> ErrorLst
        {
            get { return errorLst; }
        }

        public List<Order9> ReadOrders()
        {

            List<Order9> orderLst = new List<Order9>();

            try
            {
                string fileContent = ReadFile();

                TradacomsParser parser = new TradacomsParser(fileContent);

                SegmentList segList = parser.ParseMessage();


                Order9 order = null;
                Order9Type orderType = null;
                Order9Supplier supplier = null;
                Order9Customer customer = null;
                

                foreach (Segment seg in segList)
                {
                    switch (seg.SegmentName)
                    {
                        case "STX":
                            {
                                break;
                            }
                        case "TYP":
                            {
                                orderType = new Order9Type();
                                orderType.OrderTypeCode = seg.GetDataElement(0);
                                orderType.OrderType = seg.GetDataElement(1);

                                break;
                            }
                        case "SDT":
                            {
                                supplier = new Order9Supplier();
                                supplier.SupplierGLN = seg.GetDataElement(0);
                                supplier.SupplierName = seg.GetDataElement(1);

                                break;
                            }
                        case "CDT":
                            {
                                customer = new Order9Customer();
                                customer.CustomerGLN = seg.GetDataElement(0);
                                customer.CustomerName = seg.GetDataElement(1);

                                break;
                            }

                        case "FIL":
                            {
                                orderType.FileName = _fileName;
                                orderType.FileGenerationNo = seg.GetDataElement(0);
                                orderType.FileVersionNo = seg.GetDataElement(1);
                                orderType.FileCreationDate = ParseDate(seg.GetDataElement(2));

                                break;
                            }
                        case "MHD":
                            {
                                if (seg.GetDataElement(1).Equals("ORDERS"))
                                {
                                    order = new Order9(orderType, supplier, customer);
                                }
                                break;
                            }
                        case "CLO":
                            {
                                order.CustomerDepotGLN = seg.GetDataElement(0);
                                order.CustomerDepotCode = seg.GetDataElement(0, 1);
                                order.CustomerDepotAddress = seg.GetDataElement(2);

                                break;
                            }
                        case "ORD":
                            {
                                order.CustomerOrderNo = seg.GetDataElement(0);
                                order.OrderDate = ParseDate(seg.GetDataElement(0, 2));

                                break;
                            }
                        case "DIN":
                            {
                                order.DepotDate = ParseDate(seg.GetDataElement(0));
                                order.DepotTime = ParseTime(seg.GetDataElement(2));

                                break;
                            }
                        case "OLD":
                            {

                                Order9Line details = new Order9Line(order.Id);

                                details.LineNo = seg.GetDataElement(0);
                                details.ProductSupplierGTIN = seg.GetDataElement(1);
                                details.ProductSupplierCode = seg.GetDataElement(1, 1);
                                details.ProductGTIN = seg.GetDataElement(2);
                                details.ProductCustomerGTIN = seg.GetDataElement(3);
                                details.ProductCustomerCode = seg.GetDataElement(3, 1);
                                details.OrderUnit = ParseEDIInt(seg.GetDataElement(4));
                                details.OrderQty = ParseEDIInt(seg.GetDataElement(5));
                                details.ProductDescription = seg.GetDataElement(9);

                                order.Order9Lines.Add(details);

                                break;
                            }
                        case "OTR":
                            {
                                orderLst.Add(order);

                                break;
                            }
                        default:
                            break;
                    }



                }

                foreach (Segment seg in segList)
                {
                    if (!string.IsNullOrEmpty(seg.SegmentError))
                        errorLst.Add(seg.SegmentError);
                }
            }
            catch (Exception ex)
            {
                throw new Order9Exception("Error parsing TRADACOMS Order 9 File.\n" + ex.Message, ex);
            }

            return orderLst;
        }

        private string ReadFile()
        {
            try
            {
                StreamReader tr = new StreamReader(_fileName);
                string fileContent = tr.ReadToEnd();
                return fileContent;
            }
            catch (Exception)
            {
                throw new Order9Exception("Error reading file: " + _fileName);
            }
        }

        private DateTime ParseDate(string strDate)
        {
            try
            {
                return DateTime.ParseExact(strDate, "yyMMdd", null);
            }
            catch (Exception)
            {
                throw new Order9Exception("Error parsing Date: " + strDate);
            }
            
        }

        private TimeSpan ParseTime(string strTime)
        {
            try
            {
                if (string.IsNullOrEmpty(strTime))
                    strTime = "0000";

                return DateTime.ParseExact(strTime, "HHmm", null).TimeOfDay;
            }
            catch (Exception)
            {
                throw new Order9Exception("Error parsing Time: " + strTime);
            }
        }

        private Int32 ParseEDIInt(string str)
        {
            try
            {
                return Int32.Parse(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
