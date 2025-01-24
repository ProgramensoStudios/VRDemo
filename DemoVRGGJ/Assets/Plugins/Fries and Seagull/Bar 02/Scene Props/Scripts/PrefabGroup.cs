﻿using System.Collections.Generic;
using UnityEngine;

namespace Seagull.Bar_02.SceneProps {
    public class PrefabGroup : MonoBehaviour {
        public List<GameObject> prefabs;
        public GameObject getRandomPrefab() {
            int r = Random.Range(0, prefabs.Count);
            return prefabs[r];
        }
    }
}