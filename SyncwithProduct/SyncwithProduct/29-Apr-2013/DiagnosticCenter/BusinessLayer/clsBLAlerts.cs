using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data;


namespace BusinessLayer
{
    public class clsBLAlerts
    {
        public clsBLAlerts()
        {
            /// Add Constructor logic here...
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "dc_tp_alerttypes";

        private string StrErrorMessage = "";


        private string _AlertTypeID = Default;

        


        private string _Description = Default;
        private string _Name = Default;
        private string _Type = Default;
        private string _Active = Default;
        private string _ProcessID = Default;

        
       

        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region properties
        public string AlertTypeID
        {
            get { return _AlertTypeID; }
            set { _AlertTypeID = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
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
                    objdbhims.Query = @"SELECT dta.AlertTypeID,dta.Name,dta.Description,dta.`Type`,dta.Active,dta.processID,tp.name Process,
                                        CASE WHEN dta.`Type`='S' THEN 'SMS' WHEN dta.`Type`='E' THEN 'E-Mail' END AS TypeDetail,
                                        CONCAT(dta.name,' | ',CASE WHEN dta.`Type`='S' THEN 'SMS' WHEN dta.`Type`='E' THEN 'E-Mail' END) AS DetailedName
                                        FROM dc_tp_alerttypes dta left outer Join dc_tp_tprocess tp on tp.processID=dta.processID where 1=1 ";
                    if (!_AlertTypeID.Equals(Default) && !_AlertTypeID.Equals(""))
                    {
                        objdbhims.Query += " and AlertTypeID=" + _AlertTypeID;
                    }
                    if (!_Active.Equals(Default) && !_Active.Equals(""))
                    {
                        objdbhims.Query += " and dta.Active='" + _Active + "'";
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

                    objdbhims.Query = objQB.QBGetMax("AlertTypeID", TableName);
                    this._AlertTypeID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._AlertTypeID.Equals("True"))
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

            if (!this._AlertTypeID.Equals(Default))
            {
                arySAPS[0, 0] = "AlertTypeID";
                arySAPS[0, 1] = this._AlertTypeID;
                arySAPS[0, 2] = "int";
            }

            if (!this._Name.Equals(Default))
            {
                arySAPS[1, 0] = "Name";
                arySAPS[1, 1] = this._Name;
                arySAPS[1, 2] = "string";
            }

            if (!this._Description.Equals(Default))
            {
                arySAPS[2, 0] = "Description";
                arySAPS[2, 1] = this._Description;
                arySAPS[2, 2] = "string";
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
            if (!this._ProcessID.Equals(Default))
            {
                arySAPS[8, 0] = "ProcessID";
                arySAPS[8, 1] = this._ProcessID;
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
