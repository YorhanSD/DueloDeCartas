using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class CartaRuntime
{
    public int ID;
    public string especieSelecionada;
    public string nome;
    public int ataqueAtual;
    public int vidaAtual;
    public int vidaMaxima;
    public int couraca;
    public int reacao;
    public int lucidez;

    public CartaOriginal cartaOriginal;
    public UICard uiCard;

    public void Inicializar(int ID)
    {
        //ID vem de fora
        this.ID = ID;
        especieSelecionada = cartaOriginal.especie.ToString();
        nome = cartaOriginal.nome;
        ataqueAtual = cartaOriginal.ataque;
        vidaAtual = cartaOriginal.vida;
        vidaMaxima = cartaOriginal.vidaMaxima;
        couraca = cartaOriginal.couraca;
        reacao = cartaOriginal.reacao;
        lucidez = cartaOriginal.lucidez;
    }
}
