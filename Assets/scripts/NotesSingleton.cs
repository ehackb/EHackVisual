using UnityEngine;
using System.Collections;

public class NotesSingleton: MonoBehaviour
{
	
	protected static NotesSingleton Instance{ get; private set; }
	private static update_note[] notes= new update_note[4];

	void Awake()
	{
		Instance = this;
		notes [0] = null;
	}

	public static update_note[] getNotes()
	{
		return notes;
	}
}


