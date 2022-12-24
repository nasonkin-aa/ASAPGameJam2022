using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraineTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;
    void Start()
    {
        GetComponentInParent<WorldScroller>().Add(transform.gameObject, tilePosition);
    }

}
