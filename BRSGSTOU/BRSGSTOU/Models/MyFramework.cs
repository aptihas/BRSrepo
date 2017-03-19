using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BRSGSTOU.Models
{
    public static class MyFramework
    {
        public static  string Abreviatura(string[] masssiv)
        {
            string abrev = "";
            if (masssiv.Length > 1)
            {
                foreach (string m in masssiv)
                {
                    abrev += m.Length > 0 ? m.Substring(0, 1) : "";
                }
            }
            else
            {
                abrev = masssiv[0].Substring(0, 5) + "-" + masssiv[0].Substring(masssiv[0].Length - 1, 1);
            }
            return abrev.ToUpper();
        }
    }
}