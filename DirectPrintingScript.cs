using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    //model
    public class DirectPrintingScript
    {
        public string Value { get; set; }
        public List<int> PrintMethodID { get; set; }
        public bool IsNeedPrint { get; set; }
    }

    public class BigOne
    {
        public void print(List<DirectPrintingScript> result, string IP, int Port)
        {
            // it is 
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
                foreach (int tempID in item.PrintMethodID)
                {
                    clientSocket.Send(Encoding.UTF8.GetBytes(job.SelectMethod(tempID)));
                }

                // here get info form list
                byte[] contentBytes = Encoding.UTF8.GetBytes(item.Value);

                // print and add white space
                if (item.IsNeedPrint)
                {
                    clientSocket.Send(contentBytes);
                    clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
                }
            }

            //for more space for cut bill
            for (int i = 0; i < 10; i++) clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));

            //close conncetion with socket
            clientSocket.Close();
        }



        //class to make format
        public class DirectPrinterProcess
        {
            public string SelectMethod(int MethodID)
            {
                switch (MethodID)
                {
                    case 0:
                        return JustificationCenter();
                    case 1:
                        return JustificationLeft();
                    case 2:
                        return DoubleHeight();
                    case 3:
                        return DoubleWidth();
                    case 4:
                        return CancelDoubleHeightWidth();
                    default:
                        return CancelDoubleHeightWidth();
                }
            }


            // all this is format
            private string JustificationCenter()
            {
                return "" + (char)27 + (char)97 + (char)1;
            }

            private string JustificationLeft()
            {
                return "" + (char)27 + (char)97 + (char)0;
            }

            private string DoubleHeight()
            {
                return "" + (char)27 + (char)33 + (char)16;
            }

            private string DoubleWidth()
            {
                return "" + (char)27 + (char)33 + (char)32;
            }

            public string CancelDoubleHeightWidth()
            {
                return "" + (char)27 + (char)33 + (char)0;
            }

            public string NewLine()
            {
                return "" + "\n";
            }

        }



    }
}
