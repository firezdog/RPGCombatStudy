using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace RPG.Core {
    public class FollowCam : MonoBehaviour
    {
        public Transform player;

        void LateUpdate()
        {
            transform.position = player.position;
        }
    }
}