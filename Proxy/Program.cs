Console.Title = "Proxy";

Console.WriteLine("Constructing document");

var myDocument = new Proxy.Document("MyDocument.pdf");
Console.WriteLine("Document constructed");
myDocument.DisplayDocument();

Console.WriteLine();

Console.WriteLine("Constructing document proxy");
var myDocumentProxy = new Proxy.DocumentProxy("MyDocument.pdf");
Console.WriteLine("Document proxy constructed");
myDocumentProxy.DisplayDocument();

var protectedDocumentProxy = new Proxy.ProtectedDocumentProxy("MyDocument.pdf", "Viewer");
protectedDocumentProxy.DisplayDocument();

Console.WriteLine("===========");

var protectedDocumentProxyNoAccess = new Proxy.ProtectedDocumentProxy("MyDocument.pdf", "");
protectedDocumentProxyNoAccess.DisplayDocument();
