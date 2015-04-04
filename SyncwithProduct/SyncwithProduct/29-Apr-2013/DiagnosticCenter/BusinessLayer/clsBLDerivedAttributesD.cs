using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsBLDerivedAttributesD
    {
        public clsBLDerivedAttributesD()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "LS_TDerivedAttributesD";
        private string StrErrorMessage = "";
        private string StrAttributeID = Default;
        private string StrDerivedID = Default;
        private string StrDetailDerivedID = Default;
        private string StrVariableName = Default;
        private string StrType = Default;
        private string StrLocation = Default;
        // private string StrFormula = Default;
        //private string StrAttributeName = Default;
        //private string StrDescription = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrStatus = Default;
        private string StrTestID = Default;


        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties

        public string DerivedID
        {
            get { return StrDerivedID; }
            set { StrDerivedID = value; }
        }
        public string DetailDerivedID
        {
            get { return StrDetailDerivedID; }
            set { StrDetailDerivedID = value; }
        }

        public string AttributeID
        {
            get { return StrAttributeID; }
            set { StrAttributeID = value; }
        }

        public string ErrorMessage
        {
            get { return StrErrorMessage; }
        }

        public string VariableName
        {
            get { return StrVariableName; }
            set { StrVariableName = value; }
        }

        public string Type
        {
            get { return StrType; }
            set { StrType = value; }
        }

        public string Location
        {
            get { return StrLocation; }
            set { StrLocation = value; }
        }

        public string EnteredOn
        {
            get { return StrEnteredOn; }
            set { StrEnteredOn = value; }
        }
        public string EnteredBy
        {
            get { return StrEnteredBy; }
            set { StrEnteredBy = value; }
        }

        public string ClientID
        {
            get { return StrClientID; }
            set { StrClientID = value; }
        }
        public string Status
        {
            get { return StrStatus; }
            set { StrStatus = value; }
        }

        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }

        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * From " + TableName + " where AttributeID='" + StrAttributeID + "'";
                    break;
                case 2:
                    objdbhims.Query = "Select DETAILDERIVEID, DerivedID,VariableName From LS_TDerivedAttributesD where TestId='" + StrTestID + "' and Type='A'";
                    break;

            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool delete()
        {
            if (!StrDerivedID.Equals(Default))
            {
                objTrans.Start_Transaction();
                objdbhims.Query = "Delete From Ls_TDerivedAttributesD where DerivedID='" + StrDerivedID + "'";
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

                if (StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
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
                this.StrErrorMessage = "Derived ID Not provided";
                return false;

            } //return true;
        }

        public bool insert()
        {
            try
            {
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBGetMax("DETAILDERIVEID", TableName);
                this.StrDetailDerivedID = objTrans.DataTrigger_Get_Max(objdbhims);
                if (this.StrDetailDerivedID.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                else
                {
                    objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                    this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                    if (this.StrErrorMessage.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;

                    }
                    else
                    {
                        objTrans.End_Transaction();
                        return true;
                    }
                }

            }
            catch (Exception ee)
            {
                this.StrErrorMessage = ee.ToString();
                return false;
            }


        }

        public bool updateAcronym()
        {
            try
            {
                QueryBuilder objQB = new QueryBuilder();
                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                objTrans.Start_Transaction();
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;

                }
                else
                {
                    objTrans.End_Transaction();
                    return true;
                }
            }
            catch (Exception ee)
            {
                this.StrErrorMessage = ee.ToString();
                return false;
            }
        }


        private string[,] MakeArray()
        {
            string[,] AryDerivedAttribute = new string[10, 3];

            if (!StrDetailDerivedID.Equals(Default))
            {
                AryDerivedAttribute[0, 0] = "DETAILDERIVEID";
                AryDerivedAttribute[0, 1] = StrDetailDerivedID;
                AryDerivedAttribute[0, 2] = "int";
            }
            if (!StrDerivedID.Equals(Default))
            {
                AryDerivedAttribute[1, 0] = "DerivedID";
                AryDerivedAttribute[1, 1] = StrDerivedID;
                AryDerivedAttribute[1, 2] = "int";
            }
            if (!StrAttributeID.Equals(Default))
            {
                AryDerivedAttribute[2, 0] = "AttributeID";
                AryDerivedAttribute[2, 1] = StrAttributeID;
                AryDerivedAttribute[2, 2] = "int";
            }
            if (!StrVariableName.Equals(Default))
            {
                AryDerivedAttribute[3, 0] = "VARIABLENAME";
                AryDerivedAttribute[3, 1] = StrVariableName;
                AryDerivedAttribute[3, 2] = "string";
            }
            if (!StrType.Equals(Default))
            {
                AryDerivedAttribute[4, 0] = "TYPE";
                AryDerivedAttribute[4, 1] = StrType;
                AryDerivedAttribute[4, 2] = "string";
            }
            if (!StrLocation.Equals(Default))
            {
                AryDerivedAttribute[5, 0] = "Location";
                AryDerivedAttribute[5, 1] = StrLocation;
                AryDerivedAttribute[5, 2] = "string";
            }

            if (!StrEnteredBy.Equals(Default))
            {
                AryDerivedAttribute[6, 0] = "EnteredBy";
                AryDerivedAttribute[6, 1] = StrEnteredBy;
                AryDerivedAttribute[6, 2] = "int";
            }

            if (!StrEnteredOn.Equals(Default))
            {
                AryDerivedAttribute[7, 0] = "EnteredOn";
                AryDerivedAttribute[7, 1] = StrEnteredOn;
                AryDerivedAttribute[7, 2] = "datetime";
            }
            if (!StrClientID.Equals(Default))
            {
                AryDerivedAttribute[8, 0] = "ClientID";
                AryDerivedAttribute[8, 1] = StrClientID;
                AryDerivedAttribute[8, 2] = "string";
            }
            if (!StrTestID.Equals(Default))
            {
                AryDerivedAttribute[9, 0] = "TestID";
                AryDerivedAttribute[9, 1] = StrTestID;
                AryDerivedAttribute[9, 2] = "int";
            }

            return AryDerivedAttribute;

        }
        #endregion
    }
}
