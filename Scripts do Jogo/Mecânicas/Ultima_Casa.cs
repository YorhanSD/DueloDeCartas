using UnityEngine;

public class Ultima_Casa : MonoBehaviour
{
    Regras_Jogo regrasJogo;

    [System.Obsolete]
    private void Start()
    {
        regrasJogo = FindObjectOfType<Regras_Jogo>();
    }

    public void OnTriggerEnter2D(Collider2D _carta)
    {
        if (_carta.gameObject.tag == "Card Oponente")
        {
            regrasJogo.AtivaTela_Derrota();
        }

        if (_carta.gameObject.tag == "Card Player")
        {
            regrasJogo.AtivaTela_Vitoria();
        }
    }
}
