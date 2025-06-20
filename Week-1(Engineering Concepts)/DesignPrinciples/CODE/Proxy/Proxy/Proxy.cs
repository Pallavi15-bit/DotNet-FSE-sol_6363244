using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    interface IImage
    {
        void Display();
    }

    class RealImage : IImage
    {
        private string filename;
        public RealImage(string filename)
        {
            this.filename = filename;
            LoadImage();
        }

        private void LoadImage()
        {
            Console.WriteLine($"Loading {filename} from remote server...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {filename}");
        }
    }

    class ProxyImage : IImage
    {
        private RealImage realImage;
        private string filename;

        public ProxyImage(string filename)
        {
            this.filename = filename;
        }

        public void Display()
        {
            if (realImage == null)
                realImage = new RealImage(filename);
            realImage.Display();
        }
    }

    class Proxy
    {
        static void Main(string[] args)
        {
            IImage image = new ProxyImage("image1.jpg");
            image.Display();
            image.Display(); // Cached
        }
    }
}
