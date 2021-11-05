using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    // Start is called before the first frame update
    //calling GameManagerScript
    GameManger GM;
    public GameObject Colliderobject;
    
    
   
    private void Start()
    {
        //allows me to use variables from game manager script
        GM = FindObjectOfType<GameManger>();

        Colliderobject = null;

        //give item amount values
        GM.scrapMetalAmount = 0;
        GM.brokenPipeAmount = 0;
        GM.rustyMetalAmount = 0;
        GM.marinePropulsionPartAmount = 0;
        GM.electricMotorPartAmount = 0;
        GM.airCompressionPartAmount = 0;
        GM.steamTurbinePartAmount = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //Give inventory items amounts 
        GM.scrapMetalAmountTxt.text = "Scrap Metal : " + GM.scrapMetalAmount;
        GM.brokenPipeAmountTxt.text = "Broken Pipe(s): " + GM.brokenPipeAmount;
        GM.rustyMetalAmountTxt.text = "Rusty Metal : " + GM.rustyMetalAmount;
        GM.marinePropulsionPartAmountTxt.text = "Marine Propulsion Part(s): " + GM.marinePropulsionPartAmount;
        GM.electricMotorPartAmountTxt.text = "Electric Motor Part(s): " + GM.electricMotorPartAmount;
        GM.airCompressionPartAmountTxt.text = "Air Compression Part(s): " + GM.airCompressionPartAmount;
        GM.steamTurbinePartAmountTxt.text = "Steam Turbine Part(s): " + " " + GM.steamTurbinePartAmount;

        if ((Input.GetKeyDown(KeyCode.E) && GM.CanClean))
        {
            GM.CanClean = false;
            GM.scrapMetalAmount += 1;
            Destroy(Colliderobject);
            Colliderobject = null;
        }




    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //try making 2 array lists, one with tag names (String), one with amounts (int)
        // loop through the list, when i = 0 collission.tag = StringArray[i] and intArray[0] aka GM.scrapMetalAmount + 1;

        if (collision.gameObject.CompareTag("Smetal") && Input.GetKeyDown(KeyCode.E)&& GM.CanClean)
        {
            GM.scrapMetalAmount += 1;
            GM.CanClean = false;
            Destroy(Colliderobject);
            Colliderobject = null;
        }
        if (collision.tag == "Rmetal" && Input.GetKeyDown(KeyCode.E) && GM.CanClean)
        {
            GM.rustyMetalAmount += 1;
            GM.CanClean = false;
            Destroy(Colliderobject);
            Colliderobject = null;
        }
        if (collision.tag == "pipe" && Input.GetKeyDown(KeyCode.E) && GM.CanClean)
        {
            GM.brokenPipeAmount += 1;
            GM.CanClean = false;
            Destroy(Colliderobject);
            Colliderobject = null;
        }
        if (collision.gameObject.CompareTag("marProPart"))
        {

        }
        if (collision.gameObject.CompareTag("eMotorPart"))
        {

        }
        if (collision.gameObject.CompareTag("airComPart"))
        {

        }
        if (collision.gameObject.CompareTag("sTurbPart"))
        {

        }
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        //When player encounter any of these items, message click E to clean
        // enables "can clean" and "can pickup" so the player can pick up said items
        //
        if (collision.tag == "Smetal")
        {
            GM.CanClean = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }
        //
        if (collision.tag == "Rmetal")
        {
            GM.CanClean = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }
        //
        if (collision.tag == "pipe")
        {
            GM.CanClean = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }
        //
        if (collision.tag == "marProPart")
        {
            GM.CanClean = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }
        //
        if (collision.tag == "eMotorPart")
        {
            GM.CanClean = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }
            //
        if (collision.tag == "airComPart")
        {
            GM.CanClean = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }
            if (collision.tag == "sTurbPart")
            {
                GM.CanClean = true;
                GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
            }
        }


    //when you aren't touching/near any of the pickup items
    private void OnTriggerExit2D(Collider2D collision)
    {
        //
        if (collision.tag == "Smetal")
        {
            GM.CanClean = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        //
        if (collision.tag == "Rmetal")
        {
            GM.CanClean = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        //
        if (collision.tag == "pipe")
        {
            GM.CanClean = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        //
        if (collision.tag == "marProPart")
        {
            GM.CanClean = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        //
        if (collision.tag == "eMotorPart")
        {
            GM.CanClean = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        //
        if (collision.tag == "airComPart")
        {
            GM.CanClean = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        if (collision.tag == "sTurbPart")
        {
            GM.CanClean = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
    }
  
}
