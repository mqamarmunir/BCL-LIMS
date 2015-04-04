using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DataLayer;

namespace BusinessLayer
{
    public class clsGroupOption
    {
        #region Class Variables

        private const string Default = "~!@";
        private const string TableName = "dc_tu_groupright";
        private const string TableName2 = "dc_tu_accessoption";
        private string StrErrorMessage = "";

        private string _GroupId = Default;
        private string _OptionId = Default;
        private string _Type = Default;
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
                    objdbhims.Query = "select gr.GroupId,op.OptionId,op.OptionName,op.Description from " + TableName + " gr," + TableName2 + " op where gr.OptionId = op.OptionId and gr.GroupId ='" + _GroupId + "' and op.Type = '" + _Type + "'";
                    break;

                case 2:
                    objdbhims.Query = "select op.OptionId,op.OptionName from " + TableName2 + " op left outer join " + TableName + " gr on gr.OptionId = op.OptionId where gr.GroupId = '" + _GroupId + "' and op.Type = '" + _Type + "'";
                    break;

                case 3:
                    objdbhims.Query = "select op.OptionId,op.OptionName,op.Description from " + TableName2 + " op where op.Active='Y' and op.Type = '" + _Type + "' order by op.OptionName";
                    break;

                case 4:
                    objdbhims.Query = "select gr.OptionId from " + TableName2 + " op," + TableName + " gr where gr.OptionId = op.OptionId and gr.GroupId = '" + _GroupId + "' and op.Type = '" + _Type + "'";
                    break;
            }

            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Insert()
        {
            try
            {
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

        public bool Delete()
        {

            clsoperation objTrans = new clsoperation();
            QueryBuilder objQB = new QueryBuilder();

            objTrans.Start_Transaction();
            objdbhims.Query = "delete from " + TableName + " where groupid =" + _GroupId;
            objdbhims.Query += " and optionid in (select optionid from " + TableName2 + " where type = '" + _Type + "')";
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
            string[,] arySAPS = new string[4, 3];

            if (!this._GroupId.Equals(Default))
            {
                arySAPS[0, 0] = "GroupId";
                arySAPS[0, 1] = this._GroupId;
                arySAPS[0, 2] = "int";
            }

            if (!this._OptionId.Equals(Default))
            {
                arySAPS[1, 0] = "OptionId";
                arySAPS[1, 1] = this._OptionId;
                arySAPS[1, 2] = "int";
            }

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[2, 0] = "Enteredby";
                arySAPS[2, 1] = this._Enteredby;
                arySAPS[2, 2] = "int";
            }

            if (!this._Enteredon.Equals(Default))
            {
                arySAPS[3, 0] = "Enteredon";
                arySAPS[3, 1] = this._Enteredon;
                arySAPS[3, 2] = "datetime";
            }

            return arySAPS;
        }

        #endregion

    }
}

