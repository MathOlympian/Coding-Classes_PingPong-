using UnityEngine;
using System.Collections;

public class Revision : MonoBehaviour {

	public GameObject [] game_Objects;
	string [] tobePopulated;

	// Use this for initialization
	void Start () 
	{
		float sum = 0;
		for(int z = 0; z < game_Objects.Length; z++)
		{
			Vector3 pos;
			pos = game_Objects [z].transform.position;
			sum = sum + 5;
			pos.z = pos.z + sum;
			game_Objects [z].transform.position = pos;

			if (z % 2 == 0) 
			{
				pos.y = pos.y + 2;
				game_Objects [z].transform.position = pos;
				game_Objects [z].GetComponent<Renderer> ().material.color = Color.red;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
