using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
  
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
   // Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public bool IsDefending;
    public bool IsUnderAttack;
    public static PlayerBehaviour _instance;
    public int life = 30;
    bool IsDead;
    AudioSource [] audio;
    AudioSource sound1, sound2, sound3, sound4;
    void Awake()
    {
        IsDefending = false;
        _instance = this;
        IsDead = false;
        // Set up references.
        anim = GetComponent<Animator>();
        audio = GetComponents<AudioSource>();
        sound1 = audio[0];
        sound2 = audio[1];
        sound3 = audio[2];
        sound4 = audio[3];

        //playerRigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        IsDead = false;
    }

    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (!IsDead)
        {
            // Animate the player.
            Animating(h, v);

            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 24, transform.position.z + 100);
        }
    }

    void Update()
    {
        if (!IsDead)
        {
            Ataque();
            Defesa();
        }
    }
    void Ataque()
    {
        //entra em modo de ataque ao pressionar o botão direito do mouse
        if (Input.GetMouseButton(0))
        {
                //aciona a animação ataca
                anim.SetBool("IsAttacking",true);
               sound3.Play();
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

    public void TakeDamage()
    {
        if (!IsDefending && !IsDead)
        {
           // Debug.Log("hit em player");
            anim.SetTrigger("Hit");
          sound1.Play();
            PopUpDamage.ShowMessage("-2", transform.position);
            
            Timer._timer.minustime(2);
            life--;
        }
    }

    public void die()
    {
        sound4.Play();
        anim.SetBool("Die", true);
        IsDead = true;
        
    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;


        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
