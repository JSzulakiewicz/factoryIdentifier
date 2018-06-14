using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class PartModel
    {
        public string Name { get; set; }
        public string FactoryName { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreationDate { get; set; }

        
        public PartModel (Db.Part dbEntity)
        {
            this.Name = $"{dbEntity.Category.Name}-{dbEntity.Factory.Name}-{dbEntity.Number}";
            this.FactoryName = dbEntity.Factory.Name;
            this.CategoryName = dbEntity.Category.Name;
            this.CreationDate = dbEntity.CreationDate;
        }
    }
}