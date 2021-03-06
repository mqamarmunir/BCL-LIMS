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
        private string _organizationName = Default;
        private string _AbnormalObject = Default;
        private string _Payment_mode = Default;
        private string _ObjectDate1 = Default;
        private string _Type = Default;
        private string _Organism = Default;
        private string _Drug = Default;

        

       

        

        
        public string Reporttype { get; set; }
        public string Drug
        {
            get { return _Drug; }
            set { _Drug = value; }
        }
        public string Organism
        {
            get { return _Organism; }
            set { _Organism = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string ObjectDate1
        {
            get { return _ObjectDate1; }
            set { _ObjectDate1 = value; }
        }
        public string Payment_mode
        {
            get { return _Payment_mode; }
            set { _Payment_mode = value; }
        }

        public string AbnormalObject
        {
            get { return _AbnormalObject; }
            set { _AbnormalObject = value; }
        }
        public string OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; }
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
                    objdbhims.Query = "select m.referenceno, m.specimen_Internal,m.type,ifnull(w.name,'-') as ward,m.bed,ifnull(m.BranchID,'1') as branch,`p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,date_format(`m`.`enteredon`,'%d/%m/%Y') AS `registrationDate`,REPLACE(`pn`.`name`,'&amp;','&') AS `panel`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,m.labid from `dc_tpatient` `p` join `dc_tpatient_bookingm` `m` left join `dc_tp_refdoctors` `re` on `re`.`doctorid` = `m`.`doctorid` left join `dc_tpanel` `pn` on `pn`.`panelid` = `m`.`panelid` left join dc_tp_Ward w on w.wardid=m.wardid where `p`.`prid` = `m`.`prid`";
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
                   
                    //objdbhims.Query = "select  ifnull(m.BranchID,'1') as branch,`p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,date_format(`m`.`enteredon`,'%d/%m/%Y') AS `registrationDate`,REPLACE(`pn`.`name`,'&amp;','&') AS `panel`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,m.labid from `dc_tpatient` `p` join `dc_tpatient_bookingm` `m` left join `dc_tp_refdoctors` `re` on `re`.`doctorid` = `m`.`doctorid` left join `dc_tpanel` `pn` on `pn`.`panelid` = `m`.`panelid` where `p`.`prid` = `m`.`prid`";
                    //if (!_prno.Equals(Default))
                    //{
                    //    objdbhims.Query += " AND p.prno ='" + _prno + "'";
                    //}
                    //if (!_labid.Equals(Default))
                    //{
                    //    objdbhims.Query += "  AND m.labid = '" + _labid + "'";
                    //}
                    //if (!_ReferenceNo.Equals(Default))
                    //{
                    //    objdbhims.Query += "  AND m.adm_ref = '" + _ReferenceNo + "'";
                    //}
                    //objdbhims.Query += " LIMIT 1";
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
                    objdbhims.Query = "SELECT case when t.Heading='Y' then concat('<b><u>',t.`attribute_name`,'</u></b>') else t.`attribute_name` end as attribute_name,REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as Normal,REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit,t.result,date_format(t.enteredon,'%b %d %Y') as enteredon FROM `dc_tresult` as t LEFT JOIN dc_tpatient_bookingd as b ON t.bookingdid = b.bookingdid WHERE b.bookingdid = '" + _bookingdid + "' and t.Print='Y' order by t.dorder";
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
                    objdbhims.Query = @"SELECT case when t.Heading='Y' then concat('<b><u>',t.`attribute_name`,'</u></b>') else  t.`attribute_name` end as Test,
                    REPLACE(SUBSTR(t.range_text,INSTR(t.range_text,'('),INSTR(t.range_text,')')),'&nbsp;','-') as Normal,
                    REPLACE(SUBSTR(t.range_text, instr(t.range_text ,')')+1),'&nbsp;','-') as Unit,
                    " + _ObjectDate + @"FROM (SELECT * FROM dc_tresult WHERE Print='Y' and  testid='" + _TestId + "' AND prid='" + _prid + @"' UNION
                    SELECT * from dc_tresultm_archive WHERE  testid='" + _TestId + "' and Print='Y' AND prid='" + _prid + "') t GROUP BY t.attributeid  ORDER BY t.dorder ";  
                    break;
                case 11:
                    objdbhims.Query = "SELECT s.OrganismID,d.DRUG,o.Organism,s.Senstivity FROM dc_tmicro_senstivity as s LEFT JOIN  dc_tp_organism as o ON s.OrganismID = o.OrganismID LEFT JOIN dc_tp_drug as d ON s.DRUGID = d.DRUGID WHERE s.`bookingdid` = '"+_bookingdid+"'";
                    //objdbhims.Query = "SELECT s.OrganismID,d.DRUG,o.Organism,s.Senstivity FROM dc_tmicro_senstivity as s LEFT JOIN  dc_tp_organism as o ON s.OrganismID = o.OrganismID LEFT JOIN dc_tp_drug as d ON s.DRUGID = d.DRUGID WHERE s.`bookingdid` = '103178'";
                    break;
                case 12:
                    //objdbhims.Query = "SELECT `comment`,`opinion` FROM dc_ttest_opinion WHERE `bookingdid` = '23' LIMIT 1";
                    objdbhims.Query = "SELECT distinct `comment`,`opinion` FROM dc_ttest_opinion WHERE `bookingdid` = '" + _bookingdid + "'  order by enteredon desc Limit 1 ";//and type='V' removed this on request of ALi(lab technologist)
                    break;
                case 13:
                   // with SubdepartmentID.... objdbhims.Query = "select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND p.prno ='" + _prno + "' AND m.labid='" + _labid + "'  AND su.SubdepartmentId = '" + _SubdepartmentId + "' ";
                    objdbhims.Query = @"select `p`.`prid` AS `prid`,`p`.`prno` AS `prno`,`p`.`title` AS `patienttitle`,(case when isnull(`p`.`title`) then `p`.`name` else concat(`p`.`title`,_latin1'.',`p`.`name`) end) AS `name`,(case when (`p`.`gender` = _latin1'M') then _utf8'Male' else _utf8'Female' end) AS `gender`,`p`.`address` AS `address`,(case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 365) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 365)),_utf8' Year(s)') else (case when ((to_days(curdate()) - to_days(`p`.`dob`)) > 30) then concat(floor(((to_days(curdate()) - to_days(`p`.`dob`)) / 30)),_utf8' Month(s)') else concat((to_days(curdate()) - to_days(`p`.`dob`)),_utf8'Day(s)') end) end) AS `age`,`t`.`TestId` AS `testid`,`t`.`Test_Name` AS `test_name`,`t`.`SepReport` AS `sepreport`,`t`.`PrintGroup` AS `printgroup`,`t`.`PrintTest` AS `printtest`,`t`.`GroupId` AS `groupid`,`t`.`reportformat` AS `reportformat`,(case when (`tt`.`totaltext` = 1) then 1 else 0 end) AS `totaltext`,`t`.`AutomatedText` AS `automatedtext`,`gm`.`Name` AS `groupname`,`m`.`labid` AS `labid`,`m`.`bookingid` AS `bookingid`,(case when isnull(`m`.`doctorid`) then `m`.`referredby` else `re`.`name` end) AS `consultant`,`m`.`enteredon` AS `registrationDate`,`d`.`ProcessID` AS `processid`,`re`.`code` AS `code`,`re`.`title` AS `title`,`m`.`referenceno` AS `referenceno`,`t`.`SubdepartmentId` AS `subdepartmentid`,`pn`.`name` AS `panel`,`su`.`DepartmentId` AS `departmentid`,`m`.`payment_mode` AS `patienttype`,(case when (isnull(`p`.`hphone`) or (`p`.`hphone` = _utf8'')) then `p`.`cellno` else `p`.`hphone` end) AS `phoneNo`,`d`.`bookingdid` AS `bookingdid`,`w`.`name` AS `ward`,`m`.`type` AS `ind_outdoor`,`m`.`origin_place` AS `origin_place` from (((((((((`dc_tpatient` `p` join `dc_tpatient_bookingm` `m`) join `dc_tp_test` `t`) left join `dc_tp_refdoctors` `re` on((`re`.`doctorid` = `m`.`doctorid`))) left join `dc_tp_groupm` `gm` on((`gm`.`GroupId` = `t`.`GroupId`))) join `dc_tpatient_bookingd` `d`) left join `dc_tpanel` `pn` on((`pn`.`panelid` = `m`.`panelid`))) join `dc_tp_subdepartments` `su` on((`su`.`SubdepartmentId` = `t`.`SubdepartmentId`))) left join `dc_tp_ward` `w` on((`w`.`wardid` = `m`.`wardid`))) left join `dc_vtotaltext` `tt` on((`tt`.`testid` = `d`.`testid`))) where ((`p`.`prid` = `m`.`prid`) and (`m`.`bookingid` = `d`.`bookingid`) and (`d`.`testid` = `t`.`TestId`)) AND d.ProcessID IN ('7','8')  AND p.prno ='" + _prno + "' AND m.labid='" + _labid + "'  AND  su.SubdepartmentId = '" + _SubdepartmentId + "'";
                    if (_bookingdid != null && !_bookingdid.Equals("~!@"))
                    { objdbhims.Query += " and d.bookingdid='" + _bookingdid + "'"; }
                    objdbhims.Query +="    ORDER BY su.subdepartmentid,gm.name,t.sepreport,t.testid ";
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
                    if (OrganizationName != "SL")
                    {
                        //TEsting without View                       
                         objdbhims.Query = @"SELECT
                    t.`attribute_name` as Test,
                    REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as 'Nor. Ranges',
                    REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit, " + _ObjectDate + " FROM `dc_tresultTemp` as t WHERE testid='" + _TestId + "' AND (result <> '-' or heading='Y') AND prid='" + _prid + "' GROUP BY attribute_name ORDER BY t.dorder";


                        
//                                                objdbhims.Query = @"SELECT
//                                            t.`attribute_name` as Test,
//                                            REPLACE(SUBSTR(`range_text`,INSTR(`range_text`,'('),INSTR(`range_text`,')')),'&nbsp;','-') as 'Nor. Ranges',
//                                            REPLACE(SUBSTR(range_text, instr(range_text ,')')+1),'&nbsp;','-') as Unit, " + _ObjectDate + ",t.dorder dorder FROM `dc_tresult` as t WHERE t.testid='" + _TestId + "' AND t.result <> '-' AND t.prid='" + _prid + @"' GROUP BY t.attribute_name
//                        union
//                        SELECT
//                                            t1.`attribute_name` as Test,
//                                            REPLACE(SUBSTR(t1.`range_text`,INSTR(t1.`range_text`,'('),INSTR(t1.`range_text`,')')),'&nbsp;','-') as 'Nor. Ranges',
//                                            REPLACE(SUBSTR(t1.range_text, instr(t1.range_text ,')')+1),'&nbsp;','-') as Unit, " + _ObjectDate1 + " ,t1.dorder dorder FROM `dc_tresultm_archive` as t1 WHERE t1.testid='" + _TestId + "' AND t1.result <> '-' AND t1.prid='" + _prid + @"' GROUP BY t1.attribute_name order by dorder";
                                           
                    }
                    else
                    {
                        objdbhims.Query = @"SELECT
                   case when t.heading='Y' then concat('<b><u>',t.`attribute_name`,'</u></b>') when trim(ifnull(t.range_text,''))='-' OR  trim(ifnull(t.range_text,''))='' then concat('<b>',t.`attribute_name`,'</b>') else concat('<b>',t.`attribute_name`,'</b>','<br />&nbsp;&nbsp;&nbsp;&nbsp;Ranges: ',ifnull(t.range_text,'')) end as 'ATTRIBUTE'," + _ObjectDate + @",ta.aunit as Unit,ifnull(concat('x',ta.Conversionfactor),'-') as 'Conv. Factor',round(convert(ifnull(t.result,0),signed integer)*ifnull(ta.Conversionfactor,0),6)   as 'SI Result',ta.asiunit as 'SI Unit'," + _AbnormalObject + @"
                    FROM `dc_tresultTemp` as t left outer join dc_tp_Aranges ta on ta.rangeid=t.rangeid WHERE t.testid='" + _TestId + "' AND t.prid='" + _prid + "' AND (t.result <> '-' or t.heading='Y') and t.print='Y' GROUP BY attribute_name order by t.dorder";
                     
                    }
                    //My Last Execution
//                   objdbhims.Query = @"SELECT t.`attribute_name` as Test,
//REPLACE(SUBSTR(t.range_text,INSTR(t.range_text,'('),INSTR(t.range_text,')')),'&nbsp;','-') as Normal,
//REPLACE(SUBSTR(t.range_text, instr(t.range_text ,')')+1),'&nbsp;','-') as Unit,
//" + _ObjectDate + @"FROM (SELECT * FROM dc_tresult WHERE testid='" + _TestId + "' AND prid='" + _prid + @"' UNION
//SELECT * from dc_tresultm_archive WHERE testid='" + _TestId + "' AND prid='" + _prid + "') t ";                                     
                   break;
                case 15:
                    // objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon  FROM `dc_tresult` as t WHERE testid='369' AND prid='788' GROUP BY t.enteredon";
                   if (OrganizationName != "SL")
                   {
                       /*TEsting without view*/
                       objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon , date_format(t.enteredon,'%b %d,%y - %H:%i') as headerName,t.result   FROM `dc_tresult` as t WHERE testid=" + _TestId + @" AND prid=" + _prid + @" GROUP BY t.enteredon
Union
SELECT date_format(t1.enteredon,'%Y-%m-%d %r') as enteredon , date_format(t1.enteredon,'%b %d,%y - %H:%i') as headerName,t1.result   FROM `dc_tresultm_archive` as t1 WHERE testid=" + _TestId + @" AND prid=" + _prid + @" GROUP BY t1.enteredon

order by enteredon DESC LIMIT 3";
                      // objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon , date_format(t.enteredon,'%b %d,%y - %H:%i') as headerName,t.result   FROM `dc_tresulttemp` as t WHERE testid='" + _TestId + "' AND prid='" + _prid + "' GROUP BY t.enteredon ORDER BY t.enteredon DESC LIMIT 3";

                   }
                   else
                   {
                       objdbhims.Query = @"SELECT date_format(t.enteredon,'%Y-%m-%d %r') as enteredon , date_format(t.enteredon,'%d-%m-%y') as headerName  FROM `dc_tresultTemp` as t WHERE testid='" + _TestId + "' AND prid='" + _prid + "' GROUP BY date_format(t.enteredon,'%d-%m-%Y') ORDER BY t.enteredon DESC LIMIT 2";
                        
                   }
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
                    t.`attribute_name` as Test," + _ObjectDate + @",ta.aunit as Unit,ta.Conversionfactor as 'Conversion Factor',convert(ifnull(t.result,0),signed integer)*ifnull(ta.Conversionfactor,0)   as 'Result in SI Unit',ta.asiunit as 'SI Unit'
                    FROM `dc_tresultTemp` as t inner join dc_tp_Aranges ta on ta.rangeid=t.rangeid WHERE t.testid='" + _TestId + "' AND t.prid='" + _prid + "' AND t.result <> '-' GROUP BY attribute_name";
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
                    objdbhims.Query = "SELECT REPLACE(r.description, '\r\n', '<br/>') as description ,t.Attribute_Name FROM  dc_tp_aranges r LEFT JOIN dc_tp_attributes t ON r.AttributeId = t.AttributeId WHERE t.testid = '" + _TestId + "' AND length(r.description) >= 10 ";
                    break;

                case 26://for cash invoice report master grid
//                    objdbhims.Query = @"
//                                    SELECT `dc_tp_branch`.name Branch,
//                                      date_format(`dc_tpatient_bookingm`.`enteredon`,'%d-%b-%Y') bookedon,
//                                      `dc_tpatient_bookingm`.`labid`,
//                                      `dc_tpatient`.`name` patientname,
//                                      `dc_tp_test`.`Test_Name`,
//                                      `dc_tpatient_bookingm`.`bookingid`,
//                                      `dc_tp_refdoctors`.`name` consultant,
//                                      `dc_tpanel`.`name` panel,
//                                      `dc_tpatient_bookingm`.`totalamount` charges,
//                                      IfNull(`dc_tpatient_bookingm`.`paidamount`,0) paidamount,
//                                      `dc_tpatient_bookingd`.`totalamount` totamount,
//                                      `dc_tpatient_bookingm`.`doctorid`,
//                                      `dc_tp_refdoctors`.`title`,
//                                      `dc_tpatient`.`title`,
//                                      `dc_tp_personnel`.`Salutation`,
//                                      `dc_tp_personnel`.`FName` enteredby,
//                                      `dc_tp_personnel`.`MName`,
//                                      `dc_tp_personnel`.`LName`,
//                                      `discountreception_sumary`.`discount` discount_amt,
//                                      `dc_tpatient_bookingm`.`panelid`,
//                                      `dc_tpatient_bookingd`.`clientid`,
//                                      (`dc_tpatient_bookingm`.`totalamount`-ifnull(`dc_tpatient_bookingm`.`paidamount`,0)-ifnull(`discountreception_sumary`.`discount`,0)) AS balance
//                                    FROM
//                                      {oj(
//                                        (
//                                          (
//                                            `dc_tp_personnel` `dc_tp_personnel` INNER JOIN (
//                                              `discountreception_sumary` `discountreception_sumary` INNER
//                                              JOIN (
//                                                (
//                                                  `dc_tpatient_bookingd`
//                                                  `dc_tpatient_bookingd` INNER JOIN `dc_tpatient_bookingm`
//                                                  `dc_tpatient_bookingm` ON `dc_tpatient_bookingd`.`bookingid`
//                                                  = `dc_tpatient_bookingm`.`bookingid`
//                                                ) INNER JOIN `dc_tp_test` `dc_tp_test` ON
//                                                `dc_tpatient_bookingd`.`testid` = `dc_tp_test`.`TestId`
//                                              ) ON (
//                                                `discountreception_sumary`.`bookingid` =
//                                                `dc_tpatient_bookingm`.`bookingid`
//                                              )
//                                              AND (
//                                                    `discountreception_sumary`.`prid` =
//                                                    `dc_tpatient_bookingm`.`prid`
//                                                  )
//                                            ) ON `dc_tp_personnel`.`PersonId` = `dc_tpatient_bookingm`.`enteredby`
//                                          ) INNER JOIN `dc_tpatient` `dc_tpatient` ON
//                                          `dc_tpatient_bookingm`.`prid` = `dc_tpatient`.`prid`
//                                        ) LEFT OUTER JOIN `dc_tp_refdoctors` `dc_tp_refdoctors` ON
//                                        `dc_tpatient_bookingm`.`doctorid` = `dc_tp_refdoctors`.`doctorid`
//                                      )
//                                      LEFT OUTER JOIN dc_tpanel `dc_tpanel`
//                                        ON   `dc_tpatient_bookingm`.`panelid` = `dc_tpanel`.`panelid` }
//LEFT OUTER JOIN dc_tp_branch `dc_tp_branch`
//                                        ON   `dc_tpatient_bookingm`.`branchid` = `dc_tp_branch`.`branchid`
//                                    WHERE 
//                                      
//                                      `dc_tpatient_bookingm`.`enteredon` BETWEEN str_to_date('" + _Datefrom + @"','%d/%m/%Y')
//                                      AND STR_TO_DATE('" + _Dateto + @"','%d/%m/%Y')";
//                    if (!_ConsultantID.Equals(Default) && !_ConsultantID.Equals(""))
//                    {
//                        objdbhims.Query += @" and `dc_tp_refdoctors`.Doctorid=" + _ConsultantID;
//                    }
//                    if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
//                    {
//                        objdbhims.Query += " and `dc_tpatient_bookingm`.PanelID=" + _PanelID;
//                    }
//                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
//                    {
//                        objdbhims.Query += " and `dc_tpatient_bookingm`.branchid=" + _BranchID;
//                    }
//                    if (!_Type.Equals(Default) && !_Type.Equals(""))
//                    {
//                        objdbhims.Query += " and `dc_tpatient_bookingm`.type='" + _Type+"'";
//                    }

//                    objdbhims.Query += @" GROUP BY dc_tpatient_bookingm.bookingid
//                                      ORDER BY
//                                      `dc_tpatient_bookingm`.`branchid`,
//                                      `dc_tpatient_bookingd`.`clientid`,
//`dc_tpatient_bookingm`.`payment_mode`,
//                                      `dc_tpatient_bookingm`.`bookingid`";

                    ///////////////////For Local Execution////////////////////////////////////////
                     objdbhims.Query = @"
                                    
SELECT dc_tp_branch .name Branch,
       date_format(dc_tpatient_bookingm . enteredon, '%d-%b-%Y') bookedon,
       dc_tpatient_bookingm . labid,
       dc_tpatient . name patientname,
       dc_tp_test . Test_Name,
       dc_tpatient_bookingm . bookingid,
       dc_tp_refdoctors . name consultant,
       dc_tpanel . name panel,
       ifnull(dc_tpanel . CashPanel, 'N') as panelcash,
       dc_tpatient_bookingm . totalamount charges,

       IfNull((select sum(paidamount)
                from dc_tcashcollection
               where bookingid = dc_tpatient_bookingm .
               bookingid and date_format(enteredon,'%d/%m/%y')=date_format(dc_tpatient_bookingm .enteredon,'%d/%m/%y')
                 ),
              0) paidamount,

       dc_tpatient_bookingd . totalamount totamount,
       dc_tpatient_bookingm . doctorid,
       dc_tp_refdoctors . title,
       dc_tpatient . title,
       dc_tp_personnel . Salutation,
       dc_tp_personnel . FName enteredby,
       dc_tp_personnel . MName,
       dc_tp_personnel . LName,
       discountreception_sumary . discount discount_amt,
       ifnull(dc_tpatient_bookingm . panelid, 0) as panelid,
       dc_tpatient_bookingd . clientid,
       (dc_tpatient_bookingm .
        totalamount -
        IfNull((select sum(paidamount)
                 from dc_tcashcollection
                where bookingid = dc_tpatient_bookingm .
                bookingid and date_format(enteredon,'%d/%m/%y')=date_format(dc_tpatient_bookingm .enteredon,'%d/%m/%y')),
               0) - ifnull(discountreception_sumary . discount, 0)) AS balance
  FROM {oj(((dc_tp_personnel dc_tp_personnel INNER
            JOIN(discountreception_sumary discountreception_sumary INNER
                  JOIN((dc_tpatient_bookingd dc_tpatient_bookingd INNER JOIN
                        dc_tpatient_bookingm dc_tpatient_bookingm ON
                        dc_tpatient_bookingd .
                        bookingid = dc_tpatient_bookingm . bookingid) INNER JOIN
                       dc_tp_test dc_tp_test ON dc_tpatient_bookingd .
                       testid = dc_tp_test . TestId)
                  ON(discountreception_sumary .
                     bookingid = dc_tpatient_bookingm . bookingid) AND
                  (discountreception_sumary . prid = dc_tpatient_bookingm . prid)) ON
            dc_tp_personnel . PersonId = dc_tpatient_bookingm . enteredby)
            INNER JOIN dc_tpatient dc_tpatient ON dc_tpatient_bookingm .
            prid = dc_tpatient . prid) LEFT OUTER JOIN dc_tp_refdoctors
           dc_tp_refdoctors ON dc_tpatient_bookingm .
           doctorid = dc_tp_refdoctors . doctorid)
  LEFT OUTER JOIN dc_tpanel dc_tpanel ON dc_tpatient_bookingm .
 panelid = dc_tpanel . panelid }
  LEFT OUTER JOIN dc_tp_branch dc_tp_branch ON dc_tpatient_bookingm .
 branchid = dc_tp_branch .
 branchid

                                    WHERE 
                                      
                                      `dc_tpatient_bookingm`.`enteredon` BETWEEN str_to_date('" + _Datefrom + @"','%d/%m/%Y')
                                      AND STR_TO_DATE('" + _Dateto + @"','%d/%m/%Y')";
                     //  IfNull(`dc_tpatient_bookingm`.`paidamount`,0) paidamount,

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
                    if (!_Type.Equals(Default) && !_Type.Equals(""))
                    {
                        objdbhims.Query += " and `dc_tpatient_bookingm`.type='" + _Type+"'";
                    }

                    objdbhims.Query += @" GROUP BY dc_tpatient_bookingm.bookingid
                                      ORDER BY
                                      `dc_tpatient_bookingm`.`branchid`,
                                      `dc_tpatient_bookingd`.`clientid`,
`dc_tpatient_bookingm`.`payment_mode`,
                                      `dc_tpatient_bookingm`.`bookingid`,dc_tpatient_bookingm.enteredon";
                    ///////////////////////--------/////////////////////////////////////////////////


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
                                          date_format(r.enteredon,'%d-%b-%Y') enteredon,
                                          m.clientid,m.panelid
                                        FROM
                                          dc_tpatient_bookingm m
                                          JOIN dc_Tcashrefund r
                                            ON   m.bookingid = r.bookingid
                                          LEFT OUTER JOIN dc_tp_test t
                                            ON   t.testid = r.testid
                                          JOIN dc_tpatient p
                                            ON   p.prid = m.prid
                                        WHERE m.enteredon<>r.enteredon
                                        AND r.enteredon BETWEEN str_to_date('" + _Datefrom + @"','%d/%m/%Y') AND str_to_date('" + _Dateto + @"','%d/%m/%Y')";
                    if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
                    {
                        objdbhims.Query += " and m.PanelID=" + _PanelID;
                    }
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and m.branchid=" + _BranchID;
                    }
                    if (!_Type.Equals(Default) && !_Type.Equals(""))
                    {
                        objdbhims.Query += " and m.type='" + _Type+"'";
                    }
                    objdbhims.Query += @" GROUP BY m.bookingid";
                    break;
                case 28://Cash Summary Report(Refund/Cancellations Detail)
                    objdbhims.Query = @"SELECT ifnull(m.panelid,'0') as panelid, case when r.refundtype='C' then 'Cancel' when r.refundtype='D' then 'Discount' when r.refundtype='K' then 'BCL Staff' when r.refundtype='R' then 'Poor Patient' when r.refundtype='W' then 'Wrong Entry' else 'Not Defined' end as refundType ,
                                        CASE
                                            WHEN m.panelid IS NOT NULL AND m.payment_mode = 'A' AND (r.refundtype = 'C' OR r.refundtype = 'W') THEN
                                                    r.totalamount
                                            ELSE r.paidamount
                                            END  AS paidamount,t.test_name,ifnull(pn.CashPanel,'N') as PanelCash
                                        FROM dc_tpatient_bookingm m
                                            JOIN dc_Tcashrefund r
                                            ON   m.bookingid = r.bookingid
                                            LEFT OUTER JOIN dc_tp_test t
                                            ON   t.testid = r.testid
                                            JOIN dc_tpatient p
                                            ON   p.prid = m.prid
                                            left outer join dc_tpanel pn on pn.panelid=m.panelid
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
                case 31:
                    objdbhims.Query = @"select br.Name as branch,m.branchid,sum(m.totalamount) totalamount,sum(m.discount_amt) as discamount,
                                        sum(m.refund_amt) as refundamount ,sum(m.paidamount) paidamount,sum(balance) as balance,
                                        (select Round((sum((ifnull(d.totalamount,0)*ifnull(b.percentagediscount,0))/100))/10)*10 as net

                                        From dc_tpatient_bookingd d,dc_tp_branchtestd b,dc_tpatient_bookingm m1
                                        where b.branchid=m1.branchid
                                        and d.testid=b.testid
                                        and d.bookingid=m1.bookingid
                                        and m1.branchid=m.branchid
                                        and b.Active='Y' and d.status!='X' and m1.Payment_mode='"+_Payment_mode+@"'  and date_format(m1.enteredon,'%Y/%m/%d') between '"+_Datefrom+@"' and '"+_Dateto+@"'";
                     if(!_BranchID.Equals(Default ) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query+=" and m1.Branchid="+Convert.ToInt16(_BranchID);
                    }                                                                           
                      objdbhims.Query+=@" ) as branchshare
                                        from dc_tpatient_bookingm m
                                        inner join dc_tp_branch br on br.branchid=m.branchid
                                        where  m.Branchid is not null
                                        and m.payment_mode='"+_Payment_mode+@"'
                                        and date_format(m.enteredon,'%Y/%m/%d')
                                        between '"+_Datefrom+"' and '"+_Dateto+@"'";
                    if(!_BranchID.Equals(Default ) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query+=" and m.Branchid="+Convert.ToInt16(_BranchID);
                    }
                   objdbhims.Query+=@" group by m.branchid";
                    break;

                case 32:
                    this.objdbhims.Query = "Select b.name as branch,r.totalamount,r.paidamount,t.test_name,m.labid,pp.name,Round((ifnull(r.paidamount,0)*ifnull(bt.percentagediscount,0)/100)) as branchshare,date_format(m.enteredon,'%d/%m/%Y') as bookingdate,date_format(r.enteredon,'%d/%m/%Y') as RefundDate,p.fname as Refundedby From dc_tcashrefund r inner join dc_tpatient_bookingm m on m.bookingid=r.bookingid inner join dc_tp_branch b on b.branchid=m.branchid inner join dc_tp_branchtestd bt on bt.branchid=b.branchid and bt.testid=r.testid Inner join dc_tp_test t on t.testid=r.testid inner join dc_tp_personnel p on p.personid=r.enteredby inner join dc_tpatient pp on pp.prid=m.prid where date_format(m.enteredon,'%Y/%m/%d') not between '" + this._Datefrom + "' and '" + this._Dateto + "' and date_format(r.enteredon,'%Y/%m/%d')  between '" + this._Datefrom + "' and '" + this._Dateto + "' and bt.Active='Y'";
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and m.branchid=" + Convert.ToInt16(_BranchID);
                    }
                    break;
                case 33:
                    this.objdbhims.Query = "select  sum(ifnull(balance,0)) as totalbalance from dC_tpatient_bookingm\r\nwhere enteredon between date_sub(sysdate(),interval 30 day) and sysdaTE()";
                    break;
                case 34:
                    this.objdbhims.Query = "select  sum(ifnull(balance,0)) as totalbalance from dC_tpatient_bookingm\r\nwhere enteredon between date_sub(sysdate(),interval 60 day) and sysdaTE()";
                    break;
                case 35:
                    this.objdbhims.Query = "select  sum(ifnull(balance,0)) as totalbalance from dC_tpatient_bookingm\r\nwhere enteredon between date_sub(sysdate(),interval 90 day) and sysdaTE()";
                    break;
                case 36:
                    objdbhims.Query = @"select br.Name as branch,m.branchid,sum(m.totalamount) totalamount,
                                        (select Round((sum((ifnull(d.totalamount,0)*ifnull(b.percentagediscount,0))/100))/10)*10 as net
                                        From dc_tpatient_bookingd d,dc_tp_branchtestd b,dc_tpatient_bookingm m1
                                        where b.branchid=m1.branchid
                                        and d.testid=b.testid
                                        and d.bookingid=m1.bookingid
                                        and m1.branchid=m.branchid
                                        and b.Active='Y' and m1.Payment_mode='A' and d.status!='X'  and date_format(m1.enteredon,'%Y/%m/%d') between '"+_Datefrom+"' and '"+_Dateto+@"'";
                   if(!_BranchID.Equals(Default) && !_BranchID.Equals(""))                                                                                                                                     if(!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                   {
                       objdbhims.Query+=@" and m1.BranchID="+Convert.ToInt16(_BranchID);
                   }
                   objdbhims.Query+=@" ) as branchshare,
                                            (Select sum(t.charges-ifnull(d.totalamount,0))
                                            from dc_tpatient_bookingd d,dc_tp_test t,dc_tpatient_bookingm m2
                                            where d.testid=t.testid
                                            and d.bookingid=m2.bookingid
                                            and m2.branchid=m.branchid
                                            AND d.status!='X' and m2.payment_mode='A' and date_format(m2.enteredon,'%Y/%m/%d') between '"+_Datefrom+"' and '"+_Dateto+@"'";
                   if(!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                   {
                       objdbhims.Query+=@" and m2.BranchID="+Convert.ToInt16(_BranchID);
                   }                                                                                                                     
                   objdbhims.Query+=@" ) as tradediscount

                                        from dc_tpatient_bookingm m inner join dc_tp_branch br on br.branchid=m.branchid
                                        where  m.Branchid is not null and m.payment_mode='A'  and date_format(m.enteredon,'%Y/%m/%d') between '"+_Datefrom+"' and '"+_Dateto+@"'";
                   if(!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                   {
                       objdbhims.Query+=@" and m.BranchID="+Convert.ToInt16(_BranchID);
                   }                                                                                                      
                   objdbhims.Query+=@" group by m.branchid";
                    //this.objdbhims.Query = "select br.Name as branch,m.branchid,sum(m.totalamount) totalamount,\r\n                                        (select Round((sum((ifnull(d.totalamount,0)*ifnull(b.percentagediscount,0))/100))/10)*10 as net\r\n                                        From dc_tpatient_bookingd d,dc_tp_branchtestd b,dc_tpatient_bookingm m1\r\n                                        where b.branchid=m1.branchid\r\n                                        and d.testid=b.testid\r\n                                        and d.bookingid=m1.bookingid\r\n                                        and m1.branchid=m.branchid\r\n                                        and b.Active='Y' and m1.Payment_mode='A' and d.status!='X' ";
                    //if (!this._Datefrom.Equals("~!@") && !this.Datefrom.Equals(""))
                    //{
                    //    clsdbhims clsdbhims2 = this.objdbhims;
                    //    string str2 = clsdbhims2.Query + " and date_format(m1.enteredon,'%Y/%m/%d') between '" + this._Datefrom + "' and '" + this._Dateto + "'";
                    //    clsdbhims2.Query = str2;
                    //}
                    //clsdbhims clsdbhims9 = this.objdbhims;
                    //string str9 = clsdbhims9.Query + ") as branchshare,\r\n                                            (Select sum(t.charges-d.totalamount)\r\n                                            from dc_tpatient_bookingd d,dc_tp_test t,dc_tpatient_bookingm m2\r\n                                            where d.testid=t.testid\r\n                                            and d.bookingid=m2.bookingid\r\n                                            and m2.branchid=m.branchid\r\n                                            AND d.status!='X' and m2.payment_mode='A'";
                    //clsdbhims9.Query = str9;
                    //if (!this._Datefrom.Equals("~!@") && !this.Datefrom.Equals(""))
                    //{
                    //    clsdbhims clsdbhims2 = this.objdbhims;
                    //    string str2 = clsdbhims2.Query + " and date_format(m2.enteredon,'%Y/%m/%d') between '" + this._Datefrom + "' and '" + this._Dateto + "'";
                    //    clsdbhims2.Query = str2;
                    //}
                    //clsdbhims clsdbhims10 = this.objdbhims;
                    //string str10 = clsdbhims10.Query + ") as tradediscount\r\n\r\n                                        from dc_tpatient_bookingm m inner join dc_tp_branch br on br.branchid=m.branchid \r\n                                        where  m.Branchid is not null and m.payment_mode='A' ";
                    //clsdbhims10.Query = str10;
                    //if (!this._BranchID.Equals("~!@") && !this._BranchID.Equals(""))
                    //{
                    //    clsdbhims clsdbhims2 = this.objdbhims;
                    //    string str2 = clsdbhims2.Query + " and m.branchid=" + this._BranchID;
                    //    clsdbhims2.Query = str2;
                    //}
                    //if (!this._Datefrom.Equals("~!@") && !this.Datefrom.Equals(""))
                    //{
                    //    clsdbhims clsdbhims2 = this.objdbhims;
                    //    string str2 = clsdbhims2.Query + " and date_format(m.enteredon,'%Y/%m/%d') between '" + this._Datefrom + "' and '" + this._Dateto + "'";
                    //    clsdbhims2.Query = str2;
                    //}
                    //clsdbhims clsdbhims11 = this.objdbhims;
                    //string str11 = clsdbhims11.Query + " group by m.branchid";
                    //objdbhims.Query = str11;
                    break;
                case 37:// USed at panel services summary report panelservices(outstandingdues).aspx
                #region "old query"
                //                    objdbhims.Query = @"select sum(d.totalamount) as rate,pn.panelid,Replace(pn.name,'&amp;','&') as panelname,ifnull(pn.CashPanel,'N') as PanelCash,
//(select ifnull(sum(c.Paidamount),0) from dc_tcashcollection c where c.bookingid=m.bookingid) as Paidamount,
//(select ifnull(sum(c.Paidamount),0) from dc_tcashrefund c where c.bookingid=m.bookingid and refundtype='D') as Discountamt,
//(select ifnull(sum(c.Paidamount),0) from dc_tcashrefund c where c.bookingid=m.bookingid and refundtype!='D') as Refund
//from dc_tpatient p
// join dc_tpatient_bookingm m
// join dc_tpatient_bookingd d
// join dc_tpanel pn
//
//where m.prid=p.prid and m.bookingid = d.bookingid and m.panelid=pn.panelid
//and  m.enteredon between str_to_Date('"+Datefrom+"','%d/%m/%Y') and str_to_date('"+Dateto+@"','%d/%m/%Y')"; 
//                    if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
//                    {
//                        objdbhims.Query += " and m.PanelID=" + _PanelID;
//                    }
//                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
//                    {
//                        objdbhims.Query += " and m.branchid=" + _BranchID;
//                    }                          
                                                         
//                    objdbhims.Query+=@" group by pn.panelid,pn.Name,pn.CashPanel";
                //                    break;
                #endregion
                    objdbhims.Query = @"select (sum(d.totalamount)-(select ifnull(sum(r.totalamount),0) from dc_tcashrefund r left outer join dc_tpatient_bookingm m on m.bookingid =r.bookingid where r.refundtype='C'  and m.panelid = pn.panelid
           and m.enteredon >= str_to_date('" + Datefrom + @"', '%d/%m/%Y')
              
           and r.enteredon between str_to_Date('" + Datefrom + @"', '%d/%m/%Y') and
               str_to_date('" + Dateto + @"', '%d/%m/%Y')
           and m.branchid = 4  )) as rate,
                                                   pn.panelid,
                                                   Replace(pn.name, '&amp;', '&') as panelname,
                                                   ifnull(pn.CashPanel, 'N') as PanelCash,
                                                   (select ifnull(sum(c.Paidamount), 0)
                                                      from dc_tcashcollection c, dc_tpatient_bookingm m
                                                     where c.bookingid = m.bookingid
                                                       and m.panelid = pn.panelid
                                            and m.enteredon>=str_to_date('" +Datefrom+@"','%d/%m/%Y')
           
                                                    and  c.enteredon between str_to_Date('" +Datefrom+"','%d/%m/%Y') and str_to_date('"+Dateto+@"','%d/%m/%Y')";

                                                     
                                                     if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                                                      {
                                                            objdbhims.Query += " and m.branchid=" + _BranchID;
                                                        } 
                                                      objdbhims.Query += @") as PaidamountTB,
                                                                        (select ifnull(sum(c.Paidamount), 0)
                                                                          from dc_tcashcollection c, dc_tpatient_bookingm m
                                                                         where c.bookingid = m.bookingid
                                                                           and m.panelid = pn.panelid
                                                                and m.enteredon<str_to_date('" +Datefrom+@"','%d/%m/%Y')
                                                                                            and  c.enteredon between str_to_Date('" +Datefrom+"','%d/%m/%Y') and str_to_date('"+Dateto+@"','%d/%m/%Y')";

                                                     
                                                     if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                                                      {
                                                            objdbhims.Query += " and m.branchid=" + _BranchID;
                                                        } objdbhims.Query += @" ) as PaidamountPB,

                                                           (select ifnull(sum(c.Paidamount), 0)
                                                              from dc_tcashrefund c,dc_tpatient_bookingm m
                                                             where c.bookingid = m.bookingid
                                                            and m.panelid=pn.panelid
                                                               and refundtype = 'D'
                                                    and  m.enteredon between str_to_Date('" + Datefrom+"','%d/%m/%Y') and str_to_date('"+Dateto+@"','%d/%m/%Y')";

                                                    
                                                     if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                                                      {
                                                            objdbhims.Query += " and m.branchid=" + _BranchID;
                                                        } 
                                                      objdbhims.Query += @") as Discountamt,
                                                           (select ifnull(sum(c.Paidamount), 0)
                                                              from dc_tcashrefund c,dc_tpatient_bookingm m
                                                             where c.bookingid = m.bookingid
                                                            and m.panelid=pn.panelid
                                                               and refundtype != 'D'
                                                     and  m.enteredon between str_to_Date('" + Datefrom+"','%d/%m/%Y') and str_to_date('"+Dateto+@"','%d/%m/%Y')";

                                                     
                                                     if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                                                      {
                                                            objdbhims.Query += " and m.branchid=" + _BranchID;
                                                        } 
                                                      objdbhims.Query +=@") as Refund
                                                      from dc_tpatient p
                                                      join dc_tpatient_bookingm m
                                                      join dc_tpatient_bookingd d
                                                      join dc_tpanel pn

                                                     where m.prid = p.prid
                                                       and m.bookingid = d.bookingid
                                                       and m.panelid = pn.panelid
                                                       and  m.enteredon between str_to_Date('"+Datefrom+"','%d/%m/%Y') and str_to_date('"+Dateto+@"','%d/%m/%Y')"; 
                                                     if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
                                                      {
                                                            objdbhims.Query += " and m.PanelID=" + _PanelID;
                                                      }
                                                     if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                                                      {
                                                            objdbhims.Query += " and m.branchid=" + _BranchID;
                                                        }                          
                                                         
                                                        objdbhims.Query+=@" group by pn.panelid,pn.Name,pn.CashPanel";
                    break;
                case 38://Panel Ledger Report at rptPanelledger.aspx
                    // old query
                    //"Select date_format(m.enteredon,'%d %b %Y %r') enteredon, p.name patientname,concat(ifnull(pr.fname,''),' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as EnteredBY, m.bookingid,p.prid,concat(m.labid,'<br />',ifnull(m.referenceno,'')) as labid,m.enteredon,m.totalamount,ifnull(m.paidamount,0) paidamount,ifnull(m.balance,0) balance ,ifnull(m.discount_amt,0) discount_amt,m.payment_mode,m.panelid,t.test_name testname,d.totalamount as testcharges,(100-ifnull(pt.panelsharepercent,0))*d.totalamount/100 as LabShare
                    //                    from dc_tpatient p  inner join dc_tpatient_bookingm m on m.prid=p.prid
                    //                    inner join dc_tpatient_bookingd d on d.bookingid=m.bookingid
                    //                    inner  join dc_tpanel pn on pn.panelid=m.panelid
                    //                    inner join dc_tp_personnel pr on pr.personid=m.EnteredBy 
                    //                    inner join dc_tp_Test t on t.testid=d.testid
                    //                    inner join dc_tpanel_test pt on pt.testid=d.testid and pt.panelid=m.panelid
                    //                    left outer join dc_tp_refdoctors re on re.doctorid=m.doctorid

                                        //where d.status<>'X'
                    objdbhims.Query = @"Select date_format(m.enteredon,'%d %b %Y %r') enteredon, p.name patientname,concat(ifnull(pr.fname,''),' ',ifnull(pr.mname,''),' ',ifnull(pr.lname,'')) as EnteredBY,
m.bookingid,p.prid,concat(m.labid,'<br />',ifnull(m.referenceno,'')) as labid,m.enteredon,
(m.totalamount - (select ifnull(sum(totalamount),0) from dc_tcashrefund where bookingid=m.bookingid and refundtype='C')) as totalamount,ifnull(m.paidamount,0) paidamount,ifnull(m.balance,0) balance ,ifnull(m.discount_amt,0) discount_amt,m.payment_mode,m.panelid,t.test_name testname,d.totalamount as testcharges,(100-ifnull(pt.panelsharepercent,0))*d.totalamount/100 as LabShare
                                        from dc_tpatient p  inner join dc_tpatient_bookingm m on m.prid=p.prid
                                        inner join dc_tpatient_bookingd d on d.bookingid=m.bookingid
                                        inner  join dc_tpanel pn on pn.panelid=m.panelid
                                        inner join dc_tp_personnel pr on pr.personid=m.EnteredBy 
                                        inner join dc_tp_Test t on t.testid=d.testid
                                        inner join dc_tpanel_test pt on pt.testid=d.testid and pt.panelid=m.panelid
                                        left outer join dc_tp_refdoctors re on re.doctorid=m.doctorid

                                        where d.status<>'X' and m.enteredon between str_to_Date('" + _Datefrom + "','%d/%m/%Y') and str_to_date('" + _Dateto + "','%d/%m/%Y')"; 
                    if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
                    {
                        objdbhims.Query += " and m.PanelID=" + _PanelID;
                    }
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and m.branchid=" + _BranchID;
                    }
                    objdbhims.Query += @" and case when m.groupid is null then pt.groupid is null else pt.groupid=m.groupid end  order by m.bookingid asc";
                    break;
                case 39:// Due balance Summary at rptbal_discsummary.aspx
                    objdbhims.Query = @"Select p.prno,b.Name as BranchName,m.branchid,m.enteredon,p.name patientName,m.labid,m.totalamount,m.paidamount,m.discount_amt,m.balance,concat(per.salutation,per.fname,' ',per.Mname,' ',per.LName) as EnteredBy
                                        From dc_tpatient_bookingm m inner join dc_tpatient p on p.prid=m.prid
                                        Inner join dc_tp_personnel per On per.personid=m.enteredby
                                        Inner join dc_tp_branch b on b.Branchid=m.branchid
                                        where m.panelid is null and balance<>0 and m.enteredon between str_to_Date('" + _Datefrom + "','%d/%m/%Y') and str_to_date('" + _Dateto + "','%d/%m/%Y')";
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and m.branchid=" + _BranchID;
                    }
                    objdbhims.Query += @" order by m.branchid";
                    break;
                case 40://Reporting Preferences
                    objdbhims.Query = @"Select * from dc_tp_reportpreferences where Active='Y' and OrgID='" + _ClientId + "'";// and ReportTypeID=" + Reporttype;
                    if (Reporttype!=null && Reporttype!="")
                    {
                        objdbhims.Query += " and ReportTypeID=" + Convert.ToInt16(Reporttype);
                    }
                    break;
                case 41://Balance Received against Previous Bookings used on(Report/rpt_Cash_Invoice.aspx)
                    objdbhims.Query = @"select m.bookingid,p.Name patientName, date_format(c.enteredon,'%d-%M-%y') as enteredon,date_format(m.enteredon,'%d-%M-%y') bookedon,m.labid,c.totalamount charges,c.paidamount,
ifnull(pn.Name,'') as Panel,ifnull(concat(ref.title,'. ',ref.name),m.referredby) as COnsultant,concat(per.salutation,per.fname,' ',per.Mname,' ',per.LName) as EnteredBy,ifnull(pn.CashPanel,'N') as Panelcash

from dc_tcashcollection c inner join dc_tpatient_bookingm m on c.bookingid=m.bookingid 
inner join dc_tpatient p on p.prid=m.prid
inner join dc_tp_personnel per on per.personid=c.enteredby
left outer join dc_tpanel pn on pn.panelid=m.panelid
left outer join dc_tp_refdoctors ref on ref.doctorid=m.doctorid

where c.enteredon between str_to_Date('" + _Datefrom + "','%d/%m/%Y') and str_to_date('" + _Dateto + @"','%d/%m/%Y')
 and date_format(m.enteredon,'%d/%m/%y')<>date_format(c.enteredon,'%d/%m/%y')
   ";
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and m.branchid=" + _BranchID;
                    }
                    if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
                    {
                        objdbhims.Query += " and m.PanelID=" + _PanelID;
                    }
                    if (!_ConsultantID.Equals(Default) && !_ConsultantID.Equals(""))
                    {
                        objdbhims.Query += @" and ref.Doctorid=" + _ConsultantID;
                    }
                    if (!_Type.Equals(Default) && !_Type.Equals(""))
                    {
                        objdbhims.Query += " and m.type='" + _Type + "'";
                    }
                    break;
                case 42:
                    objdbhims.Query = "SELECT distinct d.DRUG FROM dc_tmicro_senstivity as s LEFT JOIN  dc_tp_organism as o ON s.OrganismID = o.OrganismID LEFT JOIN dc_tp_drug as d ON s.DRUGID = d.DRUGID WHERE s.`bookingdid` = '" + _bookingdid + "'";
                    break;
                case 43:
                    objdbhims.Query = "SELECT s.Senstivity FROM dc_tmicro_senstivity as s LEFT JOIN  dc_tp_organism as o ON s.OrganismID = o.OrganismID LEFT JOIN dc_tp_drug as d ON s.DRUGID = d.DRUGID WHERE s.`bookingdid` = '" + _bookingdid + "' and o.OrganismID='" + Organism + "'";
                    break;
                case 44:
                    objdbhims.Query  = "SELECT s.Senstivity FROM dc_tmicro_senstivity as s LEFT JOIN  dc_tp_organism as o ON s.OrganismID = o.OrganismID LEFT JOIN dc_tp_drug as d ON s.DRUGID = d.DRUGID WHERE s.`bookingdid` = '" + _bookingdid + "' and o.Organism='" + Organism + "' and d.Drug ='" + Drug + "'";
                    break;
                case 45:
                    objdbhims.Query  = "SELECT distinct s.OrganismID,o.Organism FROM dc_tmicro_senstivity as s LEFT JOIN  dc_tp_organism as o ON s.OrganismID = o.OrganismID LEFT JOIN dc_tp_drug as d ON s.DRUGID = d.DRUGID WHERE s.`bookingdid` = '" + _bookingdid + "'";
                    break;
                case 46:
                    objdbhims.Query = @"Select m.bookingid,Convert(m.enteredon,date) as entereddate,p.prid,p.cliq_dependent_id,'' as relation,p.name as patientname,m.labid,tp.PanelTestCode as Testcode,tp.testid,t.test_name,d.totalamount as charges ,m.totalamount,
ifnull(m.paidamount,0) paidamount,ifnull(m.balance,0) balance ,ifnull(m.discount_amt,0) discount_amt,m.payment_mode,
m.panelid, ' ' as Dependentid,' ' as EmployeeID,' ' as Referalcode,' ' as RefNonSNo
from dc_tpatient p  inner join dc_tpatient_bookingm m on m.prid=p.prid
                                        inner join dc_tpatient_bookingd d on d.bookingid=m.bookingid
                                        inner  join dc_tpanel pn on pn.panelid=m.panelid
                                        left outer join dc_tp_refdoctors re on re.doctorid=m.doctorid
                                        inner join dc_tp_test t on d.testid=t.testid
inner join dc_tpanel_test tp on tp.testid=d.testid
and tp.panelid=m.panelid

                      where d.status<>'X' and m.enteredon between str_to_Date('" + _Datefrom + "','%d/%m/%Y') and str_to_date('" + _Dateto + "','%d/%m/%Y')";
                    if (!_PanelID.Equals(Default) && !_PanelID.Equals(""))
                    {
                        objdbhims.Query += " and m.PanelID=" + _PanelID;
                    }
                    if (!_BranchID.Equals(Default) && !_BranchID.Equals(""))
                    {
                        objdbhims.Query += " and m.branchid=" + _BranchID;
                    }
                    break;

            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }


        public bool Delete_RecordResultView()
        {
            objTrans.Start_Transaction();
           // objdbhims.Query = "DELETE FROM dc_tresult_view";
            objdbhims.Query = " DROP VIEW IF EXISTS dc_tresulttemp";
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

