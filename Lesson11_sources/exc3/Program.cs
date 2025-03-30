Console.WriteLine("Введите номер счета отправителя:");
string fromAccount = Console.ReadLine() ?? "ACC001";

Console.WriteLine("Введите номер счета получателя:");
string toAccount = Console.ReadLine() ?? "ACC002";

Console.WriteLine("Введите сумму перевода:");
decimal amount = decimal.Parse(Console.ReadLine() ?? "100");

BankAccountService receiver = new BankAccountService();
ICommand transferCommand = new TransferMoneyCommand(receiver, amount, fromAccount, toAccount);

BankingTerminal terminal = new BankingTerminal();
terminal.SetCommand(transferCommand);
terminal.ExecuteCommand();

interface ICommand
{
    void Execute();
}

class TransferMoneyCommand : ICommand
{
    private readonly BankAccountService _receiver;
    private readonly decimal _amount;
    private readonly string _fromAccount;
    private readonly string _toAccount;

    public TransferMoneyCommand(BankAccountService receiver, decimal amount, string fromAccount, string toAccount)
    {
        _receiver = receiver;
        _amount = amount;
        _fromAccount = fromAccount;
        _toAccount = toAccount;
    }

    public void Execute()
    {
        _receiver.Transfer(_amount, _fromAccount, _toAccount);
    }
}

class BankAccountService
{
    public void Transfer(decimal amount, string fromAccount, string toAccount)
    {
        Console.WriteLine($"Перевод {amount} руб. со счета {fromAccount} на счет {toAccount}");
    }
}

class BankingTerminal
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}