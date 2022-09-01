using System.Linq;
namespace onBoard
{
    public interface IDbContext
    {
        IQueryable<T> Set<T>() where T : class;
    }
}