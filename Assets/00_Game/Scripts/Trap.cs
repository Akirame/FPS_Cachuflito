    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Trap : MonoBehaviour
    {

        private void OnDestroy()
        {
            Game.Get().AddScore(100);
            Game.Get().TrapDestroyed();
        }
}
