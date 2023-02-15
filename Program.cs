#region data
using CA230215;

List<Person> people = new()
{
    new Person()
    {
        Id = 1,
        Name = "John Doe",
        BirthDate = new DateTime(1994, 07, 03),
        FavBooks = new() { "Harry Potter I.", "1984", "Shining", },
        Workplace = "Microsoft",
        NoChildren = 1,
        Sex = true,
    },
    new Person()
    {
        Id = 1,
        Name = "Edgar Crispin",
        BirthDate = new DateTime(1973, 01, 20),
        FavBooks = new() { "Lord of the Rigs", "Song of Ice and Fire", "Wheel of Time", },
        Workplace = "Apple",
        NoChildren = 0,
        Sex = true,
    },
    new Person()
    {
        Id = 3,
        Name = "Martin Stone",
        BirthDate = new DateTime(2008, 02, 14),
        FavBooks = new() { "Aranyember", "Az Ember Tragédiája", },
        Workplace = null,
        NoChildren = 0,
        Sex = true,
    },
    new Person()
    {
        Id = 4,
        Name = "Suzi Jaylen",
        BirthDate = new DateTime(1991, 02, 15),
        FavBooks = new() { "The Great Gatsby", "Fifty Shades of Grey", },
        Workplace = "Apple",
        NoChildren = 4,
        Sex = false,
    },
    new Person()
    {
        Id = 5,
        Name = "Alexa Stirling",
        BirthDate = new DateTime(1985, 12, 29),
        FavBooks = new() { "Invisible Man", "1984", "Watchman", },
        Workplace = "Microsoft",
        NoChildren = 2,
        Sex = false,
    },
};
#endregion

//a setben lévő emberek gyermekeinek száma összesen
int a1 = people.Sum(p => p.NoChildren);
Console.WriteLine($"gyerekek száma összesen: {a1}");

//átlag életkor
double a2 = people.Average(p => DateTime.Now.Year - p.BirthDate.Year);
Console.WriteLine($"emberek átlagéletkora: {a2:0.00}");

//MS dolgozók száma
int a3 = people.Count(p => p.Workplace == "Microsoft");
Console.WriteLine($"MS dolgozók száma: {a3}");

//van-e munkanélküli?
bool a4 = people.Any(p => p.Workplace is null);
Console.WriteLine($"{(a4 ? "van" : "nincs")} munkanélküli");

//Apple dolgozók listája
var a5 = people.Where(p => p.Workplace == "Apple");
Console.WriteLine("Apple dolgozói:");
foreach (var p in a5)
    Console.WriteLine($"\tnév: {p.Name}, szül.év: {p.BirthDate.Year}");

//legöregebb ember szül.datum
var a6 = people.Min(p => p.BirthDate);
Console.WriteLine($"Legöregebb ember szülinapja: {a6:yy-MM-dd}");

//legöregebb ember neve
var a7 = people.MinBy(p => p.BirthDate);
Console.WriteLine($"Legöregebb ember neve: {a7.Name}");

//nevek projektálása másik adatszerkezetbe
string[] a8 = people.Select(p => p.Name).ToArray();
Console.WriteLine("csak a nevek:");
foreach (var n in a8) Console.WriteLine($"\t{n}");

//munkahelyenként dolgozók listája
var a9 = people.GroupBy(p => p.Workplace);
foreach (var group in a9)
{
    Console.WriteLine(group.Key is null ? "munkanélküliek:" : $"{group.Key} dolgozói:");
    foreach (var p in group) Console.WriteLine($"\t-{p.Name}");
}

//adott munkahelyen dolgozók száma:
var a10 = people
    .Where(p => !string.IsNullOrWhiteSpace(p.Workplace))
    .GroupBy(p => p.Workplace)
    .ToDictionary(g => g.Key, g => g.Count());
foreach (var kvp in a10) Console.WriteLine($"{kvp.Key}: {kvp.Value} fő");

//microsoftnál dolgozó gyermektelen nők nevei listája életkoruk szerint csökkenőben
Console.WriteLine("[commentbe benne van] nevek listája:");
people
    .Where(p => p.Workplace == "Microsoft")
    .Where(p => !p.Sex)
    .Where(p => p.NoChildren == 0)
    .OrderByDescending(p => p.BirthDate)
    .Select(p => p.Name)
    .ToList()
    .ForEach(e => { Console.WriteLine($"\t{e}\n"); });

Console.WriteLine("összes könyv:");
var a11 = people.SelectMany(p => p.FavBooks).Distinct().OrderBy(x => x);
foreach (var book in a11) Console.WriteLine($"\t{book}");

//First, Last =>
//          [ha egyedi a szűrés után akkor visszaadja azt]
//          [ha ismétlődik szűrés után, akkor visszaadja az egyiket]
//          [ha NICS a szűrésnek megfelelő, akkor exception]

//FirstOrDefault, LastOrDefault
//          [ha egyedi a szűrés után, akkor visszaadja azt]
//          [ha ismétlődik szűrés után, akkor visszaadja az egyiket]
//          [ha nincs a szűrésnek megfelelő, ref -> null; val -> 0]

//Single
//          [ha egyedi a szűrés után, akkor visszaadja azt]
//          [ha ismétlődik szűrés után, akkor exception]
//          [ha nincs a szűrésnek megfelelő, akkor is exception]

//SingleOrDefault
//          [ha egyedi a szűrés után, akkor visszaadja azt]
//          [ha ismétlődik szűrés után, akkor exception]
//          [ha nincs a szűrésnek megfelelő, ref -> null; val -> 0]


//Person pl02 = people.First(p => p.Id == 1);
//Console.WriteLine(pl02.Name);