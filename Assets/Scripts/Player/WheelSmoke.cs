using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSmoke : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystemLeft;
    [SerializeField] ParticleSystem particleSystemRight;
    [SerializeField] float driftThreshold = 0.5f;

    public void PlaySmokeEffect(float input)
    {
        bool isDrifting = Mathf.Abs(input) > driftThreshold;

        if (particleSystemLeft == null || particleSystemRight == null)
            return;

        if (isDrifting)
        {
            if (input < 0)
            {
                if (!particleSystemRight.isPlaying) particleSystemRight.Play();
                if (particleSystemLeft.isPlaying) particleSystemLeft.Stop();
            }
            else
            {
                if (!particleSystemLeft.isPlaying) particleSystemLeft.Play();
                if (particleSystemRight.isPlaying) particleSystemRight.Stop();
            }
        }
        else
        {
            if (particleSystemLeft.isPlaying) particleSystemLeft.Stop();
            if (particleSystemRight.isPlaying) particleSystemRight.Stop();
        }
    }
}
