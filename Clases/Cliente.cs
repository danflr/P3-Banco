using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Banco.Clases
{
    class Cliente
    {
        public string nombre { get; set; }
        public string domicilio { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nombre, string domicilio, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.domicilio = domicilio;
            this.fechaNacimiento = fechaNacimiento;
        }

    }
}
