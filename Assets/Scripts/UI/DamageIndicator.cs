using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Image image;
    public float flashSpeed;
    private Coroutine coroutine;
    
    // Start is called before the first frame update
    private void Start()
    {
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash;
    }

    public void Flash()
    {
        //기존에 코르틴이 있다면 꺼줘야 하기 때문에.
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        image.enabled = true;
        image.color = new Color(1f, 105f / 255f, 105f / 255f);
        coroutine = StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while (a > 0.0f)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime;
            image.color = new Color(1f, 100f / 155f, 100f / 255f, a);
            yield return null;
        }
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
