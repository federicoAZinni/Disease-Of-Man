using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBroken : MonoBehaviour
{
    [SerializeField] float minIntervals;
    [SerializeField] float maxIntervals;

    [SerializeField] Light lightBroken;
    void Start()
    {
        LeanTween.delayedCall(Random.Range(2, 6), () =>
        {
            StartCoroutine(TurnOffOnLight());
            Start();
        });

    }

    IEnumerator TurnOffOnLight()
    {
        for (int i = 0; i < Random.Range(1,5); i++)
        {
            lightBroken.enabled = false;
            yield return new WaitForSeconds(GetRandomNumberToWait());
            lightBroken.enabled = true;
            yield return new WaitForSeconds(GetRandomNumberToWait());
        }
        
    }
    float GetRandomNumberToWait()
    {
        return Random.Range(minIntervals, maxIntervals);
    }
}
