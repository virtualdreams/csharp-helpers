using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CS.Helpers
{
	public static class XDocumentExtensions
	{
		/// <summary>
		/// Set the default xml namespace for given element
		/// </summary>
		public static void SetDefaultXmlNamespace(this XElement element, XNamespace ns)
		{
			if (element.Name.NamespaceName == string.Empty)
			{
				element.Name = ns + element.Name.LocalName;
			}
			foreach (var e in element.Elements())
			{
				e.SetDefaultXmlNamespace(ns);
			}
		}
	}
}
