using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTests : MonoBehaviour
{
    public GameObject ChessTileVisual;

    private List<GameObject> _tiles = new List<GameObject>();
    private int _boardSize = 1;
    private int _tileIndex = 0;
    private int _tileSelectedIndex = 0;

    void Start()
    {
        BuildChessBoard();
        UpdateColors();
        InvokeRepeating("UpdateSelectedColor", 0.5f, 0.5f);
    }

    private void BuildChessBoard()
    {
        for (int col = 0; col < _boardSize; col++)
        {
            for (int lig = 0; lig < _boardSize; lig++)
            {
                GameObject tile = Instantiate(ChessTileVisual, new Vector3(col, 0, lig), Quaternion.identity);
                _tiles.Add(tile);
            }
        }
    }

    private void ChooseColor(int pIndex, int pColIndex)
    {
        GameObject lTile = _tiles[pIndex];
        Renderer lRenderer = lTile.GetComponent<Renderer>();

        if (pColIndex % 2 == 0)
        {
            if (pIndex % 2 == 0)
            {
                lRenderer.material.color = Color.black;
            }
            else
            {
                lRenderer.material.color = Color.white;
            }
        }
        else
        {
            if (pIndex % 2 == 0)
            {
                lRenderer.material.color = Color.white;
            }
            else
            {
                lRenderer.material.color = Color.black;
            }
        }
    }

    void UpdateColors()
    {
        _tileIndex = 0;
        for (int col = 0; col < _boardSize; col++)
        {
            for (int lig = 0; lig < _boardSize; lig++)
            {
                ChooseColor(_tileIndex, col);
                _tileIndex++;
            }
        }

    }

    void UpdateSelectedColor()
    {
        // on remet toutes les cases en noir et blanc
        UpdateColors();

        // on met en jaune la case sélectionnée
        GameObject lTile = _tiles[_tileSelectedIndex];
        Renderer lRenderer = lTile.GetComponent<Renderer>();
        lRenderer.material.color = Color.yellow;

        // on passe à la case suivante
        _tileSelectedIndex = (_tileSelectedIndex +1) % (_boardSize* _boardSize);
    }
}
