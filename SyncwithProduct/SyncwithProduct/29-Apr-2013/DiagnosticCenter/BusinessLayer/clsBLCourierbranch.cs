using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsBLCourierbranch
    {
        public clsBLCourierbranch()
        {
            ///
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "dc_tp_CourierService";

        private string StrErrorMessage = "";

     

        private string _CourierServiceId = Default;

       
        private string _Name = Default;

       
        private string _Address = Default;
        private string _Email = Default;
        private string _City = Default;
        private string _Active = Default;
        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        private string _Phone = Default;
        private string _Phone2 = Default;
        private string _Fax = Default;
        private string _Mobile = Default;
        private string _BranchID = Default;

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion


        #region Properties
        public string CourierServiceId
        {
            get { return _CourierServiceId; }
            set { _CourierServiceId = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
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
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public string Phone2
        {
            get { return _Phone2; }
            set { _Phone2 = value; }
        }
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
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
                    objdbhims.Query = "Select * From "+ TableName+" where BranchID="+_BranchID;
                    break;
                case 2:
                    objdbhims.Query = "Select * From " + TableName + " where BranchID=" + _BranchID + " and Active='Y'";
                    break;
                case 3:
                    objdbhims.Query = "Select * From " + TableName + " where BranchID=" + _BranchID+" and CourierServiceID="+_CourierServiceId;
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

                    objdbhims.Query = objQB.QBGetMax("CourierServiceID", TableName);
                    this._CourierServiceId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._CourierServiceId.Equals("True"))
                    {
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
                    else
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    this.StrErrorMessage = e.Message;
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
            else
            {
                return false;
            }
        }

        private string[,] MakeArray()
        {
            string[,] arySAPS = new string[14, 3];

            if (!this._CourierServiceId.Equals(Default))
            {
                arySAPS[0, 0] = "CourierServiceId";
                arySAPS[0, 1] = this._CourierServiceId;
                arySAPS[0, 2] = "int";
            }

            if (!this._Name.Equals(Default))
            {
                arySAPS[1, 0] = "Name";
                arySAPS[1, 1] = this._Name;
                arySAPS[1, 2] = "string";
            }

            if (!this._Address.Equals(Default))
            {
                arySAPS[2, 0] = "Address";
                arySAPS[2, 1] = this._Address;
                arySAPS[2, 2] = "string";
            }

            if (!this._Email.Equals(Default))
            {
                arySAPS[3, 0] = "Email";
                arySAPS[3, 1] = this._Email;
                arySAPS[3, 2] = "string";
            }

            if (!this._Active.Equals(Default))
            {
                arySAPS[4, 0] = "Active";
                arySAPS[4, 1] = this.Active;
                arySAPS[4, 2] = "string";
            }

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[5, 0] = "Enteredby";
                arySAPS[5, 1] = this._Enteredby;
                arySAPS[5, 2] = "int";
            }

            if (!this._Enteredon.Equals(Default))
            {
                arySAPS[6, 0] = "Enteredon";
                arySAPS[6, 1] = this._Enteredon;
                arySAPS[6, 2] = "datetime";
            }

            if (!this._City.Equals(Default))
            {
                arySAPS[7, 0] = "City";
                arySAPS[7, 1] = this._City;
                arySAPS[7, 2] = "string";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[8, 0] = "ClientId";
                arySAPS[8, 1] = this._ClientId;
                arySAPS[8, 2] = "string";
            }
            if (!this._Phone.Equals(Default))
            {
                arySAPS[9, 0] = "Phone";
                arySAPS[9, 1] = this._Phone;
                arySAPS[9, 2] = "string";
            }
            if (!this._Phone2.Equals(Default))
            {
                arySAPS[10, 0] = "Phone2";
                arySAPS[10, 1] = this._Phone2;
                arySAPS[10, 2] = "string";
            }
            if (!this._Fax.Equals(Default))
            {
                arySAPS[11, 0] = "Fax";
                arySAPS[11, 1] = this._Fax;
                arySAPS[11, 2] = "string";
            }
            if (!this._Mobile.Equals(Default))
            {
                arySAPS[12, 0] = "Mobile";
                arySAPS[12, 1] = this._Mobile;
                arySAPS[12, 2] = "string";
            }
            if (!this._BranchID.Equals(Default))
            {
                arySAPS[13, 0] = "BranchID";
                arySAPS[13, 1] = this._BranchID;
                arySAPS[13, 2] = "int";
            }

            return arySAPS;
        }
        #endregion

        #region Validations
        private bool Validation()
        {
            return true;
        }
        #endregion
    }
}
