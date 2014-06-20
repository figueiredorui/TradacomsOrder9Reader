using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev.EDI
{
    public class Order9
    {
        private Guid _Id;
        private String _OrderTypeCode;
        private String _OrderType;
        private String _SupplierGLN;
        private String _SupplierName;
        private String _CustomerGLN;
        private String _CustomerName;
        private String _FileGenerationNo;
        private String _FileVersionNo;
        private DateTime _FileCreationDate;
        private String _FileName;
        private String _CustomerDepotGLN;
        private String _CustomerDepotCode;
        private String _CustomerDepot;
        private String _CustomerDepotAddress;
        private String _CustomerOrderNo;
        private String _SupplierOrderNo;
        private DateTime _OrderDate;
        private DateTime _DepotDate;
        private TimeSpan _DepotTime;
        private List<Order9Line> _Order9Lines;

        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        
        public String OrderTypeCode
        {
            get
            {
                return _OrderTypeCode;
            }
            set
            {
                _OrderTypeCode = value;
            }
        }
        
        public String OrderType
        {
            get
            {
                return _OrderType;
            }
            set
            {
                _OrderType = value;
            }
        }

        public String SupplierGLN
        {
            get
            {
                return _SupplierGLN;
            }
            set
            {
                _SupplierGLN = value;
            }
        }

        public String SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
            }
        }

        public String CustomerGLN
        {
            get
            {
                return _CustomerGLN;
            }
            set
            {
                _CustomerGLN = value;
            }
        }

        public String CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }
        
        public String FileGenerationNo
        {
            get
            {
                return _FileGenerationNo;
            }
            set
            {
                _FileGenerationNo = value;
            }
        }
        
        public String FileVersionNo
        {
            get
            {
                return _FileVersionNo;
            }
            set
            {
                _FileVersionNo = value;
            }
        }

        public DateTime FileCreationDate
        {
            get
            {
                return _FileCreationDate;
            }
            set
            {
                _FileCreationDate = value;
            }
        }

        public String FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
        
        public String CustomerDepotGLN
        {
            get
            {
                return _CustomerDepotGLN;
            }
            set
            {
                _CustomerDepotGLN = value;
            }
        }
        
        public String CustomerDepotCode
        {
            get
            {
                return _CustomerDepotCode;
            }
            set
            {
                _CustomerDepotCode = value;
            }
        }
        
        public String CustomerDepot
        {
            get
            {
                return _CustomerDepot;
            }
            set
            {
                _CustomerDepot = value;
            }
        }
        
        public String CustomerDepotAddress
        {
            get
            {
                return _CustomerDepotAddress;
            }
            set
            {
                _CustomerDepotAddress = value;
            }
        }
        
        public String CustomerOrderNo
        {
            get
            {
                return _CustomerOrderNo;
            }
            set
            {
                _CustomerOrderNo = value;
            }
        }
        
        public String SupplierOrderNo
        {
            get
            {
                return _SupplierOrderNo;
            }
            set
            {
                _SupplierOrderNo = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
            }
        }

        public DateTime DepotDate
        {
            get
            {
                return _DepotDate;
            }
            set
            {
                _DepotDate = value;
            }
        }
        
        public TimeSpan DepotTime
        {
            get
            {
                return _DepotTime;
            }
            set
            {
                _DepotTime = value;
            }
        }

        public List<Order9Line> Order9Lines
        {
            get
            {
                return _Order9Lines;
            }
            set
            {
                _Order9Lines = value;
            }
        }

        public Order9()
        {
            _Id = Guid.NewGuid();
            _Order9Lines = new List<Order9Line>();
        }

        public Order9(Order9Type ordeType, Order9Supplier supplier, Order9Customer customer)
        {
            _Id = Guid.NewGuid();
            _Order9Lines = new List<Order9Line>();

            this.OrderTypeCode = ordeType.OrderTypeCode;
            this.OrderType = ordeType.OrderType;

            this.CustomerGLN = customer.CustomerGLN;
            this.CustomerName = customer.CustomerName;

            this.SupplierGLN = supplier.SupplierGLN;
            this.SupplierName = supplier.SupplierName;

            this.FileName = ordeType.FileName;
            this.FileGenerationNo = ordeType.FileGenerationNo;
            this.FileVersionNo = ordeType.FileVersionNo;
            this.FileCreationDate = ordeType.FileCreationDate;
        }

    }

    public class Order9Line 
    {
        private Guid _OrderId;
        private String _LineNo;
        private String _ProductSupplierGTIN;
        private String _ProductSupplierCode;
        private String _ProductGTIN;
        private String _ProductCustomerGTIN;
        private String _ProductCustomerCode;
        private Int32 _OrderUnit;
        private Int32 _OrderQty;
        private Decimal _OrderUnitPrice;
        private String _ProductDescription;

        public Guid OrderId
        {
            get
            {
                return _OrderId;
            }
            set
            {
                _OrderId = value;
            }
        }
        
        public String LineNo
        {
            get
            {
                return _LineNo;
            }
            set
            {
                _LineNo = value;
            }
        }
        
        public String ProductSupplierGTIN
        {
            get
            {
                return _ProductSupplierGTIN;
            }
            set
            {
                _ProductSupplierGTIN = value;
            }
        }
        
        public String ProductSupplierCode
        {
            get
            {
                return _ProductSupplierCode;
            }
            set
            {
                _ProductSupplierCode = value;
            }
        }
        
        public String ProductGTIN
        {
            get
            {
                return _ProductGTIN;
            }
            set
            {
                _ProductGTIN = value;
            }
        }
        
        public String ProductCustomerGTIN
        {
            get
            {
                return _ProductCustomerGTIN;
            }
            set
            {
                _ProductCustomerGTIN = value;
            }
        }
        
        public String ProductCustomerCode
        {
            get
            {
                return _ProductCustomerCode;
            }
            set
            {
                _ProductCustomerCode = value;
            }
        }
        
        public Int32 OrderUnit
        {
            get
            {
                return _OrderUnit;
            }
            set
            {
                _OrderUnit = value;
            }
        }

        public Int32 OrderQty
        {
            get
            {
                return _OrderQty;
            }
            set
            {
                _OrderQty = value;
            }
        }
        
        public Decimal OrderUnitPrice
        {
            get
            {
                return _OrderUnitPrice;
            }
            set
            {
                _OrderUnitPrice = value;
            }
        }
        
        public String ProductDescription
        {
            get
            {
                return _ProductDescription;
            }
            set
            {
                _ProductDescription = value;
            }
        }

        public Order9Line(Guid orderId)
        {
            _OrderId = orderId;
        }
        

    }

    public class Order9Customer
    {
        private String _CustomerGLN;
        private String _CustomerName;

        public String CustomerGLN
        {
            get
            {
                return _CustomerGLN;
            }
            set
            {
                _CustomerGLN = value;
            }
        }

        public String CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }

    }

    public class Order9Supplier
    {
        private String _SupplierGLN;
        private String _SupplierName;

        public String SupplierGLN
        {
            get
            {
                return _SupplierGLN;
            }
            set
            {
                _SupplierGLN = value;
            }
        }

        public String SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
            }
        }

    }

    public class Order9Type
    {
        private String _OrderTypeCode;
        private String _OrderType;
        private String _FileGenerationNo;
        private String _FileVersionNo;
        private DateTime _FileCreationDate;
        private String _FileName;

        public String OrderTypeCode
        {
            get
            {
                return _OrderTypeCode;
            }
            set
            {
                _OrderTypeCode = value;
            }
        }

        public String OrderType
        {
            get
            {
                return _OrderType;
            }
            set
            {
                _OrderType = value;
            }
        }

        public String FileGenerationNo
        {
            get
            {
                return _FileGenerationNo;
            }
            set
            {
                _FileGenerationNo = value;
            }
        }

        public String FileVersionNo
        {
            get
            {
                return _FileVersionNo;
            }
            set
            {
                _FileVersionNo = value;
            }
        }

        public DateTime FileCreationDate
        {
            get
            {
                return _FileCreationDate;
            }
            set
            {
                _FileCreationDate = value;
            }
        }

        public String FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }

        
    }

}
