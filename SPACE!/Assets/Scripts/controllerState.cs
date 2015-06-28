using UnityEngine;
using System.Collections;

public class controllerState {
	public float horizontal, vertical;
	public bool attack1, attack2;
	// Use this for initialization
	void Start () {
		horizontal = vertical = 0.0f;
		attack1 = attack2 = false;
	}
	
	public void ResetAxis(){
		horizontal = vertical = 0.0f;
	}
	public void ResetAttack(){
		attack1 = attack2 = false;
	}
	
}
