using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    // Start is called before the first frame update
    //calling GameManagerScript
    GameManger GM;
    public GameObject Colliderobject;
    public SpriteRenderer Repair;
    public GameObject AC;
    public GameObject DE;
    public GameObject ST;
    public GameObject MP;
    public GameObject EM;



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

        AC = GameObject.FindGameObjectWithTag("AC");
        DE = GameObject.FindGameObjectWithTag("DE");
        ST = GameObject.FindGameObjectWithTag("ST");
        MP = GameObject.FindGameObjectWithTag("MP");
        EM = GameObject.FindGameObjectWithTag("EM");

        //in the start player starts out with no money
        GM.currency = 0;


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
       

        //Give currency amount
        GM.Money.text = "Current Money: " + GM.currency.ToString();
        //updates store currency as well
        GM.Money2.text = GM.Money.text;

        //testing Repair
        //when you click E to clean up basic scraps

        if (Input.GetKeyDown(KeyCode.E) && GM.CanPickUpHealth)
        {
            GM.CanPickUpHealth = false;
            GM.healthKits += 1;
            GM.MedKit.text = "Current Medkits: " + GM.healthKits.ToString();
            Destroy(Colliderobject);
            Colliderobject = null;
        }
//Air compressor repair
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
        //requirements to build air compressor
        //scrap metal = 1; broken pipe = 1; rusty metal = 3; air compressor part = 1;
        if (GM.scrapMetalAmount >= 1 && GM.brokenPipeAmount >= 1 && GM.rustyMetalAmount >= 3 && GM.airCompressionPartAmount >= 1)
        {
            GM.canRepairAirCompressor = true;
        }
        else GM.canRepairAirCompressor = false; 

        //when you repair the air compressor remove items from inventory
        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairAirCompressor && GM.CanfixAC))
        {
            GM.PickUp.enabled = false;
            Repair = AC.GetComponent<SpriteRenderer>();
            Repair.color = Color.white;
            GM.canCleanAC = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            GM.airCompressionPartAmount -= 1;
            GM.airCompressorRepaired = true; // is repaired
                                           
            //when you repair you get currency
            GM.currency += 90;


        }

//Steam Turbine Repairs
        //when you pick up steam turbine scraps
        if ((Input.GetKeyDown(KeyCode.E) && GM.canCleanST))
        {
            GM.canCleanST = false;
            //scrap metal = 1; broken pipe = 1; rusty metal = 3; steam turbine part = 1;
            GM.scrapMetalAmount += 1;
            GM.brokenPipeAmount += 1;
            GM.rustyMetalAmount += 3;
            GM.steamTurbinePartAmount += 1;
            Destroy(Colliderobject);
            Colliderobject = null;
        }

        //requirements to build steam turbine
        //scrap metal = 1; broken pipe = 1; rusty metal = 3; steam turbine part = 1;
        if (GM.scrapMetalAmount >= 1 && GM.brokenPipeAmount >= 1 && GM.rustyMetalAmount >= 3 && GM.steamTurbinePartAmount >= 1){
            GM.canRepairSteamTurbine = true;
        }
        else GM.canRepairSteamTurbine = false;
        

        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairSteamTurbine && GM.CanFixST))
        {
            Repair = ST.GetComponent<SpriteRenderer>();
            Repair.color = Color.white;
            GM.canCleanST = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            GM.steamTurbinePartAmount -= 1;
            GM.steamTurbineRepaired = true; // is repaired
                                            //when you repair you get currency
            GM.currency += 75;

        }
        
//marine propulsion repair
        //when you pick up marine propulsion scraps
        //scrap metal = 1; broken pipe = 1; rusty metal = 3; marine propulsion part = 1;
        if ((Input.GetKeyDown(KeyCode.E) && GM.canCleanMP))
        {
            GM.canCleanMP = false;
            //scrap metal = 1; broken pipe = 1; rusty metal = 3; marine propulsion part = 1;
            GM.scrapMetalAmount += 1;
            GM.brokenPipeAmount += 1;
            GM.rustyMetalAmount += 3;
            GM.marinePropulsionPartAmount += 1;
            Destroy(Colliderobject);
            Colliderobject = null;
        }

        //requirements to build marine propulsion
        if (GM.scrapMetalAmount >= 1 && GM.brokenPipeAmount >= 1 && GM.rustyMetalAmount >= 3 && GM.marinePropulsionPartAmount >= 1)
        {
            GM.canRepairMarinePropulsion = true;
        }
        else
        {
            GM.canRepairMarinePropulsion = false;
        }

        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairMarinePropulsion && GM.CanFixMP))
        {
            GM.canCleanMP = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            GM.marinePropulsionPartAmount -= 1;
            Repair = MP.GetComponent<SpriteRenderer>();
            Repair.color = Color.white;
            GM.marinePropulsionRepaired = true; // is repaired

            //when you repair you get currency
            GM.currency += 100;

        }

