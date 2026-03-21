using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BancoCards : MonoBehaviour
{
    //public List<UICard> geralCartaUILista = new List<UICard>();
    public List<CartaRuntime> geralCartaRuntimeLista = new();
    public List<CartaDaCena> geralCartaCenaLista = new();

    [SerializeField] CartaRuntime card;
    [SerializeField] CartaDaCena cartaCena;
    [SerializeField] UICard uiPrefab;

    public int contaID = 0;
    public int numeroTotalDeCartasAtualmente = 12;

    void Awake()
    {
        CriarCartasDaCena();
    }
    
    public void CriarCartasDaCena()
    {
        for (int i = 0; i < numeroTotalDeCartasAtualmente; i++)
        {
            CartaRuntime runtime = new CartaRuntime();
            runtime.cartaOriginal = geralCartaCenaLista[contaID].cartaBase;
            runtime.Inicializar(contaID);

            geralCartaRuntimeLista.Add(runtime);
            geralCartaCenaLista[contaID].dados = runtime;

            geralCartaCenaLista[contaID].GravaUI(runtime);

            contaID++;
        }
    }
}
