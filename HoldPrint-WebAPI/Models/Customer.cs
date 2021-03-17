using System.ComponentModel.DataAnnotations;
namespace HoldPrint_WebAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cpf { get; set; }

        public Customer()
        {
        }
        public Customer(int id, string name, string surname, string cpf)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Cpf = cpf;
        }
    }
}