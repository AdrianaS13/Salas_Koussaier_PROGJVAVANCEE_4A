using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomMovement : MonoBehaviour
{
    
    public float speedAuto=0;
    
    public void GoBack()
    {
        transform.position = new Vector3(2.12586431e-18f,-3.59601984e-08f,-4.8265152f);
        //transform.Translate(Vector3.back * 60 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speedAuto;
    }
}
