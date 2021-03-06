﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using BusinessLayer;
using DataLayer;



    public class clsReporting
    {
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        private const string Default = "~!@";
        private const string TableName = "dc_tp_aranges";
        private const string TableName2 = "dc_tp_personnel";

        private const string TableName3 = "dc_tp_subdepartments";
        private const string TableName4 = "dc_tp_groupm";
        private const string TableName5 = "dc_tp_test";
        
        private string StrErrorMessage = "";
        private string StrError = Default;

        private string _RangeId = Default;
        private string _AttributeId = Default;
        private string _GroupId = Default;
        private string _SubdepartmentId = Default;

        private string _TestId = Default;
        private string _Sex = Default;
        private string _Age_Min = Default;
        private string _Age_Max = Default;
        private string _Min_Value = Default;

        private string _Max_Value = Default;
        private string _AUnit = Default;
        private string _Active = Default;

        private string _Min_Panic_Value = Default;
        private string _Max_Panic_Value = Default;
        private string _MethodID = Default;

        private string _ClientId = Default;
        private string _Enteredby = Default;
        private string _Enteredon = Default;
        private string _Description = Default;
        private string _bookingdid = Default;
        private string _prno = Default;
        private string _prid = Default;
        private string _ReferenceNo = Default;
        private string _ObjectDate = Default;
        private string _BranchID = Default;
        private string _PanelID = Default;
        private string _ConsultantID = Default;
        private string _Datefrom = Default;
        private string _Dateto = Default;
        private string _payment_mode = Default;

        public string Payment_mode
        {
            get { return _payment_mode; }
            set { _payment_mode = value; }
        }

        public string Dateto
        {
            get { return _Dateto; }
            set { _Dateto = value; }
        }
        public string Datefrom
        {
            get { return _Datefrom; }
            set { _Datefrom = value; }
        }
        public string ConsultantID
        {
            get { return _ConsultantID; }
            set { _ConsultantID = value; }
        }
        public string PanelID
        {
            get { return _PanelID; }
            set { _PanelID = value; }
        }
        public string BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }



        public string ObjectDate
        {
            get { return _ObjectDate; }
            set { _ObjectDate = value; }
        }

        public string ReferenceNo
        {
            get { return _ReferenceNo; }
            set { _ReferenceNo = value; }
        }

        public string Prid
        {
            get { return _prid; }
            set { _prid = value; }
        }

        public string Prno
        {
            get { return _prno; }
            set { _prno = value; }
        }
        private string _labid = Default;

        public string Labid
        {
            get { return _labid; }
            set { _labid = value; }
        }

        public string Bookingdid
        {
            get { return _bookingdid; }
            set { _bookingdid = value; }
        }


        #region Properties

        public string RangeId
        {
            get
            {
                return _RangeId;
            }
            set
            {
                _RangeId = value;
            }
        }
        public string AttributeId
        {
            get
            {
                return _AttributeId;
            }
            set
            {
                _AttributeId = value;
            }
        }

        public string GroupId
        {
            get
            {
                return _GroupId;
            }
            set
            {
                _GroupId = value;
            }
        }
        public string SubdepartmentId
        {
            get
            {
                return _SubdepartmentId;
            }
            set
            {
                _SubdepartmentId = value;
            }
        }

        public string TestId
        {
            get
            {
                return _TestId;
            }
            set
            {
                _TestId = value;
            }
        }
        public string Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }

        public string Age_Min
        {
            get
            {
                return _Age_Min;
            }
            set
            {
                _Age_Min = value;
            }
        }
        public string Age_Max
        {
            get
            {
                return _Age_Max;
            }
            set
            {
                _Age_Max = value;
            }
        }

        public string Min_Value
        {
            get
            {
                return _Min_Value;
            }
            set
            {
                _Min_Value = value;
            }
        }
        public string Max_Value
        {
            get
            {
                return _Max_Value;
            }
            set
            {
                _Max_Value = value;
            }
        }

        public string AUnit
        {
            get
            {
                return _AUnit;
            }
            set
            {
                _AUnit = value;
            }
        }
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public string Min_Panic_Value
        {
            get
            {
                return _Min_Panic_Value;
            }
            set
            {
                _Min_Panic_Value = value;
            }
        }
        public string Max_Panic_Value
        {
            get
            {
                return _Max_Panic_Value;
            }
            set
            {
                _Max_Panic_Value = value;
            }
        }
        public string MethodID
        {
            get { return _MethodID; }
            set { _MethodID = value; }
        }

        public string ClientId
        {
            get
            {
                return _ClientId;
            }
            set
            {
                _ClientId = value;
            }
        }
        public string Enteredby
        {
            get
            {
                return _Enteredby;
            }
            set
            {
                _Enteredby = value;
            }
        }
        public string Enteredon
        {
            get
            {
                return _Enteredon;
            }
            set
            {
                _Enteredon = value;
            }
        }

        public string ErrorMessage
        {
            get { return StrErrorMessage; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        #endregion



        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "select r.RangeId,g.Name as GroupName,case when r.Sex = 'M' then 'Male' when r.sex='F' then 'Female' else 'All' end as Sex,r.Age_Min,r.Age_Max,r.AUnit,r.methodid,r.active,concat(ifnull(r.min_value,'-'),'-',ifnull(r.max_value,'-'),'-',ifnull(r.aunit,'-')) as referencerange,concat('(',concat(case when r.age_min % 365=0 then floor(r.age_min/365) when r.age_min%30=0  then floor(r.age_min/30) else r.age_min end,'-',case when r.age_max % 365=0 then floor(r.age_max/365) when r.age_max%30=0  then floor(r.age_max/30) else r.age_max end),')',' ',case when r.age_max % 365=0 then 'Year(s)' when r.age_max%30=0  then 'Month(s)' else 'Day(s)' end)  as TotalAge,case when r.age_max % 365=0 then concat(floor(r.age_max/365),' Year(s)') when r.age_max%30=0  then concat(floor(r.age_max/30),' Month(s)') else concat(r.age_max,' Day(s)') end as MAX_age_show,t.test_name,a.attribute_name,concat(r.age_min,'-',r.age_max) totaldays,m.name as methodname,concat( (case when Age_Min > 365 then concat(Floor(Age_Min/365),' (Y) ') else '' end) ,(case when  ((Age_Min%365)  <> 0 )  then concat(Floor( ((Age_Min%365)) /30),' (M) ') else '' end),(case when  ( (Age_Min%365)  <> 0  and (Floor(Age_Min/365) % 30) <> 0 )  then concat(Floor(Age_Min % 30),' (D)')  else '' end)) as total_min,concat( (case when Age_Max > 365 then concat(Floor(Age_Max/365),' (Y) ') else '' end) ,(case when  ((Age_Max % 365)  <> 0 )  then concat(Floor( ((Age_Max%365)) /30),' (M) ') else '' end),(case when  ( (Age_Max % 365)  <> 0  and (Floor(Age_Max%365) % 30) <> 0 )  then concat(Floor(Age_Max % 30),' (D)')  else '' end)) as total_max from " + TableName + " r left outer join " + TableName5 + " t on r.TestId = t.TestId left outer join " + TableName4 + " g on r.GroupId = g.GroupId left outer join dc_tp_attributes a on r.attributeid=a.attributeid join dc_tp_method m on r.methodid=m.methodid where 1 = 1";
                    if (!_SubdepartmentId.Equals(Default))
                    {
                        objdbhims.Query += " and r.SubdepartmentId = " + _SubdepartmentId;
                    }
                    if (!_AttributeId.Equals(Default))
                    {
                        objdbhims.Query += " and r.AttributeId = " + _AttributeId;
                    }
                    if (!_GroupId.Equals(Default))
                    {
                        objdbhims.Query += " and r.GroupId = " + _GroupId;
                    }
                    if (!_TestId.Equals(Default))
                    {
                        objdbhims.Query += " and r.TestId = " + _TestId;
                    }
                    objdbhims.Query += " order by ifnull(a.dorder,a.attribute_name)";
                    break;

                case 2:
                    objdbhims.Query = "select  m.type,ifnull(w.name,'-') as ward,m.bed,ifnull(m.BranchID,'1') as branch,`p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,REPLACE(`pn`.`name`,'&amp;','&') AS `panel`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,m.labid from `dc_tpatient` `p` join `dc_tpatient_bookingm` `m` left join `dc_tp_refdoctors` `re` on `re`.`doctorid` = `m`.`doctorid` left join `dc_tpanel` `pn` on `pn`.`panelid` = `m`.`panelid` left join dc_tp_Ward w on w.wardid=m.wardid  where `p`.`prid` = `m`.`prid`";
                    if (!_prno.Equals(Default))
                    {
                        objdbhims.Query += " AND p.prno ='" + _prno + "'";
                    }
                    if (!_labid.Equals(Default))
                    {
                        objdbhims.Query += "  AND m.labid = '" + _labid + "'";
                    }
                    if (!_ReferenceNo.Equals(Default))
                    {
                        objdbhims.Query += "  AND m.adm_ref = '" + _ReferenceNo + "'";
                    }
                    objdbhims.Query += " LIMIT 1";
                    break;
                case 3:
                    objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='" + _prno + "' AND m.labid='" + _labid + "' AND d.TestId='"+_TestId+"' AND su.SubdepartmentId = '"+_SubdepartmentId+"' ";
                   //objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='006-10-00000936' AND m.labid = '11-006-00001881' ";
                    break;
                case 4:
                    objdbhims.Query = "SELECT t.`attribute_name`,REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as Normal,REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit,t.result,date_format(t.enteredon,'%b %d %Y') as enteredon FROM `dc_tresult` as t LEFT JOIN dc_tpatient_bookingd as b ON t.bookingdid = b.bookingdid WHERE b.bookingdid = '"+_bookingdid+"'";
                    //objdbhims.Query = "SELECT t.`attribute_name`,REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as Normal,REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit,t.result,date_format(t.enteredon,'%b %d %Y') as enteredon FROM `dc_tresult` as t LEFT JOIN dc_tpatient_bookingd as b ON t.bookingdid = b.bookingdid WHERE t.testid='" + _TestId + "' AND t.prid='" + _prid + "' ORDER BY b.deliverytime DESC";
                    break;
                    //////////////////////////////////////HISTOPATHOLOGY/////////////////////////////////////////////////////////
                case 5:
                   // objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,REPLACE(`pn`.`name`,'&amp;','&') AS `panel`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,m.labid from `dc_tpatient` `p` join `dc_tpatient_bookingm` `m` left join `dc_tp_refdoctors` `re` on `re`.`doctorid` = `m`.`doctorid` left join `dc_tpanel` `pn` on `pn`.`panelid` = `m`.`panelid` where `p`.`prid` = `m`.`prid` AND p.prno ='006-10-00000936' AND m.labid = '10-006-00002303'";
                    objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,REPLACE(`pn`.`name`,'&amp;','&') AS `panel`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,m.labid from `dc_tpatient` `p` join `dc_tpatient_bookingm` `m` left join `dc_tp_refdoctors` `re` on `re`.`doctorid` = `m`.`doctorid` left join `dc_tpanel` `pn` on `pn`.`panelid` = `m`.`panelid` where `p`.`prid` = `m`.`prid` AND p.prno ='"+_prno+"' AND m.labid = '"+_labid+"'";
                    break;
                case 6:
                    //objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='008-11-00002827' AND m.labid = '11-008-00006556' AND groupid='22' GROUP BY groupid ";
                    //objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='006-11-00006892' AND m.labid = '11-006-00006408' AND gm.groupid='22' GROUP BY gm.groupid";
                    //objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='008-12-00002803' AND m.labid = '12-008-00004068' AND su.SubdepartmentId='3'";
                    //objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='" + _prno + "' AND m.labid = '" + _labid + "' AND d.TestId='" + _TestId + "'  AND su.SubdepartmentId='"+_SubdepartmentId +"' ";
                    objdbhims.Query = @"select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,
                    ifnull(`gm`.`Name`,`t`.`Test_Name`) AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,
                    (case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place`
                    from (((((((((`dc_tpatient` `p`
                    join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`)))
                    join `dc_tpatient_bookingd` `d`)
                    left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`)))
                    join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`)))
                    left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`)))
                    left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`)))
                    where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='" + _prno + "' AND m.labid = '" + _labid + "' AND d.TestId='" + _TestId + "'  AND su.SubdepartmentId='" + _SubdepartmentId + "'";
                    break;
                case 7:
                    objdbhims.Query = "SELECT t.`attribute_name`,REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as Normal,REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit,t.result,date_format(t.enteredon,'%b %d %Y') as enteredon FROM `dc_tresult` as t LEFT JOIN dc_tpatient_bookingd as b ON t.bookingdid = b.bookingdid WHERE b.bookingdid = '" + _bookingdid + "'";
                    break;
                case 8:
                    objdbhims.Query = "SELECT `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,REPLACE(`pn`.`name`,'&amp;','&') AS `panel`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,m.labid from `dc_tpatient` `p` join `dc_tpatient_bookingm` `m` left join `dc_tp_refdoctors` `re` on `re`.`doctorid` = `m`.`doctorid` left join `dc_tpanel` `pn` on `pn`.`panelid` = `m`.`panelid` where `p`.`prid` = `m`.`prid` AND p.prno ='"+_prno+"' AND m.labid = '"+_labid+"'";
                    break;
                case 9:
                   // objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='006-11-00001290' AND m.labid = '11-006-00001793' AND gm.groupid='7' GROUP BY gm.groupid";
                   // objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='020-12-00000900' AND m.labid = '12-020-00000990' AND gm.groupid='7' GROUP BY gm.groupid";
                   // objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='006-10-00000456' AND m.labid = '10-006-00000475' AND  su.SubdepartmentId = '13' GROUP BY su.SubdepartmentId";
                    objdbhims.Query = "SELECT `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='" + _prno + "' AND m.labid = '" + _labid + "' AND d.TestId='" + _TestId + "'  AND su.SubdepartmentId = '" + _SubdepartmentId + "'";
                    break;
                case 10:
                    //objdbhims.Query = "SELECT t.`attribute_name`,REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as 'Normal Ranges',REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as 'Unit',t.result,date_format(t.enteredon,'%b %d %Y') as enteredon FROM `dc_tresult` as t LEFT JOIN dc_tpatient_bookingd as b ON t.bookingdid = b.bookingdid WHERE b.bookingdid = '" + _bookingdid + "'";
