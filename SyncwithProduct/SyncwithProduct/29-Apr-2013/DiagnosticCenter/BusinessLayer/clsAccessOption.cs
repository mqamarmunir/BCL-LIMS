using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
    public class clsAccessOption
    {
        #region Class Variables

        private const string Default = "~!@";
        private const string TableName = "dc_tu_accessoption";        
        private string StrErrorMessage = "";

        private string _OptionId = Default;
        private string _OptionName = Default;
        private string _Type = Default;
        private string _Active = Default;
        private string _EventActive = Default;
        private string _Description = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        #endregion

        #region Properties
        public string OptionId
        {
            get
            {
                return _OptionId;
            }
            set
            {
                _OptionId = value;
            }
        }

        public string OptionName
        {
            get
            {
                return _OptionName;
            }
            set
            {
                _OptionName = value;
            }
        }

        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        public string Active
        {
            get
            {
                return _Active;
            }
            set
            {
                _Active = value;
            }
        }

        public string EventActive
        {
            get
            {
                return _EventActive;
            }
            set
            {
                _EventActive = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        public string Enteredby
        {
            get
            {
                return _Enteredby;
            }
            set
            {
                _Enteredby = value;
            }
        }

        public string Enteredon
        {
            get
            {
                return _Enteredon;
            }
            set
            {
                _Enteredon = value;
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
                    objdbhims.Query = "select t.OptionId,t.OptionName,t.Description,t.Type,t.Active,t.EventActive from " + TableName + " t where 1=1";
                    if (!this._Type.Equals(Default))
                    {
                        objdbhims.Query += " and t.Type = '" + _Type + "'";
                    }
                    objdbhims.Query += " order by t.OptionName";
                    break;

                case 2:
                    objdbhims.Query = "select t.OptionId,t.OptionName from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.OptionName) = '" + this._OptionName.ToUpper() + "'";
                    break;

                case 3:
                    objdbhims.Query = "select OptionName,Description,Type,Active,EventActive from " + TableName + " where OptionId=" + _OptionId;
                    break;

                case 4:
                    objdbhims.Query = "select OptionName,OptionId from " + TableName + " t where t.Active='Y'";
                    break;

                case 5:
                    objdbhims.Query = "select OptionName,OptionId from " + TableName + " t where t.Active='Y'";
                    if (!this._Type.Equals(Default))
                    {
                        objdbhims.Query += " and t.Type = '" + _Type + "'";
                    }
                    objdbhims.Query += " order by t.OptionName";
                    break;

                case 6:
                    objdbhims.Query = "select OptionName,OptionId from " + TableName + " t where t.Active='Y' and t.EventActive = 'Y'";
                    if (!this._Type.Equals(Default))
                    {
                        objdbhims.Query += " and t.Type = '" + _Type + "'";
                    }
                    objdbhims.Query += " order by t.OptionName";
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

                    objdbhims.Query = objQB.QBGetMax("OptionId", TableName);
                    this._OptionId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._OptionId.Equals("True"))
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
            string[,] arySAPS = new string[8, 3];

            if (!this._OptionId.Equals(Default))
            {
                arySAPS[0, 0] = "OptionId";
                arySAPS[0, 1] = this._OptionId;
                arySAPS[0, 2] = "int";
            }

            if (!this._OptionName.Equals(Default))
            {
                arySAPS[1, 0] = "OptionName";
                arySAPS[1, 1] = this._OptionName;
                arySAPS[1, 2] = "string";
            }

            if (!this._Type.Equals(Default))
            {
                arySAPS[2, 0] = "Type";
                arySAPS[2, 1] = this._Type;
                arySAPS[2, 2] = "string";
            }

            if (!this._Active.Equals(Default))
            {
                arySAPS[3, 0] = "Active";
                arySAPS[3, 1] = this._Active;
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

            if (!this._EventActive.Equals(Default))
            {
                arySAPS[6, 0] = "EventActive";
                arySAPS[6, 1] = this._EventActive;
                arySAPS[6, 2] = "string";
            }

            if (!this._Description.Equals(Default))
            {
                arySAPS[7, 0] = "Description";
                arySAPS[7, 1] = this._Description;
                arySAPS[7, 2] = "string";
            }

            return arySAPS;
        }

        #endregion

        #region "Validation Functions"

        private bool Validation()
        {
            if (!VD_AccessOption())
            {
                return false;
            }
            return true;
        }

        public bool VD_AccessOption()
        {

            if (this._OptionName.Equals(""))
            {
                this.StrErrorMessage = "Please Enter Option Name. (empty is not allowed)";
                return false;
            }

            DataView dvTest = GetAll(2);

            if (!this._OptionId.Equals(Default))
            {
                dvTest.RowFilter = "OptionId <> '" + _OptionId + "' And OptionName = '" + _OptionName + "'";
            }
            else
            {
                dvTest.RowFilter = "OptionName = '" + _OptionName + "'";
            }

            if (dvTest.Count > 0)
            {
                this.StrErrorMessage = "Please Enter another Option Name, it is already present.";
                return false;
            }

            return true;
        }

        #endregion

    }
}

