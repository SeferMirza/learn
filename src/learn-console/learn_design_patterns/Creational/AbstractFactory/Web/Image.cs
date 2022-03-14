using Learn.DesignPatterns.Creational.AbstractFactory.Components;
using System;

namespace Learn.DesignPatterns.Creational.AbstractFactory.Web
{
    class Image : IImage
    {
        public void ImageUrl(string ur)
        {
            Console.WriteLine("Web Image url:" + ur);
        }

        public void ShowImage()
        {
            Console.WriteLine("Web Image");
        }
    }
}
