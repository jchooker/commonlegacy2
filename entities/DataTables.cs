using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace CommonLegacy.entities
{
    public class DataTables
    {
        public int draw {  get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<User> data { get; set; }
    }
}