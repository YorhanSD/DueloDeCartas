using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoPlay : MonoBehaviour
{
    public string cena;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CarregaCena()
    {
        SceneManager.LoadScene(cena);
    }

}
