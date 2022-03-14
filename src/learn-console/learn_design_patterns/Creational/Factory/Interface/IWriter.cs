using System;

namespace Learn.DesignPatterns.Creational.Factory.Interface
{
    public interface IWriter
    {
        string GetName();
        string GetBooks();
        DateTime GetBirthDay();

    }
}
