using System;
using System.IO;
using System.Text.Json;

namespace tpmodul8_103022300158
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        private static readonly string configFile = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\covid_config.json"));

        public CovidConfig()
        {
            satuan_suhu = "celcius";
            batas_hari_deman = 14;
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else
            {
                satuan_suhu = "celcius";
            }
            SimpanKeFile();
        }

        public static CovidConfig LoadConfig()
        {
            CovidConfig config;
            if (File.Exists(configFile))
            {
                string json = File.ReadAllText(configFile);
                config = JsonSerializer.Deserialize<CovidConfig>(json);
            }
            else
            {
                config = new CovidConfig();
                config.SimpanKeFile();
            }
            return config;
        }

        private void SimpanKeFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(configFile, json);
        }
    }
}
