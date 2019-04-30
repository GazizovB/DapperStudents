using DapperStudents.Models;
using DapperStudents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperStudents.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tГлавное меню");
            Console.WriteLine("Выберите:");
            Console.WriteLine("Добавление (нажмите 1)");
            Console.WriteLine("Удаление (нажмите 2)");

            StudentRepository _userRep = new StudentRepository();

            int choise = int.Parse(Console.ReadLine());
            if (choise == 1)
            {
                do
                {
                    Console.Write("Фамилия: ");
                    var lastName = Console.ReadLine();
                    Console.Write("Имя: ");
                    var firstName = Console.ReadLine();
                    Console.Write("Очество: ");
                    var middleName = Console.ReadLine();
                    Console.Write("GroupId: ");
                    int groupId = int.Parse(Console.ReadLine());


                    _userRep.InsertStudent(@"INSERT INTO Students (LastName, FirstName, MiddleName, GroupId)
                                        VALUES(@LastName, @FirstName, @MiddleName, @GroupId)",
                new Student()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    GroupId = groupId
                });

                    var students = _userRep.GetAllStudent("SELECT * FROM Students");

                    students.ForEach(f =>
                    {
                        Console.WriteLine($"{f.Id}\t\t{f.LastName}\t\t{f.FirstName}\t\t{f.MiddleName}");
                    });
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }

            else if (choise == 2)
            {
                do
                {
                    _userRep.GetAllStudent("SELECT * FROM Students").ForEach(f =>
                    {
                        Console.WriteLine($"{f.Id}\t\t{f.LastName}\t\t{f.FirstName}\t\t{f.MiddleName}");
                    });
                    Console.WriteLine("Введите идентификатор для удаления:");
                    var tmp = Console.ReadLine();
                    int IdSt;
                    int.TryParse(tmp, out IdSt);

                    _userRep.DeleteStudent(@"DELETE Students WHERE Id = @Id", IdSt);

                    var students = _userRep.GetAllStudent("SELECT * FROM Students");
                    students.ForEach(f =>
                    {
                        Console.WriteLine($"{f.Id}\t\t{f.LastName}\t\t{f.FirstName}\t\t{f.MiddleName}");
                    });

                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
        }
    }
}
