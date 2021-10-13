using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public double health;
    public double numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    
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
            if(health > numOfHearts)
            {
                health = numOfHearts * 2;
            }

            // if i is less than the health make heart empty
                if(i < health)
                 {
                      hearts[i].sprite = fullHeart;
                 }

                 else
                 {
                    hearts[i].sprite = emptyHeart;
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


    }
}
