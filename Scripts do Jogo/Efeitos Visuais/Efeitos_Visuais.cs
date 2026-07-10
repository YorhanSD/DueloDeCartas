using System.Collections;
using UnityEngine;

public class Efeitos_Visuais : MonoBehaviour
{
    public GameObject[] casasPossiveis;
    public void ativaPisca_Pisca()
    {
        StartCoroutine(PiscaCasas());
    }
    private IEnumerator PiscaCasas()
    {
        casasPossiveis[0].SetActive(true);
        casasPossiveis[1].SetActive(true);
        casasPossiveis[2].SetActive(true);
        casasPossiveis[3].SetActive(true);
        yield return new WaitForSeconds(1);
        casasPossiveis[0].SetActive(false);
        casasPossiveis[1].SetActive(false);
        casasPossiveis[2].SetActive(false);
        casasPossiveis[3].SetActive(false);
    }
}
