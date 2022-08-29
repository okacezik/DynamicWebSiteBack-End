using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Mission:IEntity
    {
        public int Id { get; set; }
        public string ToDo { get; set; }
        public bool IsComplete { get; set; }
    }
}
