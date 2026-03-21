using System.Collections.Generic;
using UnityEngine;

public class Baralho_Oponente : MonoBehaviour
{
    //LISTAS EXCLUSIVAS PARA CARTAS CLONES
    public List<CartaDaCena> deckOponente = new List<CartaDaCena>();
    [SerializeField] private List<CartaDaCena> cenaTemp = new List<CartaDaCena>();
    [SerializeField] private List<CartaOriginal> dadosTemp = new List<CartaOriginal>();

    public List<Case> casesOponente = new List<Case>();

    [SerializeField] UICard uiPrefab;
    [SerializeField] Transform uiParent;

    BancoCards bancoCartas;
    Baralho baralho;
    public Canvas canvas;
    public int numeroAleatorio;
    public int casaReferenciaDeMenorPosicao = 10;
    public Transform casaTransform;

    public void Start()
    {
        bancoCartas = GetComponent<BancoCards>();
        baralho = GetComponent<Baralho>();
    }

    public void ProximaCartaAleatoriaOponente()
    {
        numeroAleatorio = UnityEngine.Random.Range(0, 3);

        ChecaCasasVazias(numeroAleatorio);
    }
    public void ChecaCasasVazias(int _numeroAleatorio)
    {
        casaReferenciaDeMenorPosicao = 10;

        foreach (Case _casa in casesOponente)
        {
            if (_casa.GetCaseOcupadoOponente() == true || _casa.GetCaseOcupadoJogador() == true)
            {
                //SEMPRE QUE HOUVER CASAS OCUPADAS, A POSIÇÃO DE REFERÊNCIA AUMENTA

                if (casaReferenciaDeMenorPosicao < 14)
                {
                    casaReferenciaDeMenorPosicao++;
                }
            }
            else
            {
                break;
            }
        }

        Case _casaEscolhida = casesOponente.Find(c => c.GetPosicaoCasa() == casaReferenciaDeMenorPosicao);
        //casaTransform = _casaEscolhida.transform;
        DefinePosicaoDaCarta(_casaEscolhida.transform, _numeroAleatorio);
    }
    public void DefinePosicaoDaCarta(Transform _posicaoCasa, int _numeroSortiado)
    {
        CartaDaCena cartaClone = Instantiate(cenaTemp[_numeroSortiado], _posicaoCasa, false);

        CriaDuplicata(_numeroSortiado, cartaClone);
    }
    public void CriaDuplicata(int _numeroSortiado, CartaDaCena cartaClone)
    {
        CartaRuntime cartaRuntime = new CartaRuntime();
        cartaRuntime.cartaOriginal = dadosTemp[_numeroSortiado];
        cartaRuntime.Inicializar(bancoCartas.contaID);

        cartaClone.dados = cartaRuntime;

        cartaClone.GravaUI(cartaRuntime);
        cartaClone.PrintaDados(cartaRuntime);
        //cartaClone.uiCarta.AtualizarUI(cartaClone.dados);

        //cartaClone.GravaDados(cartaRuntime);

        //Debug.Log($"Baralho jogador gerou a carta: {cartaRuntime.nomeAtual} com o ID: {cartaRuntime.ID}");

        bancoCartas.geralCartaCenaLista.Add(cartaClone);
        bancoCartas.geralCartaRuntimeLista.Add(cartaRuntime);
        deckOponente.Add(cartaClone);

        cartaClone.transform.localPosition = Vector3.zero;

        bancoCartas.contaID++;
    }

}

