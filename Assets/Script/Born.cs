using UnityEngine;
using System.Collections;

public class Born : MonoBehaviour {

	public GameObject enemyPrefab;
	public float bornTime = 3;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("ACC", 0.3f, 1);
	}

	void ACC(){
		bornTime -= 0.05f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= bornTime) {
			timer -= bornTime;
			BornEnemy();
		}
	}

	void BornEnemy(){
		GameObject.Instantiate (enemyPrefab, transform.position, transform.rotation);
	}
}
