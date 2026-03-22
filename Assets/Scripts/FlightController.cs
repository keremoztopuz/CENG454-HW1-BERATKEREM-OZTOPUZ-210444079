using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private AudioSource engineAudio;
    [SerializeField] private AudioClip landingAudio;
    [SerializeField] private AudioClip crashAudio;

    public GameObject collisionEffect;
    public GameObject gameManager;

    private bool isEngineStart = false;

    public float speed = 0f;
    public float maxSpeed = 500f;
    public float acceleration = 25f;
    public float deceleration = 10f;
    public float turnSpeed = 10f;

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

        if (Input.GetKeyDown(KeyCode.M)) {
            isEngineStart = true;
            engineAudio.clip = landingAudio;
            engineAudio.Play(); 
        }

        if (isEngineStart == false) {
            return;
        }

        if (transform.position.y < 2f) {
            transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Tower")) {
            engineAudio.Stop();
            if (crashAudio != null) {
                AudioSource.PlayClipAtPoint(crashAudio, transform.position);
            }
            if (collisionEffect != null) {
                Instantiate(collisionEffect, transform.position, Quaternion.identity);
            }
            if (gameManager != null) {
                gameManager.SendMessage("GameOver");
            }
            gameObject.SetActive(false);
        }
    }
}
