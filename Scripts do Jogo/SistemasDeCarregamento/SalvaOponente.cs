using UnityEngine;

[System.Serializable]
public class SalvaOponente
{
    private int idOponente;
    private bool eOponente;
    private string nomeOponente;
    private string paisOponente;
    private string especieRecessivaOponente;
    private string especieDominanteOponente;
    public void SetEOponente(bool _eOponente)
    {
        eOponente = _eOponente;
    }
    public bool GetEOponente()
    {
        return eOponente;
    }
    public void SetEspecieDominente(string _especieDominanteOponente)
    {
        especieDominanteOponente = _especieDominanteOponente;
    }
    public string GetEspecieDominante()
    {
        return especieDominanteOponente;
    }
    public void SetEspecieRecessiva(string _especieRecessivaOponente)
    {
        especieRecessivaOponente = _especieRecessivaOponente;
    }
    public string GetEspecieRecessiva()
    {
        return especieRecessivaOponente;
    }
    public void SetNomeOponenteEscolhido(string _nomeOponente)
    {
        nomeOponente = _nomeOponente;
    }
    public string GetNomeOponenteEscolhido()
    {
        return nomeOponente;
    }
    public void SetOponenteEscolhido(int _idOponente)
    {
        idOponente = _idOponente;
    }
    public int GetOponenteEscolhido()
    {
        return idOponente;
    }
    public string GetPais()
    {
        return paisOponente;
    }
    public void SetPais(string _paisOponente)
    {
        paisOponente = _paisOponente;
    }
}
