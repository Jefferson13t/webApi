using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Model
{
    public class Person {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string? Photo { get; private set; }

        public Person(string Name, int Age, string Photo){
            this.Name = Name;
            this.Age = Age;
            this.Photo = Photo;
        }
    }
}