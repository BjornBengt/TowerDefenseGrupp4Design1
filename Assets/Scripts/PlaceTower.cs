using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    Camera myCamera;
    PlayerData playerData;
    [SerializeField] GameObject towerPrefabToPlace;
    [SerializeField] GameObject endzoneManager;
    [SerializeField] LayerMask canPlaceOnLayers;
    [SerializeField] float towerOffsetY = 3.5f;
    [SerializeField] int towerCost;

    void Start()
    {
        myCamera = Camera.main;
        playerData = endzoneManager.GetComponent<PlayerData>();
    }

    void Update()
    {
        // Draw Raycast
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        mousePosition = myCamera.ScreenToWorldPoint(mousePosition);
        Debug.DrawRay(transform.position, mousePosition - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray raycast = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            // Makes the acctual raycast and places an object
            if (Physics.Raycast(raycast, out raycastHit, 100, canPlaceOnLayers)) 
            {
                print("raycastHit " + raycastHit.point);
                Vector3 towerPlacement = new Vector3(raycastHit.transform.position.x, raycastHit.transform.position.y + towerOffsetY, raycastHit.transform.position.z);
                print("towerPlacement " + towerPlacement.y);
                Instantiate(towerPrefabToPlace, towerPlacement, Quaternion.identity);
                playerData.GetMoney(-towerCost);
            }
        }
    }
}