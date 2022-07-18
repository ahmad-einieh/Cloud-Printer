// ryan and ahmad work copyright

using ConsoleApp1;

BigOne a = new BigOne();


List<DirectPrintingScript> list = new List<DirectPrintingScript>();

list.Add(new DirectPrintingScript
{
    Value = "# order number #\n",
    PrintMethodID = new List<int> { ((int)Settings.DoubleWidth), ((int)Settings.DoubleHeight), ((int)Settings.JustificationCenter) }
    ,
    IsNeedPrint = true
}
);

list.Add(new DirectPrintingScript
{
    Value = "it is test order be careful 1\n",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
}
);

list.Add(new DirectPrintingScript
{
    Value = "it is test order be careful 2\n",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
}
);

a.print(list, "172.20.6.58", 9100);

Console.WriteLine("done");

enum Settings
{
    JustificationCenter,
    JustificationLeft,
    DoubleHeight,
    DoubleWidth,
    CancelDoubleHeightWidth,
}