using System;
using System.IO;
using System.Xml;

namespace Atk.Lib
{
    static class Common
    {
        public static string VerifyTag(XmlDocument XmlDoc, string Tag, string Message)
        {
            XmlNodeList xnList = XmlDoc.DocumentElement.GetElementsByTagName(Tag);
            if (xnList == null || xnList.Count == 0)
            {
                throw new Exception(Message);
            }
            return xnList[0].InnerText;
        }
        public static string DoTimeStamp(string Format = "")
        {
            #region variables
            string sDoTimeStamp = "";
            string Anio = string.Empty;
            string Mes = string.Empty;
            string Dia = string.Empty;
            string Hora = string.Empty;
            string Minu = string.Empty;
            string Segu = string.Empty;
            string Mili = string.Empty;
            DateTime dFechaHoy = DateTime.Now;
            #endregion

            #region asignación y validación de variables
            Format = string.IsNullOrEmpty(Format) ? "Y-M-D H:M:S" : Format;
            Anio = (dFechaHoy.Year < 10 ? "0" : "") + dFechaHoy.Year.ToString();
            Mes = (dFechaHoy.Month < 10 ? "0" : "") + dFechaHoy.Month.ToString();
            Dia = (dFechaHoy.Day < 10 ? "0" : "") + dFechaHoy.Day.ToString();
            Hora = (dFechaHoy.Hour < 10 ? "0" : "") + dFechaHoy.Hour.ToString();
            Minu = (dFechaHoy.Minute < 10 ? "0" : "") + dFechaHoy.Minute.ToString();
            Segu = (dFechaHoy.Second < 10 ? "0" : "") + dFechaHoy.Second.ToString();
            Mili = (dFechaHoy.Millisecond < 10 ? "00" : (dFechaHoy.Millisecond < 100 ? "0" : "")) + dFechaHoy.Millisecond.ToString();
            #endregion

            #region YMS
            if (Format.IndexOf("YMD") != -1)
            {
                sDoTimeStamp = Anio + Mes + Dia;
            }
            if (Format.IndexOf("YM") != -1)
            {
                sDoTimeStamp = Anio + Mes;
            }
            if (Format.IndexOf("Y/M/D") != -1)
            {
                sDoTimeStamp = Anio + "/" + Mes + "/" + Dia;
            }
            if (Format.IndexOf("Y-M-D") != -1)
            {
                sDoTimeStamp = Anio + "-" + Mes + "-" + Dia;
            }
            #endregion
            #region DMY
            if (Format.IndexOf("DMY") != -1)
            {
                sDoTimeStamp = Dia + Mes + Anio;
            }
            if (Format.IndexOf("MY") != -1)
            {
                sDoTimeStamp = Mes + Anio;
            }
            if (Format.IndexOf("D/M/Y") != -1)
            {
                sDoTimeStamp = Dia + "/" + Mes + "/" + Anio;
            }
            if (Format.IndexOf("D-M-Y") != -1)
            {
                sDoTimeStamp = Dia + "-" + Mes + "-" + Anio;
            }
            #endregion
            #region T o Espacio
            if (Format.IndexOf("T") != -1)
            {
                sDoTimeStamp += "T";
            }
            if (Format.IndexOf(" ") != -1)
            {
                sDoTimeStamp += " ";
            }
            #endregion
            #region HMS
            if (Format.IndexOf("HMSN") != -1)
            {
                sDoTimeStamp += Hora + Minu + Segu + Mili;
            }
            if (Format.IndexOf("HMS") != -1)
            {
                sDoTimeStamp += Hora + Minu + Segu;
            }
            if (Format.IndexOf("H:M:S.N") != -1)
            {
                sDoTimeStamp += Hora + ":" + Minu + ":" + Segu + "." + Mili;
            }
            if (Format.IndexOf("H:M:S") != -1)
            {
                sDoTimeStamp += Hora + ":" + Minu + ":" + Segu;
            }
            #endregion
            return sDoTimeStamp;
        }
        public static void StreamWriter(string File, string Text, bool Append = true)
        {
            StreamWriter stFile = null;
            stFile = new StreamWriter(File, Append);
            stFile.WriteLine(Text);
            stFile.Close();
        }
    }
}
