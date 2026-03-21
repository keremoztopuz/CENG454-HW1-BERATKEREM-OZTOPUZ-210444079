using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject SkyScraperPrefab;
    public Transform PlaneTransform;

    private float time = 0f;
    private float spawnTime = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaneTransform == null || PlaneTransform.position.y < 20f) {
            return;
        }

        time += Time.deltaTime;
        
        if (time >= spawnTime) {
            time = 0f;
            
            Vector3 spawnPosition = PlaneTransform.position - (PlaneTransform.forward * 5000f);
            
            spawnPosition.y = 0f;
            spawnPosition.x += Random.Range(-50f, 50f);

            GameObject newTower = Instantiate(SkyScraperPrefab, spawnPosition, Quaternion.identity);
            Destroy(newTower, 10f);
        }

        
    }
}
