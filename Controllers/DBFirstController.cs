using DataBaseFirstApproach.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBFirstController : ControllerBase
    {
        private readonly DbfirstContext _dbfirstContext;
        public DBFirstController(DbfirstContext dbfirstContext)
        {
            _dbfirstContext = dbfirstContext;
        }

        [HttpGet]
        [Route("GET ALL")]
        public IEnumerable<DbfirstTable> GetTables()
        {
            return _dbfirstContext.DbfirstTables;
        }
        [HttpPost]
        [Route("create")]
        public DbfirstTable Create(DbfirstTable model)
        {
            int newId = _dbfirstContext.DbfirstTables.OrderByDescending(item => item.Id).FirstOrDefault()?.Id + 1 ?? 1;
            DbfirstTable customer = new DbfirstTable
            {
                Id = newId,
                Address = model.Address,
                EmployeeName = model.EmployeeName,
                EmployeeId = model.EmployeeId,
            };

            _dbfirstContext.Add(customer);
            _dbfirstContext.SaveChanges();
            return customer;
        }
    }
}
