using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerFollow;

    public float smoothSpeed = 0.125f;
    public final endBackgroundPosition = 200;
    public final beginBackgroundPosition = 1;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        playerFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = playerFollow.position.x;

        transform.position = temp;

        if(playerFollow.position.x > endBackgroundPosition){
            temp.x = 
            transform.position = temp;
        }
    }
}
