using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    // Start is called before the first frame update
    //calling GameManagerScript
    GameManger GM;
    public GameObject Colliderobject;
    public SpriteRenderer Repair;


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

       //when you click E to clean up basic scraps
        if ((Input.GetKeyDown(KeyCode.E) && GM.CanClean))
        {
           GM.CanClean = false;
            //1 scrap metal, 1 broken pipe, and 3 rusty metal pieces
           GM.scrapMetalAmount += 1;
           GM.brokenPipeAmount += 1;
           GM.rustyMetalAmount += 3; 
           Destroy(Colliderobject);
           Colliderobject = null;
        }

        //When you pick up air compressor scraps
        if ((Input.GetKeyDown(KeyCode.E) && GM.canCleanAC))
        {
            GM.canCleanAC = false;
            //scrap metal = 1; broken pipe = 1; rusty metal = 3; air compressor part = 1;
            GM.scrapMetalAmount += 1;
            GM.brokenPipeAmount += 1;
            GM.rustyMetalAmount += 3;
            GM.airCompressionPartAmount += 1;
            Destroy(Colliderobject);
            Colliderobject = null;
        }

        //when you pick up steam turbine scraps

        //when you pick up marine propulsion scraps

        //when you pick up electric motor scraps

        //when you pick up diesel engine scraps



        //requirements for a test machine
        if (GM.scrapMetalAmount == 1 && GM.brokenPipeAmount == 1 && GM.rustyMetalAmount == 3)
        {
            GM.canRepairTestMachine = true;
        }
        else
        {
            GM.canRepairTestMachine = false;
        }

        //when you repair the test machine remove items from inventory
        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairTestMachine && GM.CanRepair))
        {
            GM.CanClean = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            Repair = Colliderobject.GetComponent<SpriteRenderer>();
            Repair.color = Color.yellow;
            GM.testMachineRepaired = true; //testMachine is repaired
        }

        //requirements to build air compressor
        //scrap metal = 1; broken pipe = 1; rusty metal = 3; air compressor part = 1;
        if (GM.scrapMetalAmount == 1 && GM.brokenPipeAmount == 1 && GM.rustyMetalAmount == 3 && GM.airCompressionPartAmount == 1)
        {
            GM.canRepairAirCompressor = true;
        }
        else
        {
            GM.canRepairAirCompressor = false;
        }

        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairAirCompressor && GM.CanRepair))
        {
            GM.canCleanAC = false; //maybe change back
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            GM.airCompressionPartAmount -= 1;
            Repair = Colliderobject.GetComponent<SpriteRenderer>();
            Repair.color = Color.yellow;
            GM.airCompressorRepaired = true; // is repaired
        }

