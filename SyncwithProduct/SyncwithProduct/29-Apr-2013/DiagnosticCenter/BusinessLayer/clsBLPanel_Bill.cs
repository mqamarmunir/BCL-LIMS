using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class clsBLPanel_Bill
    {
       clsdbhims objdbhims = new clsdbhims();
       clsoperation objTrans = new clsoperation();

       #region "Variables"

       private const string Default = "~!@";
       private const string TableName = "dc_tpanel_bill";

       private string StrError = Default;
       private string StrBillID = Default;
       private string StrBill_No = Default;

       private string StrBill_Date = Default;
       private string StrTotalCharges = Default;
       private string StrBilling_Month = Default;

       private string StrPanelID = Default;
       private string StrFrom_Date = Default;
       private string StrTo_Date= Default;

       private string StrBill_Ref1 = Default;
       private string StrBill_Ref2 = Default;
       private string StrAuthorization_No = Default;
       private string StrAuthorization_Date = Default;

       private string StrService_No = Default;
       private string StrDisplay_Date = Default;

       private string StrM_Authorization_No = Default; // booking master
       private string StrM_Bill_Ref1 = Default;//BM
       private string StrM_Bill_Ref2 = Default;//BM
       private string StrM_Authorization_Date = Default;//BM

       private string StrM_Service_No = Default; //BM
       private string StrM_Add_Bill = Default; // BM

       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;
       private string StrClientID = Default;

       private string StrPRID = Default;
       private string StrBookingID = Default;

       private string StrShow_Ref1 = Default;
       private string StrShow_Ref2 = Default;
       private string StrDiscount = Default;

       #endregion

       #region "Properties"

       public string Error
       {
           get { return StrError; }
           set { StrError = value; }
       }
       public string BillID
       {
           get { return StrBillID; }
           set { StrBillID = value; }
       }
       public string Bill_No
       {
           get { return StrBill_No; }
           set { StrBill_No = value; }
       }

       public string Bill_Date
       {
           get { return StrBill_Date; }
           set { StrBill_Date = value; }
       }
       public string TotalCharges
       {
           get { return StrTotalCharges; }
           set { StrTotalCharges = value; }
       }
       public string Billing_Month
       {
           get { return StrBilling_Month; }
           set { StrBilling_Month = value; }
       }

       public string PanelID
       {
           get { return StrPanelID; }
           set { StrPanelID = value; }
       }
       public string From_Date
       {
           get { return StrFrom_Date; }
           set { StrFrom_Date = value; }
       }
       public string To_Date
       {
           get { return StrTo_Date; }
           set { StrTo_Date = value; }
       }

       public string Bill_Ref1
       {
           get { return StrBill_Ref1; }
           set { StrBill_Ref1 = value; }
       }
       public string Bill_Ref2
       {
           get { return StrBill_Ref2; }
           set { StrBill_Ref2 = value; }
       }
       public string Authorization_No
       {
           get { return StrAuthorization_No; }
           set { StrAuthorization_No = value; }
       }
       public string Authorization_Date
       {
           get { return StrAuthorization_Date; }
           set { StrAuthorization_Date = value; }
       }

       public string ServiceNo
       {
           get { return StrService_No; }
           set { StrService_No = value; }
       }
       public string Display_Date
       {
           get { return StrDisplay_Date; }
           set { StrDisplay_Date = value; }
       }

       public string M_Authorize_No
       {
           get { return StrM_Authorization_No; }
           set { StrM_Authorization_No = value; }
       }
       public string M_Bill_Ref1
       {
           get { return StrM_Bill_Ref1; }
           set { StrM_Bill_Ref1 = value; }
       }
       public string M_Bill_Ref2
       {
           get { return StrM_Bill_Ref2; }
           set { StrBill_Ref2 = value; }
       }
       public string M_Authorize_Date
       {
           get { return StrM_Authorization_Date; }
           set { StrM_Authorization_Date = value; }
       }

       public string M_ServiceNo
       {
           get { return StrM_Service_No; }
           set { StrM_Service_No = value; }
       }
       public string Add_Bill
       {
           get { return StrM_Add_Bill; }
           set { StrM_Add_Bill = value; }
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

       public string PRID
       {
           get { return StrPRID; }
           set { StrPRID = value; }
       }
       public string BookingID
       {
           get { return StrBookingID; }
           set { StrBookingID = value; }
       }

       public string Show_Ref1
       {
           get { return StrShow_Ref1; }
           set { StrShow_Ref1 = value; }
       }
       public string Show_Ref2
       {
           get { return StrShow_Ref2; }
           set { StrShow_Ref2 = value; }
       }
       public string Discount
       {
           get { return StrDiscount; }
           set { StrDiscount = value; }
       }
       #endregion

       #region "Method"

       public DataView GetAll(int flag)
       {
           switch (flag)
           {
               case 1:// panel Fill
                   objdbhims.Query = "select panelid,name from dc_tpanel where active='Y'";
                   break;
               case 2: // pending bills gv
                   objdbhims.Query = "select p.prid,p.prno,concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male' else 'Female' end,' : ', case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs') else case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon') else      concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ')   as patientname,m.bookingid,m.labid,group_concat(t.test_name separator ',') as test_name,d.bookingid,m.totalamount,'Y' as add_bill,m.bill_ref1,m.bill_ref2,m.bill_serviceno,'' as authorizeno,date_format(m.authorize_date,'%d/%m/%Y') as authorize_date from dc_tpatient p join dc_tpatient_bookingm m join dc_tpatient_bookingd d join dc_tp_test t where p.prid=m.prid and m.bookingid=d.bookingid and d.testid=t.testid and p.panelid=" + StrPanelID + " and date_format(m.enteredon,'%Y-%m-%d') between '" + StrFrom_Date + "' and '" + StrTo_Date + "' and m.billid is null and m.payment_mode<>'P' and d.status <> 'X'";

                   objdbhims.Query += " group by m.bookingid";
                   
                   break;
               case 3: // fill bills gv
                   objdbhims.Query = "select billid,billno,date_format(bill_date,'%d/%m/%Y') as bill_date,totalcharges,billing_month from dc_tpanel_bill where panelid="+StrPanelID+"";
                   break;
               case 4: // fill gv on Edit
                   objdbhims.Query = "select p.prid,p.prno,concat(ifnull(p.title,''),' ',p.name,' ( ',case when p.gender='M' then 'Male' else 'Female' end,' : ', case when DATEDIFF(CURRENT_DATE,p.dob) > 365 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/365),' Yrs') else case when DATEDIFF(CURRENT_DATE,p.dob) > 30 then concat(Floor(DATEDIFF(CURRENT_DATE,p.dob)/30),' Mon') else concat(DATEDIFF(CURRENT_DATE,p.dob),'Dys') end end,' ) ')   as patientname,m.bookingid,m.labid,group_concat(t.test_name separator ',') as test_name,d.bookingid,m.totalamount,pb.billid,m.add_bill,m.bill_ref1,m.bill_ref2,m.bill_serviceno,m.authorizeno,date_format(m.authorize_date,'%d/%m/%Y') as authorize_date,pb.billno,date_format(pb.bill_date,'%d/%m/%Y') as bill_date,pb.panelid,date_format(pb.fromdate,'%d/%m/%Y') as fromdate,date_format(pb.todate,'%d/%m/%Y') as todate,pb.ref1,pb.ref2,pb.authorize_no as b_authorize_no,date_format(pb.authorize_date,'%d/%m/%Y') as b_authorize_date,pb.service_no,pb.display_date,pb.billing_month,pb.totalcharges,pb.show_ref1,pb.show_ref2,ifnull(pb.discount,0) as discount from dc_tpatient p join dc_tpatient_bookingm m join dc_tpatient_bookingd d join dc_tp_test t join dc_tpanel_bill pb where p.prid=m.prid and m.bookingid=d.bookingid and d.testid=t.testid and pb.billid = m.billid and pb.billid="+StrBillID+" group by m.bookingid";
                   break;
               case 5: // test detail
                   objdbhims.Query = "select t.test_name,d.bookingdid,d.bookingid,t.testid from dc_Tpatient_bookingd d join dc_tp_test t where t.testid=d.testid and d.bookingid="+StrBookingID+"";
                   break;
               case 6: // bill no validate
                   objdbhims.Query = "select billid from dc_tpanel_bill where billno='"+StrBill_No+"'";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool Insert(string[,] str)
       {
           if (VD_Billno())
           {
               QueryBuilder objQB = new QueryBuilder();
               objTrans.Start_Transaction();

               objdbhims.Query = objQB.QBGetMax("billid", TableName);
               StrBillID = objTrans.DataTrigger_Get_Max(objdbhims);
               if (StrError.Equals("True"))
               {
                   objTrans.End_Transaction();
                   StrError = objTrans.OperationError;
                   return false;
               }
               else
               {

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
                       for (int i = 0; i <= str.GetUpperBound(0); i++)
                       {
                           StrPRID = str[i, 0];
                           StrBookingID = str[i, 1];
                           StrM_Bill_Ref1 = str[i, 2];

                           StrM_Bill_Ref2 = str[i, 3];
                           StrM_Service_No = str[i, 4];

                           StrM_Authorization_No = str[i, 5];
                           StrM_Authorization_Date = str[i, 6];
                           StrM_Add_Bill = str[i, 7];

                           //objdbhims.Query = "update dc_tpatient_bookingm set billid=" + StrBillID + " , add_bill='" + StrM_Add_Bill + "', authorizeno='" + StrM_Authorization_No + "' , authorize_date= str_to_date('"+StrM_Authorization_Date+"','%d/%m/%Y'),bill_ref1='"+StrM_Bill_Ref1+"', bill_ref2='"+StrM_Bill_Ref2+"', bill_serviceno='"+StrM_Service_No+"'";
                           objdbhims.Query = objQB.QBUpdate(MakeArray_BookingM(), "dc_tpatient_bookingm");
                           StrError = objTrans.DataTrigger_Update(objdbhims);

                           if (StrError.Equals("True"))
                           {
                               objTrans.End_Transaction();
                               StrError = objTrans.OperationError;
                               return false;
                           }
                       }

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
               }
               return true;
           }
           else
               return false;
       }
       public bool Update(string[,] str)
       {
           if (VD_Billno())
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
                   objdbhims.Query = "update dc_tpatient_bookingm set  add_bill=null, authorizeno=null , authorize_date= null,bill_ref1=null, bill_ref2=null, bill_serviceno=null where billid=" + StrBillID + " ";
                   StrError = objTrans.DataTrigger_Update(objdbhims);

                   if (StrError.Equals("True"))
                   {
                       objTrans.End_Transaction();
                       StrError = objTrans.OperationError;
                       return false;
                   }


                   for (int i = 0; i <= str.GetUpperBound(0); i++)
                   {
                       StrPRID = str[i, 0];
                       StrBookingID = str[i, 1];
                       StrM_Bill_Ref1 = str[i, 2];

                       StrM_Bill_Ref2 = str[i, 3];
                       StrM_Service_No = str[i, 4];

                       StrM_Authorization_No = str[i, 5];
                       StrM_Authorization_Date = str[i, 6];
                       StrM_Add_Bill = str[i, 7];

                       //objdbhims.Query = "update dc_tpatient_bookingm set billid=" + StrBillID + " , add_bill='" + StrM_Add_Bill + "', authorizeno='" + StrM_Authorization_No + "' , authorize_date= str_to_date('"+StrM_Authorization_Date+"','%d/%m/%Y'),bill_ref1='"+StrM_Bill_Ref1+"', bill_ref2='"+StrM_Bill_Ref2+"', bill_serviceno='"+StrM_Service_No+"'";
                       objdbhims.Query = objQB.QBUpdate(MakeArray_BookingM(), "dc_tpatient_bookingm");
                       StrError = objTrans.DataTrigger_Update(objdbhims);

                       if (StrError.Equals("True"))
                       {
                           objTrans.End_Transaction();
                           StrError = objTrans.OperationError;
                           return false;
                       }
                   }
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
               return true;
           }
           return false;
       }

       private string[,] MakeArray()
       {
           string[,] kldc = new string[20, 3];

           if (!StrBillID.Equals(Default))
           {
               kldc[0, 0] = "billid";
               kldc[0, 1] = this.StrBillID;
               kldc[0, 2] = "int";
           }
           if (!StrBill_No.Equals(Default))
           {
               kldc[1, 0] = "billno";
               kldc[1, 1] = this.StrBill_No;
               kldc[1, 2] = "string";
           }
           if (!StrBill_Date.Equals(Default))
           {
               kldc[2, 0] = "bill_date";
               kldc[2, 1] = this.StrBill_Date;
               kldc[2, 2] = "date";
           }
           if (!StrTotalCharges.Equals(Default))
           {
               kldc[3, 0] = "totalcharges";
               kldc[3, 1] = this.StrTotalCharges;
               kldc[3, 2] = "int";
           }
           if (!StrBilling_Month.Equals(Default))
           {
               kldc[4, 0] = "billing_month";
               kldc[4, 1] = this.StrBilling_Month;
               kldc[4, 2] = "string";
           }
           if (!StrPanelID.Equals(Default))
           {
               kldc[5, 0] = "panelid";
               kldc[5, 1] = this.StrPanelID;
               kldc[5, 2] = "int";
           }
           if (!StrFrom_Date.Equals(Default))
           {
               kldc[6, 0] = "fromdate";
               kldc[6, 1] = this.StrFrom_Date;
               kldc[6, 2] = "date";
           }
           if (!StrTo_Date.Equals(Default))
           {
               kldc[7, 0] = "todate";
               kldc[7, 1] = this.StrTo_Date;
               kldc[7, 2] = "date";
           }

           if (!StrBill_Ref1.Equals(Default))
           {
               kldc[8, 0] = "ref1";
               kldc[8, 1] = this.StrBill_Ref1;
               kldc[8, 2] = "string";
           }
           if (!StrBill_Ref2.Equals(Default))
           {
               kldc[9, 0] = "ref2";
               kldc[9, 1] = this.StrBill_Ref2;
               kldc[9, 2] = "string";
           }
           if (!StrAuthorization_No.Equals(Default))
           {
               kldc[10, 0] = "authorize_no";
               kldc[10, 1] = this.StrAuthorization_No;
               kldc[10, 2] = "string";
           }

           if (!StrAuthorization_Date.Equals(Default))
           {
               kldc[11, 0] = "authorize_date";
               kldc[11, 1] = this.StrAuthorization_Date;
               kldc[11, 2] = "date";
           }
           if (!StrService_No.Equals(Default))
           {
               kldc[12, 0] = "service_No";
               kldc[12, 1] = this.StrService_No;
               kldc[12, 2] = "string";
           }
           if (!StrDisplay_Date.Equals(Default))
           {
               kldc[13, 0] = "Display_date";
               kldc[13, 1] = this.StrDisplay_Date;
               kldc[13, 2] = "string";
           }

           if (!StrEnteredBy.Equals(Default))
           {
               kldc[14, 0] = "enteredby";
               kldc[14, 1] = this.StrEnteredBy;
               kldc[14, 2] = "int";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               kldc[15, 0] = "enteredon";
               kldc[15, 1] = this.StrEnteredOn;
               kldc[15, 2] = "datetime";
           }
           if (!StrClientID.Equals(Default))
           {
               kldc[16, 0] = "clientID";
               kldc[16, 1] = this.StrClientID;
               kldc[16, 2] = "string";
           }
           if (!StrShow_Ref1.Equals(Default))
           {
               kldc[17, 0] = "show_ref1";
               kldc[17, 1] = this.StrShow_Ref1;
               kldc[17, 2] = "string";
           }
           if (!StrClientID.Equals(Default))
           {
               kldc[18, 0] = "show_ref2";
               kldc[18, 1] = this.StrShow_Ref2;
               kldc[18, 2] = "string";
           }
           if (!StrDiscount.Equals(Default))
           {
               kldc[19, 0] = "discount";
               kldc[19, 1] = this.StrDiscount;
               kldc[19, 2] = "int";
           }
           return kldc;
       }
       private string[,] MakeArray_BookingM()
       {
           string[,] kldc = new string[8, 3];
           if (!StrBookingID.Equals(Default))
           {
               kldc[0, 0] = "bookingid";
               kldc[0, 1] = this.StrBookingID;
               kldc[0, 2] = "int";
           }
           
           if (!StrM_Add_Bill.Equals(Default))
           {
               kldc[1, 0] = "add_bill";
               kldc[1, 1] = this.StrM_Add_Bill;
               kldc[1, 2] = "string";
           }
           if (!StrM_Authorization_Date.Equals(Default))
           {
               kldc[2, 0] = "authorize_date";
               kldc[2, 1] = this.StrM_Authorization_Date;
               kldc[2, 2] = "date";
           }
           if (!StrM_Authorization_No.Equals(Default))
           {
               kldc[3, 0] = "authorizeno";
               kldc[3, 1] = this.StrM_Authorization_No;
               kldc[3, 2] = "string";
           }
           if (!StrM_Bill_Ref1.Equals(Default))
           {
               kldc[4, 0] = "bill_ref1";
               kldc[4, 1] = this.StrM_Bill_Ref1;
               kldc[4, 2] = "string";
           }
           if (!StrM_Bill_Ref2.Equals(Default))
           {
               kldc[5, 0] = "bill_ref2";
               kldc[5, 1] = this.StrM_Bill_Ref2;
               kldc[5, 2] = "string";
           }
           if (!StrM_Service_No.Equals(Default))
           {
               kldc[6, 0] = "bill_serviceno";
               kldc[6, 1] = this.StrM_Service_No;
               kldc[6, 2] = "string";
           }
           if (!StrBillID.Equals(Default))
           {
               kldc[7, 0] = "billid";
               kldc[7, 1] = this.StrBillID;
               kldc[7, 2] = "int";
           }
           return kldc;
       }
       private bool VD_Billno()
       {
           DataView dv = GetAll(6);
           if (dv.Count > 0)
           {
               if (!StrBillID.Equals(Default) && !StrBillID.Equals("") && StrBillID != null)
               {
                   dv.RowFilter = "billid <>" + StrBillID;
                   if (dv.Count > 0)
                   {
                       StrError = "Bill number already exist. Please enter other bill number";
                       return false;
                   }
                   else
                       return true;
               }

               else
               {
                   return false;
               }
           }
           else { return true; }
       }
       #endregion

   }
}
