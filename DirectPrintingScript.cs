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
            var job = new DirectPrinterProcess();
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;

            IPAddress ip = IPAddress.Parse(IP);
            IPEndPoint ipep = new IPEndPoint(ip, Port);
           
            clientSocket.Connect(ipep);
            
            foreach (DirectPrintingScript item in result)
            {

                //job.CancelDoubleHeightWidth();
                foreach (int tempID in item.PrintMethodID) {                
                    clientSocket.Send(Encoding.UTF8.GetBytes(job.SelectMethod(tempID)));
                }

                //var command = job.SelectMethod(item.PrintMethodID);
                //byte[] commandBytes = Encoding.UTF8.GetBytes(command);
                //clientSocket.Send(commandBytes);

                byte[] contentBytes = Encoding.UTF8.GetBytes(item.Value);
          
                if (item.IsNeedPrint)
                {
                    clientSocket.Send(contentBytes);               
                    clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));               
                }
            }

            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            clientSocket.Send(Encoding.UTF8.GetBytes(job.NewLine()));
            /*byte[] bEsc = new byte[6];
            bEsc[0] = 0x0A;
            bEsc[1] = 0x0A;
            bEsc[2] = 0x0A;
            bEsc[3] = 0x0A;
            bEsc[4] = 0x0A;
            clientSocket.Send(bEsc);*/

            clientSocket.Close();
        }



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

            public string Lines()
            {
                return "" + "\n\n\n\n\n\n\n\n\n";
            }
        }



    }
}
