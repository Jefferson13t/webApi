using MongoDB.Driver;
using MongoDB.Bson;

namespace WebApi.Config
{
        public class ConnectionContext{

            public static IMongoDatabase ConnectionToMongo(){
                string? connectionUri =  "mongodb+srv://cluster0:cluster0@cluster0.cqhq5et.mongodb.net/?retryWrites=true&w=majority";
                var settings = MongoClientSettings.FromConnectionString(connectionUri);
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);
                MongoClient client = new MongoClient(settings);
                IMongoDatabase database = client.GetDatabase("web_api");
                return database;
            }
        }
}