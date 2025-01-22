using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experience;

        public ExperienceManager(IExperienceDal experience)
        {
            _experience = experience;
        }

        public void TAdd(Experience t)
        {
            _experience.Insert(t);
        }

        public void TDelete(Experience t)
        {
            _experience.Delete(t);
        }

        public Experience TGetById(int id)
        {
           return _experience.GetById(id);
        }

        public List<Experience> TGetByListFilter()
        {
            throw new NotImplementedException();
        }

        public List<Experience> TGetList()
        {
            return _experience.GetList();
        }

        public void TUpdate(Experience t)
        {
            _experience.Update(t);
        }
    }
}
