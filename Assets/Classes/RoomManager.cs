using UnityEngine;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour 
{
	public float roomOffsetX = 0.15f;
	public float roomOffsetY = -0.15f;

	public Vector3 topRight;
	public Vector3 topLeft;

	List<GameObject> rooms;

	void Start () {
		rooms 		= new List<GameObject>();
		topRight 	= gameObject.GetComponentInChildren<Camera>().ViewportToWorldPoint(new Vector3(1, 1, 0));
		topLeft 	= gameObject.GetComponentInChildren<Camera>().ViewportToWorldPoint(new Vector3(0, 1, 0));

		CreateRooms ();
	}

	public void CreateRooms() {
		//create our firt room and set its position. we do this outside of the loop, 
		//because we need to get the bounds for the room object in order to calculate the total number of rooms needed.
		GameObject room 		= GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/RoomRDoor")) as GameObject;
		Vector3 pos 			= new Vector3(topLeft.x + roomOffsetX, topLeft.y + roomOffsetY, 0);
		room.transform.position = pos;
		room.GetComponent<Room> ().Revealed = true;
		rooms.Add (room);

		//setup the variables we need to generate the right number of rooms
		float roomWidth 	= room.renderer.bounds.size.x;
		float roomHeight 	= room.renderer.bounds.size.y;
		int roomsAcross 	= (int)Mathf.Round(topRight.x / roomWidth*1.8f);
		int roomsDown 		= (int)Mathf.Round(topRight.y / roomHeight*1.5f);

		for (int i = 0; i < roomsAcross; i++) {
			for (int j = 0; j < roomsDown; j++) {
				if(i == 0 && j == 0) continue; //we already built our first room above, skip this step of the loop

				//clone our room prefab and set its position
				room 	= GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/RoomLRDoor")) as GameObject;
				pos 	= new Vector3(topLeft.x + roomOffsetX + i*roomWidth, topLeft.y + roomOffsetY - j*roomHeight, 0);
				room.transform.position = pos;
				room.GetComponent<Room> ().Revealed = false;
				rooms.Add(room);
			}
		}
	}

	public static Sprite GetSpriteForType(RoomTypes type) {
		return Resources.Load ("Sprites/RoomSprite") as Sprite;
	}
}
