using Learn.DesignPatterns.Creational.AbstractFactory.Components;
using System;

namespace Learn.DesignPatterns.Creational.AbstractFactory.Mobil
{
    public class Image : IImage
    {
        public void ImageUrl(string ur)
        {
            Console.WriteLine("Mobile Image url" + ur);
        }

        public void ShowImage()
        {
            Console.WriteLine("Mobile Image");
        }
    }
}
