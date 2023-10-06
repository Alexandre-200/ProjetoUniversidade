using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.EventoContext
{
    public class Tutor : User
    {
        public List<Evento>? Eventos { get; set; }
    }
}
