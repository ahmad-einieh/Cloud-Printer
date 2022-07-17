﻿using System;
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
        public int PrintMethodID { get; set; }
        public bool IsNeedPrint { get; set; }
    }
    public class BigOne
    {

        public  byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        //--printer script model


        //--print method

        public void print(List<DirectPrintingScript> result, string IP, int Port)
        {
            var job = new DirectPrinterProcess();
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;

            IPAddress ip = IPAddress.Parse(IP);
            IPEndPoint ipep = new IPEndPoint(ip, Port);
           
            clientSocket.Connect(ipep);
            //Encoding enc = Encoding.ASCII;
            //Encoding.UTF8
            
            foreach (DirectPrintingScript item in result)
            {
                var command = job.SelectMethod(item.PrintMethodID);
                byte[] commandBytes = Encoding.UTF8.GetBytes(command);
                byte[] contentBytes = Encoding.UTF8.GetBytes(item.Value);
                clientSocket.Send(commandBytes);

                if (item.IsNeedPrint)
                {
                    clientSocket.Send(contentBytes);
                    var n = job.NewLine();
                    byte[] nBytes = Encoding.UTF8.GetBytes(n);
                    clientSocket.Send(nBytes);
                }
            }

            // Line feed hexadecimal values
            byte[] bEsc = new byte[4];
            bEsc[0] = 0x0A;
            bEsc[1] = 0x0A;
            bEsc[2] = 0x0A;
            bEsc[3] = 0x0A;

            // Send the bytes over 
            clientSocket.Send(bEsc);

            clientSocket.Close();
        }

      /*  public void print2(*//*List<DirectPrintingScript> result,*//* string IP, int Port) {
            var job = new DirectPrinterProcess();
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;

            IPAddress ip = IPAddress.Parse(IP);
            IPEndPoint ipep = new IPEndPoint(ip, Port);

            clientSocket.Connect(ipep);
            clientSocket.Send(converterDemo(Image.FromFile("D:\\wton files\\2.png")));

            byte[] bEsc = new byte[4];
            bEsc[0] = 0x0A;
            bEsc[1] = 0x0A;
            bEsc[2] = 0x0A;
            bEsc[3] = 0x0A;

            // Send the bytes over 
            clientSocket.Send(bEsc);


            clientSocket.Close();

        }*/



        //--print method process
        public class DirectPrinterProcess
        {
            public string SelectMethod(int MethodID)
            {
                switch (MethodID)
                {
                    case 1:
                        return JustificationCenter();
                    case 2:
                        return JustificationLeft();
                    case 3:
                        return DoubleHeight();
                    case 4:
                        return DoubleWidth();
                    case 5:
                        return CancelDoubleHeightWidth();
                    case 6:
                        return SetColorRed();
                    case 7:
                        return SetColorBlack();
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

            private string CancelDoubleHeightWidth()
            {
                return "" + (char)27 + (char)33 + (char)0;
            }

            private string SetColorRed()
            {
                return "" + (char)27 + (char)114 + (char)1;
            }

            private string SetColorBlack()
            {
                return "" + (char)27 + (char)114 + (char)0;
            }

            public string NewLine()
            {
                return "" + "\n";
            }
        }
    }
}
