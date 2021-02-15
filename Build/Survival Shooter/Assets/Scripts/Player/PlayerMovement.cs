using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    private float camRayLength = 100f;

    float multiplier = 1f;
    public int PowerUpTime = 6;

    private void Awake()
    {
        // Ambil nilai mask dari layer bernama Floor
        floorMask = LayerMask.GetMask("Floor");

        // Get komponen Animator
        anim = GetComponent<Animator>();

        // Get RigidBody
        playerRigidbody = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        //Mendapatkan nilai input horizontal (-1,0,1)
        float h = Input.GetAxisRaw("Horizontal");

        //Mendapatkan nilai input vertical (-1,0,1)
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);

        Turning();

        Animating(h, v);
    }

    // Method player move
    public void Move(float h, float v)
    {
        // Set nilai x dan y
        movement.Set(h, 0f, v);

        // Normalisasi nilai vector biar total panjang dari vector adalah 1
        movement = movement.normalized * speed * Time.deltaTime * multiplier;

        // Move to position
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        // Buat Ray dari posisi mouse di layar
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Buat raycast untuk floorHit
        RaycastHit floorHit;

        // Lakukan raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Mendapatkan vector dari posisi player dan posisi floorHit
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            // Mendapatkan look rotation baru ke hit position
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Rotasi player
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    public void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    public void SpeedPowerUp(float speed)
    {
        if (multiplier < 2.0f)
            multiplier *= 2;
        Invoke(nameof(ResetPowerUp), PowerUpTime);
    }


    private void ResetPowerUp()
    {
        multiplier = 1.0f;
    }
}
