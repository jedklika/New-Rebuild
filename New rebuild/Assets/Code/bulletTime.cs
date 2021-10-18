using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTime : MonoBehaviour 
{ 
    public float lifeTime;
    public SpriteRenderer SR;
    public WeaponSwitch WS;
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
        }
       else if(WS.gun == 2)
        {
            SR.color = Color.green;
            lifeTime = .1f;
           
        }
       else if (WS.gun == 3)
        {
            SR.color = Color.cyan;
            lifeTime = .2f;
        }
       if(WS.gun != 1 && Input.GetKeyDown(KeyCode.Alpha2) || WS.gun != 1 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(gameObject);
        }
        if (WS.gun != 2 && Input.GetKeyDown(KeyCode.Alpha1) || WS.gun != 2 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(gameObject);
        }
        if (WS.gun != 3 && Input.GetKeyDown(KeyCode.Alpha1) || WS.gun != 3 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void DestroyProjectile()
{
    Destroy(gameObject);
}
}
