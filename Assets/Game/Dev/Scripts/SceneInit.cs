using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInit : MonoBehaviour
{
    private void Awake()
    {
#if !UNITY_EDITOR
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
#endif
    }
}
