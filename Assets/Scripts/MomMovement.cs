using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomMovement : MonoBehaviour
{
    
    public float speedAuto=0;
    [SerializeField]private AudioSource Amy;

    public void PlayAmyAudio()
    {
        Amy.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speedAuto;
    }
}
