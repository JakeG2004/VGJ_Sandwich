using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public void KillThePlayer()
    {
        FindFirstObjectByType<PlayerController>().HurtPlayer(10);
    }
}
