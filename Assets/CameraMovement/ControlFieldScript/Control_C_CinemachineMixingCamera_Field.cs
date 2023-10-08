using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineMixingCamera_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineMixingCamera);

       [UnityEngine.TooltipAttribute("The weight of the first tracked camera")]
            public DataMixer <System.Single> m_Weight0;
       [UnityEngine.TooltipAttribute("The weight of the second tracked camera")]
            public DataMixer <System.Single> m_Weight1;
       [UnityEngine.TooltipAttribute("The weight of the third tracked camera")]
            public DataMixer <System.Single> m_Weight2;
       [UnityEngine.TooltipAttribute("The weight of the fourth tracked camera")]
            public DataMixer <System.Single> m_Weight3;
       [UnityEngine.TooltipAttribute("The weight of the fifth tracked camera")]
            public DataMixer <System.Single> m_Weight4;
       [UnityEngine.TooltipAttribute("The weight of the sixth tracked camera")]
            public DataMixer <System.Single> m_Weight5;
       [UnityEngine.TooltipAttribute("The weight of the seventh tracked camera")]
            public DataMixer <System.Single> m_Weight6;
       [UnityEngine.TooltipAttribute("The weight of the eighth tracked camera")]
            public DataMixer <System.Single> m_Weight7;
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
            CameraMovement.Control_C_CinemachineMixingCamera_Config source = (CameraMovement.Control_C_CinemachineMixingCamera_Config)sourceConfig;
            if(source.m_Weight0.IsUse) m_Weight0.Add(new MixItem<System.Single>(id, priority, source.m_Weight0.Value));
            if(source.m_Weight1.IsUse) m_Weight1.Add(new MixItem<System.Single>(id, priority, source.m_Weight1.Value));
            if(source.m_Weight2.IsUse) m_Weight2.Add(new MixItem<System.Single>(id, priority, source.m_Weight2.Value));
            if(source.m_Weight3.IsUse) m_Weight3.Add(new MixItem<System.Single>(id, priority, source.m_Weight3.Value));
            if(source.m_Weight4.IsUse) m_Weight4.Add(new MixItem<System.Single>(id, priority, source.m_Weight4.Value));
            if(source.m_Weight5.IsUse) m_Weight5.Add(new MixItem<System.Single>(id, priority, source.m_Weight5.Value));
            if(source.m_Weight6.IsUse) m_Weight6.Add(new MixItem<System.Single>(id, priority, source.m_Weight6.Value));
            if(source.m_Weight7.IsUse) m_Weight7.Add(new MixItem<System.Single>(id, priority, source.m_Weight7.Value));
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
            CameraMovement.Control_C_CinemachineMixingCamera_Config source = (CameraMovement.Control_C_CinemachineMixingCamera_Config)sourceConfig;
            if(source.m_Weight0.IsUse) m_Weight0.Remove(new MixItem<System.Single>(id, priority, source.m_Weight0.Value));
            if(source.m_Weight1.IsUse) m_Weight1.Remove(new MixItem<System.Single>(id, priority, source.m_Weight1.Value));
            if(source.m_Weight2.IsUse) m_Weight2.Remove(new MixItem<System.Single>(id, priority, source.m_Weight2.Value));
            if(source.m_Weight3.IsUse) m_Weight3.Remove(new MixItem<System.Single>(id, priority, source.m_Weight3.Value));
            if(source.m_Weight4.IsUse) m_Weight4.Remove(new MixItem<System.Single>(id, priority, source.m_Weight4.Value));
            if(source.m_Weight5.IsUse) m_Weight5.Remove(new MixItem<System.Single>(id, priority, source.m_Weight5.Value));
            if(source.m_Weight6.IsUse) m_Weight6.Remove(new MixItem<System.Single>(id, priority, source.m_Weight6.Value));
            if(source.m_Weight7.IsUse) m_Weight7.Remove(new MixItem<System.Single>(id, priority, source.m_Weight7.Value));
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
            var target = (Cinemachine.CinemachineMixingCamera)targetObj;
            if (templateDict.ContainsKey(m_Weight0.Id))
                target.m_Weight0 = templateDict[m_Weight0.Id].Config.alertCurve.Evaluate(templateDict[m_Weight0.Id].CostTime / templateDict[m_Weight0.Id].Config.duration);
            target.m_Weight0 = m_Weight0.Value;
            if (templateDict.ContainsKey(m_Weight1.Id))
                target.m_Weight1 = templateDict[m_Weight1.Id].Config.alertCurve.Evaluate(templateDict[m_Weight1.Id].CostTime / templateDict[m_Weight1.Id].Config.duration);
            target.m_Weight1 = m_Weight1.Value;
            if (templateDict.ContainsKey(m_Weight2.Id))
                target.m_Weight2 = templateDict[m_Weight2.Id].Config.alertCurve.Evaluate(templateDict[m_Weight2.Id].CostTime / templateDict[m_Weight2.Id].Config.duration);
            target.m_Weight2 = m_Weight2.Value;
            if (templateDict.ContainsKey(m_Weight3.Id))
                target.m_Weight3 = templateDict[m_Weight3.Id].Config.alertCurve.Evaluate(templateDict[m_Weight3.Id].CostTime / templateDict[m_Weight3.Id].Config.duration);
            target.m_Weight3 = m_Weight3.Value;
            if (templateDict.ContainsKey(m_Weight4.Id))
                target.m_Weight4 = templateDict[m_Weight4.Id].Config.alertCurve.Evaluate(templateDict[m_Weight4.Id].CostTime / templateDict[m_Weight4.Id].Config.duration);
            target.m_Weight4 = m_Weight4.Value;
            if (templateDict.ContainsKey(m_Weight5.Id))
                target.m_Weight5 = templateDict[m_Weight5.Id].Config.alertCurve.Evaluate(templateDict[m_Weight5.Id].CostTime / templateDict[m_Weight5.Id].Config.duration);
            target.m_Weight5 = m_Weight5.Value;
            if (templateDict.ContainsKey(m_Weight6.Id))
                target.m_Weight6 = templateDict[m_Weight6.Id].Config.alertCurve.Evaluate(templateDict[m_Weight6.Id].CostTime / templateDict[m_Weight6.Id].Config.duration);
            target.m_Weight6 = m_Weight6.Value;
            if (templateDict.ContainsKey(m_Weight7.Id))
                target.m_Weight7 = templateDict[m_Weight7.Id].Config.alertCurve.Evaluate(templateDict[m_Weight7.Id].CostTime / templateDict[m_Weight7.Id].Config.duration);
            target.m_Weight7 = m_Weight7.Value;
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
