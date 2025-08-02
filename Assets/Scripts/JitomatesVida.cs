using UnityEngine;
using System.Collections;

public class JitomatesVida : MonoBehaviour
{
    public float tiempoEspera = 8f;
    public Animator animator;
    public int estadoJitomate = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
