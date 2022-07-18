using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CloudPrinter
{
    // enum to select format of text
    enum Settings
    {
        JustificationCenter,
        JustificationLeft,
        DoubleHeight,
        DoubleWidth,
        CancelDoubleHeightWidth,
    }  

     class Printer
    {
        public void print(List<DirectPrintingScript> result, string IP, int Port)
        {
            var job = new DirectPrinterProcess();
            // make socket to send info to printer
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;
            //handle ip and convert string ip to ipaddress
            IPAddress ip = IPAddress.Parse(IP);
            IPEndPoint ipep = new IPEndPoint(ip, Port);

            //connect with printer
            clientSocket.Connect(ipep);

            //loop to print all bill
            foreach (DirectPrintingScript item in result)
            {
                //add format
                foreach (var tempID in item.PrintMethodID)
                {
                    clientSocket.Send(Encoding.UTF8.GetBytes(job.SelectMethod((int)tempID)));
                }

                // here get info form list
                byte[] contentBytes = Encoding.UTF8.GetBytes(item.Value);

                // print and add white space
                clientSocket.Send(contentBytes);
                clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            }

            //for more space for cut bill
            for (int i = 0; i < 10; i++) clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            //close conncetion with socket
            clientSocket.Close();
        }

    }
}
