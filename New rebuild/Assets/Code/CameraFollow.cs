using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Transform playerFollow is used to track the orientation of the player
    public Transform playerFollow;

    // Determines in a range from [1 to 10] on how smooth the follow camera should be
    [Range(1,10)]
    public float smoothFactor = 0.125f;

    // Used to provide an offset from the player's position
    public Vector3 offset;


    //public float endBackgroundPosition = 200f;
    //public float beginBackgroundPosition = 1f;
    


    // Start is called before the first frame update
    void Start()
    {
        playerFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Vector3 targetPosition is used as a postion that needs to be meet by the camera's postion
        Vector3 targetPosition = playerFollow.position + offset;


        // Vector3 smoothPosition is used to provide a smooth transition from the orginal camera postion to the target postion
        // Lerp function linearly interpolates between two points(First two parameters): 
        // The first two parameters (a,b) creates a range. My range is [transform.position to targetPosition]
        // The last paramter ranges from [0 to 1] and acts as 
        // a percentage that is used to determine the value from the range of the two parameters: 

        Vector3 smoothPosition = Vector3.Lerp(transform.position,targetPosition,smoothFactor * Time.fixedDeltaTime);


        //Sets the current camera position with an updated position(smoothPosition)
        transform.position = smoothPosition;

        
        //if(playerFollow.position.x > endBackgroundPosition){
        //    temp.x = 
        //    transform.position = temp;
        //}
       
    }
}
