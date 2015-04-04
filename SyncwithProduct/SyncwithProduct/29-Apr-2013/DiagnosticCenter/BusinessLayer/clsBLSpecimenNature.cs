using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLSpecimenNature
    {
       clsoperation objTrans = new clsoperation();
       clsdbhims objdbhims = new clsdbhims();

       #region"Variables"

       private const string TableName = "dc_tp_specimen_Nature";
       private const string Default = "~!@";

       private string StrError = Default;
       private string StrSpecimenNatureID = Default;
       private string StrName = Default;

       private string StrActive = Default;
       private string StrDescription = Default;
       private string StrType = Default;

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
       public string SpecimenNatureID
       {
           get { return StrSpecimenNatureID; }
           set { StrSpecimenNatureID = value; }
       }
       public string Name
       {
           get { return StrName; }
           set { StrName = value; }
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
       public string Type
       {
           get { return StrType; }
           set { StrType = value; }
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
                   objdbhims.Query = "select specimennatureid,name,active,description,case when type='H' then 'Histopathalogy' when type='M' then 'Microbiology' else 'General' end as typename,type from dc_tp_specimen_nature";
                   break;
               case 2:
                   objdbhims.Query = "select specimennatureid from dc_tp_specimen_nature where name='"+StrName+"'";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert()
       {
           if (Validate_Dup())
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
           if (Validate_Dup())
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
           string[,] kdcArr = new string[8, 3];

           if (!StrSpecimenNatureID.Equals(Default))
           {
               kdcArr[0, 0] = "specimennatureid";
               kdcArr[0, 1] = this.StrSpecimenNatureID;
               kdcArr[0, 2] = "int";
           }
           if (!StrName.Equals(Default))
           {
               kdcArr[1, 0] = "name";
               kdcArr[1, 1] = this.StrName;
               kdcArr[1, 2] = "string";
           }
           if (!StrActive.Equals(Default))
           {
               kdcArr[2, 0] = "active";
               kdcArr[2, 1] = this.StrActive;
               kdcArr[2, 2] = "string";
           }
           if (!StrDescription.Equals(Default))
           {
               kdcArr[3, 0] = "description";
               kdcArr[3, 1] = this.StrDescription;
               kdcArr[3, 2] = "string";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kdcArr[4, 0] = "enteredby";
               kdcArr[4, 1] = this.StrEnteredBy;
               kdcArr[4, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kdcArr[5, 0] = "enteredon";
               kdcArr[5, 1] = this.StrEnteredOn;
               kdcArr[5, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kdcArr[6, 0] = "clientID";
               kdcArr[6, 1] = this.StrClientID;
               kdcArr[6, 2] = "string";
           }
           if (!StrType.Equals(Default))
           {
               kdcArr[7, 0] = "type";
               kdcArr[7, 1] = this.StrType;
               kdcArr[7, 2] = "string";
           }
           return kdcArr;
       }

       private bool Validate_Dup()
       {
           DataView dv = GetAll(2);

           if (dv.Count > 0)
           {
               if (!StrSpecimenNatureID.Equals(Default) && !StrSpecimenNatureID.Equals("") && StrSpecimenNatureID != null)
                   dv.RowFilter = "specimennatureid <>"+StrSpecimenNatureID+"";
               if (dv.Count > 0)
               {
                   StrError = "This specimen nature already registered.";
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
