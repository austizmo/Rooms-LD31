using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour 
{
	private int roomsAcross;
	private int roomsDown;

	public float roomOffsetX = 0.15f;
	public float roomOffsetY = -0.15f;

	void Start () {
		Vector3 topRight 	= gameObject.GetComponentInChildren<Camera>().ViewportToWorldPoint(new Vector3(1, 1, 0));
		Vector3 topLeft 	= gameObject.GetComponentInChildren<Camera>().ViewportToWorldPoint(new Vector3(0, 1, 0));

		GameObject room 	= GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/RoomBase")) as GameObject;
		Vector3 pos 		= new Vector3(topLeft.x + roomOffsetX, topLeft.y + roomOffsetY, 0);

		room.transform.position = pos;

		float roomWidth 	= room.renderer.bounds.size.x;
		float roomHeight 	= room.renderer.bounds.size.y;

		roomsAcross = (int)Mathf.Round(topRight.x / roomWidth*1.8f);
		roomsDown 	= (int)Mathf.Round(topRight.y / roomHeight*1.5f);
		for (int i = 0; i < roomsAcross; i++) {
			for (int j = 0; j < roomsDown; j++) {
				if(i == 0 && j == 0) continue;

				room 	= GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/RoomBase")) as GameObject;
				pos 	= new Vector3(topLeft.x + roomOffsetX + i*roomWidth, topLeft.y + roomOffsetY - j*roomHeight, 0);

				room.transform.position = pos;
			}
		}
	}

	public static Sprite GetSpriteForType(RoomTypes type) {
		return Resources.Load ("Sprites/RoomSprite") as Sprite;
	}
}
