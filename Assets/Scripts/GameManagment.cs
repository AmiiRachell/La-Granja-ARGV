using JetBrains.Annotations;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    public static GameManagment instancia;
    int contadorHuevo;


    void Awake(){

        if(instancia == null){
            instancia = this;
        }else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
        public void SumarHuevo(){
        contadorHuevo ++;
        Debug.Log(contadorHuevo);

    }
 }
