using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int EnemyKilled = 0;
    public TextMeshProUGUI EnemyKilledText;
    public GameObject PanelWin;
    public GameObject PanelLose;

    void Start()
    {
        PanelLose.SetActive(false);
        PanelWin.SetActive(false);
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PanelLose.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void EnemyKilledIncrement()
    {
        EnemyKilled++;
        EnemyKilledText.text = "Enemies Killed: " + EnemyKilled.ToString();
        if (EnemyKilled == 3)
        {
            PanelWin.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }
}
