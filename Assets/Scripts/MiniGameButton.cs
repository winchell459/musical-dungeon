using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameButton : MonoBehaviour
{
    public string MiniGameSceneName;
    float aspect;

    private void Awake()
    {
        aspect = transform.lossyScale.x / transform.lossyScale.y;

    }

    private void OnMouseUp()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MiniGameSceneName);
    }

    public void SetupButton(float screenWidth)
    {
        print("Button Setup");
        Vector3 parentScale = transform.parent.localScale;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.x / (aspect * parentScale.y), transform.localScale.z);
    }
}
