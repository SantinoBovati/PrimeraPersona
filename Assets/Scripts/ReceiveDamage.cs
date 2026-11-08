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
            if (health <= 0)
            {
                Debug.Log("Object destroyed");
                Collider col = GetComponent<Collider>();
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
        Destroy(gameObject);
    }

}
