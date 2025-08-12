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



    public void SembrarTrigo(InputAction.CallbackContext contexto){
        if(contexto.started){
            Instantiate( trigoPreFab, transform.position, Quaternion.identity);

        }
    }

    public void SembrarJitomate(InputAction.CallbackContext contexto)
    {
        if (contexto.started)
        {
            Instantiate(jitomatePreFab, transform.position, Quaternion.identity);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Huevo"))
        {
            Destroy(collision.gameObject);
            GameManager.instancia.SumarHuevo();
        }
        else if (collision.CompareTag("Trigo"))
        {
            Destroy(collision.gameObject);
            GameManager.instancia.SumarTrigo();
        }
        else if (collision.CompareTag("Jitomate"))
        {
            Destroy(collision.gameObject);
            GameManager.instancia.SumarJitomate();
        }
    }


}

    
