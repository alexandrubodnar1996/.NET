using System;
using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface IRepository
    {
        void Create(PointOfInterest point);
        void Delete(PointOfInterest point);
        void Update(PointOfInterest point);
        PointOfInterest GetById(Guid id);
        List<PointOfInterest> GetAll();
        void Commit();
        Task CommitAsync();
    }
}
