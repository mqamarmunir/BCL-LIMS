using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLVitalSign
    {
       clsoperation objTrans = new clsoperation();
       clsdbhims objdbhims = new clsdbhims();

       #region"Variable"

       private const string TableName = "dc_tvitalsign";
       private const string Default = "~!@";
       private string StrError = Default;

       private string StrVitalID = Default;
       private string StrName = Default;
       private string StrUnit = Default;
       private string StrActive = Default;

       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;
       private string StrClientID = Default;

       #endregion

       #region"Properties"

       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }

       public string VitalID
       {
           get { return StrVitalID; }
           set { StrVitalID = value; }
       }
       public string Name
       {
           get { return StrName; }
           set { StrName = value; }
       }
       public string Unit
       {
           get { return StrUnit; }
           set { StrUnit = value; }
       }
       public string Active
       {
           get { return StrActive; }
           set { StrActive = value; }
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

       #endregion

       #region"Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1: // fill gv 
                   objdbhims.Query = "select vitalid,name,unit,active from dc_tvitalsign";
                   break;
               case 2: // validation duplicate
                   objdbhims.Query = "select vitalid from dc_tvitalsign where name='"+StrName+"'";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert()
       {
           if (Validate())
           {
               QueryBuilder objQB = new QueryBuilder();

               objTrans.Start_Transaction();

               objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
               StrError = objTrans.DataTrigger_Insert(objdbhims);

               if (StrError.Equals("True"))
               {
                   objTrans.End_Transaction();
                   StrError = objTrans.OperationError;
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
           if (Validate())
           {
               QueryBuilder objQB = new QueryBuilder();

               objTrans.Start_Transaction();

               objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
               StrError = objTrans.DataTrigger_Update(objdbhims);

               if (StrError.Equals("True"))
               {
                   objTrans.End_Transaction();
                   StrError = objTrans.OperationError;
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
           string[,] kdcArr = new string[7, 3];

           if (!StrVitalID.Equals(Default) && !StrVitalID.Equals(""))
           {
               kdcArr[0, 0] = "vitalid";
               kdcArr[0, 1] = this.StrVitalID;
               kdcArr[0, 2] = "int";
           }
           if (!StrUnit.Equals(Default))
           {
               kdcArr[1, 0] = "unit";
               kdcArr[1, 1] = this.StrUnit;
               kdcArr[1, 2] = "string";
           }
           if (!StrActive.Equals(Default))
           {
               kdcArr[2, 0] = "active";
               kdcArr[2, 1] = this.StrActive;
               kdcArr[2, 2] = "string";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kdcArr[3, 0] = "enteredby";
               kdcArr[3, 1] = this.StrEnteredBy;
               kdcArr[3, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kdcArr[4, 0] = "enteredon";
               kdcArr[4, 1] = this.StrEnteredOn;
               kdcArr[4, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kdcArr[5, 0] = "clientid";
               kdcArr[5, 1] = this.StrClientID;
               kdcArr[5, 2] = "string";
           }
           if (!StrName.Equals(Default))
           {
               kdcArr[6, 0] = "name";
               kdcArr[6, 1] = this.StrName;
               kdcArr[6, 2] = "string";
           }
           return kdcArr;
       }

       private bool Validate()
       {
           DataView dv = GetAll(2);
           if (dv.Count > 0)
           {
               if (!StrVitalID.Equals("") && !StrVitalID.Equals(Default) && StrVitalID != null)
                   dv.RowFilter = "vitalid<>"+StrVitalID+"";
               if (dv.Count > 0)
               {
                   StrError = "Please enter other vital sign.it is already registered.";
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
