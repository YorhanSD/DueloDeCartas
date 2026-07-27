using System.Collections.Generic;
using UnityEngine;

public class Baralho_Oponente : MonoBehaviour
{
    //LISTAS EXCLUSIVAS PARA CARTAS CLONES
    public List<CartaDaCena> deckOponente = new List<CartaDaCena>();
    [SerializeField] private List<CartaDaCena> cenaTemp = new List<CartaDaCena>();
    [SerializeField] private List<CartaDaCena> bancoDeCartasSelecionadas = new List<CartaDaCena>();
    [SerializeField] private List<CartaOriginal> dadosTemp = new List<CartaOriginal>();

    public List<Casa> casesOponente = new List<Casa>();

    [SerializeField] UICard uiPrefab;
    [SerializeField] Transform uiParent;

    public SalvaJogoPC salvaJogoPC;
    public BancoCards bancoCartas;

    public Canvas canvas;
    public int numeroAleatorio;
    public int casaReferenciaDeMaiorPosicao = 15;
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

        DefinePosicaoDaCarta();
    }
    public void ChecaCasasVazias()
    {
        //for(int i = 16; i > 11; i--)
        //{
            
            Debug.Log("Casa que pode ser aclopada com carta do oponente " + casaReferenciaDeMaiorPosicao);
           // DefinePosicaoDaCarta();
        //}
        //foreach (Casa _casa in casesOponente)
        //{
            //if (_casa.GetCaseOcupadoOponente() == true && _casa.GetCaseOcupadoJogador() == true)
            //{
                //SEMPRE QUE HOUVER CASAS OCUPADAS, A POSIÇÃO DE REFERÊNCIA DIMINUI

                //if (casaReferenciaDeMaiorPosicao > 11)
                //{
                    //casaReferenciaDeMaiorPosicao--;

                    //Debug.Log("Casa que pode ser aclopada com carta do oponente " + casaReferenciaDeMaiorPosicao);

                    //naoHaCasasDisponiveis = true;
                //}
            //}
            //else
            //{
                //Debug.Log("Há casas disponíveis");

                //naoHaCasasDisponiveis = false;

                //Casa _casaEscolhida = casesOponente.Find(c => c.GetPosicaoCasa() == casaReferenciaDeMaiorPosicao);

                //DefinePosicaoDaCarta(_casaEscolhida.transform, _numeroAleatorio);

                //break;
            //}
        //}

        
    }
    public void DefinePosicaoDaCarta()
    {
        Casa _casaEscolhida = casesOponente.Find(c => c.GetPosicaoCasa() == casaReferenciaDeMaiorPosicao);
        //if (naoHaCasasDisponiveis == false)
        //{
        CartaDaCena cartaClone = Instantiate(bancoDeCartasSelecionadas[numeroAleatorio], _casaEscolhida.transform, false);

            cartaClone.tag = "Carta Oponente";
            cartaClone.GetComponent<MoveCarta>().enabled = false;

            CriaDuplicata(cartaClone);
        //}
    }
    public void CriaDuplicata(CartaDaCena cartaClone)
    {
        CartaRuntime cartaRuntime = new CartaRuntime();
        cartaRuntime.cartaOriginal = bancoDeCartasSelecionadas[numeroAleatorio].cartaBase; ;
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

