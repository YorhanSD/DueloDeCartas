using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoVoltar : MonoBehaviour
{
    public GameObject tela;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FechaMenu()
    {
        tela.SetActive(false);
    }
}
