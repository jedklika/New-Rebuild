using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameManger GM;
    public GameObject Colliderobject;
    // Start is called before the first frame update
    private void Start()
    {
        GM = FindObjectOfType<GameManger>();
        Colliderobject = null;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GM.CanPickUpHealth)
        {
            GM.CanPickUpHealth = false;
            GM.healthKits += 1;
            GM.MedKit.text = "Current Medkits: " + GM.healthKits.ToString();
            Destroy(Colliderobject);
            Colliderobject = null;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Kit")
        {
            GM.CanPickUpHealth = true;
            GM.PickUp.enabled = true;
            Colliderobject = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Kit")
        {
            GM.CanPickUpHealth = false;
            GM.PickUp.enabled = false;
        }
    }
}
