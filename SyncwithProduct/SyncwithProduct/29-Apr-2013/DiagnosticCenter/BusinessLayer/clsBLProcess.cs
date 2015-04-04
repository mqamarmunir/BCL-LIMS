using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLProcess
    {

        clsdbhims objdbhims = new clsdbhims();
        clsoperation objTrans = new clsoperation();

        #region"Variables"

        private const string Default = "~!@";
        private const string TableName = "dc_tp_tprocess";

        private string StrProcessID = Default;
        private string StrName = Default;
        private string StrAcronym = Default;

        private string StrEnteredOn = Default;
        private string StrEnteredBy = Default;
        private string StrClientID = Default;
          
        private string StrActive = Default;
        private string StrError = Default;

   

        #endregion

        #region"Properties"

       public string ProcessID
       {
           get { return StrProcessID; }
           set { StrProcessID = value; }
       }
        public string Name
        {
            get { return StrName; }
            set { StrName = value; }
        }
        public string Acronym
        {
            get { return StrAcronym; }
            set { StrAcronym = value; }
        }

        public string EnteredBy
        {
            get { return StrEnteredBy; }
            set { StrEnteredBy = value; }
        }
        public string EnteredOn
        {
            get { return StrEnteredOn; }
            set { StrEnteredOn = value; }
        }
        public string ClientID
        {
            get { return StrClientID; }
            set { StrClientID = value; }
        }
              
        public string Active
        {
            get { return StrActive; }
            set { StrActive = value; }
        }
        public string Error
        {
            get { return StrError; }
            set { StrError = value; }
        }
           
        #endregion

        #region"Method"

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1: // fill grid
                    objdbhims.Query = "select processid,name,acronym,active from dc_tp_tprocess where 1=1";
                    if (!StrActive.Equals("") && !StrActive.Equals(Default))
                    {
                        objdbhims.Query += @" and Active='" + StrActive + "'";
                    }
                    break;
                case 2: // procedure duplicate
                    objdbhims.Query = "select processid from dc_tp_tprocess where name = '" + StrName + "'";
                    break;
                case 3: // acronym duplicate
                    objdbhims.Query = "select processid from dc_tp_tprocess where acronym = '" + StrAcronym + "'";
                    break;
              
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Insert()
        {
            if (Validate_Form())
            {
                QueryBuilder ObjQB = new QueryBuilder();
                objTrans.Start_Transaction();

                objdbhims.Query = ObjQB.QBInsert(MakeArray(), TableName);
                StrError = objTrans.DataTrigger_Insert(objdbhims);

                if (StrError.Equals("True"))
                {
                    StrError = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                else
                {
                    objTrans.End_Transaction();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Update()
        {
            if (Validate_Form())
            {
                QueryBuilder ObjQB = new QueryBuilder();
                objTrans.Start_Transaction();

                objdbhims.Query = ObjQB.QBUpdate(MakeArray(), TableName);
                StrError = objTrans.DataTrigger_Update(objdbhims);

                if (StrError.Equals("True"))
                {
                    StrError = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                else
                {
                    objTrans.End_Transaction();
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
            string[,] kd_arr = new string[7, 3];

            if (!StrProcessID.Equals(Default))
            {
                kd_arr[0, 0] = "processid";
                kd_arr[0, 1] = this.StrProcessID;
                kd_arr[0, 2] = "int";
            }
            if (!StrName.Equals(Default))
            {
                kd_arr[1, 0] = "name";
                kd_arr[1, 1] = this.StrName;
                kd_arr[1, 2] = "string";
            }
            if (!StrAcronym.Equals(Default))
            {
                kd_arr[2, 0] = "acronym";
                kd_arr[2, 1] = this.StrAcronym;
                kd_arr[2, 2] = "string";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                kd_arr[3, 0] = "enteredby";
                kd_arr[3, 1] = this.StrEnteredBy;
                kd_arr[3, 2] = "int";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                kd_arr[4, 0] = "enteredon";
                kd_arr[4, 1] = this.StrEnteredOn;
                kd_arr[4, 2] = "datetime";
            }
            if (!StrClientID.Equals(Default))
            {
                kd_arr[5, 0] = "clientid";
                kd_arr[5, 1] = this.StrClientID;
                kd_arr[5, 2] = "string";
            }
            if (!StrActive.Equals(Default))
            {
                kd_arr[6, 0] = "active";
                kd_arr[6, 1] = this.StrActive;
                kd_arr[6, 2] = "string";
            }
            return kd_arr;
        }

        private bool Validate_Form()
        {
            if (!VD_Name())
            {
                return false;
            }
            if (!VD_Acronym())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool VD_Name()
        {
            DataView dv = GetAll(2);
            if (dv.Count > 0)
            {
                if (!StrProcessID.Equals(Default) && !StrProcessID.Equals("") && StrProcessID != null)
                    dv.RowFilter = "processid <>" + StrProcessID;
                if (dv.Count > 0)
                {
                    StrError = "please enter other process name.It is already exist";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private bool VD_Acronym()
        {
            DataView dv = GetAll(3);
            if (dv.Count > 0)
            {
                if (!StrProcessID.Equals(Default) && !StrProcessID.Equals("") && StrProcessID != null)
                    dv.RowFilter = "processid <>" + StrProcessID;
                if (dv.Count > 0)
                {
                    StrError = "please enter other acronym.It is already exist";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
