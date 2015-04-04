using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsBLBranchAlertsD
    {

        public clsBLBranchAlertsD()
        {
            /// Add Constructor logic here...
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "dc_tp_branchAlertsD";

        private string StrErrorMessage = "";


        private string _branchAlertDid = Default;

        private string _BranchID = Default;
        private string _BranchAlertID = Default;
        
        private string _Subject = Default;

        private string _header = Default;
        private string _footer = Default;
        private string _Type = Default;
        private string _Active = Default;
        private string _ProcessID = Default;

      




        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string branchAlertDid
        {
            get { return _branchAlertDid; }
            set { _branchAlertDid = value; }
        }
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public string BranchAlertID
        {
            get { return _BranchAlertID; }
            set { _BranchAlertID = value; }
        }
        
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        public string header
        {
            get { return _header; }
            set { _header = value; }
        }
        public string footer
        {
            get { return _footer; }
            set { _footer = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public string ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }
        public string ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }
        public string Enteredby
        {
            get { return _Enteredby; }
            set { _Enteredby = value; }
        }
        public string Enteredon
        {
            get { return _Enteredon; }
            set { _Enteredon = value; }
        }
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }
        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = @"SELECT dtb.branchAlertDid,dtb.BranchAlertID,
                                        dtb.`Subject`,dtb.header,dtb.Footer,dtb.`Type`,dta.name Alert_Name,dtb.Active,
                                        CASE WHEN dta.`Type`='S' THEN 'SMS' ELSE 'E-Mail' END AS TypeDetail,dta.AlertTypeID
                                         FROM dc_tp_branchalertsd dtb INNER JOIN dc_tp_branchalertsm dtb2 ON dtb2.BranchAlertID = dtb.BranchAlertID
                                         INNER JOIN dc_tp_alerttypes dta ON dta.AlertTypeID=dtb2.AlertID

                                        WHERE 1=1 and dtb2.Active='Y' and dta.Active='Y'";
                    if (!_branchAlertDid.Equals("") && !_branchAlertDid.Equals(Default))
                    {
                        objdbhims.Query += " and dtb.BranchAlertDid=" + _branchAlertDid;
                    }
                    if (!_Active.Equals("") && !_Active.Equals(Default))
                    {
                        objdbhims.Query += " and dtb.Active='" + _Active + "'";
                    }
                    if (!_BranchID.Equals("") && !_BranchID.Equals(Default))
                    {
                        objdbhims.Query += " and dtb2.BranchID=" + _BranchID;
                    }
                    if (!_Type.Equals(Default) && !_Type.Equals(""))
                    {
                        objdbhims.Query += " and dtb.Type='" + _Type + "'";
                    }
                    if (!_ProcessID.Equals("") && !_ProcessID.Equals(Default))
                    {
                        objdbhims.Query += " and dta.processID=" + _ProcessID;
                    }

                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Insert()
        {
            if (Validation())
            {
                try
                {
                    clsoperation objTrans = new clsoperation();
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("branchAlertDid", TableName);
                    this._branchAlertDid = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._branchAlertDid.Equals("True"))
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.ErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        objTrans.End_Transaction();

                        if (this.ErrorMessage.Equals("True"))
                        {
                            this.ErrorMessage = objTrans.OperationError;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        this.ErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    this.ErrorMessage = e.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Update()
        {
            if (Validation())
            {
                clsoperation objTrans = new clsoperation();
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                this.ErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                objTrans.End_Transaction();

                if (this.ErrorMessage.Equals("True"))
                {
                    this.ErrorMessage = objTrans.OperationError;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {

                return false;
            }
        }

        private string[,] MakeArray()
        {
            string[,] arySAPS = new string[10, 3];

            if (!this._branchAlertDid.Equals(Default))
            {
                arySAPS[0, 0] = "branchAlertDid";
                arySAPS[0, 1] = this._branchAlertDid;
                arySAPS[0, 2] = "int";
            }

            if (!this._footer.Equals(Default))
            {
                arySAPS[1, 0] = "footer";
                arySAPS[1, 1] = this._footer;
                arySAPS[1, 2] = "string";
            }

            if (!this._BranchAlertID.Equals(Default))
            {
                arySAPS[2, 0] = "BranchAlertID";
                arySAPS[2, 1] = this._BranchAlertID;
                arySAPS[2, 2] = "int";
            }

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[3, 0] = "Enteredby";
                arySAPS[3, 1] = this._Enteredby;
                arySAPS[3, 2] = "int";
            }

            if (!this._Enteredon.Equals(Default))
            {
                arySAPS[4, 0] = "Enteredon";
                arySAPS[4, 1] = this._Enteredon;
                arySAPS[4, 2] = "datetime";
            }

            if (!this._Type.Equals(Default))
            {
                arySAPS[5, 0] = "Type";
                arySAPS[5, 1] = this._Type;
                arySAPS[5, 2] = "string";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[6, 0] = "ClientId";
                arySAPS[6, 1] = this._ClientId;
                arySAPS[6, 2] = "string";
            }
            if (!this._Active.Equals(Default))
            {
                arySAPS[7, 0] = "Active";
                arySAPS[7, 1] = this._Active;
                arySAPS[7, 2] = "string";
            }

            
            if (!this._Subject.Equals(Default))
            {
                arySAPS[8, 0] = "Subject";
                arySAPS[8, 1] = this._Subject;
                arySAPS[8, 2] = "string";
            }
            if (!this._header.Equals(Default))
            {
                arySAPS[9, 0] = "header";
                arySAPS[9, 1] = this._header;
                arySAPS[9, 2] = "string";
            }
            



            return arySAPS;
        }
        #endregion

        #region Valdiation Fuinctions
        private bool Validation()
        {
            return true;
        }
        #endregion
    }
}
