namespace Proxy
{
    public interface IDocument
    {
        void DisplayDocument();
    }
    public class Document : IDocument
    {
        private readonly string _fileName;
        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int AuthorId { get; private set; }
        public DateTimeOffset LastAccessed { get; private set; }

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Executing expensive action: loading a file from disk");
            Thread.Sleep(1000);

            Title = "An expensive document";
            Content = "Lots and lots of content";
            AuthorId = 1;
            LastAccessed = DateTimeOffset.Now;
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }
    }

    public class DocumentProxy : IDocument
    {
        private Lazy<Document> _document;
        private string _fileName;

        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }
        public void DisplayDocument()
        {
            _document.Value.DisplayDocument();
        }
    }
    
    public class ProtectedDocumentProxy: IDocument
    {
        private readonly string _fileName;
        private readonly string _userRole;
        private DocumentProxy _documentProxy;
        public ProtectedDocumentProxy(string fileName, string userRole)
        {
            _fileName = fileName;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(fileName);
        }
        
        public void DisplayDocument()
        {
            Console.WriteLine($"Entering DisplayDocument in {nameof(ProtectedDocumentProxy)}");

            if (_userRole != "Viewer")
            {
                throw new UnauthorizedAccessException();
            }
            
            _documentProxy.DisplayDocument();
            
            Console.WriteLine($"Exiting Display Document in {nameof(ProtectedDocumentProxy)}");
        }
    }
}