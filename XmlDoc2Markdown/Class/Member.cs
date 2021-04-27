using System.Collections.Generic;

namespace XmlDoc2Markdown
{
    public class Member
    {
        public MemberType Type;
        public string Id;
        public string Name;
        public string Namespace;
        public string Summary;
        public string SummaryShort;
        public string ParametersText;
        public string ParametersFullText;
        public List<Parameters> Parameters;
        public string Return;
        public string Exception;
        public string Example;
        public string Remark;
        public string SeeAlso;
        public List<Member> Overloads;
        public List<Member> Constructors;
        public List<Member> Fields;
        public List<Member> Properties;
        public Dictionary<string, Member> Methods;
    }
}
