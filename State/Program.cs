using State;

Console.Title = "State";

var bankAccount = new BankAccount();
bankAccount.Withdraw(300);
bankAccount.Withdraw(300);
bankAccount.Deposit(1000);
bankAccount.Deposit(1000);
bankAccount.Deposit(1000);
bankAccount.Deposit(1000);
bankAccount.Withdraw(1000);
bankAccount.Withdraw(1000);
bankAccount.Withdraw(1000);
bankAccount.Withdraw(1000);
bankAccount.Withdraw(1000);
bankAccount.Withdraw(1000);
