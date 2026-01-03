using System.Collections.Generic;
using UnityEngine;

public class Baralho_Oponente : MonoBehaviour
{
    //LISTAS EXCLUSIVAS PARA CARTAS CLONES
    [SerializeField] private List<CartaDaCena> cartaTemp = new List<CartaDaCena>();
    [SerializeField] private List<CartaOriginal> dadosTemp = new List<CartaOriginal>();

    public List<Case> casesOponente = new List<Case>();

    [SerializeField] UICard uiPrefab;
    [SerializeField] Transform uiParent;

    BancoCards bancoCartas;
    SistemaCombate sistemaCombate;
    Baralho baralho;

    public Canvas canvas;
    Deck deck;

    public int numeroAleatorio;
    //public Transform baralhoTransform;
    public int guardaPosicaoDaCasa;
    //public int casaDisponivel;
    //public bool existeCasasOcupadasPeloOponente;
    public int casaReferenciaDeMenorPosicao = 8;
    public Transform casaTransform;

    //IA_MapeamentoDeCases ia_MapeamentoDeCases;
    public void Start()
    {
        sistemaCombate = GetComponent<SistemaCombate>();
        deck = GetComponent<Deck>();
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
        casaReferenciaDeMenorPosicao = 8;

        foreach (Case _casa in casesOponente)
        {
            if (_casa.GetCaseOcupadoOponente() == true)
            {
                //SEMPRE QUE HOUVER CASAS OCUPADAS, A POSIÇÃO DE REFERÊNCIA AUMENTA
                if (casaReferenciaDeMenorPosicao < 14)
                {
                    casaReferenciaDeMenorPosicao++;
                    Debug.Log($"Próxima casa livre: {casaReferenciaDeMenorPosicao}");
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
        CartaDaCena cartaClone = Instantiate(cartaTemp[_numeroSortiado], _posicaoCasa, false);

        CriaDuplicata(_numeroSortiado, cartaClone);
    }
    public void CriaDuplicata(int _numeroSortiado, CartaDaCena cartaClone)
    {
        baralho.contador++;

        CartaRuntime cartaRuntime = new CartaRuntime();
        cartaRuntime.cartaOriginal = dadosTemp[_numeroSortiado];
        cartaRuntime.Inicializar(baralho.contador);
        cartaClone.GravaUI(cartaRuntime);

        bancoCartas.geralCartaCenaLista.Add(cartaClone);
        bancoCartas.geralCartaRuntimeLista.Add(cartaRuntime);

        cartaClone.transform.localPosition = Vector3.zero;
    }

}

