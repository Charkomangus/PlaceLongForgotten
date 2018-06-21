using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class BOMB : MonoBehaviour {



	// Use this for initialization
	void Start () {
		FindObjectOfType<PurchaseManager>().ReturnPlayerControl();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
