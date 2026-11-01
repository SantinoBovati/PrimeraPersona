using Unity.VisualScripting;
using UnityEngine;

public class ReceiveDamage : MonoBehaviour
{

    public int health = 100;

    void Start()
    {
        
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
            Debug.Log("Health: " + health);
            if (health <= 0)
            {
                Debug.Log("Object destroyed");
                Destroy(gameObject);
            }
        }
    }
}
