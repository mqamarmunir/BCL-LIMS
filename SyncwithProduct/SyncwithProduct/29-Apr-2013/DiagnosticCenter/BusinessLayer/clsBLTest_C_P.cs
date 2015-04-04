using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLTest_C_P
   {
       clsoperation objTrans = new clsoperation();
       clsdbhims objdbhims = new clsdbhims();

       #region"Variables"

       private const string TableName = "dc_ttest_c_p";
       private const string Default = "~!@";
       private string StrError = Default;

       private string StrCPID = Default;
       private string StrTestID = Default;
       private string StrPersonID = Default;
       private string StrActive = Default;

       private string StrComent = Default;
       private string StrOpinion = Default;
       private string StrSubDept = Default;

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

       public string CPID
       {
           get { return StrCPID; }
           set { StrCPID = value; }
       }
       public string TestID
       {
           get { return StrTestID; }
           set { StrTestID = value; }
       }
       public string PersonID
       {
           get { return StrPersonID; }
           set { StrPersonID = value; }
       }
       public string Active
       {
           get { return StrActive; }
           set { StrActive = value; }
       }

       public string Coment
       {
           get { return StrComent; }
           set { StrComent = value; }
       }
       public string Opinion
       {
           get { return StrOpinion; }
           set { StrOpinion = value; }
       }
       public string SubDeptID
       {
           get { return StrSubDept; }
           set { StrSubDept = value; }
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

       #region"Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1: // fill gv
                   objdbhims.Query = "select cp.cpid,cp.testid,cp.personid,cp.active,concat(salutation,fname,' ',ifnull(mname,''),' ',ifnull(lname,'') ) as personname,cp.comment,cp.opinion from dc_ttest_c_p cp left outer join dc_tp_personnel p on cp.personid=p.personid where cp.testid="+StrTestID+"";
                   break;
               case 2: // fill test
                   objdbhims.Query = "select testid,test_name from dc_tp_test where active='Y'";
                   if (!StrSubDept.Equals(Default) && !StrSubDept.Equals("-1"))
                       objdbhims.Query += " and subdepartmentid='"+StrSubDept+"'";
                   break;
               case 3://fill sub depart
                   objdbhims.Query = "SELECT subdepartmentid,name FROM dc_tp_subdepartments where active='Y'";
                   break;
               case 4: // fill person
                   objdbhims.Query = "SELECT concat(salutation,fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as name,personid FROM dc_tp_personnel where active='Y'";
                   break;
               case 5: // fill test
                   objdbhims.Query = "select testid,test_name from dc_tp_test where active='Y' LIMIT 200";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert()
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
       public bool Update()
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

       private string[,] MakeArray()
       {
           string[,] kldcarr = new string[9, 3];

           if (!StrCPID.Equals(Default))
           {
               kldcarr[0, 0] = "cpid";
               kldcarr[0, 1] = this.StrCPID;
               kldcarr[0, 2] = "int";
           }
           if (!StrTestID.Equals(Default))
           {
               kldcarr[1, 0] = "testid";
               kldcarr[1, 1] = this.StrTestID;
               kldcarr[1, 2] = "int";
           }
           if (!StrPersonID.Equals(Default))
           {
               kldcarr[2, 0] = "personid";
               kldcarr[2, 1] = this.StrPersonID;
               kldcarr[2, 2] = "int";
           }
           if (!StrComent.Equals(Default))
           {
               kldcarr[3, 0] = "comment";
               kldcarr[3, 1] = this.StrComent;
               kldcarr[3, 2] = "string";
           }
           if (!StrOpinion.Equals(Default))
           {
               kldcarr[4, 0] = "opinion";
               kldcarr[4, 1] = this.StrOpinion;
               kldcarr[4, 2] = "string";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kldcarr[5, 0] = "enteredby";
               kldcarr[5, 1] = this.StrEnteredBy;
               kldcarr[5, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kldcarr[6, 0] = "enteredon";
               kldcarr[6, 1] = this.StrEnteredOn;
               kldcarr[6, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kldcarr[7, 0] = "clientid";
               kldcarr[7, 1] = this.StrClientID;
               kldcarr[7, 2] = "string";
           }
           if (!StrActive.Equals(Default))
           {
               kldcarr[8, 0] = "active";
               kldcarr[8, 1] = this.StrActive;
               kldcarr[8, 2] = "string";
           }
           return kldcarr;
       }

       #endregion
   }
}
