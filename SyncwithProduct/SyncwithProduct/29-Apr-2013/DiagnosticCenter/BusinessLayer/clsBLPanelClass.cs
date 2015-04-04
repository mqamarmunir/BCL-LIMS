using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLPanelClass
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region"Variables"

       private const string Default = "~!@";
       private const string TableName = "dc_tpanel_class";

       private string StrClassID = Default;
       private string StrPanelID = Default;
       private string StrName = Default;

       private string StrTestID= Default;
       private string StrOld_TestID = Default;
       private string StrActive = Default;
       private string StrDescription = Default;

       private string StrDepartmentID = Default;
       private string StrSubDepartmentID = Default;
       private string StrGroupID = Default;

       private string StrRate = Default;
       private string StrUrgent = Default;
       private string Strpercentdiscount = Default;
       private string StrPanelTestCode = Default;
       private string StrPanelSharepercent = Default;

       
       

       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;
       private string StrClientID = Default;
       private string StrError = Default;

       #endregion

       #region "Properties"
       public string PanelSharepercent
       {
           get { return StrPanelSharepercent; }
           set { StrPanelSharepercent = value; }
       }
       public string PanelTestCode
       {
           get { return StrPanelTestCode; }
           set { StrPanelTestCode = value; }
       }
       public string percentdiscount
       {
           get { return Strpercentdiscount; }
           set { Strpercentdiscount = value; }
       }

       public string ClassID
       {
           get { return StrClassID; }
           set { StrClassID = value; }
       }
       public string PanelID
       {
           get { return StrPanelID; }
           set { StrPanelID = value; }
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
       public string OldTestID
       {
           get { return StrOld_TestID; }
           set { StrOld_TestID = value; }
       }
       public string Active
       {
           get { return StrActive; }
           set { StrActive = value; }
       }
       public string Description
       {
           get { return StrDescription; }
           set { StrDescription = value; }
       }

       public string Rate
       {
           get { return StrRate; }
           set { StrRate = value; }
       }
       public string Urgent
       {
           get { return StrUrgent; }
           set { StrUrgent = value; }
       }

       public string DepartmentID
       {
           get { return StrDepartmentID; }
           set { StrDepartmentID = value; }
       }
       public string SubDepartID
       {
           get { return StrSubDepartmentID; }
           set { StrSubDepartmentID = value; }
       }
       public string GroupID
       {
           get { return StrGroupID; }
           set { StrGroupID = value; }
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
               case 1: // fill class gv
                   objdbhims.Query = "select c.classid,c.name ,c.active,p.name as panelname,c.active,c.description,c.panelid from dc_tpanel_class c left outer join dc_tpanel p on c.panelid = p.panelid where c.panelid="+StrPanelID+"";
                   break;
               case 2: // fill ddl panel ..Class and panel test registration
                   objdbhims.Query = "select panelid,concat(ifnull(acronym,'-'),':',name) as name from dc_tpanel where active='Y' and clientid='" + StrClientID + "'";
                   break;
               case 3: // class validate
                   objdbhims.Query = "select classid from dc_tpanel_class where panelid="+StrPanelID+" and name ='"+StrName+"'";
                   break;
               case 4: // fill subdepartment
                   objdbhims.Query = "select subdepartmentid,name from dc_tP_subdepartments where active='Y' ";
                   if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals(""))
                       objdbhims.Query += " and departmentid =" + StrDepartmentID;
                   break;
               case 5: // fill group
                   objdbhims.Query = "select m.groupid,m.name from dc_tp_groupm m where active='Y' ";
                   //left outer join dc_tp_test t on m.groupid = t.groupid where m.active='Y' and  t.subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid="+StrDepartmentID+")";
                  // if(!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals(""))
                    //   objdbhims.Query +=" and t.subdepartmentid="+StrSubDepartmentID+"";
                   break;
               case 6: // fill test
                   objdbhims.Query = "select testid,test_name from dc_tp_test where active='Y' and subdepartmentid in (select subdepartmentid from dc_tp_subdepartments where departmentid="+StrDepartmentID+")";
                   if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals(""))
                       objdbhims.Query += " and subdepartmentid=" + StrSubDepartmentID + "";
                   if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                       objdbhims.Query += " and groupid="+StrGroupID+" ";
                   break;
               case 7: // panel test validate
                   objdbhims.Query = "select testid  from dc_tpanel_test where testid="+StrTestID+" and panelid="+StrPanelID+" and classid="+StrClassID+"";
                   break;
               case 8: // fill class
                   objdbhims.Query = "select classid,name from dc_Tpanel_class where panelid="+StrPanelID+"";
                   break;
               case 9: // get test price
                   objdbhims.Query = "SELECT ifnull(charges,0) as charges FROM dc_tp_test where testid="+StrTestID+"";
                   break;
               case 10: // fill gv => panel test
                   objdbhims.Query = "select ifnull(d.PanelSharepercent,0) PanelSharePercent,d.panelTestCode,t.speedkey,t.testid,d.panelid,de.name as Department,s.name as subdepartment,t.test_name,d.rate,d.urgentrate,ifnull(t.charges,0) as testcharges,ifnull(t.chargesurgent,0) as testurgentcharges,ifnull(d.percentdiscount,0) percentdiscount from  dc_tp_test t left outer join dc_tpanel_test d  on d.testid = t.testid and d.panelid="+StrPanelID+" left outer join dc_tp_subdepartments s on t.subdepartmentid = s.subdepartmentid left outer join dc_tp_departments de on s.departmentid = de.departmentid where 1=1 and t.active='Y' and d.groupid is null";//and d.classid="+StrClassID+"
                   if (!StrSubDepartmentID.Equals(Default))
                       objdbhims.Query += " and t.subdepartmentid="+StrSubDepartmentID+"";
                   if (!StrDepartmentID.Equals(Default))
                       objdbhims.Query += " and de.departmentid="+StrDepartmentID+"";
                   if (!StrGroupID.Equals(Default))
                       objdbhims.Query += " and t.groupid="+StrGroupID+"";
                   //if (!StrPanelID.Equals(Default))
                   //    objdbhims.Query += " and d.panelid=" + StrPanelID + " ";
                   objdbhims.Query += " order by t.test_name";
                   break;
               case 11: // fill group test wise : Edit Mode
                   objdbhims.Query = "select m.groupid,m.name from dc_tp_groupm m left outer join dc_tp_test t on m.groupid = t.groupid where m.active='Y' and t.testid=" + StrTestID + "";
                   break;
               case 12: // select subdpt test wise and group wise: Edit mode
                   objdbhims.Query = "select s.subdepartmentid,s.name from dc_tp_subdepartments s left outer join dc_tp_test t on s.subdepartmentid = t.subdepartmentid where s.active='Y' and t.testid=" + StrTestID + " and t.groupid="+StrGroupID+"";
                   break;
               case 13: // fill Department
                   objdbhims.Query = "select departmentid,name from dc_tp_departments where active='Y'";
                   if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals(""))
                       objdbhims.Query += " and departmentid in (select departmentid from dc_tp_subdepartments where subdepartmentid=" + StrSubDepartmentID + ")";
                   break;
               case 14: // fill gv => panel test ++ onlye test
                   objdbhims.Query = "select t.speedkey,t.testid,de.name as Department,s.name as subdepartment,m.name as groupname,t.test_name,ifnull(t.charges,0) as testcharges,ifnull(t.chargesurgent,0) as testurgentcharges,'' as panelid from  dc_tp_test t  left outer join dc_tp_groupm m on t.groupid=m.groupid left outer join dc_tp_subdepartments s on t.subdepartmentid = s.subdepartmentid left outer join dc_tp_departments de on s.departmentid = de.departmentid where 1=1 and t.active='Y'";//and d.classid="+StrClassID+"
                   if (!StrSubDepartmentID.Equals(Default))
                       objdbhims.Query += " and t.subdepartmentid=" + StrSubDepartmentID + "";
                   if (!StrDepartmentID.Equals(Default))
                       objdbhims.Query += " and de.departmentid=" + StrDepartmentID + "";
                   if (!StrGroupID.Equals(Default))
                       objdbhims.Query += " and t.groupid=" + StrGroupID + "";
                   objdbhims.Query += " order by t.test_name";
                  
                   break;
               case 15: // fill gv => panel test group d
                   objdbhims.Query = "select m.name as groupname,d.testid,t.test_name,t.charges as test_charges, d.charges as group_charges ,pt.rate as panel_charges,d.groupid from  dc_tp_groupm m left outer join dc_tp_groupd d  on m.groupid=d.groupid  join dc_Tpanel_test pt on d.groupid=pt.groupid join dc_tp_test t on d.testid = t.testid where d.active='Y' and pt.testid=t.testid";
                   if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                       objdbhims.Query += " and d.groupid="+StrGroupID+"";
                   if (!StrPanelID.Equals(Default) && !StrPanelID.Equals(""))
                       objdbhims.Query += " and pt.panelid="+StrPanelID+"";
                   objdbhims.Query += " order by m.name,t.test_name";
                   break;
               case 16: // fill gv => panel test group d
                   
                       objdbhims.Query = "select m.name as groupname,d.testid,t.test_name,t.charges as test_charges,d.charges as group_charges ,null as panel_charges,d.groupid from  dc_tp_groupm m join dc_tp_groupd d  on m.groupid=d.groupid join dc_tp_Test t on t.testid=d.testid where d.active='Y'";
                  
                   if (!StrGroupID.Equals(Default) && !StrGroupID.Equals(""))
                       objdbhims.Query += " and d.groupid="+StrGroupID+"";
                   objdbhims.Query += " order by m.name,t.test_name";
                  
                   break;
               case 17: // fil org , panel class, test
                   objdbhims.Query = "SELECT orgid,name  FROM dc_tp_organization where active='Y' and external='N' ";
                   break;
             
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert()
       {
           if (Valid_form())
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
           if (Valid_form())
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

       public bool Insert_PanelTest(string[,] str,string[,] str_del)
       {
           if (Valid_Paneltest())
           {
               QueryBuilder ObjQB = new QueryBuilder();
               objTrans.Start_Transaction();

               for (int i = 0; i <= str_del.GetUpperBound(0); i++)
               {
                   StrTestID = str_del[i, 0];

                   objdbhims.Query = "delete from dc_tpanel_test where  panelid=" + StrPanelID + " and testid="+StrTestID+" ";
                   StrError = objTrans.DataTrigger_Delete(objdbhims);
                   if (StrError.Equals("True"))
                   {
                       StrError = objTrans.OperationError;
                       objTrans.End_Transaction();
                       return false;
                   }
               }
               for (int i = 0; i <= str.GetUpperBound(0); i++)
               {
                   StrTestID = str[i, 0];

                   objdbhims.Query = "delete from dc_tpanel_test where  panelid=" + StrPanelID + " and testid=" + StrTestID + " ";
                   StrError = objTrans.DataTrigger_Delete(objdbhims);
                   if (StrError.Equals("True"))
                   {
                       StrError = objTrans.OperationError;
                       objTrans.End_Transaction();
                       return false;
                   }
               }

               if (!StrError.Equals("True"))
               {
                   for (int i = 0; i <= str.GetUpperBound(0); i++)
                   {
                       StrTestID = str[i, 0];
                       StrRate = str[i, 1];
                       StrUrgent = str[i, 2];
                       Strpercentdiscount = str[i, 3];
                       StrPanelTestCode = str[i, 4];
                       StrPanelSharepercent = str[i, 5];
                       objdbhims.Query = ObjQB.QBInsert(MakeArray_PanelTest(), "dc_tpanel_test");
                       StrError = objTrans.DataTrigger_Insert(objdbhims);

                       if (StrError.Equals("True"))
                       {
                           StrError = objTrans.OperationError;
                           objTrans.End_Transaction();
                           return false;
                       }
                   }

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
                   objTrans.End_Transaction();
                   StrError = objTrans.OperationError;
                   return false;
               }
           }
           else
           {
               return false;
           }
 
       }

       public bool Insert_PanelGroup(string[,] str, string[,] str_del)
       {
           if (Valid_Paneltest())
           {
               QueryBuilder ObjQB = new QueryBuilder();
               objTrans.Start_Transaction();

               for (int i = 0; i <= str_del.GetUpperBound(0); i++)
               {
                   StrTestID = str_del[i, 0];
                   StrGroupID = str_del[i, 1];

                   objdbhims.Query = "delete from dc_tpanel_test where  panelid=" + StrPanelID + " and testid=" + StrTestID + " and groupid="+StrGroupID+" ";
                   StrError = objTrans.DataTrigger_Delete(objdbhims);
                   if (StrError.Equals("True"))
                   {
                       StrError = objTrans.OperationError;
                       objTrans.End_Transaction();
                       return false;
                   }
               }
               for (int i = 0; i <= str.GetUpperBound(0); i++)
               {
                   StrTestID = str[i, 0];
                   StrGroupID = str[i, 2];

                   objdbhims.Query = "delete from dc_tpanel_test where  panelid=" + StrPanelID + " and testid=" + StrTestID + " and groupid="+StrGroupID+" ";
                   StrError = objTrans.DataTrigger_Delete(objdbhims);
                   if (StrError.Equals("True"))
                   {
                       StrError = objTrans.OperationError;
                       objTrans.End_Transaction();
                       return false;
                   }
               }

               if (!StrError.Equals("True"))
               {
                   for (int i = 0; i <= str.GetUpperBound(0); i++)
                   {
                       StrTestID = str[i, 0];
                       StrRate = str[i, 1];
                       StrGroupID = str[i, 2];

                       objdbhims.Query = ObjQB.QBInsert(MakeArray_PanelTest(), "dc_tpanel_test");
                       StrError = objTrans.DataTrigger_Insert(objdbhims);

                       if (StrError.Equals("True"))
                       {
                           StrError = objTrans.OperationError;
                           objTrans.End_Transaction();
                           return false;
                       }
                   }

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
                   objTrans.End_Transaction();
                   StrError = objTrans.OperationError;
                   return false;
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
               kd_arr[0, 0] = "classid";
               kd_arr[0, 1] = this.StrClassID;
               kd_arr[0, 2] = "int";
           }
           if (!StrPanelID.Equals(Default))
           {
               kd_arr[1, 0] = "panelid";
               kd_arr[1, 1] = this.StrPanelID;
               kd_arr[1, 2] = "int";
           }
           if (!StrName.Equals(Default))
           {
               kd_arr[2, 0] = "name";
               kd_arr[2, 1] = this.StrName;
               kd_arr[2, 2] = "string";
           }
           if (!StrActive.Equals(Default))
           {
               kd_arr[3, 0] = "active";
               kd_arr[3, 1] = this.StrActive;
               kd_arr[3, 2] = "string";
           }
           if (!StrDescription.Equals(Default))
           {
               kd_arr[4, 0] = "description";
               kd_arr[4, 1] = this.StrDescription;
               kd_arr[4, 2] = "string";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kd_arr[5, 0] = "enteredby";
               kd_arr[5, 1] = this.StrEnteredBy;
               kd_arr[5, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kd_arr[6, 0] = "enteredon";
               kd_arr[6, 1] = this.StrEnteredOn;
               kd_arr[6, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kd_arr[7, 0] = "clientid";
               kd_arr[7, 1] = this.StrClientID;
               kd_arr[7, 2] = "string";
           }
           return kd_arr;
       }

       private string[,] MakeArray_PanelTest()
       {
           string[,] kd_ary = new string[13, 3];
           if (!StrTestID.Equals(Default))
           {
               kd_ary[0, 0] = "testid";
               kd_ary[0, 1] = this.StrTestID;
               kd_ary[0, 2] = "int";
           }
           if (!StrClassID.Equals(Default))
           {
               kd_ary[1, 0] = "classid";
               kd_ary[1, 1] = this.StrClassID;
               kd_ary[1, 2] = "int";
           }
           if (!StrPanelID.Equals(Default))
           {
               kd_ary[2, 0] = "panelid";
               kd_ary[2, 1] = this.StrPanelID;
               kd_ary[2, 2] = "int";
           }
           if (!StrActive.Equals(Default))
           {
               kd_ary[3, 0] = "active";
               kd_ary[3, 1] = this.StrActive;
               kd_ary[3, 2] = "string";
           }
           if (!StrRate.Equals(Default))
           {
               kd_ary[4, 0] = "rate";
               kd_ary[4, 1] = this.StrRate;
               kd_ary[4, 2] = "int";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kd_ary[5, 0] = "enteredby";
               kd_ary[5, 1] = this.StrEnteredBy;
               kd_ary[5, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kd_ary[6, 0] = "enteredon";
               kd_ary[6, 1] = this.StrEnteredOn;
               kd_ary[6, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kd_ary[7, 0] = "clientid";
               kd_ary[7, 1] = this.StrClientID;
               kd_ary[7, 2] = "string";
           }
           if (!StrUrgent.Equals(Default))
           {
               kd_ary[8, 0] = "urgentrate";
               kd_ary[8, 1] = this.StrUrgent;
               kd_ary[8, 2] = "int";
           }
           if (!StrGroupID.Equals(Default))
           {
               kd_ary[9, 0] = "groupid";
               kd_ary[9, 1] = this.StrGroupID;
               kd_ary[9, 2] = "int";
           }
           if (!Strpercentdiscount.Equals(Default))
           {
               kd_ary[10, 0] = "percentdiscount";
               kd_ary[10, 1] = this.Strpercentdiscount;
               kd_ary[10, 2] = "int";
           }
           if (!StrPanelTestCode.Equals(Default))
           {
               kd_ary[11, 0] = "PanelTestCode";
               kd_ary[11, 1] = this.StrPanelTestCode;
               kd_ary[11, 2] = "string";
           }
           if (!StrPanelSharepercent.Equals(Default))
           {
               kd_ary[12, 0] = "PanelSharepercent";
               kd_ary[12, 1] = this.StrPanelSharepercent;
               kd_ary[12, 2] = "int";
           }
           return kd_ary;
       }

       private bool Valid_form()
       {
           DataView dv = GetAll(3);
           if (dv.Count > 0)
           {
               if (!StrClassID.Equals(Default) && !StrClassID.Equals("") && StrClassID != null)
                   dv.RowFilter = "classid <>" + StrClassID;
               if (dv.Count > 0)
               {
                   StrError = "Please enter other class.This class is already exist agianst this Panel.";
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

       private bool Valid_Paneltest()
       {
           //DataView dv = GetAll(7);
           //if (dv.Count > 0)
           //{
           //    if (!StrOld_TestID.Equals(Default) && !StrOld_TestID.Equals("") && StrOld_TestID != null)
           //        dv.RowFilter = "testid <>" + StrTestID;
           //    if (dv.Count > 0)
           //    {
           //        StrError = "Please select other test.This test is already configured";
           //        return false;
           //    }
           //    else
           //    {
           //        return true;
           //    }
           //}
           //else
           //{
               return true;
           //}

       }

       #endregion
   }
}
