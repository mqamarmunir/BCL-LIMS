using System;
using System.Configuration;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for QueryBuilder.
	/// </summary>
	public class QueryBuilder
	{
		public QueryBuilder()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public string QBInsert(string[,] ar, string tableName)
		{
			string toReturn = "Insert into " + tableName + "(";
			int checker = 0;
			string dateFormat = "";

			for(int counter = 0; counter <= ar.GetUpperBound(0); counter++)
			{
				if(ar[counter,0] != null)
				{
					if(checker != 0)
					{
						toReturn += ",";
					}

					toReturn += ar[counter, 0];

					checker++;
				}
			}

			toReturn += ") Values(";
			checker = 0;

			for(int counter = 0; counter <= ar.GetUpperBound(0); counter++)
			{
				if(ar[counter,0] != null)
				{
					if(checker != 0)
					{
						toReturn += ",";
					}

					switch(ar[counter,2])
					{
						case "string":
							toReturn += "'" + ar[counter,1] + "'";
							break;

						case "int":
							toReturn += ar[counter,1];
							break;

						case "date":
                            dateFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
							toReturn += "str_to_date('" + ar[counter,1] + "','"+ dateFormat +"')";
							break;

                        case "datetime":
                            dateFormat = ConfigurationSettings.AppSettings["DateTimeFormat"].ToString();
                            toReturn += "str_to_date('" + ar[counter, 1] + "','" + dateFormat + "')";
                            break;

                        case "datetime24":
                            dateFormat = ConfigurationSettings.AppSettings["DateTimeFormat24"].ToString();
                            toReturn += "str_to_date('" + ar[counter, 1] + "','" + dateFormat + "')";
                            break;

						default:
							toReturn += "'" + ar[counter,1] + "'";
							break;
					}

				checker++;
				}
			}

			toReturn += ")";

			return toReturn;
		}


		public string QBUpdate(string[,] ar, string tableName)
		{
			string toReturn = "Update " + tableName + " set ";
			int checker = 0;
			string dateFormat = "";

			for(int counter = 1; counter <= ar.GetUpperBound(0); counter++)
			{
				if(ar[counter,0] != null)
				{
					if(checker != 0)
					{
						toReturn += ",";
					}

					switch(ar[counter,2])
					{
						case "string":
							toReturn += ar[counter, 0] + "='" + ar[counter,1] + "'";
							break;

						case "int":
							toReturn += ar[counter, 0] + "=" + ar[counter,1];
							break;

						case "date":
							dateFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();							
							toReturn += ar[counter, 0] + "=str_to_date('" + ar[counter,1] + "','" + dateFormat + "')";
							break;

						case "datetime":
							dateFormat = ConfigurationSettings.AppSettings["DateTimeFormat"].ToString();		
							toReturn += ar[counter, 0] + "=str_to_date('" + ar[counter,1] + "','" + dateFormat + "')";
							break;

                        case "datetime24":
                            dateFormat = ConfigurationSettings.AppSettings["DateTimeFormat24"].ToString();
                            toReturn += ar[counter, 0] + "=str_to_date('" + ar[counter, 1] + "','" + dateFormat + "')";
                            break;

						default:
							toReturn += ar[counter, 0] + "='" + ar[counter,1] + "'";
							break;
					}

					checker++;
				}
			}

			if(ar[0,2].Equals("string"))
			{
				toReturn += " Where " + ar[0,0].ToUpper() + "='" + ar[0,1].ToUpper() +"'";
			}
			else
			{
				toReturn += " Where " + ar[0,0].ToUpper() + "=" + ar[0,1].ToUpper();
			}

			return toReturn;
		}

		public string QBUpdate2(string[,] ar, string tableName)
		{
			string toReturn = "Update " + tableName + " set ";
			int checker = 0;
			string dateFormat = "";

			for(int counter = 1; counter <= ar.GetUpperBound(0); counter++)
			{
				if(ar[counter,0] != null)
				{
					if(checker != 0)
					{
						toReturn += ",";
					}

					switch(ar[counter,2])
					{
						case "string":
							toReturn += ar[counter, 0] + "='" + ar[counter,1] + "'";
							break;

						case "int":
							toReturn += ar[counter, 0] + "=" + ar[counter,1];
							break;

						case "date":
                            dateFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();							
							toReturn += ar[counter, 0] + "=str_to_date('" + ar[counter,1] + "','" + dateFormat + "')";
							break;

						case "datetime":
							dateFormat = ConfigurationSettings.AppSettings["DateTimeFormat"].ToString();		
							toReturn += ar[counter, 0] + "=str_to_date('" + ar[counter,1] + "','" + dateFormat +"')";
							break;

                        case "datetime24":
                            dateFormat = ConfigurationSettings.AppSettings["DateTimeFormat24"].ToString();
                            toReturn += ar[counter, 0] + "=str_to_date('" + ar[counter, 1] + "','" + dateFormat + "')";
                            break;

						default:
							toReturn += ar[counter, 0] + "='" + ar[counter,1] + "'";
							break;
					}

					checker++;
				}
			}

			if(ar[0,2].Equals("string"))
			{
				toReturn += " Where " + ar[0,0].ToUpper() + "='" + ar[0,1].ToUpper() +"'";
			}
			else
			{
				toReturn += " Where " + ar[0,0].ToUpper() + "=" + ar[0,1].ToUpper();
			}

			if(ar[1,2].Equals("string"))
			{
				toReturn += " and " + ar[1,0].ToUpper() + "='" + ar[1,1].ToUpper() +"'";
			}
			else
			{
				toReturn += " and " + ar[1,0].ToUpper() + "=" + ar[1,1].ToUpper();
			}

			return toReturn;
		}

        public string QBUpdate3(string[,] ar, string tableName)
        {
            string toReturn = "Update " + tableName + " set ";
            int checker = 0;
            string dateFormat = "";

            for (int counter = 1; counter <= ar.GetUpperBound(0); counter++)
            {
                if (ar[counter, 0] != null)
                {
                    if (checker != 0)
                    {
                        toReturn += ",";
                    }

                    switch (ar[counter, 2])
                    {
                        case "string":
                            toReturn += ar[counter, 0] + "='" + ar[counter, 1] + "'";
                            break;

                        case "int":
                            toReturn += ar[counter, 0] + "=" + ar[counter, 1];
                            break;

                        case "date":
                            dateFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                            toReturn += ar[counter, 0] + "=str_to_date('" + ar[counter, 1] + "','" + dateFormat + "')";
                            break;

                        case "datetime":
                            dateFormat = ConfigurationSettings.AppSettings["DateTimeFormat"].ToString();
                            toReturn += ar[counter, 0] + "=str_to_date('" + ar[counter, 1] + "','" + dateFormat + "')";
                            break;

                        case "datetime24":
                            dateFormat = ConfigurationSettings.AppSettings["DateTimeFormat24"].ToString();
                            toReturn += ar[counter, 0] + "=str_to_date('" + ar[counter, 1] + "','" + dateFormat + "')";
                            break;

                        default:
                            toReturn += ar[counter, 0] + "='" + ar[counter, 1] + "'";
                            break;
                    }

                    checker++;
                }
            }

            if (ar[0, 2].Equals("string"))
            {
                toReturn += " Where " + ar[0, 0].ToUpper() + "='" + ar[0, 1].ToUpper() + "'";
            }
            else if (ar[0, 2].Equals("date"))
            {
                dateFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                toReturn += " Where date_format(" + ar[0, 0].ToUpper() + ",'" + dateFormat + "') = '" + ar[0, 1].ToUpper() + "'";
            }
            else
            {
                toReturn += " Where " + ar[0, 0].ToUpper() + "=" + ar[0, 1].ToUpper();
            }

            if (ar[1, 2].Equals("string"))
            {
                toReturn += " and " + ar[1, 0].ToUpper() + "='" + ar[1, 1].ToUpper() + "'";
            }
            else if (ar[1, 2].Equals("date"))
            {
                dateFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                toReturn += " and date_format(" + ar[1, 0].ToUpper() + ",'" + dateFormat + "') = '" + ar[1, 1].ToUpper() + "'";
            }
            else
            {
                toReturn += " and " + ar[1, 0].ToUpper() + "=" + ar[1, 1].ToUpper();
            }

            if (ar[2, 2].Equals("string"))
            {
                toReturn += " and " + ar[2, 0].ToUpper() + "='" + ar[2, 1].ToUpper() + "'";
            }
            else if (ar[2, 2].Equals("date"))
            {
                dateFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                toReturn += " and date_format(" + ar[2, 0].ToUpper() + ",'" + dateFormat + "') = '" + ar[2, 1].ToUpper() + "'";
            }
            else
            {
                toReturn += " and " + ar[2, 0].ToUpper() + "=" + ar[2, 1].ToUpper();
            }

            return toReturn;
        }        


		public string QBGetSingle(string strColumnName, string strPKey, string strTableName)
		{
			return "Select * from " + strTableName + " Where Upper(" + strColumnName + ") = '" + strPKey.ToUpper() + "'";
		}

		public string QBDelete(string columnName, string tableName, string where)
		{
			return "delete from " + tableName + " where "+ columnName +" = "+ where;
		}

		public string QBDelete2(string columnName1, string columnName2, string tableName, string where1, string where2)
		{
			return "delete from " + tableName + " where "+ columnName1 +" = "+ where1 + " and "+columnName2+" = "+ where2;
		}

		public string QBGetMax(string columnName, string tableName)
		{
			return "Select ifnull(Max(" + columnName + "),0)+1 As MAXID from " + tableName;
		}

		public string QBGetMax1000(string columnName, string tableName)
		{
			return "Select ifnull(Max(" + columnName + "),999)+1 As MAXID from " + tableName;
		}

		public string QBGetMax1000_yy(string columnName, string tableName,string forYear)
		{
			return "Select ifnull(Max(substr(" + columnName + ",1,4)),999)+1 As MAXID from " + tableName +" where substr(" + columnName + ",6,2) = "+forYear;
		}


		public string QBGetMax_Lpad(string columnName, string tableName)
		{
			return "Select LPAD(ifnull(Max(" + columnName + "),0)+1,4,'0') As MAXID from " + tableName;
		}

        public string QBGetMax_Length(string columnName, string tableName, string strLength)
        {
            return "Select LPad(ifnull(Max(" + columnName + "),0)+1, " + strLength + ", 0) As MAXID from " + tableName;
        }
		
		public string QBGetMaxWorkListNo(string SectionID)
		{
			return "Select Max(WorkListNo)+1 As MAXID from LS_TWorkList Where SectionID = " + SectionID;
		}

		public string QBGetMaxRSerialNo()
		{			
			return "Select Max(RSerialNo)+1 As MAXID from LS_TTestResultM";
		}
        public string QBGetLastID(string columnName, string tableName)
        {
            return "Select ifnull(Max(" + columnName + "),1) As MAXID from " + tableName;
        }
	}
}
