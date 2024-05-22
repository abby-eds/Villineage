using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Targetable
{
    public Villager assignedVillager;
    public int requiredWood;
    public int currentWood;
    public int stage;
    public BuildingType buildingType;

    [SyncVar(hook = nameof(ProgressHook))]
    public int buildProgress;

    public override bool Progress(Villager villager)
    {
        buildProgress++;
        UpdateStage();
        if (buildProgress >= requiredWood)
        {
            buildProgress = requiredWood;
            switch(buildingType)
            {
                case BuildingType.House: BuildingGenerator.AddHouse(this); break;
                case BuildingType.Outpost: BuildingGenerator.AddOutpost(this); break;
            }
            UntargetAll();
            return true;
        }
        if (buildProgress >= currentWood)
        {
            buildProgress = currentWood;
            return false;
        }
        return true;
    }

    public void ContributeWood(Villager villager)
    {
        int neededWood = requiredWood - currentWood;
        int usedWood = Math.Min(neededWood, villager.inventory[(int)ResourceType.Wood]);
        currentWood += usedWood;
        villager.inventory[(int)ResourceType.Wood] -= usedWood;
        villager.totalResources -= usedWood;
    }

    private void ProgressHook(int oldProgress, int newProgress)
    {
        if (oldProgress == 0) priority *= 1.1f;
        UpdateStage();
    }

    private void UpdateStage()
    {
        int newStage = Mathf.Clamp((buildProgress * (transform.childCount - 1) / requiredWood), 0, transform.childCount - 1);
        if (newStage != stage)
        {
            stage = newStage;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(i == stage);
            }
        }
    }

    private void OnDestroy()
    {
        BuildingGenerator.RemoveBuilding(this);
    }
}