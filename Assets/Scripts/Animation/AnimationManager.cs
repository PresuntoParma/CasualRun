using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimationSetup> animationSetups;

    public enum AnimationType
    {
        idle,
        run,
        dead
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1f)
    {
        foreach (var animation in animationSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }
    }
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationManager.AnimationType type;
    public string trigger;
    public float speed = 1f;
}