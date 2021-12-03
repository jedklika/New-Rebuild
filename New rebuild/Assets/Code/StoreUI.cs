using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreUI : MonoBehaviour
{

    //calling GameManagerScript
    GameManger GM;



    // Start is called before the first frame update
    void Start()
    {


        GM = FindObjectOfType<GameManger>();

        GM.buy2.onClick.AddListener(buyTier2);
        GM.buy3.onClick.AddListener(buyTier3);
        GM.buy4.onClick.AddListener(buyTier4);
        GM.buy5.onClick.AddListener(buyTier5);
    }

    // Update is called once per frame
    void Update()
    {
 

    }


    public void buyTier2()
    {

         Debug.Log("Testing Button");

        if (GM.currency >= 100 && !GM.bought2)
        {
            GM.buytier2.text = "Sold";
            GM.bought2 = true;
            GM.currentPistol.sprite = GM.pistol2;
            GM.currency = GM.currency - 100;
            
        }
        else
        {
            Debug.Log("Can't afford");
        }
    }

    public void buyTier3()
    {
        if (GM.currency >= 200 && GM.bought2 && !GM.bought3 )
        {
            GM.buytier3.text = "Sold";
            GM.bought3 = true;
            GM.currentPistolImage = GM.pistol3;
            GM.currency -= 200;
            
        }
        else
        {
            Debug.Log("Can't afford");
        }
    }
   public void buyTier4()
    {
        if (GM.currency >= 300 && GM.bought3 && !GM.bought4)
        {
            GM.buytier4.text = "Sold";
            GM.bought4 = true;
            GM.currentPistolImage = GM.pistol4;
            GM.currency -= 300;
            
        }
        else
        {
            Debug.Log("Can't afford");
        }
    }
    public void buyTier5()
    {
        if (GM.currency >= 450 && GM.bought4 && !GM.bought5)
        {
            GM.buytier5.text = "Sold";
            GM.bought5 = true;
            GM.currentPistolImage = GM.pistol5;
            GM.currency -= 450;
           

        }
        else
        {
            Debug.Log("Can't afford");
        }
    }



}
