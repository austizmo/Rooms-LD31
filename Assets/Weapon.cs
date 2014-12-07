using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		Debug.Log (collider);
		Enemy enemy = collider.gameObject.GetComponent<Enemy> ();
		if (enemy != null) {
			enemy.health -= 1;
		}
	}
}
