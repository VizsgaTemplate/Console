using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Ad
    {
        public Ad(string line)
        {
            string[] splitedLine = line.Split(';');
            id = int.Parse(splitedLine[0]);
            rooms = int.Parse(splitedLine[1]);
            latLong = splitedLine[2];
            floors = int.Parse(splitedLine[3]);
            area = int.Parse(splitedLine[4]);
            description = splitedLine[5];
            freeOfCharge = int.Parse(splitedLine[6]) == 1;
            imageUrl = splitedLine[7];
            createAt = DateTime.Parse(splitedLine[8]);
            seller = new()
            {
                id = int.Parse(splitedLine[9]),
                name = splitedLine[10],
                phone = splitedLine[11]
            };
            category = new()
            {
                id = int.Parse(line.Split(";")[12]),
                name = splitedLine[13]
            };
        }
        public Ad()
        {

        }
        public int id { get; set; }
        public int rooms { get; set; }
        public string latLong { get; set; }
        public int floors { get; set; }
        public int area { get; set; }
        public string description { get; set; }
        public bool freeOfCharge { get; set; }
        public string imageUrl { get; set; }
        public DateTime createAt { get; set; }
        public Seller seller { get; set; }
        public Category category { get; set; }
        public static List<Ad> LoadFromCsv(string fileName)
        {
            List<Ad> adList = new List<Ad>();
            File.ReadAllLines(fileName).Skip(1).ToList().ForEach(line => {
                adList.Add(new(line)); 
            });
            return adList;
        }
    }
}
