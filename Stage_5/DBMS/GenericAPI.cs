using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Http;
using Microsoft.AspNetCore.Mvc;


namespace DBMS
{
    [Route("api/DataManagerAPI")]
    [ApiController]
    public class DataManagerAPIController : ControllerBase
    {
        private DataManager dataManager = DataManager.Instance;
        public DataManagerAPIController() { }

        [AcceptVerbs("GET")]
        [HttpGet("database")]
        public Database GetCurrentDatabase() => dataManager.CurrentDatabase;
        /*
        //[HttpGet("tables/{tableName}")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public Table GetTable(string tableName)
        {
            return dataManager.CurrentDatabase.GetTable(tableName);
        }

        //[HttpPost("tables")]
        [HttpPost]
        //public void CreateTable([FromBody] Table table)
        public void CreateTable(string tableName, [FromBody] List<Attribute> attributes)
        {
            dataManager.CreateTable(tableName, attributes);
        }

        

        //[HttpPut("tables/{tableName}")]
        [HttpPut]
        public void UpdateTable(string tableName, [FromBody] Table table)
        {
            dataManager.CurrentDatabase.UpdateTable(tableName, table);
        }

        [HttpDelete("tables/{tableName}")]
        public void DeleteTable(string tableName)
        {
            dataManager.DeleteTable(tableName);
        }

        [HttpGet("entries/{tableName}")]
        public IEnumerable<Entry> GetEntries(string tableName)
        {
            return dataManager.GetEntries(tableName);
        }

        [HttpPost("entries/{tableName}")]
        public void CreateEntry(string tableName, [FromBody] Entry entry)
        {
            dataManager.CreateEntry(tableName, entry);
        }

        [HttpPut("entries/{tableName}/{entryId}")]
        public void UpdateEntry(string tableName, long entryId, [FromBody] Entry entry)
        {
            dataManager.UpdateEntry(tableName, entryId, entry);
        }

        [HttpDelete("entries/{tableName}/{entryId}")]
        public void DeleteEntry(string tableName, long entryId)
        {
            dataManager.DeleteEntry(tableName, entryId);
        }
        */
    }
}
