XDocumentExtensions:

var doc = new XDocument(
	new XDeclaration("1.0", "utf-8", "yes"),
	new XElement("root",
		new XElement("child1", "value"),
		new XElement("child2",
			new XAttribute("name", "value"),
			new XElement("child3", "value")
			)
		)
	);

return doc.ToStringWithDeclaration();