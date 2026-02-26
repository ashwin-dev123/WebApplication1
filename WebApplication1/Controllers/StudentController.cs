using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {

        static List<Student> students = new List<Student>
        {
            new Student{Id = 1, Name= "Ash" , Age = 20},
            new Student{Id = 2 , Name = "Ben" , Age = 22},
            new Student{Id = 3 , Name = "Charles" , Age = 25}

        };


        [HttpGet]
        public IActionResult Index()
        {
            List<StudentViewModel> studentViewModels = new List<StudentViewModel>(); // creating a view model 
            foreach (var student in students)
            {
                studentViewModels.Add(new StudentViewModel
                {
                    Name = student.Name,
                    Age = student.Age
                });
            }

            return View(studentViewModels);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count + 1;
                students.Add(student);

                return RedirectToAction("Index");

            }
            return View(student);
        }





    }
}
