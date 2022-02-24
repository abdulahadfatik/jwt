using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_API
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using web_API.Context;
    using web_API.Entities;
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private CompanyContext _companyContext;
        public EmployeeController(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {

            return _companyContext.Employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {

            return _companyContext.Employees.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
           
            _companyContext.Employees.Add(value);
            _companyContext.SaveChanges();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            var emp = _companyContext.Employees.FirstOrDefault(s => s.Id == id);
            if (emp != null)
            {
                _companyContext.Entry<Employee>(emp).CurrentValues.SetValues(value);
                _companyContext.SaveChanges();
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delemp = _companyContext.Employees.FirstOrDefault(s => s.Id == id);
            if (delemp != null)
            {
                _companyContext.Employees.Remove(delemp);
                _companyContext.SaveChanges();
            }
        }
    }
}
