using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;

namespace XmlDoc2Markdown
{
    public static class Utils
    {

        public static string Escape(string content) =>
            content.Replace("`", @"\`");

        public static string JoinMarkdownSpan(string x, string y) =>
            x.EndsWith("\n\n", StringComparison.Ordinal)
                ? $"{x}{y.TrimStart()}"
                : y.StartsWith("\n\n", StringComparison.Ordinal)
                ? $"{x.TrimEnd()}{y}"
                : $"{x}{y}";

        public static int FindIndexOf(string node)
        {
            List<int> result = new List<int>();

            foreach (var item in node.Split(Environment.NewLine.ToCharArray())
                .Where(t => t.Length > 0))
            {
                result.Add(0);

                for (int i = 0; i < item.Length; i++)
                {
                    if (item.ToCharArray()[i] != ' ')
                        break;
                    result[result.Count - 1] += 1;
                }
            }

            return result.Min();
        }

        public static string AsCode(string code)
        {
            string backticks = "`";
            while (code.Contains(backticks))
            {
                backticks += "`";
            }

            return code.StartsWith("`", StringComparison.Ordinal) || code.EndsWith("`", StringComparison.Ordinal)
                ? $"{backticks} {code} {backticks}"
                : $"{backticks}{code}{backticks}";
        }
        public static string AsSpanMargin(XNode node)
        {
            var text = node as XText;
            if (text != null && text.Value.StartsWith(" ", StringComparison.Ordinal))
            {
                return " ";
            }

            return string.Empty;
        }

        public static string GetParamType(string param) => "(" + GetParamTypes(param, false).Aggregate((x, y) => x + "," + y.ToString()) + ")";
        public static IEnumerable<string> GetParamTypes(string param, bool full = true)
        {
            var paramString = param.Split('(').Last().Trim(')');

            var delta = 0;
            var list = new List<StringBuilder>()
            {
                new StringBuilder(),
            };

            foreach (var character in paramString)
            {
                if (character == '{')
                {
                    delta++;
                }
                else if (character == '}')
                {
                    delta--;
                }
                else if (character == ',' && delta == 0)
                {
                    list.Add(new StringBuilder());
                }

                if (character != ',' || delta != 0)
                {
                    //character = shortNameMember(character);
                    list.Last().Append(character);
                }
            }

            IEnumerable<string> aux = list.Select(x => x.ToString().Replace('{', '<').Replace('}', '>'));
            if (!full)
            {
                aux = aux.Select(x => {
                    Regex regex = new Regex(@"(\w|\.)*\.(\w*)", RegexOptions.Multiline);
                    string result = regex.Replace(x, @"$2");
                    return result;
                }
                );
            }
            return aux;
        }

        public static string getName(XElement elem) => elem.Attribute(XName.Get("name")).Value;

        public static XAttribute getAttribute(XElement elem, string attribute) => (elem.Attribute(XName.Get(attribute)) != null ? elem.Attribute(XName.Get(attribute)) : null);

        public static string getParametersMember(string type)
        {
            Regex regex = new Regex(@"(.*)(\(.*\))", RegexOptions.Multiline);
            type = regex.Replace(type, @"$2").Replace("``1", "<T>").Replace("``2", "<T, U>").Replace("``0", "T");
            if (!type.Contains("("))
                type = "()";// string.Empty;
            return type;
        }

        public static string shortNameMember(string type)
        {
            Regex regex = new Regex(@"(\(.*\))", RegexOptions.Multiline);
            type = regex.Replace(type, "").Replace("``1", "<T>").Replace("``2", "<T, U>").Replace("``0", "T");

            string[] aType = type.Split('.');
            if (aType.Length == 0)
            {
                return type;
            }
            return aType[aType.Length - 1];
        }

        public static string NamespaceMember(string type)
        {
            Regex regex = new Regex(@"(\(.*\))", RegexOptions.Multiline);
            type = regex.Replace(type, "").Replace("``1", "<T>").Replace("``2", "<T, U>").Replace("``0", "T");

            string[] aType = type.Split('.');
            if (aType.Length == 0)
            {
                return "";
            }
            string[] aux = new string[aType.Length - 1];
            Array.Copy(aType, 0, aux, 0, aType.Length - 1);
            string result = string.Join(".", aux);
            return result.Substring(2);
        }

        public static string GetRefMsdn(string type, ref Dictionary<string, string> paramDic, ref Dictionary<string, string> msdnDic, bool withoutMethod = true)
        {
            Dictionary<string, string> _msdnDic = msdnDic;
            string methodLarge = type;

            string method = methodLarge.Split('(').First();
            string parameter = methodLarge.Split('(').Last().Trim(')');
            string paramLarge = parameter.Replace('<', ',').Replace('>', ',').Trim(',');

            //Console.WriteLine(method);
            //Console.WriteLine(parameter);
            //Console.WriteLine(paramLarge);

            string[] paramArray = paramLarge.Split(',');
            for (var i = 0; i < paramArray.Length; i++)
            {
                var x = paramArray[i];
                string shortN = x.Split('.').Last();
                string link = string.Empty;
                if (x.StartsWith("System"))
                {
                    string xClean = x.Replace("[]", "");
                    string msdn = string.Format("http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:{0}", xClean);
                    link = string.Format("[{0}]({1} '{0}')", shortN, msdn);
                }
                if (shortN == "T" || shortN == "U")
                {
                    shortN = "Generic";
                    string xClean = x.Replace("[]", "");
                    string msdn = "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/";
                    link = string.Format("[{0}]({1} '{0}')", shortN, msdn);
                }
                if (!paramDic.ContainsKey(x))
                {
                    //Console.WriteLine(string.Format("dicParam_[{0}] = {1}", x, shortN));
                    paramDic[x] = shortN;
                }
                if (!_msdnDic.ContainsKey(shortN))
                {
                    //Console.WriteLine(string.Format("dicParam_[{0}] = {1}", shortN, link));
                    _msdnDic[shortN] = link;
                }
            }

            string ps = paramLarge.Split(',').Select(x => {
                string shortN = x.Split('.').Last();
                if (shortN == "T" || shortN == "U")
                {
                    shortN = "Generic";
                }
                string xClean = shortN.Replace("[]", "");
                string link = _msdnDic[shortN];
                return link;
            }).Aggregate((x, y) => x + "," + y.ToString());

            string paramT = parameter;
            foreach (var p in paramDic)
            {
                paramT = paramT.Replace(p.Key, _msdnDic[p.Value]);
            }
            msdnDic = _msdnDic;
            return (withoutMethod ? "" : method) + paramT;
        }
    }
}
