using System;

namespace Access_Modifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "John";
            person.InternalMethod();

            Employee employee = new Employee();
            employee.AccessProtectedMethod();
            employee.AccessPrivateProtectedMethod();

            Console.ReadKey();            

        }
    }
}
