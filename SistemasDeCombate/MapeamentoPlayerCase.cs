using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapeamentoPlayerCase : MonoBehaviour
{
    public List<Case> listaCase = new List<Case>();

    int contador = 0;

    private void Start()
    {
        listaCase[contador].SetCaseID(contador);
        contador++;
        listaCase[contador].SetCaseID(contador);
        contador++;
    }
    public void AtivaCase()
    {

    }

    public void procuraCaseOcupado(string _nomeCarta)
    {
        foreach (Case casa in listaCase)
        {
            if(casa.GetGuardaCartaNome() == null)
            {

            }
            if (casa.GetCaseOcupado())
            {
                //listaCase[casa.GetCaseID()].SetGuardaCartaNome(_nomeCarta);
            }
        }
    }
}
