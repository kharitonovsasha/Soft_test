﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Repositories
{
    [CreateAssetMenu(fileName = "BuildingsDataRepository", menuName = "Data/BuildingsDataRepository")]
    public class BuildingsDataRepository : ScriptableObject
    {
        public List<BuildingData> BuildingsData;

        public long GetBuildingUpgradePrice(string buildingId)
        {
            foreach (var data in BuildingsData)
            {
                if(data.Id == buildingId)
                    return data.UpgradePrice;
            }
            return long.MaxValue;
        }
    }

    [Serializable]
    public class BuildingData
    {
        public string Id;
        public long UpgradePrice;
    }
}