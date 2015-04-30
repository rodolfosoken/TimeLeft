using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    static int lastKeyPress;
    void Awake()
    {
        //orientação inicial
        lastKeyPress = 1;

        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");

        // Set up references.
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (!anim.GetBool("ModoAtaque"))
        {
            // Move the player around the scene.
            Move(h, v);
        }
        // Animate the player.
        Animating(h, v);
    }

    void Update()
    {
        // Turn the player to face the mouse cursor.
        Turning();
        Ataque();

    }

    void Ataque()
    {
        //entra em modo de ataque ao pressionar o botão direito do mouse
        if (Input.GetMouseButton(1))
        {
            anim.SetBool("ModoAtaque", true);

            //ataca ao pressionar o botão esquerdo do mouse
            if (Input.GetMouseButtonDown(0))
                anim.SetTrigger("Atacar");
        }
        else
        {
            anim.SetBool("ModoAtaque", false);
        }

    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }


    void Turning()
    {

        // verifica para qual direção irá virar conforme o último movimento
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && (lastKeyPress != 1))
        {
            if (lastKeyPress == 2)
                transform.Rotate(Time.deltaTime, 180, 0);
            else if (lastKeyPress == 3)
                transform.Rotate(Time.deltaTime, -90, 0);
            else if (lastKeyPress == 4)
                transform.Rotate(Time.deltaTime, 90, 0);
            lastKeyPress = 1;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && (lastKeyPress != 2))
        {
            if (lastKeyPress == 1)
                transform.Rotate(Time.deltaTime, 180, 0);
            else if (lastKeyPress == 3)
                transform.Rotate(Time.deltaTime, 90, 0);
            else if (lastKeyPress == 4)
                transform.Rotate(Time.deltaTime, -90, 0);
            lastKeyPress = 2;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && (lastKeyPress != 3))
        {
            if (lastKeyPress == 1)
                transform.Rotate(Time.deltaTime, 90, 0);
            else if (lastKeyPress == 2)
                transform.Rotate(Time.deltaTime, -90, 0);
            else if (lastKeyPress == 4)
                transform.Rotate(Time.deltaTime, 180, 0);

            lastKeyPress = 3;
        }


        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && (lastKeyPress != 4))
        {
            if (lastKeyPress == 1)
                transform.Rotate(Time.deltaTime, -90, 0);
            else if (lastKeyPress == 2)
                transform.Rotate(Time.deltaTime, 90, 0);
            else if (lastKeyPress == 3)
                transform.Rotate(Time.deltaTime, 180, 0);

            lastKeyPress = 4;
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
