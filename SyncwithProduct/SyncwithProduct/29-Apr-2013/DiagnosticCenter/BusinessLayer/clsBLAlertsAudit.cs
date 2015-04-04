using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsBLAlertsAudit
    {
        public clsBLAlertsAudit()
        {
            /// Add Constructor logic here...
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "dc_tp_alerts_audit";

        private string StrErrorMessage = "";


        private string _AuditAlertID = Default;

        private string _BranchID = Default;
        private string _AlertType = Default;
        private string _SentTo = Default;
        private string _AlertID = Default;




        private string _ClientId = Default;
        private string _SentBy = Default;
        private string _Senton = Default;

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string AuditAlertID
        {
            get { return _AuditAlertID; }
            set { _AuditAlertID = value; }
        }
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public string AlertType
        {
            get { return _AlertType; }
            set { _AlertType = value; }
        }
        public string SentTo
        {
            get { return _SentTo; }
            set { _SentTo = value; }
        }
        public string AlertID
        {
            get { return _AlertID; }
            set { _AlertID = value; }
        }
        public string ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }
        public string SentBy
        {
            get { return _SentBy; }
            set { _SentBy = value; }
        }
        public string Senton
        {
            get { return _Senton; }
            set { _Senton = value; }
        }
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }
        #endregion

        #region methods

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = @"";
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

                    objdbhims.Query = objQB.QBGetMax("AuditAlertID", TableName);
                    this._AuditAlertID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._AuditAlertID.Equals("True"))
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

        private string[,] MakeArray()
        {
            string[,] arySAPS = new string[8, 3];

            if (!this._AuditAlertID.Equals(Default))
            {
                arySAPS[0, 0] = "AuditAlertID";
                arySAPS[0, 1] = this._AuditAlertID;
                arySAPS[0, 2] = "int";
            }

            if (!this._BranchID.Equals(Default))
            {
                arySAPS[1, 0] = "BranchID";
                arySAPS[1, 1] = this._BranchID;
                arySAPS[1, 2] = "int";
            }

            if (!this._SentTo.Equals(Default))
            {
                arySAPS[2, 0] = "SentTo";
                arySAPS[2, 1] = this._SentTo;
                arySAPS[2, 2] = "string";
            }

            if (!this._AlertID.Equals(Default))
            {
                arySAPS[3, 0] = "AlertID";
                arySAPS[3, 1] = this._AlertID;
                arySAPS[3, 2] = "int";
            }

            if (!this._SentBy.Equals(Default))
            {
                arySAPS[4, 0] = "SentBy";
                arySAPS[4, 1] = this._SentBy;
                arySAPS[4, 2] = "int";
            }

            if (!this._Senton.Equals(Default))
            {
                arySAPS[5, 0] = "Senton";
                arySAPS[5, 1] = this._Senton;
                arySAPS[5, 2] = "datetime";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[6, 0] = "ClientId";
                arySAPS[6, 1] = this._ClientId;
                arySAPS[6, 2] = "string";
            }

            if (!this._AlertType.Equals(Default))
            {
                arySAPS[7, 0] = "AlertType";
                arySAPS[7, 1] = this._AlertType;
                arySAPS[7, 2] = "strng";
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
