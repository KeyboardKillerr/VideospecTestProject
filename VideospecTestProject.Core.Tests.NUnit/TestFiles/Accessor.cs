using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VideospecTestProject.Core.Tests.NUnit.TestFiles
{
    internal static class Accessor
    {
        private static readonly string RootPath = "C:\\Users\\radia\\source\\repos\\VideospecTestProject\\VideospecTestProject.Core.Tests.NUnit\\TestFiles\\";

        private static readonly string Receipt1Path = RootPath + "TestReceipt.json";

        public static string GetReceipt1()
        {
            return ReadFile(Receipt1Path);
        }

        private static string ReadFile(string path)
        {
            using var reader = new StreamReader(path);
            return reader.ReadToEnd().Replace("\r\n", string.Empty);
        }
    }
}
