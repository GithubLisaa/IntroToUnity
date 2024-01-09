using UnityEngine;
using UnityEngine.EventSystems;

// 1/ ajouter un event system dans la scene si il n'y en a pas deja un
// 2/ ajouter un graphic raycaster sur la camera
// 3/ ajouter l'interface IpoinerClickHandler
// 4/ implementer la fonction OnPointerClick

public class TileClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Tile clicked!");
    }
}
