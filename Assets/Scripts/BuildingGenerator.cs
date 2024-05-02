using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public GameObject housePrefab;

    private Vector3 center;
    private Vector3 spacingSize;
    private int spacing = 2;
    private static List<Building> pendingBuildings = new List<Building>();
    private static List<Building> buildings = new List<Building>();
    private GameObject buildingParent;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        spacingSize = housePrefab.GetComponent<BoxCollider>().size / 2 + new Vector3(spacing, spacing, spacing);
        buildingParent = new GameObject("Buildings");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaceHouse();
        }
    }

    public void PlaceHouse()
    {
        // Test grabbing a point on the navmesh
        if (RandomNavmeshPoint.RandomPointFromCenterBox(center, spacingSize, out Vector3 point, 8f, 3f, 1000f))
        {
            // Make a house
            
            Quaternion rotation = Quaternion.Euler(0, 90 * Random.Range(0, 4), 0);
            Building house = Instantiate(housePrefab, point, Quaternion.identity * rotation, buildingParent.transform).GetComponent<Building>();
            pendingBuildings.Add(house);
        }
    }

    public static List<Building> GetPendingBuildings()
    {
        return pendingBuildings;
    }

    public static void AddBuilding(Building building)
    {
        if (pendingBuildings.Contains(building))
        {
            pendingBuildings.Remove(building);
            buildings.Add(building);
        }
    }
}