/* once i get air compressor to work i can work on these
        //requirements to build steam turbine
        //scrap metal = 1; broken pipe = 1; rusty metal = 3; steam turbine part = 1;
        if (GM.scrapMetalAmount == 1 && GM.brokenPipeAmount == 1 && GM.rustyMetalAmount == 3 && GM.steamTurbinePartAmount == 1)
        {
            GM.canRepairSteamTurbine = true;
        }
        else
        {
            GM.canRepairSteamTurbine = false;
        }

        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairSteamTurbine && GM.CanRepair))
        {
            GM.CanClean = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            GM.steamTurbinePartAmount -= 1;
            Repair = Colliderobject.GetComponent<SpriteRenderer>();
            Repair.color = Color.yellow;
            GM.steamTurbineRepaired = true; // is repaired
        }


        //requirements to build marine propulsion
        //scrap metal = 1; broken pipe = 1; rusty metal = 3; marine propulsion part = 1;
        if (GM.scrapMetalAmount == 1 && GM.brokenPipeAmount == 1 && GM.rustyMetalAmount == 3 && GM.marinePropulsionPartAmount == 1)
        {
            GM.canRepairMarinePropulsion = true;
        }
        else
        {
            GM.canRepairMarinePropulsion = false;
        }

        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairMarinePropulsion && GM.CanRepair))
        {
            GM.CanClean = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            GM.marinePropulsionPartAmount -= 1;
            Repair = Colliderobject.GetComponent<SpriteRenderer>();
            Repair.color = Color.yellow;
            GM.marinePropulsionRepaired = true; // is repaired
        }


        //requirements to build electric motor
        //scrap metal = 1; broken pipe = 1; rusty metal = 3; electric motor part = 1;
        if (GM.scrapMetalAmount == 1 && GM.brokenPipeAmount == 1 && GM.rustyMetalAmount == 3 && GM.electricMotorPartAmount == 1)
        {
            GM.canRepairelectricMotor = true;
        }
        else
        {
            GM.canRepairelectricMotor = false;
        }

        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairelectricMotor && GM.CanRepair))
        {
            GM.CanClean = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            GM.electricMotorPartAmount -= 1;
            Repair = Colliderobject.GetComponent<SpriteRenderer>();
            Repair.color = Color.yellow;
            GM.electricMotorRepaired = true; // is repaired
        }


        //requirements to build diesel engine
        //scrap metal = 1; broken pipe = 1; rusty metal = 3;
        if (GM.scrapMetalAmount == 1 && GM.brokenPipeAmount == 1 && GM.rustyMetalAmount == 3 )
        {
            GM.canRepairDieselEngine = true;
        }
        else
        {
            GM.canRepairDieselEngine = false;
        }

        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairDieselEngine && GM.CanRepair))
        {
            GM.CanClean = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            Repair = Colliderobject.GetComponent<SpriteRenderer>();
            Repair.color = Color.yellow;
            GM.dieselEngineRepaired = true; // is repaired
        } */





    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //triggers for types of mess miles/scraps
        //tags: BasicScraps, MarineScraps, ElectricScraps, CompressorScraps, TurbineScraps
        if (collision.tag == "BasicScraps")
        {
            GM.CanClean = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }

        //each scrap has a specific "can clean" 
        //when canCleanAC is true, and you press E over a machine with the AC tag, player will pick up
       //materials that will allow player to build the air compressor
        if (collision.tag == "CompressorScraps") //scrap metal, broken pipe, rusty metal
        {
            GM.canCleanAC = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }

        /*
        if (collision.tag == "MarineScraps") //scrap metal, broken pipe, rusty metal
        {
            GM.canCleanMP = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }

        if (collision.tag == "ElectricScraps") //scrap metal, broken pipe, rusty metal
        {
            GM.canCleanEM = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        }

        if (collision.tag == "TurbineScraps") //scrap metal, broken pipe, rusty metal
        {
            GM.canCleanST = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to clean";
            Colliderobject = collision.gameObject;
        } */


        //triggers for repairable machines
        if (collision.tag == "Repair" && GM.canRepairTestMachine) //for testing purposes repair applies to the testing machine, i think we need a tag for each machine we need to repair
        {
            GM.CanRepair = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to Repair";
            Colliderobject = collision.gameObject;
        }
        if (collision.tag == "Repair" && GM.canRepairTestMachine == false && GM.testMachineRepaired == false)
        {
            GM.CanRepair = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Need 1 scrap metal, 1 pipe, 3 rusty metal";
            Colliderobject = collision.gameObject;
        }

        if(collision.tag == "AC" && GM.canRepairAirCompressor)
        {
            GM.canRepairAirCompressor = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to Repair";
            Colliderobject = collision.gameObject;
        }
        if (collision.tag == "AC" && GM.canRepairAirCompressor == false && GM.airCompressorRepaired == false)
        {
            GM.CanRepair = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Need 1 scrap metal, 1 pipe, 3 rusty metal, 1 air compressor part";
            Colliderobject = collision.gameObject;
        }
    }


    //when you aren't touching/near any of the pickup items
    private void OnTriggerExit2D(Collider2D collision)
    {
        //exit triggers for different mespiles/scraps
        //tags: BasicScraps, MarineScraps, ElectricScraps, CompressorScraps, TurbineScraps
        if (collision.tag == "BasicScraps") //scrap metal, broken pipe, rusty metal
        {
            GM.CanClean = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }


        if (collision.tag == "MarineScraps") //
        {
            GM.canCleanMP = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }

        if (collision.tag == "ElectricScraps") //
        {
            GM.canCleanEM = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        if (collision.tag == "CompressorScraps") //
        {
            GM.canCleanAC = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        if (collision.tag == "TurbineScraps") //
        {
            GM.canCleanST = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }

        //exit triggers for repairable machines
        //tags: DE, AC, ST, MP, EM
        if (collision.tag == "Repair") //test machine for these purposes
        {
            GM.CanRepair = false;
            GM.PickUp.enabled = false;
            GM.PickUp.text = "";
            Colliderobject = null;
        }

        if (collision.tag == "AC") //air compressor
{
    GM.canRepairAirCompressor = false;
    GM.PickUp.enabled = false;
    GM.PickUp.text = "";
    Colliderobject = null;
}

//is this necessary??
//for now, no
/*if (collision.tag == "AC") //air compressor
{
    GM.CanRepair = false;
    GM.PickUp.enabled = false;
    GM.PickUp.text = "";
    Colliderobject = null;
}
if (collision.tag == "ST") // steam turbine
{
    GM.CanRepair = false;
    GM.PickUp.enabled = false;
    GM.PickUp.text = "";
    Colliderobject = null;
}
if (collision.tag == "MP") //marine propulsion
{
    GM.CanRepair = false;
    GM.PickUp.enabled = false;
    GM.PickUp.text = "";
    Colliderobject = null;
}
if (collision.tag == "EM") // electric motor
{
    GM.CanRepair = false;
    GM.PickUp.enabled = false;
    GM.PickUp.text = "";
    Colliderobject = null;
}
if (collision.tag == "DE") // diesel engine
{
    GM.CanRepair = false;
    GM.PickUp.enabled = false;
    GM.PickUp.text = "";
    Colliderobject = null;
} */

    }

}
