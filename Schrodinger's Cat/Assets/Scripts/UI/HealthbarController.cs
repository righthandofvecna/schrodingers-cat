using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    /// <summary>
    /// A simple controller for switching between UI panels.
    /// </summary>
    public class HealthbarController : MonoBehaviour
    {
        public GameObject hitPointSprite;

        List<GameObject> hpList;

        public void Awake() {
            hpList = new List<GameObject>();
        }
        
        public void SetHP(int hp) {
            while (hpList.Count > Mathf.Clamp(hp, 0, hpList.Count+1)) {
                Object.Destroy(hpList[0]);
                hpList.RemoveAt(0);
            }
            while (hpList.Count < hp) {
                GameObject newHpSprite = Instantiate(hitPointSprite);
                newHpSprite.transform.SetParent(this.transform);
                hpList.Add(newHpSprite);
            }
        }
    }
}