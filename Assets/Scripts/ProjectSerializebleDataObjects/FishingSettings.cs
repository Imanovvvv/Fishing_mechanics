using UnityEngine;

namespace ProjectSerializebleDataObjects
{
    [CreateAssetMenu(menuName = "Fishing/Fishing Settings")]
    public class FishingSettings : ScriptableObject
    {
        [Header("Casting")]
        public float castForce = 5f;
        public float returnSpeed = 2f;
        public Transform waterPoint;

        [Header("Bite")]
        public float biteDelayMin = 2f;
        public float biteDelayMax = 5f;

        [Header("Float")]
        public float floatSwayAmplitude = 0.1f;
        public float floatSwayFrequency = 1f;
    
        [Header("MissingDataForStates")]
        public float FishingFightTime = 1.5f;
        public float CastingDelayTime = 1.5f;
        public float MinigameDuration = 2f;

    }
}
