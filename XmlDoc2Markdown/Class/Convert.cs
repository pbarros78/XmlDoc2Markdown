using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;

namespace XmlDoc2Markdown
{
    class Convert
    {
        //Diccionario para los namespaces/clases/tipo/enum
        private Dictionary<string, Member> mainDoc;
        //Diccionario para guardar los tipos de datos .Net del documento (más fácil de buscar el nombre corto o largo
        private Dictionary<string, string> paramDic;
        //Diccionario para guardar los links a MSDN de los tipos de datos .Net
        private Dictionary<string, string> msdnDic;
        private string fileXml;

        public Convert(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException("Error: File can't be empty.");
            }
            mainDoc = new Dictionary<string, Member>();
            paramDic = new Dictionary<string, string>();
            msdnDic = new Dictionary<string, string>();
            fileXml = file;
        }

        public void Process()
        {
            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load(fileXml);
            }
            catch (Exception e)
            {
                //En caso de error con el XML
                throw new Exception("Error: " + e.Message);
            }
            //Guarda el string del markdown
            StringWriter sw = new StringWriter();
            //Procesa el xml y lo agrega al diccionario
            PrepareMainDicc(xdoc.Root);
            //Procesa el diccionario para crear el string markdown
            ProcessDic(sw);
            string md = sw.ToString();
            Console.WriteLine(md);
            //Cambia la extensión del archivo de entrada (xml)
            string fileMd = Path.ChangeExtension(fileXml, ".md");
            //Escribe el markdown a disco
            Atk.Lib.Common.StreamWriter(fileMd, md, false);
        }

        void PrepareMainDicc(XElement elem)
        {
            // Si el primer elemento es doc (archivo de documentación de VS)
            if (elem.Name == "doc")
            {
                // Se agrega Nombre del ensamblado en diccionario, key = "assembly"
                mainDoc["assembly"] = new Member
                {
                    Type = MemberType.Assembly,
                    Name = elem.Element("assembly").Element("name").Value
                };

                // Se obtienen todos los nodos member
                List<XElement> members = new List<XElement>(
                    elem.Element("members").Elements("member"));
                // Se recorren los nodos para ir agregandolos al diccionario
                foreach (XElement member in members)
                {
                    //Se llama a sí mismo para procesar elementos hijos
                    PrepareMainDicc(member);
                }
            }
            // Si el elemento es T: (Type/Clase/Enum)
            else if (Utils.getName(elem).StartsWith("T:"))
            {
                //Se procesa elemento
                Member m = ProcessMember(elem);
                //Se guarda al diccionario
                mainDoc[m.Id] = m;
            }
            // Si el elemento es Method/Property/Field/Event/Unknow
            else if (Utils.getName(elem).StartsWith("M:") || Utils.getName(elem).StartsWith("P:") || Utils.getName(elem).StartsWith("F:") || Utils.getName(elem).StartsWith("E:") || Utils.getName(elem).StartsWith("!:"))
            {
                //Se procesa elemento
                Member m = ProcessMember(elem);
                //Si existe el namespace/clase/tipo en el diccionario
                if (mainDoc.ContainsKey(m.Namespace))
                {
                    //Si es method
                    if (m.Type == MemberType.Method)
                    {
                        //Si no existe lista de métodos del namespace/clase/tipo en el diccionario
                        if (mainDoc[m.Namespace].Methods == null)
                        {
                            //Se crea lista
                            mainDoc[m.Namespace].Methods = new Dictionary<string, Member>();
                            //Se agrega al listado de métodos
                            mainDoc[m.Namespace].Methods[m.Name] = m;
                        }
                        //Si existe lista de métodos del namespace/clase/tipo en el diccionario
                        else
                        {
                            //Si no existe el método en la lista de métodos (se agrega)
                            if (!mainDoc[m.Namespace].Methods.ContainsKey(m.Name))
                            {
                                mainDoc[m.Namespace].Methods[m.Name] = m;
                            }
                            //Si existe el método en la lista de métodos (se agrega como overload)
                            else if (mainDoc[m.Namespace].Methods[m.Name].Overloads == null)
                            {
                                m.Type = MemberType.Overload;
                                mainDoc[m.Namespace].Methods[m.Name].Overloads = new List<Member>();
                                mainDoc[m.Namespace].Methods[m.Name].Overloads.Add(m);
                            }
                            else
                            {
                                m.Type = MemberType.Overload;
                                mainDoc[m.Namespace].Methods[m.Name].Overloads.Add(m);
                            }
                        }
                    }
                    //Si es constructor, se agrega a la lista de constructores de la clase
                    if (m.Type == MemberType.Constructor)
                    {
                        if (mainDoc[m.Namespace].Constructors == null)
                        {
                            mainDoc[m.Namespace].Constructors = new List<Member>();
                            mainDoc[m.Namespace].Constructors.Add(m);
                        }
                        else
                        {
                            mainDoc[m.Namespace].Constructors.Add(m);
                        }
                    }
                    //Si es field, se agrega a la lista de campos de la clase
                    if (m.Type == MemberType.Field)
                    {
                        if (mainDoc[m.Namespace].Fields == null)
                        {
                            mainDoc[m.Namespace].Fields = new List<Member>();
                            mainDoc[m.Namespace].Fields.Add(m);
                        }
                        else
                        {
                            mainDoc[m.Namespace].Fields.Add(m);
                        }
                    }
                    //Si es field, se agrega a la lista de propiedades de la clase
                    if (m.Type == MemberType.Property)
                    {
                        if (mainDoc[m.Namespace].Properties == null)
                        {
                            mainDoc[m.Namespace].Properties = new List<Member>();
                            mainDoc[m.Namespace].Properties.Add(m);
                        }
                        else
                        {
                            mainDoc[m.Namespace].Properties.Add(m);
                        }
                    }
                }
            }
            // Si no existe, entonces no es un xml doc
            else
            {
                throw new Exception("Error: Wrong format file.");
            }
        }

        Member ProcessMember(XElement member)
        {
            // Obtiene el nombre completo del nodo
            string memberFullName = Utils.getName(member);
            // Obtiene el Tipo del nodo (nombre)
            string memberType = memberFullName.ElementAt(0).ToString();
            // Obtiene el nombre sin tipo para Id
            string memberId = memberFullName.Substring(2);

            // Se obtiene sólo el nombre de la clase, sin NS
            string memberShortName = Utils.shortNameMember(memberFullName);
            // Se obtiene el NS de la clase
            string memberNamespace = Utils.NamespaceMember(memberFullName);

            string memberParameters = Utils.getParametersMember(memberId);

            MemberType memberTypeEnum = MemberType.Unknown;
            switch (memberType)
            {
                case "N":
                    memberTypeEnum = MemberType.Namespace;
                    break;
                case "T":
                    memberTypeEnum = MemberType.Type;
                    break;
                case "F":
                    memberTypeEnum = MemberType.Field;
                    break;
                case "P":
                    memberTypeEnum = MemberType.Property;
                    break;
                case "M":
                    memberTypeEnum = MemberType.Method;
                    break;
                case "E":
                    memberTypeEnum = MemberType.Event;
                    break;
                case "!":
                default:
                    memberTypeEnum = MemberType.Unknown;
                    break;
            }

            // Se obtiene nodo summary en caso de tener
            string memberSummary = string.Empty;
            string memberSummaryShort = string.Empty;

            // Procesamos summary para ver si tiene atributos u otros campos
            if (member.Element("summary") != null)
            {
                XElement summary = member.Element("summary");
                string[] summaryArray = summary.Value.Trim().Split('\n');
                memberSummaryShort = summaryArray.Length > 0 ? summaryArray[0] : summary.Value.Trim();

                // Revisamos si trae attributo type
                if (summary.HasAttributes && Utils.getAttribute(summary, "type") != null)
                {
                    string summaryType = Utils.getAttribute(summary, "type").Value.ToLower();
                    switch (summaryType)
                    {
                        case "class":
                            memberTypeEnum = MemberType.Class;
                            break;
                        case "interface":
                            memberTypeEnum = MemberType.Interface;
                            break;
                        case "enum":
                            memberTypeEnum = MemberType.Enum;
                            break;
                    }
                }

                memberSummary = ProcessNodeText(summary);
            }

            // Se obtiene nodo summary en caso de example
            string memberExample = ProcessNodeText(member.Element("example"));

            // Se obtiene nodo summary en caso de remarks
            string memberRemark = ProcessNodeText(member.Element("remarks"));

            // Se obtiene nodo summary en caso de example
            //TODO: Tratamiento para el type
            string memberReturn = ProcessNodeText(member.Element("returns"));

            if (memberShortName.Contains("ctor"))
            {
                memberTypeEnum = MemberType.Constructor;
                memberShortName = Utils.shortNameMember(memberNamespace);

            }

            List<Parameters> param = new List<Parameters>();
            List<string> paramWithVarList = new List<string>();
            if (string.IsNullOrWhiteSpace(memberParameters) || memberParameters != "()")
            {
                List<XElement> elems = member.Elements("param").ToList();
                IEnumerable<string> elmParamFull = Utils.GetParamTypes(memberParameters);
                IEnumerable<string> elmParam = Utils.GetParamTypes(memberParameters, false);

                for (var i = 0; i < elmParam.Count(); i++)
                {
                    paramWithVarList.Add($"{elmParam.ElementAt(i)} {Utils.getAttribute(elems[i], "name").Value}");
                    param.Add(new Parameters
                    {
                        Name = Utils.getAttribute(elems[i], "name").Value,
                        Type = elmParam.ElementAt(i),
                        TypeFull = elmParamFull.ElementAt(i),
                        Summary = ProcessNodeText(elems[i])
                    });
                }
            }
            string paramWithVar = paramWithVarList.Count > 0 ? "(" + paramWithVarList.Aggregate((x, y) => x + ", " + y.ToString()) + ")" : memberParameters;

            Member result = new Member
            {
                Type = memberTypeEnum,
                Id = memberId,
                Name = memberShortName,
                Namespace = memberNamespace,
                Summary = memberSummary,
                SummaryShort = memberSummaryShort,
                Example = memberExample,
                Remark = memberRemark,
                ParametersFullText = paramWithVar,
                ParametersText = Utils.GetParamType(memberParameters),
                Parameters = param,
                Return = memberReturn
            };

            return result;
        }

        string ProcessNodeText(XElement elem) =>
            elem != null ?
            elem.Nodes()
                .Select(ProcessNodeSpan)
                .Aggregate(string.Empty, Utils.JoinMarkdownSpan)
                .Trim() :
            string.Empty;

        string ProcessNodeSpan(XNode node)
        {
            XText text = node as XText;
            if (text != null)
            {
                return Utils.Escape(text.Value).TrimStart(' ').Replace("            ", string.Empty);
            }

            XElement child = node as XElement;
            if (child != null)
            {
                switch (child.Name.ToString())
                {
                    case "see":
                        return "#RESCAN#" + child.Attribute("cref").Value + "#R#";
                    case "paramref":
                    case "typeparamref":
                        return $"{Utils.AsCode(child.Attribute("name").Value)}{Utils.AsSpanMargin(child.NextNode)}";
                    case "c":
                    case "value":
                        return $"{Utils.AsCode(child.Value)}{Utils.AsSpanMargin(child.NextNode)}";
                    case "code":
                        var lang = child.Attribute("lang")?.Value ?? "csharp";

                        string value = child.Nodes().First().ToString().Replace("\t", "    ");
                        var indexOf = Utils.FindIndexOf(value);

                        var codeblockLines = value.Split(Environment.NewLine.ToCharArray())
                            .Where(t => t.Length > indexOf)
                            .Select(t => t.Substring(indexOf));
                        var codeblock = string.Join("\n", codeblockLines);

                        return $"\n\n```{lang}\n{codeblock}\n```\n\n";
                    case "example":
                    case "para":
                        return $"\n{ProcessNodeText(child)}\n\n";
                    default:
                        return string.Empty;
                }
            }
            return string.Empty;
        }

        void ProcessDic(StringWriter sw)
        {
            foreach (string m in mainDoc.Keys)
            {
                ProcessDicMember(sw, mainDoc[m]);
            }
        }

        void ProcessDicMember(StringWriter sw, Member member)
        {
            if (member.Type == MemberType.Assembly)
            {
                sw.WriteLine("# {0}\n", member.Name);
            }
            else if (member.Type == MemberType.Type || member.Type == MemberType.Class || member.Type == MemberType.Interface)
            {
                //sw.WriteLine("\n## {0} `{1}`", member.Name, member.Type.ToString());
                sw.WriteLine("\n## {0}", member.Name);
                sw.WriteLine("\nNamespace: {0}", member.Namespace);

                if (!string.IsNullOrWhiteSpace(member.Summary))
                    sw.WriteLine("\n{0}", ReprocessSummary(member.Summary));

                if (member.Constructors != null)
                {
                    sw.WriteLine("\n### Lista de constructores\n");
                    sw.WriteLine("| Constructor | Descripción |");
                    sw.WriteLine("| ---- | ---- |");

                    foreach (Member m in member.Constructors)
                    {
                        string link = member.Name + m.ParametersText;
                        link = "#" + link.Replace(",", "").Replace("(", "").Replace(")", "").Replace("<", "").Replace(">", "").ToLower();
                        sw.WriteLine("| [{0}{1}]({3}) | {2} |", member.Name, m.ParametersText.Replace("<", @"\<"), m.SummaryShort, link);
                    }

                    sw.WriteLine();
                    foreach (Member m in member.Constructors)
                    {
                        ProcessDicMember(sw, m);
                    }
                }

                if (!string.IsNullOrWhiteSpace(member.Example))
                    sw.WriteLine("\n### Ejemplos\n\n{0}", member.Example);

                if (!string.IsNullOrWhiteSpace(member.Remark))
                    sw.WriteLine("\n### Observaciones\n\n{0}", member.Remark);

                if (!string.IsNullOrWhiteSpace(member.SeeAlso))
                    sw.WriteLine("\n### Ver también\n\n{0}", member.SeeAlso);

                if (member.Fields != null)
                {
                    sw.WriteLine("\n### Lista de campos\n");
                    sw.WriteLine("| Campo | Descripción |");
                    sw.WriteLine("| ---- | ---- |");
                    foreach (Member m in member.Fields)
                    {
                        ProcessDicMember(sw, m);
                    }
                    sw.WriteLine("\n");
                }

                if (member.Properties != null)
                {
                    sw.WriteLine("\n### Lista de propiedades\n");
                    sw.WriteLine("| Propiedad | Descripción |");
                    sw.WriteLine("| ---- | ---- |");
                    foreach (Member m in member.Properties)
                    {
                        ProcessDicMember(sw, m);
                    }
                    sw.WriteLine("\n");
                }

                if (member.Methods != null)
                {
                    sw.WriteLine("\n### Lista de métodos\n");
                    sw.WriteLine("| Método | Descripción |");
                    sw.WriteLine("| ---- | ---- |");
                    foreach (var m in member.Methods)
                    {
                        // TODO: link a detalle del metodo
                        sw.WriteLine("| [{0}{1}](#{3}) | {2} |", m.Key, m.Value.ParametersText, m.Value.SummaryShort, m.Value.Name.ToLower());
                    }

                    sw.WriteLine();
                    foreach (var m in member.Methods)
                    {
                        ProcessDicMember(sw, m.Value);
                    }
                }
            }
            else if (member.Type == MemberType.Enum)
            {
                //sw.WriteLine("\n### {0} `{1}`", member.Name, member.Type.ToString());
                sw.WriteLine("\n### {0}", member.Name);

                if (!string.IsNullOrWhiteSpace(member.Summary))
                    sw.WriteLine("\n{0}", ReprocessSummary(member.Summary));

                if (member.Fields != null)
                {
                    sw.WriteLine("\n#### Lista de campos\n");
                    sw.WriteLine("| Campo | Descripción |");
                    sw.WriteLine("| ---- | ---- |");

                    foreach (Member m in member.Fields)
                    {
                        sw.WriteLine("| **{0}** | {1} |", m.Name, m.Summary);
                    }
                }

                if (!string.IsNullOrWhiteSpace(member.Example))
                    sw.WriteLine("\n#### Ejemplos\n\n{0}", member.Example);

                if (!string.IsNullOrWhiteSpace(member.Remark))
                    sw.WriteLine("\n#### Observaciones\n\n{0}", member.Remark);

                if (!string.IsNullOrWhiteSpace(member.SeeAlso))
                    sw.WriteLine("\n#### Ver también\n\n{0}", member.SeeAlso);
            }
            else if (member.Type == MemberType.Constructor)
            {
                sw.WriteLine("#### {0}{1}\n\n", member.Name, member.ParametersText.Replace("<", @"\<"));

                if (string.IsNullOrWhiteSpace(member.Example))
                    sw.WriteLine("```csharp\nvar a = new {0}{1}\n```\n", member.Name, member.ParametersFullText);

                sw.WriteLine("{0}\n", ReprocessSummary(member.Summary));

                if (member.Parameters != null && member.Parameters.Count > 0)
                {
                    sw.WriteLine("\n##### Parámetros del constructor\n");
                    sw.WriteLine("| Parámetro | Tipo  | Descripción |");
                    sw.WriteLine("| ---- | ---- | ---- |");
                    foreach (Parameters m in member.Parameters)
                    {
                        sw.WriteLine("| **{0}** | {1}  | {2} |", m.Name, Utils.GetRefMsdn(m.TypeFull, ref paramDic, ref msdnDic), m.Summary);
                    }
                    sw.WriteLine();
                }

                if (!string.IsNullOrWhiteSpace(member.Example))
                    sw.WriteLine("\n### Ejemplos\n\n{0}", member.Example);

                if (!string.IsNullOrWhiteSpace(member.Remark))
                    sw.WriteLine("\n### Observaciones\n\n{0}", member.Remark);

                if (!string.IsNullOrWhiteSpace(member.SeeAlso))
                    sw.WriteLine("\n### Ver también\n\n{0}", member.SeeAlso);
            }
            else if (member.Type == MemberType.Field || member.Type == MemberType.Property || member.Type == MemberType.Event)
            {
                sw.WriteLine("| **{0}** | {1} |", member.Name, member.Summary);
                //sw.WriteLine("#### {0} `{1}`\n{2}\n", member.Name, member.Type.ToString(), member.Summary);
            }
            else if (member.Type == MemberType.Overload)
            {
                sw.WriteLine("\n##### {0}", member.Name + member.ParametersText);

                if (!string.IsNullOrWhiteSpace(member.Summary))
                    sw.WriteLine("{0}", ReprocessSummary(member.Summary));
                //sw.WriteLine("##### {0}{1}\n\n{2}\n", member.Name, member.ParametersFullText, member.Summary);
                sw.WriteLine("```csharp\n{0}{1}\n```\n", member.Name, member.ParametersFullText);

                if (member.Parameters != null)
                {
                    sw.WriteLine("\n###### Parámetros\n");
                    sw.WriteLine("| Parámetro | Tipo  | Descripción |");
                    sw.WriteLine("| ---- | ---- | ---- |");
                    foreach (Parameters m in member.Parameters)
                    {
                        sw.WriteLine("| **{0}** | {1} | {2} |", m.Name, Utils.GetRefMsdn(m.TypeFull, ref paramDic, ref msdnDic), m.Summary);
                    }
                    sw.WriteLine();
                }

                if (!string.IsNullOrWhiteSpace(member.Return))
                    sw.WriteLine("\n###### Retorna\n\n{0}", member.Return);

                if (!string.IsNullOrWhiteSpace(member.Exception))
                    sw.WriteLine("\n###### Excepciones\n\n{0}", member.Exception);

                if (!string.IsNullOrWhiteSpace(member.Example))
                    sw.WriteLine("\n###### Ejemplos\n\n{0}", member.Example);

                if (!string.IsNullOrWhiteSpace(member.Remark))
                    sw.WriteLine("\n###### Observaciones\n\n{0}", member.Remark);

                if (!string.IsNullOrWhiteSpace(member.SeeAlso))
                    sw.WriteLine("\n###### Ver también\n\n{0}", member.SeeAlso);
            }
            else if (member.Type == MemberType.Method)
            {
                //sw.WriteLine("\n#### {0} `{1}`", member.Name, member.Type.ToString());
                sw.WriteLine("\n#### {0}", member.Name);

                if (member.Overloads != null)
                {
                    if (!string.IsNullOrWhiteSpace(member.Summary))
                        sw.WriteLine("{0}", ReprocessSummary(member.Summary));

                    sw.WriteLine("\n##### Lista de sobrecargas\n");
                    sw.WriteLine("| Sobrecarga | Descripción |");
                    sw.WriteLine("| ---- | ---- |");

                    // Como el elemento es una sobrecarga, se debe tratar por separado
                    string link = member.Name + member.ParametersText;
                    link = "#" + link.Replace(",", "").Replace("(", "").Replace(")", "").Replace("<", "").Replace(">", "").ToLower();
                    sw.WriteLine("| [{0}]({2}) | {1} |", member.Name + member.ParametersText, member.SummaryShort, link);

                    foreach (Member m in member.Overloads)
                    {
                        link = m.Name + m.ParametersText;
                        link = "#" + link.Replace(",", "").Replace("(", "").Replace(")", "").Replace("<", "").Replace(">", "").ToLower();
                        sw.WriteLine("| [{0}]({2}) | {1} |", m.Name + m.ParametersText, m.SummaryShort, link);
                    }
                    sw.WriteLine("\n");

                    sw.WriteLine("\n##### {0}", member.Name + member.ParametersText);

                    if (!string.IsNullOrWhiteSpace(member.Summary))
                        sw.WriteLine("{0}", ReprocessSummary(member.Summary));

                    sw.WriteLine("```csharp\n{0}{1}\n```\n", member.Name, member.ParametersFullText);

                    if (member.Parameters != null)
                    {
                        sw.WriteLine("\n###### Parámetros\n");
                        sw.WriteLine("| Parámetro | Tipo  | Descripción |");
                        sw.WriteLine("| ---- | ---- | ---- |");
                        foreach (Parameters m in member.Parameters)
                        {
                            sw.WriteLine("| **{0}** | {1}  | {2} |", m.Name, Utils.GetRefMsdn(m.TypeFull, ref paramDic, ref msdnDic), m.Summary);
                        }
                        sw.WriteLine();
                    }

                    if (!string.IsNullOrWhiteSpace(member.Return))
                        sw.WriteLine("\n###### Retorna\n\n{0}", member.Return);

                    if (!string.IsNullOrWhiteSpace(member.Exception))
                        sw.WriteLine("\n###### Excepciones\n\n{0}", member.Exception);

                    if (!string.IsNullOrWhiteSpace(member.Example))
                        sw.WriteLine("\n###### Ejemplos\n\n{0}", member.Example);

                    if (!string.IsNullOrWhiteSpace(member.Remark))
                        sw.WriteLine("\n###### Observaciones\n\n{0}", member.Remark);

                    if (!string.IsNullOrWhiteSpace(member.SeeAlso))
                        sw.WriteLine("\n###### Ver también\n\n{0}", member.SeeAlso);

                    foreach (Member m in member.Overloads)
                    {
                        ProcessDicMember(sw, m);
                        //sw.WriteLine("\n##### {0}", m.Name + m.ParametersText);

                        //sw.WriteLine("```csharp\n{0}{1}\n```\n", m.Name, m.ParametersFullText);

                        //if (m.Parameters != null)
                        //{
                        //    sw.WriteLine("\n##### Parámetros\n");
                        //    sw.WriteLine("| Parámetro | Tipo  | Descripción |");
                        //    sw.WriteLine("| ---- | ---- | ---- |");
                        //    foreach (Parameters mm in member.Parameters)
                        //    {
                        //        sw.WriteLine("| **{0}** | {1}  | {2} |", mm.Name, mm.Type, mm.Summary);
                        //    }
                        //    sw.WriteLine();
                        //}
                    }
                }
                else
                {
                    //sw.WriteLine("\n##### {0}", member.Name + member.ParametersText);

                    if (!string.IsNullOrWhiteSpace(member.Summary))
                        sw.WriteLine("\n{0}", ReprocessSummary(member.Summary));
                    //sw.WriteLine("##### {0}{1}\n\n{2}\n", member.Name, member.ParametersFullText, member.Summary);

                    if (string.IsNullOrWhiteSpace(member.Example))
                        sw.WriteLine("\n```csharp\n{0}{1}\n```\n", member.Name, member.ParametersFullText);

                    if (member.Parameters != null)
                    {
                        sw.WriteLine("\n###### Parámetros\n");
                        sw.WriteLine("| Parámetro | Tipo  | Descripción |");
                        sw.WriteLine("| ---- | ---- | ---- |");
                        foreach (Parameters m in member.Parameters)
                        {
                            sw.WriteLine("| **{0}** | {1} | {2} |", m.Name, Utils.GetRefMsdn(m.TypeFull, ref paramDic, ref msdnDic), m.Summary);
                        }
                        sw.WriteLine();
                    }

                    if (!string.IsNullOrWhiteSpace(member.Return))
                        sw.WriteLine("\n##### Retorna\n\n{0}", member.Return);

                    if (!string.IsNullOrWhiteSpace(member.Exception))
                        sw.WriteLine("\n##### Excepciones\n\n{0}", member.Exception);

                    if (!string.IsNullOrWhiteSpace(member.Example))
                        sw.WriteLine("\n##### Ejemplos\n\n{0}", member.Example);

                    if (!string.IsNullOrWhiteSpace(member.Remark))
                        sw.WriteLine("\n##### Observaciones\n\n{0}", member.Remark);

                    if (!string.IsNullOrWhiteSpace(member.SeeAlso))
                        sw.WriteLine("\n##### Ver también\n\n{0}", member.SeeAlso);
                }
            }
            else
            {
                sw.WriteLine("\n#### {0} {1}", member.Type.ToString(), member.Summary);
            }
        }

        string ReprocessSummary(string summary)
        {
            string result = string.Empty;

            if (summary.IndexOf("#RESCAN#") == -1)
            {
                return summary;
            }
            else
            {
                string[] sep = { "#RESCAN#" };
                string summaryBefore = summary.Split(sep, StringSplitOptions.RemoveEmptyEntries).First();
                string summaryAfter = summary.Split(sep, StringSplitOptions.RemoveEmptyEntries).Last();

                if (summaryAfter.StartsWith("M:"))
                {
                    string[] sep2 = { "#R#" };
                    string sufix = string.Empty;
                    if (!summaryAfter.EndsWith("#R#"))
                    {
                        sufix = summaryAfter.Split(sep2, StringSplitOptions.RemoveEmptyEntries).Last();
                        summaryAfter = summaryAfter.Split(sep2, StringSplitOptions.RemoveEmptyEntries).First();
                        if (!string.IsNullOrEmpty(sufix))
                        {
                            sufix = !sufix.StartsWith(" ") ? " " + sufix : sufix;
                        }
                    }
                    else
                    {
                        summaryAfter = summaryAfter.Split(sep2, StringSplitOptions.RemoveEmptyEntries).First();
                    }

                    string ns = Utils.NamespaceMember(summaryAfter);
                    string method = Utils.shortNameMember(summaryAfter.Substring(2));
                    string param1 = Utils.getParametersMember(summaryAfter.Substring(2));
                    if (mainDoc.ContainsKey(ns))
                    {
                        if ((mainDoc[ns]).Methods.ContainsKey(method))
                        {
                            //summaryAfter = $"[{method}](#{method.ToLower()}-method)";
                            summaryAfter = $"[{method}](#{method.ToLower()})";
                        }
                    }
                    summaryAfter += sufix;
                }
                result = summaryBefore + summaryAfter;
            }
            return result;
        }
    }
}
