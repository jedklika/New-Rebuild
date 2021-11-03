using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    // Start is called before the first frame update
    //calling GameManagerScript
    GameManger GM;
    private void Start()
    {
        GM = FindObjectOfType<GameManger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
