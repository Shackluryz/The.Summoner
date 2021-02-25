using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaNoiteAnimacao : MonoBehaviour
{
    public Color AmbienteCor;
    public float AmbienteIntensidade;
    public Color NevoeiroCor;
    public float NevoeiroIntensidade;

    private void OnTriggerStay() {
        RenderSettings.ambientLight = AmbienteCor;
        RenderSettings.ambientIntensity = AmbienteIntensidade;
        RenderSettings.fogColor = NevoeiroCor;
        RenderSettings.fogDensity = NevoeiroIntensidade;
        RenderSettings.fog = true;
    }
}
