using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameManger GM;
    // Start is called before the first frame update
    private void Start()
    {
        GM = FindObjectOfType<GameManger>();
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E) && GM.CanPickUpHealth)
    //    {
    //        GM.healthKits += 1;
    //        GM.MedKit.text = "Current Medkits: " + GM.healthKits.ToString();
    //        Destroy();
    //        GM.PickUp.enabled = false;
    //    }
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        GM.CanPickUpHealth = true;
    //        GM.PickUp.enabled = true;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        GM.CanPickUpHealth = false;
    //        GM.PickUp.enabled = false;
    //    }
    //}
    //public void Destroy()
    //{
    //    Destroy(this.gameObject);
    //}
}
