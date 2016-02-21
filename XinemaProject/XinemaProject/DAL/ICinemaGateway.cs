using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinemaProject.Models;

namespace XinemaProject.DAL
{
    interface ICinemaGateway
    {
        IEnumerable<Cinema> SelectAll();
        Cinema SelectById(int? id);
        void Insert(Cinema cinema);
        void Update(Cinema cinema);
        Cinema Delete(int? id);
        void Save();
    }
}
