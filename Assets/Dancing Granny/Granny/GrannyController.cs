using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyController : MonoBehaviour {

    public GameObject Granny;
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = Granny.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeAnim(string trigger)
    {
        anim.SetTrigger(trigger);
    }
}
