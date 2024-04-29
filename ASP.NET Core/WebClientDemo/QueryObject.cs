using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClientDemo
{
    /// <summary>
    /// обєкти які потрібно отримати з нода
    /// </summary>
    public class QueryObject
    {
        public long Id { get; set; }
        public Guid Sender { get; set; }
        public Guid Destination { get; set; }
        public string ObjectId { get; set; }
        public string ObjectType { get; set; }

    }
}
