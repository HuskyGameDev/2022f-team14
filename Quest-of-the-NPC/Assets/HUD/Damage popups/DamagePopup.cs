using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private const float DISAPPEAR_TIMER_MAX = 0.3f;
    private static int sortingOrder;
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;
    
    public static DamagePopup Create(Vector3 position, int damageAmount, bool isCriticalHit, bool isHeal)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, Vector3.zero, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCriticalHit, isHeal);

        return damagePopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damageAmount, bool isCriticalHit, bool isHeal)
    {
        if (isHeal)
        {
            textMesh.SetText("+" + damageAmount);
        }
        else
        {
            textMesh.SetText(damageAmount.ToString());
        }
        

        if (isCriticalHit)
        {
            textMesh.fontSize = 6;
            textColor = Color.red;
        }
        else if (isHeal)
        {
            textMesh.fontSize = 5;
            textColor = Color.green;
        }
        else
        {
            textMesh.fontSize = 5;
            textColor = Color.yellow;
        }

        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        moveVector = new Vector3(0.7f, 1) * 6f;
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            // First half of popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            // Second half of popup lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }
        
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // Start disappearing
            float disappearSpeed = 3;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
