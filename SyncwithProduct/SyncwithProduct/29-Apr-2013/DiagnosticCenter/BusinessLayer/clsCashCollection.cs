using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsCashCollection
    {
        clsdbhims objdbhims = new clsdbhims();
        clsoperation objTrans = new clsoperation();

        private const string TableName = "dc_tcashcollection";
        private const string Default = "~!@";

        private string StrError = Default;

        public string Error
        {
            get { return StrError; }
            set { StrError = value; }
        }

        private string StrBookingID = Default;
        private string StrBookingDID = Default;
        private string StrPRID = Default;

        private string StrLabID = Default;
        private string StrReceiveNo = Default;
        private string StrPaymentMode = Default;

        private string StrTotalAmount = Default;
        private string StrPaidAmount = Default;
        private string StrPanelID = Default;

        private string StrDiscount = Default;
        private string StrEnteredOn = Default;
        private string StrEnteredBy = Default;
        private string StrClientID = Default;

        public string BookingID
        {
            get { return StrBookingID; }
            set { StrBookingID = value; }
        }
        public string BookingDID
        {
            get { return StrBookingDID; }
            set { StrBookingDID = value; }
        }
        public string PRID
        {
            get { return StrPRID; }
            set { StrPRID = value; }
        }

        public string LabID
        {
            get { return StrLabID; }
            set { StrLabID = value; }
        }
        public string ReceiveNo
        {
            get { return StrReceiveNo; }
            set { StrReceiveNo = value; }
        }
        public string PaymentMode
        {
            get { return StrPaymentMode; }
            set { StrPaymentMode = value; }
        }

        public string TotalAmount
        {
            get { return StrTotalAmount; }
            set { StrTotalAmount = value; }
        }
        public string PaidAmount
        {
            get { return StrPaidAmount; }
            set { StrPaidAmount = value; }
        }
        public string PanelID
        {
            get { return StrPanelID; }
            set { StrPanelID = value; }
        }

        public string Discount
        {
            get { return StrDiscount; }
            set { StrDiscount = value; }
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

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "SELECT *  FROM dc_tcashcollection WHERE labid = '" + StrLabID + "' ";
                    break;
                // case 2:
                //     objdbhims.Query = "select c.receiveno,c.labid,ifnull(c.paidamount,0) as paidamount,c.totalamount,d.totalamount as charges,concat(t.test_name,' ',ifnull(cl.name,'')) as testname, concat(pr.salutation,' ',pr.fname,' ',ifnull(mname,''),' ',ifnull(lname,'')) as receivedby,concat(ifnull(pp.title,''),' ',pp.name) as patient, date_format(c.enteredon,'%d/%m/%y %h:%i %p') as receivedon,pp.prno, d.deliverytime ,concat(og.name,' ',og.address) as orgaddress,og.phoneno,date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'Male' else 'Female' end as gender,cl.classificationid,d.testid,m.bookingid,m.prid,c.paymentmode,pn.panelid,pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),'(Years)')  else    case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else      concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid='' then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,ifnull((select sum(ifnull(paidamount,0)) from dc_tcashcollection where bookingid=m.bookingid),0) as totalpaid, pp.cellno,pp.hphone,dr.code,m.referenceno,t.external,t.speedkey,pp.pasword,m.remarks,m.payment_mode as M_Bmode,pn.print_amount,w.name as ward,m.type as ind_outdoor,m.origin_place from dc_tcashcollection c  join dc_tpatient_bookingm m on c.bookingid = m.bookingid left outer join dc_tp_personnel pr on c.enteredby = pr.personid join dc_tpatient_bookingd d on m.bookingid = d.bookingid join dc_tp_test t on d.testid = t.testid left outer join dc_tp_tclass cl  on d.classificationid = cl.classificationid join dc_tpatient pp on m.prid = pp.prid left outer join dc_tp_organization og on m.origin_place = og.orgid left outer join dc_tpanel pn on c.panelid= pn.panelid left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid WHERE pp.prno = '" + PRNO + "' AND d.labid = '" + LabID + "' ";
                //     break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }


        private string[,] MakeArray()
        {
            string[,] kdc_arr = new string[11, 3];

            if (!StrBookingID.Equals(Default))
            {
                kdc_arr[0, 0] = "bookingid";
                kdc_arr[0, 1] = this.StrBookingID;
                kdc_arr[0, 2] = "int";
            }
            if (!StrLabID.Equals(Default))
            {
                kdc_arr[1, 0] = "labid";
                kdc_arr[1, 1] = this.StrLabID;
                kdc_arr[1, 2] = "string";
            }
            if (!StrPRID.Equals(Default))
            {
                kdc_arr[2, 0] = "prid";
                kdc_arr[2, 1] = this.StrPRID;
                kdc_arr[2, 2] = "int";
            }

            if (!StrReceiveNo.Equals(Default))
            {
                kdc_arr[3, 0] = "receiveno";
                kdc_arr[3, 1] = this.StrReceiveNo;
                kdc_arr[3, 2] = "string";
            }
            if (!StrPaymentMode.Equals(Default))
            {
                kdc_arr[4, 0] = "paymentmode";
                kdc_arr[4, 1] = this.StrPaymentMode;
                kdc_arr[4, 2] = "string";
            }
            if (!StrTotalAmount.Equals(Default))
            {
                kdc_arr[5, 0] = "totalamount";
                kdc_arr[5, 1] = this.StrTotalAmount;
                kdc_arr[5, 2] = "int";
            }
            if (!StrPaidAmount.Equals(Default))
            {
                kdc_arr[6, 0] = "paidamount";
                kdc_arr[6, 1] = this.StrPaidAmount;
                kdc_arr[6, 2] = "int";
            }
            if (!StrPanelID.Equals(Default))
            {
                kdc_arr[7, 0] = "panelid";
                kdc_arr[7, 1] = this.StrPanelID;
                kdc_arr[7, 2] = "int";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                kdc_arr[8, 0] = "enteredby";
                kdc_arr[8, 1] = this.StrEnteredBy;
                kdc_arr[8, 2] = "int";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                kdc_arr[9, 0] = "enteredon";
                kdc_arr[9, 1] = this.StrEnteredOn;
                kdc_arr[9, 2] = "datetime";
            }
            if (!StrClientID.Equals(Default))
            {
                kdc_arr[10, 0] = "clientid";
                kdc_arr[10, 1] = this.StrClientID;
                kdc_arr[10, 2] = "string";
            }
            return kdc_arr;
        }

        public bool Update()
        {
            QueryBuilder objQB = new QueryBuilder();
            objTrans.Start_Transaction();
            objdbhims.Query = objQB.QBUpdate2(MakeArray(), TableName);
            this.StrError = objTrans.DataTrigger_Update(objdbhims);
            objTrans.End_Transaction();

            if (this.StrError.Equals("True"))
            {
                this.StrError = objTrans.OperationError;
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool Insert()
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

    }
}
