using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public float lifeTime;
    public WeaponSwitch WS;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        WS = FindObjectOfType<WeaponSwitch>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "NorthWall" || collision.tag == "SouthWall" || collision.tag == "EastWall" || collision.tag == "WestWall")
        {
            GameObject.Destroy(this.gameObject);
          
        }
    }

    // Update is called once per frame
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
