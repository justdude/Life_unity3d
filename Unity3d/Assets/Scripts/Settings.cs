using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
    {
        public float updateTime = 1f;
        public int countX = 16;
        public int womansStart = 4, menStart = 8;
        public int maxDistanceToSpeak = 3;

        public float animatingMoveSpeed = 0.7f;

        public static Settings link;

        void Awake()
        {
            link = this;
        }

    }

