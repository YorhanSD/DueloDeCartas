using UnityEngine;

public class Regras_Jogo : MonoBehaviour
{
    //AMBOS OS JOGADORES TÊM 2 MINUTOS PARA JOGAR.
    //NO PRIMEIRO TURNO, O JOGADOR DEVE USAR TODAS AS CARTAS, COLOCANDO-AS NAS CASAS DISPONÍVEIS.

    public GameObject telaDeVitoria;
    public GameObject telaDeDerrota;

    public void AtivaTela_Vitoria()
    {
        telaDeVitoria.SetActive(true);
    }

    public void AtivaTela_Derrota()
    {
        telaDeDerrota.SetActive(true);
    }
}
