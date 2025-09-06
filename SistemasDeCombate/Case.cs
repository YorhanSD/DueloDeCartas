using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    //[SerializeField] private Vector3 casePosicao;
    [SerializeField] int caseID = 0;
    [SerializeField] private bool caseOcupado;
    [SerializeField] private string guardaNomeCarta;

    private void Start()
    {
        //posicaoCase = transform.position;
    }
    public void SetCaseID(int _caseID)
    {
        caseID = _caseID;
    }
    public int GetCaseID()
    {
        return caseID;
    }
    public void SetCaseOcupado(bool _caseOcupado)
    {
        caseOcupado = _caseOcupado;
    }
    public bool GetCaseOcupado()
    {
        return caseOcupado;
    }
    public void SetGuardaCartaNome(string _nomeCarta)
    {
        guardaNomeCarta = _nomeCarta;
    }
    public string GetGuardaCartaNome()
    {
        return guardaNomeCarta;
    }

    public void OnTriggerEnter2D(Collider2D _carta)
    {
        if (_carta.gameObject.tag == "Card Player" && GetCaseOcupado() != true)
        {
            SetCaseOcupado(true);
            SetGuardaCartaNome(_carta.gameObject.name);
        }
    }
    public void OnTriggerExit2D(Collider2D _carta)
    {
        if (_carta.gameObject.tag == "Card Player" && GetCaseOcupado() != false)
        {
            SetCaseOcupado(false);
            SetGuardaCartaNome(null);
        }
    }
    /*
    public void SetCasePosicao(Vector2 _casePosicao)
    {
        casePosicao = new Vector2 (_casePosicao.x, _casePosicao.y);
    }
    public Vector2 GetCasePosicao()
    {
        return casePosicao;
    }
    */

}
