using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _portfolio;

        public PortfolioManager(IPortfolioDal portfolio)
        {
            _portfolio = portfolio;
        }

        public void TAdd(Portfolio t)
        {
            _portfolio.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _portfolio.Delete(t);
        }

        public Portfolio TGetById(int id)
        {
           return _portfolio.GetById(id);
        }

        public List<Portfolio> TGetByListFilter()
        {
            throw new NotImplementedException();
        }

        public List<Portfolio> TGetList()
        {
           return _portfolio.GetList();
        }

        public void TUpdate(Portfolio t)
        {
            _portfolio.Update(t);
        }
    }
}
