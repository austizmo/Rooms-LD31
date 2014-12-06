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
		Revealed = true;
	}
}
