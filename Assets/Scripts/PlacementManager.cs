using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject towerPrefab; // Drag your tower model here
    private GameObject currentTower;
    public LayerMask groundLayer; // Set this to the layer of your floor/grass

    void Update()
    {
        // 1. Start placement when pressing "1" or a UI button
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTower = Instantiate(towerPrefab);
        }

        // 2. If we are currently holding a tower
        if (currentTower != null)
        {
            MoveTowerToMouse();

            // 3. Confirm placement with Left Click
            if (Input.GetMouseButtonDown(0))
            {
                currentTower = null; // Let go of the tower
            }
        }
    }

    void MoveTowerToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Shoot the ray from the camera to the mouse position
        if (Physics.Raycast(ray, out hit, 100f, groundLayer))
        {
            // For Minecraft style: Snap to the nearest whole number (grid)
            float x = Mathf.Round(hit.point.x);
            float z = Mathf.Round(hit.point.z);
            
            currentTower.transform.position = new Vector3(x, hit.point.y, z);
        }
    }
}