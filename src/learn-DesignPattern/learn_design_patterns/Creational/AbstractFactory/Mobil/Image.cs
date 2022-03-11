using learn_DesignPattern.Creational.AbstractFactory.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.AbstractFactory.Mobil
{
    public class Image : IImage
    {
        public void ImageUrl(string ur)
        {
            Console.WriteLine("Mobile Image url"+ur);
        }

        public void ShowImage()
        {
            Console.WriteLine("Mobile Image");
        }
    }
}
