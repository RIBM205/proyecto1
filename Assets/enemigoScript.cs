using UnityEngine;

public class enemigoScript : MonoBehaviour
{
    Transform objetivo;
    public float speedE;

    void Start()
    {
        Debug.Log("enemigoScript Start: Buscando objeto 'Jugador'...");
        objetivo = GameObject.Find("Jugador")?.GetComponent<Transform>();

        if (objetivo != null)
        {
            Debug.Log("enemigoScript Start: Jugador encontrado correctamente.");
        }
        else
        {
            Debug.LogError("enemigoScript Start: No se encontró el GameObject 'Jugador'.");
            GameObject.Destroy(gameObject); // Destruye el enemigo si no se encuentra el jugador
        }
    }

    void Update()
    {
        if (objetivo == null)
        {
            Debug.LogWarning("enemigoScript Update: objetivo está nulo. No se puede mover el enemigo.");
            return;
        }

        Vector2 target = Vector2.MoveTowards(transform.position, objetivo.position, speedE * Time.deltaTime);
        transform.position = target;
    }

}