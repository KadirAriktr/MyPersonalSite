﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.ViewComponents.Dashboard
{
    public class ToDoListPanel:ViewComponent
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EfToDoList());
        public IViewComponentResult Invoke()
        {
            var values=toDoListManager.TGetList();
            return View(values);
        }
    }
}
