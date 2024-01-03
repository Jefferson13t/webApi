using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Attributes;
using System;

var pack = new ConventionPack { new CamelCaseElementNameConvention() };
ConventionRegistry.Register("elementNameConvention", pack, x => true);

    const string connectionUri = "mongodb+srv://cluster0:cluster0@cluster0.cqhq5et.mongodb.net/?retryWrites=true&w=majority";
    var settings = MongoClientSettings.FromConnectionString(connectionUri);
    // Set the ServerApi field of the settings object to Stable API version 1
    settings.ServerApi = new ServerApi(ServerApiVersion.V1);
    // Create a new client and connect to the server
    var client = new MongoClient(settings);
    // Send a ping to confirm a successful connection
    try {
    var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
    } catch (Exception ex) {
    Console.WriteLine(ex);
    }

var db = client.GetDatabase("sample_guides");
var coll = db.GetCollection<Comet>("comets");


try{
    Comet result = await coll.Find(x => x.Id == "6594999b11381b4ad63d6763").FirstOrDefaultAsync();
    long resultMany = await coll.Find(x => x.Mass < 69).CountDocumentsAsync();

    var filter = Builders<Comet>.Filter.Gt("Radius", 1);
    List<Comet> resultFiltered = await coll.Find(filter).ToListAsync();
    
    foreach(Comet document in resultFiltered){
        Console.WriteLine(document.ToJson());    
        }

} catch (Exception ex) {
    Console.WriteLine(ex);
}

//query get
// var cursor = from planet in coll.AsQueryable() 
//              where planet["surfaceTemperatureC.mean"] < 15 && planet["surfaceTemperatureC.min"] > -100
//              select planet;

// foreach(var document in cursor){
//     Console.WriteLine(document);
// }

//query post

    Comet[] comets = new [] {
        new Comet("Halley's Comet", "1P/Halley",75,3.4175,2.2e14),
        new Comet ( "Wild2", "81P/Wild", 6.41, 1.5534, 2.3e13),
        new Comet ( "Comet Hyakutake", "C/1996 B2", 17000, 0.77671, 8.8e12)
    };

//coll.InsertOne(new Comet( "Comet Bernardo", "B/2001 BM", 24, 1, 68));


class Comet {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public string OfficialName { get; set; }
    public double OrbitalPeriod { get; set; }
    public double Radius { get; set; }
    public double Mass { get; set; }
    public Comet(string Name, string OfficialName, double OrbitalPeriod, double Radius, double Mass){
        this.Name = Name;
        this.OfficialName = OfficialName;
        this.OrbitalPeriod = OrbitalPeriod;
        this.Radius = Radius;
        this.Mass = Mass;

    }
}
