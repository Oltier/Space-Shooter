using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float XMin, XMax, ZMin, ZMax;
}

public class MyPlayerController : MonoBehaviour
{
    public float Speed;
    public float Tilt;

    public Boundary Boundary;

    public GameObject Shot;
    public Transform ShotSpawn;

    public float FireRate;
    
    private float _nextFire;

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = movement * Speed;

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(rb.position.x, Boundary.XMin, Boundary.XMax),
            0.0f,
            Mathf.Clamp(rb.position.z, Boundary.ZMin, Boundary.ZMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -Tilt);
    }

    private void Update()
    {
        if (Input.GetButton("Jump") && Time.time > _nextFire)
        {
            _nextFire = Time.time + FireRate;
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }
}