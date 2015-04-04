using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsBLbranchAlerts
    {
        public clsBLbranchAlerts()
        {
             /// Add Constructor logic here...
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "dc_tp_branchalertsm";

        private string StrErrorMessage = "";

        private string _BranchAlertID = Default;
        private string _AlertID = Default;
        private string _BranchID = Default;
        
        private string _ExpiryDate = Default;
        private string _Rate = Default;
        private string _Active = Default;
        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region properties
        public string BranchAlertID
        {
            get { return _BranchAlertID; }
            set { _BranchAlertID = value; }
        }
        public string AlertID
        {
            get { return _AlertID; }
            set { _AlertID = value; }
        }
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public string ExpiryDate
        {
            get { return _ExpiryDate; }
            set { _ExpiryDate = value; }
        }
        public string Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }

        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
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
                    objdbhims.Query = @"SELECT dtb.BranchAlertID,dtb.BranchId,dtb.AlertID,dta.Name Alert_name,dtb2.Name,date_format(dtb.ExpiryDate,'%d/%m/%Y') ExpiryDate,dtb.Rate,dtb.Active,
                                        CASE WHEN dta.`Type`='S' THEN 'SMS' WHEN dta.`Type`='E' THEN 'E-Mail' END AS TypeDetail,
                                        CONCAT(dta.name,' | ',CASE WHEN dta.`Type`='S' THEN 'SMS' WHEN dta.`Type`='E' THEN 'E-Mail' END) AS DetailedName
                                        FROM dc_tp_branchalertsm dtb INNER JOIN dc_tp_branch dtb2 ON dtb2.BranchID = dtb.BranchID
                                        INNER JOIN dc_tp_alerttypes dta ON dta.AlertTypeID=dtb.AlertID

                                        WHERE 1=1";
                    if (!_BranchAlertID.Equals("") && !_BranchAlertID.Equals(Default))
                    {
                        objdbhims.Query += " and dtb.branchAlertID=" + _BranchAlertID;
                    }
                    if (!_Active.Equals(Default) && !_Active.Equals(""))
                    {
                        objdbhims.Query += " and dtb.Active='" + _Active + "'";
                    }
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and dtb.branchID=" + _BranchID;
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

                    objdbhims.Query = objQB.QBGetMax("BranchAlertID", TableName);
                    this._BranchAlertID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._BranchAlertID.Equals("True"))
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
            string[,] arySAPS = new string[9, 3];

            if (!this._BranchAlertID.Equals(Default))
            {
                arySAPS[0, 0] = "BranchAlertID";
                arySAPS[0, 1] = this._BranchAlertID;
                arySAPS[0, 2] = "int";
            }

            if (!this._AlertID.Equals(Default))
            {
                arySAPS[1, 0] = "AlertID";
                arySAPS[1, 1] = this._AlertID;
                arySAPS[1, 2] = "int";
            }

            if (!this._BranchID.Equals(Default))
            {
                arySAPS[2, 0] = "BranchID";
                arySAPS[2, 1] = this._BranchID;
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

            if (!this._ExpiryDate.Equals(Default))
            {
                arySAPS[5, 0] = "ExpiryDate";
                arySAPS[5, 1] = this._ExpiryDate;
                arySAPS[5, 2] = "datetime";
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
            if (!this._Rate.Equals(Default))
            {
                arySAPS[8, 0] = "Rate";
                arySAPS[8, 1] = this._Rate;
                arySAPS[8, 2] = "int";
            }

            


            return arySAPS;
        }
        #endregion

        #region Validation Functions
        private bool Validation()
        {
            return true;
        }
        #endregion
     

    }
}
