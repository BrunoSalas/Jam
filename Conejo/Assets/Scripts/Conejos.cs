using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Tipos de conejos")]
public class Conejos : ScriptableObject
{
    public enum Tipos
    {
        Blanco,
        Naranja,
        Morado,
        Amarillo
    }
    public Tipos tipos;
    public enum TiposComida
    {
        Zanahoria,
        Veterraga,
        Kion
    }

    [HideInInspector]
    public TiposComida tiposComida;
}
