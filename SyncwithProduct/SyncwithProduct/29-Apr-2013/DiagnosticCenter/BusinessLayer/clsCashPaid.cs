using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsCashPaid
    {
        clsdbhims objdbhims = new clsdbhims();
        clsoperation objTrans = new clsoperation();

        private const string TableName = "dc_tpatient_bookingm";
        private const string Default = "~!@";

        private string StrError = Default;

        public string Error
        {
            get { return StrError; }
            set { StrError = value; }
        }

        private string _bookingid = Default;

        public string Bookingid
        {
            get { return _bookingid; }
            set { _bookingid = value; }
        }
        private string _labid = Default;

        public string Labid
        {
            get { return _labid; }
            set { _labid = value; }
        }

        private string _prid = Default;

        public string Prid
        {
            get { return _prid; }
            set { _prid = value; }
        }
        private string _type = Default;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _payment_mode = Default;

        public string Payment_mode
        {
            get { return _payment_mode; }
            set { _payment_mode = value; }
        }
        private string _totalamount = Default;

        public string Totalamount
        {
            get { return _totalamount; }
            set { _totalamount = value; }
        }
        private string _doctorid = Default;

        public string Doctorid
        {
            get { return _doctorid; }
            set { _doctorid = value; }
        }
        private string _referredby = Default;

        public string Referredby
        {
            get { return _referredby; }
            set { _referredby = value; }
        }
        private string _origin_place = Default;

        public string Origin_place
        {
            get { return _origin_place; }
            set { _origin_place = value; }
        }
        private string _deliveryby = Default;

        public string Deliveryby
        {
            get { return _deliveryby; }
            set { _deliveryby = value; }
        }
        private string _clientid = Default;

        public string Clientid
        {
            get { return _clientid; }
            set { _clientid = value; }
        }
        private string _authorizeno = Default;

        public string Authorizeno
        {
            get { return _authorizeno; }
            set { _authorizeno = value; }
        }
        private string _discount_amt = Default;

        public string Discount_amt
        {
            get { return _discount_amt; }
            set { _discount_amt = value; }
        }
        private string _referenceno = Default;

        public string Referenceno
        {
            get { return _referenceno; }
            set { _referenceno = value; }
        }
        private string _refund_amt = Default;

        public string Refund_amt
        {
            get { return _refund_amt; }
            set { _refund_amt = value; }
        }
        private string _balance = Default;

        public string Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        private string _remarks = Default;

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        private string _panelid = Default;

        public string Panelid
        {
            get { return _panelid; }
            set { _panelid = value; }
        }
        private string _wardid = Default;

        public string Wardid
        {
            get { return _wardid; }
            set { _wardid = value; }
        }
        private string _bed = Default;

        public string Bed
        {
            get { return _bed; }
            set { _bed = value; }
        }
        private string _adm_ref = Default;

        public string Adm_ref
        {
            get { return _adm_ref; }
            set { _adm_ref = value; }
        }
        private string _Booking_Iscompleted = Default;

        public string Booking_Iscompleted
        {
            get { return _Booking_Iscompleted; }
            set { _Booking_Iscompleted = value; }
        }

        private string _paidamount = Default;

        public string Paidamount
        {
            get { return _paidamount; }
            set { _paidamount = value; }
        }
        private string _enteredby = Default;

        public string Enteredby
        {
            get { return _enteredby; }
            set { _enteredby = value; }
        }
        private string _enteredon = Default;

        public string Enteredon
        {
            get { return _enteredon; }
            set { _enteredon = value; }
        }


        private string[,] MakeArray_Booking_M()
        {
            string[,] booking_array = new string[25, 3];

            if (!_labid.Equals(Default))
            {
                booking_array[0, 0] = "labid";
                booking_array[0, 1] = this._labid;
                booking_array[0, 2] = "string";
            }
            if (!_bookingid.Equals(Default))
            {
                booking_array[1, 0] = "bookingid";
                booking_array[1, 1] = this._bookingid;
                booking_array[1, 2] = "int";
            }
            if (!_prid.Equals(Default))
            {
                booking_array[2, 0] = "prid";
                booking_array[2, 1] = this._prid;
                booking_array[2, 2] = "string";
            }

            if (!_type.Equals(Default))
            {
                booking_array[3, 0] = "type";
                booking_array[3, 1] = this._type;
                booking_array[3, 2] = "string";
            }

            if (!_payment_mode.Equals(Default))
            {
                booking_array[4, 0] = "payment_mode";
                booking_array[4, 1] = this._payment_mode;
                booking_array[4, 2] = "string";
            }

            if (!_totalamount.Equals(Default))
            {
                booking_array[5, 0] = "totalamount";
                booking_array[5, 1] = this._totalamount;
                booking_array[5, 2] = "string";
            }

            if (!_doctorid.Equals(Default))
            {
                booking_array[6, 0] = "doctorid";
                booking_array[6, 1] = this._doctorid;
                booking_array[6, 2] = "string";
            }

            if (!_referredby.Equals(Default))
            {
                booking_array[7, 0] = "referredby";
                booking_array[7, 1] = this._referredby;
                booking_array[7, 2] = "string";
            }

            if (!_origin_place.Equals(Default))
            {
                booking_array[8, 0] = "origin_place";
                booking_array[8, 1] = this._origin_place;
                booking_array[8, 2] = "string";
            }

            if (!_paidamount.Equals(Default))
            {
                booking_array[9, 0] = "paidamount";
                booking_array[9, 1] = this._paidamount;
                booking_array[9, 2] = "int";
            }
            if (!_deliveryby.Equals(Default))
            {
                booking_array[10, 0] = "deliveryby";
                booking_array[10, 1] = this._deliveryby;
                booking_array[10, 2] = "int";
            }

            if (!_enteredby.Equals(Default))
            {
                booking_array[11, 0] = "enteredby";
                booking_array[11, 1] = this._enteredby;
                booking_array[11, 2] = "string";
            }
            if (!_enteredon.Equals(Default))
            {
                booking_array[12, 0] = "enteredon";
                booking_array[12, 1] = this._enteredon;
                booking_array[12, 2] = "datetime";
            }
            if (!_clientid.Equals(Default))
            {
                booking_array[13, 0] = "clientid";
                booking_array[13, 1] = this._clientid;
                booking_array[13, 2] = "string";
            }
            if (!_authorizeno.Equals(Default))
            {
                booking_array[14, 0] = "authorizeno";
                booking_array[14, 1] = this._authorizeno;
                booking_array[14, 2] = "string";
            }
            if (!_discount_amt.Equals(Default))
            {
                booking_array[15, 0] = "discount_amt";
                booking_array[15, 1] = this._discount_amt;
                booking_array[15, 2] = "string";
            }
            if (!_referenceno.Equals(Default))
            {
                booking_array[16, 0] = "referenceno";
                booking_array[16, 1] = this._referenceno;
                booking_array[16, 2] = "string";
            }
            if (!_refund_amt.Equals(Default))
            {
                booking_array[17, 0] = "refund_amt";
                booking_array[17, 1] = this._refund_amt;
                booking_array[17, 2] = "string";
            }
            if (!_balance.Equals(Default))
            {
                booking_array[18, 0] = "balance";
                booking_array[18, 1] = this._balance;
                booking_array[18, 2] = "int";
            }
            if (!_remarks.Equals(Default))
            {
                booking_array[19, 0] = "remarks";
                booking_array[19, 1] = this._remarks;
                booking_array[19, 2] = "string";
            }
            if (!_panelid.Equals(Default))
            {
                booking_array[20, 0] = "panelid";
                booking_array[20, 1] = this._panelid;
                booking_array[20, 2] = "string";
            }
            if (!_wardid.Equals(Default))
            {
                booking_array[21, 0] = "wardid";
                booking_array[21, 1] = this._wardid;
                booking_array[21, 2] = "string";
            }
            if (!_bed.Equals(Default))
            {
                booking_array[22, 0] = "bed";
                booking_array[22, 1] = this._bed;
                booking_array[22, 2] = "string";
            }
            if (!_adm_ref.Equals(Default))
            {
                booking_array[23, 0] = "adm_ref";
                booking_array[23, 1] = this._adm_ref;
                booking_array[23, 2] = "string";
            }
            if (!_Booking_Iscompleted.Equals(Default))
            {
                booking_array[24, 0] = "Booking_Iscompleted";
                booking_array[24, 1] = this._Booking_Iscompleted;
                booking_array[24, 2] = "string";
            }

            return booking_array;
        }

        public bool Update()
        {
            QueryBuilder objQB = new QueryBuilder();
            objTrans.Start_Transaction();
            objdbhims.Query = objQB.QBUpdate(MakeArray_Booking_M(), TableName);
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

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "SELECT bookingid,	prid,	type,	payment_mode,	labid,	totalamount,	paidamount,	doctorid,	referredby,	origin_place,	deliveryby,	enteredby,	enteredon,	clientid,	authorizeno,	discount_amt,	referenceno,	refund_amt,	balance,	remarks,	panelid,	wardid,	bed,	adm_ref,	Booking_Iscompleted FROM dc_tpatient_bookingm WHERE labid = '" + _labid + "' ";
                    break;
                case 2:
                    objdbhims.Query = "SELECT DATEDIFF(CURDATE(),dc_tpatient_bookingm.enteredon) as Age, `dc_tpatient_bookingm`.`enteredon`, `dc_tpatient_bookingm`.`labid`, `dc_tpatient`.`name`, `dc_tpatient_bookingm`.`bookingid`, CONCAT(`dc_tpatient_bookingm`.`totalamount`-`dc_tpatient_bookingm`.`paidamount`-`dc_tpatient_bookingm`.`discount_amt`) as bal,`dc_tpatient_bookingm`.`totalamount`, `dc_tpatient_bookingm`.`paidamount`, `dc_tpatient`.`title`,CONCAT(dc_tp_personnel.Salutation,dc_tp_personnel.FName,dc_tp_personnel.MName,dc_tp_personnel.LName) as enteredby ,`dc_tp_personnel`.`Salutation`, `dc_tp_personnel`.`FName`, `dc_tp_personnel`.`MName`, `dc_tp_personnel`.`LName`, `dc_tpatient_bookingm`.`discount_amt`, `dc_tpanel`.`panelid`, `dc_tpanel`.`name` as pname, `dc_tpatient_bookingm`.`panelid`, `dc_tpatient_bookingm`.`clientid`, `dc_tpatient`.`prno` FROM   {oj ((`dc_tp_personnel` `dc_tp_personnel` INNER JOIN `bc_lims`.`dc_tpatient_bookingm` `dc_tpatient_bookingm` ON `dc_tp_personnel`.`PersonId`=`dc_tpatient_bookingm`.`enteredby`) INNER JOIN `bc_lims`.`dc_tpatient` `dc_tpatient` ON `dc_tpatient_bookingm`.`prid`=`dc_tpatient`.`prid`) LEFT OUTER JOIN `dc_tpanel` `dc_tpanel` ON `dc_tpatient_bookingm`.`panelid`=`dc_tpanel`.`panelid`} WHERE  `dc_tpatient_bookingm`.`enteredon` BETWEEN CURDATE() - INTERVAL 30 DAY AND CURDATE() AND `dc_tpatient_bookingm`.`panelid` IS    NULL AND totalamount-paidamount-discount_amt <> 0 ORDER BY `dc_tpatient_bookingm`.`clientid`";    
                    // objdbhims.Query = "SELECT `dc_tpatient_bookingm`.`enteredon`, `dc_tpatient_bookingm`.`labid`, `dc_tpatient`.`name`, `dc_tpatient_bookingm`.`bookingid`, CONCAT(`dc_tpatient_bookingm`.`totalamount`-`dc_tpatient_bookingm`.`paidamount`-`dc_tpatient_bookingm`.`discount_amt`) as bal,`dc_tpatient_bookingm`.`totalamount`, `dc_tpatient_bookingm`.`paidamount`, `dc_tpatient`.`title`,CONCAT(dc_tp_personnel.Salutation,dc_tp_personnel.FName,dc_tp_personnel.MName,dc_tp_personnel.LName) as enteredby ,`dc_tp_personnel`.`Salutation`, `dc_tp_personnel`.`FName`, `dc_tp_personnel`.`MName`, `dc_tp_personnel`.`LName`, `dc_tpatient_bookingm`.`discount_amt`, `dc_tpanel`.`panelid`, `dc_tpanel`.`name` as pname, `dc_tpatient_bookingm`.`panelid`, `dc_tpatient_bookingm`.`clientid`, `dc_tpatient`.`prno` FROM   {oj ((`dc_tp_personnel` `dc_tp_personnel` INNER JOIN `bc_lims`.`dc_tpatient_bookingm` `dc_tpatient_bookingm` ON `dc_tp_personnel`.`PersonId`=`dc_tpatient_bookingm`.`enteredby`) INNER JOIN `bc_lims`.`dc_tpatient` `dc_tpatient` ON `dc_tpatient_bookingm`.`prid`=`dc_tpatient`.`prid`) LEFT OUTER JOIN `dc_tpanel` `dc_tpanel` ON `dc_tpatient_bookingm`.`panelid`=`dc_tpanel`.`panelid`} WHERE  YEAR(`dc_tpatient_bookingm`.`enteredon`) = YEAR(CURDATE()) AND MONTH(`dc_tpatient_bookingm`.`enteredon`) = MONTH(CURDATE()) AND `dc_tpatient_bookingm`.`panelid` IS    NULL ORDER BY `dc_tpatient_bookingm`.`clientid` ";
                    break;
                case 3:
                    objdbhims.Query = "SELECT DATEDIFF(CURDATE(),dc_tpatient_bookingm.enteredon) as Age, `dc_tpatient_bookingm`.`enteredon`, `dc_tpatient_bookingm`.`labid`, `dc_tpatient`.`name`, `dc_tpatient_bookingm`.`bookingid`,CONCAT(`dc_tpatient_bookingm`.`totalamount`-ifnull(`dc_tpatient_bookingm`.`paidamount`,0)-ifnull(`dc_tpatient_bookingm`.`discount_amt`,0)) as bal ,`dc_tpatient_bookingm`.`totalamount`, `dc_tpatient_bookingm`.`paidamount`, `dc_tpatient`.`title`,CONCAT(dc_tp_personnel.Salutation,dc_tp_personnel.FName,dc_tp_personnel.MName,dc_tp_personnel.LName) as enteredby ,`dc_tp_personnel`.`Salutation`, `dc_tp_personnel`.`FName`, `dc_tp_personnel`.`MName`, `dc_tp_personnel`.`LName`, `dc_tpatient_bookingm`.`discount_amt`, `dc_tpanel`.`panelid`, `dc_tpanel`.`name` as pname, `dc_tpatient_bookingm`.`panelid`, `dc_tpatient_bookingm`.`clientid`, `dc_tpatient`.`prno` FROM   {oj ((`dc_tp_personnel` `dc_tp_personnel` INNER JOIN `bc_lims`.`dc_tpatient_bookingm` `dc_tpatient_bookingm` ON `dc_tp_personnel`.`PersonId`=`dc_tpatient_bookingm`.`enteredby`) INNER JOIN `bc_lims`.`dc_tpatient` `dc_tpatient` ON `dc_tpatient_bookingm`.`prid`=`dc_tpatient`.`prid`) LEFT OUTER JOIN `dc_tpanel` `dc_tpanel` ON `dc_tpatient_bookingm`.`panelid`=`dc_tpanel`.`panelid`} WHERE `dc_tpatient_bookingm`.`enteredon` BETWEEN '2012-07-01' AND '2013-06-30' AND  `dc_tpatient_bookingm`.`panelid` IS NOT NULL  AND totalamount-paidamount-discount_amt <> 0 ORDER BY `dc_tpatient_bookingm`.`clientid` LIMIT 30";
                    break;
                case 4:
                    objdbhims.Query = "SELECT DATEDIFF(CURDATE(),dc_tpatient_bookingm.enteredon) as Age, `dc_tpatient_bookingm`.`enteredon`, `dc_tpatient_bookingm`.`labid`, `dc_tpatient`.`name`, `dc_tpatient_bookingm`.`bookingid`,CONCAT(`dc_tpatient_bookingm`.`totalamount`-ifnull(`dc_tpatient_bookingm`.`paidamount`,0)-ifnull(`dc_tpatient_bookingm`.`discount_amt`,0)) as bal ,`dc_tpatient_bookingm`.`totalamount`, `dc_tpatient_bookingm`.`paidamount`, `dc_tpatient`.`title`,CONCAT(dc_tp_personnel.Salutation,dc_tp_personnel.FName,dc_tp_personnel.MName,dc_tp_personnel.LName) as enteredby ,`dc_tp_personnel`.`Salutation`, `dc_tp_personnel`.`FName`, `dc_tp_personnel`.`MName`, `dc_tp_personnel`.`LName`, `dc_tpatient_bookingm`.`discount_amt`, `dc_tpanel`.`panelid`, `dc_tpanel`.`name` as pname, `dc_tpatient_bookingm`.`panelid`, `dc_tpatient_bookingm`.`clientid`, `dc_tpatient`.`prno` FROM   {oj ((`dc_tp_personnel` `dc_tp_personnel` INNER JOIN `bc_lims`.`dc_tpatient_bookingm` `dc_tpatient_bookingm` ON `dc_tp_personnel`.`PersonId`=`dc_tpatient_bookingm`.`enteredby`) INNER JOIN `bc_lims`.`dc_tpatient` `dc_tpatient` ON `dc_tpatient_bookingm`.`prid`=`dc_tpatient`.`prid`) LEFT OUTER JOIN `dc_tpanel` `dc_tpanel` ON `dc_tpatient_bookingm`.`panelid`=`dc_tpanel`.`panelid`} WHERE `dc_tpatient_bookingm`.`enteredon` BETWEEN '2012-07-01' AND '2013-06-30' AND  `dc_tpatient_bookingm`.`panelid` IS NULL  AND totalamount-paidamount-discount_amt <> 0 ORDER BY `dc_tpatient_bookingm`.`clientid`";
                    break;
                case 5:
                    objdbhims.Query = "SELECT DATEDIFF(CURDATE(),dc_tpatient_bookingm.enteredon) as Age, `dc_tpatient_bookingm`.`enteredon`, `dc_tpatient_bookingm`.`labid`, `dc_tpatient`.`name`, `dc_tpatient_bookingm`.`bookingid`, CONCAT(`dc_tpatient_bookingm`.`totalamount`-`dc_tpatient_bookingm`.`paidamount`-`dc_tpatient_bookingm`.`discount_amt`) as bal,`dc_tpatient_bookingm`.`totalamount`, `dc_tpatient_bookingm`.`paidamount`, `dc_tpatient`.`title`,CONCAT(dc_tp_personnel.Salutation,dc_tp_personnel.FName,dc_tp_personnel.MName,dc_tp_personnel.LName) as enteredby ,`dc_tp_personnel`.`Salutation`, `dc_tp_personnel`.`FName`, `dc_tp_personnel`.`MName`, `dc_tp_personnel`.`LName`, `dc_tpatient_bookingm`.`discount_amt`, `dc_tpanel`.`panelid`, `dc_tpanel`.`name` as pname, `dc_tpatient_bookingm`.`panelid`, `dc_tpatient_bookingm`.`clientid`, `dc_tpatient`.`prno` FROM   {oj ((`dc_tp_personnel` `dc_tp_personnel` INNER JOIN `bc_lims`.`dc_tpatient_bookingm` `dc_tpatient_bookingm` ON `dc_tp_personnel`.`PersonId`=`dc_tpatient_bookingm`.`enteredby`) INNER JOIN `bc_lims`.`dc_tpatient` `dc_tpatient` ON `dc_tpatient_bookingm`.`prid`=`dc_tpatient`.`prid`) LEFT OUTER JOIN `dc_tpanel` `dc_tpanel` ON `dc_tpatient_bookingm`.`panelid`=`dc_tpanel`.`panelid`} WHERE  `dc_tpatient_bookingm`.`enteredon` BETWEEN CURDATE() - INTERVAL 60 DAY AND CURDATE() AND `dc_tpatient_bookingm`.`panelid` IS    NULL AND totalamount-paidamount-discount_amt <> 0 ORDER BY `dc_tpatient_bookingm`.`clientid`";
                    // objdbhims.Query = "SELECT `dc_tpatient_bookingm`.`enteredon`, `dc_tpatient_bookingm`.`labid`, `dc_tpatient`.`name`, `dc_tpatient_bookingm`.`bookingid`, CONCAT(`dc_tpatient_bookingm`.`totalamount`-`dc_tpatient_bookingm`.`paidamount`-`dc_tpatient_bookingm`.`discount_amt`) as bal,`dc_tpatient_bookingm`.`totalamount`, `dc_tpatient_bookingm`.`paidamount`, `dc_tpatient`.`title`,CONCAT(dc_tp_personnel.Salutation,dc_tp_personnel.FName,dc_tp_personnel.MName,dc_tp_personnel.LName) as enteredby ,`dc_tp_personnel`.`Salutation`, `dc_tp_personnel`.`FName`, `dc_tp_personnel`.`MName`, `dc_tp_personnel`.`LName`, `dc_tpatient_bookingm`.`discount_amt`, `dc_tpanel`.`panelid`, `dc_tpanel`.`name` as pname, `dc_tpatient_bookingm`.`panelid`, `dc_tpatient_bookingm`.`clientid`, `dc_tpatient`.`prno` FROM   {oj ((`dc_tp_personnel` `dc_tp_personnel` INNER JOIN `bc_lims`.`dc_tpatient_bookingm` `dc_tpatient_bookingm` ON `dc_tp_personnel`.`PersonId`=`dc_tpatient_bookingm`.`enteredby`) INNER JOIN `bc_lims`.`dc_tpatient` `dc_tpatient` ON `dc_tpatient_bookingm`.`prid`=`dc_tpatient`.`prid`) LEFT OUTER JOIN `dc_tpanel` `dc_tpanel` ON `dc_tpatient_bookingm`.`panelid`=`dc_tpanel`.`panelid`} WHERE  YEAR(`dc_tpatient_bookingm`.`enteredon`) = YEAR(CURDATE()) AND MONTH(`dc_tpatient_bookingm`.`enteredon`) = MONTH(CURDATE()) AND `dc_tpatient_bookingm`.`panelid` IS    NULL ORDER BY `dc_tpatient_bookingm`.`clientid` ";
                    break;
                case 6:
                    objdbhims.Query = "SELECT DATEDIFF(CURDATE(),dc_tpatient_bookingm.enteredon) as Age, `dc_tpatient_bookingm`.`enteredon`, `dc_tpatient_bookingm`.`labid`, `dc_tpatient`.`name`, `dc_tpatient_bookingm`.`bookingid`, CONCAT(`dc_tpatient_bookingm`.`totalamount`-`dc_tpatient_bookingm`.`paidamount`-`dc_tpatient_bookingm`.`discount_amt`) as bal,`dc_tpatient_bookingm`.`totalamount`, `dc_tpatient_bookingm`.`paidamount`, `dc_tpatient`.`title`,CONCAT(dc_tp_personnel.Salutation,dc_tp_personnel.FName,dc_tp_personnel.MName,dc_tp_personnel.LName) as enteredby ,`dc_tp_personnel`.`Salutation`, `dc_tp_personnel`.`FName`, `dc_tp_personnel`.`MName`, `dc_tp_personnel`.`LName`, `dc_tpatient_bookingm`.`discount_amt`, `dc_tpanel`.`panelid`, `dc_tpanel`.`name` as pname, `dc_tpatient_bookingm`.`panelid`, `dc_tpatient_bookingm`.`clientid`, `dc_tpatient`.`prno` FROM   {oj ((`dc_tp_personnel` `dc_tp_personnel` INNER JOIN `bc_lims`.`dc_tpatient_bookingm` `dc_tpatient_bookingm` ON `dc_tp_personnel`.`PersonId`=`dc_tpatient_bookingm`.`enteredby`) INNER JOIN `bc_lims`.`dc_tpatient` `dc_tpatient` ON `dc_tpatient_bookingm`.`prid`=`dc_tpatient`.`prid`) LEFT OUTER JOIN `dc_tpanel` `dc_tpanel` ON `dc_tpatient_bookingm`.`panelid`=`dc_tpanel`.`panelid`} WHERE  `dc_tpatient_bookingm`.`enteredon` BETWEEN CURDATE() - INTERVAL 90 DAY AND CURDATE() AND `dc_tpatient_bookingm`.`panelid` IS    NULL AND totalamount-paidamount-discount_amt <> 0 ORDER BY `dc_tpatient_bookingm`.`clientid`";
                    // objdbhims.Query = "SELECT `dc_tpatient_bookingm`.`enteredon`, `dc_tpatient_bookingm`.`labid`, `dc_tpatient`.`name`, `dc_tpatient_bookingm`.`bookingid`, CONCAT(`dc_tpatient_bookingm`.`totalamount`-`dc_tpatient_bookingm`.`paidamount`-`dc_tpatient_bookingm`.`discount_amt`) as bal,`dc_tpatient_bookingm`.`totalamount`, `dc_tpatient_bookingm`.`paidamount`, `dc_tpatient`.`title`,CONCAT(dc_tp_personnel.Salutation,dc_tp_personnel.FName,dc_tp_personnel.MName,dc_tp_personnel.LName) as enteredby ,`dc_tp_personnel`.`Salutation`, `dc_tp_personnel`.`FName`, `dc_tp_personnel`.`MName`, `dc_tp_personnel`.`LName`, `dc_tpatient_bookingm`.`discount_amt`, `dc_tpanel`.`panelid`, `dc_tpanel`.`name` as pname, `dc_tpatient_bookingm`.`panelid`, `dc_tpatient_bookingm`.`clientid`, `dc_tpatient`.`prno` FROM   {oj ((`dc_tp_personnel` `dc_tp_personnel` INNER JOIN `bc_lims`.`dc_tpatient_bookingm` `dc_tpatient_bookingm` ON `dc_tp_personnel`.`PersonId`=`dc_tpatient_bookingm`.`enteredby`) INNER JOIN `bc_lims`.`dc_tpatient` `dc_tpatient` ON `dc_tpatient_bookingm`.`prid`=`dc_tpatient`.`prid`) LEFT OUTER JOIN `dc_tpanel` `dc_tpanel` ON `dc_tpatient_bookingm`.`panelid`=`dc_tpanel`.`panelid`} WHERE  YEAR(`dc_tpatient_bookingm`.`enteredon`) = YEAR(CURDATE()) AND MONTH(`dc_tpatient_bookingm`.`enteredon`) = MONTH(CURDATE()) AND `dc_tpatient_bookingm`.`panelid` IS    NULL ORDER BY `dc_tpatient_bookingm`.`clientid` ";
                    break;
                case 7:
                    objdbhims.Query = @"SELECT d.totalamount as charges,
t.test_name,concat(ifnull(pp.title,''),' ',
pp.name) as patient, pp.prno,
 d.deliverytime ,
date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'M' else 'F'
end as gender,d.testid,m.bookingid,m.prid,pn.panelid,
pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,
case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,
case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' (Y)')  else
 case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else
     concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid=''
     then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,
     dr.code,m.referenceno,case when m.payment_mode = 'A' then 'On Acc' else 'On Cash' end as M_Bmode,
     pn.print_amount,w.name as ward,m.adm_ref,m.type as ind_outdoor,m.labid,m.enteredon as bookedon,
m.totalamount,ifnull(m.paidamount,0) as paidamount,ifnull(m.discount_amt,0) as discount_amt
, m.totalamount-(ifnull(m.paidamount,0)+ifnull(m.discount_amt,0)) as Balance
from  dc_tpatient_bookingm m
join dc_tpatient_bookingd d on m.bookingid = d.bookingid
join dc_tp_test t on d.testid = t.testid
join dc_tpatient pp on m.prid = pp.prid
left outer join dc_tpanel pn on m.panelid= pn.panelid
left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid
where m.clientid='008'
and m.`enteredon` BETWEEN CURDATE() - INTERVAL 30 DAY AND CURDATE() and m.type='I' and d.status<>'X' GROUP BY m.labid";
                    break;
                case 8:
                    objdbhims.Query = @"SELECT d.totalamount as charges,
t.test_name,concat(ifnull(pp.title,''),' ',
pp.name) as patient, pp.prno,
 d.deliverytime ,
date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'M' else 'F'
end as gender,d.testid,m.bookingid,m.prid,pn.panelid,
pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,
case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,
case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' (Y)')  else
 case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else
     concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid=''
     then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,
     dr.code,m.referenceno,case when m.payment_mode = 'A' then 'On Acc' else 'On Cash' end as M_Bmode,
     pn.print_amount,w.name as ward,m.adm_ref,m.type as ind_outdoor,m.labid,m.enteredon as bookedon,
