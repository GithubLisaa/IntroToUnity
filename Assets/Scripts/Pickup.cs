using Cinemachine;
using UnityEngine;

[SelectionBase]
public class Pickup : MonoBehaviour
{
    public ItemData ItemData;
    public ParticleSystem ParticleSystem;
    public float RotationSpeed = 20.0f;
    public GameObject ItemPrefb;
    public CinemachineVirtualCamera VirtualCamera;
    private Hud _hud;

    // Start is called before the first frame update
    void Start()
    {
        // place l'objet en utilisant la data de l'objet
        //transform.position = ItemData.ItemPosition;

        //Mesh myMesh = Instantiate(ItemData.ItemMeshFilter);
        //GetComponent<MeshFilter>().sharedMesh = myMesh;        

        //_hud = GameObject.FindGameObjectWithTag("Hud")?.GetComponent<Hud>();
        _hud = FindObjectOfType<Hud>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemPrefb.transform.RotateAround(transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " Game ObjectClicked!" + "ID" + ItemData.ItemID + " price" + ItemData.ItemPrice);

        if (ItemData.IsDestroyable)
        {
            Destroy(gameObject);
            Instantiate(ParticleSystem, transform.position, Quaternion.identity);

            //VirtualCamera.enabled = false;

            //if (_hud != null)
            //{
            //    _hud.UpdateScore(1);
            //}

            _hud?.UpdateScore(ItemData.ItemScore);
        }
    }
}
