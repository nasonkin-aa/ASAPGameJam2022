using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    [SerializeField]
    private Transform character;
    [SerializeField]
    public float tileSize = 20f;
    public Vector2Int currentTilePosition;
    [SerializeField]
    public Vector2Int playerTilePosition = new Vector2Int(0, 0);
    Vector2Int onTileGridPosition;
    private GameObject[,] terraineTiles;

    [SerializeField] 
    private int terraineTileHorizontalCount;
    [SerializeField] 
    private int terraineTileVerticalCount;

    [SerializeField]
    private int fieldOfVisionHeight = 3;
    [SerializeField]
    private int fieldOfVisionWidth = 3;

    private void Awake()
    {
        terraineTiles = 
            new GameObject[terraineTileHorizontalCount, terraineTileVerticalCount];
    }

    private void Update()
    {
        playerTilePosition.x = (int)(character.position.x / tileSize);
        playerTilePosition.y = (int)(character.position.y / tileSize);

        playerTilePosition.x -= character.position.x <= 0 ? 1 : 0;
        playerTilePosition.y -= character.position.y <= 0 ? 1 : 0;

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPosition.x = CalculatePositionOnAxis(onTileGridPosition.x, true);
            onTileGridPosition.y = CalculatePositionOnAxis(onTileGridPosition.y, false);
            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for (int pov_x = -(fieldOfVisionWidth / 2);
            pov_x <= fieldOfVisionWidth / 2; pov_x++)
        {
            for (int pov_y = -(fieldOfVisionHeight / 2);
                pov_y <= fieldOfVisionHeight / 2; pov_y++)
            {
                int tileToUpdate_x = 
                    CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y =
                    CalculatePositionOnAxis(playerTilePosition.y + pov_y, false);

                GameObject tile = terraineTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(
                    playerTilePosition.x + pov_x,
                    playerTilePosition.y + pov_y);
            }
        }
    }

    private Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize);
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue %= terraineTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = 
                    terraineTileHorizontalCount - 1 + currentValue % 
                    terraineTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue %= terraineTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue =
                    terraineTileVerticalCount - 1 + currentValue %
                    terraineTileVerticalCount;
            }
        }
        return (int)currentValue;
    }

    internal void Add(GameObject tile, Vector2Int tilePosition)
    {

        terraineTiles[tilePosition.x, tilePosition.y] = tile;
    }

}
