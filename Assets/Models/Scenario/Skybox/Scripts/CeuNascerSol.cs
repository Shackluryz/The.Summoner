using UnityEngine;
using System.Collections;

public class CeuNascerSol : MonoBehaviour {

	public Material ceuNascerSol;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RenderSettings.skybox=ceuNascerSol;
		
	}
}