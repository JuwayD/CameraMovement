using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineExternalCamera_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineExternalCamera);

       [UnityEngine.TooltipAttribute("Hint for blending positions to and from this virtual camera")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.BlendHint> m_BlendHint;
       [UnityEngine.HideInInspector]
        public Control_S_String_Field[] m_ExcludedPropertiesInInspector;
       [UnityEngine.HideInInspector]
        public Control_C_CC_Stage_Field[] m_LockStageInInspector;
       [UnityEngine.TooltipAttribute("The priority will determine which camera becomes active based on the state of other cameras and this camera.  Higher numbers have greater priority.")]
            public DataMixer <System.Int32> m_Priority;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> FollowTargetAttachment;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> LookAtTargetAttachment;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineExternalCamera_Config source = (CameraMovement.Control_C_CinemachineExternalCamera_Config)sourceConfig;
            if(source.m_BlendHint.IsUse) m_BlendHint.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.BlendHint>(id, priority, source.m_BlendHint.Value));
            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].AddByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].AddByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Add(new MixItem<System.Int32>(id, priority, source.m_Priority.Value));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.Value));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.Value));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineExternalCamera_Config source = (CameraMovement.Control_C_CinemachineExternalCamera_Config)sourceConfig;
            if(source.m_BlendHint.IsUse) m_BlendHint.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.BlendHint>(id, priority, source.m_BlendHint.Value));
            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].RemoveByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].RemoveByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Remove(new MixItem<System.Int32>(id, priority, source.m_Priority.Value));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.Value));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.Value));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineExternalCamera)targetObj;
            target.m_BlendHint = m_BlendHint.Value;
            // 处理数组字段 m_ExcludedPropertiesInInspector
            for (int i = 0; i < m_ExcludedPropertiesInInspector.Length; i++)
            {
                // 生成递归代码
                m_ExcludedPropertiesInInspector[i].ControlCinemachine(target.m_ExcludedPropertiesInInspector[i], templateDict);
            }
            // 处理数组字段 m_LockStageInInspector
            for (int i = 0; i < m_LockStageInInspector.Length; i++)
            {
                // 生成递归代码
                m_LockStageInInspector[i].ControlCinemachine(target.m_LockStageInInspector[i], templateDict);
            }
            target.m_Priority = m_Priority.Value;
            target.m_StandbyUpdate = m_StandbyUpdate.Value;
        }
    }
}
