using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public float startZ;
    public float endZ;
    public float moveSpeed;
    public float targetZ;
    public bool moving;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
        targetZ = startZ;
    }

    public void Move(float distance)
    {
        targetZ = transform.position.z - distance;
    }

    private void Update()
    {
        moving = transform.position.z > targetZ; 
        if (moving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                new Vector3(transform.position.x, transform.position.y, targetZ), 
                moveSpeed * Time.deltaTime);
        }
    }

    public bool Moving()
    {
        return transform.position.z > targetZ;
    }
}
