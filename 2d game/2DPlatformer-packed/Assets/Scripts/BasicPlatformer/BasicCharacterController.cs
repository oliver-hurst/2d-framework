using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//--------------------------------------------
/*Basic Character Controller Includes:  
    - Basic Jumping
    - Basic grounding with line traces
    - Basic horizontal movement
 */
//--------------------------------------------

public class BasicCharacterController : MonoBehaviour
{
    

    protected bool facingRight = true;
    protected bool jumped;

    public float sprint = 10.0f;
    public float speed = 5.0f;
    public float jumpForce = 1000;

    private float horizInput;

    public Transform groundedCheckStart;
    public Transform groundedCheckEnd;
    public bool grounded;

    public float jump_speed;
    public healthbar healthbar;
    public int maxhealth;
    public int currenthealth;
    //create knock bacck forse
    public float KBforce;
    //how long the knock back will last
    public float KBcounter;
    public float KBtotaltime;
    //where have we been hit 
    bool knockformright;
    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthbar.SetHealth(currenthealth); 
            
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("gun"))
        {
            TakeDamage(30);
          
        }

        if (collision.gameObject.tag == "thesavage")
        {
            KBcounter = KBtotaltime;
            if(collision.transform.position.x <= transform.position.x)
            {
                knockformright = true;
            }

            if (collision.transform.position.x >= transform.position.x)
            {
                knockformright = false;
            }
            TakeDamage(20);
            rb.AddForce(Vector2.right);
        }            
    }


    

    private void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump_speed);
        grounded = false;

    }
    void Start()
    {
        currenthealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);

    }


    void FixedUpdate()
    {

        if (rb.position.y < -100f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //if player dies the level will restart
        }

        if (currenthealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //if player dies the level will restart
        }

        //Linecast to our groundcheck gameobject if we hit a layer called "Level" then we're grounded
        grounded = Physics2D.Linecast(groundedCheckStart.position, groundedCheckEnd.position, 1 << LayerMask.NameToLayer("Level"));
        Debug.DrawLine(groundedCheckStart.position, groundedCheckEnd.position, Color.red);
        if(KBcounter <= 0)
        {
        //Get Player input 
        horizInput = Input.GetAxis("Horizontal");
        //Move Character
        rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            if(knockformright == true)
            {
                rb.velocity = new Vector2(KBforce, KBforce);
            }
            if(knockformright == false)
            {
                rb.velocity = new Vector2(-KBforce, KBforce);
            }
            KBcounter -= Time.deltaTime;
        }
       

        if (Input.GetKey(KeyCode.Space) && grounded)
            jump();
        if (Input.GetKey(KeyCode.LeftShift))
           rb.velocity = new Vector2(Input.GetAxis("Horizontal") * sprint, rb.velocity.y);



        if (jumped == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            Debug.Log("Jumping!");

            jumped = false;
        }

        // Detect if character sprite needs flipping
        if (horizInput > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if (horizInput < 0 && facingRight)
        {
            FlipSprite();
        }
    }
    


    // Flip Character Sprite
    void FlipSprite()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
