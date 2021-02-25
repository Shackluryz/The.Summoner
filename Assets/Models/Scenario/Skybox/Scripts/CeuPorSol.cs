using UnityEngine;
using System.Collections;

public class CeuPorSol : MonoBehaviour {

	public Material ceuPorSol;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RenderSettings.skybox=ceuPorSol;
		
	}
}