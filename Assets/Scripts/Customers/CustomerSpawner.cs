using UnityEngine;

public class CustomerSpawner : MonoBehaviour {
    [SerializeField] Transform[] spawnLocations;
    [SerializeField] int customersToSpawn;
    int customersSpawned = 0;

    [SerializeField] GameObject customer;

    float cooldown = 2;
    float internalTimer = 0;

    void Start() {

    }

    void Update() {
        if (internalTimer >= cooldown && customersSpawned <= customersToSpawn) {
            internalTimer = 0;

            // TODO: make this randomized haha
            Instantiate(customer, spawnLocations[customersSpawned].position, spawnLocations[customersSpawned].rotation);
            customersSpawned++;
        }
        else {
            internalTimer += Time.deltaTime;
        }
    }
}
