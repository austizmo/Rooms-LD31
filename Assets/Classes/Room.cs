using UnityEngine;
using System.Collections;

public enum RoomTypes { Basic };

public class Room : MonoBehaviour {
	public RoomTypes type;
	
	// Use this for initialization
	void Start () {
		type = RoomTypes.Basic;
		//gameObject.GetComponent<SpriteRenderer>().sprite = RoomManager.GetSpriteForType (type);
	}
}
