// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

// ryan and ahmad work copyright
List<DirectPrintingScript> list = new List<DirectPrintingScript>();
list.Add(new DirectPrintingScript {Value = "rayan and ahmad are the best\n",PrintMethodID = 0, IsNeedPrint= true });
list.Add(new DirectPrintingScript {Value = "it is print from our device\n",PrintMethodID = 0, IsNeedPrint= true });
BigOne a = new BigOne();
a.print(list,"172.20.6.55", 9100);


