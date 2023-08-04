using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightEffect : MonoBehaviour
{
    [SerializeField] Light light;

    private void Start()
    {
        LeanTween.value(gameObject, 70, 75, 3).setOnUpdate((float value) => { light.spotAngle = value; }).setLoopPingPong(-1);
    }
}
