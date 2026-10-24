# Cloud Printer

A C#/.NET 6 receipt-printing experiment originally intended for Foodics/Sunmi-style network printers. It sends formatted receipt content to a configured printer IP/TCP port, not a hosted cloud-printing service.

## Setup and safety

Requires .NET 6, network access, and a compatible printer you control. Review `Program.cs`, replace its hardcoded address/port, and edit its receipt list before running `dotnet restore` and `dotnet run`. **Running the sample can physically print receipts.** Use a development printer, not production hardware. Drawing-dependent paths use `System.Drawing.Common` 6 and have platform limitations; prefer Windows.

`Printer.cs` contains printing, `DirectPrinterProcess.cs` handles text processing, and `DirectPrintingScript.cs` models content/formatting. Validate encoding, width, and commands on actual hardware. No hardware tests were performed for this documentation refresh.

## Original usage notes

print bill on foodics or sunmi cloud printer

----------------------------------------------

you can start test from program.cs file printer.cs file it is have print method if you want see it.

DirectPrinterProcess.cs it is for only edit text when want to print bill.

DirectPrintingScript.cs it is just a model to give string and format of text to print method.

-------------------------------------------------------------------------


you need to fill print method with ip address and port number to start print process 
and you need give list of DirectPrintingScript.cs to print method as example in program.cs file.

-----------------------------------------------------------

thanks
