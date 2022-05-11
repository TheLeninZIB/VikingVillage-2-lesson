using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class WalkOnSnowFmod : MonoBehaviour
{
    [FMODUnity.EventRef] public string RunStepEvent;
    public vThirdPersonInput tpInput;
    // Start is called before the first frame update
    void Start()
    {
        tpInput = GetComponent<vThirdPersonInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void WalkStep()
    {
        if(tpInput.cc.inputMagnitude > 0.1)
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(RunStepEvent, gameObject);
        } 
       
    }
}
