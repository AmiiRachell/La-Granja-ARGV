using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public int contadorHuevo;
    public int contadorTrigo;
    public int contadorJitomate;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SumarHuevo()
    {
        contadorHuevo++;
        Debug.Log("Huevos: " + contadorHuevo);
    }

    public void SumarTrigo()
    {
        contadorTrigo++;
        Debug.Log("Trigo: " + contadorTrigo);
    }

    public void SumarJitomate()
    {
        contadorJitomate++;
        Debug.Log("Jitomates: " + contadorJitomate);
    }
}