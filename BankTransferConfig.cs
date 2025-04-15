using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class BankTransferConfig
{
    public class Transfer
    {
        public string threshold { get; set; }
        public string low_fee { get; set; }
        public string high_fee { get; set; }
    }
    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }
    public string lang { get; set; }

    public Transfer transfer { get; set; }

    public string[] methods { get; set; }

    public Confirmation confirmation { get; set; }
    public BankTransferConfig()
    {
    }
    public BankTransferConfig(string lang, Transfer transfer, string[] methods, Confirmation confirmation)
    {
        this.lang = lang;
        this.transfer = transfer;
        this.methods = methods;
        this.confirmation = confirmation;
    }
}

class BankConfigUI
{
    public BankTransferConfig config { get; set; }
    public const string configFile = "bank_transfer_config.json";
    private BankTransferConfig ReadConfig()
    {
        string configData = File.ReadAllText(configFile);
        config = JsonSerializer.Deserialize<BankTransferConfig>(configData);
        return config;
    }
    private void WriteConfig()
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(configFile, jsonString);
    }

    private void setDefaultConfig()
    {
        config = new BankTransferConfig
        {
            lang = "en",
            transfer = new BankTransferConfig.Transfer
            {
                threshold = "25000000",
                low_fee = "6500",
                high_fee = "15000"
            },
            methods = new string[] { "RTO(real - time)", "SKN", "RTGS", "BI FAST" },
            confirmation = new BankTransferConfig.Confirmation
            {
                en = "Yes",
                id = "Ya"
            }
        };
        WriteConfig();
    }
    public BankConfigUI()
    {
        try
        {
            config = ReadConfig();
        }
        catch (FileNotFoundException)
        {
            setDefaultConfig();
            WriteConfig();
        }
    }
}
