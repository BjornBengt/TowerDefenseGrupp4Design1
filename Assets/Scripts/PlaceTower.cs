using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    Camera myCamera;
    [SerializeField] GameObject towerPrefabToPlace;
    [SerializeField] GameObject endzoneManager;
    [SerializeField] LayerMask canPlaceOnLayers;
    [SerializeField] int towerCost;

    void Start()
    {
        myCamera = Camera.main;
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
                Vector3 towerPlacement = raycastHit.point;
                print("towerPlacement " + towerPlacement.y);
                Instantiate(towerPrefabToPlace, towerPlacement, Quaternion.identity);
            }
        }
    }
}