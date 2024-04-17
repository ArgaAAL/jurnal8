using System;
using System.IO;
using System.Text.Json;

public class BankTransferConfig
{
    private const string configFile = "bank_transfer_config.json";
    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };
    private ConfigData configData;

    public BankTransferConfig()
    {
        if (File.Exists(configFile))
        {
            string configText = File.ReadAllText(configFile);
            configData = JsonSerializer.Deserialize<ConfigData>(configText);
        }
        else
        {
            configData = new ConfigData
            {
                Lang = "en",
                Transfer = new TransferConfig
                {
                    Threshold = 25000000,
                    LowFee = 6500,
                    HighFee = 15000
                },
                Methods = new string[] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
                Confirmation = new ConfirmationConfig
                {
                    En = "yes",
                    Id = "ya"
                }
            };
            SimpanPerubahan();
        }
    }

    public string Lang
    {
        get { return configData.Lang; }
        set { configData.Lang = value; }
    }

    public TransferConfig Transfer
    {
        get { return configData.Transfer; }
    }

    public string[] Methods
    {
        get { return configData.Methods; }
    }

    public ConfirmationConfig Confirmation
    {
        get { return configData.Confirmation; }
    }

    public void SimpanPerubahan()
    {
        string json = JsonSerializer.Serialize(configData, options);
        File.WriteAllText(configFile, json);
    }

    public class ConfigData
    {
        public string Lang { get; set; }
        public TransferConfig Transfer { get; set; }
        public string[] Methods { get; set; }
        public ConfirmationConfig Confirmation { get; set; }
    }

    public class TransferConfig
    {
        public int Threshold { get; set; }
        public int LowFee { get; set; }
        public int HighFee { get; set; }
    }

    public class ConfirmationConfig
    {
        public string En { get; set; }
        public string Id { get; set; }
    }
}