m.totalamount,ifnull(m.paidamount,0) as paidamount,ifnull(m.discount_amt,0) as discount_amt
, m.totalamount-(ifnull(m.paidamount,0)+ifnull(m.discount_amt,0)) as Balance
from  dc_tpatient_bookingm m
join dc_tpatient_bookingd d on m.bookingid = d.bookingid
join dc_tp_test t on d.testid = t.testid
join dc_tpatient pp on m.prid = pp.prid
left outer join dc_tpanel pn on m.panelid= pn.panelid
left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid
where m.clientid='008'
and m.`enteredon` BETWEEN CURDATE() - INTERVAL 60 DAY AND CURDATE() and m.type='I' and d.status<>'X' GROUP BY m.labid";
                    break;
                case 9:
                    objdbhims.Query = @"SELECT d.totalamount as charges,
t.test_name,concat(ifnull(pp.title,''),' ',
pp.name) as patient, pp.prno,
 d.deliverytime ,
date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'M' else 'F'
end as gender,d.testid,m.bookingid,m.prid,pn.panelid,
pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,
case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,
case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' (Y)')  else
 case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else
     concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid=''
     then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,
     dr.code,m.referenceno,case when m.payment_mode = 'A' then 'On Acc' else 'On Cash' end as M_Bmode,
     pn.print_amount,w.name as ward,m.adm_ref,m.type as ind_outdoor,m.labid,m.enteredon as bookedon,