//                    objdbhims.Query = @"SELECT
//                    t.`attribute_name` as Test,
//                    REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as 'Nor. Ranges',
//                    REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit, " + _ObjectDate + " FROM `dc_tresultTemp` as t WHERE testid='" + _TestId + "'  AND prid='" + _prid + "' GROUP BY attribute_name ORDER BY t.dorder";
                    // REPLACE(REPLACE(REPLACE(t.Range_text,')',''),'(',''),'&nbsp;','') as Normal,
                    objdbhims.Query = @"SELECT t.`attribute_name` as Test,
                    REPLACE(SUBSTR(t.range_text,INSTR(t.range_text,'('),INSTR(t.range_text,')')),'&nbsp;','-') as Normal,
                    REPLACE(SUBSTR(t.range_text, instr(t.range_text ,')')+1),'&nbsp;','-') as Unit,
                    " + _ObjectDate + @"FROM (SELECT * FROM dc_tresult WHERE  testid='" + _TestId + "' AND prid='" + _prid + @"' UNION
                    SELECT * from dc_tresultm_archive WHERE  testid='" + _TestId + "' AND prid='" + _prid + "') t GROUP BY t.attributeid  ORDER BY t.dorder ";  
                    break;
                case 11:
                    objdbhims.Query = "SELECT s.OrganismID,d.DRUG,o.Organism,s.Senstivity FROM dc_tmicro_senstivity as s LEFT JOIN  dc_tp_organism as o ON s.OrganismID = o.OrganismID LEFT JOIN dc_tp_drug as d ON s.DRUGID = d.DRUGID WHERE s.`bookingdid` = '"+_bookingdid+"'";
                    //objdbhims.Query = "SELECT s.OrganismID,d.DRUG,o.Organism,s.Senstivity FROM dc_tmicro_senstivity as s LEFT JOIN  dc_tp_organism as o ON s.OrganismID = o.OrganismID LEFT JOIN dc_tp_drug as d ON s.DRUGID = d.DRUGID WHERE s.`bookingdid` = '103178'";
                    break;
                case 12:
                    //objdbhims.Query = "SELECT `comment`,`opinion` FROM dc_ttest_opinion WHERE `bookingdid` = '23' LIMIT 1";
                    objdbhims.Query = "SELECT distinct `comment`,`opinion` FROM dc_ttest_opinion WHERE `bookingdid` = '" + _bookingdid + "' AND type='V' ";
                    break;
                case 13:
                   // with SubdepartmentID.... objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='" + _prno + "' AND m.labid='" + _labid + "'  AND su.SubdepartmentId = '" + _SubdepartmentId + "' ";
                    objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND d.ProcessID IN ('7','8')  AND p.prno ='" + _prno + "' AND m.labid='" + _labid + "'  AND  su.SubdepartmentId = '" + _SubdepartmentId + "' ORDER BY su.subdepartmentid,gm.name,t.sepreport,t.testid ";
                        //objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='006-10-00000936' AND m.labid = '11-006-00001881' ";
                    break;
                    // testing..........................
                case 14:
