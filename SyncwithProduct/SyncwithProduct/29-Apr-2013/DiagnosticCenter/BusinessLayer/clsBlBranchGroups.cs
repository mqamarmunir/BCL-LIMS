using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsBLBranchGroups
    {
        public clsBLBranchGroups()
        {
            ///Add Constructor logic here...
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "dc_tp_BranchGroups";

        private string StrErrorMessage = "";

        private string _BranchGroupID = Default;


        private string _BranchID = Default;
        private string _GroupID = Default;


        private string _Active = Default;

        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;


        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #endregion

        #region Properties
        public string BranchGroupID
        {
            get { return _BranchGroupID; }
            set { _BranchGroupID = value; }
        }
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public string GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
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

        #region methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select bp.branchgroupid,bp.branchID,bp.groupid,p.Name PanelName From " + TableName + " bp inner join dc_tp_groupm p on p.groupid=bp.groupid where bp.Active='Y' and bp.branchID=" + _BranchID;
                    break;
                case 2:
                    objdbhims.Query = "Select * From " + TableName + " where BranchID=" + _BranchID + " and GroupID=" + _GroupID + " and Active='Y'";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        public bool Insert()
        {
            if (Validation() && Vd_chkduplicate())
            {
                try
                {
                    clsoperation objTrans = new clsoperation();
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("BranchGroupID", TableName);
                    this._BranchGroupID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._BranchGroupID.Equals("True"))
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

        private bool Delete()
        {
            objdbhims.Query = "Update "+ TableName+ " set Active='N',EnteredBy=" + Convert.ToInt32(_Enteredby) + " where BranchGroupID=" + Convert.ToInt32(_BranchGroupID);
            objTrans.Start_Transaction();
            StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
            if (StrErrorMessage.Equals("True"))
            {
                this.StrErrorMessage = objTrans.OperationError;
                return false;
            }
            return true;

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
            string[,] arySAPS = new string[7, 3];

            if (!this._BranchGroupID.Equals(Default))
            {
                arySAPS[0, 0] = "BranchGroupID";
                arySAPS[0, 1] = this._BranchGroupID;
                arySAPS[0, 2] = "int";
            }

            if (!this._BranchID.Equals(Default))
            {
                arySAPS[1, 0] = "BranchID";
                arySAPS[1, 1] = this._BranchID;
                arySAPS[1, 2] = "int";
            }
            if (!this._GroupID.Equals(Default))
            {
                arySAPS[2, 0] = "GroupID";
                arySAPS[2, 1] = this._GroupID;
                arySAPS[2, 2] = "int";
            }

            if (!this.Active.Equals(Default))
            {
                arySAPS[3, 0] = "Active";
                arySAPS[3, 1] = this.Active;
                arySAPS[3, 2] = "string";
            }

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[4, 0] = "Enteredby";
                arySAPS[4, 1] = this._Enteredby;
                arySAPS[4, 2] = "int";
            }

            if (!this._Enteredon.Equals(Default))
            {
                arySAPS[5, 0] = "Enteredon";
                arySAPS[5, 1] = this._Enteredon;
                arySAPS[5, 2] = "datetime";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[6, 0] = "ClientId";
                arySAPS[6, 1] = this._ClientId;
                arySAPS[6, 2] = "string";
            }




            return arySAPS;
        }

        #endregion

        #region Validations
        private bool Validation()
        {
            if (!VD_Organization())
            {
                return false;
            }
            if (!VD_Branch())
            {
                return false;
            }

            return true;
        }

        private bool VD_Organization()
        {
            if (_ClientId == "-1" || _ClientId == Default)
            {
                StrErrorMessage = "please Select Organization";
                return false;
            }
            return true;
        }

        private bool VD_Branch()
        {
            if (_BranchID == Default || _BranchID == "-1")
            {
                StrErrorMessage = "please Select Branch";
                return false;
            }
            return true;
        }

        private bool Vd_chkduplicate()
        {
            DataView dv_chk = GetAll(2);
            if (dv_chk.Count > 0)
            {
                dv_chk.Dispose();
                StrErrorMessage = "Selected Panel already exists against this branch";
                return false;

            }
            return true;
        }
        #endregion

    }
}

