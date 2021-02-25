using UnityEngine;
using System.Collections;

public class DiaNoiteAnimada : MonoBehaviour {

	public Color AmbienteCor;
	public float AmbienteItensidade;
	public Color NevoeiroCor;
	public float NevoeiroItensidade;

	void OnTriggerStay() {
		RenderSettings.ambientLight = AmbienteCor;
		RenderSettings.ambientIntensity = AmbienteItensidade;
		RenderSettings.fogColor = NevoeiroCor;
		RenderSettings.fogDensity = NevoeiroItensidade;
		RenderSettings.fog = true;
	}
}