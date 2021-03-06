using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    //health and damage variables
    public float playerHealth;
    public float Playerdamage;
    public float EnemyDamage;

    //weapon level 
    public int pistolLevel;
    public int shotgunLevel;
    public int rifleLevel;

    //images + sprites for heart
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    public Image Gameover;   //gameover image
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite EmptyHeart;

    public bool isDead;
    PlayerMovement player;

    //game text
    public Text GameOver;
    public Text Replay;
    public int healthKits; //number of health kits
    public Text MedKit; 
    

    // bool statements 
    public bool CanPickUpHealth; //if true player can pick up health kits
    public bool CanClean; // if true player can pick up trash

    //tells player how to pick up items
    public Text PickUp;

    Item Object;
    public Text Weapon;
    public int metal;
    public int adhesive;
    public int tubing;

    // values for inventory items
    public int scrapMetalAmount;
    public int brokenPipeAmount;
    public int rustyMetalAmount;
    public int marinePropulsionPartAmount;
    public int electricMotorPartAmount;
    public int airCompressionPartAmount;
    public int steamTurbinePartAmount;
    //health kits for later
    public int smallHealthKitAmount;
    public int mediumHealthKitAmount;
    public int bigHealthKitAmount;

    //txt for inventory item amount
    public Text scrapMetalAmountTxt;
    public Text brokenPipeAmountTxt;
    public Text rustyMetalAmountTxt;
    public Text marinePropulsionPartAmountTxt;
    public Text electricMotorPartAmountTxt;
    public Text airCompressionPartAmountTxt;
    public Text steamTurbinePartAmountTxt;
    //health kits for later
    public Text smallHealthKitTxt;
    public Text mediumHealthKitTxt;
    public Text bigHealthKitTxt;

    //inventory items images
    public Image scrapMetal;
    public Image brokenPipe;
    public Image rustyMetal;
    public Image marinePropulsionPart;
    public Image electricMotorPart;
    public Image airCompressionPart;
    public Image steamTurbinePart;
    //health kits for later
    public Image smallHealthKit;
    public Image mediumHealthKit;
    public Image bigHealthKit;


    //rebuilding bool
    // if a machine has been rebuilt the bool will be true
    public bool testMachineRepaired;
    public bool dieselEngineRepaired;
    public bool airCompressorRepaired;
    public bool steamTurbineRepaired;
    public bool marinePropulsionRepaired;
    public bool electricMotorRepaired;

    // if a machine can be rebuilt bool will be true
    public bool canRepairTestMachine;
    public bool canRepairDieselEngine;
    public bool canRepairAirCompressor;
    public bool canRepairSteamTurbine;
    public bool canRepairMarinePropulsion;
    public bool canRepairElectricMotor;

    //bool for cleaning specific scraps
    public bool canCleanAC;
    public bool canCleanDE;
    public bool canCleanST;
    public bool canCleanMP;
    public bool canCleanEM;

    // bools for fixing specific machines
    public bool CanfixAC;
    public bool CanFixDE;
    public bool CanFixST;
    public bool CanFixMP;
    public bool CanFixEM;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Heart1.sprite = FullHeart;
        Heart2.sprite = FullHeart;
        Heart3.sprite = FullHeart;
        Gameover.enabled = false;
        player = FindObjectOfType<PlayerMovement>();
        player.enabled = true;
        GameOver.enabled = false;
        Replay.enabled = false;
        MedKit.text = "Current Medkits: " + healthKits.ToString();
        CanPickUpHealth = false;
        PickUp.enabled = false;
        Object = FindObjectOfType<Item>();
        Weapon.text = "Pistol";
        CanfixAC = false;
        CanFixDE = false;
        CanFixEM = false;
        CanFixMP = false;
        CanFixST = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        //press G, if you have health kits, less than 3 hearts, health will increase
        if (Input.GetKeyDown(KeyCode.G) && playerHealth < 3 && healthKits > 0)
        {
            playerHealth += .5f;
            healthKits -= 1;
            MedKit.text = "Current Medkits: " + healthKits.ToString() ;
        }
        switch (playerHealth)
        {
            case 3:
                Heart1.sprite = FullHeart;
                Heart2.sprite = FullHeart;
                Heart3.sprite = FullHeart;
                break;
            case 2.5f:
                Heart1.sprite = HalfHeart;
                break;
            case 2:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = FullHeart;
                break;
            case 1.5f:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = HalfHeart;
                break;
            case 1:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = EmptyHeart;
                Heart3.sprite = FullHeart;
                break;
            case 0.5f:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = EmptyHeart;
                Heart3.sprite = HalfHeart;
                break;
            case 0:
                Heart1.sprite = EmptyHeart;
                Heart2.sprite = EmptyHeart;
                Heart3.sprite = EmptyHeart;
                isDead = true;
                Weapon.text = "";
                MedKit.text = "";
                StartCoroutine(EndScreen());
                break;
        }
        IEnumerator EndScreen()
        {
            Weapon.text = "";
            MedKit.text = "";
            player.enabled = false;
            yield return new WaitForSeconds(1);
            Gameover.enabled = true;
            yield return new WaitForSeconds(.5f);
            GameOver.enabled = true;
            yield return new WaitForSeconds(.5f);
            Replay.enabled = true;
        }

    }
}
