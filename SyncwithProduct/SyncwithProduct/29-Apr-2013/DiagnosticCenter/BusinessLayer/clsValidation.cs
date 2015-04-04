using System;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for Validation1.
	/// </summary>
	public class clsValidation
	{
		System.Globalization.CultureInfo ObjDateFormat = new CultureInfo("ur-PK");

        public clsValidation()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public bool IsName(string strName)
		{
			Regex objReg = new Regex(@"(^[A-Za-z]+\s?)*[A-Za-z]$");
			return objReg.IsMatch(strName);
		}
		
		public bool IsBBName(string strBBName)
		{
			Regex objReg = new Regex(@"^[A-Za-z0-9]([A-Za-z0-9]+\s?\(?[\+-]?\)?\s?)*$");
			return objReg.IsMatch(strBBName);
		}

		public bool IsEmail(string strEmail)
		{
			Regex objReg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
			return objReg.IsMatch(strEmail);
		}

		public bool IsAddress(string strAddress)
		{
			Regex objReg = new Regex(@"^[A-Za-z0-9\s]+([\/\.-]*)?[A-Za-z0-9\s]+$");
			return objReg.IsMatch(strAddress);
		}


		public bool IsDate(string strDate)
		{
			Regex objReg = new Regex(@"^[0-3][0-9]\/[0-1][0-9]\/[0-9][0-9][0-9][0-9]$");
		
			if(objReg.IsMatch(strDate))
			{
				ObjDateFormat.DateTimeFormat.ShortDatePattern ="dd/MM/yyyy"; 
				System.Threading.Thread.CurrentThread.CurrentCulture = ObjDateFormat;

				try
				{
					System.DateTime.Parse(strDate);
					return true;
				}  
				catch(Exception)
				{					
					return false;				
				}
			}
			else
			{
				return false;
			}
		}

		public bool IsTime(string strTime)
		{
			Regex objReg = new Regex(@"(^[1][0-2]|^[1-9]|^[0][1-9]):[0-5][0-9]\s(AM|PM)$");
		
			if(objReg.IsMatch(strTime))
			{
				ObjDateFormat.DateTimeFormat.ShortTimePattern ="hh:mm tt"; 
				System.Threading.Thread.CurrentThread.CurrentCulture = ObjDateFormat;

				try
				{
					System.DateTime.Parse(strTime);
					return true;
				}  
				catch(Exception)
				{					
					return false;				
				}
			}
			else
			{
				return false;
			}
		}
        public bool IsTime_24(string strTime)
        {
            Regex objReg = new Regex(@"([01]?[0-9]|2[0-3]):[0-5][0-9]");

            if (objReg.IsMatch(strTime))
            {
                ObjDateFormat.DateTimeFormat.ShortTimePattern = "24HH:mm";
                System.Threading.Thread.CurrentThread.CurrentCulture = ObjDateFormat;

                try
                {
                    System.DateTime.Parse(strTime);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

		public bool IsNIC(string strNIC)
		{
			Regex objReg = new Regex(@"^[0-9]+[-][0-9]+[-][0-9]+$");
			return objReg.IsMatch(strNIC);
		}
		public bool IsNaturalNumber(String strNumber)
		{
			Regex objNotNaturalPattern=new Regex("[^0-9]");
			Regex objNaturalPattern=new Regex("0*[1-9][0-9]*");
			return  !objNotNaturalPattern.IsMatch(strNumber) &&
				objNaturalPattern.IsMatch(strNumber);
		}  

		// Function to test for Positive Integers with zero inclusive  

		public bool IsWholeNumber(String strNumber)
		{
			Regex objNotWholePattern=new Regex("[^0-9]");
			return !objNotWholePattern.IsMatch(strNumber);
		}  

		// Function to Test for Integers both Positive & Negative  

		public bool IsInteger(String strNumber)
		{
			Regex objNotIntPattern=new Regex("[^0-9-]");
			Regex objIntPattern=new Regex("^-[0-9]+$|^[0-9]+$");
			return  !objNotIntPattern.IsMatch(strNumber) &&  objIntPattern.IsMatch(strNumber);
		} 

		
		/// <summary>
		/// Function to Test for Positive Number (both Integer & Real)
		/// </summary>
		/// <param name="strNumber"></param>
		/// <returns>bool</returns>
		public bool IsPositiveNumber(String strNumber)  
		{
			Regex objNotPositivePattern=new Regex("[^0-9.]");
			Regex objPositivePattern=new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
			Regex objTwoDotPattern=new Regex("[0-9]*[.][0-9]*[.][0-9]*");
			return !objNotPositivePattern.IsMatch(strNumber) &&
				objPositivePattern.IsMatch(strNumber)  &&
				!objTwoDotPattern.IsMatch(strNumber);
		}  


		/// <summary>
		/// Function to test whether the string is valid number or not
		/// </summary>
		/// <param name="strNumber"></param>
		/// <returns>bool</returns>		
		public bool IsNumber(String strNumber)
		{
			Regex objNotNumberPattern=new Regex("[^0-9.-]");
			Regex objTwoDotPattern=new Regex("[0-9]*[.][0-9]*[.][0-9]*");
			Regex objTwoMinusPattern=new Regex("[0-9]*[-][0-9]*[-][0-9]*");
			String strValidRealPattern="^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
			String strValidIntegerPattern="^([-]|[0-9])[0-9]*$";
			Regex objNumberPattern =new Regex("(" + strValidRealPattern +")|(" + strValidIntegerPattern + ")");
			return !objNotNumberPattern.IsMatch(strNumber) &&
				!objTwoDotPattern.IsMatch(strNumber) &&
				!objTwoMinusPattern.IsMatch(strNumber) &&
				objNumberPattern.IsMatch(strNumber);
		}  

	
		/// <summary>
		/// Function To test for Alphabets. 
		/// </summary>
		/// <param name="strToCheck"></param>
		/// <returns>bool</returns>
		public bool IsAlpha(String strToCheck)
		{
			Regex objAlphaPattern=new Regex("[^a-zA-Z][a-zA-Z.]$");
			return !objAlphaPattern.IsMatch(strToCheck);
		}


		/// <summary>
		/// Function to Check for AlphaNumeric.
		/// </summary>
		/// <param name="strToCheck"></param>
		/// <returns>bool</returns>
		public bool IsAlphaNumeric(string strToCheck)
		{
			Regex objAlphaNumericPattern=new Regex (@"^[a-zA-Z0-9]*([a-zA-Z0-9\-\/]*\.?\s?)*[a-zA-Z0-9]*$");

			return !objAlphaNumericPattern.IsMatch(strToCheck);
            
		}		

		public bool IsPLNo(string strToCheck)
		{
			Regex objAlphaNumericPattern = new Regex(@"^([a-zA-Z0-9]+[-])*[0-9]*[0-9]$");

			return objAlphaNumericPattern.IsMatch(strToCheck);   
		}		
		public bool IsEntitledPatientId(string patientId){
			if(patientId.ToLower().IndexOf("e")==0)
			{
				return true;
			}
			return false;
		}

		public bool IsBloodGroup(string strToCheck)
		{
			Regex objBGPattern = new Regex(@"^[A-Z][A-Z]?\+$|^[A-Z][A-Z]?[-]$");
			return objBGPattern.IsMatch(strToCheck);
		}
	}
}
