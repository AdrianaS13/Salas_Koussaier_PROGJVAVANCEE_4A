using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomMovement : MonoBehaviour
{
    
    public float speedAuto;


    public void SetZ(float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y ,z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speedAuto;
    }
}
