using TourDe.Models;

namespace TourDe.Api.Data;

public interface IPersonRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeletePerson(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    public Task<Person?> UpdatePerson(Person person);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    public Task<int> AddPerson(Person person);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Person?> GetPerson(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<List<Person>> GetAllPersons();
}