# Pár hasznos tipp:

- Valaminek a négyzet gyöke: ``Math.Sqrt()``

- Szükség esetén az osztály adattagjainak beállítását konstruktor segítségével állítsa
be = Add át a sort konstruktorban, valahogy így: 
```
public Osztály(string line)
{ 
    string[] splitedLine = line.Split(';');
    id = int.Parse(splitedLine[0]);
    //...
}
public static List<Osztály> LoadFromCsv(string fileName)
{
    List<Osztály> osztályList = new List<Osztály>();
    File.ReadAllLines(fileName).Skip(1).ToList().ForEach(line => 
    {
      osztályList.Add(new(line)); 
    });
    return osztályList;
}
```

- Szöveget (stringet) dobule-lé alakítani: ``double.Parse("3.14", CultureInfo.InvariantCulture);``

- Az osztályokat kötelező úgy elnevezni, de a propertyket variálhatod!

- Linq metódusok után kell egy ``ToList()``, ha ``ForEach()``-t akarsz használni.
