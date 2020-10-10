using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringHelper
{
    public static string StringColor(string msg, Color col)
    {
        return "<color=#" + ColorUtility.ToHtmlStringRGBA(col) + ">" + msg + "</color>";
    }
	
}
