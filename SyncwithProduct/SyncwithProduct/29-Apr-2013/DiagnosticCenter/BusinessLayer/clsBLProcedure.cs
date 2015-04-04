using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
   public class clsBLProcedure
   {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region"Variables"

       private const string Default = "~!@";
       private const string TableName = "dc_tp_tprocedurem";

       private string StrProcedureID = Default;
       private string StrName = Default;
       private string StrAcronym = Default;

       private string StrEnteredOn = Default;
       private string StrEnteredBy = Default;
       private string StrClientID = Default;

       private string StrProcessID = Default;
       private string StrActive = Default;
       private string StrError = Default;
       private string StrD_Active = Default;

       private string StrOld_ProcedureID = Default;
       private string StrOld_ProcessID = Default;

       #endregion

       #region"Properties"

       public string ProcedureID
       {
           get { return StrProcedureID; }
           set { StrProcedureID = value; }
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

       public string ProcessID
       {
           get { return StrProcessID; }
           set { StrProcessID = value; }
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
       public string D_Active
       {
           get { return StrD_Active; }
           set { StrD_Active = value; }
       }

       public string Old_ProcedureID
       {
           get { return StrOld_ProcedureID; }
           set { StrOld_ProcedureID = value; }
       }
       public string Old_ProcessID
       {
           get { return StrOld_ProcessID; }
           set { StrOld_ProcessID = value; }
       }

       #endregion

       #region"Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1: // fill grid
                   objdbhims.Query = "select procedureid,name,acronym,active from dc_tp_tprocedurem";
                   break;
               case 2: // procedure duplicate
                   objdbhims.Query = "select procedureid from dc_tp_tprocedurem where name = '"+StrName+"'";
                   break;
               case 3: // acronym duplicate
                   objdbhims.Query = "select procedureid from dc_tp_tprocedurem where acronym = '" + StrAcronym+"'";
                   break;
               case 4: // fill procedure d drop down process
                   objdbhims.Query = "select procedureid,name from dc_tp_tprocedurem where active='Y'";
                   break;
               case 5: // fill procedure d drop down process
                   objdbhims.Query = "Select processid,name from dc_tp_tprocess where active='Y'";
                   break;
               case 6: // fill gv procedure D
                   objdbhims.Query = "SELECT d.procedureid,d.processid,m.name as procedurename,pr.name as processname,d.active FROM dc_tp_tprocedured d left outer join dc_tp_tprocess pr on d.processid=pr.processid left outer join dc_tp_tprocedurem m on d.procedureid = m.procedureid where d.procedureid = "+StrProcedureID+"";

                   break;
               case 7: // procedure d duplicate validate
                   objdbhims.Query = "select processid, procedureid from dc_tp_tprocedured where procedureid = "+StrProcedureID+" and processid="+StrProcessID+"";
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

       public bool InsertProcedureD()
       {
           if (VD_ProcedureD())
           {
               objTrans.Start_Transaction();

               if (!StrOld_ProcedureID.Equals(Default) && !StrOld_ProcessID.Equals(Default) && !StrOld_ProcedureID.Equals("") && !StrOld_ProcessID.Equals(""))
               {
                   objdbhims.Query = "delete from dc_tp_tprocedured where processid=" + StrOld_ProcessID + " and procedureid=" + StrOld_ProcedureID + "";
                   StrError = objTrans.DataTrigger_Delete(objdbhims);
               }

               if (StrError.Equals("True"))
               {
                   StrError = objTrans.OperationError;
                   objTrans.End_Transaction();
                   return false;
               }

               objdbhims.Query = "insert into dc_tp_tprocedured (procedureid,processid,enteredby,enteredon,clientid,active) values (" + StrProcedureID + "," + StrProcessID + "," + StrEnteredBy + ",str_to_date('" + StrEnteredOn + "','%d/%m/%Y %h:%i:%s %p'),'" + StrClientID + "','"+StrD_Active+"')";
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
          
       private string[,] MakeArray()
       {
           string[,] kd_arr = new string[7, 3];

           if (!StrProcedureID.Equals(Default))
           {
               kd_arr[0, 0] = "procedureid";
               kd_arr[0, 1] = this.StrProcedureID;
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
               if (!StrProcedureID.Equals(Default) && !StrProcedureID.Equals("") && StrProcedureID != null)
                   dv.RowFilter = "procedureid <>" + StrProcedureID;
               if (dv.Count > 0)
               {
                   StrError = "please enter other procedure name.It is already exist";
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
               if (!StrProcedureID.Equals(Default) && !StrProcedureID.Equals("") && StrProcedureID != null)
                   dv.RowFilter = "procedureid <>" + StrProcedureID;
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

       private bool VD_ProcedureD()
       {
           DataView dv = GetAll(7);
           if (dv.Count > 0)
           {
               if (!StrOld_ProcedureID.Equals(Default) && !StrOld_ProcedureID.Equals("") && StrOld_ProcedureID != null)
                   dv.RowFilter = "processid =" + StrProcessID;
               if (dv.Count > 0)
               {
                   StrError = "This procedure and process has alread configured";
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
