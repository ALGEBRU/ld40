using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public void ajustHealthBar(float health)
    {
        if (health < 0.0f)
        {
            transform.GetChild(1).transform.GetComponent<RectTransform>().localScale = new Vector2(0.0f, transform.GetChild(1).transform.GetComponent<RectTransform>().localScale.y);
        } else
            transform.GetChild(1).transform.GetComponent<RectTransform>().localScale = new Vector2(health, transform.GetChild(1).transform.GetComponent<RectTransform>().localScale.y);

    }
}
