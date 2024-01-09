using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTests : MonoBehaviour
{
    public GameObject ChessTileVisualWhite;
    public GameObject ChessTileVisualBlack;

    private List<GameObject> _tiles = new List<GameObject>();
    private int _boardSize = 8;

    void Start()
    {
        BuildChessBoard();
    }

    // une fonction qui va creer le plateau de jeu en creant le prefab case par case grace a un Instantiate
    private void BuildChessBoard()
    {
        for (int col = 0; col < _boardSize; col++)
        {
            for (int lig = 0; lig < _boardSize; lig++)
            {
                GameObject tile;

                if (col % 2 == 0)
                {
                    if (lig % 2 == 0)
                    {
                        tile = Instantiate(ChessTileVisualBlack, new Vector3(col, 0, lig), Quaternion.identity);
                    }
                    else
                    {
                        tile = Instantiate(ChessTileVisualWhite, new Vector3(col, 0, lig), Quaternion.identity);
                    }
                }
                else
                {
                    if (lig % 2 == 0)
                    {
                        tile = Instantiate(ChessTileVisualWhite, new Vector3(col, 0, lig), Quaternion.identity);
                    }
                    else
                    {
                        tile = Instantiate(ChessTileVisualBlack, new Vector3(col, 0, lig), Quaternion.identity);
                    }
                }

                // ajoute la tuile nouvellement créee dans une liste
                _tiles.Add(tile);
            }
        }
    }
}
