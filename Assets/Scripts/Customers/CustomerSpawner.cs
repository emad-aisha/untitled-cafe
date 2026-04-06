using UnityEngine;

public class CustomerSpawner : MonoBehaviour {
    [SerializeField] Transform[] spawnLocations;
    [SerializeField] int customersToSpawn;
    int customersSpawned = 0;

    [SerializeField] GameObject customer;

    float cooldown = 2;
    float internalTimer = 0;

    void Start() { }

    void Update() {
        if (internalTimer >= cooldown && customersSpawned < customersToSpawn) {
            customersSpawned++;
            internalTimer = 0;

            int index = Random.Range(0, spawnLocations.Length);
            Instantiate(customer, spawnLocations[index].position, spawnLocations[index].rotation);
        }
        else {
            internalTimer += Time.deltaTime;
        }
    }

}
