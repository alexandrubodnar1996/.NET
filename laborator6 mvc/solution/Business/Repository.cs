using System;
using System.Collections.Generic;
using DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class Repository : IRepository
    {
        public ApplicationContext _applicationContext;

        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            Commit();
        }

        public void Create(PointOfInterest point)
        {   
            if(!_applicationContext.Set<PointOfInterest>().ToList().Contains(point))
            {
                _applicationContext.Set<PointOfInterest>().Add(point);
                _applicationContext.SaveChanges();
            }else
            {
                throw new Exception("Elementul cu id " + point.Id + " exista deja");
            }

        }

        public void Delete(PointOfInterest point)
        {
            if (_applicationContext.Set<PointOfInterest>().ToList().Contains(point))
            {
                _applicationContext.Set<PointOfInterest>().Remove(point);
            }
            else
            {
                throw new Exception("Elementul cu id " + point.Id + " nu exista");
            }
        }

        public List<PointOfInterest> GetAll()
        {
            return _applicationContext.Set<PointOfInterest>().ToList();
        }

        public PointOfInterest GetById(Guid id)
        {
            return _applicationContext.Set<PointOfInterest>().Where(p => p.Id.Equals(id)).FirstOrDefault();
        }

        public void Update(PointOfInterest point)
        {
            if (_applicationContext.Set<PointOfInterest>().Find(point).Equals(true))
            {
                _applicationContext.Set<PointOfInterest>().Update(point);
            }
            else
            {
                throw new Exception("This point doesn't exist anymore");
            }

        }

        public void Commit ()
        {
            _applicationContext.SaveChanges();
        }

        public Task CommitAsync()
        {
           return _applicationContext.SaveChangesAsync();
        }
    }
}
