using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
public class Movement : MonoBehaviour
{
    [SerializeField] float MovSpeed = 20f; //set movespeed
    [SerializeField] ParticleSystem TestParticle;
    bool On = false;
    private Rigidbody2D rb; //variable call
    private Vector2 input;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //variable call
    }
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        input.Normalize(); //fixes diagonal movement to not be faster
        rb.linearVelocity = input * MovSpeed; //movement calculation
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("test"))

        {
            if (On == true)
            {
                TestParticle.Stop();
                On = false;
            }
            else
            {
                TestParticle.Play();
                On = true;
            }
        }
    }
}

