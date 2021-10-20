using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public int playerMaxHealth; //2x the amount of hearst (3 * 6)
    public int numOfHearts; //(3)
    public int playerCurrentHealth; // amount of half hearts (6)

    public Image[] hearts;  //heart objet
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;


    /*
    //Use this property to set health on Player from anywhere, it will cause HealthBar graphics to update at the same time.
    public int PlayerHealth
    {
        get { return _playerCurrentHealth; }
        set
        {
            _playerCurrentHealth = Mathf.Clamp(value, 0, PlayerMaxHealth);
            SetHealthBarHealth(_playerCurrentHealth);
            //You can add other things to happen here as well, like check if health is 0 and cause death as an example:
            // if(_playerCurrentHealth == 0) { Die(); }
        }
    }
    //Same idea as the PlayerHealth property above, same uses.
    public int PlayerMaxHealth
    {
        set
        {
            _playerMaxHealth = Mathf.Max(0, value); //Make sure maxHealh can't go below 0 to avoid issues.
            UpdateHealthBarHeartCount(PlayerMaxHealth); //Update the Health Bar graphics
        }
        get { return _playerMaxHealth; }
    }

    private void Awake()
    {
        //Initialize the HP bar graphics by assigning their own value back to them, causing their respective "Set{}" methods to execute.
        PlayerHealth = PlayerMaxHealth;
        //Since we are assigning to the MaxHealth, it will then call UpdateHealthBarHeartCount(), resulting in the correct amount of heartPrefabs spawning.
        PlayerMaxHealth = PlayerMaxHealth;
    }

    //This is only called when in Editor. It will let you freely adjust the Health and MaxHealth in the inspector in the editor for testing as needed.
    private void OnValidate()
    {
        PlayerHealth = PlayerHealth;
        PlayerMaxHealth = PlayerMaxHealth;
    }
    */






    // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
           
            //health = hearts * 2 because each heart carries 2 HP Points
            if(playerMaxHealth > numOfHearts)
            {
                playerMaxHealth = numOfHearts * 2;
            }

            // if i is less than the health make heart empty
            /*
                if(i < health)
                 {
                      hearts[i].sprite = fullHeart;
                 }
                else if ()
                {
                heaers[i].sprite = fullHeart;
                }

                 else
                 {
                    hearts[i].sprite = emptyHeart;
            }    
            
            */

            switch (playerMaxHealth) {
                case 0:
                    hearts[i].sprite = emptyHeart;
                    break;
                case 1:
                    hearts[i].sprite = halfHeart;
                    break;
                case 2:
                    hearts[i].sprite = fullHeart;
                    break;
            
            }






            //if you have more hearts than needed it will make them invisible

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }
        }

     /*
        //Used to update the amount of Heart sprites in the Health Bar automatically.
        public void UpdateHealthBarHeartCount(int maxHealth)
        {
            //Convert maxHealth "quater hearts" value into whole hearts value.
            //Ceil to ensure less than a whole heart still spawns heart object
            maxHealth = Mathf.CeilToInt(maxHealth / 4.0f);

            int heartCount = hearts.Count;

            if (maxHealth > heartCount)
            {
                int heartsToAdd = maxHealth - heartCount;

                for (int i = 0; i < heartsToAdd; i++)
                {
                    hearts.Add(Instantiate(heartPrefab.gameObject, heartContainer).GetComponent<Image>());
                }
                SetHealthBarHealth(PlayerMaxHealth); //Since we added hearts, update heart graphics so the new hearts respect current health value.
            }
            else if (maxHealth < heartCount)
            {
                int heartsToRemove = heartCount - maxHealth;
                for (int i = 0; i < heartsToRemove; i++)
                {
                    int lastHeartIndex = hearts.Count - 1;
                    Destroy(hearts[lastHeartIndex].gameObject);
                    hearts.RemoveAt(lastHeartIndex);
                }
            }
        }
        */

    }







}
