using UnityEngine;
using UnityEngine.UIElements;

public class InventarioControlUI : MonoBehaviour
{
    private Label labelHuevos;
    private Label labelTrigo;
    private Label labelJitomate;

    private int huevosPrevios = -1;
    private int trigoPrevio = -1;
    private int jitomatePrevio = -1;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        labelHuevos = root.Q<Label>("labelHuevos");
        labelTrigo = root.Q<Label>("labelTrigo");
        labelJitomate = root.Q<Label>("labelJitomate");
    }

    void Update()
    {
        if (GameManager.instancia.contadorHuevo != huevosPrevios)
        {
            huevosPrevios = GameManager.instancia.contadorHuevo;
            labelHuevos.text = $"Huevos: {huevosPrevios}";
        }

        if (GameManager.instancia.contadorTrigo != trigoPrevio)
        {
            trigoPrevio = GameManager.instancia.contadorTrigo;
            labelTrigo.text = $"Trigo: {trigoPrevio}";
        }

        if (GameManager.instancia.contadorJitomate != jitomatePrevio)
        {
            jitomatePrevio = GameManager.instancia.contadorJitomate;
            labelJitomate.text = $"Jitomate: {jitomatePrevio}";
        }
    }
}