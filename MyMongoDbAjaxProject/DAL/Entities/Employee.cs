using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMongoDbAjaxProject.DAL.Entities
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public decimal EmployeeSalary { get; set; }
    }
}