//                    objdbhims.Query = @"SELECT
//                                        t.`attribute_name`,
//                                        REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as Normal,
//                                        REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit,
//                                          MAX(IF(t.enteredon = '2012-03-02 18:44:54', t.result, NULL)) AS '2012-03-02 18:44:54',
//                                          MAX(IF(t.enteredon = '2012-04-02 19:15:52', t.result, NULL)) AS '2012-04-02 19:15:52',
//                                          MAX(IF(t.enteredon = '2012-05-02 19:15:52', t.result, NULL)) AS 'NULL'
//                                        FROM `dc_tresult` as t
//                                        WHERE testid='369' AND prid='788' GROUP BY attribute_name";
                   objdbhims.Query = @"SELECT
                    t.`attribute_name` as Test,
                    REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as 'Nor. Ranges',
                    REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit, " + _ObjectDate + " FROM `dc_tresultTemp` as t WHERE testid='" + _TestId + "' AND result <> '-' AND prid='" + _prid + "' GROUP BY attribute_name ORDER BY t.dorder";

                    //My Last Execution
//                   objdbhims.Query = @"SELECT t.`attribute_name` as Test,
//REPLACE(SUBSTR(t.range_text,INSTR(t.range_text,'('),INSTR(t.range_text,')')),'&nbsp;','-') as Normal,
//REPLACE(SUBSTR(t.range_text, instr(t.range_text ,')')+1),'&nbsp;','-') as Unit,
//" + _ObjectDate + @"FROM (SELECT * FROM dc_tresult WHERE testid='" + _TestId + "' AND prid='" + _prid + @"' UNION
//SELECT * from dc_tresultm_archive WHERE testid='" + _TestId + "' AND prid='" + _prid + "') t ";                                     
                   break;
                case 15:
                    // objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon  FROM `dc_tresult` as t WHERE testid='369' AND prid='788' GROUP BY t.enteredon";
                   objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon , date_format(t.enteredon,'%b %d,%y - %H:%i') as headerName,t.result   FROM `dc_tresultTemp` as t WHERE testid='" + _TestId + "' AND prid='" + _prid + "' GROUP BY t.enteredon ORDER BY t.enteredon DESC LIMIT 3";
                   // objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon , date_format(t.enteredon,'%b %d,%y - %H:%i') as headerName , t.result
                                       // from (select result,resultid,testid,prid,enteredon from dc_tresult WHERE testid='" + _TestId + "' AND prid='" + _prid + @"' GROUP BY enteredon UNION
                                       // SELECT result,resultid,testid,prid,enteredon from dc_tresultm_archive WHERE testid='" + _TestId + @"' AND prid='" + _prid + @"' GROUP BY enteredon) t
                                       // GROUP BY t.resultid
                                       // ORDER BY t.enteredon DESC LIMIT 3";
                    break;
                case 16:
                        // objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon  FROM `dc_tresult` as t WHERE testid='369' AND prid='788' GROUP BY t.enteredon";
                        objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon , date_format(t.enteredon,'%b %d,%y - %H:%i') as headerName  FROM `dc_tresult` as t WHERE testid='" + _TestId + "' AND prid='" + _prid + "' GROUP BY t.enteredon ORDER BY t.enteredon DESC LIMIT 2";
                        break;
                case 17:
                       objdbhims.Query = @"SELECT
                        t.`attribute_name` as Test,
                        REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as Normal,
                        REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit, " + _ObjectDate + " FROM `dc_tresult` as t WHERE testid='" + _TestId + "' AND prid='" + _prid + "' GROUP BY attribute_name";
                        break;
                case 18:
                    //,REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as Normal
                    objdbhims.Query = @"SELECT
                    t.`attribute_name` as Test," + _ObjectDate + @",REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit,CONCAT('1','.0000') as 'Conversion Factor',CONCAT('12','.13') as 'Result in SI Unit',CONCAT('mIU','/L') as 'SI Unit'
                    FROM `dc_tresultTemp` as t WHERE testid='" + _TestId + "' AND prid='" + _prid + "' AND result <> '-' GROUP BY attribute_name";
                    break;
                case 19:
                    objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND d.ProcessID IN ('7','8') AND p.prno ='" + _prno + "' AND m.labid='" + _labid + "' AND t.testid='"+_TestId+"'  AND su.SubdepartmentId = '" + _SubdepartmentId + "' ";
                    //objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='006-10-00000936' AND m.labid = '11-006-00001881' ";
                    break;
                //case 19:
                //    objdbhims.Query = "DELETE FROM dc_tresult_view";
                //    break;
                //case 20:
                //    // objdbhims.Query = @"CREATE OR REPLACE TABLE dc_tresultTemp AS SELECT * FROM dc_tresult WHERE testid='"+_TestId+"' AND prid='"+_prid+ @"'  UNION
                //    // SELECT * from dc_tresultm_archive WHERE testid='"+_TestId+"' AND prid='"+_prid+"' ";
                //    objdbhims.Query = @"INSERT INTO dc_tresult_view (SELECT * FROM dc_tresult WHERE testid='" + _TestId + "' AND prid='" + _prid + "')";                                                 
                //    break;
                //case 21:
                //    objdbhims.Query = @"INSERT INTO dc_tresult_view (SELECT * from dc_tresultm_archive WHERE testid='" + _TestId + "' AND prid='" + _prid + "')";                                                 
                //    break;
                case 22:
                    objdbhims.Query = "SELECT REPLACE(AutomatedText, '\r\n', '<br/>') as autotext,Test_Name,AutomatedText FROM dc_tp_test  WHERE testid = '" + _TestId + "' ";
                    break;
                case 23:
                    objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='" + _prno + "' AND m.labid='" + _labid + "' AND d.ProcessID IN (7,8) GROUP BY  su.SubdepartmentId";
                    //objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='006-10-00000936' AND m.labid = '11-006-00001881' ";
                    break;
                case 24:
                    // objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon  FROM `dc_tresult` as t WHERE testid='369' AND prid='788' GROUP BY t.enteredon";
                    objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon , date_format(t.enteredon,'%b %d,%y') as headerName,t.result   FROM `dc_tresultTemp` as t WHERE testid='" + _TestId + "' AND prid='" + _prid + "' GROUP BY t.enteredon ORDER BY t.enteredon DESC LIMIT 2";
                    break;
                case 25:
                    objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon , date_format(t.enteredon,'%b %d,%y - %H:%i') as headerName , t.result
                                        from (select result,resultid,testid,prid,enteredon from dc_tresult WHERE testid='" + _TestId + "' AND prid='" + _prid + @"' GROUP BY enteredon UNION
                                        SELECT result,resultid,testid,prid,enteredon from dc_tresultm_archive WHERE testid='" + _TestId + @"' AND prid='" + _prid + @"' GROUP BY enteredon) t
                                        GROUP BY t.resultid
                                        ORDER BY t.enteredon DESC LIMIT 3";
                    break;
                case 29:
                    //objdbhims.Query = "SELECT REPLACE(AutomatedText, '\r\n', '<br/>') as autotext,Test_Name FROM dc_tp_test  WHERE testid = '" + _TestId + "' ";
                    //objdbhims.Query = "SELECT REPLACE(description, '\r\n', '<br/>') as description FROM dc_tp_aranges WHERE testid = '"+_TestId+"' ";
                    //objdbhims.Query = "SELECT REPLACE(r.description, '\r\n', '<br/>') as description ,t.Attribute_Name FROM  dc_tp_aranges r LEFT JOIN dc_tp_attributes t ON r.AttributeId = t.AttributeId WHERE t.testid = '" + _TestId + "' ";
                    objdbhims.Query = "SELECT REPLACE(r.description, '\r\n', '<br/>') as description ,t.Attribute_Name FROM  dc_tp_aranges r LEFT JOIN dc_tp_attributes t ON r.AttributeId = t.AttributeId WHERE t.testid = '" + _TestId + "' AND r.description <> '' ";
                    break;

                case 26://for cash invoice report master grid
                    objdbhims.Query = @"
                                    SELECT
                                      date_format(`dc_tpatient_bookingm`.`enteredon`,'%d-%b-%Y') bookedon,
                                      `dc_tpatient_bookingm`.`labid`,
                                      `dc_tpatient`.`name` patientname,
                                      `dc_tp_test`.`Test_Name`,
                                      `dc_tpatient_bookingm`.`bookingid`,
                                      `dc_tp_refdoctors`.`name` consultant,
                                      `dc_tpanel`.`name` panel,
                                      `dc_tpatient_bookingm`.`totalamount` charges,
                                      IfNull(`dc_tpatient_bookingm`.`paidamount`,0) paidamount,
                                      `dc_tpatient_bookingd`.`totalamount` totamount,
                                      `dc_tpatient_bookingm`.`doctorid`,
                                      `dc_tp_refdoctors`.`title`,
                                      `dc_tpatient`.`title`,
                                      `dc_tp_personnel`.`Salutation`,
                                      `dc_tp_personnel`.`FName` enteredby,
                                      `dc_tp_personnel`.`MName`,
                                      `dc_tp_personnel`.`LName`,
                                      `discountreception_sumary`.`discount` discount_amt,
                                      `dc_tpatient_bookingm`.`panelid`,
                                      `dc_tpatient_bookingd`.`clientid`,
                                      (`dc_tpatient_bookingm`.`totalamount`-ifnull(`dc_tpatient_bookingm`.`paidamount`,0)-ifnull(`discountreception_sumary`.`discount`,0)) AS balance
                                    FROM
                                      {oj(
                                        (
                                          (
                                            `dc_tp_personnel` `dc_tp_personnel` INNER JOIN (
                                              `discountreception_sumary` `discountreception_sumary` INNER
                                              JOIN (
                                                (
                                                  `bc_lims`.`dc_tpatient_bookingd`
                                                  `dc_tpatient_bookingd` INNER JOIN `bc_lims`.`dc_tpatient_bookingm`
                                                  `dc_tpatient_bookingm` ON `dc_tpatient_bookingd`.`bookingid`
                                                  = `dc_tpatient_bookingm`.`bookingid`
                                                ) INNER JOIN `bc_lims`.`dc_tp_test` `dc_tp_test` ON
                                                `dc_tpatient_bookingd`.`testid` = `dc_tp_test`.`TestId`
                                              ) ON (
                                                `discountreception_sumary`.`bookingid` =
                                                `dc_tpatient_bookingm`.`bookingid`
                                              )
                                              AND (
                                                    `discountreception_sumary`.`prid` =
                                                    `dc_tpatient_bookingm`.`prid`
                                                  )
                                            ) ON `dc_tp_personnel`.`PersonId` = `dc_tpatient_bookingm`.`enteredby`
                                          ) INNER JOIN `bc_lims`.`dc_tpatient` `dc_tpatient` ON
                                          `dc_tpatient_bookingm`.`prid` = `dc_tpatient`.`prid`
                                        ) LEFT OUTER JOIN `bc_lims`.`dc_tp_refdoctors` `dc_tp_refdoctors` ON
                                        `dc_tpatient_bookingm`.`doctorid` = `dc_tp_refdoctors`.`doctorid`
                                      )
                                      LEFT OUTER JOIN bc_lims.dc_tpanel `dc_tpanel`
                                        ON   `dc_tpatient_bookingm`.`panelid` = `dc_tpanel`.`panelid`}
                                    WHERE 
                                      
                                      `dc_tpatient_bookingm`.`enteredon` BETWEEN str_to_date('" + _Datefrom + @"','%d/%m/%Y')
                                      AND STR_TO_DATE('" + _Dateto + @"','%d/%m/%Y')";
                    if (!_ConsultantID.Equals(Default) && !_ConsultantID.Equals(""))
                    {
                        objdbhims.Query += @" and `dc_tp_refdoctors`.Doctorid=" + _ConsultantID;
                    }
                    if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
                    {
                        objdbhims.Query += " and `dc_tpatient_bookingm`.PanelID=" + _PanelID;
                    }
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and `dc_tpatient_bookingm`.branchid=" + _BranchID;
                    }

                    objdbhims.Query += @" GROUP BY dc_tpatient_bookingm.bookingid
                                      ORDER BY
                                      `dc_tpatient_bookingd`.`clientid`,
                                      `dc_tpatient_bookingm`.`bookingid`";
                    break;

                case 27://Cash Summary Report(Refund/Cancellations master)
                    objdbhims.Query = @"SELECT
                                          m.bookingid,
                                          m.labid,
                                          m.prid,
                                          CASE
                                            WHEN p.panelid IS NOT NULL AND m.payment_mode = 'A' AND (r.refundtype = 'C' OR r.refundtype = 'W') THEN
                                                 r.totalamount
                                            ELSE r.paidamount
                                          END  AS paidamount,
                                          r.refundtype,
                                          t.test_name,
                                          r.comments,
                                          CONCAT(IFNULL(p.title, ''), ' ', p.name) AS patientname,
                                          r.enteredon,
                                          m.clientid
                                        FROM
                                          dc_tpatient_bookingm m
                                          JOIN dc_Tcashrefund r
                                            ON   m.bookingid = r.bookingid
                                          LEFT OUTER JOIN dc_tp_test t
                                            ON   t.testid = r.testid
                                          JOIN dc_tpatient p
                                            ON   p.prid = m.prid
                                        WHERE m.enteredon<>r.enteredon
                                        AND m.enteredon BETWEEN str_to_date('" + _Datefrom + @"','%d/%m/%Y') AND str_to_date('" + _Dateto + @"','%d/%m/%Y')";
                    if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
                    {
                        objdbhims.Query += " and m.PanelID=" + _PanelID;
                    }
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and m.branchid=" + _BranchID;
                    }

                    objdbhims.Query += @" GROUP BY m.bookingid";
                    break;
                case 28://Cash Summary Report(Refund/Cancellations Detail)
                    objdbhims.Query = @"SELECT case when r.refundtype='C' then 'Cancel' when r.refundtype='D' then 'Discount' when r.refundtype='K' then 'BCL Staff' when r.refundtype='R' then 'Poor Patient' when r.refundtype='W' then 'Wrong Entry' else 'Not Defined' end as refundType ,
                                        CASE
                                            WHEN p.panelid IS NOT NULL AND m.payment_mode = 'A' AND (r.refundtype = 'C' OR r.refundtype = 'W') THEN
                                                    r.totalamount
                                            ELSE r.paidamount
                                            END  AS paidamount,t.test_name
                                        FROM dc_tpatient_bookingm m
                                            JOIN dc_Tcashrefund r
                                            ON   m.bookingid = r.bookingid
                                            LEFT OUTER JOIN dc_tp_test t
                                            ON   t.testid = r.testid
                                            JOIN dc_tpatient p
                                            ON   p.prid = m.prid
                                        WHERE m.enteredon<>r.enteredon
                                        and r.bookingid =" + _bookingdid;
                    break;
                case 30:
                    objdbhims.Query = @"select SUM(d.totalamount) as rate,m.labid,m.bookingid,pn.panelid,pn.name as panelname,
