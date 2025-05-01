using UnityEngine;
using TMPro;//Agregamos libreria de Text Mesh Pro

public class GameManager : MonoBehaviour
{
    public  int score =0;
    public TextMeshProUGUI textoScore;

    void Start()
    {
        //Buscamos un objeto llamado Score y su componente TMPro
        textoScore=GameObject.Find("SCORE").GetComponent<TextMeshProUGUI>();
    }

    public void sumarPuntos(){
        score++;
        textoScore.text=score.ToString();
    }

    void Update()
    {
        
    }
}
