using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Models;

namespace SalesWeb.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> DepartmentList = new List<Department>();
            DepartmentList.Add(new Department { Id = 1, Name = "RH" });
            DepartmentList.Add(new Department { Id = 2, Name = "Contabilidade" });
            DepartmentList.Add(new Department { Id = 3, Name = "Gerencia" });
            DepartmentList.Add(new Department { Id = 4, Name = "Desenvolvimento e manutenção" });

            return View(DepartmentList);
        }
    }
}