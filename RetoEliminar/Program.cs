using System;

class Nodo<T>
{
    public T Dato = default!;
    public Nodo<T>? Siguiente;
}

class ListaSimple<T>
{
    private Nodo<T>? cabeza;
    private int contador;

    public void AgregarAlFinal(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>
        {
            Dato = dato,
            Siguiente = null
        };

        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Nodo<T> actual = cabeza;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }

        contador++;
    }

    public void Mostrar()
    {
        Nodo<T>? actual = cabeza;

        while (actual != null)
        {
            Console.Write(actual.Dato + " → ");
            actual = actual.Siguiente;
        }

        Console.WriteLine("null");
    }

    public int Contar()
    {
        return contador;
    }

    public bool Eliminar(T dato)
    {
    
        if (cabeza == null)
        {
            return false;
        }

        if (Equals(cabeza.Dato, dato))
        {
            cabeza = cabeza.Siguiente;
            contador--;
            return true;
        }

        Nodo<T> anterior = cabeza;

        while (anterior.Siguiente != null &&
               !Equals(anterior.Siguiente.Dato, dato))
        {
            anterior = anterior.Siguiente;
        }

        if (anterior.Siguiente == null)
        {
            return false;
        }

        anterior.Siguiente = anterior.Siguiente.Siguiente;

        contador--;
        return true;
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine(" RETO: ELIMINAR SIN FRONTERAS");
        Console.WriteLine(" NIVEL 1 - LISTA SIMPLE");

        // CASO 1: ELIMINAR NODO DEL MEDIO

        Console.WriteLine("\nCASO 1: ELIMINAR DEL MEDIO");

        ListaSimple<int> lista1 = new ListaSimple<int>();

        lista1.AgregarAlFinal(10);
        lista1.AgregarAlFinal(20);
        lista1.AgregarAlFinal(30);

        Console.Write("Antes: ");
        lista1.Mostrar();

        bool resultado1 = lista1.Eliminar(20);

        Console.Write("Despues: ");
        lista1.Mostrar();

        Console.WriteLine("Resultado: " + resultado1);
        Console.WriteLine("Cantidad: " + lista1.Contar());

        // CASO 2: ELIMINAR LA CABEZA

        Console.WriteLine("\nCASO 2: ELIMINAR CABEZA");

        ListaSimple<int> lista2 = new ListaSimple<int>();

        lista2.AgregarAlFinal(10);
        lista2.AgregarAlFinal(20);
        lista2.AgregarAlFinal(30);

        Console.Write("Antes: ");
        lista2.Mostrar();

        bool resultado2 = lista2.Eliminar(10);

        Console.Write("Despues: ");
        lista2.Mostrar();

        Console.WriteLine("Resultado: " + resultado2);
        Console.WriteLine("Cantidad: " + lista2.Contar());

        // CASO 3: ELIMINAR LA COLA

        Console.WriteLine("\nCASO 3: ELIMINAR COLA");

        ListaSimple<int> lista3 = new ListaSimple<int>();

        lista3.AgregarAlFinal(10);
        lista3.AgregarAlFinal(20);
        lista3.AgregarAlFinal(30);

        Console.Write("Antes: ");
        lista3.Mostrar();

        bool resultado3 = lista3.Eliminar(30);

        Console.Write("Despues: ");
        lista3.Mostrar();

        Console.WriteLine("Resultado: " + resultado3);
        Console.WriteLine("Cantidad: " + lista3.Contar());

        // CASO 4: ELEMENTO QUE NO EXISTE

        Console.WriteLine("\nCASO 4: ELEMENTO INEXISTENTE");

        ListaSimple<int> lista4 = new ListaSimple<int>();

        lista4.AgregarAlFinal(10);
        lista4.AgregarAlFinal(20);
        lista4.AgregarAlFinal(30);

        Console.Write("Antes: ");
        lista4.Mostrar();

        bool resultado4 = lista4.Eliminar(50);

        Console.Write("Despues: ");
        lista4.Mostrar();

        Console.WriteLine("Resultado: " + resultado4);
        Console.WriteLine("Cantidad: " + lista4.Contar());

        // CASO 5: LISTA VACIA

        Console.WriteLine("\nCASO 5: LISTA VACIA");

        ListaSimple<int> lista5 = new ListaSimple<int>();

        Console.Write("Antes: ");
        lista5.Mostrar();

        bool resultado5 = lista5.Eliminar(10);

        Console.Write("Despues: ");
        lista5.Mostrar();

        Console.WriteLine("Resultado: " + resultado5);
        Console.WriteLine("Cantidad: " + lista5.Contar());

        // CASO 6: LISTA CON UN SOLO NODO

        Console.WriteLine("\nCASO 6: UN SOLO NODO");

        ListaSimple<int> lista6 = new ListaSimple<int>();

        lista6.AgregarAlFinal(10);

        Console.Write("Antes: ");
        lista6.Mostrar();

        bool resultado6 = lista6.Eliminar(10);

        Console.Write("Despues: ");
        lista6.Mostrar();

        Console.WriteLine("Resultado: " + resultado6);
        Console.WriteLine("Cantidad: " + lista6.Contar());

        // PRUEBA ADICIONAL: LISTA DE TEXTOS

        Console.WriteLine("\nPRUEBA EXTRA: LISTA STRING");

        ListaSimple<string> ciudades = new ListaSimple<string>();

        ciudades.AgregarAlFinal("La Paz");
        ciudades.AgregarAlFinal("El Alto");
        ciudades.AgregarAlFinal("Viacha");

        Console.Write("Antes: ");
        ciudades.Mostrar();

        bool resultadoTexto = ciudades.Eliminar("El Alto");

        Console.Write("Despues: ");
        ciudades.Mostrar();

        Console.WriteLine("Resultado: " + resultadoTexto);
        Console.WriteLine("Cantidad: " + ciudades.Contar());

    }
}