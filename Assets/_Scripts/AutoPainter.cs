using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
public class AutoPainter : MonoBehaviour
{
    [SerializeField]
    Tilemap tileMap;

    [SerializeField]
    List<TileBase> tileBase;

    [SerializeField]
    TMP_InputField sizeX, sizeY;

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
        for (int i = 0; i < int.Parse(sizeX.text); i++)
        {
            PaintTiles(currentPosition);
            for (int o = 0; o < int.Parse(sizeY.text); o++)
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
        cam.orthographicSize = (int.Parse(sizeX.text) + int.Parse(sizeY.text)) / 3;
        cam.transform.position = new Vector3(int.Parse(sizeX.text) / 2, int.Parse(sizeY.text) / 2,-10);
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
