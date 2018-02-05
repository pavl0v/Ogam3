﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonInterface;
using Ogam3.Lsp;
using Ogam3.Network.Tcp;

namespace TcpServer {
    class Program {
        static void Main(string[] args) {
            var srv = new OTcpServer(1010);

            srv.RegisterImplementation(new ServerLogigImplementation());

            Console.WriteLine("OK");
            Console.ReadLine();
        }

        static void foo<T>(T a, object o) {
            a = (T) o;
        }
    }


    class ServerLogigImplementation : IServerSide {
        public int IntSumm(int a, int b) {
            return a + b;
        }

        public int IntSummOfPower(int a, int b) {
            var pc = OTcpServer.ContexReClient.CreateInterfase<IClientSide>();
            return pc.Power(a) + pc.Power(b);
        }

        public double DoubleSumm(double a, double b) {
            return a + b;
        }

        public void WriteMessage(string text) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void NotImplemented() {
            throw new NotImplementedException();
        }

        public ExampleDTO TestSerializer(ExampleDTO dto) {
            return dto;
        }
    }
}
