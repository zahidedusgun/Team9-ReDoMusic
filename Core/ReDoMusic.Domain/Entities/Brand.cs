using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReDoMusic.Domain.Common;

namespace ReDoMusic.Domain.Entities
{
    public class Brand : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        //public DateTime EstablishedDate { get; set; }
    }
}
