using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator animator;
    public FixedJoystick joystick;
    public GameObject joystickGO;
    float hInput, vInput;
    private Vector2 lastMove;
    private Vector2 currentInput;
    Vector2 movementDirection;
    Vector3 finalDirection;

    public int maxHealth = 1000;
    public int currentHealth;
    public healthBar healthBar;
    public UnityEngine.InputSystem.HID.HID.Button weaponButton;
    private SpriteRenderer spriteRenderer;
    public GameObject tutoPanel1;
    public GameObject tutoText1;
    public GameObject tutoTextClose1;
    public GameObject carTuto;
    public GameObject tutoArrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        //Player Fix Direction
        if (movement.y > 0.5f)
        {
            finalDirection = new Vector2(0, 1);
        }
        else if (movement.y < -0.5f)
        {
            finalDirection = new Vector2(0, -1);
        }
        else if (movement.x > 0.5f)
        {
            finalDirection = new Vector2(1, 0);
        }
        else if (movement.x < -0.5f)
        {
            finalDirection = new Vector2(-1, 0);
        }
        else
        {
            finalDirection = Vector2.zero;
        }


        movementDirection = finalDirection;


        //PlayerLastMovement
        if ((movement.x != 0 || movement.y != 0))
        {
            lastMove = movement;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("hLastMove", lastMove.x);
        animator.SetFloat("vLastMove", lastMove.y);

        //Player Damage
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
      

        transform.Translate(hInput, vInput, 0);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if we entered a spawn zone
        if (other.CompareTag("tutoTrigger1"))
        {
            tutoPanel1.SetActive(true);
            tutoText1.SetActive(true);
            tutoTextClose1.SetActive(false);
            tutoArrow.SetActive(false);
            carTuto.SetActive(true);
            joystickGO.SetActive(false);
            moveSpeed = 0;
            movement.x = 0;
            movement.y = 0;
        }
    }
}
