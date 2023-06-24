using Mediator;

Console.Title = "Mediator";

var teamChatroom = new TeamChatRoom();

var sven = new Lawyer("Sven");
var kenneth = new Lawyer("Kenneth");
var ann = new AccountManager("Ann");
var john = new AccountManager("John");
var kylie = new AccountManager("Kylie");

teamChatroom.Register(sven);
teamChatroom.Register(kenneth);
teamChatroom.Register(ann);
teamChatroom.Register(john);
teamChatroom.Register(kylie);

ann.Send("Please take care of file ABC123");
sven.Send("On it");
