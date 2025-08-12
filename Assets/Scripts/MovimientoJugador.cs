using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public Vector2 entrada;
    public Rigidbody2D rb;
    public float velocidad = 5f;
    private Animator animator;
    public GameObject huevoPreFab;
    public GameObject trigoPreFab;
    public GameObject jitomatePreFab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = velocidad * entrada;
    }
    public void Movimiento(InputAction.CallbackContext contexto){
        

        Vector2 valorEntrada = contexto.ReadValue<Vector2>();

        animator.SetBool("estaCaminando", true);

        // Determinar el eje dominante
        if (Mathf.Abs(valorEntrada.x) > Mathf.Abs(valorEntrada.y))
        {
            // Movimiento horizontal
            entrada = new Vector2(Mathf.Sign(valorEntrada.x), 0);
        }
        else if (Mathf.Abs(valorEntrada.y) > 0)
        {
            // Movimiento vertical
            entrada = new Vector2(0, Mathf.Sign(valorEntrada.y));
        }
        else
        {
            entrada = Vector2.zero;
        }

        animator.SetFloat("entradaX", entrada.x);
        animator.SetFloat("entradaY", entrada.y);

        if (contexto.canceled)
        {
            animator.SetBool("estaCaminando", false);
        }
    }



    public void SembrarTrigo(InputAction.CallbackContext contexto)
    {
        if (contexto.started)
        {
            Vector3 posicionSiembra = transform.position + new Vector3(0, 1f, 0);
            GameObject nuevoTrigo = Instantiate(trigoPreFab, posicionSiembra, Quaternion.identity);

           
            TrigoVida trigoScript = nuevoTrigo.GetComponent<TrigoVida>();
            if (trigoScript != null)
            {
                trigoScript.estadoTrigo = 0;
                trigoScript.isMature = false;
                trigoScript.StartCoroutine("CambiarEstado"); 
            }

            Debug.Log("Trigo sembrado y ciclo iniciado.");
        }
    }

    public void SembrarJitomate(InputAction.CallbackContext contexto)
    {
        if (contexto.started)
        {
            Vector3 posicionSiembra = transform.position + new Vector3(0, 1f, 0);
            GameObject nuevoJitomate = Instantiate(jitomatePreFab, posicionSiembra, Quaternion.identity);

            JitomateVida jitomateScript = nuevoJitomate.GetComponent<JitomateVida>();
            if (jitomateScript != null)
            {
                jitomateScript.estadoJitomate = 0;
                jitomateScript.isMature = false;
                jitomateScript.StartCoroutine("CambiarEstado");
            }

            Debug.Log(" Jitomate sembrado y ciclo iniciado.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name + " Tag: " + collision.tag);

        if (collision.CompareTag("Huevo"))
        {
            Destroy(collision.gameObject);
            GameManager.instancia.SumarHuevo();
        }
        else if (collision.CompareTag("Trigo"))
        {
            TrigoVida trigoScript = collision.GetComponent<TrigoVida>();

            if (trigoScript != null)
            {
                if (trigoScript.isMature)
                {
                    Destroy(collision.gameObject);
                    GameManager.instancia.SumarTrigo();
                    Debug.Log("Trigo recolectado");
                }
                else
                {
                    Debug.Log(" El trigo aún no está listo para cosechar");
                }
            }
            else
            {
                Debug.Log("Error: El script TrigoVida no está en el objeto trigo");
            }
        }
        else if (collision.CompareTag("Jitomate"))
        {
            JitomateVida jitomateScript = collision.GetComponent<JitomateVida>();

            if (jitomateScript != null)
            {
                if (jitomateScript.isMature)
                {
                    Destroy(collision.gameObject);
                    GameManager.instancia.SumarJitomate();
                    Debug.Log("Jitomate recolectado ");
                }
                else
                {
                    Debug.Log(" El jitomate aún no está listo para cosechar");
                }
            }
            else
            {
                Debug.Log("Error: El script JitomateVida no está en el objeto jitomate");
            }
        }
    }
}