m.enteredon,d.clientid
from  dc_tpatient_bookingm m join dc_tpatient_bookingd d join dc_tpanel pn
where  m.bookingid = d.bookingid and m.panelid=pn.panelid
and d.status<>'X' AND m.enteredon BETWEEN str_to_date('" + _Datefrom + @"','%d/%m/%Y') AND str_to_date('" + _Dateto + @"','%d/%m/%Y')";
                    if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
                    {
                        objdbhims.Query += " and m.PanelID=" + _PanelID;
                    }
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and m.branchid=" + _BranchID;
                    }
                    objdbhims.Query += @" GROUP BY panelid";
                    break;
                case 31: // All branches totals used on Report/rpt_cashsummary_report.aspx
                    objdbhims.Query = @"select br.Name as branch,m.branchid,sum(m.totalamount) totalamount,sum(m.discount_amt) as discamount,
                                        sum(m.refund_amt) as refundamount ,sum(m.paidamount) paidamount,sum(balance) as balance,
                                        (select Round((sum((ifnull(d.totalamount,0)*ifnull(b.percentagediscount,0))/100))/10)*10 as net

                                        From dc_tpatient_bookingd d,dc_tp_branchtestd b,dc_tpatient_bookingm m1
                                        where b.branchid=m1.branchid
                                        and d.testid=b.testid
                                        and d.bookingid=m1.bookingid
                                        and m1.branchid=m.branchid
                                        and b.Active='Y' and d.status!='X' ";
                                        if (!_payment_mode.Equals(Default) && !_payment_mode.Equals(""))
                                        {
                                            objdbhims.Query += " and m1.payment_mode='"+_payment_mode+"'";
                                        }
                                        if(!_Datefrom.Equals(Default) && !Datefrom.Equals(""))
                                        {
                                            objdbhims.Query+=" and date_format(m1.enteredon,'%Y/%m/%d') between '"+_Datefrom+"' and '"+_Dateto+"'";
                                        }
                                        objdbhims.Query+=@") as branchshare
                                        from dc_tpatient_bookingm m inner join dc_tp_branch br on br.branchid=m.branchid where  m.Branchid is not null";
                                        if(!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                                        {
                                            objdbhims.Query+=" and m.branchid="+_BranchID;
                                        }
                                        if (!_payment_mode.Equals(Default) && !_payment_mode.Equals(""))
                                        {
                                            objdbhims.Query += " and m.payment_mode='" + _payment_mode + "'";
                                        }
                                        if(!_Datefrom.Equals(Default) && !Datefrom.Equals(""))
                                        {
                                            objdbhims.Query+=" and date_format(m.enteredon,'%Y/%m/%d') between '"+_Datefrom+"' and '"+_Dateto+"'";
                                        }
                                        objdbhims.Query+=" group by m.branchid";
                    break;
                case 32:// Previous Refunds used on Report/rpt_cashsummary_report.aspx
//                    objdbhims.Query = @"Select b.name as branch,r.totalamount,r.paidamount,t.test_name,m.labid,pp.name,
//Round((ifnull(r.paidamount,0)*ifnull(bt.percentagediscount,0)/100)) as branchshare,
//date_format(m.enteredon,'%d/%m/%Y') as bookingdate,
//date_format(r.enteredon,'%d/%m/%Y') as RefundDate,p.fname as Refundedby
//From dc_tcashrefund r inner join dc_tpatient_bookingm m on m.bookingid=r.bookingid
//inner join dc_tp_branch b on b.branchid=m.branchid
//inner join dc_tp_branchtestd bt on bt.branchid=b.branchid
//and bt.testid=r.testid
//Inner join dc_tp_test t on t.testid=r.testid
//inner join dc_tp_personnel p on p.personid=r.enteredby
//inner join dc_tpatient pp on pp.prid=m.prid
//where date_format(m.enteredon,'%Y/%m/%d') not between '2013/07/11' and '2013/07/12'
//and date_format(r.enteredon,'%Y/%m/%d')  between '2013/07/11' and '2013/07/12'
//and bt.Active='Y'";
                    objdbhims.Query = @"Select b.name as branch,r.totalamount,r.paidamount,t.test_name,m.labid,pp.name,
Round((ifnull(r.paidamount,0)*ifnull(bt.percentagediscount,0)/100)) as branchshare,
date_format(m.enteredon,'%d/%m/%Y') as bookingdate,
date_format(r.enteredon,'%d/%m/%Y') as RefundDate,p.fname as Refundedby
From dc_tcashrefund r inner join dc_tpatient_bookingm m on m.bookingid=r.bookingid
inner join dc_tp_branch b on b.branchid=m.branchid
inner join dc_tp_branchtestd bt on bt.branchid=b.branchid
and bt.testid=r.testid
Inner join dc_tp_test t on t.testid=r.testid
inner join dc_tp_personnel p on p.personid=r.enteredby
inner join dc_tpatient pp on pp.prid=m.prid
                                        where date_format(m.enteredon,'%Y/%m/%d') not between '" + _Datefrom + "' and '" + _Dateto + @"'
                                        and date_format(r.enteredon,'%Y/%m/%d')  between '" + _Datefrom + "' and '" + _Dateto + @"'
                                        and bt.Active='Y'";
                    break;

                case 33://30 days balance
                    objdbhims.Query = @"select  sum(ifnull(balance,0)) as totalbalance from dC_tpatient_bookingm
where enteredon between date_sub(sysdate(),interval 30 day) and sysdaTE()";
                    break;
                case 34://60 days balance
                    objdbhims.Query = @"select  sum(ifnull(balance,0)) as totalbalance from dC_tpatient_bookingm
where enteredon between date_sub(sysdate(),interval 60 day) and sysdaTE()";
                    break;
                case 35://90 days balance
                    objdbhims.Query = @"select  sum(ifnull(balance,0)) as totalbalance from dC_tpatient_bookingm
where enteredon between date_sub(sysdate(),interval 90 day) and sysdaTE()";
                    break;
                case 36://All Branches cash/net totals panel patients used on rptcashsummary_report.aspx
                    objdbhims.Query = @"select br.Name as branch,m.branchid,sum(m.totalamount) totalamount,
                                        (select Round((sum((ifnull(d.totalamount,0)*ifnull(b.percentagediscount,0))/100))/10)*10 as net
                                        From dc_tpatient_bookingd d,dc_tp_branchtestd b,dc_tpatient_bookingm m1
                                        where b.branchid=m1.branchid
                                        and d.testid=b.testid
                                        and d.bookingid=m1.bookingid
                                        and m1.branchid=m.branchid
                                        and b.Active='Y' and m1.Payment_mode='A' and d.status!='X' ";
                                        if(!_Datefrom.Equals(Default) && !Datefrom.Equals(""))
                                        {
                                            objdbhims.Query+=" and date_format(m1.enteredon,'%Y/%m/%d') between '"+_Datefrom+"' and '"+_Dateto+"'";
                                        }
                                        objdbhims.Query += @") as branchshare,
                                            (Select sum(t.charges-d.totalamount)
                                            from dc_tpatient_bookingd d,dc_tp_test t,dc_tpatient_bookingm m2
                                            where d.testid=t.testid
                                            and d.bookingid=m2.bookingid
                                            and m2.branchid=m.branchid
                                            AND d.status!='X' and m2.payment_mode='A'";
                                        if(!_Datefrom.Equals(Default) && !Datefrom.Equals(""))
                                        {
                                            objdbhims.Query+=" and date_format(m2.enteredon,'%Y/%m/%d') between '"+_Datefrom+"' and '"+_Dateto+"'";
                                        }
                                        objdbhims.Query+=@") as tradediscount

                                        from dc_tpatient_bookingm m inner join dc_tp_branch br on br.branchid=m.branchid 
                                        where  m.Branchid is not null and m.payment_mode='A' ";
                                        if(!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                                        {
                                            objdbhims.Query+=" and m.branchid="+_BranchID;
                                        }
                                        
                                        if(!_Datefrom.Equals(Default) && !Datefrom.Equals(""))
                                        {
                                            objdbhims.Query+=" and date_format(m.enteredon,'%Y/%m/%d') between '"+_Datefrom+"' and '"+_Dateto+"'";
                                        }
                                        objdbhims.Query+=" group by m.branchid";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }


        public bool Delete_RecordResultView()
        {
            objTrans.Start_Transaction();
           // objdbhims.Query = "DELETE FROM dc_tresult_view";
            objdbhims.Query = " DROP VIEW IF EXISTS `bc_lims`.dc_tresulttemp";
            StrError = objTrans.DataTrigger_Insert(objdbhims);
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


        public bool Insert_RecordResultView()
        {
            objTrans.Start_Transaction();
            //objdbhims.Query = "INSERT INTO dc_tresult_view (SELECT * FROM dc_tresult WHERE prid='" + _prid + "')";

            objdbhims.Query = @"CREATE OR REPLACE VIEW dc_tresultTemp AS SELECT * FROM dc_tresult WHERE prid='"+_prid+ @"'  UNION
SELECT * from dc_tresultm_archive WHERE  prid='"+_prid+"'";

            StrError = objTrans.DataTrigger_Insert(objdbhims);

            if (StrError.Equals("True"))
            {
                objTrans.End_Transaction();
                StrError = objTrans.OperationError;
                return false;
            }
            else
            {
                //objdbhims.Query = "INSERT INTO dc_tresult_view (SELECT * FROM dc_tresultm_archive WHERE prid='" + _prid + "')";
                //StrError = objTrans.DataTrigger_Insert(objdbhims);

                //if (StrError.Equals("True"))
                //{
                //    objTrans.End_Transaction();
                //    StrError = objTrans.OperationError;
                //    return false;
                //}

                //else
                //{
                    objTrans.End_Transaction();
                    return true;
              //  }
            }
        }

    }

