﻿namespace MyMongoDbAjaxProject.DAL.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string EmployeeCollectionName { get; set; }
    }
}
