using acme_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
// esta es la clase dada por el profesor pero la modifique para poder hacer lo que necesitaba, la original va sin 
namespace acme_api.Repositories;
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> Get();
    Task<T> Get(int id);
    Task<T> Create(T value);
    Task<T> Update(T value);
    Task<string> Delete(int id);
}

