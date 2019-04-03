using UnityEngine;

public class NucleonSpawner : MonoBehaviour
{
    public float TimeBetweenSpawns;
    public float SpawnDistance;
    public Nucleon[] nucleonPrefabs;
    private float timeSinceLastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= TimeBetweenSpawns)
        {
            timeSinceLastSpawn -= TimeBetweenSpawns;
            SpawnNucleon();
        }
    }

    private void SpawnNucleon()
    {
        var nucleon= nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        var prefab = Instantiate(nucleon);
        prefab.transform.localPosition = Random.onUnitSphere * SpawnDistance;
    }
}
