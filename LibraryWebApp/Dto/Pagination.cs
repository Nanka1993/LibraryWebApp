using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Dto
{
    public class Pagination
    {
        public int? Skip { get; set; }

        public int? Take { get; set; }
    }
}
