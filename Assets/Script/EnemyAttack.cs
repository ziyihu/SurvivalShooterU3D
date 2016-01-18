using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float attack = 5;
	public float attackTime = 1;
	private float timer = 1;
	private EnemyHealth health;

	void Start(){
		timer = attackTime;
		health = this.GetComponent<EnemyHealth> ();
	}

	public void OnTriggerStay(Collider col){
		if(col.tag == "Player" && health.hp > 0){
			timer += Time.deltaTime;
			if (timer >= attackTime) {
				timer -= attackTime;
				col.GetComponent<PlayerHealth>().TakeDamage(attack);
			}
		}
	}
}
