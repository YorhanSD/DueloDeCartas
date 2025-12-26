using UnityEngine;

[System.Serializable]
public class CartaRuntime
{
    public int ID;
    public string nomeAtual;
    public int ataqueAtual;
    public int vidaAtual;
    public CartaOriginal cartaOriginal;

    public void Inicializar(int ID)
    {
        this.ID = ID;
        nomeAtual = cartaOriginal.nome;
        ataqueAtual = cartaOriginal.ataque;
        vidaAtual = cartaOriginal.vida;
    }
}
