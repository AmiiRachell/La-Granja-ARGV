using System.Collections;
using UnityEngine;

public class JitomateVida : MonoBehaviour
{
    public float tiempoEspera = 8f;
    public Animator animator;
    public int estadoJitomate = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CambiarEstado());
    }

    private IEnumerator CambiarEstado()
    {
        while (estadoJitomate < 4)
        {
            animator.SetInteger("estado", estadoJitomate);
            estadoJitomate++;
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}
