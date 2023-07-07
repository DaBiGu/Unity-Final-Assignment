using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IKControlLogic : MonoBehaviour
{
    Animator m_animator;

    [SerializeField]
    bool m_isHandIKActive = true;

    [SerializeField]
    Transform m_leftHandTarget;

    [SerializeField]
    Transform m_rightHandTarget;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHandIK(AvatarIKGoal goal, Transform targetTransform)
    {
        m_animator.SetIKPosition(goal, targetTransform.position);
        m_animator.SetIKRotation(goal, targetTransform.rotation);
        m_animator.SetIKPositionWeight(goal, 1.0f);
        m_animator.SetIKRotationWeight(goal, 1.0f);
    }

    void OnAnimatorIK()
    {
        if (m_animator)
        {
            if (m_isHandIKActive)
            {
                UpdateHandIK(AvatarIKGoal.LeftHand, m_leftHandTarget);
                UpdateHandIK(AvatarIKGoal.RightHand, m_rightHandTarget);
            }
            else
            {
                // reset the position and rotation
                m_animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
                m_animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
                m_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
                m_animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
            }
        }
    }
}
