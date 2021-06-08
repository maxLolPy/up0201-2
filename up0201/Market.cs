using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up0201
{
    public class Market
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public int countPlaces { get; set; }
        public string city { get; set; }
        public double price { get; set; }
        public double delta { get; set; }
        public int flors { get; set; }
        public byte[] photo { get; set; }
        public List<Pavilion> pavilions { get; set; }
        public Market(int Id, string Name, string Status, int CountPlaces, string City, double Price, double Delta, int Flors, byte[] Photo)
        {
            id = Id;
            name = Name;
            status = Status;
            countPlaces = CountPlaces;
            city = City;
            price = Price;
            delta = Delta;
            flors = Flors;
            photo = Photo;
        }
    }
}
