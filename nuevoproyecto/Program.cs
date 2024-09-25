using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace nuevoproyecto
{
    internal class Program
    {

        static int balance = 1000;
        static object balancelock = new object();
        //no me acuerdo xD
        static Random p = new Random();
        //el ramdom se uso para que los hilos sean aletorios 

        static void Main(string[] args)
        {
            
            Thread hilo1 = new Thread(obtener);
            Thread hilo2 = new Thread(obtener);
            Thread hilo3 = new Thread(obtener);
            Thread hilo4 = new Thread(obtener);
            Thread hilo5 = new Thread(obtener);
            
            hilo1.Start();
            hilo2.Start();
            hilo3.Start();
            hilo4.Start();
            hilo5.Start();

            hilo1.Join();
            hilo2.Join();
            hilo3.Join();
            hilo4.Join();
            hilo5.Join();
           
            Console.WriteLine($"Balance final: {balance}");
            Console.ReadLine();
            
        }
        
        static void obtener()
        {
            int retiro = p.Next(10, 100);
            for (int i = 0; i < 6; i++)
                //el for es para el bucle no me acordaba para que lo use x3
            {
                
                lock (balancelock)
                {
                    //para que retire uno por uno

                    if (balance > retiro)
                    {
                        balance -= retiro;
                        Console.WriteLine($" el hilo {Thread.CurrentThread.ManagedThreadId} retiro {retiro} exitosamente el balacen actual es {balance}");
                        Thread.Sleep(1000); //eso va hay tuta loco
                    }
                    else
                    {
                        Console.WriteLine($"El hilo {Thread.CurrentThread.ManagedThreadId} no pudo completar la transacción por saldo insuficiente.");
                    }
                }
            }
        }
    }
}
