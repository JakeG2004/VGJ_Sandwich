using UnityEngine;
using UnityEngine.Events;

public class SetSpawn : MonoBehaviour
{
    // Called when the object collides with another collider
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            SetNewSpawn(col.gameObject);
        }
    }

    // Called when the object enters a trigger collider
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            SetNewSpawn(col.gameObject);
        }
    }

    void SetNewSpawn(GameObject go)
    {
        // Get the PlayerController component and call GetBreadType
        PlayerController playerController = go.GetComponent<PlayerController>();
        playerController.SetRespawnPos(transform);
        //gameObject.SetActive(false);
    }
}
