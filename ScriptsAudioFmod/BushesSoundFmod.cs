using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushesSoundFmod : MonoBehaviour
{
    [SerializeField]
    [FMODUnity.EventRef] string BushSoundEvent;
    FMOD.Studio.EventInstance BushSoundInstance;
    // Start is called before the first frame update
    void Start()
    {
         
        
       

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            BushSoundInstance = FMODUnity.RuntimeManager.CreateInstance(BushSoundEvent);
             BushSoundInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            
            BushSoundInstance.start();
            BushSoundInstance.release();
           
            Debug.Log("Задел куст");
        }
    }
}