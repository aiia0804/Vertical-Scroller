using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roater : MonoBehaviour
{
    [SerializeField] float roationSpeede = 5f;

    void Update()
    {
        transform.Rotate(0, 0, roationSpeede);
    }
}
