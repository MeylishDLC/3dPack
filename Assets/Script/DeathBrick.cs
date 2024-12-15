using UnityEngine;

namespace Script
{
    public class DeathBrick: DeathAttack
    {
        [SerializeField] private LayerMask groundLayer;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (((1 << other.gameObject.layer) & groundLayer.value) != 0)
            {
                Destroy(gameObject);
            }
        }
    }
}