m.totalamount,ifnull(m.paidamount,0) as paidamount,ifnull(m.discount_amt,0) as discount_amt
, m.totalamount-(ifnull(m.paidamount,0)+ifnull(m.discount_amt,0)) as Balance
from  dc_tpatient_bookingm m
join dc_tpatient_bookingd d on m.bookingid = d.bookingid
join dc_tp_test t on d.testid = t.testid
join dc_tpatient pp on m.prid = pp.prid
left outer join dc_tpanel pn on m.panelid= pn.panelid
left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid
where m.clientid='008'
and m.`enteredon` BETWEEN CURDATE() - INTERVAL 90 DAY AND CURDATE() and m.type='I' and d.status<>'X' GROUP BY m.labid";
                    break;
                case 10:
                    objdbhims.Query = @"SELECT d.totalamount as charges,
t.test_name,concat(ifnull(pp.title,''),' ',
pp.name) as patient, pp.prno,
 d.deliverytime ,
date_format(pp.dob,'%d/%m/%Y') as dob,case when pp.gender='M' then 'M' else 'F'
end as gender,d.testid,m.bookingid,m.prid,pn.panelid,
pn.name as panelname,ifnull(m.authorizeno,'') as authorizeno,ifnull(pp.serviceno,'') as serviceno,
case when pp.address is null or pp.address='' then '-' else pp.address end as address,m.enteredon,
case when DATEDIFF(CURRENT_DATE,pp.dob) > 365 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/365),' (Y)')  else
 case when DATEDIFF(CURRENT_DATE,pp.dob) > 30 then      concat(Floor(DATEDIFF(CURRENT_DATE,pp.dob)/30),' (M)')    else
     concat(DATEDIFF(CURRENT_DATE,pp.dob),'(D)')    end  end  AS age,case when m.doctorid is null or m.doctorid=''
     then m.referredby else concat(ifnull(dr.title,''),' ',dr.name) end as consultant,m.discount_amt,
     dr.code,m.referenceno,case when m.payment_mode = 'A' then 'On Acc' else 'On Cash' end as M_Bmode,
     pn.print_amount,w.name as ward,m.adm_ref,m.type as ind_outdoor,m.labid,m.enteredon as bookedon,
m.totalamount,ifnull(m.paidamount,0) as paidamount,ifnull(m.discount_amt,0) as discount_amt
, m.totalamount-(ifnull(m.paidamount,0)+ifnull(m.discount_amt,0)) as Balance
from  dc_tpatient_bookingm m
join dc_tpatient_bookingd d on m.bookingid = d.bookingid
join dc_tp_test t on d.testid = t.testid
join dc_tpatient pp on m.prid = pp.prid
left outer join dc_tpanel pn on m.panelid= pn.panelid
left outer join dc_tp_refdoctors dr on dr.doctorid=m.doctorid left outer join dc_tp_ward w on w.wardid=m.wardid
where m.clientid='008' and m.type='I' and d.status<>'X' GROUP BY m.labid LIMIT 200 ";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }


    }

}
