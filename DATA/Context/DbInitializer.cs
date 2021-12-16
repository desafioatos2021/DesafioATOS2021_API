using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.DATA.Interfaces;
using TeamGM.DATA.Context;
using Base.DOMAIN.Models;

namespace Base.DATA.Context
{
    public static class DbInitializer
    {
        public static void Initialize(DesafioAtosContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Cliente.Any())
            {
                return;   // DB has been seeded
            }

            var clientes = new Cliente[]
            {
                new Cliente{Nome="Felix"},
                new Cliente{Nome="Slow"},
                new Cliente{Nome="Penelope"},
                new Cliente{Nome="Nami"},
                new Cliente{Nome="Sasuke"}
            };
            foreach (Cliente c in clientes)
            {
                context.Cliente.Add(c);
            }
            context.SaveChanges();
        }
    }
}
