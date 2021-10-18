using System;

namespace Festo_BackEnd_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.BlCouse objBl = new BL.BlCouse();
            if (args.Length > 0)
            {
                DisplayData(objBl.Get_CourseWithFilter(args[0]));
            }
            else
            {
                DisplayData(objBl.Get_CourseInformation());
            }
          //  Console.ReadKey();
        }

        public static void DisplayData(ClassModal modal)
        {
            try
            {
                if (modal != null)
                {
                    if (modal.lstCourse != null)
                    {
                        Console.WriteLine("Course \t\t\tType");
                        foreach (Course objcourse in modal.lstCourse)
                        {
                            Console.WriteLine("{0}  =>  {1}", objcourse.CourseTitle, modal.lstcourseTypes.Find(e => e.ID == objcourse.CourseTypeID).Name);
                        }
                    }
                }
                else {
                    Console.WriteLine("SomeThing Went Wrong");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong...");
            }
        }
    }
}
