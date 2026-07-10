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

    public string funcao; // Finalizador / Articulador / Sustentador / Punidor / Combatente / Guardiao

    public enum Especies // Espacial / Angelical / Tenebroso / Extinto
    {
        Celestial, Espacial, Extinto, Tenebroso
    };

    public Especies especie;

    public bool especieDominante;

    public bool especieRecessiva;

    public string nome;

    public int vida;

    public int vidaMaxima;

    public int ataque;

    public int couraca; // quando chega a 0 a criatura recebe 100 % do ataque oponente, em vez de 50 %
                        // diminui em 10 para cada ataque sofrido
    public int couracaMaxima;

    public int reacao;  // capacidade de dano que a criatura tem de revidar ao alvo que ataca ela.

    public int lucidez; // quando chega a 0 a criatura tem 50 % de chance de errar o ataque.
                        // diminui em 10 para cada ataque recebido
}
