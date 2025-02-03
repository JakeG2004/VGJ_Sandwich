using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ToppingSpawner : MonoBehaviour
{
    public GameObject toppingPrefab; // Single topping prefab
    public Transform spawnPoint; // Point where toppings spawn
    public float spawnInterval = 0.5f; // Time between spawns
    public float riseSpeed = 1f; // Speed at which the sandwich rises
    
    private bool spawning = false;
    private Transform lastTopping;

    public UnityEvent _event;

    private AudioSource _as;

    public float upperBound = 10.0f;

    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    public void StartToppings()
    {
        StartCoroutine(SpawnToppings());
    }

    IEnumerator SpawnToppings()
    {
        spawning = true;
        while (spawning)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnTopping();

            // Handle offscreen
            if(lastTopping.position.y > upperBound)
            {
                spawning = false;
                _event.Invoke();
            }
        }
    }

    void SpawnTopping()
    {
        if (toppingPrefab == null) return;

        _as.Play();
        // Determine spawn position based on the last topping
        Vector3 position = spawnPoint.position;
        if (lastTopping != null)
        {
            position = lastTopping.position + new Vector3(0, riseSpeed, 0); // Adjust height based on previous topping
        }
        
        // Instantiate the topping
        GameObject newTopping = Instantiate(toppingPrefab, position, Quaternion.identity);
        lastTopping = newTopping.transform;
    }
}
