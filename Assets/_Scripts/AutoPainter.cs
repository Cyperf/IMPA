using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class AutoPainter : MonoBehaviour
{
    [SerializeField]
    Tilemap tileMap;

    [SerializeField]
    List<TileBase> tileBase;

    [SerializeField]
    int sizeX = 10, sizeY = 10;

    [SerializeField]
    public Camera cam;

    private Vector2Int currentPosition;

    public void Draw()
    {
        AdjustCam();
        
        tileMap.ClearAllTiles();
        int x = 0;
        int y = 0;
        currentPosition.Set(x, y);
        for (int i = 0; i < sizeX; i++)
        {
            PaintTiles(currentPosition);
            for (int o = 0; o < sizeY; o++)
            {
                y++;
                currentPosition.Set(x, y);
                PaintTiles(currentPosition);
            }
            y = 0;
            x++;
            currentPosition.Set(x, y);
        }
    }

    private void AdjustCam()
    {
        cam.orthographicSize = (sizeX + sizeY) / 3;
        cam.transform.position = new Vector3(sizeX / 2, sizeY / 2,-10);
    }

    public void PaintTiles(Vector2Int position)
    {
        var tilePosition = tileMap.WorldToCell((Vector3Int)position);
        TileBase color = tileBase[UnityEngine.Random.Range(0, tileBase.Count)];
        tileMap.SetTile(tilePosition, color);
    }

    private void ChangeColor()
    {
        
    }
}
