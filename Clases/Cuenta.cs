using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace P3_Banco.Clases
{
    class Cuenta
    {
        public int numCuenta { get; set; }
        public double saldo { get; set; }
        public List<Movimientos> movimientos;
        public Cliente cliente;

        private Cuenta instance;

        public double Depositar(double monto)
        {
            return 0.0;
        }

        public double Retirar(double monto)
        {
            return 0.0;
        }

        public List<Movimientos> consultar(DateTime fecha)
        {
            List<Movimientos> movimientosPorFecha = new List<Movimientos>();
            return movimientosPorFecha;
        }

        public Cuenta()
        {

        }

        public Cuenta(double saldo, int numCuenta, Cliente cliente)
        {
            this.saldo = saldo;
            this.numCuenta = numCuenta;
            this.cliente = cliente;
            this.movimientos = new List<Movimientos>();
        }

    }
}
