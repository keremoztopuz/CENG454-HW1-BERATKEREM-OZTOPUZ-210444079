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
        transform.position -= transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)) {
            if (speed < maxSpeed) {
                speed += acceleration * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            if (speed > 0) {
                speed -= deceleration * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.A) && transform.position.y > 20f) {
            transform.Rotate(Vector3.back*Time.deltaTime*turnSpeed);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.y > 20f) {
            transform.Rotate(Vector3.forward*Time.deltaTime*turnSpeed);
        }

        if (Input.GetKey(KeyCode.S) && speed >= 100f) {
            transform.Rotate(Vector3.right*Time.deltaTime*turnSpeed);
        }

        if (Input.GetKey(KeyCode.W) && speed >= 100f) {
            transform.Rotate(Vector3.left*Time.deltaTime*turnSpeed);
        }

        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.down*Time.deltaTime*turnSpeed);
        }

        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up*Time.deltaTime*turnSpeed);
        }

        if (transform.position.y < 2f) {
            transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        }
    }
}
