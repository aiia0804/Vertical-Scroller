using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollper : MonoBehaviour
{
    [SerializeField] float backgroundScrollperSpeed = 0.5f;
    Material myMaterial;
    Vector2 offset;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundScrollperSpeed);
    }

    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
