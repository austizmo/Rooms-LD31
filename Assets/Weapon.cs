using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public int 		damage 			= 1;
	public float 	attackDuration 	= 0.1f;

	void OnTriggerEnter(Collider collider) {
		Enemy enemy = collider.gameObject.GetComponent<Enemy> ();
		if (enemy != null) {
			enemy.health -= damage;
		}
	}
}
