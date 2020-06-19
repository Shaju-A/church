using Church.DataLayer.Db.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.DataLayer.Repositories
{
    public interface IGenderRepository
    {
        IEnumerable<Gender> Genders { get; }
    }
}
