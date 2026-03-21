using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject SkyScraperPrefab;
    public Transform PlaneTransform;

    private float time = 0f;
    private float spawnTime = 2f;

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
    }
}
