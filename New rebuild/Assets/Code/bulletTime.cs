using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTime : MonoBehaviour 
{ 
    public float lifeTime;
// Start is called before the first frame update
void Start()
{
    Invoke("DestroyProjectile", lifeTime);
}

// Update is called once per frame
void DestroyProjectile()
{
    Destroy(gameObject);
}
}
