using System.ComponentModel.DataAnnotations;

namespace Backend.Data
{
    public class Employee
    {
        public int id { get; set; }
        public  string firstName { get; set; }
        public  string lastName { get; set; }
        public int age { get; set; }
        public string department { get; set; }



    }
}
