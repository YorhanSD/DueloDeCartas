using System.Collections;
using UnityEngine;

public class TrocaLugar : MonoBehaviour
{
    public IA_MapeamentoDeCases ia_MapeamentoDeCases;
    public Trava_Casas travaCasas;

    private bool verificaSeSoltou;

    [System.Obsolete]
    void Start()
    {
        travaCasas = GetComponent<Trava_Casas>();
        ia_MapeamentoDeCases = GetComponent<IA_MapeamentoDeCases>();
    }

    public void SetVerificaSoltouCarta(bool _verificaSeSoltou)
    {
        verificaSeSoltou = _verificaSeSoltou;
    }

    public bool GetVerificaSoltou()
    {
        return verificaSeSoltou;
    }

    public void VerificaPosicaoDasCartas(CartaDaCena _retaguarda, CartaDaCena _vanguarda)
    {
        Debug.Log($"A carta de retaguarda é : {_retaguarda.dados.nome}");
        Debug.Log($"A carta da vanguarda é : {_vanguarda.dados.nome}");

        if (GetVerificaSoltou() == true)
        {
            foreach (Case casa in ia_MapeamentoDeCases.listaCase)
            {
                if (casa.GetIDCartaOcupante() == _vanguarda.dados.ID && _vanguarda.GetEstaAtivada() == true)
                {
                    _vanguarda.transform.SetParent(_retaguarda.gameObject.transform, false);
                    _vanguarda.transform.localPosition = Vector3.zero;

                    _retaguarda.transform.SetParent(casa.gameObject.transform, false);
                    _retaguarda.transform.localPosition = Vector3.zero;

                    StartCoroutine(aguardaMovimento(casa, _retaguarda, _vanguarda));

                    break;
                }
            }
        }
    }

    public IEnumerator aguardaMovimento(Case casa, CartaDaCena _retaguarda, CartaDaCena _vanguarda)
    {
        yield return new WaitForSeconds(0.1f);

        //casa.OcuparCasa(_retaguarda);

        foreach (Case _casa in ia_MapeamentoDeCases.listaCase)
        {
            if (_casa.GetIDCartaOcupante() == _vanguarda.dados.ID) // Pega a posição da carta que estava no lugar
            {
                travaCasas.BloqueiaCasas(_casa.GetPosicaoCasa());
            }
        }

        //travaCasas.BloqueiaCasas(casa.GetPosicaoCasa());

        //travaCasas.BloqueiaCasas(casa.GetPosicaoCasa());

        //break;
        //}
        //}

        //yield return new WaitForSeconds(0.4f);

        //_vanguarda.SetMoveuSe(false);
        //_vanguarda.SetPodeAtacar(true);
    }
}
