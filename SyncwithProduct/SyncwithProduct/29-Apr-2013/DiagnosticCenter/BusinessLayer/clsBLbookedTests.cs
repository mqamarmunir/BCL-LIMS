using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsBLbookedTests
    {
        public clsBLbookedTests()
        {
            /// Add Constructor Logic here...
        }

        #region Variables
        private const string Default="~!@";
        private const string TableName="";
        private string _BranchID=Default;
        private string _From = Default;

    
        private string _To = Default;
        private string _DestinationBranchid = Default;
        private string _Status = Default;

     

        
        
        private string _ErrorMessage=Default;



        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public string From
        {
            get { return _From; }
            set { _From = value; }
        }
        public string To
        {
            get { return _To; }
            set { _To = value; }
        }

        public string DestinationBranchid
        {
            get { return _DestinationBranchid; }
            set { _DestinationBranchid = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public string ErrorMessage
        {
          get { return _ErrorMessage; }
          set { _ErrorMessage = value; }
        }
        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:// Fill pending Grid
                    objdbhims.Query = @"Select p.prid,bd.labid,bd.TestID,t.Test_name,bm.BranchID,(Select name From dc_tp_branch where BranchID="+_BranchID+@") Booking_branch,bd.DestinationBranchID,
                                        case when bd.DestinationBranchID=0 then 'Internal' when bd.DestinationBranchId is null then ''
                                        else 'External' end as External,b.Name DestinationBranch_name,bd.EnteredOn,case when p.title is null then p.name else concat(p.title,'.',p.Name) end as pName,bd.Deliverytime DeliveryDate

                                        From dc_tpatient_bookingd bd
                                        Inner join dc_tpatient_bookingm bm on bd.bookingID=bm.bookingid
                                        left outer join dc_tpatient p on p.prid=bm.prid
                                        left outer join dc_tp_test t on t.TestId=bd.TestID
                                        left outer join dc_tp_branch b on bd.DestinationBranchID=b.branchId

                                        where bm.BranchID="+_BranchID+@"
                                        
                                        and bd.DestinationbranchId="+_DestinationBranchid+@"
                                        and bd.sendstatus!='S' and bd.Sendstatus!='R'
                                        and bd.processID>3
                                        order by bd.enteredon"; 
                       //                 and date_format(bd.Enteredon,'%Y/%m/%d') between '"+_From+"' and '"+_To+@"'   
                         //               ;
                    break;
                  //  and bd.DestinationBranchID is not null 
                case 2:
                    objdbhims.Query=@"Select distinct b.BranchID DestinationBranchID,b.Name DestinationBranch_name
                                        From dc_tp_Branch b
                                        inner join dc_tpatient_bookingd bd on bd.DestinationBranchID=b.BranchID
                                        inner join dc_tpatient_bookingm bm on bm.bookingid=bd.bookingid
                                        where bm.BranchID="+_BranchID+@" and date_format(bd.EnteredOn,'%Y/%m/%d') between '"+_From+"' and '"+_To+"' and bd.sendStatus='P' and bd.processid>3" ;
                    break;
                case 3:
                    objdbhims.Query = @"Select cb.TestID,cb.batchid,cb.batch_no,cb.labID,bd.enteredon,bd.deliverytime DeliveryDate,p.Name PName,t.Test_Name,b.Name Booking_Branch,cb.EnteredOn DispatchTime,cs.Name ServiceName
                                        From dc_tp_courierbatches cb
                                        left outer join dc_tpatient_bookingd bd
                                        on bd.labid=cb.labid
                                        and bd.testid=cb.testid
                                        left outer join dc_tpatient p
                                        on p.prid=cb.prid
                                        left outer join dc_tp_test t
                                        on t.testid=cb.Testid
                                        left outer join dc_tp_branch b
                                        on b.branchid=cb.branchid
                                        left outer join dc_tp_courierservice cs
                                        on cs.CourierServiceID=cb.CourierServiceID
                                        where cb.DestinationBranchID=" +_BranchID+@" and cb.Status='"+_Status+@"'
                                        and date_format(bd.EnteredOn,'%Y/%m/%d') between '"+_From +"' and '"+_To+"'";
                    break;
                case 4:
                    objdbhims.Query = @"Select cb.batchid,cb.batch_no,cb.labID,bd.enteredon,bd.deliverytime DeliveryDate,p.Name PName,t.Test_Name,b.Name Destination_Branch,cb.Status TestStatus,bd.ProcessID
                                        From dc_tp_courierbatches cb
                                        left outer join dc_tpatient_bookingd bd
                                        on bd.labid=cb.labid
                                        and bd.testid=cb.testid
                                        left outer join dc_tpatient p
                                        on p.prid=cb.prid
                                        left outer join dc_tp_test t
                                        on t.testid=cb.Testid
                                        left outer join dc_tp_branch b
                                        on b.branchid=cb.Destinationbranchid
                                        where cb.BranchID=" + _BranchID + @" and cb.Status!='P' and cb.Status!='Q'
                                        and date_format(bd.EnteredOn,'%Y/%m/%d') between '" + _From + "' and '" + _To + "'";
              
                    break;
                case 5:
                    objdbhims.Query = @"Select cb.TestID,cb.batchid,cb.batch_no,cb.labID,bd.enteredon,bd.deliverytime DeliveryDate,p.Name PName,t.Test_Name,b.Name Booking_Branch,cb.EnteredOn DispatchTime,cs.Name ServiceName
                                        From dc_tp_courierbatches cb
                                        left outer join dc_tpatient_bookingd bd
                                        on bd.labid=cb.labid
                                        and bd.testid=cb.testid
                                        left outer join dc_tpatient p
                                        on p.prid=cb.prid
                                        left outer join dc_tp_test t
                                        on t.testid=cb.Testid
                                        left outer join dc_tp_branch b
                                        on b.branchid=cb.branchid
                                        left outer join dc_tp_courierservice cs
                                        on cs.CourierServiceID=cb.CourierServiceID
                                        where cb.DestinationBranchID="+_BranchID+@" and cb.Status='"+_Status+@"'
                                        and cb.TestId not in
                                        (Select btd.TestID From dc_tp_branchTestd btd where
                                        (btd.DestinationBranchID!=null or btd.DestinationBranchID!=0)
                                         and btd.BranchID="+_BranchID+@" and btd.Active='Y')
                                        and date_format(bd.EnteredOn,'%Y/%m/%d') between '" + _From + "' and '" + _To + "'";
                    break;
                case 6:
                    objdbhims.Query = @"Select cb.TestID,cb.batchid,cb.batch_no,cb.labID,bd.enteredon,bd.deliverytime DeliveryDate,p.Name PName,t.Test_Name,b.Name Booking_Branch,cb.EnteredOn DispatchTime,cs.Name ServiceName
                                        From dc_tp_courierbatches cb
                                        left outer join dc_tpatient_bookingd bd
                                        on bd.labid=cb.labid
                                        and bd.testid=cb.testid
                                        left outer join dc_tpatient p
                                        on p.prid=cb.prid
                                        left outer join dc_tp_test t
                                        on t.testid=cb.Testid
                                        left outer join dc_tp_branch b
                                        on b.branchid=cb.branchid
                                        left outer join dc_tp_courierservice cs
                                        on cs.CourierServiceID=cb.CourierServiceID
                                        where cb.DestinationBranchID="+_BranchID+@" and cb.Status='" + _Status + @"'
                                        and cb.TestId in
                                        (Select btd.TestID From dc_tp_branchTestd btd where
                                        (btd.DestinationBranchID!=null or btd.DestinationBranchID!=0)
                                         and btd.BranchID=" + _BranchID + @" and btd.Active='Y')
                                        and date_format(bd.EnteredOn,'%Y/%m/%d') between '" + _From + "' and '" + _To + "'";
                    break;
                case 7:
                    objdbhims.Query = @"Select distinct d.Batch_no batchNumber,d.DestinationbranchId,b.Name Destination From dc_tp_courierbatches d,dc_tp_branch b where
                                        d.DestinationbranchID=b.BranchID
                                        and d.Status='Q'
                                        and date_format(d.EnteredOn,'%Y/%m/%d') between '" + _From + "' and '" + _To + @"'
                                        and d.branchId="+_BranchID;
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        #endregion
    }
}
