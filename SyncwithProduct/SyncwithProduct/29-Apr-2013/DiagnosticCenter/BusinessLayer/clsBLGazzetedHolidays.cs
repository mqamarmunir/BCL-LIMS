﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsBLGazzetedHolidays
    {
        public clsBLGazzetedHolidays()
        {
            /// Add Constructor logic here...
        }

        #region Variables
        private const string TableName = "dc_tp_gazzetedholidays";
        private const string Default = "~!@";

        private string StrErrorMessage = "";
        private string _HolidayID = Default;


        private string _Date_From = Default;
        private string _Date_To = Default;
        private string _Active = Default;
        private string _Description = Default;
        private string _Type = Default;


        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;
        private string _BranchID = Default;
        private string _deliverytime = Default;




        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #endregion

        #region properties

        public string Deliverytime
        {
            get { return _deliverytime; }
            set { _deliverytime = value; }
        }
        public string HolidayID
        {
            get { return _HolidayID; }
            set { _HolidayID = value; }
        }
        public string Date_From
        {
            get { return _Date_From; }
            set { _Date_From = value; }
        }
        public string Date_To
        {
            get { return _Date_To; }
            set { _Date_To = value; }
        }
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
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
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        #endregion

        #region methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = @"Select holidayid,type,active,description,date_format(date_from,'%d/%m/%Y') date_from,
                                        CASE  WHEN 'S'=Type THEN date_format(date_to,'%d/%m/%Y') else '-' end as date_to,
                                        CASE WHEN TYPE='P' THEN 'Permanent' ELSE 'Seasonal' END AS DiscountTYPE

                                        From dc_tp_gazzetedholidays  where 1=1";
                    if (!_HolidayID.Equals(Default) && !_HolidayID.Equals(""))
                    {
                        objdbhims.Query += " and HolidayID=" + _HolidayID;
                    }
                    if (!_Active.Equals(Default) && !_Active.Equals(""))
                    {
                        objdbhims.Query += " and Active='" + _Active + "'";
                    }
                    if (!_deliverytime.Equals(Default))
                    {
                        objdbhims.Query += @" and (case when type='S' then ('"+System.DateTime.Now.ToString("yyyy-MM-dd")+@"' between Date_From and Date_to)
  or ('" + _deliverytime + @"' between Date_From and Date_To) or (date_from between '" + System.DateTime.Now.ToString("yyyy-MM-dd") + @"' and '" + _deliverytime + @"') or (date_to between '" + System.DateTime.Now.ToString("yyyy-MM-dd") + @"' and '" + _deliverytime + @"') else 1=1 end)";
                    }
                    objdbhims.Query += " order by type,date_from";
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

                    objdbhims.Query = objQB.QBGetMax("holidayID", TableName);
                    this.HolidayID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._BranchID.Equals("True"))
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

            if (!this._HolidayID.Equals(Default))
            {
                arySAPS[0, 0] = "HolidayID";
                arySAPS[0, 1] = this._HolidayID;
                arySAPS[0, 2] = "int";
            }

            if (!this._Date_From.Equals(Default))
            {
                arySAPS[1, 0] = "Date_From";
                arySAPS[1, 1] = this._Date_From;
                arySAPS[1, 2] = "datetime";
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

            if (!this._Date_To.Equals(Default))
            {
                arySAPS[5, 0] = "Date_To";
                arySAPS[5, 1] = this._Date_To;
                arySAPS[5, 2] = "datetime";
            }

            if (!this._Description.Equals(Default))
            {
                arySAPS[6, 0] = "Description";
                arySAPS[6, 1] = this._Description;
                arySAPS[6, 2] = "string";
            }

            if (!this._Type.Equals(Default))
            {
                arySAPS[7, 0] = "Type";
                arySAPS[7, 1] = this._Type;
                arySAPS[7, 2] = "string";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[8, 0] = "ClientId";
                arySAPS[8, 1] = this._ClientId;
                arySAPS[8, 2] = "string";
            }
            if (!this._BranchID.Equals(Default))
            {
                arySAPS[9, 0] = "BranchID";
                arySAPS[9, 1] = this._BranchID;
                arySAPS[9, 2] = "string";
            }

            return arySAPS;
        }
        #endregion

        #region ValidationFunctions
        private bool Validation()
        {
            return true;
        }

        #endregion

    }
}
