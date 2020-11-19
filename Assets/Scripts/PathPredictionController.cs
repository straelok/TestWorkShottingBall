using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPredictionController : MonoBehaviour
{
    public static PathPredictionController Instance;
    public GameObject player;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = player.transform.localScale.x;
        transform.localScale = newScale;
    }
}