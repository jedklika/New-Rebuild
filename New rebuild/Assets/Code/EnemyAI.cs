using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Enemy AI
    // Movement around the game area
        // Enemy can't go out of the area
    // When player get into the emeny area
        // Enemy starts chasing the player

public class EnemyAI : MonoBehaviour
{

    private enum STATE
    {
        ChaseEnemy,Roaming
    }

    private Transform target;
    private Vector2 randomRoamingTarget;

    private float randomRoamingTargetx;
    private float randomRomaingTargety;

    private int current;


    private float waitTime;
    public float startWaitTime;

    private SpriteRenderer SR;


    public Transform[] moveSpots;

    [Range(0.1f,10f)]
    public float speed = 0.3f;
    public float enemyStoppingDistance = 1.5f;
    public float enemyRadius = 3f;

    public int health;


    // Start is called before the first frame update
    void Start()
    {
        current = Random.Range(0, moveSpots.Length);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        STATE enemyState = STATE.Roaming;
        Debug.Log("Roamer");
        SR.color = Color.blue;


        if (Vector2.Distance(target.position, transform.position) < enemyRadius){
            enemyState = STATE.ChaseEnemy;
            Debug.Log("Kill");
            SR.color = Color.red;
        }
        switch (enemyState)
        {
            case (STATE.ChaseEnemy):
                if (Vector2.Distance(transform.position, target.position) > enemyStoppingDistance){
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    Debug.Log("Kill Player");
                    //SR.color = Color.red;
                }
                break;
            case (STATE.Roaming):
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[current].position, speed * Time.deltaTime);
                Debug.Log("Roaming");
                //SR.color = Color.blue;
                if (Vector2.Distance(transform.position,moveSpots[current].position) < 0.2f) { 
                        if(waitTime <= 0)
                        {
                            current = Random.Range(0, moveSpots.Length);
                            waitTime = startWaitTime;
                        }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                    }
                // randomRoamingTarget = new Vector2(transform.position.x + randomRoamingTargetx, transform.position.y + randomRomaingTargety);
                // randomRoamingTarget = new Vector2( transform.position.x + (Random.Range(-1f, 1f) * randomRoamingTargetx), transform.position.y + (Random.Range(-1f, 1f) * randomRomaingTargety));
                // transform.position = Vector2.MoveTowards(transform.position, randomRoamingTarget, speed * Time.deltaTime);
                break;
        }
    }

   
  
    /*
    void setRandom(Transform [] arr)
    {
        Transform newPoint;

        newPoint = GameObject.FindGameObjectWithTag("Pointer").transform;
        for(int a = 0; a < arr.Length; a++)
        {
            newPoint.position = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            arr[a] = newPoint;
        }
    }

    */
    
  
}
