using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLUserRight
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region"Variables"

       private const string Default = "~!@";
       private const string TableName = "dc_tu_userright";

       private string StrError = Default;
       private string StrRightID = Default;
       private string StrPersonID = Default;

       private string StrGroupID = Default;
       private string StrActive = Default;
       private string StrEnteredOn = Default;

       private string StrEnteredBy = Default;
       private string StrClientID = Default;
       private string StrDefaultPage = Default;

       #endregion

       #region"Properties"

       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }
       public string RighTID
       {
           get { return StrRightID; }
           set { StrRightID = value; }
       }
       public string PersonID
       {
           get { return StrPersonID; }
           set { StrPersonID = value; }
       }

       public string GroupID
       {
           get { return StrGroupID; }
           set { StrGroupID = value; }
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
       public string DefaultPage
       {
           get { return StrDefaultPage; }
           set { StrDefaultPage = value; }
       }

       #endregion

       #region"Method"

       public DataView GetALL(int flag)
       {
           switch(flag)
           {
               case 1: // fill group ddl
                   objdbhims.Query = "SELECT d.groupid,d.groupname FROM dc_tu_accessgroup d where d.active='Y'";
                   break;
               case 2: // personnel group ddl
                   objdbhims.Query = "SELECT d.personid,concat(d.salutation,d.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as personname FROM dc_tp_personnel d where active='Y';";
                   break;
               case 3: // fill GV
                   objdbhims.Query = "SELECT d.rightid,d.groupid,d.personid,d.active,concat(p.salutation,'',p.fname,' ',ifnull(p.mname,''),' ',ifnull(p.lname,'')) as personname,d.defaultpage,a.optionname as pagename FROM dc_tu_userright d left outer join dc_tp_personnel p on p.personid = d.personid  left outer join dc_tu_accessoption a on d.defaultpage =a.optionid where d.groupid=" + StrGroupID + "";
                   break;
               case 4: // Validation check
                   objdbhims.Query = "select rightid from dc_tu_userright where groupid="+StrGroupID+" and personid="+StrPersonID+"";
                   break;
               case 5: // validation check only group 
                   objdbhims.Query = "select groupid from dc_tu_userright where personid ="+StrPersonID+" and active='Y'";
                   break;
               case 6: //page fill
                   objdbhims.Query = "SELECT distinct o.optionid as pageid,o.optionname as pagename FROM dc_tu_accessoption o left outer join dc_tu_groupright r on o.optionid=r.optionid  where r.groupid=" + StrGroupID + " and o.active='Y' order by o.optionid ";
                   break;
               case 7:
                   objdbhims.Query = @"SELECT ur.rightid,dtg.groupid,dta.optionname,dta.optionid
                                      FROM dc_tu_userright ur,dc_tu_groupright dtg,dc_tu_accessoption dta
                                    WHERE dtg.groupid=ur.groupid
                                    AND dta.optionid=dtg.optionid
                                    and ur.personid="+StrPersonID+@"
                                    AND dta.`type`='link'";
                   break;
               case 8:
                   objdbhims.Query = objdbhims.Query = @"select * from dc_tcashcheckin where cashierid=" + StrPersonID + @" and
                                    cashChkin_id=(select max(cashChkin_id) from dc_tcashcheckin where cashierid=" + StrPersonID + ")";

                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert()
       {
           if (Validate_Form())
           {
               QueryBuilder objQB = new QueryBuilder();

               objTrans.Start_Transaction();

               objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
               StrError = objTrans.DataTrigger_Insert(objdbhims);

               if (!StrError.Equals("True"))
               {
                   objTrans.End_Transaction();
                   return true;
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

       public bool Update()
       {
           if (Validate_Form())
           {
               QueryBuilder objQB = new QueryBuilder();

               objTrans.Start_Transaction();

               objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
               StrError = objTrans.DataTrigger_Update(objdbhims);

               if (!StrError.Equals("True"))
               {
                   objTrans.End_Transaction();
                   return true;
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
           string[,] kdc_arr = new string[8, 3];

           if (!StrRightID.Equals(Default))
           {
               kdc_arr[0, 0] = "rightid";
               kdc_arr[0, 1] = this.StrRightID;
               kdc_arr[0, 2] = "int";
           }
           if (!StrGroupID.Equals(Default))
           {
               kdc_arr[1, 0] = "groupid";
               kdc_arr[1, 1] = this.StrGroupID;
               kdc_arr[1, 2] = "int";
           }
           if (!StrPersonID.Equals(Default))
           {
               kdc_arr[2, 0] = "personid";
               kdc_arr[2, 1] = this.StrPersonID;
               kdc_arr[2, 2] = "int";
           }
           if (!StrActive.Equals(Default))
           {
               kdc_arr[3, 0] = "active";
               kdc_arr[3, 1] = this.StrActive;
               kdc_arr[3, 2] = "string";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kdc_arr[4, 0] = "enteredby";
               kdc_arr[4, 1] = this.StrEnteredBy;
               kdc_arr[4, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kdc_arr[5, 0] = "enteredon";
               kdc_arr[5, 1] = this.StrEnteredOn;
               kdc_arr[5, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kdc_arr[6, 0] = "clientid";
               kdc_arr[6, 1] = this.StrClientID;
               kdc_arr[6, 2] = "string";
           }
           if (!StrDefaultPage.Equals(Default))
           {
               kdc_arr[7, 0] = "defaultpage";
               kdc_arr[7, 1] = this.StrDefaultPage;
               kdc_arr[7, 2] = "int";
           }
           return kdc_arr;
       }


       private bool Validate_Form()
       {
           if (!Vald_User())
               return false;
           if (!Vald_Group())
               return false;
           else
               return true;
       }
       private bool Vald_User()
       {
           DataView dv = GetALL(4);

           if (dv.Count > 0)
           {
               if (!StrRightID.Equals(Default) && !StrRightID.Equals("") && StrRightID != null)
                   dv.RowFilter = "rightid <>" + StrRightID;
               if (dv.Count > 0)
               {
                   StrError = "This user is already configured with this group";
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

       private bool Vald_Group()
       {
           DataView dv = GetALL(5);

           if (dv.Count > 0)
           {
               if (!StrRightID.Equals(Default) && !StrRightID.Equals(""))
                   dv.RowFilter = "groupid<>"+StrGroupID;
               if (dv.Count > 0)
               {
                   StrError = "This user already configured with other group.";
                   return false;
               }
               else
                   return true;
           }
           else
           {
               return true;
           }
       }
       #endregion
   }
}
