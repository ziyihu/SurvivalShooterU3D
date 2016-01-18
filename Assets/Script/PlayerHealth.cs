using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float hp = 100;
	private Animator anim;
	private PlayerMove playerMove;
	private PlayerShoot playerShoot;

	public float smoothing = 1;

	private SkinnedMeshRenderer bodyRenderer;

	void Awake(){
		anim = this.GetComponent<Animator> ();
		playerMove = this.GetComponent<PlayerMove> ();
		playerShoot = this.GetComponentInChildren<PlayerShoot> ();
		this.bodyRenderer = transform.Find ("Player").renderer as SkinnedMeshRenderer;
	}

	void Update(){
		bodyRenderer.material.color = Color.Lerp (bodyRenderer.material.color, Color.white, smoothing * Time.deltaTime);
	}

	public void TakeDamage(float damage){
		if(hp <= 0) return;
		this.hp -= damage;
		bodyRenderer.material.color = Color.red;
		if(this.hp <= 0){
			anim.SetBool("Dead",true);
			Dead();
		}
	}

	void Dead(){
		this.playerMove.enabled = false;
		this.playerShoot.enabled = false;
	}
}
