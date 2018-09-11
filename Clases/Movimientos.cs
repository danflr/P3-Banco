using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Banco.Clases
{
    class Movimientos
    {
        public double monto { get; set; }
        public DateTime fecha { get; set; }
        public double saldoAnterior { get; set; }
        public double saldoActual { get; set; }
        public string tipoMovimiento { get; set; }

        public Movimientos()
        {

        }

        public Movimientos(double monto, double saldoAnterior, double saldoActual, string tipoMovimiento)
        {
            this.monto = monto;
            this.fecha = DateTime.Now;
            this.saldoAnterior = saldoAnterior;
            this.saldoActual = saldoActual;
            this.tipoMovimiento = tipoMovimiento;
        }
    }
}
