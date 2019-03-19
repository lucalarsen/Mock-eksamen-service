﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ConsoleAppTcpServer
{
    class TCPService
    {
        private TcpClient connectionSocket;

        public TCPService(TcpClient connectionSocket)
        {
            // TODO: Complete member initialization
            this.connectionSocket = connectionSocket;
        }
        internal void DoIt()
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer;
            while (message != null && message != "")
            {
                Console.WriteLine("Client: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();

            }
            ns.Close();
            connectionSocket.Close();
        }
    }
}
