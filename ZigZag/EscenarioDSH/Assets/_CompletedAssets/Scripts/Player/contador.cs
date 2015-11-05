using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class contador : MonoBehaviour {
	static int icontador = 0;
	Text text;
	// Use this for initialization
	void Start () {
		icontador++;
	}
	
	// Update is called once per frame
	void Update () {
		text = GetComponent <Text> ();
		text.text = "Contador " + icontador.ToString ();
	}
}