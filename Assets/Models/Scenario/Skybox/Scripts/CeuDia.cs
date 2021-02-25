using UnityEngine;
using System.Collections;

public class CeuDia : MonoBehaviour {

	public Material ceuDia;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RenderSettings.skybox=ceuDia;
		
	}
}