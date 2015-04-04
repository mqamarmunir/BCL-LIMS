using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data;
namespace BusinessLayer
{
   public class clsBlBankEntry
    {

        #region Class Variables

        private const string Default = "~!@";
        private const string TableName = "dc_tp_bankentry";
       
        private string StrErrorMessage = "";

        private string strlocation = Default;
        private string strcashier = Default;
        private string strdate = Default;
        private string strrptamount = Default;

        private string strbankamount = Default;
        private string strcomments = Default;
        private string strenteredon = Default;
        private string strenteredby = Default;
        private string strreportno = Default;

        





        #endregion

        #region Properties

        public string Location
        {
            get
            {
                return strlocation;
            }
            set
            {
                strlocation = value;
            }
        }
        public string Cashier
        {
            get
            {
                return strcashier;
            }
            set
            {
                strcashier = value;
            }
        }

        public string Date
        {
            get
            {
                return strdate;
            }
            set
            {
                strdate = value;
            }
        }
        public string ReportAmount
        {
            get
            {
                return strrptamount;
            }
            set
            {
                strrptamount = value;
            }
        }

        public string BankAmount
        {
            get
            {
                return strbankamount;
            }
            set
            {
               strbankamount = value;
            }
        }
        public string Comments
        {
            get
            {
                return strcomments;
            }
            set
            {
                strcomments = value;
            }
        }

        public string Reportno
        {
            get
            {
                return strreportno;
            }
            set
            {
                strreportno
                    = value;
            }
        }
        public string Enteredon
        {
            get
            {
                return strenteredon;
            }
            set
            {
                strenteredon = value;
            }
        }

        public string Enteredby
        {
            get
            {
                return strenteredby;
            }
            set
            {
                strenteredby = value;
            }
        }
        
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
        }
      

        #endregion


        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region Methods

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Insert()
        {
            
                try
                {
                    clsoperation objTrans = new clsoperation();
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();

                       objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        objTrans.End_Transaction();

                        if (this.StrErrorMessage.Equals("True"))
                        {
                            this.StrErrorMessage = objTrans.OperationError;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    
                }
                catch (Exception e)
                {
                    this.StrErrorMessage = e.Message;
                    return false;
                }
           
        }

        public bool Update()
        {
           
                clsoperation objTrans = new clsoperation();
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                objTrans.End_Transaction();

                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    return false;
                }
                else
                {
                    return true;
                }
            
        }

        private string[,] MakeArray()
        {
            string[,] arySAPS = new string[21, 3];

            if (!this.strlocation.Equals(Default))
            {
                arySAPS[0, 0] = "location";
                arySAPS[0, 1] = this.strlocation;
                arySAPS[0, 2] = "string";
            }

            if (!this.strcashier.Equals(Default))
            {
                arySAPS[1, 0] = "cashier";
                arySAPS[1, 1] = this.strcashier;
                arySAPS[1, 2] = "string";
            }

            if (!this.strdate.Equals(Default))
            {
                arySAPS[2, 0] = "date";
                arySAPS[2, 1] = this.strdate;
                arySAPS[2, 2] = "datetime";
            }

            if (!this.strrptamount.Equals(Default))
            {
                arySAPS[3, 0] = "Reportamount";
                arySAPS[3, 1] = this.strrptamount;
                arySAPS[3, 2] = "double";
            }

            if (!this.strbankamount.Equals(Default))
            {
                arySAPS[4, 0] = "bankamount";
                arySAPS[4, 1] = this.strbankamount;
                arySAPS[4, 2] = "double";
            }

            if (!this.strcomments.Equals(Default))
            {
                arySAPS[5, 0] = "comments";
                arySAPS[5, 1] = this.strcomments;
                arySAPS[5, 2] = "string";
            }

            if (!this.strenteredon.Equals(Default))
            {
                arySAPS[6, 0] = "enteredon";
                arySAPS[6, 1] = this.strenteredon;
                arySAPS[6, 2] = "datetime";
            }

            if (!this.strenteredby.Equals(Default))
            {
                arySAPS[7, 0] = "enteredby";
                arySAPS[7, 1] = this.strenteredby;
                arySAPS[7, 2] = "int";
            }

            return arySAPS;
        }

        #endregion

        #region "Validation Functions"

        //private bool Validation_Form()
        //{
        //    if (!VD_Method())
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        //private bool VD_Method()
        //{
        //    DataView dv = GetAll(10); // 6
        //    if (dv.Count > 0)
        //    {
        //        if (!_RangeId.Equals(Default) && !_RangeId.Equals("") && _RangeId != null)
        //            dv.RowFilter = "rangeid <>" + _RangeId;
        //        if (dv.Count > 0)
        //        {
        //            StrErrorMessage = "This gender and age is already configured with this method.";
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        #endregion
    }
}
