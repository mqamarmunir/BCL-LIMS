using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
    public class clsAccessGroup
    {
        #region Class Variables

        private const string Default = "~!@";
        private const string TableName = "dc_tu_accessgroup";        
        private string StrErrorMessage = "";

        private string _GroupId = Default;
        private string _GroupName = Default;
        private string _Description = Default;
        private string _Active = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;

        #endregion

        #region Properties
        public string GroupId
        {
            get
            {
                return _GroupId;
            }
            set
            {
                _GroupId = value;
            }
        }

        public string GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                _GroupName = value;
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
                    objdbhims.Query = "select t.GroupId,t.GroupName,t.Description,t.Active from " + TableName + " t order by t.GroupName";
                    break;

                case 2:
                    objdbhims.Query = "select t.GroupId,t.GroupName,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.GroupName) = '" + this._GroupName.ToUpper() + "'";
                    break;

                case 3:
                    objdbhims.Query = "select GroupName,Description,Active from " + TableName + " where GroupId=" + _GroupId;
                    break;

                case 4:
                    objdbhims.Query = "select GroupName,GroupId from " + TableName + " t where t.Active='Y' order by t.GroupName";
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

                    objdbhims.Query = objQB.QBGetMax("GroupId", TableName);
                    this._GroupId = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._GroupId.Equals("True"))
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
            string[,] arySAPS = new string[6, 3];

            if (!this._GroupId.Equals(Default))
            {
                arySAPS[0, 0] = "GroupId";
                arySAPS[0, 1] = this._GroupId;
                arySAPS[0, 2] = "int";
            }

            if (!this._GroupName.Equals(Default))
            {
                arySAPS[1, 0] = "GroupName";
                arySAPS[1, 1] = this._GroupName;
                arySAPS[1, 2] = "string";
            }

            if (!this.Active.Equals(Default))
            {
                arySAPS[2, 0] = "Active";
                arySAPS[2, 1] = this.Active;
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

            if (!this._Description.Equals(Default))
            {
                arySAPS[5, 0] = "Description";
                arySAPS[5, 1] = this._Description;
                arySAPS[5, 2] = "string";
            }

            return arySAPS;
        }

        #endregion

        #region "Validation Functions"

        private bool Validation()
        {
            if (!VD_AccessGroup())
            {
                return false;
            }
            return true;
        }

        public bool VD_AccessGroup()
        {

            if (this._GroupName.Equals(""))
            {
                this.StrErrorMessage = "Please Enter Group Name. (empty is not allowed)";
                return false;
            }

            DataView dvTest = GetAll(2);

            if (!this._GroupName.Equals(Default))
            {
                dvTest.RowFilter = "GroupId <> '" + _GroupId + "' And GroupName = '" + _GroupName + "'";
            }
            else
            {
                dvTest.RowFilter = "GroupName = '" + _GroupName + "'";
            }

            if (dvTest.Count > 0)
            {
                this.StrErrorMessage = "Please Enter another Group Name, it is already present.";
                return false;
            }

            return true;
        }

        #endregion

    }
}

