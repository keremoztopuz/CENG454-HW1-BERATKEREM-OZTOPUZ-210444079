using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeed = 500f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    public float turnSpeed = 100f;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
