using UnityEngine;

public class UltimateScript : MonoBehaviour
{
    [SerializeField] private KeyCode _ultimate = KeyCode.Space;
    private PlayerController _pc;

    [SerializeField] private GameObject _frenchPlatform;

    private GameObject _curPlat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(_ultimate))
        {
            // Allowed to place a platform if not coming from another platform
            if(_pc.GetBreadType() == PlayerController.BreadType.French && _pc.GetLastGroundedOnRealGround())
            {
                // Annihilate previous platform
                GameObject platform = GameObject.FindWithTag("FrenchPlatform");
                Destroy(platform);

                // Spawn a new one below the player
                Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
                _curPlat = Instantiate(_frenchPlatform, spawnPos, Quaternion.identity);
            }
        }    
    }
}
