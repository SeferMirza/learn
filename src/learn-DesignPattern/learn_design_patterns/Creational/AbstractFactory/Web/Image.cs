using learn_DesignPattern.Creational.AbstractFactory.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.AbstractFactory.Web
{
    class Image : IImage
    {
        public void ImageUrl(string ur)
        {
            Console.WriteLine("Web Image url:"+ur);
        }

        public void ShowImage()
        {
            Console.WriteLine("Web Image");
        }
    }
}
