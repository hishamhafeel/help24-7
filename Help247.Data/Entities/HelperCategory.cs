using Help247.Data.Application;
using Help247.Data.Entities.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Collections;

namespace Help247.Data.Entities
{
    [Table("HelperCategories")]
    public class HelperCategory : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string IconUrl { get; set; }
        public string ImageUrl { get; set; }

        //internal string _ServicesProvided { get; set; }

        //[NotMapped]
        //public ServicesProvided ServicesProvided
        //{
        //    get { return _ServicesProvided == null ? null : JsonConvert.DeserializeObject<ServicesProvided>(_ServicesProvided);  }
        //    set { _ServicesProvided = JsonConvert.SerializeObject(value);  }
        //}

        public Dictionary<string, string> ServicesProvided { get; set; } = new Dictionary<string, string>();
    }
}