//electric motor repair
        //when you pick up electric motor scraps
        if ((Input.GetKeyDown(KeyCode.E) && GM.canCleanEM))
        //scrap metal = 1; broken pipe = 1; rusty metal = 3; electric motor part = 1;
        {
            GM.canCleanEM = false;
            GM.scrapMetalAmount += 1;
            GM.brokenPipeAmount += 1;
            GM.rustyMetalAmount += 3;
            GM.electricMotorPartAmount += 1;
            Destroy(Colliderobject);
            Colliderobject = null;
        }

        //requirements to build electric motor
        if (GM.scrapMetalAmount >= 1 && GM.brokenPipeAmount >= 1 && GM.rustyMetalAmount >= 3 && GM.electricMotorPartAmount >= 1)
        {
            GM.canRepairElectricMotor = true;
        }
        else
        {
            GM.canRepairElectricMotor = false;
        }

        if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairElectricMotor && GM.CanFixEM))
        {
            Repair = EM.GetComponent<SpriteRenderer>();
            Repair.color = Color.white;
            GM.canCleanEM = false;
            GM.scrapMetalAmount -= 1;
            GM.brokenPipeAmount -= 1;
            GM.rustyMetalAmount -= 3;
            GM.electricMotorPartAmount -= 1;
            GM.electricMotorRepaired = true; // is repaired

            //when you repair you get currency
            GM.currency += 150;

        }

//diesel engine repair
        //when you pick up diesel engine scraps
        if ((Input.GetKeyDown(KeyCode.E) && GM.canCleanDE))
        {
            GM.canCleanDE = false;
            GM.scrapMetalAmount += 1;
            GM.brokenPipeAmount += 1;
            GM.rustyMetalAmount += 3;
            Destroy(Colliderobject);
            Colliderobject = null;
        }
        //requirements to build diesel engine
        //scrap metal = 1; broken pipe = 1; rusty metal = 3;
        if (GM.scrapMetalAmount >= 1 && GM.brokenPipeAmount >= 1 && GM.rustyMetalAmount >= 3 )
                {
                    GM.canRepairDieselEngine = true;
                }
                else
                {
                    GM.canRepairDieselEngine = false;
                }

                if ((Input.GetKeyDown(KeyCode.E) && GM.canRepairDieselEngine && GM.CanFixDE))
                {
                    Repair = DE.GetComponent<SpriteRenderer>();
                    Repair.color = Color.white;
                    GM.CanClean = false;
                    GM.scrapMetalAmount -= 1;
                    GM.brokenPipeAmount -= 1;
                    GM.rustyMetalAmount -= 3;
                    GM.dieselEngineRepaired = true; // is repaired

            //when you repair you get currency
            GM.currency += 50;

        }
    }
//when you are near or ontop of the scraps or machine you can interact with them
    private void OnTriggerStay2D(Collider2D collision)
    {
        //triggers for types of mess miles/scraps
        //tags: BasicScraps, MarineScraps, ElectricScraps, CompressorScraps, TurbineScraps

        if (collision.tag == "Kit")
        {
            GM.CanPickUpHealth = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to Pick up health kit";
            Colliderobject = collision.gameObject;
        }

        //each scrap has a specific "can clean" 
        //when canCleanAC is true, and you press E over a machine with the AC tag, player will pick up
       //materials that will allow player to build the air compressor
        if (collision.tag == "CompressorScraps" ) //scrap metal, broken pipe, rusty metal
        {
            GM.canCleanAC = true;
             GM.PickUp.enabled = true;
             GM.PickUp.text = "Press E to clean";
             Colliderobject = collision.gameObject; 
            //cleanPresetStay(collision);
        }
        
        if (collision.tag == "MarineScraps") //scrap metal, broken pipe, rusty metal
        {
            GM.canCleanMP = true;
            cleanPresetStay(collision);
        }

        if (collision.tag == "ElectricScraps") //scrap metal, broken pipe, rusty metal
        {
            GM.canCleanEM = true;
            cleanPresetStay(collision);
        }

        if (collision.tag == "TurbineScraps") //scrap metal, broken pipe, rusty metal
        {
            GM.canCleanST = true;
            cleanPresetStay(collision);
        } 
        
        if (collision.tag == "DieselScraps") //scrap metal, broken pipe, rusty metal
        {

            GM.canCleanDE = true;

            cleanPresetStay(collision);
        }
         


    //triggers for repairable machines
        //repair test machine triggers
        //repair air compressor triggers
        if(collision.tag == "AC" && GM.canRepairAirCompressor)
        {
            GM.CanfixAC = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Press E to Repair";
            Colliderobject = collision.gameObject;
            Repair = Colliderobject.GetComponent<SpriteRenderer>();
            //repairPresetStay(collision);
        }
        if (collision.tag == "AC" && GM.canRepairAirCompressor == false && GM.airCompressorRepaired == false)
        {
            GM.CanfixAC = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Need 1 scrap metal, 1 pipe, 3 rusty metal, 1 air compressor part";
            Colliderobject = collision.gameObject;
              
        }

        //repair marine propulsion triggers
        if (collision.tag == "MP" && GM.canRepairMarinePropulsion)
        {

            GM.CanFixMP = true;
            repairPresetStay(collision);
        }
        if (collision.tag == "MP" && GM.canRepairMarinePropulsion == false && GM.marinePropulsionRepaired == false)
        {
            GM.CanFixMP = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Need 1 scrap metal, 1 pipe, 3 rusty metal, 1 marine propulsion part";
            Colliderobject = collision.gameObject;

        }


        //repair electric motor triggers
        if (collision.tag == "EM" && GM.canRepairElectricMotor)
        {
            GM.CanFixEM = true;
            repairPresetStay(collision);
        }
        if (collision.tag == "EM" && GM.canRepairElectricMotor == false && GM.electricMotorRepaired == false)
        {
            GM.CanFixEM = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Need 1 scrap metal, 1 pipe, 3 rusty metal, 1 electric motor part";
            Colliderobject = collision.gameObject;

        }


        //repair turbine scraps triggers
        if (collision.tag == "ST" && GM.canRepairSteamTurbine)
        {
            GM.CanFixST = true;
            repairPresetStay(collision);
        }
        if (collision.tag == "ST" && GM.canRepairSteamTurbine == false && GM.steamTurbineRepaired == false)
        {
            GM.CanFixST = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Need 1 scrap metal, 1 pipe, 3 rusty metal, 1 steam turbine part";
            Colliderobject = collision.gameObject;

        }


        //repair diesel engine triggers
        if (collision.tag == "DE" && GM.canRepairDieselEngine)
        {
            GM.CanFixDE = true;
            repairPresetStay(collision);
        }
        if (collision.tag == "DE" && GM.canRepairDieselEngine == false && GM.dieselEngineRepaired == false)
        {
            GM.CanFixDE = true;
            GM.PickUp.enabled = true;
            GM.PickUp.text = "Need 1 scrap metal, 1 pipe, 3 rusty metal, 1 diesel engine part";
            Colliderobject = collision.gameObject;

        }
    }


