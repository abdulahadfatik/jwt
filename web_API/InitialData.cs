using System.Linq;

namespace web_API
{
    using System.Linq;
    using web_API.Entities;
    using web_API.Context;

    public static class InitialData
    {
        public static void Seed(this CompanyContext dbContext)
        {
            if (!dbContext.Employees.Any())
            {
                dbContext.Employees.Add(new Employee
                {
                    Name = "Emp01",
                    Gender = "Male",
                    DateOfBirth = "01-01-1990",
                    Nationality = "Pakistan",
                    City = "Rawalpindi",
                    CurrentAddress = "Current Address",
                    PermanentAddress = "Permanent Address",
                    PINCode = "051"
                });
                dbContext.Employees.Add(new Employee
                {
                    Name = "Emp02",
                    Gender = "Female",
                    DateOfBirth = "02-02-1995",
                    Nationality = "Afghan",
                    City = "Kabul",
                    CurrentAddress = "Current Address",
                    PermanentAddress = "Permanent Address",
                    PINCode = "0721"
                });
                dbContext.Employees.Add(new Employee
                {
                    Name = "Emp03",
                    Gender = "Male",
                    DateOfBirth = "03-03-1999",
                    Nationality = "Indian",
                    City = "Bangalore",
                    CurrentAddress = "Current Address",
                    PermanentAddress = "Permanent Address",
                    PINCode = "560078"
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User
                {
                    Id="1",
                    UserName = "ahad",
                    Password = "qw12",
                    FirstName="abdul",
                    LastName="ahad",
                });
                dbContext.Users.Add(new User
                {
                    Id = "2",
                    UserName = "faisal",
                    Password = "q1w2",
                    FirstName = "faisal",
                    LastName = "shahzaid",
                });
                dbContext.Users.Add(new User
                {
                    Id = "3",
                    UserName = "hassan",
                    Password = "12qw",
                    FirstName = "muhammad",
                    LastName = "hassan",
                });
            }
        }
    }
      
}
