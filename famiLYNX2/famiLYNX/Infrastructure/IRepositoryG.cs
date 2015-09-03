using System.Linq;

namespace famiLYNX.Infrastructure {
    public interface IRepositoryG {
        void Add<T>(T entityToCreate) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        void Dispose();
        T Find<T>(params object[] keyValues) where T : class;
        IQueryable<T> Query<T>() where T : class;
        void SaveChanges();
    }
}