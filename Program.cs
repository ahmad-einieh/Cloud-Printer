// ryan and ahmad work copyright

using ConsoleApp1;

BigOne a = new BigOne();

List<DirectPrintingScript> list = new List<DirectPrintingScript>();
list.Add(new DirectPrintingScript { Value = "rayan and ahmad are the best\n", PrintMethodID = [0], IsNeedPrint = true });
list.Add(new DirectPrintingScript {Value = "it is print from our device\n",PrintMethodID = [0], IsNeedPrint= true });


a.print(list, "172.20.6.58", 9100);

Console.WriteLine("done");
