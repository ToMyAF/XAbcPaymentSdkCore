using System;
using System.Collections;

namespace XAbcPaymentSdkCore.Client
{
	// Token: 0x0200004B RID: 75
	public class XMLDocument
	{
		// Token: 0x06000195 RID: 405 RVA: 0x00011C4C File Offset: 0x00010C4C
		public virtual string getFirstTagName()
		{
			string result = null;
			int num = this.iXMLString.IndexOf('<');
			int num2 = this.iXMLString.IndexOf('>');
			if (num2 > num)
			{
				result = this.iXMLString.Substring(num + 1, num2 - (num + 1));
			}
			return result;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00011C9E File Offset: 0x00010C9E
		public XMLDocument()
		{
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00011CB4 File Offset: 0x00010CB4
		public XMLDocument(string aXMLString)
		{
			this.init(aXMLString);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00011CD4 File Offset: 0x00010CD4
		public XMLDocument init(string aXMLString)
		{
			this.iXMLString = aXMLString;
			return this;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00011CF0 File Offset: 0x00010CF0
		public override string ToString()
		{
			return this.iXMLString;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00011D08 File Offset: 0x00010D08
		public virtual XMLDocument getValue(string aTag)
		{
			XMLDocument result = null;
			int num = this.iXMLString.IndexOf("<" + aTag.Trim() + ">");
			int num2 = this.iXMLString.IndexOf("</" + aTag.Trim() + ">");
			if (num >= 0 && num2 >= 0 && num < num2)
			{
				result = new XMLDocument(this.iXMLString.Substring(num + aTag.Length + 2, num2 - (num + aTag.Length + 2)));
			}
			return result;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00011DA0 File Offset: 0x00010DA0
		public virtual string getValueNoNull(string aTag)
		{
			string result = "";
			XMLDocument value = this.getValue(aTag);
			if (value != null)
			{
				result = value.ToString();
			}
			return result;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00011DD4 File Offset: 0x00010DD4
		public virtual ArrayList getDocuments(string aTag)
		{
			string text = this.iXMLString;
			ArrayList arrayList = new ArrayList();
			for (;;)
			{
				int num = text.IndexOf("<" + aTag.Trim() + ">");
				int num2 = text.IndexOf("</" + aTag.Trim() + ">");
				if (num == -1 || num2 == -1 || num > num2)
				{
					break;
				}
				XMLDocument value = new XMLDocument(text.Substring(num, num2 + aTag.Length + 3 - num));
				arrayList.Add(value);
				text = text.Substring(num2 + 1);
			}
			return arrayList;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00011E8C File Offset: 0x00010E8C
		public virtual XMLDocument getFormatDocument(string aSpace)
		{
			return this.getFormatDocument(0, aSpace);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00011EA8 File Offset: 0x00010EA8
		private XMLDocument getFormatDocument(int aLevel, string aSpace)
		{
			string text = aSpace;
			for (int i = 0; i < aLevel; i++)
			{
				text += aSpace;
			}
			string firstTagName = this.getFirstTagName();
			XMLDocument result;
			if (firstTagName == null)
			{
				result = this;
			}
			else
			{
				string text2 = "\n";
				XMLDocument xmldocument = new XMLDocument(this.iXMLString);
				while ((firstTagName = xmldocument.getFirstTagName()) != null)
				{
					XMLDocument value = xmldocument.getValue(firstTagName);
					string text3 = "";
					if (value.getFirstTagName() != null)
					{
						text3 = text;
					}
					text2 = string.Concat(new object[]
					{
						text2,
						text,
						"<",
						firstTagName,
						">",
						value.getFormatDocument(aLevel + 1, aSpace),
						text3,
						"</",
						firstTagName,
						">\n"
					});
					xmldocument = xmldocument.deleteFirstTagDocument();
				}
				result = new XMLDocument(text2);
			}
			return result;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00011FB8 File Offset: 0x00010FB8
		public virtual XMLDocument deleteFirstTagDocument()
		{
			string firstTagName = this.getFirstTagName();
			int num = this.iXMLString.IndexOf("<" + firstTagName + ">");
			int num2 = this.iXMLString.IndexOf("</" + firstTagName + ">");
			if (num2 > num)
			{
				this.iXMLString = this.iXMLString.Substring(num2 + firstTagName.Length + 3);
			}
			return this;
		}

		// Token: 0x040001AE RID: 430
		private string iXMLString = "";
	}
}
