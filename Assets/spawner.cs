using System.Collections;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemigo;       // Prefab del enemigo
    public bool generando;           // Controla si se generan enemigos
    public GameObject mainCanvas;    // Referencia al canvas "mainCanvas"
    private Coroutine generadorCoroutine; // Referencia a la corutina
    public string jugadorTag = "Jugador"; // Tag del jugador para buscarlo en la escena

    void Start()
    {
        // Inicia la corutina si generando es true y el jugador está presente
        if (generando && JugadorPresente())
        {
            generadorCoroutine = StartCoroutine(generador());
        }
    }

    IEnumerator generador()
    {
        while (generando)
        {
            if (!JugadorPresente())
            {
                Debug.Log("Jugador no encontrado. Deteniendo la rutina.");
                generando = false;
                yield break; // Salimos de la corutina
            }

            Debug.Log("EMPIEZA LA RUTINA");
            yield return new WaitForSeconds(1f); // Esperamos 1 segundo
            Instantiate(enemigo, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        // Verifica si el canvas "mainCanvas" está activo
        if (mainCanvas != null && mainCanvas.activeInHierarchy)
        {
            if (generando)
            {
                generando = false; // Detenemos la generación de enemigos
                if (generadorCoroutine != null)
                {
                    StopCoroutine(generadorCoroutine); // Detenemos la corutina
                    generadorCoroutine = null;
                }
            }
        }
        else
        {
            if (!generando && JugadorPresente())
            {
                generando = true; // Iniciamos la generación de enemigos
                generadorCoroutine = StartCoroutine(generador()); // Reiniciamos la corutina
            }
        }
    }

    // Método para verificar si el jugador está presente en la escena
    private bool JugadorPresente()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag(jugadorTag);
        return jugador != null;
    }
}