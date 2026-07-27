using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class TrocaLugar : MonoBehaviour
{
    Casa casaRetaguarda = null;
    Casa casaVanguarda = null;

    public IA_MapeamentoDeCases ia_MapeamentoDeCases;
    public EntraESaiCartas entraESaiCartas;

    [System.Obsolete]
    void Start()
    {
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
        entraESaiCartas = GetComponent<EntraESaiCartas>();
    }

    public void VerificaPosicaoDasCartas(CartaDaCena _retaguarda, CartaDaCena _vanguarda)
    {
        Debug.Log($"A carta de retaguarda é : {_retaguarda.dados.nome}");
        Debug.Log($"A carta da vanguarda é : {_vanguarda.dados.nome}");

        if (entraESaiCartas.GetEncostouEmOutraCarta() == true && _retaguarda.GetEstaAtivada() == true)
        {
            foreach (Casa casa in ia_MapeamentoDeCases.listaCase)
            {
                if (casa.GetIDCartaOcupante() == _retaguarda.dados.ID)
                    casaRetaguarda = casa;

                if (casa.GetIDCartaOcupante() == _vanguarda.dados.ID)
                    casaVanguarda = casa;
            }

            if (casaRetaguarda == null || casaVanguarda == null)
                return;

            //casaVanguarda.CartaSai(_vanguarda);

            casaVanguarda.CartaEntra(_retaguarda, casaVanguarda.transform);

            //casaRetaguarda.CartaSai(_retaguarda);

            casaRetaguarda.CartaEntra(_vanguarda, casaRetaguarda.transform);

            entraESaiCartas.SetEncostouEmOutraCarta(false);

            //_retaguarda.transform.SetParent(casaVanguarda.transform, false);
            //_retaguarda.transform.localPosition = Vector3.zero;

            //_vanguarda.transform.SetParent(casaRetaguarda.transform, false);
            //_vanguarda.transform.localPosition = Vector3.zero;

            //casaRetaguarda.SetCartaOcupante(_vanguarda);
            //casaRetaguarda.SetIDCartaOcupante(_vanguarda.dados.ID);

            //casaVanguarda.SetCartaOcupante(_retaguarda);
            //casaVanguarda.SetIDCartaOcupante(_retaguarda.dados.ID);

        }
    }
}
