using UnityEngine;
using System.Collections;

public class CeuNoite : MonoBehaviour {

	public Material ceuNoite;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RenderSettings.skybox=ceuNoite;
		
	}
}