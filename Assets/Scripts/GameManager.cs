using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI enemyKilledText;
    public GameObject panelVictoria;
    public GameObject panelDerrota;
    public int enemigosAsesinados = 0;
    public int totalEnemigosParaGanar = 3;

    private bool juegoTerminado = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (panelVictoria != null) panelVictoria.SetActive(false);
        if (panelDerrota != null) panelDerrota.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ActualizarContadorTexto();
    }

    public void EnemyKilledIncrement()
    {
        if (juegoTerminado) return;

        enemigosAsesinados++;
        ActualizarContadorTexto();

        if (enemigosAsesinados >= totalEnemigosParaGanar)
        {
            MostrarPanelVictoria();
        }
    }

    public void GameOver()
    {
        if (juegoTerminado) return;
        juegoTerminado = true;

        if (panelDerrota != null)
        {
            panelDerrota.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void ActualizarContadorTexto()
    {
        if (enemyKilledText != null)
        {
            enemyKilledText.text = "Enemigos Asesinados " + enemigosAsesinados;
        }
    }

    void MostrarPanelVictoria()
    {
        juegoTerminado = true;
        if (panelVictoria != null)
        {
            panelVictoria.SetActive(true);
        }
        Time.timeScale = 1f;
    }
}