using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour {
    // Start is called before the first frame update
    public Animator[] mBackgrounds;
    void Start()
    {
        FlowControl(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlowControl (float speed) {
        foreach(Animator bg in mBackgrounds)
            bg.speed = speed;
    }
}
