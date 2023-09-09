using System.ComponentModel.DataAnnotations;
using ChainOfResponsibility;

Console.Title = "Chain of Responsibility";

var validDocument =
    new Document("How to avoid java development", DateTimeOffset.UtcNow, true, true);
var invalidDocument
    = new Document("How to avoid java development", DateTimeOffset.UtcNow, false, true);

var documentHandlerChain = new DocumentTitleHandler();

documentHandlerChain
    .SetSuccessor(new DocumentLastModifiedHandler())
    .SetSuccessor(new DocumentApprovedByLitigationHandler())
    .SetSuccessor(new DocumentApprovedByManagementHandler());

try
{
    documentHandlerChain.Handle(validDocument);
    Console.WriteLine("Valid document is valid");
    documentHandlerChain.Handle(invalidDocument);
    Console.WriteLine("Valid document is invalid");
}
catch (ValidationException validationException)
{
    Console.WriteLine(validationException.Message);
}