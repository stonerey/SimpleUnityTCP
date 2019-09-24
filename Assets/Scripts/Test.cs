using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Test 
{
    private static string SEPARATOR = "|";
    private static string ERROR_RESPONSE_HAVE_NO_EXTRAINFO = "There is no extra info on the response";


    public static string GetResponseInfo(this string result)
    {
        return result.Contains(SEPARATOR) ? result.Split(new[] { SEPARATOR }, StringSplitOptions.None).Last() : ERROR_RESPONSE_HAVE_NO_EXTRAINFO;
    }
}
