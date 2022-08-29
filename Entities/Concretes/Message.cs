using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Message:IEntity
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string InMessage { get; set; }
    }
}
