namespace WebApi.Model
{
    public interface IPersonRepository{
        void Add(Person person);
        List<Person> Get();
        Person? Get(string id);
    }
}