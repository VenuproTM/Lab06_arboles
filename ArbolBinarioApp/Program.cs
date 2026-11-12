
using System;
using System.Collections.Generic;

class NodoArbol
{
    public int Dato;
    public NodoArbol HijoIzquierdo;
    public NodoArbol HijoDerecho;

    public NodoArbol(int dato)
    {
        Dato = dato;
        HijoIzquierdo = null;
        HijoDerecho = null;
    }
}

class ArbolBinarioBusqueda
{
    public NodoArbol raiz;

    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    // INSERTAR
    public void Insertar(int dato)
    {
        raiz = InsertarRecursivo(raiz, dato);
    }

    private NodoArbol InsertarRecursivo(NodoArbol nodo, int dato)
    {
        if (nodo == null)
        {
            return new NodoArbol(dato);
        }

        if (dato < nodo.Dato)
        {
            nodo.HijoIzquierdo = InsertarRecursivo(nodo.HijoIzquierdo, dato);
        }
        else if (dato > nodo.Dato)
        {
            nodo.HijoDerecho = InsertarRecursivo(nodo.HijoDerecho, dato);
        }

        return nodo;
    }

    // ELIMINAR
    public void Eliminar(int dato)
    {
        raiz = EliminarRecursivo(raiz, dato);
    }

    private NodoArbol EliminarRecursivo(NodoArbol nodo, int dato)
    {
        if (nodo == null)
        {
            return null;
        }

        if (dato < nodo.Dato)
        {
            nodo.HijoIzquierdo = EliminarRecursivo(nodo.HijoIzquierdo, dato);
        }
        else if (dato > nodo.Dato)
        {
            nodo.HijoDerecho = EliminarRecursivo(nodo.HijoDerecho, dato);
        }
        else
        {
            // Caso 1 y 2: sin hijo izquierdo
            if (nodo.HijoIzquierdo == null)
            {
                return nodo.HijoDerecho;
            }

            // Caso 2: sin hijo derecho
            if (nodo.HijoDerecho == null)
            {
                return nodo.HijoIzquierdo;
            }

            // Caso 3: dos hijos
            NodoArbol sucesor = EncontrarMinimo(nodo.HijoDerecho);

            nodo.Dato = sucesor.Dato;

            nodo.HijoDerecho = EliminarRecursivo(
                nodo.HijoDerecho, sucesor.Dato);
        }

        return nodo;
    }

    private NodoArbol EncontrarMinimo(NodoArbol nodo)
    {
        while (nodo.HijoIzquierdo != null)
        {
            nodo = nodo.HijoIzquierdo;
        }

        return nodo;
    }

    // RECORRIDO PREORDEN
    public void RecorrerPreorden(NodoArbol nodo, List<int> resultado)
    {
        if (nodo == null)
        {
            return;
        }

        resultado.Add(nodo.Dato);

        RecorrerPreorden(nodo.HijoIzquierdo, resultado);
        RecorrerPreorden(nodo.HijoDerecho, resultado);
    }

    // RECORRIDO INORDEN
    public void RecorrerInorden(NodoArbol nodo, List<int> resultado)
    {
        if (nodo == null)
        {
            return;
        }

        RecorrerInorden(nodo.HijoIzquierdo, resultado);

        resultado.Add(nodo.Dato);

        RecorrerInorden(nodo.HijoDerecho, resultado);
    }

    // RECORRIDO POSTORDEN
    public void RecorrerPostorden(NodoArbol nodo, List<int> resultado)
    {
        if (nodo == null)
        {
            return;
        }

        RecorrerPostorden(nodo.HijoIzquierdo, resultado);
        RecorrerPostorden(nodo.HijoDerecho, resultado);

        resultado.Add(nodo.Dato);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();

        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);
        arbol.Insertar(20);
        arbol.Insertar(40);
        arbol.Insertar(60);
        arbol.Insertar(80);

        List<int> preorden = new List<int>();
        arbol.RecorrerPreorden(arbol.raiz, preorden);

        Console.WriteLine("RECORRIDO PREORDEN:");
        Console.WriteLine(string.Join(", ", preorden));

        List<int> inorden = new List<int>();
        arbol.RecorrerInorden(arbol.raiz, inorden);

        Console.WriteLine("\nRECORRIDO INORDEN:");
        Console.WriteLine(string.Join(", ", inorden));

        List<int> postorden = new List<int>();
        arbol.RecorrerPostorden(arbol.raiz, postorden);

        Console.WriteLine("\nRECORRIDO POSTORDEN:");
        Console.WriteLine(string.Join(", ", postorden));

        Console.WriteLine("\nELIMINANDO EL NODO 30...");
        arbol.Eliminar(30);

        List<int> nuevoInorden = new List<int>();
        arbol.RecorrerInorden(arbol.raiz, nuevoInorden);

        Console.WriteLine("ARBOL DESPUES DE ELIMINAR:");
        Console.WriteLine(string.Join(", ", nuevoInorden));
    }
}
