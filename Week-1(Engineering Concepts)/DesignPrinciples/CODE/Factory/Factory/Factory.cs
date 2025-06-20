using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    interface IDocument
    {
        void Open();
    }

    class WordDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Word document");
    }

    class PdfDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening PDF document");
    }

    class ExcelDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Excel document");
    }

    abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    class PdfFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new PdfDocument();
    }

    class WordFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new WordDocument();
    }

    class ExcelFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new ExcelDocument();
    }

    class Program
    {
        static void Main(string[] args)
        {
            DocumentFactory factory = new ExcelFactory();
            IDocument doc = factory.CreateDocument();
            doc.Open();
        }
    }
}