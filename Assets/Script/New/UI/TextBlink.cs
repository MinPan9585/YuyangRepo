using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    public Text text;
    public float blinkSpeed = 1f;
    public float minAlpha = 0.2f;
    public float maxAlpha = 1f;

    private bool isFadingOut = true;
    private void OnEnable()
    {
        StartCoroutine(BlinkText());
        
    }
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    IEnumerator BlinkText()
    {
        Color originalColor = text.color;

        while (true)
        {
            float alpha = text.color.a;

            if (isFadingOut)
            {
                alpha -= Time.deltaTime * blinkSpeed;
                if (alpha <= minAlpha)
                {
                    alpha = minAlpha;
                    isFadingOut = false;  
                }
            }
            else
            {
                alpha += Time.deltaTime * blinkSpeed;
                if (alpha >= maxAlpha)
                {
                    alpha = maxAlpha;
                    isFadingOut = true;
                }
            }

            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null; 
        }
    }
}
