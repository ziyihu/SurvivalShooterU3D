using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float hp = 100;
	private Animator anim;

	private NavMeshAgent agent;
	private EnemyMove enemyMove;
	public AudioClip deadClip;

	private ParticleSystem particleSystem;
	private EnemyAttack enemyAttack;

	void Awake(){
		anim = this.GetComponent<Animator> ();
		agent = this.GetComponent<NavMeshAgent> ();
		enemyMove = this.GetComponent<EnemyMove> ();
		particleSystem = this.GetComponentInChildren<ParticleSystem> ();
	//	enemyAttack = this.GetComponent<EnemyAttack> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.hp <= 0){
			transform.Translate(Vector3.down*Time.deltaTime*0.5f);
			if(transform.position.y <= -3){
				Destroy(this.gameObject);
			}
		}
	}

	public void TakeDamage(float damage,Vector3 hitPoint){
		if(this.hp <= 0) return;
		audio.Play ();
		particleSystem.transform.position = hitPoint;
		particleSystem.Play ();
		this.hp -= damage;
		if (this.hp <= 0) {
			Dead();
		}
	}

	void Dead(){
		anim.SetBool ("Dead", true);
		agent.enabled = false;
		enemyMove.enabled = false;
	//	enemyAttack.enabled = false;
		AudioSource.PlayClipAtPoint(deadClip,transform.position,1f);
	}
}
