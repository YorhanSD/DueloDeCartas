using UnityEngine;

public class TrocaLugar : MonoBehaviour
{
    MoveCarta moveCarta;
    IA_MapeamentoDeCases ia_MapeamentoDeCases;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        moveCarta = GetComponent<MoveCarta>();
        ia_MapeamentoDeCases = FindObjectOfType<IA_MapeamentoDeCases>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerificaPosicaoDasCartas(CartaDaCena _retaguarda, CartaDaCena _vanguarda)
    {
        //REGRAS:

        //CARTA RETAGUARDA, FOI COLOCADA AGORA.
        //TEM QUE ESTAR ATRAS DA VANGUARDA

        //CARTA VANGUARDA, FOI COLOCADA ANTES.
        //TEM QUE ESTAR A FRANTE DA RETAGUARDA

        if(_retaguarda.GetMoveuSe() == true && _vanguarda.GetMoveuSe() == false && moveCarta.selecionou == true && moveCarta.encostouEmOutraCartaSua == true)
        {
            //Case _casaAvancada = ia_MapeamentoDeCases.listaCase.Find(c => c.GetIDCartaOcupante() == _vanguarda.dados.ID);
            //Case _casaRecuada = ia_MapeamentoDeCases.listaCase.Find(c => c.GetIDCartaOcupante() == _retaguarda.dados.ID);

            _retaguarda.transform.SetParent(_vanguarda.gameObject.transform, false);
            _retaguarda.transform.localPosition = Vector3.zero;

            _vanguarda.transform.SetParent(_retaguarda.gameObject.transform, false);
            _vanguarda.transform.localPosition = Vector3.zero;
        }
    }
}
