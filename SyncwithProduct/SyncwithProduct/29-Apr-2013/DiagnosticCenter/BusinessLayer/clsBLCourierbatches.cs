using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class clsBLCourierbatches
    {
        public clsBLCourierbatches()
        {
            /// Add Constructor Logic here...
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "dc_tp_CourierBatches";

        private string _BatchID = Default;

      
        private string _Batchno = Default;
        private string _labid = Default;
        private string _TestID = Default;
        private string _PRID = Default;
        private string _Status = Default;
        private string _CourierServiceID = Default;
        private string _Recieptnumber = Default;

        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;
        private string _BranchID = Default;
        private string _DestinationBranchID = Default;
        private string _sendstatus = Default;
        private string _RecievedBy = Default;

       
        private string _RecievedAt = Default;


      

        private string StrErrorMessage = "";


        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string BatchID
        {
            get { return _BatchID; }
            set { _BatchID = value; }
        }
        public string Batchno
        {
            get { return _Batchno; }
            set { _Batchno = value; }
        }
        public string labid
        {
            get { return _labid; }
            set { _labid = value; }
        }
        public string TestID
        {
            get { return _TestID; }
            set { _TestID = value; }
        }
        public string PRID
        {
            get { return _PRID; }
            set { _PRID = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string CourierServiceID
        {
            get { return _CourierServiceID; }
            set { _CourierServiceID = value; }
        }
        public string Recieptnumber
        {
            get { return _Recieptnumber; }
            set { _Recieptnumber = value; }
        }
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public string DestinationBranchID
        {
            get { return _DestinationBranchID; }
            set { _DestinationBranchID = value; }
        }
        public string ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }
        public string Enteredby
        {
            get { return _Enteredby; }
            set { _Enteredby = value; }
        }
        public string Enteredon
        {
            get { return _Enteredon; }
            set { _Enteredon = value; }
        }
        public string Sendstatus
        {
            get { return _sendstatus; }
            set { _sendstatus = value; }
        }
        public string RecievedBy
        {
            get { return _RecievedBy; }
            set { _RecievedBy = value; }
        }
        public string RecievedAt
        {
            get { return _RecievedAt; }
            set { _RecievedAt = value; }
        }
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }
        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = @"Select count(distinct batch_no)+1 as MaxID From dc_tp_courierbatches where date_format(enteredon,'%Y/%m/%d') between '"+System.DateTime.Now.Year.ToString()+"/"+System.DateTime.Now.Month.ToString()+"/01"+@"' and '"+System.DateTime.Now.ToString("dd/MM/yyyy")+@"'
                                        and BranchID="+_BranchID+"  and DestinationBranchID="+_DestinationBranchID;
                    break;
                case 2:
                    objdbhims.Query = @"Select cb.labid,cb.batch_no,(Select name from dc_tp_branch where BranchID=" + _BranchID + @") as origin,b.name BName,concat(b.StreetAddress,' ',(Select distinct tc.Name From dc_tcity tc,dc_tp_branch tb,dc_tp_courierbatches tcb where tc.cityid=tb.city and tcb.branchID=tb.branchID and tcb.batch_No='"+_Batchno+@"')) as branchAddress,t.Test_Name TName,p.Name PName,cb.EnteredOn,concat(ifnull(pp.Salutation,''),'.',pp.FName,' ',ifnull(pp.Mname,''),' ',ifnull(pp.LName,'')) as EntryPerson,
                                        (Select count(cb.Testid) From dc_tp_courierbatches cb where cb.batch_no='" +_Batchno+@"') Count
                                        From dc_tp_courierbatches cb
                                        left outer join dc_tp_branch b on b.BranchID=cb.DestinationBranchID
                                        left outer join dc_tp_Test t on t.TestID=cb.TestID
                                        left outer join dc_tpatient p on p.prid=cb.prid
                                        left outer join dc_tp_personnel pp on pp.PersonID=cb.Enteredby 
                                        where cb.batch_no='"+_Batchno+"'";//-1-2-09/12' ";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        public bool Insert()
        {
            //System.DateTime.Now.Month.ToString();
            //System.DateTime.Now.Year.ToString();
            if (Validation())
            {
                try
                {
                    //clsoperation objTrans = new clsoperation();
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("BatchId", TableName);
                    this._BatchID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._BatchID.Equals("True"))
                    {
                        //objdbhims.Query = @"Select  count(distinct batch_no)+1 as MaxID From dc_tp_courierbatches where date_format(enteredon,'%Y/%m/%d') between ('"+System.DateTime.Now.Year.ToString()+"/"+System.DateTime.Now.Month.ToString()+@"/01' and @'"+Enteredon+@"') 
                        //                  and BranchID="+_BranchID+"  and DestinationBranchID="+_DestinationBranchID;
                        //string count = objTrans.DataTrigger_Get_Max(objdbhims);
                        //if (count != "True")
                        //{
                        //  _Batchno = _BranchID + "-" + count + "-" + _DestinationBranchID + "-" + System.DateTime.Now.ToString("MM/yy");
                        objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        objTrans.End_Transaction();

                        if (this.StrErrorMessage.Equals("True"))
                        {
                            this.StrErrorMessage = objTrans.OperationError;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                   // }
                    //else
                    //{
                      //  this.StrErrorMessage = objTrans.OperationError;
                        //objTrans.End_Transaction();
                        //return false;
                    //}
                }
                catch (Exception e)
                {
                    this.StrErrorMessage = e.Message;
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
            if (Validation())
            {
                clsoperation objTrans = new clsoperation();
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                this.ErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                objTrans.End_Transaction();

                if (this.ErrorMessage.Equals("True"))
                {
                    this.ErrorMessage = objTrans.OperationError;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {

                return false;
            }
        }
        public bool updatebookingstatus()
        {
            objTrans.Start_Transaction();
            objdbhims.Query = "Update dc_tpatient_bookingd set sendstatus='"+_sendstatus+"' where labid='" + _labid + "' and testid=" + _TestID;
            StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
            if (!this.StrErrorMessage.Equals("True"))
            {
                objTrans.End_Transaction();
                return true;
            }
            else
            {
                this.StrErrorMessage = objTrans.OperationError;
                return false;
            }
        }

        public bool updaterecieptinfo()
        {
            objTrans.Start_Transaction();
            objdbhims.Query = "Update dc_tp_courierbatches set status='" + Status + "', Courier_RecieptNumber='" + _Recieptnumber + "', CourierServiceID='" + _CourierServiceID + "' where Batch_no='" + _Batchno+"'";
            StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
            if (!this.StrErrorMessage.Equals("True"))
            {
                objTrans.End_Transaction();
                return true;
            }
            else
            {
                this.StrErrorMessage = objTrans.OperationError;
                return false;
            }


        }
        private string[,] MakeArray()
        {
            string[,] arySAPS = new string[15, 3];

            if (!this._BatchID.Equals(Default))
            {
                arySAPS[0, 0] = "BatchID";
                arySAPS[0, 1] = this._BatchID;
                arySAPS[0, 2] = "int";
            }

            if (!this._Batchno.Equals(Default))
            {
                arySAPS[1, 0] = "Batch_no";
                arySAPS[1, 1] = this._Batchno;
                arySAPS[1, 2] = "string";
            }

            if (!this._labid.Equals(Default))
            {
                arySAPS[2, 0] = "labid";
                arySAPS[2, 1] = this._labid;
                arySAPS[2, 2] = "string";
            }

            if (!this._TestID.Equals(Default))
            {
                arySAPS[3, 0] = "TestID";
                arySAPS[3, 1] = this._TestID;
                arySAPS[3, 2] = "int";
            }

            if (!this._PRID.Equals(Default))
            {
                arySAPS[4, 0] = "PRID";
                arySAPS[4, 1] = this._PRID;
                arySAPS[4, 2] = "int";
            }

            if (!this._Enteredby.Equals(Default))
            {
                arySAPS[5, 0] = "Enteredby";
                arySAPS[5, 1] = this._Enteredby;
                arySAPS[5, 2] = "int";
            }

            if (!this._Enteredon.Equals(Default))
            {
                arySAPS[6, 0] = "Enteredon";
                arySAPS[6, 1] = this._Enteredon;
                arySAPS[6, 2] = "datetime";
            }

            if (!this._Status.Equals(Default))
            {
                arySAPS[7, 0] = "Status";
                arySAPS[7, 1] = this._Status;
                arySAPS[7, 2] = "string";
            }

            if (!this._ClientId.Equals(Default))
            {
                arySAPS[8, 0] = "ClientId";
                arySAPS[8, 1] = this._ClientId;
                arySAPS[8, 2] = "string";
            }
            if (!this._CourierServiceID.Equals(Default))
            {
                arySAPS[9, 0] = "CourierServiceID";
                arySAPS[9, 1] = this._CourierServiceID;
                arySAPS[9, 2] = "int";
            }
            if (!this._Recieptnumber.Equals(Default))
            {
                arySAPS[10, 0] = "Courier_Recieptnumber";
                arySAPS[10, 1] = this._Recieptnumber;
                arySAPS[10, 2] = "string";
            }
            if (!this._DestinationBranchID.Equals(Default))
            {
                arySAPS[11, 0] = "DestinationBranchID";
                arySAPS[11, 1] = this._DestinationBranchID;
                arySAPS[11, 2] = "int";
            }
            if (!this._BranchID.Equals(Default))
            {
                arySAPS[12, 0] = "BranchID";
                arySAPS[12, 1] = this._BranchID;
                arySAPS[12, 2] = "int";
            }
            if (!this._RecievedBy.Equals(Default))
            {
                arySAPS[13, 0] = "RecievedBy";
                arySAPS[13, 1] = this._RecievedBy;
                arySAPS[13, 2] = "int";
            }
            if (!this._RecievedAt.Equals(Default))
            {
                arySAPS[14, 0] = "RecievedAt";
                arySAPS[14, 1] = this._RecievedAt;
                arySAPS[14, 2] = "datetime";
            }

            return arySAPS;
        }
        #endregion

        #region Validations
        private bool Validation()
        {
            return true;
        }
        #endregion

    }
}
