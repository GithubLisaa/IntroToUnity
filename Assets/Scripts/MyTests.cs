using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

                // si la colonne est paire
                if (col % 2 == 0)
                {
                    // si la ligne est paire
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
                    // sinon
                    // si la ligne est paire
                    if (lig % 2 == 0)
                    {
                        tile = Instantiate(ChessTileVisualWhite, new Vector3(col, 0, lig), Quaternion.identity);
                    }
                    else
                    {
                        tile = Instantiate(ChessTileVisualBlack, new Vector3(col, 0, lig), Quaternion.identity);
                    }
                }

                // ajoute la nouvelle tuile dans la liste
                _tiles.Add(tile);
            }
        }

        // ** Memo 1D <=> 2D **
        // index = lig * boardSize + col
        // lig = index / boardSize
        // col = index % boardSize
    }

    // selection via index
    private void SelectOneTile(int pTileIndex)
    {
        _tiles[pTileIndex].GetComponent<Renderer>().material.color = Color.yellow;
    }

    private void UnselectOneTile(int pTileIndex)
    {
        _tiles[pTileIndex].GetComponent<Renderer>().material.color = Color.clear;
    }

    // avec boucle for
    private void SelectAllTiles()
    {
        // TODO
    }

    // avec boucle foreach
    private void SelectAllTiles2()
    {
        // TODO
    }

    // avec boucle for
    private void UnselectAllTiles()
    {
        // TODO
    }

    private void SelectAllBlack()
    {
        // TODO
    }

    private void SelectAllWhite()
    {
        // TODO
    }

    private void SelectRandomTile()
    {
        int randomIndex = Random.Range(0, _tiles.Count); // renvoi un nombre aléatoire en 0 et _tiles.Count
        // TODO
    }

    private void SelectCol(int pColIndex)
    {
        // TODO
    }

    private void SelectLig(int pLigIndex)
    {
        // TODO
    }

    // selectionne le contour
    private void SelectBorders()
    {
        // TODO
    }

    // selectionne la diagonale de gauche a droite
    private void SelectDiagonal()
    {
        // TODO
    }

    // selectionne les 2 diagonales
    private void SelectX()
    {
        // TODO
    }

    // Select AOE en croix
    // 0 0 0 0 0 0 0 0
    // 0 0 0 x 0 0 0 0
    // 0 0 x i x 0 0 0
    // 0 0 0 x 0 0 0 0    
    // 0 0 0 0 0 0 0 0
    private void SelectAOECross(int pLigIndex, int pColIndex)
    {
        // TODO
    }

    // line, square, cone, circle :)


    // get neighbors
    private GameObject GetUpTile(int pTileIndex)
    {
        // TODO
        return null;
    }

    private GameObject GetDownTile(int pTileIndex)
    {
        // TODO
        return null;
    }

    private GameObject GetLeftTile(int pTileIndex)
    {
        // TODO
        return null;
    }

    private GameObject GetRightTile(int pTileIndex)
    {
        // TODO
        return null;
    }

    private List<GameObject> GetNeighbors(int pTileIndex, bool pDiagnals = false)
    {
        List<GameObject> lNeighbors = new List<GameObject>();
        if (pDiagnals)
        {

        }
        else
        {

        }

        // TODO
        return lNeighbors;
    }
}