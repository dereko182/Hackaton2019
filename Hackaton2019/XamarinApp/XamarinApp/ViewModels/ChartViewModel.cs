using System.Collections.Generic;

namespace XamarinApp.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
        public List<Person> Data { get; set; }

        public ChartViewModel()
        {
            Data = new List<Person>()
            {
                new Person {Name = "Trigo", Height = 14588},
                new Person {Name = "Algodón", Height = 20000},
                new Person {Name = "Alfalfa", Height = 10430}
            };
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public double Height { get; set; }
    }
}
