using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLRefDoctor
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region"Variables"

       private const string TableName = "dc_tp_refdoctors";
       private const string Default = "~!@";
       private string StrError = Default;

       private string StrDoctorID = Default;
       private string StrName = Default;
       private string StrReg_Date = Default;

       private string StrShare = Default;
       private string StrActive = Default;
       private string StrDeptID = Default;

       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;
       private string StrClientID = Default;

       private string StrOrgID = Default;
       private string StrPanelID = Default;

       private string StrCellNo = Default;
       private string StrFaxNo = Default;
       private string StrEmail = Default;

       private string StrSpeciality = Default;
       private string StrAddress = Default;
       private string StrCityID = Default;

       private string StrTitle = Default;
       private string StrCode = Default;

       private string StrLoginID = Default;
       private string StrPasword = Default;

       #endregion

       #region"Properties"

       public string DoctorID
       {
           get { return StrDoctorID; }
           set { StrDoctorID = value; }
       }
       public string Name
       {
           get { return StrName; }
           set { StrName = value; }
       }
       public string Reg_date
       {
           get { return StrReg_Date; }
           set { StrReg_Date = value; }
       }

       public string Share
       {
           get { return StrShare; }
           set { StrShare = value; }
       }
       public string Active
       {
           get { return StrActive; }
           set { StrActive = value; }
       }
       public string DeptID
       {
           get { return StrDeptID; }
           set { StrDeptID = value; }
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

       public string OrgID
       {
           get { return StrOrgID; }
           set { StrOrgID = value; }
       }
       public string PanelID
       {
           get { return StrPanelID; }
           set { StrPanelID = value; }
       }

       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }

       public string CellNo
       {
           get { return StrCellNo; }
           set { StrCellNo = value; }
       }
       public string Fax
       {
           get { return StrFaxNo; }
           set { StrFaxNo = value; }
       }
       public string Email
       {
           get { return StrEmail; }
           set { StrEmail = value; }
       }

       public string Speciality
       {
           get { return StrSpeciality; }
           set { StrSpeciality = value; }
       }
       public string Address
       {
           get { return StrAddress; }
           set { StrAddress = value; }
       }
       public string CityID
       {
           get { return StrCityID; }
           set { StrCityID = value; }
       }

       public string Title
       {
           get { return StrTitle; }
           set { StrTitle = value; }
       }
       public string Code
       {
           get { return StrCode; }
           set { StrCode = value; }
       }

       public string LoginID
       {
           get { return StrLoginID; }
           set { StrLoginID = value; }
       }
       public string Pasword
       {
           get { return StrPasword; }
           set { StrPasword = value; }
       }
       #endregion

       #region"Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1: // fillgv
                   objdbhims.Query = "select r.doctorid,r.name,r.share,date_format(r.reg_date,'%d/%m/%Y') as reg_date,r.active,r.departmentid,r.orgid,r.panelid,org.name as orgname,p.name as panelname,r.cellno,r.faxno,r.email,r.specialityid,r.address,r.cityid,ct.name as cityname,r.title,r.code,concat(r.name,' ',r.title) as doctorname,r.loginid,r.pasword from dc_tp_refdoctors r left outer join dc_tp_organization org on r.orgid=org.orgid left outer join dc_tpanel p on r.panelid=p.panelid left outer join  dc_tcity ct on r.cityid=ct.cityid where 1=1";
                   if(!StrDeptID.Equals(Default) && !StrDeptID.Equals("-1"))
                       objdbhims.Query +=" and r.departmentid = "+StrDeptID+"";
                   if (!StrOrgID.Equals(Default) && !StrOrgID.Equals("-1"))
                       objdbhims.Query += " and r.orgid='" + StrOrgID + "'";
                   if (!StrPanelID.Equals(Default) && !StrPanelID.Equals("-1"))
                       objdbhims.Query += " and r.panelid="+StrPanelID+"";
                   break;
               case 2: // check doctor duplicate name
                   objdbhims.Query = "select doctorid from dc_tp_refdoctors where name ='"+StrName+"' and departmentid="+StrDeptID+"";
                   break;
               case 3: // department fill
                   objdbhims.Query = "select departmentid,name from dc_Tp_departments where active='Y'";
                   break;
               case 4: // organization fill
                   objdbhims.Query = "select orgid,name from dc_tp_organization where active='Y'";
                   break;
               case 5: // panel Fill
                   objdbhims.Query = "select panelid,name from dc_tpanel where active='Y'";
                   break;
               case 6: // fill speciality
                   objdbhims.Query = "select specialityid ,name from dc_tp_speciality where active='Y'";
                   break;
               case 7: // fill city
                   objdbhims.Query = "SELECT cityid,name FROM dc_tcity c where countryid='001' and active='Y'";
                   break;
               case 8:
                   objdbhims.Query = "select doctorid from dc_tp_refdoctors where code='"+StrCode+"'";
                   break;
               case 9: // loginID validation
                   objdbhims.Query = " select doctorid from dc_tp_refdoctors where loginid='"+StrLoginID+"' and orgid='"+StrOrgID+"'";
                   break;
               case 10:
                   objdbhims.Query = "Select concat(title,'.',name) as Name From dc_tp_refdoctors where doctorid=" + StrDoctorID;
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
           if (Validate())
           {
               QueryBuilder objQB = new QueryBuilder();

               objTrans.Start_Transaction();
               objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
               StrError = objTrans.DataTrigger_Update(objdbhims);

               if (StrError.Equals("True"))
               {
                  StrError =  objTrans.OperationError;
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
           string[,] kd_arr = new string[21, 3];

           if (!StrDoctorID.Equals(Default))
           {
               kd_arr[0, 0] = "doctorid";
               kd_arr[0, 1] = this.StrDoctorID;
               kd_arr[0, 2] = "int";
           }
           if (!StrName.Equals(Default))
           {
               kd_arr[1, 0] = "name";
               kd_arr[1, 1] = this.StrName;
               kd_arr[1, 2] = "string";
           }
           if (!StrShare.Equals(Default))
           {
               kd_arr[2, 0] = "share";
               kd_arr[2, 1] = this.StrShare;
               kd_arr[2, 2] = "int";
           }
           if (!StrReg_Date.Equals(Default))
           {
               kd_arr[3, 0] = "reg_date";
               kd_arr[3, 1] = this.StrReg_Date;
               kd_arr[3, 2] = "date";
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
           if (!StrDeptID.Equals(Default))
           {
               kd_arr[8, 0] = "departmentid";
               kd_arr[8, 1] = this.StrDeptID;
               kd_arr[8, 2] = "int";
           }
           if (!StrPanelID.Equals(Default))
           {
               kd_arr[9, 0] = "panelid";
               kd_arr[9, 1] = this.StrPanelID;
               kd_arr[9, 2] = "int";
           }
           if (!StrOrgID.Equals(Default))
           {
               kd_arr[10, 0] = "orgid";
               kd_arr[10, 1] = this.StrOrgID;
               kd_arr[10, 2] = "string";
           }
           else
           {
               kd_arr[10, 0] = "orgid";
               kd_arr[10, 1] = "null";
               kd_arr[10, 2] = "int";
           }
           if (!StrCellNo.Equals(Default))
           {
               kd_arr[11, 0] = "cellno";
               kd_arr[11, 1] = this.StrCellNo;
               kd_arr[11, 2] = "string";
           }
           if (!StrFaxNo.Equals(Default))
           {
               kd_arr[12, 0] = "faxno";
               kd_arr[12, 1] = this.StrFaxNo;
               kd_arr[12, 2] = "string";
           }
           if (!StrEmail.Equals(Default))
           {
               kd_arr[13, 0] = "email";
               kd_arr[13, 1] = this.StrEmail;
               kd_arr[13, 2] = "string";
           }
           if (!StrAddress.Equals(Default))
           {
               kd_arr[14, 0] = "address";
               kd_arr[14, 1] = this.StrAddress;
               kd_arr[14, 2] = "string";
           }
           if (!StrSpeciality.Equals(Default))
           {
               kd_arr[15, 0] = "specialityid";
               kd_arr[15, 1] = this.StrSpeciality;
               kd_arr[15, 2] = "int";
           }
           if (!StrCityID.Equals(Default))
           {
               kd_arr[16, 0] = "cityid";
               kd_arr[16, 1] = this.StrCityID;
               kd_arr[16, 2] = "int";
           }
           if (!StrTitle.Equals(Default))
           {
               kd_arr[17, 0] = "title";
               kd_arr[17, 1] = this.StrTitle;
               kd_arr[17, 2] = "string";
           }
           if (!StrCode.Equals(Default))
           {
               kd_arr[18, 0] = "code";
               kd_arr[18, 1] = this.StrCode;
               kd_arr[18, 2] = "string";
           }
           if (!StrLoginID.Equals(Default))
           {
               kd_arr[19, 0] = "loginid";
               kd_arr[19, 1] = this.StrLoginID;
               kd_arr[19, 2] = "string";
           }
           if (!StrPasword.Equals(Default))
           {
               kd_arr[20, 0] = "pasword";
               kd_arr[20, 1] = this.StrPasword;
               kd_arr[20, 2] = "string";
           }
           return kd_arr;
       }

       private bool Validate()
       {
           if (!Vd_Code())
               return false;
           if (!Vd_Login())
               return false;
           else
               return true;
       }
       //private bool Vd_Name()
       //{
       //    DataView dv = GetAll(2);
       //    if (dv.Count > 0)
       //    {
       //        if (!StrDoctorID.Equals(Default) && !StrDoctorID.Equals("") && StrDoctorID != null)
       //            dv.RowFilter = "doctorid <>" + StrDoctorID;
       //        if (dv.Count > 0)
       //        {
       //            StrError = "Please enter other doctor name.This is already exist";
       //            return false;
       //        }
       //        else
       //        {
       //            return true;
       //        }
       //    }
       //    else 
       //    {
       //        return true;
       //    }
       //}
       private bool Vd_Code()
       {
           if (!StrCode.Trim().Equals(""))
           {
               DataView dv = GetAll(8);
               if (dv.Count > 0)
               {
                   if (!StrDoctorID.Equals(Default) && !StrDoctorID.Equals("") && StrDoctorID != null)
                       dv.RowFilter = "doctorid <>" + StrDoctorID;
                   if (dv.Count > 0)
                   {
                       StrError = "Please enter other doctor code.This is already exist";
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
       private bool Vd_Login()
       {
           if (!StrLoginID.Trim().Equals(""))
           {
               DataView dv = GetAll(9);
               if (dv.Count > 0)
               {
                   if (!StrDoctorID.Equals(Default) && !StrDoctorID.Equals("") && StrDoctorID != null)
                       dv.RowFilter = "doctorid <>" + StrDoctorID;
                   if (dv.Count > 0)
                   {
                       StrError = "Please enter other login id.This is already exist";
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
