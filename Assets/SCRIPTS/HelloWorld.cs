using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HelloWorld : MonoBehaviour {

	public List<string> l = new List<string>();

	// Use this for initialization
	void Start () {
		print(l[0] + " " + l[1]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}