using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove_Platformer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float Restart;
    [SerializeField] ParticleSystem HurtPart;
    SpriteRenderer SR;
    Vector2 PlyrPos;
    Rigidbody2D rb;
    Collider2D Feet;
    GameObject gameobject;
    bool IsLive = true;
    bool IsGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Feet = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Run();
        GroundCheck();
    }
    void GroundCheck()
    {
        IsGrounded = Feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    public void OnMove(InputValue value)
    {
        PlyrPos = value.Get<Vector2>();
    }
    void Run()
    {
        Vector2 PlyrSpd = new Vector2(PlyrPos.x * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = PlyrSpd;
    }
    public void OnJump(InputValue value)
    {
        if(!IsLive) 
        { 
            return; 
        }
        if (!Feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            rb.linearVelocity += new Vector2(0f, jumpForce);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            Restart = 1f;
            IsLive = false;
            print("Player is dead");
            HurtPart.Play();
            Invoke("ReloadScene", Restart);
            
        }
    }
}

