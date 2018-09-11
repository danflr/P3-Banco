using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using P3_Banco.Clases;

namespace P3_Banco
{
    class Program
    {

        private static List<Cuenta> cuentas;

        static void Main(string[] args)
        {
            cuentas = new List<Cuenta>();
            Console.WriteLine(".::::REPROBANCO::::.");
            Console.WriteLine("1.-Crear cuenta\n" +
                              "2.-Depositar\n" +
                              "3.-Retirar\n" +
                              "4.-Consultar\n" +
                              "5.-Salir\n");
            int opc = int.Parse(Console.ReadLine());

            do
            {
                switch (opc)
                {
                    case 1:
                        Cliente cliente = new Cliente();
                        Console.WriteLine("--->Datos del cliente<---");
                        Console.WriteLine("Nombre: ");
                        cliente.nombre = Console.ReadLine();
                        Console.WriteLine("Domicilio: ");
                        cliente.domicilio = Console.ReadLine();
                        Console.WriteLine("Fecha de nacimiento: ");
                        DateTime fecNac = new DateTime();
                        if (!DateTime.TryParse(Console.ReadLine(), out fecNac))
                        {
                            Console.WriteLine("La fecha introducida no es válida, intente de nuevo.");
                        }
                        else
                        {
                            cliente.fechaNacimiento = fecNac;
                        }

                        Console.WriteLine("--->Datos de la cuenta<---");
                        Console.WriteLine("Numero de cuenta: ");
                        int noCuenta = int.Parse(Console.ReadLine());
                        Console.WriteLine("Saldo de apertura: ");
                        double saldoApertura = int.Parse(Console.ReadLine());
                        if (CrearCuenta(cliente, noCuenta, saldoApertura)) Console.WriteLine("Cuenta creada correctamente.");
                        else Console.WriteLine("Ocurrió un error al crear la cuenta, intente de nuevo por favor.");
                        break;
                    case 2:
                        Console.WriteLine("Cuenta del movimiento: ");
                        int nCuenta = int.Parse(Console.ReadLine());
                        Cuenta cuenta = null;
                        foreach (Cuenta c in cuentas)
                        {
                            if (c.numCuenta == nCuenta)
                            {
                                cuenta = c;
                            }
                        }
                        if(cuenta == null) Console.WriteLine("No se encontró ese número de cuenta.");
                        else
                        {
                            Console.WriteLine("Monto: (0.0)");
                            double monto = double.Parse(Console.ReadLine());
                            Movimientos mov = new Movimientos(monto, cuenta.saldo, cuenta.saldo + monto, "Deposito");
                            cuenta.movimientos.Add(mov);
                            Console.WriteLine("Movimiento agregado correctamente.");
                            cuenta.saldo = cuenta.saldo + mov.monto;
                            foreach (Movimientos m in cuenta.movimientos)
                            {
                                Console.WriteLine("Fecha: {0}\tMonto: {1}\tTipo:{2}\tSaldo anterior: {3}\tSaldo actual: {4}", m.fecha, m.monto, m.tipoMovimiento, m.saldoAnterior, m.saldoActual);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Cuenta del movimiento: ");
                        int nCta = int.Parse(Console.ReadLine());
                        Cuenta cta = null;
                        foreach (Cuenta c in cuentas)
                        {
                            if (c.numCuenta == nCta)
                            {
                                cta = c;
                            }
                        }
                        if (cta == null) Console.WriteLine("No se encontró ese número de cuenta.");
                        else
                        {
                            Console.WriteLine("Monto: (0.0)");
                            double monto = double.Parse(Console.ReadLine());
                            Movimientos mov = new Movimientos(monto, cta.saldo, cta.saldo - monto, "Retiro");
                            cta.movimientos.Add(mov);
                            Console.WriteLine("Movimiento agregado correctamente.");
                            cta.saldo = cta.saldo - mov.monto;
                            foreach (Movimientos m in cta.movimientos)
                            {
                                Console.WriteLine("Fecha: {0}\tMonto: {1}\tTipo:{2}\tSaldo anterior: {3}\tSaldo actual: {4}", m.fecha, m.monto, m.tipoMovimiento, m.saldoAnterior, m.saldoActual);
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("->Depositos:");
                        foreach (Cuenta c in cuentas)
                        {
                            Console.WriteLine("Cuenta: {0}", c.numCuenta);
                            foreach (Movimientos m in c.movimientos)
                            {
                                Console.WriteLine("Fecha: {0}\tMonto: {1}\tTipo:{2}\tSaldo anterior: {3}\tSaldo actual: {4}", m.fecha, m.monto, m.tipoMovimiento, m.saldoAnterior, m.saldoActual);
                            }

                        }
                        break;
                }
                Console.WriteLine("\n1.-Crear cuenta\n" +
                                  "2.-Depositar\n" +
                                  "3.-Retirar\n" +
                                  "4.-Consultar\n" +
                                  "5.-Salir\n");
                opc = int.Parse(Console.ReadLine());
            } while (opc > 0 && opc < 5);
            Console.Read();
        }

        public static bool CrearCuenta(Cliente cliente, int numCuenta, double saldo)
        {
            if (cliente != null && numCuenta > 0 && saldo > 0.0)
            {
                Cuenta cuenta = new Cuenta(saldo, numCuenta, cliente);
                cuentas.Add(cuenta);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
