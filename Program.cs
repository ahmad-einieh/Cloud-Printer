using ConsoleApp1;

Printer printer = new Printer();

// this is print list
List<DirectPrintingScript> list = new List<DirectPrintingScript>();

// if you want use dynammic value you need handle string and count number of char to make good bill

list.Add(new DirectPrintingScript
{
    Value = "# order number #\n",
    PrintMethodID = new List<Settings> { Settings.DoubleWidth, Settings.DoubleHeight, Settings.JustificationCenter}
});

list.Add(new DirectPrintingScript
{
    Value = "product name1     : 20$",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft, Settings.CancelDoubleHeightWidth}
});

list.Add(new DirectPrintingScript
{
    Value = "product name2     : 15$",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft, Settings.CancelDoubleHeightWidth}
});
list.Add(new DirectPrintingScript
{
    Value = "product name2     : 23$\n",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft, Settings.CancelDoubleHeightWidth}
});


list.Add(new DirectPrintingScript
{
    Value = "[section 1]",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft,Settings.CancelDoubleHeightWidth}
});

list.Add(new DirectPrintingScript
{
    Value = "others3          => text3",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft, Settings.CancelDoubleHeightWidth}
});

list.Add(new DirectPrintingScript
{
    Value = "others2          => text2",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft, Settings.CancelDoubleHeightWidth}
});
list.Add(new DirectPrintingScript
{
    Value = "others1          => text1",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft, Settings.CancelDoubleHeightWidth}
});


list.Add(new DirectPrintingScript
{
    Value = "---------------------------------------",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft, Settings.CancelDoubleHeightWidth, Settings.JustificationCenter}
});


list.Add(new DirectPrintingScript
{
    Value = "footer text",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft, Settings.CancelDoubleHeightWidth}
});

list.Add(new DirectPrintingScript
{
    Value = "good bye",
    PrintMethodID = new List<Settings> { Settings.JustificationLeft, Settings.CancelDoubleHeightWidth, Settings.JustificationCenter}
});

// here static ip we add it to printer when config it
printer.print(list, "172.20.6.58", 9100);


// enum to select format of text