//when you aren't touching/near any of the pickup items you cannot interact with them
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Kit")
        {
            GM.CanPickUpHealth = false;
            GM.PickUp.enabled = false;
            Colliderobject = null;
        }
        //exit triggers for different mespiles/scraps
        //tags: BasicScraps, MarineScraps, ElectricScraps, CompressorScraps, TurbineScraps
        if (collision.tag == "CompressorScraps") // air compressor (basic scraps + air compressor part)
        {
            GM.canCleanAC = false;
         
           /* GM.PickUp.enabled = false;
            Colliderobject = null;*/
            cleanPresetExit();
        }
         if (collision.tag == "MarineScraps") //marine propulsion
         {
             GM.canCleanMP = false;
            cleanPresetExit();
        }
         if (collision.tag == "ElectricScraps") //elctric motor
         {
             GM.canCleanEM = false;
            cleanPresetExit();
        }
         if (collision.tag == "TurbineScraps") // 
         {
             GM.canCleanST = false;
            cleanPresetExit();
        }
         if (collision.tag == "DieselScraps") // 
         {
             GM.canCleanDE = false;
            cleanPresetExit();
        }

         

        //exit triggers for repairable machines
        //tags: DE, AC, ST, MP, EM=


if (collision.tag == "ST") // steam turbine
{
   
    GM.canRepairSteamTurbine = false;
            repairPresetExit();
        }
if (collision.tag == "MP") //marine propulsion
{
    
    GM.canRepairMarinePropulsion = false;
            repairPresetExit();
        }
if (collision.tag == "EM") // electric motor
{
    
    GM.canRepairElectricMotor = false;
            repairPresetExit();
        }
if (collision.tag == "DE") // diesel engine
{
    
    GM.canRepairDieselEngine = false;
            repairPresetExit();
        } 

    }

    //removes repetiveness for triggers
    //repair triggers
    public void repairPresetStay(Collider2D collision)
    {
        GM.PickUp.enabled = true;
        GM.PickUp.text = "Press E to Repair";
        Colliderobject = collision.gameObject;
        Repair = Colliderobject.GetComponent<SpriteRenderer>();
    }
    public void repairPresetExit()
    {
        GM.PickUp.enabled = false;
        GM.PickUp.text = "";
        Colliderobject = null;
        Repair = null;
        GM.CanPickUpHealth = false;
        GM.CanfixAC = false;
        GM.CanFixDE = false;
        GM.CanFixEM = false;
        GM.CanFixMP = false;
        GM.CanFixST = false;
    }
    //clean up triggers
    public void cleanPresetExit()
    {
        GM.PickUp.enabled = false;
        Colliderobject = null;
    }
    public void cleanPresetStay(Collider2D collision)
    {
        GM.PickUp.enabled = true;
        GM.PickUp.text = "Press E to clean";
        Colliderobject = collision.gameObject;
    }

}
