using UnityEngine;

public class FireScript : MonoBehaviour
{
    // Called when the object collides with another collider
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            DoFireDamage(col.gameObject);
        }
    }

    // Called when the object enters a trigger collider
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            DoFireDamage(col.gameObject);
        }
    }

    void DoFireDamage(GameObject go)
    {
        // Get the PlayerController component and call GetBreadType
        PlayerController playerController = go.GetComponent<PlayerController>();
        PlayerController.BreadType breadType = playerController.GetBreadType();

        // Hurt non toast type
        if(breadType != PlayerController.BreadType.Toast)
        {
            playerController.HurtPlayer(10);
        }
    }
}
