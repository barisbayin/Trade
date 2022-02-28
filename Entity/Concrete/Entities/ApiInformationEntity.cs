using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entity.Concrete.Entities
{
    public class ApiInformationEntity : IEntity
    {
        public int? Id { get; set; }
        public string Exchange { get; set; }
        public string ApiTitle { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public  bool? InUse { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? RemovedDate { get; set; }
    }
}
