// ryan and ahmad work copyright

using ConsoleApp1;


// need add esc last of page

BigOne a = new BigOne();


List<DirectPrintingScript> list = new List<DirectPrintingScript>();

/*list.Add(new DirectPrintingScript
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
);*/


list.Add(new DirectPrintingScript
{
    Value = "# order number #\n",
    PrintMethodID = new List<int> { ((int)Settings.DoubleWidth), ((int)Settings.DoubleHeight), ((int)Settings.JustificationCenter) },
    IsNeedPrint = true
});

list.Add(new DirectPrintingScript
{
    Value = "product name1     : 20$",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
});

list.Add(new DirectPrintingScript
{
    Value = "product name2     : 15$",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
});
list.Add(new DirectPrintingScript
{
    Value = "product name2     : 23$\n",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
});


list.Add(new DirectPrintingScript
{
    Value = "[section 1]",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
});

list.Add(new DirectPrintingScript
{
    Value = "others3          => text3",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
});

list.Add(new DirectPrintingScript
{
    Value = "others2          => text2",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
});
list.Add(new DirectPrintingScript
{
    Value = "others1          => text1",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
});


list.Add(new DirectPrintingScript
{
    Value = "---------------------------------------",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth), ((int)Settings.JustificationCenter) },
    IsNeedPrint = true
});


list.Add(new DirectPrintingScript
{
    Value = "footer text",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth) },
    IsNeedPrint = true
});

list.Add(new DirectPrintingScript
{
    Value = "good bye",
    PrintMethodID = new List<int> { ((int)Settings.JustificationLeft), ((int)Settings.CancelDoubleHeightWidth), ((int)Settings.JustificationCenter) },
    IsNeedPrint = true
});




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