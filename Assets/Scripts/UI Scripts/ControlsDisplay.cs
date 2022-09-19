using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject moveText;
    [SerializeField]
    private GameObject jumpText;

    public float waitTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        moveText.SetActive(true);
        jumpText.SetActive(true);
        StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
	{
        yield return new WaitForSeconds(waitTime);
        moveText.SetActive(false);
        jumpText.SetActive(false);
    }

}
