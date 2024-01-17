using UnityEngine;

// ScriptableObject est une classe qui permet de créer des "data assets"
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public enum ERarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    // Variables publiques avec leurs valeurs par défaut
    public int ItemID = -1;
    public float ItemPrice = 0.0f; // Mettre un f à la fin pour les float
    public string ItemName = "Default ItemName"; // Mettre des guillemets pour les chaines de caractères alias strings
    public bool IsDestroyable = false;
    public ERarity Rarity = ERarity.Common; // ici on utilise l'enum défini plus haut pour définir la rareté de l'objet par défaut
    public Vector3 ItemPosition = new Vector3(0.0f, 0.0f, 0.0f); // décrit la position par defaut l'objet dans la scène (ici au centre du monde)
    public Sprite ItemSprite; // Un sprite 2D pour l'icone de l'objet
    public int ItemScore = 0;
    //public Mesh ItemMeshFilter; // Un mesh 3D pour l'objet
}
