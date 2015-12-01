using UnityEngine;
using System.Collections;
using SocketIO;

public class GeneratePrefabs : MonoBehaviour {

	public Transform first_note;
	public Transform second_note;
	public Transform third_note;
	
	private SocketIOComponent socket;
	private float nextActionTime = 0.0f;
	private float period = 4f;

	void Start () {
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("message", TestMessage);
	}

	public void TestMessage(SocketIOEvent e)
	{
		Debug.Log (string.Format ("[name: {0}, data: {1}]", e.name, e.data));

		switch(e.data.GetField("message").str)
		{
			case "first": generate(first_note); break;
			case "second": generate(second_note);break;
			case "third": generate(third_note);break;
		}
	}

	public void generate(Transform which)
	{
		if (Time.time > nextActionTime) { 
			float x = Random.Range (-4f, 2f);
			float y = Random.Range (-3f, 3f);
			
			Instantiate (which, new Vector3 (x, y, 0), Quaternion.identity);
			nextActionTime = Time.time + period;
		}
	}
}
