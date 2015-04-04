using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLPanel
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region"Variables"

       private const string Default = "~!@";
       private const string TableName = "dc_tpanel";

       private string StrPanelID = Default;
       private string StrName = Default;
       private string StrActive = Default;

       private string StrAcronym = Default;
       private string StrAddress = Default;
       private string StrPhoneNo = Default;

       private string StrEmail = Default;
       private string StrFax = Default;
       private string StrDiscount = Default;
       private string StrRpt_Format = Default;

       private string StrReg_Date = Default;
       private string StrExp_Date = Default;
       private string StrContactPerson = Default;
       private string StrCP_Designation = Default;

       private string StrCP_ContactNo = Default;
       private string StrCP_Email = Default;
       private string StrAuthorization_Required = Default;
       private string StrPrint_Amt = Default;
       private string _CashPanel = Default;
       private string _panel_cliq_id = Default;

       
     
       private string StrLogin = Default;
       private string StrPassword = Default;
       private string StrEnteredBy = Default;

       private string StrENteredOn = Default;
       private string StrCLientID = Default;
       private string StrError = Default;

       #endregion

       #region"Properties"
       public string Panel_cliq_id
       {
           get { return _panel_cliq_id; }
           set { _panel_cliq_id = value; }
       }
       public string CashPanel
       {
           get { return _CashPanel; }
           set { _CashPanel = value; }
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
       public string Address
       {
           get { return StrAddress; }
           set { StrAddress = value; }
       }
       public string PhoneNO
       {
           get { return StrPhoneNo; }
           set { StrPhoneNo = value; }
       }

       public string Email
       {
           get { return StrEmail; }
           set { StrEmail = value; }
       }
       public string Fax
       {
           get { return StrFax; }
           set { StrFax = value; }
       }
       public string Discount
       {
           get { return StrDiscount; }
           set { StrDiscount = value; }
       }
       public string Rpt_Format
       {
           get { return StrRpt_Format; }
           set { StrRpt_Format = value; }
       }

       public string Reg_Date
       {
           get { return StrReg_Date; }
           set { StrReg_Date = value; }
       }
       public string Exp_Date
       {
           get { return StrExp_Date; }
           set { StrExp_Date = value; }
       }
       public string Contact_person
       {
           get { return StrContactPerson; }
           set { StrContactPerson = value; }
       }
       public string CP_Designation
       {
           get { return StrCP_Designation; }
           set { StrCP_Designation = value; }
       }

       public string CP_ContactNo
       {
           get { return StrCP_ContactNo; }
           set { StrCP_ContactNo = value; }
       }
       public string CP_Email
       {
           get { return StrCP_Email; }
           set { StrCP_Email = value; }
       }
       public string Login
       {
           get { return StrLogin; }
           set { StrLogin = value; }
       }

       public string Pasword
       {
           get { return StrPassword; }
           set { StrPassword = value; }
       }
       public string EnteredOn
       {
           get { return StrENteredOn; }
           set { StrENteredOn = value; }
       }
       public string Authorization_Required
       {
           get { return StrAuthorization_Required; }
           set { StrAuthorization_Required = value; }
       }
       public string Print_Amt
       {
           get { return StrPrint_Amt; }
           set { StrPrint_Amt = value; }
       }

       public string EnteredBy
       {
           get { return StrEnteredBy; }
           set { StrEnteredBy = value; }
       }
       public string ClientID
       {
           get { return StrCLientID; }
           set { StrCLientID = value; }
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
               case 1: // fill GV
                   objdbhims.Query = "select cashPanel,panelid,name,active,acronym,address,phoneno,email,fax,discount,date_format(reg_date,'%d/%m/%Y') as reg_date,date_format(exp_date,'%d/%m/%Y') as exp_date,contact_person,cp_designation,cp_contactno,cp_email,login,pasword,authorization_required,rpt_format,clientid,print_amount from dc_tpanel where clientid='" + StrCLientID + "'";
                   break;
               case 2: // check panel name duplicate
                   objdbhims.Query = "select panelid from dc_tpanel where name= '" + StrName + "' and clientid='" + StrCLientID + "'";
                   break;
               case 3: // check loginid duplicate
                   objdbhims.Query = "select panelid from dc_tpanel where login='" + StrLogin + "' and clientid='" + StrCLientID + "'";
                   break;
               case 4:
                   objdbhims.Query = "select panelid from dc_tpanel where acronym='" + StrAcronym + "' and clientid='" + StrCLientID + "'";
                   break;
               case 5:
                   objdbhims.Query = "SELECT PanelID,name,panel_cliq_id FROM dc_tpanel where Active='Y'";
                   break;
               case 6:
                   objdbhims.Query = "SELECT  distinct(Year(enteredOn)) as Year FROM dc_tpatient_bookingm";
                   break;
               case 7: // fill org
                   objdbhims.Query = "SELECT orgid,name  FROM dc_tp_organization where active='Y' and external='N' ";
                   break;
               case 8:
                   objdbhims.Query = "SELECT PanelID,name FROM dc_tpanel where Active='Y' and clientid ='"+StrCLientID+"'";
                   break;
               case 9:
                   objdbhims.Query = "Select name,panel_cliq_id From dc_tpanel where panelID=" + StrPanelID;
                   break;
               case 10:
                   objdbhims.Query = "Select panelid,name from dc_tpanel where panel_cliq_id=" + _panel_cliq_id;
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert()
       {
           if (Valid_Form())
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
           if (Valid_Form())
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
           string[,] kd_arr = new string[24, 3];

           if (!StrPanelID.Equals(Default))
           {
               kd_arr[0, 0] = "panelid";
               kd_arr[0, 1] = this.StrPanelID;
               kd_arr[0, 2] = "int";
           }
           if (!StrName.Equals(Default))
           {
               kd_arr[1, 0] = "name";
               kd_arr[1, 1] = this.StrName;
               kd_arr[1, 2] = "string";
           }
           if (!StrActive.Equals(Default))
           {
               kd_arr[2, 0] = "active";
               kd_arr[2, 1] = this.StrActive;
               kd_arr[2, 2] = "string";
           }
           if (!StrAcronym.Equals(Default))
           {
               kd_arr[3, 0] = "acronym";
               kd_arr[3, 1] = this.StrAcronym;
               kd_arr[3, 2] = "string";
           }
           if (!StrAddress.Equals(Default))
           {
               kd_arr[4, 0] = "address";
               kd_arr[4, 1] = this.StrAddress;
               kd_arr[4, 2] = "string";
           }
           if (!StrPhoneNo.Equals(Default))
           {
               kd_arr[5, 0] = "phoneno";
               kd_arr[5, 1] = this.StrPhoneNo;
               kd_arr[5, 2] = "int";
           }
           if (!StrEmail.Equals(Default))
           {
               kd_arr[6, 0] = "email";
               kd_arr[6, 1] = this.StrEmail;
               kd_arr[6, 2] = "string";
           }
           if (!StrFax.Equals(Default))
           {
               kd_arr[7, 0] = "fax";
               kd_arr[7, 1] = this.StrFax;
               kd_arr[7, 2] = "string";
           }
           if (!StrDiscount.Equals(Default))
           {
               kd_arr[8, 0] = "discount";
               kd_arr[8, 1] = this.StrDiscount;
               kd_arr[8, 2] = "int";
           }
           if (!StrReg_Date.Equals(Default))
           {
               kd_arr[9, 0] = "reg_date";
               kd_arr[9, 1] = this.StrReg_Date;
               kd_arr[9, 2] = "date";
           }
           if (!StrContactPerson.Equals(Default))
           {
               kd_arr[10, 0] = "contact_person";
               kd_arr[10, 1] = this.StrContactPerson;
               kd_arr[10, 2] = "string";
           }
           if (!StrCP_Designation.Equals(Default))
           {
               kd_arr[11, 0] = "cp_designation";
               kd_arr[11, 1] = this.StrCP_Designation;
               kd_arr[11, 2] = "string";
           }
           if (!StrCP_ContactNo.Equals(Default))
           {
               kd_arr[12, 0] = "cp_contactno";
               kd_arr[12, 1] = this.StrCP_ContactNo;
               kd_arr[12, 2] = "string";
           }
           if (!StrCP_Email.Equals(Default))
           {
               kd_arr[13, 0] = "cp_email";
               kd_arr[13, 1] = this.StrCP_Email;
               kd_arr[13, 2] = "string";
           }
           if (!StrAuthorization_Required.Equals(Default))
           {
               kd_arr[14, 0] = "authorization_required";
               kd_arr[14, 1] = this.StrAuthorization_Required;
               kd_arr[14, 2] = "string";
           }
           if (!StrLogin.Equals(Default))
           {
               kd_arr[15, 0] = "login";
               kd_arr[15, 1] = this.StrLogin;
               kd_arr[15, 2] = "string";
           }
           if (!StrPassword.Equals(Default))
           {
               kd_arr[16, 0] = "pasword";
               kd_arr[16, 1] = this.StrPassword;
               kd_arr[16, 2] = "string";
           }
           if (!StrEnteredBy.Equals(Default))
           {
               kd_arr[17, 0] = "enteredby";
               kd_arr[17, 1] = this.StrEnteredBy;
               kd_arr[17, 2] = "int";
           }
           if (!StrENteredOn.Equals(Default))
           {
               kd_arr[18, 0] = "enteredon";
               kd_arr[18, 1] = this.StrENteredOn;
               kd_arr[18, 2] = "datetime";
           }
           if (!StrCLientID.Equals(Default))
           {
               kd_arr[19, 0] = "clientid";
               kd_arr[19, 1] = this.StrCLientID;
               kd_arr[19, 2] = "string";
           }
           if (!StrExp_Date.Equals(Default))
           {
               kd_arr[20, 0] = "exp_date";
               kd_arr[20, 1] = this.StrExp_Date;
               kd_arr[20, 2] = "date";
           }
           if (!StrRpt_Format.Equals(Default))
           {
               kd_arr[21, 0] = "rpt_format";
               kd_arr[21, 1] = this.StrRpt_Format;
               kd_arr[21, 2] = "int";
           }
           if (!StrPrint_Amt.Equals(Default))
           {
               kd_arr[22, 0] = "print_amount";
               kd_arr[22, 1] = this.StrPrint_Amt;
               kd_arr[22, 2] = "string";
           }
           if (!_CashPanel.Equals(Default))
           {
               kd_arr[23, 0] = "CashPanel";
               kd_arr[23, 1] = this._CashPanel;
               kd_arr[23, 2] = "string";
           }
           return kd_arr;
       }

       private bool Valid_Form()
       {
           if (!VD_Name())
           {
               return false;
           }
           if (!VD_Acronym())
           {
               return false;
           }
           if (!VD_Login())
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
               if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("") && StrPanelID != null)
                   dv.RowFilter = "panelid<>" + StrPanelID;
               if (dv.Count > 0)
               {
                   StrError = "This panel comapny is already exist.Please enter other panel company";
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
       private bool VD_Login()
       {
           DataView dv = GetAll(3);
           if (dv.Count > 0)
           {
               if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("") && StrPanelID != null)
                   dv.RowFilter = "panelid<>" + StrPanelID;
               if (dv.Count > 0)
               {
                   StrError = "This login is already exist.Please enter other login";
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
           DataView dv = GetAll(4);
           if (dv.Count > 0)
           {
               if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("") && StrPanelID != null)
                   dv.RowFilter = "panelid<>" + StrPanelID;
               if (dv.Count > 0)
               {
                   StrError = "This acronym is already exist.Please enter other acronym";
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
