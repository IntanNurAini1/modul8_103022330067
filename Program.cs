class Program
{
    static void Main(string[] args)
    {
        BankConfigUI bankConfigUI = new BankConfigUI();
        Console.WriteLine("Language en or id");
        bankConfigUI.config.lang = Console.ReadLine();
        if (bankConfigUI.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
            string amount = Console.ReadLine();
            if (int.TryParse(amount, out int amountValue))
            {
                if (amountValue <= Convert.ToInt32(bankConfigUI.config.transfer.threshold))
                {
                    Console.WriteLine("Your transfer is below the maximum threshold.");
                    int fee = Convert.ToInt32(bankConfigUI.config.transfer.low_fee);
                    int hasil = amountValue + fee;
                    Console.WriteLine("Total amount : " + hasil);
                    Console.WriteLine("Select transfer method:");
                    foreach (var method in bankConfigUI.config.methods)
                    {
                        Console.WriteLine(method);
                    }
                    string selectedMethod = Console.ReadLine();
                    Console.WriteLine("Please type 'Yes' to confirm the transaction");
                    string confirmation = Console.ReadLine();
                    if (confirmation == "Yes")
                    {
                        Console.WriteLine("The transfer is completed");
                    }
                    else
                    {
                        Console.WriteLine("Transfer is cancelled.");
                    }

                }
                else if (amountValue > Convert.ToInt32(bankConfigUI.config.transfer.threshold))
                {
                    Console.WriteLine("Your transfer is above the maximum threshold.");
                    int fee = Convert.ToInt32(bankConfigUI.config.transfer.high_fee);
                    int hasil = amountValue + fee;
                    Console.WriteLine("Total amount : " + hasil);
                    Console.WriteLine("Select transfer method:");
                    foreach (var method in bankConfigUI.config.methods)
                    {
                        Console.WriteLine(method);
                    }
                    string selectedMethod = Console.ReadLine();
                    Console.WriteLine("Please type 'Yes' to confirm the transaction");
                    string confirmation = Console.ReadLine();
                    if (confirmation == "Yes")
                    {
                        Console.WriteLine("The transfer is completed");
                    }
                    else
                    {
                        Console.WriteLine("Transfer is cancelled.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Masukan nominal yang ingin ditransfer :");
                string amounts = Console.ReadLine();
                if (int.TryParse(amounts, out int amountValues))
                {
                    if (amountValues <= Convert.ToInt32(bankConfigUI.config.transfer.threshold))
                    {
                        Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
                        int fee = Convert.ToInt32(bankConfigUI.config.transfer.low_fee);
                        int hasil = amountValue + fee;
                        Console.WriteLine("Total biaya : " + hasil);
                        Console.WriteLine("Pilih metode transfer: ");
                        foreach (var method in bankConfigUI.config.methods)
                        {
                            Console.WriteLine(method);
                        }
                        string selectedMethod = Console.ReadLine();
                        Console.WriteLine(" Ketik 'Ya' untuk mengkonfirmasi transaksi");
                        string confirmation = Console.ReadLine();
                        if (confirmation == "Ya")
                        {
                            Console.WriteLine("Proses transfer berhasil");
                        }
                        else
                        {
                            Console.WriteLine("Proses transfer dibatalkan");
                        }

                    }
                    else if (amountValue > Convert.ToInt32(bankConfigUI.config.transfer.threshold))
                    {
                        Console.WriteLine("Your transfer is above the maximum threshold.");
                        int fee = Convert.ToInt32(bankConfigUI.config.transfer.high_fee);
                        int hasil = amountValue + fee;
                        Console.WriteLine("Total amount : " + hasil);
                        Console.WriteLine("Select transfer method:");
                        foreach (var method in bankConfigUI.config.methods)
                        {
                            Console.WriteLine(method);
                        }
                        string selectedMethod = Console.ReadLine();
                        Console.WriteLine(" Ketik 'Ya' untuk mengkonfirmasi transaksi");
                        string confirmation = Console.ReadLine();
                        if (confirmation == "Yes")
                        {
                            Console.WriteLine("Proses transfer berhasil");
                        }
                        else
                        {
                            Console.WriteLine("Proses transfer dibatalkan");
                        }
                    }
                }
        }
    }
}