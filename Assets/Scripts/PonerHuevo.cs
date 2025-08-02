using UnityEngine;

public class PonerHuevo : MonoBehaviour
{
    public GameObject huevo;
    public float intervalo = 10f;

    void Start()
    {
        InvokeRepeating(nameof(PonerUnHuevo), intervalo, intervalo);
    }
    void PonerUnHuevo(){
        Instantiate(huevo, transform.position, Quaternion.identity);

    }


}