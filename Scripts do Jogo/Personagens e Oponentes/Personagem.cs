using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NovoPersonagem", menuName = "Personagem/PersonagemOriginal")]
public class Personagem : ScriptableObject
{
    public int id;

    public bool eOponente = false;

    public Image fotoPersonagem;

    public string nome;

    public string sobrinome;

    public int idade;

    public string profissao;

    public string pais;

    [TextArea(7, 7)]
    public string lore;

    public string elencoDominante;

    public string elencoRecessivo;
}
