using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropInstatiator : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private int daysSinceDug = -1;
    [SerializeField] private int daysSinceWatered = -1;
    [ItemCodeDescription]
    [SerializeField] private int SeedItemCode = 0;
    [SerializeField] private int growthDays = 0;

    private void OnEnable()
    {
        EventHandler.InstantiateCropPrefabsEvent += InstatiateCropPrefabs;
    }
    private void OnDisable()
    {
        EventHandler.InstantiateCropPrefabsEvent -= InstatiateCropPrefabs;
    }
    private void InstatiateCropPrefabs()
    {
        grid = GameObject.FindObjectOfType<Grid>();
        Vector3Int cropGridPosition = grid.WorldToCell(transform.position);
        SetCropGridProperties(cropGridPosition);
        Destroy(gameObject);
    }
    private void SetCropGridProperties(Vector3Int cropGridPosition)
    {
        if(SeedItemCode > 0)
        {
            GridPropertyDetails gridPropertyDetails;

            gridPropertyDetails = GridPropertiesManager.Instance.GetGridPropertyDetails(cropGridPosition.x, cropGridPosition.y);
            if (gridPropertyDetails == null)
            {
                gridPropertyDetails = new GridPropertyDetails();
            }
            gridPropertyDetails.daysSinceDug = daysSinceDug;
            gridPropertyDetails.daysSinceWatered = daysSinceWatered;
            gridPropertyDetails.seedItemCode = SeedItemCode;
            gridPropertyDetails.growthDays = growthDays;
            GridPropertiesManager.Instance.SetGridPropertyDetails(cropGridPosition.x, cropGridPosition.y, gridPropertyDetails);
        }
    }
}
