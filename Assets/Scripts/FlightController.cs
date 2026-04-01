// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Berat Kerem Öztopuz | Student ID: 210444079
using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed  = 45f;  // degrees/second
    [SerializeField] private float yawSpeed    = 45f;  // degrees/second
    [SerializeField] private float rollSpeed   = 45f;  // degrees/second
    [SerializeField] private float thrustSpeed = 50f;  // units/second

    // Task 3-A: private Rigidbody field
    private Rigidbody rb;

    // Engine & audio
    [SerializeField] private AudioSource engineAudio;
    [SerializeField] private AudioClip   landingAudio;
    [SerializeField] private AudioClip   crashAudio;

    // Game integration
    public GameObject collisionEffect;
    public GameObject gameManager;

    private bool isEngineStarted = false;

    void Start()
    {
        // Task 3-B: Cache Rigidbody and freeze rotation.
        // freezeRotation prevents the physics engine from overriding our
        // transform.Rotate calls with physics torques, giving full manual
        // control over the aircraft's orientation.
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
            rb.useGravity = false;
        }
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
        HandleEngineStart();
    }

    private void HandleRotation()
    {
        // Task 3-C:
        // Pitch – Arrow Up/Down  → rotate around local X axis (Vector3.right)
        float pitch = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * pitch * pitchSpeed * Time.deltaTime);

        // Yaw – Arrow Left/Right → rotate around local Y axis (Vector3.up)
        float yaw = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yaw * yawSpeed * Time.deltaTime);

        // Roll – Q/E             → rotate around local Z axis (Vector3.forward)
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.forward *  rollSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.forward * -rollSpeed * Time.deltaTime);
    }

    private void HandleThrust()
    {
        // Task 3-D: Spacebar → forward thrust  |  LeftShift → brake
        if (Input.GetKey(KeyCode.Space))
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
            transform.Translate(Vector3.back * (thrustSpeed * 0.5f) * Time.deltaTime);
    }

    private void HandleEngineStart()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isEngineStarted)
        {
            isEngineStarted = true;
            if (engineAudio != null && landingAudio != null)
            {
                engineAudio.clip = landingAudio;
                engineAudio.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            if (engineAudio != null) engineAudio.Stop();
            if (crashAudio != null)
                AudioSource.PlayClipAtPoint(crashAudio, transform.position);
            if (collisionEffect != null)
                Instantiate(collisionEffect, transform.position, Quaternion.identity);
            if (gameManager != null)
                gameManager.SendMessage("GameOver");
            gameObject.SetActive(false);
        }
    }
}
