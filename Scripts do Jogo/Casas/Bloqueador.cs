using UnityEngine;

public class Bloqueador : MonoBehaviour
{
    private bool desativaBloqueador = false;

    public void SetDesativaBloqueador(bool _desativa)
    {
        desativaBloqueador = _desativa;
    }

    public bool GetDesativaBloqueador()
    {
        return desativaBloqueador;
    }
}
