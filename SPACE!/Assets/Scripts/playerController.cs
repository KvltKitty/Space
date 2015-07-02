using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	Vector3 viewportPosition;
	Vector3 amountToMove;
	Camera _camera;
	BoxCollider _collider;
	public playerStats _stats;
	// Use this for initialization
	void Start () {
		_camera = Camera.main;
		amountToMove = Vector3.zero;
		_stats = new playerStats();
		_collider = transform.GetComponent<BoxCollider>();
	}
	


	public void Move(controllerState state){
		amountToMove = Vector3.zero;
		viewportPosition = _camera.WorldToViewportPoint(transform.position);
		if(state.horizontal > 0.0f) //if going right
		{
			if(viewportPosition.x + (state.horizontal * _stats.speed) < 1.0f)
			{
				amountToMove.x = (state.horizontal * _stats.speed);
			}
		}
		else if(state.horizontal < 0.0f) //if going left
		{
			if(viewportPosition.x  + (state.horizontal * _stats.speed) > 0.0f)
			{
				amountToMove.x = (state.horizontal * _stats.speed);
			}
		}
		if(state.vertical > 0.0f) //if going up
		{
			if(viewportPosition.y  + (state.vertical * _stats.speed) < 1.0f)
			{
				amountToMove.y = (state.vertical * _stats.speed);
			}
		}
		else if(state.vertical < 0.0f) //if going down
		{
			if(viewportPosition.y  + (state.vertical * _stats.speed) > 0.0f)
			{
				amountToMove.y = (state.vertical * _stats.speed);
			}
		}

		transform.Translate (amountToMove);
	}

	public void Fire(controllerState state){

	}


}
