using UnityEngine;
using System.Collections;

public class handleInput : MonoBehaviour {
	controllerState _state;
	playerController _controller;
	// Use this for initialization
	void Start () {
		_state = new controllerState();
		_controller = this.gameObject.GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
		_state.horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
		_state.vertical = Input.GetAxisRaw ("Vertical") * Time.deltaTime;
		_controller.Move (_state);
		if(_state.attack1 || _state.attack2){
			_controller.Fire(_state);
		}
		_state.ResetAxis();
	}
}
