using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer SR;
    private Animator Anim;
    GameManger GM;
    public bool takeDamage;
    public float timeBtwAttack;
    public float startTimeBtwAttack;

    //creating a "panel" object for inventory
    public GameObject Panel;

    //inventory variables 
    public bool inInventory; //inventory tab open
    public bool outInventory = true; //inventory tab closed

    //creating a panel object for menu/store
    public GameObject storePanel;
    //store variables
    public bool inStore;
    public bool outStore = true;

    //creating a panel object for controls
    public GameObject controls;
    //control variables
    public bool inControls;
    public bool outControls = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        GM = FindObjectOfType<GameManger>();
        takeDamage = false;

        //creates an inventory panel
        //when this is true the inventory panel opens

        Panel.GetComponent<Canvas>().enabled = false;
        storePanel.GetComponent<Canvas>().enabled = false;
        controls.GetComponent<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement = moveInput.normalized * speed;
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            Anim.SetInteger("KeyInput", 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            Anim.SetInteger("KeyInput", -1);
        }
        else if (Input.GetAxisRaw("Vertical") == 1)
        {
            Anim.SetInteger("KeyInput", 2);
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            Anim.SetInteger("KeyInput", -2);
        }
        else
        {
            Anim.SetInteger("KeyInput", 0);
        }
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            speed = 0;
            Anim.SetInteger("KeyInput", 0);
        }
        else
        {
            speed = 10;
        }


        // if you press I then Inventory will show up,

        if (Input.GetKeyDown(KeyCode.I) && outInventory)
        {
            Time.timeScale = 0;
            outInventory = false;
            inInventory = true;
            Panel.GetComponent<Canvas>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && inInventory)
        {
            Time.timeScale = 1;
            outInventory = true;
            inInventory = false;
            Panel.GetComponent<Canvas>().enabled = false;
        }

        //if you press M then store menu will show up
        if (Input.GetKeyDown(KeyCode.M) && outStore)
        {
            Time.timeScale = 0;
            outStore = false;
            inStore = true;
            storePanel.GetComponent<Canvas>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && inStore)
        {
            Time.timeScale = 1;
            outStore = true;
            inStore = false;
            storePanel.GetComponent<Canvas>().enabled = false;
        }

        //if press C the controls will show up
        if (Input.GetKeyDown(KeyCode.C) && outControls)
        {
            Time.timeScale = 0;
            outControls = false;
            inControls = true;
            controls.GetComponent<Canvas>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && inControls)
        {
            Time.timeScale = 1;
            outControls = true;
            inControls = false;
            controls.GetComponent<Canvas>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        if (Time.time > startTimeBtwAttack && takeDamage)
        {
            GM.playerHealth -= GM.EnemyDamage;
            startTimeBtwAttack = Time.time + timeBtwAttack;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            takeDamage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            takeDamage = false;
        }
    }




}
