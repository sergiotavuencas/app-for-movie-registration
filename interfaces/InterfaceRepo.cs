using System.Collections.Generic;

namespace app_for_movie_registration.interfaces
{
    public interface InterfaceRepo<T>
    {
        List<T> ListAll();
        T GetById(int Id);
        void Insert(T Entity);
        void Delete(int Id);
        void Update(int Id, T Entity);
        int NextId();
    }
}