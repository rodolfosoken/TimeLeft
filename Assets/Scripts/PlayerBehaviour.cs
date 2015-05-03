using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
   // Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public bool IsDefending;
    public bool IsUnderAttack;
    public static PlayerBehaviour _instance;
    
    void Awake()
    {
        IsDefending = false;
        _instance = this;

        // Set up references.
        anim = GetComponent<Animator>();
        //playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Animate the player.
        Animating(h, v);
    }

    void Update()
    {
        // Turn the player to face the mouse cursor.
        //Turning();
        Ataque();
        Defesa();
    }

    void Ataque()
    {
        //entra em modo de ataque ao pressionar o botão direito do mouse
        if (Input.GetMouseButton(0))
        {
                //aciona a animação ataca
                anim.SetBool("IsAttacking",true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }

    }


    void Defesa()
    {
        if (Input.GetMouseButton(1))
        {
            //aciona a animação de ataque
            anim.SetBool("IsDefending", true);
            IsDefending = true;
        }
        else
        {
            anim.SetBool("IsDefending", false);
            IsDefending = false;
        }

    }

    public void Hit()
    {
        anim.SetTrigger("Hit");
    }
  

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;


        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
