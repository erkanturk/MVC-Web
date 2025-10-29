using _17_AdoNetExample.DbService.Abstract;
using _17_AdoNetExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace _17_AdoNetExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService _dbService;
        public HomeController(IDbService dbService)
        {
            _dbService=dbService;
        }

        public IActionResult Index()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AddData()
        {
            string query = "Insert into Students (FirstName,LastName,Age) Values('Erkan','Türk','31')";
            _dbService.ExecuteNonQuery(query);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddDataSecure([FromForm] Student student)
        {
            string query = "Insert into Students (FirstName,LastName,Age) Values(@FirstName,@LastName,@Age)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@FirstName",student.FirstName),
                new SqlParameter("@LastName",student.LastName),
                new SqlParameter("@Age",student.Age)
            };
            _dbService.ExecuteNonQuery(query, parameters);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetData()
        {
            string query = "Select * From Students";
            var data = _dbService.ExecuteReader(query);
            return View(data);

        }
        [HttpGet]
        public IActionResult GetCount()
        {
            string query = "Select Count(*) From Students";
            var count = _dbService.ExecuteScalar(query);

            return View(count);
        }
        public IActionResult DeleteDataSecure()
        {
           return View();
        }
        [HttpPost]
        public IActionResult DeleteDataSecure([FromForm] int id)
        {
            string query = "Delete From Students Where Id=@Id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id",id)
            };
            _dbService.ExecuteNonQuery(query, parameters);

            return RedirectToAction("GetData");
        }
        public IActionResult UpdateDataSecure()
        {
          return View();

        }
        [HttpPost]
        public IActionResult UpdateDataSecure([FromForm] Student model)
        {
            string query = "Update Students set FirstName=@FirstName, LastName=@LastName, Age=@Age Where Id=@Id";
            SqlParameter[] parameters =
           {
                new SqlParameter("@FirstName",model.FirstName),
                new SqlParameter("@LastName",model.LastName),
                new SqlParameter("@Age",model.Age),
                new SqlParameter("@Id",model.Id)
            };
            _dbService.ExecuteNonQuery(query, parameters);
            return RedirectToAction("GetData");

        }

    }
}
