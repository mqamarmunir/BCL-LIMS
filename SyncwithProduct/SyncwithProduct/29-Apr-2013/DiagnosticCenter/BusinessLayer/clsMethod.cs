using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsMethod
    {
        #region Class Variables

        private const string Default = "~!@";
        private const string TableName = "dc_tp_method";        
        private string StrErrorMessage = "";

       private string StrMethodID = Default;
       private string StrSub_DeptID = Default;
       private string StrMethod = Default;

       private string StrActive = Default;
       private string StrAcronym = Default;
       private string StrMinTime = Default;

       private string StrMaxTime = Default;
       private string StrDorder = Default;
       private string StrDefault = Default;

       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;
       private string StrClientID = Default;
        #endregion

       #region"Properties"

       public string Error
       {
           get { return StrErrorMessage; }
           set { StrErrorMessage = value; }
       }
       public string MethodID
       {
           get { return StrMethodID; }
           set { StrMethodID = value; }
       }
       public string SubDeptID
       {
           get { return StrSub_DeptID; }
           set { StrSub_DeptID = value; }
       }
       public string Method
       {
           get { return StrMethod; }
           set { StrMethod = value; }
       }

       public string Active
       {
           get { return StrActive; }
           set { StrActive = value; }
       }
       public string Acronym
       {
           get { return StrAcronym; }
           set { StrAcronym = value; }
       }
       public string MinTime
       {
           get { return StrMinTime; }
           set { StrMinTime = value; }
       }

       public string MaxTime
       {
           get { return StrMaxTime; }
           set { StrMaxTime = value; }
       }
       public string Dorder
       {
           get { return StrDorder; }
           set { StrDorder = value; }
       }
       public string Default_value
       {
           get { return StrDefault; }
           set { StrDefault = value; }
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

       #endregion

       clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region Methods

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "select methodid,Name,Acronym,Active,dfault,dorder,subdepartmentid,case when mintime <60 then concat(format(mintime,0),' Minutes') when mintime >=60 and mintime < 1440 then concat(format(mintime/60,0),' Hours') else concat(format(mintime/1440,0),' Days') end as MinTime,case when maxtime <60 then concat(format(maxtime,0),' Minutes') when maxtime >=60 and maxtime < 1440 then concat(format(maxtime/60,0),' Hours') else concat(format(maxtime/1440,0),' Days') end as MaxTime, case when mintime <60 then mintime when mintime >=60 and mintime < 1440 then format(mintime/60,0) else format(mintime/1440,0) end as MinTimeValue, case when maxtime <60 then maxtime when maxtime >=60 and maxtime < 1440 then format(maxtime/60,0) else format(maxtime/1440,0) end as MaxTimeValue, case when mintime <60 then 'M' when mintime >=60 and mintime < 1440 then 'H' else 'D' end as TimeType from " + TableName + " t where 1 = 1";
                    if(!StrSub_DeptID.Equals("") && !StrSub_DeptID.Equals(Default))
                        objdbhims.Query += " and subdepartmentid='"+StrSub_DeptID+"'";
                    objdbhims.Query += " order by ifnull(t.dorder,t.Name)";
                    break;

                case 2:
                    objdbhims.Query = "select methodid,Name,Active from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Name) = '" + this.StrMethod.ToUpper() + "' and subdepartmentid='"+StrSub_DeptID+"'";
                    break;
                                  

                case 3:
                    objdbhims.Query = "select methodid,Acronym from " + TableName + " t ";
                    objdbhims.Query = objdbhims.Query + " Where Upper(t.Acronym) = '" + this.StrAcronym.ToUpper() + "'";
                    break;
                case 4: // fill drop down fill
                    objdbhims.Query = "SELECT d.subdepartmentid,d.name FROM dc_tp_subdepartments d where d.active='Y'";
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
            string[,] aryMeth = new string[12, 3];

            if (!StrMethodID.Equals(Default) && !StrMethodID.Equals(""))
            {
                aryMeth[0, 0] = "methodid";
                aryMeth[0, 1] = this.StrMethodID;
                aryMeth[0, 2] = "int";
            }
            if (!StrMethod.Equals(Default))
            {
                aryMeth[1, 0] = "name";
                aryMeth[1, 1] = this.StrMethod;
                aryMeth[1, 2] = "string";
            }
            if (!StrSub_DeptID.Equals(Default))
            {
                aryMeth[2, 0] = "subdepartmentid";
                aryMeth[2, 1] = this.StrSub_DeptID;
                aryMeth[2, 2] = "int";
            }
            if (!StrAcronym.Equals(Default))
            {
                aryMeth[3, 0] = "acronym";
                aryMeth[3, 1] = this.StrAcronym;
                aryMeth[3, 2] = "string";
            }
            if (!StrActive.Equals(Default))
            {
                aryMeth[4, 0] = "active";
                aryMeth[4, 1] = this.StrActive;
                aryMeth[4, 2] = "string";
            }
            if (!StrMinTime.Equals(Default))
            {
                aryMeth[5, 0] = "mintime";
                aryMeth[5, 1] = this.StrMinTime;
                aryMeth[5, 2] = "int";
            }
            if (!StrMaxTime.Equals(Default))
            {
                aryMeth[6, 0] = "maxtime";
                aryMeth[6, 1] = this.StrMaxTime;
                aryMeth[6, 2] = "int";
            }
            if (!StrDorder.Equals(Default))
            {
                aryMeth[7, 0] = "dorder";
                aryMeth[7, 1] = this.StrDorder;
                aryMeth[7, 2] = "string";
            }
            if (!StrDefault.Equals(Default))
            {
                aryMeth[8, 0] = "dfault";
                aryMeth[8, 1] = this.StrDefault;
                aryMeth[8, 2] = "string";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                aryMeth[9, 0] = "enteredby";
                aryMeth[9, 1] = this.StrEnteredBy;
                aryMeth[9, 2] = "int";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                aryMeth[10, 0] = "enteredon";
                aryMeth[10, 1] = this.StrEnteredOn;
                aryMeth[10, 2] = "datetime";
            }
            if (!StrClientID.Equals(Default))
            {
                aryMeth[11, 0] = "clientid";
                aryMeth[11, 1] = this.StrClientID;
                aryMeth[11, 2] = "string";
            }

            return aryMeth;
        }

        #endregion

        #region "Validation Functions"

        private bool Validation()
        {
            if (!VD_Organization())
            {
                return false;
            }
            if (!VD_Acronym())
            {
                return false;
            }
            return true;
        }

        public bool VD_Organization()
        {                      

            DataView dvTest = GetAll(2);

            if (!this.StrMethodID.Equals(Default))
            {
                dvTest.RowFilter = "methodid <> '" + StrMethodID+ "' And Name = '" + StrMethod + "'";
            }
            else
            {
                dvTest.RowFilter = "Name = '" + StrMethod + "'";
            }

            if (dvTest.Count > 0)
            {
                this.StrErrorMessage = "Please Enter another method Name, it is already present.";
                return false;
            }

            return true;
        }

        private bool VD_Acronym()
        {           

            if (!this.StrAcronym.Equals("") && !this.StrAcronym.Equals(Default))
            {
                DataView dvTest = GetAll(3);

                if (!this.StrMethodID.Equals(Default))
                {
                    dvTest.RowFilter = "methodid <> '" + StrMethodID + "' And Acronym = '" + StrAcronym + "'";
                }
                else
                {
                    dvTest.RowFilter = "Acronym = '" + StrAcronym + "'";
                }

                if (dvTest.Count > 0)
                {
                    this.StrErrorMessage = "Please Enter another Acronym, it is already present.";
                    return false;
                }
            }

            return true;

        }

        #endregion
    }
}
