using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReceiveDamage : MonoBehaviour
{

    public int health = 100;

    public TextMeshProUGUI HealthText;

    public Image BarraHealth;

    public enemynavigation enemynavigation;

    public GameObject canvasdevida;

    private bool isDead = false;


    void Start()
    {
        enemynavigation = GetComponent<enemynavigation>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Hit by projectile");
            Destroy(collision.gameObject);
            health -= 25;
            HealthText.text = health.ToString();
            BarraHealth.fillAmount = health / 100f;
            Debug.Log("Health: " + health);
            if (health <= 0 && !isDead)
            {
                isDead = true;

                Debug.Log("Object destroyed");

                Collider col = GetComponent<Collider>();

                DestruirEnemigo();

                if (col != null)
                {
                    col.enabled = false;
                }

                enemynavigation.die();

                if (canvasdevida != null)
                {
                    canvasdevida.SetActive(false);
                }
            }
        }
    }

    public void DestruirEnemigo()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.EnemyKilledIncrement();
        }

        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

}
