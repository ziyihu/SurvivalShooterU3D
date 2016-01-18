using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public float smoothing = 3;
	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPos = player.position + new Vector3 (0, 6, -6);
		transform.position = Vector3.Lerp(transform.position,targetPos,smoothing*Time.deltaTime);
	}
}
