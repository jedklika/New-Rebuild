using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameManger GM;
    public GameObject Colliderobject;
    public SpriteRenderer Repair;
    // Start is called before the first frame update
    private void Start()
    {
        GM = FindObjectOfType<GameManger>();
        Colliderobject = null;
        

    }
    private void Update()
    {
        //when you press E
        //add to num of med kits
    }
        /*
        //when you pickup clean up items, adds metal, adhesive, tubing
        if ((Input.GetKeyDown(KeyCode.E) && GM.CanClean))
        {
            GM.CanClean = false;
            GM.scrapMetalAmount += 1;
            GM.brokenPipeAmount += 1;
            GM.rustyMetalAmount += 1;
            Destroy(Colliderobject);
            Colliderobject = null;
        }
        if (GM.scrapMetalAmount == 1 && GM.brokenPipeAmount == 1 && GM.rustyMetalAmount == 1)
        {
            GM.GearedUp = true;
        }
        else
        {
            GM.GearedUp = false;
        }
        if ((Input.GetKeyDown(KeyCode.E) && GM.GearedUp && GM.CanRepair))
        {
            GM.CanClean = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 1;
            Repair = Colliderobject.GetComponent<SpriteRenderer>();
            Repair.color = Color.yellow;
            GM.itemFixed = true;
        }
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Kit")
        {
            GM.CanPickUpHealth = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to Pick up health kit";
            Colliderobject = collision.gameObject;
        }
    }
     /*   if(collision.tag == "Trash")
        {
            GM.CanClean = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }
        if (collision.tag == "Repair" && GM.GearedUp)
        {
            GM.CanRepair = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to Repair";
            Colliderobject = collision.gameObject;
        }
        if (collision.tag == "Repair" && GM.GearedUp == false && GM.itemFixed == false)
        {
            GM.CanRepair = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Need 1 scrap metal, 1 pipe, 1 rusty metal";
            Colliderobject = collision.gameObject;
        } */
    
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
/*        if (collision.tag == "Trash")
        {
            GM.CanClean = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        if (collision.tag == "Repair")
        {
            GM.CanRepair = false;
            GM.PickUp.enabled = false;
            GM.PickUp.text = "";
            Colliderobject = null;
        }
    }*/
}
