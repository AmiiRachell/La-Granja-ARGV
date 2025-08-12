using System.Collections;
using UnityEngine;

public class TrigoVida : MonoBehaviour
{
    public float tiempoEspera = 8f;
    public Animator animator;
    public int estadoTrigo = 0;
    public bool isMature = false;

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

            if (estadoTrigo == 4)
            {
                isMature = true;
                Debug.Log("El trigo está maduro");
            }

            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}