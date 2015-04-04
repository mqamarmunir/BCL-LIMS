using System;
using System.Data;
using System.Data.OleDb;
using DataLayer;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTestProcess.
	/// </summary>
	public class clsBLOrganism
	{
		public clsBLOrganism()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "dc_tp_Organism";
    private const string TableName1 = "dc_tDrugOrganism";
		private string StrErrorMessage = "";
		private string StrOrganismID = Default;
		private string StrOrganism = Default;		
		private string StrAcronym = Default;		
		private string StrActive = Default;		
		private string StrDescription = Default;
    private string StrEnteredBy= Default;
    private string StrEnteredOn= Default;
    private string StrClientID = Default;

    private string StrDrugID = Default;
    private string StrType = "O";
		#endregion

		#region "Properties"
		
		public string OrganismID
		{
		get{	return StrOrganismID;	}
		set{	StrOrganismID = value;	}
		}
		
		public string Organism
		{
			get{	return StrOrganism;	}
			set{	StrOrganism = value;	}
		}
		
		public string Acronym
		{
			get{	return StrAcronym;	}
			set{	StrAcronym = value;	}
		}
		
		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}
		
		public string Description
		{
			get{	return StrDescription;	}
			set{	StrDescription = value;	}
		}

    public string EnteredBy
    {
      get
      {
        return StrEnteredBy;
      }
      set
      {
        StrEnteredBy = value;
      }
    }

    public string EnteredOn
    {
      get
      {
        return StrEnteredOn;
      }
      set
      {
        StrEnteredOn = value;
      }
    }

    public string ClientID
    {
      get
      {
        return StrClientID;
      }
      set
      {
        StrClientID = value;
      }
    }
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}

		#endregion
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public bool Insert(string OrganismList)
		{
      string[] OrgList = OrganismList.Split(',');

      if (Validate_Form())
      {
        QueryBuilder ObjQB = new QueryBuilder();
        clsBLDrugOrganism objDrugOrgan = new clsBLDrugOrganism();

        objTrans.Start_Transaction();

        objdbhims.Query = ObjQB.QBInsert(MakeArray(), TableName);
        StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

        if (StrErrorMessage.Equals("True"))
        {
          StrErrorMessage = objTrans.OperationError;
          objTrans.End_Transaction();
          return false;
        }
        else
        {
          StrOrganismID = objDrugOrgan.GetAll(1).Table.Rows[0][0].ToString();
        
          for (int i = 0; i <= OrgList.GetUpperBound(0); i++)
          {
            if (!OrgList[i].Trim().Equals(""))
            {
              StrDrugID = OrgList[i];

              objdbhims.Query = ObjQB.QBInsert(MakeArrayDrugOrganism(), TableName1);
              StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

              if (StrErrorMessage.Equals("True"))
              {
                StrErrorMessage = objTrans.OperationError;
                objTrans.End_Transaction();
                return false;
              }
            }
          }

          objTrans.End_Transaction();
          return true;
        }
      }
      else
      {
        return false;
      }
		}

    public bool Update(string OrganismList)
		{
      if (Validate_Form())
      {
        QueryBuilder ObjQB = new QueryBuilder();
        clsBLDrugOrganism objDrugOrgan = new clsBLDrugOrganism();
        string[] OrgList = OrganismList.Split(',');

        objTrans.Start_Transaction();

        objdbhims.Query = ObjQB.QBUpdate(MakeArray(), TableName);
        StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

        if (StrErrorMessage.Equals("True"))
        {
          StrErrorMessage = objTrans.OperationError;
          objTrans.End_Transaction();
          return false;
        }
        else
        {
          objDrugOrgan.OrganismID = StrOrganismID;
          objDrugOrgan.Type = "O";

          objDrugOrgan.DeleteWithOrganism();

          for (int i = 0; i <= OrgList.GetUpperBound(0); i++)
          {
            if (!OrgList[i].Trim().Equals(""))
            {
              StrDrugID = OrgList[i];

              objdbhims.Query = ObjQB.QBInsert(MakeArrayDrugOrganism(), TableName1);
              StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

              if (StrErrorMessage.Equals("True"))
              {
                StrErrorMessage = objTrans.OperationError;
                objTrans.End_Transaction();
                return false;
              }
            }
          }

          objTrans.End_Transaction();
          return true;
        }
      }
      else
      {
        return false;
      }
		}

		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select OrganismID, Organism, Acronym,Description,Active from " + TableName + " Order by Organism";
					break;
        case 2:
          objdbhims.Query = "SELECT OrganismID FROM dc_tp_organism where Organism = '" + StrOrganism + "';";
          break;
        case 3:
          objdbhims.Query = "SELECT OrganismID FROM dc_tp_organism where Acronym = '" + StrAcronym + "';";
          break;
        case 4:
           objdbhims.Query = "SELECT OrganismId,Organism FROM dc_tp_organism where Active ='Y' order by Organism";
          break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}	

		private string[,] MakeArray()
		{
			string[,] aryOrganism = new string[8,3];

			if(!this.StrOrganismID.Equals(Default))
			{
				aryOrganism[0,0] = "OrganismID";
				aryOrganism[0,1] = this.StrOrganismID;
				aryOrganism[0,2] = "int";
			}

			if(!this.StrOrganism.Equals(Default))
			{
				aryOrganism[1,0] = "Organism";
				aryOrganism[1,1] = this.StrOrganism;
				aryOrganism[1,2] = "string";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryOrganism[2,0] = "Active";
				aryOrganism[2,1] = this.StrActive;
				aryOrganism[2,2] = "string";
			}

			if(!this.StrAcronym.Equals(Default))
			{
				aryOrganism[3,0] = "Acronym";
				aryOrganism[3,1] = this.StrAcronym;
				aryOrganism[3,2] = "string";
			}

			if(!this.StrDescription.Equals(Default))
			{
				aryOrganism[4,0] = "Description";
				aryOrganism[4,1] = this.StrDescription;
				aryOrganism[4,2] = "string";
			}

			if(!this.StrEnteredBy.Equals(Default))
			{
				aryOrganism[5,0] = "EnteredBY";
				aryOrganism[5,1] = this.StrEnteredBy;
				aryOrganism[5,2] = "int";
			}
      
      if (!this.StrEnteredOn.Equals(Default))
      {
        aryOrganism[6, 0] = "EnteredON";
        aryOrganism[6, 1] = this.StrEnteredOn;
        aryOrganism[6, 2] = "datetime";
      }

      if (!this.StrClientID.Equals(Default))
      {
        aryOrganism[7, 0] = "ClientID";
        aryOrganism[7, 1] = this.StrClientID;
        aryOrganism[7, 2] = "string";
      }

			return aryOrganism;
    }

    private string[,] MakeArrayDrugOrganism()
    {
      string[,] aryDrugOrganism = new string[6, 3];

      if (!this.StrOrganismID.Equals(Default))
      {
        aryDrugOrganism[0, 0] = "OrganismID";
        aryDrugOrganism[0, 1] = this.StrOrganismID;
        aryDrugOrganism[0, 2] = "int";
      }

      if (!this.StrDrugID.Equals(Default))
      {
        aryDrugOrganism[1, 0] = "DrugID";
        aryDrugOrganism[1, 1] = this.StrDrugID;
        aryDrugOrganism[1, 2] = "int";
      }

      if (!this.StrType.Equals(Default))
      {
        aryDrugOrganism[2, 0] = "Type";
        aryDrugOrganism[2, 1] = this.StrType;
        aryDrugOrganism[2, 2] = "string";
      }

      if (!this.StrEnteredBy.Equals(Default))
      {
        aryDrugOrganism[3, 0] = "EnteredBY";
        aryDrugOrganism[3, 1] = this.StrEnteredBy;
        aryDrugOrganism[3, 2] = "int";
      }

      if (!this.StrEnteredOn.Equals(Default))
      {
        aryDrugOrganism[4, 0] = "EnteredON";
        aryDrugOrganism[4, 1] = this.StrEnteredOn;
        aryDrugOrganism[4, 2] = "datetime";
      }

      if (!this.StrClientID.Equals(Default))
      {
        aryDrugOrganism[5, 0] = "ClientID";
        aryDrugOrganism[5, 1] = this.StrClientID;
        aryDrugOrganism[5, 2] = "string";
      }

      return aryDrugOrganism;
    }


    #endregion

    #region Validate

    private bool Validate_Form()
    {
      if (!VD_Name())
      {
        return false;
      }
      if (!VD_Acronym())
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
      if (StrOrganism.Equals(""))
      {
        StrErrorMessage = "Please enter other Organism Name.";
        return false;
      }

      DataView dv = GetAll(2);
      if (dv.Count > 0)
      {
        if (!StrOrganismID.Equals(Default) && !StrOrganismID.Equals("") )
          dv.RowFilter = "OrganismID <>" + StrOrganismID;
        if (dv.Count > 0)
        {
          StrErrorMessage = "Please enter other Organism Name.It is already exist";
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
      if (StrAcronym.Trim().Equals(""))
      {
        return true;
      }
      DataView dv = GetAll(3);
      if (dv.Count > 0)
      {
        if (!StrOrganismID.Equals(Default) && !StrOrganismID.Equals("") )
          dv.RowFilter = "OrganismID <>" + StrOrganismID;
        if (dv.Count > 0)
        {
          StrErrorMessage = "please enter other acronym.It is already exist";
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
