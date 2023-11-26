using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float x, y;
    [SerializeField] private float speed;



    private void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * speed * Time.deltaTime, img.uvRect.size);
    }
}
