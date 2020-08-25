using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour {

	Rigidbody2D rb;
	GameObject target;
	float moveSpeed;
	Vector3 directionToTarget;
	public GameObject explosion;
	int count;
	public int viruskillCount = 0;



	// Use this for initialization
	void Start () {
		count = Random.Range(1, 2);

		target = GameObject.FindWithTag("Citizen");



		rb = GetComponent<Rigidbody2D> ();
		moveSpeed = Random.Range (1f, 4f);
	}
	
	// Update is called once per frame
	void Update () {

	



		MoveMonster ();
	}



	void OnTriggerEnter2D (Collider2D col)
	{
		switch (col.gameObject.tag)
		{

			case "Citizen":
				MonstersSpawnerControl.spawnAllowed = false;
				Instantiate(explosion, col.gameObject.transform.position, Quaternion.identity);
				Destroy(col.gameObject);
				target = null;
				break;

			case "Bullet":
				Instantiate(explosion, transform.position, Quaternion.identity);
				
				Destroy(col.gameObject);
				Destroy(gameObject);
				break;

			case "healball":

				viruskillCount +=1;
				Destroy(col.gameObject);
				Destroy(gameObject);
				break;
		}
	}

	void MoveMonster ()
	{

		if (target != null) {
			directionToTarget = (target.transform.position - transform.position).normalized;
			rb.velocity = new Vector2 (directionToTarget.x * moveSpeed,
										directionToTarget.y * moveSpeed);
		}
		else
			rb.velocity = Vector3.zero;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("Citizen1"))
		{
			SoundManagerScript.PlayerSound("damage");
			Destroy(gameObject);
		}
	}

}
