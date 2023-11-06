using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    Camera myCamera;
    [SerializeField] GameObject tower;
    [SerializeField] LayerMask canPlaceOnLayers;
    [SerializeField] float towerOffsetY = 3.5f;

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

            
            if (Physics.Raycast(raycast, out raycastHit, 100, canPlaceOnLayers))
            {
                print("raycastHit " + raycastHit.point);
                Vector3 towerPlacement = new Vector3(raycastHit.transform.position.x, raycastHit.transform.position.y + towerOffsetY, raycastHit.transform.position.z);
                print("towerPlacement " + towerPlacement.y);
                Instantiate(tower, towerPlacement, Quaternion.identity);
            }
        }
    }
}