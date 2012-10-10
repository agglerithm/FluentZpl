using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ZplLabels
{
	/// <summary>
	/// Summary description for IniFile.
	/// </summary>
	public class IniFile : XElement
	{
		protected string full_buff;
		protected XElement configSections;
        protected XElement doc_el;
        protected XElement last_node;
		protected string [] lines;
        public IniFile(string path)
            : base(Parse("<configuration><configSections></configSections></configuration>"))
		{   
			configSections = Elements().First();
			GetLines(path);
			for(int i = 0; i < lines.Length; i++)
			{ 
				if(lines[i].Substring(0,1) == "[")
					AddConfigSection(lines[i].Replace("[","").Replace("]",""));
				else
				{
					AddValue(lines[i]);
				}
			}
		}

		protected void AddConfigSection(string name)
		{
			var temp = new XElement("section");
			temp.Add(new XAttribute("name",name));  
			temp.Add(new XAttribute("type","System.Configuration.SingleTagSectionHandler")); 
			configSections.Add(temp); 
			last_node = new XElement(name); 
			Add(last_node);
 		}

		protected void AddValue(string name_val)
		{
			string [] temp = name_val.Split("=".ToCharArray());
			if(temp.Length != 2) return;
			temp[0] = temp[0].Trim();
			temp[1] = temp[1].Trim(); 
            last_node.Add(new XAttribute(temp[0], temp[1]));
		}

		protected void GetLines(string path)
		{

			var sr = new StreamReader(path);
			string temp = sr.ReadToEnd();
			sr.Close();
			temp = temp.Replace( "\r\n","~");
			lines = temp.Split("~".ToCharArray());
			CleanLines();

		}

		protected void CleanLines()
		{
			int count = 0;
		    var nums = new int[lines.Length];
			for(int i = 0; i < lines.Length; i++)
			{
			    int pos = lines[i].IndexOf('*');
			    if(pos == 0) 
				{
					lines[i] = "";
					nums[count] = i;
					count++;
				}
				else
				{
					if(pos != -1)
						lines[i] = lines[i].Substring(0,pos - 1);
					else
					{
						if(lines[i] == "")
						{
							lines[i] = "";
							nums[count] = i;
							count++;
						}
					}
				}
			}
		    var temp = new string[lines.Length - count];
			int j = 0; 
			for(int i = 0; i < lines.Length; i++)
			{
				if(i == nums[j])
					j++;
				else
					temp[i - j] = lines[i];
			}
			lines = temp;		
				
		}

		public XElement this[string Index]
		{
			get 
			{
				return FindNode(Index);
			}
		}

		protected XElement FindNode(string name)
		{
		    XElement fc = Elements().First();
			if(fc.Name == name)
				return fc;
		    XElement lc = Elements().Last();
			if(lc.Name == name)
				return lc;
		    XElement temp = fc.ElementsAfterSelf().First();
			while(temp != lc)
			{
				if(temp.Name == name)
					return temp;
			}
			return null;
		}
	}
}
