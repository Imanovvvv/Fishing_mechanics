using System.Threading.Tasks;
using Events;
using UnityEngine;

namespace BiteSystem
{
    public class BiteController
    {
        public async void BiteRiseAwaiter(float minBiteTime, float maxBiteTime)
        {
            float waitTime = Random.Range(minBiteTime, maxBiteTime) * 1000f;
            await Task.Delay((int)waitTime);
            FishingEventsBank.RaiseOnBite();
        }
    }
}