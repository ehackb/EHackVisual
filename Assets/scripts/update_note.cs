using UnityEngine;
using System.Collections;
using SocketIO;

public class update_note : MonoBehaviour {

	public float timeoutDestructor;

	private Rigidbody body;
	private SocketIOComponent socket;

	void Start () {
		timeoutDestructor = 200;

		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		body = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		float x = transform.position.x + Random.Range(0.01f ,0.05f);
		float y = transform.position.y + Random.Range(-0.02f ,0.02f);
		float z = transform.position.z;

		Vector3 moveTo = new Vector3 (x, y, z);

		body.MovePosition(moveTo);

		JSONObject jsonObj = new JSONObject();
		jsonObj.AddField ("scale", x);
		jsonObj.AddField ("pitch", y);
		jsonObj.AddField ("name", this.name);
		socket.Emit ("note_move", jsonObj);
	}
}
