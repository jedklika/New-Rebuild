using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTime : MonoBehaviour 
{ 
    public float lifeTime;
    public SpriteRenderer SR;
    public WeaponSwitch WS;
    public float switchDelay;
    public float startDelayTime;
// Start is called before the first frame update
void Start()
{
    Invoke("DestroyProjectile", lifeTime);
    SR = GetComponent<SpriteRenderer>();
    WS = FindObjectOfType<WeaponSwitch>();
}

 private void Update()
    {
       if(WS.gun == 1)
        {
            SR.color = Color.red;
            lifeTime = .2f;
            switchDelay = 3;
            startDelayTime = switchDelay;
        }
       else if(WS.gun == 2)
        {
            SR.color = Color.green;
            lifeTime = .1f;
            switchDelay = 3;
            startDelayTime = switchDelay;
           
        }
       else if (WS.gun == 3)
        {
            SR.color = Color.cyan;
            lifeTime = .15f;
            switchDelay = 5;
            startDelayTime = switchDelay;
        }
       //if(WS.gun != 1 && Input.GetKeyDown(KeyCode.Alpha2) || WS.gun != 1 && Input.GetKeyDown(KeyCode.Alpha3))
       // {
       //     Destroy(gameObject);
       // }
       // if (WS.gun != 2 && Input.GetKeyDown(KeyCode.Alpha1) || WS.gun != 2 && Input.GetKeyDown(KeyCode.Alpha3))
       // {
       //     Destroy(gameObject);
       // }
       // if (WS.gun != 3 && Input.GetKeyDown(KeyCode.Alpha1) || WS.gun != 3 && Input.GetKeyDown(KeyCode.Alpha2))
       // {
       //     Destroy(gameObject);
       // }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "NorthWall" || collision.tag == "SouthWall" || collision.tag == "EastWall" || collision.tag == "WestWall")
        {
            GameObject.Destroy(this.gameObject);
            WS.CanSwitch = true;
        }
    }

        // Update is called once per frame
   void DestroyProjectile()
{
    Destroy(gameObject);
    switchDelay = switchDelay - Time.time;
    if(switchDelay <= 0)
    {
            switchDelay = 0;
            Debug.Log("Switch Delay: " + switchDelay);
            WS.CanSwitch = true;
            if (WS.CanSwitch)
            {
                switchDelay = startDelayTime;
            }
    }
}
}
