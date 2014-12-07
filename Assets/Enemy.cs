using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int health = 1;
	public int xpDrop = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy(this.gameObject);
		}
	}
}
