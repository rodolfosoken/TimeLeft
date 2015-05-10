using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
  
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
   // Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public bool IsDefending;
    public bool IsUnderAttack;
    public static PlayerBehaviour _instance;
    public float life;
    public bool IsDead;
    AudioSource [] audio;
    AudioSource sound1, sound2, sound3, sound4;
    private float damage;

    public float damageAtaque = 6;
    public float damageRotacao = 2;


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
      damage = 1;
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
        
        life = Timer._timer.time;

        die();
        if (!IsDead)
        {
            Ataque();
            Defesa();
        }
    }

    public float GetDamage()
    {
        return damage;
    } 
    void Ataque()
    {
        //entra em modo de ataque ao pressionar o botão direito do mouse
        if (Input.GetMouseButton(0))
        {
                //aciona a animação ataca
                damage = damageAtaque;
                anim.SetBool("IsAttacking",true);
                sound2.Play();
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }

        if (anim.GetBool("IsDefending") && Input.GetMouseButton(0))
        {
            //ataque de rotação
            damage = damageRotacao;
            anim.SetTrigger("Rotacao");
            sound4.Play();
        }
    }


    void Defesa()
    {
        if (Input.GetMouseButton(1))
        {
            IsDefending = true;
            //aciona a animação de ataque
            anim.SetBool("IsDefending", IsDefending);
            
        }
        else
        {
            IsDefending = false;
            anim.SetBool("IsDefending", IsDefending);
        }

    }

    public void TakeDamage(float damage)
    {
        if (!IsDefending && !IsDead)
        {
           // Debug.Log("hit em player");
            anim.SetTrigger("Hit");
          sound1.Play();
          PopUpDamage.ShowMessage("-" + damage, transform.position);

          Timer._timer.minustime(damage);
          life -= damage;
        }
    }

    public void TakeDamageBehind(float damage)
    {
        if (!IsDead)
        {
            // Debug.Log("hit em player");
            anim.SetTrigger("Hit");
            sound1.Play();
            PopUpDamage.ShowMessage("-" + damage, transform.position);

            Timer._timer.minustime(damage);
            life -= damage;
        }
    }

    public void die()
    {
        if (life <= 0 && !IsDead)
        {
            sound3.Play();
            anim.SetBool("Die", true);
            IsDead = true;
        }  
    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;


        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
