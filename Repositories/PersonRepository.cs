using MongoDB.Driver;
using WebApi.Model;
using WebApi.Config;

namespace WebApi.Repository
{
    public class PersonRepository : IPersonRepository {
        private readonly IMongoCollection<Person> _personCollection;
        public PersonRepository(){
            IMongoDatabase database = ConnectionContext.ConnectionToMongo();
            _personCollection = database.GetCollection<Person>("person");
        }
        public void Add(Person person){
            _personCollection.InsertOne(person);
        }
        public List<Person> Get(){
            FilterDefinition<Person> filter = Builders<Person>.Filter.Empty;
            List<Person> result = _personCollection.Find(filter).ToList();
            return result;
        }

        public Person Get(string id){
            return _personCollection.Find(x => x.Id == id).First();
        }
    }
}