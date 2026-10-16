using System;
using System.Collections.Generic;

class NodoDoble<T>
{
    public T Dato = default!;
    public NodoDoble<T>? Anterior;
    public NodoDoble<T>? Siguiente;
}

class ListaDoble<T>
{
    private NodoDoble<T>? cabeza;
    private NodoDoble<T>? cola;
    private int contador;

    public void AgregarAlFinal(T dato)
    {
        NodoDoble<T> nuevo = new NodoDoble<T>
        {
            Dato = dato,
            Anterior = null,
            Siguiente = null
        };

        if (cabeza == null)
        {
            cabeza = nuevo;
            cola = nuevo;
        }
        else
        {
            nuevo.Anterior = cola;
            cola!.Siguiente = nuevo;
            cola = nuevo;
        }

        contador++;
    }

    public void MostrarAdelante()
    {
        NodoDoble<T>? actual = cabeza;

        while (actual != null)
        {
            Console.Write(actual.Dato + " → ");
            actual = actual.Siguiente;
        }

        Console.WriteLine("null");
    }

    public void MostrarAtras()
    {
        NodoDoble<T>? actual = cola;

        while (actual != null)
        {
            Console.Write(actual.Dato + " → ");
            actual = actual.Anterior;
        }

        Console.WriteLine("null");
    }

    public int Contar()
    {
        return contador;
    }
    
    public bool Eliminar(T dato)
    {
        NodoDoble<T>? actual = cabeza;

    
        while (actual != null &&
               !EqualityComparer<T>.Default.Equals(actual.Dato, dato))
        {
            actual = actual.Siguiente;
        }

        if (actual == null)
        {
            return false;
        }

        if (actual.Anterior == null)
        {
            cabeza = actual.Siguiente;
        }
        else
        {
            actual.Anterior.Siguiente = actual.Siguiente;
        }

        if (actual.Siguiente == null)
        {
            cola = actual.Anterior;
        }
        else
        {
            actual.Siguiente.Anterior = actual.Anterior;
        }

        actual.Anterior = null;
        actual.Siguiente = null;

        contador--;

        return true;
    }
}
class Program
{
    // METODO PARA MOSTRAR LAS PRUEBAS
    static void ProbarCaso<T>(
        string titulo,
        ListaDoble<T> lista,
        T datoEliminar)
    {
        Console.WriteLine("\n" + titulo);

        Console.Write("Antes adelante: ");
        lista.MostrarAdelante();

        Console.Write("Antes atras: ");
        lista.MostrarAtras();

        bool resultado = lista.Eliminar(datoEliminar);

        Console.Write("Despues adelante: ");
        lista.MostrarAdelante();

        Console.Write("Despues atras: ");
        lista.MostrarAtras();

        Console.WriteLine("Resultado: " + resultado);
        Console.WriteLine("Cantidad: " + lista.Contar());
    }
    static void Main()
    {
        Console.WriteLine("RETO: ELIMINAR SIN FRONTERAS");
        Console.WriteLine("NIVEL 2 - LISTA DOBLE");

        // CASO 1: ELIMINAR DEL MEDIO

        ListaDoble<int> lista1 = new ListaDoble<int>();

        lista1.AgregarAlFinal(10);
        lista1.AgregarAlFinal(20);
        lista1.AgregarAlFinal(30);

        ProbarCaso("CASO 1: ELIMINAR DEL MEDIO",
                  lista1, 20);

        // CASO 2: ELIMINAR CABEZA

        ListaDoble<int> lista2 = new ListaDoble<int>();

        lista2.AgregarAlFinal(10);
        lista2.AgregarAlFinal(20);
        lista2.AgregarAlFinal(30);

        ProbarCaso("CASO 2: ELIMINAR CABEZA",
                  lista2, 10);

        // CASO 3: ELIMINAR COLA

        ListaDoble<int> lista3 = new ListaDoble<int>();

        lista3.AgregarAlFinal(10);
        lista3.AgregarAlFinal(20);
        lista3.AgregarAlFinal(30);

        ProbarCaso("CASO 3: ELIMINAR COLA",
                  lista3, 30);

        // CASO 4: ELEMENTO INEXISTENTE

        ListaDoble<int> lista4 = new ListaDoble<int>();

        lista4.AgregarAlFinal(10);
        lista4.AgregarAlFinal(20);
        lista4.AgregarAlFinal(30);

        ProbarCaso("CASO 4: ELEMENTO INEXISTENTE",
                  lista4, 50);

        // CASO 5: LISTA VACIA

        ListaDoble<int> lista5 = new ListaDoble<int>();

        ProbarCaso("CASO 5: LISTA VACIA",
                  lista5, 10);

        // CASO 6: UN SOLO NODO

        ListaDoble<int> lista6 = new ListaDoble<int>();

        lista6.AgregarAlFinal(10);

        ProbarCaso("CASO 6: UN SOLO NODO",
                  lista6, 10);

        // PRUEBA EXTRA: LISTA STRING

        ListaDoble<string> ciudades = new ListaDoble<string>();

        ciudades.AgregarAlFinal("La Paz");
        ciudades.AgregarAlFinal("El Alto");
        ciudades.AgregarAlFinal("Viacha");

        ProbarCaso("PRUEBA EXTRA: LISTA STRING",
                  ciudades, "El Alto");
    }
}