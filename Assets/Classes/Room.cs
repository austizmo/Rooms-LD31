using UnityEngine;
using System.Collections;

public enum RoomTypes { Basic };

public class Room : MonoBehaviour {
	public RoomTypes type;
	private bool revealed = false;

	// Use this for initialization
	void Start () {
		type = RoomTypes.Basic;
		if (!revealed) {
			gameObject.renderer.enabled = false;
		}
		//gameObject.GetComponent<SpriteRenderer>().sprite = RoomManager.GetSpriteForType (type);
	}

	public bool Revealed {
		get { return revealed; }
		set {
			revealed = value;
			gameObject.renderer.enabled = value;
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (!Revealed && collider.gameObject.GetComponent<Player>() != null) {
			Revealed = true;
			SpawnEnemies ();
		}
	}

	private void SpawnEnemies() {
		int num = Random.Range (0, 5);
		for (int i = 0; i <= num; i++) {
			GameObject enemy = Instantiate(Resources.Load("Prefabs/Enemy")) as GameObject;
			enemy.transform.position = transform.position;
			enemy.transform.Translate(new Vector3(0,0,-0.5f));
		}
	}
}
