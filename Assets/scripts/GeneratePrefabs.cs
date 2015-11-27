using UnityEngine;
using System.Collections;
using SocketIO;

public class GeneratePrefabs : MonoBehaviour {

	public Transform first_note;

	private SocketIOComponent socket;

	void Start () {
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("message", TestMessage);
	}

	void Update () {

	}

	public void TestMessage(SocketIOEvent e)
	{
		Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));

		float x = Random.Range (-4f, 2f);
		float y = Random.Range (-3f, 3f);

		Instantiate(first_note, new Vector3(x, y, 0), Quaternion.identity);
	}


}
