using UnityEngine;
using System.Collections;
using SocketIO;

public class update_note : MonoBehaviour {

	private SocketIOComponent socket;
	private float pan;
	private float pitch;
	private float nextActionTime = 0.0f;
	private float period = 0.3f;

	void Start () 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		pan = transform.position.x;
		pitch = transform.position.y;

		updatePosition("created");
	}
	
	void FixedUpdate () 
	{
		if (Time.time > nextActionTime ) 
		{ 
			nextActionTime = Time.time + period; 
			updatePosition("moving");
		} 
	}

	void OnTriggerExit(Collider other)
	{
		updatePosition("gone");
	}

	private void updatePosition(string what)
	{
		pan = Mathf.RoundToInt((transform.position.x + 6.5f) * 9.14f);
		pitch = Mathf.RoundToInt((transform.position.y + 4) * 14.2f);
		
		JSONObject jsonObj = new JSONObject();
		jsonObj.AddField ("pan", pan);
		jsonObj.AddField ("pitch", pitch);
		jsonObj.AddField ("name", this.name);
		jsonObj.AddField ("lifecycle", what);
		
		socket.Emit ("note_move", jsonObj);

		Debug.Log (string.Format ("{0}[pan: {1}, pitch: {2}, {3}]",this.name , pan, pitch, what));
	}
}
