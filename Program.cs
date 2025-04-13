// See https://aka.ms/new-console-template for more information
using System.Globalization;
using tpmodul8_103022300158;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = int.Parse(Console.ReadLine());

        bool suhuValid = config.satuan_suhu.ToLower() switch
        {
            "celcius" => suhu >= 36.5 && suhu <= 37.5,
            "fahrenheit" => suhu >= 97.7 && suhu <= 99.5,
            _ => false
        };

        bool hariValid = hari < config.batas_hari_deman;

        Console.WriteLine(suhuValid && hariValid ?
            config.pesan_diterima :
            config.pesan_ditolak);

        config.UbahSatuan();
        Console.WriteLine($"Satuan suhu telah diubah ke {config.satuan_suhu}");

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        suhu = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        hari = int.Parse(Console.ReadLine());

        suhuValid = config.satuan_suhu.ToLower() switch
        {
            "celcius" => suhu >= 36.5 && suhu <= 37.5,
            "fahrenheit" => suhu >= 97.7 && suhu <= 99.5,
            _ => false
        };

        hariValid = hari < config.batas_hari_deman;

        Console.WriteLine(suhuValid && hariValid ?
            config.pesan_diterima :
            config.pesan_ditolak);
    }
}