using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class CharacterFmod : MonoBehaviour


{
    public vThirdPersonInput tpInput;
    enum State {OnSnow,OnSnowWood,OnWoodWood};
    State state = State.OnSnow;
    [FMODUnity.EventRef] public string RunStepEvent;
    //FMOD.Studio.EventInstance RunInstance;
    [FMODUnity.EventRef] public string WoodStepEvent;
    [FMODUnity.EventRef] public string WalkEvent;
    [FMODUnity.EventRef] public string JumpEvent;
     [FMODUnity.EventRef] public string LandingSnowEvent;
     [FMODUnity.EventRef] public string LandingWoodEvent;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
    tpInput = GetComponent<vThirdPersonInput>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RunStep()
    {
         if(state == State.OnSnow)
         {
        FMODUnity.RuntimeManager.PlayOneShotAttached(RunStepEvent, gameObject);
        Debug.Log("На снегу");
         }
         else if (state == State.OnSnowWood)
         {
           FMODUnity.RuntimeManager.PlayOneShotAttached(RunStepEvent, gameObject);
           FMODUnity.RuntimeManager.PlayOneShotAttached(WoodStepEvent, gameObject); 
            Debug.Log("По дереву"); 
         }
         else if (state == State.OnWoodWood)
         {
             FMODUnity.RuntimeManager.PlayOneShotAttached(WoodStepEvent, gameObject);
             Debug.Log("Идет по доскам"); 
         }
    }
    void WalkStep()
    {
        if(tpInput.cc.inputMagnitude > 0.1)
    {
         if (state == State.OnSnow)
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(WalkEvent, gameObject);
            Debug.Log("На снегу");
        }
        else if (state == State.OnWoodWood)
        {
             FMODUnity.RuntimeManager.PlayOneShotAttached(WoodStepEvent, gameObject);
             Debug.Log("Идет по доскам");
        }
        else if (state == State.OnSnowWood)
         {
           FMODUnity.RuntimeManager.PlayOneShotAttached(WalkEvent, gameObject);
           FMODUnity.RuntimeManager.PlayOneShotAttached(WoodStepEvent, gameObject);
            Debug.Log("По дереву");
         }
     }
    }
    void Jumpp()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(JumpEvent, gameObject);
    }
    void Landing()
    {
          if (state == State.OnSnow)
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(LandingSnowEvent, gameObject);
            Debug.Log("Приземление На снегу");
        }
        else if (state == State.OnWoodWood)
        {
             FMODUnity.RuntimeManager.PlayOneShotAttached(LandingWoodEvent, gameObject);
             Debug.Log("Приземление Идет по доскам");
        }
        else if (state == State.OnSnowWood)
         {
           FMODUnity.RuntimeManager.PlayOneShotAttached(LandingSnowEvent, gameObject);
           FMODUnity.RuntimeManager.PlayOneShotAttached(LandingWoodEvent, gameObject);
            Debug.Log("Приземление По дереву");
         }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wood")
        {
         state = State.OnSnowWood;
        
        }
        else if (other.tag == "Untagged")
        {
            state = State.OnSnow;
            
        }
        else if ( other.tag == "WoodWood")
        {
            state = State.OnWoodWood;
            
        }
        
    }
     void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wood")
        {
         state = State.OnSnowWood;
         //Debug.Log("По дереву");
        }
        else if (other.tag == "Untagged")
        {
            state = State.OnSnow;
            //Debug.Log("На снегу");
        }
        else if(other.tag == "WoodWood")
        {
            state = State.OnWoodWood;
        }
    }
         void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wood")
        {
         state = State.OnSnow;
         Debug.Log("На снегу");
        }
         else if(other.tag == "WoodWood")
        {
            state = State.OnSnow;
            
        }
    }
    
}
