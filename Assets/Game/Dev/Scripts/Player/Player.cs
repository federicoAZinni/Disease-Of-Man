using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] Transform hand;
    [SerializeField] GameObject flashLight;
  
    void Update()
    {
        FlashLightTurnOnOff();
    }


    void FlashLightTurnOnOff()
    { 
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(flashLight.activeSelf)
            {
                LeanTween.moveLocalY(hand.gameObject, -1, 0.2f).setOnComplete(()=> { flashLight.SetActive(false); });
            }
            else
            {
                flashLight.SetActive(true);
                LeanTween.moveLocalY(hand.gameObject, -0.5f, 0.2f);
            }
        }
    }
}
