using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Framework.Extensions
{
	public static class XDocumentExtensions
	{
		public static string ToStringWithDeclaration(this XDocument doc)
		{
			if (doc == null)
			{
				throw new ArgumentNullException(nameof(doc));
			}
			var builder = new StringBuilder();
			using (TextWriter writer = new Utf8StringWriter(builder))
			{
				doc.Save(writer);
			}
			return builder.ToString();
		}
	}

	public sealed class Utf8StringWriter : StringWriter
	{
		public override Encoding Encoding => Encoding.UTF8;

		public Utf8StringWriter(StringBuilder builder) : base(builder)
		{
		}
	}
}