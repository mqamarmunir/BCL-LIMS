using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLClassification
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region"Variables"

       private const string Default = "~!@";
       private const string TableName = "dc_tp_tclass";

       private string StrClassID = Default;
       private string StrName = Default;
       private string StrTestID = Default;

       private string StrDorder = Default;
       private string StrActive = Default;

       private string StrEnteredOn = Default;
       private string StrEnteredBy = Default;
       
       private string StrClientID = Default;
       private string StrError = Default;

       #endregion

       #region"Properties"

       public string ClassID
       {
           get { return StrClassID; }
           set { StrClassID = value; }
       }
       public string Name
       {
           get { return StrName; }
           set { StrName = value; }
       }
       public string TestID
       {
           get { return StrTestID; }
           set { StrTestID = value; }
       }

       public string DOrder
       {
           get { return StrDorder; }
           set { StrDorder = value; }
       }
       public string Active
       {
           get { return StrActive; }
           set { StrActive = value; }
       }

       public string EnteredBy
       {
           get { return StrEnteredBy; }
           set { StrEnteredBy = value; }
       }
       public string EnteredoN
       {
           get { return StrEnteredOn; }
           set { StrEnteredOn = value; }
       }

       public string ClientID
       {
           get { return StrClientID; }
           set { StrClientID = value; }
       }
       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }

       #endregion

       #region "Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1: // fill gv classification
                   objdbhims.Query = "select c.classificationid,c.name as classname,c.dorder,c.testid,c.active,t.test_name as testname from dc_tp_tclass c left outer join dc_tp_test t on c.testid = t.testid where c.testid="+StrTestID+"";
                   break;
               case 2: // fill test drop down
                   objdbhims.Query = "select testid,test_name as name from dc_tp_test where active='Y'";
                   break;
               case 3: // duplicate class name
                   objdbhims.Query = "select classificationid from dc_tp_tclass where name = '"+StrName+"' and testid="+StrTestID+"";
                   break;
               case 4://duplicate dorder
                   objdbhims.Query = "select classificationid from dc_tp_tclass where dorder="+StrDorder+" and testid="+StrTestID+"";
                   break;
               case 5: // next dorder 
                   objdbhims.Query = "select max(ifnull(dorder,0))+1 as nextdorder from dc_tp_tclass where testid="+StrTestID+"";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert()
       {
           if (Valid_Dup())
           {
               QueryBuilder objQB = new QueryBuilder();
               objTrans.Start_Transaction();

               objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
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
       public bool update()
       {
           if (Valid_Dup())
           {
               QueryBuilder objQB = new QueryBuilder();
               objTrans.Start_Transaction();

               objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
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
           string[,] kd_arr = new string[8, 3];

           if (!StrClassID.Equals(Default))
           {
               kd_arr[0, 0] = "classificationid";
               kd_arr[0, 1] = this.StrClassID;
               kd_arr[0, 2] = "int";
           }
           if (!StrName.Equals(Default))
           {
               kd_arr[1, 0] = "name";
               kd_arr[1, 1] = this.StrName;
               kd_arr[1, 2] = "string";
           }
           if (!StrDorder.Equals(Default) && !StrDorder.Equals(""))
           {
               kd_arr[2, 0] = "dorder";
               kd_arr[2, 1] = this.StrDorder;
               kd_arr[2, 2] = "int";
           }
           else
           {
               kd_arr[2, 0] = "dorder";
               kd_arr[2, 1] = "null";
               kd_arr[2, 2] = "int";
           }
           if (!StrTestID.Equals(Default))
           {
               kd_arr[3, 0] = "testid";
               kd_arr[3, 1] = this.StrTestID;
               kd_arr[3, 2] = "int";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kd_arr[4, 0] = "enteredby";
               kd_arr[4, 1] = this.StrEnteredBy;
               kd_arr[4, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kd_arr[5, 0] = "enteredon";
               kd_arr[5, 1] = this.StrEnteredOn;
               kd_arr[5, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kd_arr[6, 0] = "clientid";
               kd_arr[6, 1] = this.StrClientID;
               kd_arr[6, 2] = "string";
           }
           if (!StrActive.Equals(Default))
           {
               kd_arr[7, 0] = "active";
               kd_arr[7, 1] = this.StrActive;
               kd_arr[7, 2] = "string";
           }
           return kd_arr;
       }

       private bool Valid_Dup()
       {
           if (!VD_Name())
           {
               return false;
           }
           if (!VD_Dorder())
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
           DataView dv = GetAll(3);
           if (dv.Count > 0)
           {
               if (!StrClassID.Equals(Default) && !StrClassID.Equals("") && StrClassID != null)
                   dv.RowFilter = "classificationid <>" + StrClassID;
               if (dv.Count > 0)
               {
                   StrError = "Please enter other classification name.This classfication is already exist";
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
       private bool VD_Dorder()
       {
           if (!StrDorder.Equals(Default) && !StrDorder.Equals(""))
           {
               DataView dv = GetAll(4);
               if (dv.Count > 0)
               {
                   if (!StrClassID.Equals(Default) && !StrClassID.Equals("") && StrClassID != null)
                       dv.RowFilter = "classificationid <>" + StrClassID;
                   if (dv.Count > 0)
                   {
                       DataView DvMax = GetAll(5);
                       StrError = "Please enter other Dorder.This Dorder is already exist.Next available Dorder is " + DvMax[0]["nextdorder"].ToString() + "";
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
           else
           {
               return true;
           }
       }
       #endregion
   }
}
