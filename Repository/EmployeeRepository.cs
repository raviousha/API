using API.Context;
using API.Models;
using API.Repository.Interface;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    //public class EmployeeRepository : IEmployeeRepository
    //{

    //    private readonly MyContext myContext;
    //    public EmployeeRepository(MyContext myContext)
    //    {
    //        this.myContext = myContext;
    //    }

    //    public int Delete(String nik)
    //    {
    //        var entity = myContext.Employees.Find(nik);
    //        {
    //            myContext.Remove(entity);
    //            var result = myContext.SaveChanges();
    //            return result;
    //        }
    //    }

    //    public IEnumerable<Employee> Get()
    //    {
    //        return myContext.Employees.ToList();
    //    }

    //    public Employee Get(String nik)
    //    {
    //        //var entity = myContext.Employees.SingleOrDefault(e => e.NIK == nik);
    //        var entity = myContext.Employees.FirstOrDefault(e => e.NIK == nik);
    //        return entity;
    //    }

    //    public int Insert(Employee employee)
    //    {
    //        myContext.Employees.Add(employee);

    //        //var temp = myContext.Employees.Where(e => e.NIK == employee.NIK).SingleOrDefault();

    //        if (myContext.Employees.FirstOrDefault(e => e.NIK == employee.NIK) == null)
    //        {
    //            if (myContext.Employees.FirstOrDefault(e => e.Email == employee.Email) == null)
    //            {
    //                if (myContext.Employees.FirstOrDefault(e => e.Phone == employee.Phone) == null)
    //                {
    //                    return myContext.SaveChanges();
    //                }
    //                else
    //                {
    //                    return 4;
    //                }
    //            }
    //            else
    //            {
    //                return 3;
    //            }
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }

    //    public int Update(String nik, Employee employee)
    //    {
    //        //var temp = myContext.Employees.Find(nik);

    //        var temp = myContext.Employees.AsNoTracking().Where(e => e.NIK == nik).FirstOrDefault();
    //        if (temp != null)
    //        {

    //            myContext.Entry(employee).State = EntityState.Detached;

    //            if (temp.Email == employee.Email || myContext.Employees.FirstOrDefault(e => e.Email == employee.Email) == null)
    //            {
    //                if (temp.Phone == employee.Phone || myContext.Employees.FirstOrDefault(e => e.Phone == employee.Phone) == null)
    //                {
    //                    employee.NIK = nik;
    //                    myContext.Entry(employee).State = EntityState.Modified;
    //                    var result = myContext.SaveChanges();
    //                    return result;
    //                }
    //                else
    //                {
    //                    return 4;
    //                }
    //            }
    //            else
    //            {
    //                return 3;
    //            }
    //        }
    //        else
    //        {
    //            return 2;
    //        }
    //    }
    //}

    public class EmployeeRepository : GeneralRepository<MyContext, Employee, String>
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Register(RegisterVM registerVM)
        {
            var formattedNIK = $"{DateTime.Now.Year + "0" + (myContext.Employees.Count() + 1)}";

            var emp = new Employee
            {
                NIK = formattedNIK,
                firstName = registerVM.firstName,
                lastName = registerVM.lastName,
                Phone = registerVM.phone,
                birthDate = registerVM.birthDate,
                salary = registerVM.salary,
                Email = registerVM.email,
                Gender = (Gender)registerVM.gender
            };

            //Statement kondisi phone dan email
            if (myContext.Employees.FirstOrDefault(e => e.Phone == registerVM.phone) == null)
            {
                if (myContext.Employees.FirstOrDefault(e => e.Email == registerVM.email) == null)
                {
                    myContext.Employees.Add(emp);
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }

            var acc = new Account
            {
                NIK = emp.NIK,
                password = BCrypt.Net.BCrypt.HashPassword(registerVM.password)
            };
            myContext.Accounts.Add(acc);

            var edu = new Education
            {
                Id = $"{myContext.Educations.Count() + 1}",
                degree = registerVM.degree,
                GPA = registerVM.gpa,
                UniversityId = registerVM.universityId
            };
            myContext.Educations.Add(edu);

            var pro = new Profiling
            {
                NIK = acc.NIK,
                EducationId = edu.Id
            };
            myContext.Profilings.Add(pro);

            return myContext.SaveChanges();
        }

        public IEnumerable<object> GetRegisteredData()
        {
            var empList = myContext.Employees;
            var uniList = myContext.Universities;
            var eduList = myContext.Educations;
            var trList = myContext.Profilings;

            var query = from emp in empList
                        join tr in trList
                        on emp.NIK equals tr.NIK
                        join edu in eduList
                        on tr.EducationId equals edu.Id
                        join uni in uniList
                        on edu.UniversityId equals uni.Id
                        select new
                        {
                            fullName = emp.firstName + " " + emp.lastName,
                            gender = emp.Gender == 0 ? "Laki-laki" : "Perempuan",
                            emp.Phone,
                            emp.birthDate,
                            emp.salary,
                            emp.Email,
                            edu.degree,
                            edu.GPA,
                            universityName = uni.name
                        };

            return query;
        }

        public IEnumerable<object> GetRegisteredData(String nik)
        {
            var empList = myContext.Employees;
            var uniList = myContext.Universities;
            var eduList = myContext.Educations;
            var trList = myContext.Profilings;

            var query = from emp in empList
                        join tr in trList
                        on emp.NIK equals tr.NIK
                        join edu in eduList
                        on tr.EducationId equals edu.Id
                        join uni in uniList
                        on edu.UniversityId equals uni.Id
                        where emp.NIK == nik
                        select new
                        {
                            fullName = emp.firstName + " " + emp.lastName,
                            gender = emp.Gender == 0 ? "Laki-laki" : "Perempuan",
                            emp.Phone,
                            emp.birthDate,
                            emp.salary,
                            emp.Email,
                            edu.degree,
                            edu.GPA,
                            uni.name
                        };
            return query;
        }
    }
}
