using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "NovaCarta", menuName = "Cartas/CartaOriginal")]
public class CartaOriginal: ScriptableObject
{
    public int ID;

    public string nome;

    public int vida;

    public int vidaMaxima;

    public int ataque;
}
