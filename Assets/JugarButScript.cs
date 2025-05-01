using UnityEngine;

public class JugarButScript : MonoBehaviour
{
    public GameObject mainCanvas; // Arrastra el objeto "maincanvas" desde el editor
    public MonoBehaviour[] scriptsToDisable; // Arrastra aquí los scripts que deseas desactivar
    public GameObject jugador; // Referencia al objeto del jugador

    void Start()
    {
        // Desactiva los scripts al inicio
        foreach (var script in scriptsToDisable)
        {
            script.enabled = false;
        }

        // Configura el botón "Jugar"
        UnityEngine.UI.Button button = GameObject.Find("ButtonJugar").GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() =>
        {
            if (mainCanvas != null)
            {
                mainCanvas.SetActive(false);

                // Activa los scripts al presionar el botón
                foreach (var script in scriptsToDisable)
                {
                    script.enabled = true;
                }

                // Reactiva el jugador
                if (jugador != null)
                {
                    jugador.SetActive(true);
                    Debug.Log("Jugador reactivado.");
                }
                else
                {
                    Debug.LogError("El objeto 'jugador' no está asignado en el Inspector.");
                }
            }
            else
            {
                Debug.LogError("El objeto mainCanvas no está asignado.");
            }
        });
    }
}