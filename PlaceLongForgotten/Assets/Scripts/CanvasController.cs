using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    public float fadeSpeed;
    public float startingAlpha;
    public bool activeAtStart;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<CanvasGroup>().alpha = startingAlpha;
        gameObject.SetActive(activeAtStart);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void FadeIn () {

        gameObject.SetActive(true);

        bool check = false;

        while (check == false)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(gameObject.GetComponent<CanvasGroup>().alpha, 1.0f, fadeSpeed);

            if (gameObject.GetComponent<CanvasGroup>().alpha > 0.95f)
            {
                check = true;
            }
        }
    }

    public void FadeOut () {

        bool check = false;

        while (check == false)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(gameObject.GetComponent<CanvasGroup>().alpha, 0.0f, fadeSpeed);

            if (gameObject.GetComponent<CanvasGroup>().alpha < 0.05f)
            {
                check = true;
            }
        }

        gameObject.SetActive(false);
    }
}