BankTransferConfig config = new BankTransferConfig();

string langPrompt = config.Lang == "en" ? "Please insert the amount of money to transfer:" : "Masukkan jumlah uang yang akan di-transfer:";
Console.WriteLine(langPrompt);
int amount = int.Parse(Console.ReadLine());

int fee = amount <= config.Transfer.Threshold ? config.Transfer.LowFee : config.Transfer.HighFee;
int totalAmount = amount + fee;

string feeOutput = config.Lang == "en" ? "Transfer fee = " : "Biaya transfer = ";
string totalOutput = config.Lang == "en" ? "Total amount = " : "Total biaya = ";
Console.WriteLine($"{feeOutput} {fee}");
Console.WriteLine($"{totalOutput} {totalAmount}");

string methodPrompt = config.Lang == "en" ? "Select transfer method:" : "Pilih metode transfer:";
Console.WriteLine(methodPrompt);
for (int i = 0; i < config.Methods.Length; i++)
{
    Console.WriteLine($"{i + 1}. {config.Methods[i]}");
}

Console.Write("Select transfer method number: ");
int selectedMethodIndex = int.Parse(Console.ReadLine());

Console.WriteLine($"Selected transfer method: {config.Methods[selectedMethodIndex - 1]}");


string confirmationPrompt = config.Lang == "en" ? $"Please type \"{config.Confirmation.En}\" to confirm the transaction:" : $"Ketik \"{config.Confirmation.Id}\" untuk mengkonfirmasi transaksi:";
Console.WriteLine(confirmationPrompt);
string confirmation = Console.ReadLine();

string successMessage = config.Lang == "en" ? "The transfer is completed" : "Proses transfer berhasil";
string failureMessage = config.Lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan";
if (confirmation == config.Confirmation.En || confirmation == config.Confirmation.Id)
{
    Console.WriteLine(successMessage);
}
else
{
    Console.WriteLine(failureMessage);
}
