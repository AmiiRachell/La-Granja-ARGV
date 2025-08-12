using System.Collections;
using UnityEngine;

public class TrigoVida : MonoBehaviour
{
    public float tiempoEspera = 8f;
    public Animator animator;
    public int estadoTrigo = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CambiarEstado());
    }

    private IEnumerator CambiarEstado()
    {
        while (estadoTrigo < 4)
        {
            animator.SetInteger("estado", estadoTrigo);
            estadoTrigo++;
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}