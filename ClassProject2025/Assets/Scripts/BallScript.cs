using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BallScript : MonoBehaviour
{
    // Create the variables

    // exposure of the variables
    [SerializeField] // option

    // speed
    private float speed = 100.0f;

    // exposure of the variables
    [HideInInspector]
    // jump
    private float jump = 0.0f;

    [SerializeField]
    // rotationSpeed
    private float rotationSpeed = 100.0f; // rotation speed on the current postion

    //private float horizontalInput, verticalInput;// x axis and y axis value
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float translation = 0, rotation=0;

    // to access the attackball object
    public GameObject attakBall;
    private Light2D myLight;

    void Awake()
    {
        /*   // Mostly used for initialization
           Debug.Log("We are inside the awake function");
           speed = 2.5f;
           jump = 3.4f;
        */
        // initialize the attackball object
        attakBall = GameObject.Find("Attacker");
        attakBall = GameObject.FindWithTag("AttackBall");
        // let's catch the object material component and change the color
        MeshRenderer meshRenderer = attakBall.GetComponent<MeshRenderer>();
        meshRenderer.material.color = Color.green;
        
    }

    void Start()
    {
        Debug.Log("We are inside the Start function");
        speed = 1.0f;
        myLight = GetComponent<Light2D>();
       /*
        // Horizontal Position
        horizontalInput =  Input.GetAxis("Horizontal");
        Debug.Log("Horizontal Position " + horizontalInput);
        // vertical Position
        verticalInput = Input.GetAxis("Vertical");
        Debug.Log("Veritcal Postion " + verticalInput);
       */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // increamenting the values by 0.05 point with every frame
        speed += 0.05f;
        jump += 0.05f;
        Debug.Log("We are inside the Update function");
        Debug.Log("The value of speed " + speed);
        Debug.Log("The value of jump " + jump);
       // Thread.Sleep(1000);

        */

        // movement of the object itself

        // x -axis movement amount, translation
        //float translation =  speed; // the movement of one key stroke

        // Y - axis movement amount, rotation
        //float rotation =  (verticalInput + 0.2f) *rotationSpeed; // the rotation of one key stroke

        // now we need to define how the movement will spread through the frames to smooth movement
        translation = speed * Time.deltaTime;

        rotation = rotationSpeed * Time.deltaTime;
        /*
        // at this point need to control the keyboard input
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            //transform.Translate(new Vector2(-translation, 0));
            transform.position = new Vector2(transform.position.x, transform.position.y)
               + new Vector2(-translation, 0);
            //transform.Translate(Vector2.left * Time.deltaTime,Space.Self); // local position
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            //transform.Translate(new Vector2(translation, 0));
            transform.position = new Vector2(transform.position.x, transform.position.y)
                + new Vector2 (translation, 0);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            //transform.Translate(new Vector2(0, translation));
            transform.position = new Vector2(transform.position.x, transform.position.y)
                +  new Vector2(0, translation);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            //transform.Translate(new Vector2(0, -translation));
            transform.position = new Vector2(transform.position.x, transform.position.y) 
                + new Vector2(0, -translation);

        // to activate rotation
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(new Vector2(0, rotation));

        // light accessing part
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myLight.enabled = !myLight.enabled;
        }
        /// we are going to move the attack ball towards the game character ball
        */
        Vector2 targetPosition = transform.position;

        attakBall.transform.position = Vector2.MoveTowards(attakBall.transform.position, 
                                targetPosition, Time.deltaTime * speed );
       
        /*
        // perform the translation of the object, we need to call the Translate method
        transform.Translate(new Vector2(translation, 0));

        // perform rotation of the object

        transform.Rotate(new Vector2(0, rotation));

        //horizontalInput = Input.GetAxis("Horizontal"); // to get new Horizontal value
        //verticalInput = Input.GetAxis("Vertical"); // to get new Vertical value

        */
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 currentPos = new Vector2(this.gameObject.transform.position.x,
               this.gameObject.transform.position.y);
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidbody2D.MovePosition(currentPos + Vector2.left * Time.deltaTime * 20.0f );
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidbody2D.MovePosition(currentPos + Vector2.right * Time.deltaTime * 20.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigidbody2D.MovePosition( currentPos + Vector2.up * Time.deltaTime * 20.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigidbody2D.MovePosition(currentPos + Vector2.down * Time.deltaTime * 20.0f);
        }
        
        /*
        //velocity based movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidbody2D.linearVelocity = currentPos + Vector2.left * Time.deltaTime * 20.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidbody2D.linearVelocity = currentPos + Vector2.right * Time.deltaTime * 20.0f; 
        }
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigidbody2D.linearVelocity = currentPos + Vector2.up * Time.deltaTime * 20.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigidbody2D.linearVelocity = currentPos + Vector2.down * Time.deltaTime * 20.0f;
        }

        */
    }
    void FixedUpdate()
    {
        /*
        speed += 1.00f;
        jump += 1.00f;
        Debug.Log("We are inside the FixedUpdate function");
        Debug.Log("The value of speed " + speed);
        Debug.Log("The value of jump " + jump);
        //Thread.Sleep(3000);
        */
        // Detect collision with objects
        

    }
    /*
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        // going to check whether the collision happened with attacker ball
        if (collision2D.gameObject.name == "Attacker")
        {
            Debug.Log("The collision happened");
            myLight.enabled = !myLight.enabled;

        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "AttackBall")
        {
            Debug.Log("After collision stage");
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //myLight.enabled = !myLight.enabled;
        Destroy(this.gameObject);
    }
}
