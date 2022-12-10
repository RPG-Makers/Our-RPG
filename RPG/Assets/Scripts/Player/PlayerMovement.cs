using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = movement.normalized;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x); //run walk animation
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", Mathf.Abs(movement.sqrMagnitude));
        
        if(Input.GetKeyDown(KeyCode.A)) // flip the sprite. When we'll have left right mirror animatin, should turn this feature off and adjust the animator
        {
            
            spriteRenderer.flipX = true;
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    public void SpeedUp(int value) //баф скорости от зелья в инвентаре
    {
        movementSpeed += value;
    }
}