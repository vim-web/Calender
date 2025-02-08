using System.Collections.Generic;

namespace Clnder.Controllers
{
    internal class ApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public IEnumerable<object> TodoTasks { get; internal set; }
    }
}