using UnityEngine;

public class EntraESaiCartas : MonoBehaviour
{
    public TrocaLugar trocaLugar;
    public SistemaCombate sistemaCombate;
    public LiberaCasas liberaCasas;
    public Mapeamento_Jogador mapeamentoJogador;
    public BancoCards bancoCards;

    private bool soltou;
    private bool encostou;

    [System.Obsolete]
    private void Start()
    {
        trocaLugar = GetComponent<TrocaLugar>();
        sistemaCombate = GetComponent<SistemaCombate>();
        liberaCasas = GetComponent<LiberaCasas>();
        mapeamentoJogador = GetComponent<Mapeamento_Jogador>();
        bancoCards = GetComponent<BancoCards>();
    }
    
    public void MovimentaCartaParaCasa(CartaDaCena _cartaEntrando, Transform _casaTransfrom)
    {
        _cartaEntrando.transform.SetParent(_casaTransfrom, false);
        _cartaEntrando.transform.localPosition = Vector3.zero;
        _cartaEntrando.SetMoveuSe(true);
        _cartaEntrando.SetPodeAtacar(false);
    }
    public void ProcuraCartaDentroDaCasa(int _ID, CartaDaCena _cartaEntrando)
    {
        CartaDaCena carta = bancoCards.geralCartaCenaLista
     .Find(c => c.dados.ID == _ID);

        if (carta != null)
        {
            //Debug.Log($"Encontrou {carta.dados.nome}");
            ChamaCombate(carta, _cartaEntrando);
        }
    }
    public void ChamaTroca(int _ID, CartaDaCena _vanguarda)
    {
        foreach (CartaDaCena _carta in bancoCards.geralCartaCenaLista)
        {
            if (_carta.dados.ID == _ID)
            {
                trocaLugar.VerificaPosicaoDasCartas(_carta, _vanguarda);
            }
        }
    }
    public void SetEncostouEmOutraCarta(bool _encostou)
    {
        encostou = _encostou;
    }
    public bool GetEncostouEmOutraCarta()
    {
        return encostou;
    }
    public void ChamaCombate(CartaDaCena _ocupante, CartaDaCena _entrando)
    {
        sistemaCombate.UmContraUm(_ocupante.dados.ID, _entrando.dados.ID);
    }
    public void ChamaMapeamentoJogador(CartaDaCena _cartaJogador)
    {
        mapeamentoJogador.VerificaPossicaoAtualDaCartaDoJogador(_cartaJogador.dados.ID);
    }
    public void LiberaCasaQueEntrou(int _posicaoCasa)
    {
        liberaCasas.Liberar(_posicaoCasa);
    }
    public void SetVerificaSeSoltouCarta(bool _soltou)
    {
        soltou = _soltou;
    }
    public bool GetVerificaSeSoltouCarta()
    {
        return soltou;
    }
}
