﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Rot13
/// </summary>
public class Rot13
{
	public Rot13()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string Transform(string value)
    {
        char[] array = value.ToCharArray();
        for (int i = 0; i < array.Length; i++)
        {
            int number = (int)array[i];

            if (number >= 'a' && number <= 'z')
            {
                if (number > 'm')
                {
                    number -= 13;
                }
                else
                {
                    number += 13;
                }
            }
            else if (number >= 'A' && number <= 'Z')
            {
                if (number > 'M')
                {
                    number -= 13;
                }
                else
                {
                    number += 13;
                }
            }
            array[i] = (char)number;
        }
        return new string(array);
    }
}