﻿using UnityEngine;

namespace Assets.Scripts
{
    public class TileMapHelper : MonoBehaviour
    {
        public GameObject SimpleTile;
        public GameObject DarkTile;
        public GameObject tileUp;
        public GameObject tileRightCorner;
        public GameObject tileRightAlmostFull;
        public GameObject tileAllAround;
        public GameObject tileUpAndDown;

        public GameObject Get(int code)
        {
            switch (code)
            {
                case 8:
                    return Get(tileUp, 0);
                case 4:
                    return Get(tileUp, 90);
                case 2:
                    return Get(tileUp, 180);
                case 1:
                    return Get(tileUp, 270);

                case 9:
                    return Get(tileRightCorner, 0);
                case 12:
                    return Get(tileRightCorner, 90);
                case 6:
                    return Get(tileRightCorner, 180);
                case 3:
                    return Get(tileRightCorner, 270);

                case 11:
                    return Get(tileRightAlmostFull, 0);
                case 13:
                    return Get(tileRightAlmostFull, 90);
                case 14:
                    return Get(tileRightAlmostFull, 180);
                case 7:
                    return Get(tileRightAlmostFull, 270);

                case 10:
                    return Get(tileUpAndDown, 0);
                case 5:
                    return Get(tileUpAndDown, 90);

                case 15:
                    return Get(tileAllAround, 0);
                default:
                    return Get(DarkTile, 0);
            }
        }

        internal GameObject GetSimple()
        {
            return Get(SimpleTile, 0);
        }

        private GameObject Get(GameObject reference, float rotation)
        {
            var obj = Instantiate(reference, transform);
            obj.transform.Rotate(new Vector3(0, 0, rotation));
            obj.transform.localScale = new Vector3(2.5f, 2.5f, 1f);
            return obj;
        }
    }
}