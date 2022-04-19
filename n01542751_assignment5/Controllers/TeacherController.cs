using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using n01542751_assignment5.Models;


namespace n01542751_assignment5.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/List
        //showing a page of all teacher information
        [Route("/Teacher/List/{SearchKey}")]
        public ActionResult List(string SearchKey)
        {
            //connect a data access layer
            TeacherDataController controller = new TeacherDataController();
            List<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }


        //GET: Teacher/Show/id
        [Route("Teacher/Show/{id}")]

        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();

            TeacherCourse TC = controller.FindTeacher(id);

            //routes the single teacher information to Show.cshtml
            return View(TC);
        }


        //GET: Teacher/DeleteConfirm/id
        [Route("Teacher/DeleteConfirm/{id}")]

        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();

            TeacherCourse TC = controller.FindTeacher(id);

            //routes the single teacher information to Show.cshtml
            return View(TC);
        }

        //POST: /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();

            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET: Teacher/Add
        [Route("Teacher/Add")]
        public ActionResult Add()
        {
            return View();
        }

        //POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(string teacherfname, string teacherlname)
        {

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFName = teacherfname;
            NewTeacher.TeacherLName = teacherlname;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);
            //redirect to the new list
            return RedirectToAction("List");
        }
    }
}