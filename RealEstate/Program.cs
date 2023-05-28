// See https://aka.ms/new-console-template for more information
using RealEstate.Models;
using System.Globalization;
using System.IO;

List<Ad> adList = Ad.LoadFromCsv("realestates.csv");
Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete: {GetAverageAreaByFloor(0):f2} m2");

IDictionary<Ad, double> distances = new Dictionary<Ad, double>();

adList.Where(ad => ad.freeOfCharge).ToList().ForEach(ad => 
{
    distances.Add(ad, DistanceTo(ad, 47.4164220114023, 19.066342425796986));
});

Ad closest = distances.First(d => d.Value == distances.Values.Min()).Key;

Console.WriteLine("2. Mesevár ócodához légvonalban legközelebbi tehermentes ingatlan adatai:");
Console.WriteLine($"\t Eladó neve: {closest.seller.name}");
Console.WriteLine($"\t Eladó telefonja: {closest.seller.phone}");
Console.WriteLine($"\t Alapterület: {closest.area}");
Console.WriteLine($"\t Szobák száma: {closest.rooms}");

double GetAverageAreaByFloor(int floor){
    List<Ad> filteredList = adList.Where(ad => ad.floors == floor).ToList();
    List<int> area = new();
    filteredList.ForEach(ad => area.Add(ad.area));
    return area.Average();
}


double DistanceTo(Ad ad, double coord1, double coord2)
{
    double latLong1 = double.Parse(ad.latLong.Split(',')[0], CultureInfo.InvariantCulture);
    double latLong2 = double.Parse(ad.latLong.Split(',')[1], CultureInfo.InvariantCulture);
    double xDistance = latLong1 - coord1;
    double yDistance = latLong2 - coord2;
    return Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
}