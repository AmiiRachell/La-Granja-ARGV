using UnityEngine;
using System.Collections;

public class TrigoVida : MonoBehaviour
{
    public float tiempoEspera = 8f;
    public Animator animator;
    public int estadoTrigo = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        animator = GetComponent<Animator>();
        StartCoroutine(CambiarEstado());

    }

    private IEnumerator CambiarEstado(){
        while(estadoTrigo <4){
            animator.SetInteger("estado", estadoTrigo);
            estadoTrigo++;
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
    
        
    
}
