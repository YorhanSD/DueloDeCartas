using System.Collections.Generic;
using UnityEngine;

public class Baralho_Oponente : MonoBehaviour
{
    //LISTAS EXCLUSIVAS PARA CARTAS CLONES
    public List<CartaDaCena> deckOponente = new List<CartaDaCena>();
    [SerializeField] private List<CartaDaCena> cenaTemp = new List<CartaDaCena>();
    [SerializeField] private List<CartaDaCena> bancoDeCartasSelecionadas = new List<CartaDaCena>();
    [SerializeField] private List<CartaOriginal> dadosTemp = new List<CartaOriginal>();

    public List<Case> casesOponente = new List<Case>();

    [SerializeField] UICard uiPrefab;
    [SerializeField] Transform uiParent;

    public SalvaJogoPC salvaJogoPC;
    public BancoCards bancoCartas;

    public Canvas canvas;
    public int numeroAleatorio;
    public int casaReferenciaDeMenorPosicao = 12;
    public Transform casaTransform;

    bool naoHaCasasDisponiveis;
    public void Awake()
    {
        salvaJogoPC = GetComponent<SalvaJogoPC>();
        bancoCartas = GetComponent<BancoCards>();

        FiltraCartas();
    }

    public void FiltraCartas()
    {
        SalvaOponente salvaOponente = salvaJogoPC.OponenteSalvo();
        Debug.Log($"Oponente escolhido : {salvaOponente.GetNomeOponenteEscolhido()}");

        for (int i = 0; i < 12; i++)
        {
            if (cenaTemp[i].dados.especieSelecionada == salvaOponente.GetEspecieDominante() || cenaTemp[i].dados.especieSelecionada == salvaOponente.GetEspecieRecessiva())
            {
                Debug.Log($"Especie da Carta : {cenaTemp[i].dados.especieSelecionada}");
                Debug.Log($"Especie Dominante : {salvaOponente.GetEspecieDominante()} e Especie Recessiva : {salvaOponente.GetEspecieRecessiva()}");

                bancoDeCartasSelecionadas.Add(cenaTemp[i]);
            }
        }
    }
    public void ProximaCartaAleatoriaOponente()
    {
        numeroAleatorio = Random.Range(0, 6);

        ChecaCasasVazias(numeroAleatorio);
    }
    public void ChecaCasasVazias(int _numeroAleatorio)
    {
        foreach (Case _casa in casesOponente)
        {
            if (_casa.GetCaseOcupadoOponente() == true || _casa.GetCaseOcupadoJogador() == true)
            {
                //SEMPRE QUE HOUVER CASAS OCUPADAS, A POSIÇÃO DE REFERÊNCIA AUMENTA

                if (casaReferenciaDeMenorPosicao < 16)
                {
                    casaReferenciaDeMenorPosicao++;

                    naoHaCasasDisponiveis = true;
                }
            }
            else
            {
                Debug.Log("Há casas disponíveis");

                naoHaCasasDisponiveis = false;

                Case _casaEscolhida = casesOponente.Find(c => c.GetPosicaoCasa() == casaReferenciaDeMenorPosicao);

                DefinePosicaoDaCarta(_casaEscolhida.transform, _numeroAleatorio);

                break;
            }
        }

        
    }
    public void DefinePosicaoDaCarta(Transform _posicaoCasa, int _numeroSortiado)
    {
        if (naoHaCasasDisponiveis == false)
        {
            CartaDaCena cartaClone = Instantiate(bancoDeCartasSelecionadas[_numeroSortiado], _posicaoCasa, false);

            cartaClone.tag = "Carta Oponente";
            cartaClone.GetComponent<MoveCarta>().enabled = false;

            CriaDuplicata(_numeroSortiado, cartaClone);
        }
    }
    public void CriaDuplicata(int _numeroSortiado, CartaDaCena cartaClone)
    {
        CartaRuntime cartaRuntime = new CartaRuntime();
        cartaRuntime.cartaOriginal = bancoDeCartasSelecionadas[_numeroSortiado].cartaBase; ;
        cartaRuntime.Inicializar(bancoCartas.contaID);

        cartaClone.dados = cartaRuntime;

        cartaClone.GravaUI(cartaRuntime);
        cartaClone.PrintaDados(cartaRuntime);

        bancoCartas.geralCartaCenaLista.Add(cartaClone);
        bancoCartas.geralCartaRuntimeLista.Add(cartaRuntime);
        deckOponente.Add(cartaClone);

        cartaClone.transform.localPosition = Vector3.zero;

        bancoCartas.contaID++;
    }

}

