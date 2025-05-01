using UnityEngine;

public class disparo : MonoBehaviour
{
    public GameObject bala;    // Prefab de la bala
    public Transform origen;   // Punto de origen del disparo
    public float speedBala;    // Velocidad de la bala
    public Rigidbody2D playerRB;
    public float playerSpeed;
    public GameObject mainCamvas;
    public int vidas = 3; // Contador de vidas\\
    public GameManager gameManager; // Referencia al GameManager
    public JugarButScript jugarButScript; // Declara la variable aquí, fuera de los métodos
    void Update()
    {
        // Movimiento
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");
        Vector2 movimientoPlayer = new Vector2(movimientoX, movimientoY) * playerSpeed;
        playerRB.linearVelocity = movimientoPlayer;

        // Rotación del jugador
        if (movimientoPlayer != Vector2.zero)
        {
            float angle = Mathf.Atan2(movimientoY, movimientoX) * Mathf.Rad2Deg;
            playerRB.rotation = angle;
        }

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject laBala = Instantiate(bala, origen.position, transform.rotation);
            Rigidbody2D balaRB = laBala.GetComponent<Rigidbody2D>();
            balaRB.AddForce(transform.right * speedBala, ForceMode2D.Impulse);
            Destroy(laBala, 1.5f);
        }
    }

    // Detecta colisiones con Collider2D y destruye el jugador, luego muestra el menú
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("disparo.OnCollisionEnter2D: colisionando con " + collision.gameObject.name);
         GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");
            Debug.Log("Se encontraron: " + enemigos.Length + " enemigos para destruir.");
            foreach (GameObject e in enemigos)
            {
                Destroy(e);
            }

        // Ajusta la comparación al nombre del enemigo o usa Tags
        if (gameManager.score > 5)
{
    Debug.Log("disparo.OnCollisionEnter2D: Score mayor que 5. Ejecutando el bloque 'else'...");
    // Aquí puedes ejecutar el bloque que necesitas
    if (mainCamvas != null)
    {
        Debug.Log("disparo.OnCollisionEnter2D: Encontrado 'maincanvas', activándolo...");
        mainCamvas.SetActive(true);
    }
    else
    {
        Debug.LogError("disparo.OnCollisionEnter2D: No se encontró 'maincanvas'.");
    }

    gameObject.SetActive(false); // Desactiva el objeto jugador
}
   else    if (vidas > 0)
{
    vidas--;
    Debug.Log("disparo.OnCollisionEnter2D: El jugador colisionó con 'enemigo'. Vidas restantes: " + vidas);
}

else
{
    Debug.Log("disparo.OnCollisionEnter2D: El jugador colisionó con 'enemigo'. Destruyendo al jugador...");

    foreach (var script in jugarButScript.scriptsToDisable)
    {
        script.enabled = false;
    }

    if (mainCamvas != null)
    {
        Debug.Log("disparo.OnCollisionEnter2D: Encontrado 'maincanvas', activándolo...");
        mainCamvas.SetActive(true);
    }
    else
    {
        Debug.LogError("disparo.OnCollisionEnter2D: No se encontró 'maincanvas'.");
    }

    gameObject.SetActive(false); // Desactiva el objeto jugador
}
    }
}