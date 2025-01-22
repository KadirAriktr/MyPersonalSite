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
    public class ToDoListManager : IToDoListService
    {
        IToDoList _toDoList;

        public ToDoListManager(IToDoList toDoList)
        {
            this._toDoList = toDoList;
        }

        public void TAdd(ToDoList t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ToDoList t)
        {
            throw new NotImplementedException();
        }

        public ToDoList TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ToDoList> TGetByListFilter()
        {
            throw new NotImplementedException();
        }

        public List<ToDoList> TGetList()
        {
            return _toDoList.GetList();
        }

        public void TUpdate(ToDoList t)
        {
            throw new NotImplementedException();
        }
    }
}
