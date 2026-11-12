
// Program.cs - Tema 6: Árboles de Búsqueda Binaria

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

    // Método para insertar un dato
    public void Insertar(int dato)
    {
        raiz = InsertarRecursivo(raiz, dato);
    }

    private NodoArbol InsertarRecursivo(NodoArbol nodo, int dato)
    {
        if (nodo == null)
            return new NodoArbol(dato);

        if (dato < nodo.Dato)
            nodo.HijoIzquierdo = InsertarRecursivo(nodo.HijoIzquierdo, dato);

        else if (dato > nodo.Dato)
            nodo.HijoDerecho = InsertarRecursivo(nodo.HijoDerecho, dato);

        // Si el dato ya existe, no se inserta.

        return nodo;
    }

    // Método para buscar un dato
    public bool Buscar(int dato)
    {
        return BuscarRecursivo(raiz, dato);
    }

    private bool BuscarRecursivo(NodoArbol nodo, int dato)
    {
        if (nodo == null)
            return false;

        if (dato == nodo.Dato)
            return true;

        return dato < nodo.Dato
            ? BuscarRecursivo(nodo.HijoIzquierdo, dato)
            : BuscarRecursivo(nodo.HijoDerecho, dato);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();

        // Insertar valores
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);
        arbol.Insertar(20);
        arbol.Insertar(40);
        arbol.Insertar(60);
        arbol.Insertar(80);

        // Buscar valores
        Console.WriteLine("Existe 40? " + arbol.Buscar(40));
        Console.WriteLine("Existe 90? " + arbol.Buscar(90));
    }
}
