using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using TestAppn.Models;

namespace TestAppn.Controllers
{
    public class EmployeeController : Controller
    {
        string connectionString = @"data source=NIT-WKS-0047\SQLEXPRESS;initial catalog=TestDB;integrated security=True";
        // GET: Employee
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            List<tblEmployee> tblEmp = new List<tblEmployee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "Select * from tblEmployee";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
            }
            foreach (DataRow row in dt.Rows)
            {
                tblEmployee emp = new tblEmployee();
                emp.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
                emp.Name = Convert.ToString(row["Name"]);
                emp.Gender = Convert.ToString(row["Gender"]);
                emp.City = Convert.ToString(row["City"]);
                emp.DepartmentId = Convert.ToInt32(row["DepartmentId"]);
                tblEmp.Add(emp);
            }
            DataTable dtDept = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "Select * from tblDepartment";
                SqlDataAdapter sdaDept = new SqlDataAdapter(query, con);
                sdaDept.Fill(dtDept);
            }
            List<tblDepartment> lstDept = new List<tblDepartment>();
            foreach (DataRow row in dtDept.Rows)
            {
                tblDepartment dept = new tblDepartment();
                dept.Id = Convert.ToInt32(row["Id"]);
                dept.Name = Convert.ToString(row["Name"]);

                lstDept.Add(dept);
            }
            ViewBag.empdata = lstDept;

            return View(tblEmp);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
