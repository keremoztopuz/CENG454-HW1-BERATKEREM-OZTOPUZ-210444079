using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject SkyScraperPrefab;
    public Transform PlaneTransform;

    private float time = 0f;
    private float spawnTime = 12f;

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
            float coridorDeflection = Random.Range(-50f, 50f);
            spawnPosition.x += coridorDeflection;

            Vector3 rightPosition = spawnPosition + (PlaneTransform.right * 2000f);

            GameObject rightTower = Instantiate(SkyScraperPrefab, rightPosition, Quaternion.identity);
            Destroy(rightTower, 35f);

            Vector3 leftPosition = spawnPosition - (PlaneTransform.right * 2000f);

            GameObject leftTower = Instantiate(SkyScraperPrefab, leftPosition, Quaternion.identity);
            Destroy(leftTower, 35f);

            //if (spawnTime > 0.5f) {
            //    spawnTime -= 0.05f;
            //}
        }
    }
}
