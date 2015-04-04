using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsMethodTest
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region "Variables"

       private const string Default = "~!@";
       private const string TableName = "dc_tp_tmethod";
       private string StrError = "";

       private string StrMethodID = Default;
       private string StrOld_MethodID = Default;
       private string StrTestID = Default;
       private string StrOld_TestID = Default;

       private string StrSubDepartID = Default;
       private string StrDorder = Default;
       private string StrDefault_Mthd = Default;

       private string StrEnteredON = Default;
       private string StrEnteredBY = Default;
       private string StrCLietnID = Default;

       #endregion

       #region "Properties"

       public string MethodID
       {
           get { return StrMethodID; }
           set { StrMethodID = value; }
       }
       public string Old_MethodID
       {
           get { return StrOld_MethodID; }
           set { StrOld_MethodID = value; }
       }
       public string TestID
       {
           get { return StrTestID; }
           set { StrTestID = value; }
       }
       public string Old_TestID
       {
           get { return StrOld_TestID; }
           set { StrOld_TestID = value; }
       }

       public string SubDeptID
       {
           get { return StrSubDepartID; }
           set { StrSubDepartID = value; }
       }
       public string Dorder
       {
           get { return StrDorder; }
           set { StrDorder = value; }
       }
       public string Default_Mth
       {
           get { return StrDefault_Mthd; }
           set { StrDefault_Mthd = value; }
       }

       public string EnteredOn
       {
           get { return StrEnteredON; }
           set { StrEnteredON = value; }
       }
       public string EnteredBy
       {
           get { return StrEnteredBY; }
           set { StrEnteredBY = value; }
       }
       public string ClientID
       {
           get { return StrCLietnID; }
           set { StrCLietnID = value; }
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
               case 1: // fill grid
                   objdbhims.Query = "SELECT d.methodid,d.testid,t.test_name,d.dorder,d.m_default FROM dc_tp_tmethod d left outer join dc_tp_test t on d.testid = t.testid where d.methodid =" + StrMethodID + " and d.clientid='" + StrCLietnID + "' order by ifnull(d.dorder,100000)";
                   break;
               case 2: // fill method
                   objdbhims.Query = "select methodid,name from dc_tp_method where active='Y' and subdepartmentid=" + StrSubDepartID + "";
                   break;
               case 3: // fill test
                   objdbhims.Query = "select testid,test_name as name from dc_tp_test where active = 'Y'";
                   if (!StrSubDepartID.Equals(Default))
                   {
                       objdbhims.Query += " and subdepartmentid=" + StrSubDepartID;
                   }
                   break;
               case 4: // check testid 
                   objdbhims.Query = "select testid from dc_tp_tmethod where methodid = " + StrMethodID + " and testid=" + StrTestID + " and clientid='" + StrCLietnID + "'";
                   break;
               case 5: // check dorder
                   objdbhims.Query = "select ifnull(dorder,0) as dorder,testid from dc_tp_tmethod where methodid=" + StrMethodID + "  and dorder is not null and dorder=" + StrDorder + " and clientid='" + StrCLietnID + "'";
                   break;
               case 6: // next dorder 
                   objdbhims.Query = "select max(ifnull(dorder,0))+1 as nextdorder from dc_tp_tmethod where methodid="+StrMethodID+"";
                   break;
               case 7: // default method against test valid
                   objdbhims.Query = "select methodid from dc_tp_tmethod where testid='" + StrTestID + "' and methodid<>" + StrMethodID + " and m_default='Y' and clientid='" + StrCLietnID + "'";
                   break;
               case 8: // fill branch
                   objdbhims.Query = "select orgid,name from dc_tp_organization where active='Y' and external='N'";
                   break;
               case 9: // fill drop down fill
                   objdbhims.Query = "SELECT d.subdepartmentid,d.name FROM dc_tp_subdepartments d where d.active='Y'";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert()
       {
           if (validate_form())
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
       public bool Update()
       {
           if (validate_form())
           {

               QueryBuilder objQB = new QueryBuilder();

               objTrans.Start_Transaction();
               //if (StrTestID != StrOld_TestID)
               //{
                   objdbhims.Query = "delete from dc_TP_tmethod where testid=" + StrOld_TestID + " and methodid=" + StrOld_MethodID + "";
                   StrError = objTrans.DataTrigger_Delete(objdbhims);
                   if (StrError.Equals("True"))
                   {
                       StrError = objTrans.OperationError;
                       objTrans.End_Transaction();
                       return false;
                   }
                   else
                   {
                       objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                       StrError = objTrans.DataTrigger_Insert(objdbhims);
                   }
               //}
               //else
               //{
               //    objdbhims.Query = objQB.QBUpdate2(MakeArray(), TableName);
               //    StrError = objTrans.DataTrigger_Update(objdbhims);
               //}

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

           if (!StrMethodID.Equals(Default))
           {
               kd_arr[0, 0] = "methodid";
               kd_arr[0, 1] = this.StrMethodID;
               kd_arr[0, 2] = "int";
           }
           if (!StrTestID.Equals(Default))
           {
               kd_arr[1, 0] = "testid";
               kd_arr[1, 1] = this.StrTestID;
               kd_arr[1, 2] = "int";
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
           if (!StrEnteredBY.Equals(Default))
           {
               kd_arr[3, 0] = "enteredby";
               kd_arr[3, 1] = this.StrEnteredBY;
               kd_arr[3, 2] = "int";
           }
           if (!StrEnteredON.Equals(Default))
           {
               kd_arr[4, 0] = "enteredon";
               kd_arr[4, 1] = this.StrEnteredON;
               kd_arr[4, 2] = "datetime";
           }
           if (!StrCLietnID.Equals(Default))
           {
               kd_arr[5, 0] = "clientid";
               kd_arr[5, 1] = this.StrCLietnID;
               kd_arr[5, 2] = "string";
           }
           if (!StrDefault_Mthd.Equals(Default))
           {
               kd_arr[6, 0] = "m_default";
               kd_arr[6, 1] = this.StrDefault_Mthd;
               kd_arr[6, 2] = "string";
           }
           return kd_arr;
       }
             
       private bool validate_form()
       {
           if (!VD_Test())
           {
               return false;
           }
           if (!VD_Dorder())
           {
               return false;
           }
           return true;
       }
       private bool VD_Dorder()
       {
           if (StrDorder.Equals(""))
               return true;

           DataView dv = new DataView();

           dv = GetAll(5);

           if (dv.Count > 0)
           {
               if (!StrOld_TestID.Equals(Default) && !StrOld_TestID.Equals("") && !StrDorder.Equals(""))
                   dv.RowFilter = "dorder = " + StrDorder+ " and testid <>"+StrTestID;
               if (dv.Count > 0)
               {
                   DataView dvDOr = GetAll(6);
                   StrError = "Please enter other dorder.This dorder has already configured with this method and test.Available Dorder is "+dvDOr[0]["nextdorder"].ToString()+"";
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
       private bool VD_Test()
       {
           DataView dv = new DataView();
           dv = GetAll(4);

           if (dv.Count > 0)
           {
               if (!StrOld_TestID.Equals(Default) && !StrOld_TestID.Equals(""))
                   dv.RowFilter = "testid <> " + StrTestID;
               if (dv.Count > 0)
               {
                   StrError = "Please  select other test.This test has already configured with this method";
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
