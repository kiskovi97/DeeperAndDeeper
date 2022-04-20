using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "ScriptableObjects/LevelDesign")]
    public class LevelDesign : ItemForSale
    { 
        public GameObject[] labyrinths;
    }
}