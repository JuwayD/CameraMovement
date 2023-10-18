using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineMixingCamera_Field :ICameraMovementControlField<Cinemachine.CinemachineMixingCamera>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineMixingCamera);

       [UnityEngine.TooltipAttribute("The weight of the first tracked camera")]
            public DataMixer <System.Single> m_Weight0;
        public float m_Weight0AlertInit;
        public float m_Weight0Diff;
       [UnityEngine.TooltipAttribute("The weight of the second tracked camera")]
            public DataMixer <System.Single> m_Weight1;
        public float m_Weight1AlertInit;
        public float m_Weight1Diff;
       [UnityEngine.TooltipAttribute("The weight of the third tracked camera")]
            public DataMixer <System.Single> m_Weight2;
        public float m_Weight2AlertInit;
        public float m_Weight2Diff;
       [UnityEngine.TooltipAttribute("The weight of the fourth tracked camera")]
            public DataMixer <System.Single> m_Weight3;
        public float m_Weight3AlertInit;
        public float m_Weight3Diff;
       [UnityEngine.TooltipAttribute("The weight of the fifth tracked camera")]
            public DataMixer <System.Single> m_Weight4;
        public float m_Weight4AlertInit;
        public float m_Weight4Diff;
       [UnityEngine.TooltipAttribute("The weight of the sixth tracked camera")]
            public DataMixer <System.Single> m_Weight5;
        public float m_Weight5AlertInit;
        public float m_Weight5Diff;
       [UnityEngine.TooltipAttribute("The weight of the seventh tracked camera")]
            public DataMixer <System.Single> m_Weight6;
        public float m_Weight6AlertInit;
        public float m_Weight6Diff;
       [UnityEngine.TooltipAttribute("The weight of the eighth tracked camera")]
            public DataMixer <System.Single> m_Weight7;
        public float m_Weight7AlertInit;
        public float m_Weight7Diff;
       [UnityEngine.HideInInspector]
            public DataMixer<System.String>[] m_ExcludedPropertiesInInspector;
       [UnityEngine.HideInInspector]
            public DataMixer<Cinemachine.CinemachineCore.Stage>[] m_LockStageInInspector;
       [UnityEngine.TooltipAttribute("The priority will determine which camera becomes active based on the state of other cameras and this camera.  Higher numbers have greater priority.")]
            public DataMixer <System.Int32> m_Priority;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> FollowTargetAttachment;
        public float FollowTargetAttachmentAlertInit;
        public float FollowTargetAttachmentDiff;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> LookAtTargetAttachment;
        public float LookAtTargetAttachmentAlertInit;
        public float LookAtTargetAttachmentDiff;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineMixingCamera target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineMixingCamera_Config source = (CameraMovement.Control_C_CinemachineMixingCamera_Config)sourceConfig;
            if(source.m_Weight0.IsUse)
            {
                m_Weight0.Add(new MixItem<System.Single>(id, priority, source.m_Weight0.CalculatorExpression, source.m_Weight0.Value, source.m_Weight0.IsUse));
               var targetValue = (m_Weight0.IsExpression ? m_Weight0.Value : m_Weight0.PrimitiveValue);
               m_Weight0Diff = targetValue - target.m_Weight0;
               if(templateDict[m_Weight0.Id].Config.alertCurve != null) m_Weight0AlertInit = target.m_Weight0 - templateDict[m_Weight0.Id].Config.alertCurve.Evaluate(templateDict[m_Weight0.Id].CostTime / templateDict[m_Weight0.Id].Config.duration) * (m_Weight0Diff);
            }
            if(source.m_Weight1.IsUse)
            {
                m_Weight1.Add(new MixItem<System.Single>(id, priority, source.m_Weight1.CalculatorExpression, source.m_Weight1.Value, source.m_Weight1.IsUse));
               var targetValue = (m_Weight1.IsExpression ? m_Weight1.Value : m_Weight1.PrimitiveValue);
               m_Weight1Diff = targetValue - target.m_Weight1;
               if(templateDict[m_Weight1.Id].Config.alertCurve != null) m_Weight1AlertInit = target.m_Weight1 - templateDict[m_Weight1.Id].Config.alertCurve.Evaluate(templateDict[m_Weight1.Id].CostTime / templateDict[m_Weight1.Id].Config.duration) * (m_Weight1Diff);
            }
            if(source.m_Weight2.IsUse)
            {
                m_Weight2.Add(new MixItem<System.Single>(id, priority, source.m_Weight2.CalculatorExpression, source.m_Weight2.Value, source.m_Weight2.IsUse));
               var targetValue = (m_Weight2.IsExpression ? m_Weight2.Value : m_Weight2.PrimitiveValue);
               m_Weight2Diff = targetValue - target.m_Weight2;
               if(templateDict[m_Weight2.Id].Config.alertCurve != null) m_Weight2AlertInit = target.m_Weight2 - templateDict[m_Weight2.Id].Config.alertCurve.Evaluate(templateDict[m_Weight2.Id].CostTime / templateDict[m_Weight2.Id].Config.duration) * (m_Weight2Diff);
            }
            if(source.m_Weight3.IsUse)
            {
                m_Weight3.Add(new MixItem<System.Single>(id, priority, source.m_Weight3.CalculatorExpression, source.m_Weight3.Value, source.m_Weight3.IsUse));
               var targetValue = (m_Weight3.IsExpression ? m_Weight3.Value : m_Weight3.PrimitiveValue);
               m_Weight3Diff = targetValue - target.m_Weight3;
               if(templateDict[m_Weight3.Id].Config.alertCurve != null) m_Weight3AlertInit = target.m_Weight3 - templateDict[m_Weight3.Id].Config.alertCurve.Evaluate(templateDict[m_Weight3.Id].CostTime / templateDict[m_Weight3.Id].Config.duration) * (m_Weight3Diff);
            }
            if(source.m_Weight4.IsUse)
            {
                m_Weight4.Add(new MixItem<System.Single>(id, priority, source.m_Weight4.CalculatorExpression, source.m_Weight4.Value, source.m_Weight4.IsUse));
               var targetValue = (m_Weight4.IsExpression ? m_Weight4.Value : m_Weight4.PrimitiveValue);
               m_Weight4Diff = targetValue - target.m_Weight4;
               if(templateDict[m_Weight4.Id].Config.alertCurve != null) m_Weight4AlertInit = target.m_Weight4 - templateDict[m_Weight4.Id].Config.alertCurve.Evaluate(templateDict[m_Weight4.Id].CostTime / templateDict[m_Weight4.Id].Config.duration) * (m_Weight4Diff);
            }
            if(source.m_Weight5.IsUse)
            {
                m_Weight5.Add(new MixItem<System.Single>(id, priority, source.m_Weight5.CalculatorExpression, source.m_Weight5.Value, source.m_Weight5.IsUse));
               var targetValue = (m_Weight5.IsExpression ? m_Weight5.Value : m_Weight5.PrimitiveValue);
               m_Weight5Diff = targetValue - target.m_Weight5;
               if(templateDict[m_Weight5.Id].Config.alertCurve != null) m_Weight5AlertInit = target.m_Weight5 - templateDict[m_Weight5.Id].Config.alertCurve.Evaluate(templateDict[m_Weight5.Id].CostTime / templateDict[m_Weight5.Id].Config.duration) * (m_Weight5Diff);
            }
            if(source.m_Weight6.IsUse)
            {
                m_Weight6.Add(new MixItem<System.Single>(id, priority, source.m_Weight6.CalculatorExpression, source.m_Weight6.Value, source.m_Weight6.IsUse));
               var targetValue = (m_Weight6.IsExpression ? m_Weight6.Value : m_Weight6.PrimitiveValue);
               m_Weight6Diff = targetValue - target.m_Weight6;
               if(templateDict[m_Weight6.Id].Config.alertCurve != null) m_Weight6AlertInit = target.m_Weight6 - templateDict[m_Weight6.Id].Config.alertCurve.Evaluate(templateDict[m_Weight6.Id].CostTime / templateDict[m_Weight6.Id].Config.duration) * (m_Weight6Diff);
            }
            if(source.m_Weight7.IsUse)
            {
                m_Weight7.Add(new MixItem<System.Single>(id, priority, source.m_Weight7.CalculatorExpression, source.m_Weight7.Value, source.m_Weight7.IsUse));
               var targetValue = (m_Weight7.IsExpression ? m_Weight7.Value : m_Weight7.PrimitiveValue);
               m_Weight7Diff = targetValue - target.m_Weight7;
               if(templateDict[m_Weight7.Id].Config.alertCurve != null) m_Weight7AlertInit = target.m_Weight7 - templateDict[m_Weight7.Id].Config.alertCurve.Evaluate(templateDict[m_Weight7.Id].CostTime / templateDict[m_Weight7.Id].Config.duration) * (m_Weight7Diff);
            }
            for(int i = 0;i < (m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                if(source.m_ExcludedPropertiesInInspector[i].IsUse)
                {
                    m_ExcludedPropertiesInInspector[i].Add(new MixItem<System.String>(id, priority, source.m_ExcludedPropertiesInInspector[i].CalculatorExpression, source.m_ExcludedPropertiesInInspector[i].Value, source.m_ExcludedPropertiesInInspector[i].IsUse));
                }
            }
            for(int i = 0;i < (m_LockStageInInspector?.Length ?? 0);i++)
            {
                if(source.m_LockStageInInspector[i].IsUse)
                {
                    m_LockStageInInspector[i].Add(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_LockStageInInspector[i].CalculatorExpression, source.m_LockStageInInspector[i].Value, source.m_LockStageInInspector[i].IsUse));
                }
            }
            if(source.m_Priority.IsUse)
            {
                m_Priority.Add(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
            }
            if(source.FollowTargetAttachment.IsUse)
            {
                FollowTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
               var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
               FollowTargetAttachmentDiff = targetValue - target.FollowTargetAttachment;
               if(templateDict[FollowTargetAttachment.Id].Config.alertCurve != null) FollowTargetAttachmentAlertInit = target.FollowTargetAttachment - templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (FollowTargetAttachmentDiff);
            }
            if(source.LookAtTargetAttachment.IsUse)
            {
                LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
               var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
               LookAtTargetAttachmentDiff = targetValue - target.LookAtTargetAttachment;
               if(templateDict[LookAtTargetAttachment.Id].Config.alertCurve != null) LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment - templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (LookAtTargetAttachmentDiff);
            }
            if(source.m_StandbyUpdate.IsUse)
            {
                m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineMixingCamera target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineMixingCamera_Config source = (CameraMovement.Control_C_CinemachineMixingCamera_Config)sourceConfig;
            if(source.m_Weight0.IsUse)
            {
                m_Weight0.Remove(new MixItem<System.Single>(id, priority, source.m_Weight0.CalculatorExpression, source.m_Weight0.Value, source.m_Weight0.IsUse));
               var targetValue = (m_Weight0.IsExpression ? m_Weight0.Value : m_Weight0.PrimitiveValue);
               m_Weight0Diff = targetValue - target.m_Weight0;
               if(templateDict[m_Weight0.Id].Config.alertCurve != null) m_Weight0AlertInit = target.m_Weight0 - templateDict[m_Weight0.Id].Config.alertCurve.Evaluate(templateDict[m_Weight0.Id].CostTime / templateDict[m_Weight0.Id].Config.duration) * (m_Weight0Diff);
            }
            if(source.m_Weight1.IsUse)
            {
                m_Weight1.Remove(new MixItem<System.Single>(id, priority, source.m_Weight1.CalculatorExpression, source.m_Weight1.Value, source.m_Weight1.IsUse));
               var targetValue = (m_Weight1.IsExpression ? m_Weight1.Value : m_Weight1.PrimitiveValue);
               m_Weight1Diff = targetValue - target.m_Weight1;
               if(templateDict[m_Weight1.Id].Config.alertCurve != null) m_Weight1AlertInit = target.m_Weight1 - templateDict[m_Weight1.Id].Config.alertCurve.Evaluate(templateDict[m_Weight1.Id].CostTime / templateDict[m_Weight1.Id].Config.duration) * (m_Weight1Diff);
            }
            if(source.m_Weight2.IsUse)
            {
                m_Weight2.Remove(new MixItem<System.Single>(id, priority, source.m_Weight2.CalculatorExpression, source.m_Weight2.Value, source.m_Weight2.IsUse));
               var targetValue = (m_Weight2.IsExpression ? m_Weight2.Value : m_Weight2.PrimitiveValue);
               m_Weight2Diff = targetValue - target.m_Weight2;
               if(templateDict[m_Weight2.Id].Config.alertCurve != null) m_Weight2AlertInit = target.m_Weight2 - templateDict[m_Weight2.Id].Config.alertCurve.Evaluate(templateDict[m_Weight2.Id].CostTime / templateDict[m_Weight2.Id].Config.duration) * (m_Weight2Diff);
            }
            if(source.m_Weight3.IsUse)
            {
                m_Weight3.Remove(new MixItem<System.Single>(id, priority, source.m_Weight3.CalculatorExpression, source.m_Weight3.Value, source.m_Weight3.IsUse));
               var targetValue = (m_Weight3.IsExpression ? m_Weight3.Value : m_Weight3.PrimitiveValue);
               m_Weight3Diff = targetValue - target.m_Weight3;
               if(templateDict[m_Weight3.Id].Config.alertCurve != null) m_Weight3AlertInit = target.m_Weight3 - templateDict[m_Weight3.Id].Config.alertCurve.Evaluate(templateDict[m_Weight3.Id].CostTime / templateDict[m_Weight3.Id].Config.duration) * (m_Weight3Diff);
            }
            if(source.m_Weight4.IsUse)
            {
                m_Weight4.Remove(new MixItem<System.Single>(id, priority, source.m_Weight4.CalculatorExpression, source.m_Weight4.Value, source.m_Weight4.IsUse));
               var targetValue = (m_Weight4.IsExpression ? m_Weight4.Value : m_Weight4.PrimitiveValue);
               m_Weight4Diff = targetValue - target.m_Weight4;
               if(templateDict[m_Weight4.Id].Config.alertCurve != null) m_Weight4AlertInit = target.m_Weight4 - templateDict[m_Weight4.Id].Config.alertCurve.Evaluate(templateDict[m_Weight4.Id].CostTime / templateDict[m_Weight4.Id].Config.duration) * (m_Weight4Diff);
            }
            if(source.m_Weight5.IsUse)
            {
                m_Weight5.Remove(new MixItem<System.Single>(id, priority, source.m_Weight5.CalculatorExpression, source.m_Weight5.Value, source.m_Weight5.IsUse));
               var targetValue = (m_Weight5.IsExpression ? m_Weight5.Value : m_Weight5.PrimitiveValue);
               m_Weight5Diff = targetValue - target.m_Weight5;
               if(templateDict[m_Weight5.Id].Config.alertCurve != null) m_Weight5AlertInit = target.m_Weight5 - templateDict[m_Weight5.Id].Config.alertCurve.Evaluate(templateDict[m_Weight5.Id].CostTime / templateDict[m_Weight5.Id].Config.duration) * (m_Weight5Diff);
            }
            if(source.m_Weight6.IsUse)
            {
                m_Weight6.Remove(new MixItem<System.Single>(id, priority, source.m_Weight6.CalculatorExpression, source.m_Weight6.Value, source.m_Weight6.IsUse));
               var targetValue = (m_Weight6.IsExpression ? m_Weight6.Value : m_Weight6.PrimitiveValue);
               m_Weight6Diff = targetValue - target.m_Weight6;
               if(templateDict[m_Weight6.Id].Config.alertCurve != null) m_Weight6AlertInit = target.m_Weight6 - templateDict[m_Weight6.Id].Config.alertCurve.Evaluate(templateDict[m_Weight6.Id].CostTime / templateDict[m_Weight6.Id].Config.duration) * (m_Weight6Diff);
            }
            if(source.m_Weight7.IsUse)
            {
                m_Weight7.Remove(new MixItem<System.Single>(id, priority, source.m_Weight7.CalculatorExpression, source.m_Weight7.Value, source.m_Weight7.IsUse));
               var targetValue = (m_Weight7.IsExpression ? m_Weight7.Value : m_Weight7.PrimitiveValue);
               m_Weight7Diff = targetValue - target.m_Weight7;
               if(templateDict[m_Weight7.Id].Config.alertCurve != null) m_Weight7AlertInit = target.m_Weight7 - templateDict[m_Weight7.Id].Config.alertCurve.Evaluate(templateDict[m_Weight7.Id].CostTime / templateDict[m_Weight7.Id].Config.duration) * (m_Weight7Diff);
            }
            for(int i = 0;i < (m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                if(source.m_ExcludedPropertiesInInspector[i].IsUse)
                {
                    m_ExcludedPropertiesInInspector[i].Remove(new MixItem<System.String>(id, priority, source.m_ExcludedPropertiesInInspector[i].CalculatorExpression, source.m_ExcludedPropertiesInInspector[i].Value, source.m_ExcludedPropertiesInInspector[i].IsUse));
                }
            }
            for(int i = 0;i < (m_LockStageInInspector?.Length ?? 0);i++)
            {
                if(source.m_LockStageInInspector[i].IsUse)
                {
                    m_LockStageInInspector[i].Remove(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_LockStageInInspector[i].CalculatorExpression, source.m_LockStageInInspector[i].Value, source.m_LockStageInInspector[i].IsUse));
                }
            }
            if(source.m_Priority.IsUse)
            {
                m_Priority.Remove(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
            }
            if(source.FollowTargetAttachment.IsUse)
            {
                FollowTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
               var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
               FollowTargetAttachmentDiff = targetValue - target.FollowTargetAttachment;
               if(templateDict[FollowTargetAttachment.Id].Config.alertCurve != null) FollowTargetAttachmentAlertInit = target.FollowTargetAttachment - templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (FollowTargetAttachmentDiff);
            }
            if(source.LookAtTargetAttachment.IsUse)
            {
                LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
               var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
               LookAtTargetAttachmentDiff = targetValue - target.LookAtTargetAttachment;
               if(templateDict[LookAtTargetAttachment.Id].Config.alertCurve != null) LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment - templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (LookAtTargetAttachmentDiff);
            }
            if(source.m_StandbyUpdate.IsUse)
            {
                m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
            }
        }
        public void RemoveAll()
        {
            m_Weight0.RemoveAll();
            m_Weight1.RemoveAll();
            m_Weight2.RemoveAll();
            m_Weight3.RemoveAll();
            m_Weight4.RemoveAll();
            m_Weight5.RemoveAll();
            m_Weight6.RemoveAll();
            m_Weight7.RemoveAll();
            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].RemoveAll();
            }
            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].RemoveAll();
            }
            m_Priority.RemoveAll();
            FollowTargetAttachment.RemoveAll();
            LookAtTargetAttachment.RemoveAll();
            m_StandbyUpdate.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineMixingCamera target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Weight0.IsUse && templateDict.ContainsKey(m_Weight0.Id))
            {
                var targetValue = (m_Weight0.IsExpression ? m_Weight0.Value : m_Weight0.PrimitiveValue);
                target.m_Weight0 = Mathf.Approximately(0, templateDict[m_Weight0.Id].Config.duration) ? targetValue : m_Weight0AlertInit + templateDict[m_Weight0.Id].Config.alertCurve.Evaluate(templateDict[m_Weight0.Id].CostTime / templateDict[m_Weight0.Id].Config.duration) * m_Weight0Diff;
            }
            if (m_Weight1.IsUse && templateDict.ContainsKey(m_Weight1.Id))
            {
                var targetValue = (m_Weight1.IsExpression ? m_Weight1.Value : m_Weight1.PrimitiveValue);
                target.m_Weight1 = Mathf.Approximately(0, templateDict[m_Weight1.Id].Config.duration) ? targetValue : m_Weight1AlertInit + templateDict[m_Weight1.Id].Config.alertCurve.Evaluate(templateDict[m_Weight1.Id].CostTime / templateDict[m_Weight1.Id].Config.duration) * m_Weight1Diff;
            }
            if (m_Weight2.IsUse && templateDict.ContainsKey(m_Weight2.Id))
            {
                var targetValue = (m_Weight2.IsExpression ? m_Weight2.Value : m_Weight2.PrimitiveValue);
                target.m_Weight2 = Mathf.Approximately(0, templateDict[m_Weight2.Id].Config.duration) ? targetValue : m_Weight2AlertInit + templateDict[m_Weight2.Id].Config.alertCurve.Evaluate(templateDict[m_Weight2.Id].CostTime / templateDict[m_Weight2.Id].Config.duration) * m_Weight2Diff;
            }
            if (m_Weight3.IsUse && templateDict.ContainsKey(m_Weight3.Id))
            {
                var targetValue = (m_Weight3.IsExpression ? m_Weight3.Value : m_Weight3.PrimitiveValue);
                target.m_Weight3 = Mathf.Approximately(0, templateDict[m_Weight3.Id].Config.duration) ? targetValue : m_Weight3AlertInit + templateDict[m_Weight3.Id].Config.alertCurve.Evaluate(templateDict[m_Weight3.Id].CostTime / templateDict[m_Weight3.Id].Config.duration) * m_Weight3Diff;
            }
            if (m_Weight4.IsUse && templateDict.ContainsKey(m_Weight4.Id))
            {
                var targetValue = (m_Weight4.IsExpression ? m_Weight4.Value : m_Weight4.PrimitiveValue);
                target.m_Weight4 = Mathf.Approximately(0, templateDict[m_Weight4.Id].Config.duration) ? targetValue : m_Weight4AlertInit + templateDict[m_Weight4.Id].Config.alertCurve.Evaluate(templateDict[m_Weight4.Id].CostTime / templateDict[m_Weight4.Id].Config.duration) * m_Weight4Diff;
            }
            if (m_Weight5.IsUse && templateDict.ContainsKey(m_Weight5.Id))
            {
                var targetValue = (m_Weight5.IsExpression ? m_Weight5.Value : m_Weight5.PrimitiveValue);
                target.m_Weight5 = Mathf.Approximately(0, templateDict[m_Weight5.Id].Config.duration) ? targetValue : m_Weight5AlertInit + templateDict[m_Weight5.Id].Config.alertCurve.Evaluate(templateDict[m_Weight5.Id].CostTime / templateDict[m_Weight5.Id].Config.duration) * m_Weight5Diff;
            }
            if (m_Weight6.IsUse && templateDict.ContainsKey(m_Weight6.Id))
            {
                var targetValue = (m_Weight6.IsExpression ? m_Weight6.Value : m_Weight6.PrimitiveValue);
                target.m_Weight6 = Mathf.Approximately(0, templateDict[m_Weight6.Id].Config.duration) ? targetValue : m_Weight6AlertInit + templateDict[m_Weight6.Id].Config.alertCurve.Evaluate(templateDict[m_Weight6.Id].CostTime / templateDict[m_Weight6.Id].Config.duration) * m_Weight6Diff;
            }
            if (m_Weight7.IsUse && templateDict.ContainsKey(m_Weight7.Id))
            {
                var targetValue = (m_Weight7.IsExpression ? m_Weight7.Value : m_Weight7.PrimitiveValue);
                target.m_Weight7 = Mathf.Approximately(0, templateDict[m_Weight7.Id].Config.duration) ? targetValue : m_Weight7AlertInit + templateDict[m_Weight7.Id].Config.alertCurve.Evaluate(templateDict[m_Weight7.Id].CostTime / templateDict[m_Weight7.Id].Config.duration) * m_Weight7Diff;
            }
            // 处理数组字段 m_ExcludedPropertiesInInspector
            for (int i = 0; i < (m_ExcludedPropertiesInInspector?.Length ?? 0); i++)
            {
                // 生成递归代码
                if (m_ExcludedPropertiesInInspector[i].IsUse) target.m_ExcludedPropertiesInInspector[i] = m_ExcludedPropertiesInInspector[i].PrimitiveValue;
            }
            // 处理数组字段 m_LockStageInInspector
            for (int i = 0; i < (m_LockStageInInspector?.Length ?? 0); i++)
            {
                // 生成递归代码
                if (m_LockStageInInspector[i].IsUse) target.m_LockStageInInspector[i] = (m_LockStageInInspector[i].IsExpression ? (Cinemachine.CinemachineCore.Stage)m_LockStageInInspector[i].Value : (Cinemachine.CinemachineCore.Stage)m_LockStageInInspector[i].PrimitiveValue);
            }
            if (m_Priority.IsUse) target.m_Priority = m_Priority.IsExpression ? (System.Int32)m_Priority.Value :m_Priority.PrimitiveValue;
            if (FollowTargetAttachment.IsUse && templateDict.ContainsKey(FollowTargetAttachment.Id))
            {
                var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
                target.FollowTargetAttachment = Mathf.Approximately(0, templateDict[FollowTargetAttachment.Id].Config.duration) ? targetValue : FollowTargetAttachmentAlertInit + templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * FollowTargetAttachmentDiff;
            }
            if (LookAtTargetAttachment.IsUse && templateDict.ContainsKey(LookAtTargetAttachment.Id))
            {
                var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
                target.LookAtTargetAttachment = Mathf.Approximately(0, templateDict[LookAtTargetAttachment.Id].Config.duration) ? targetValue : LookAtTargetAttachmentAlertInit + templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * LookAtTargetAttachmentDiff;
            }
            if (m_StandbyUpdate.IsUse) target.m_StandbyUpdate = m_StandbyUpdate.IsExpression ? (Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode)m_StandbyUpdate.Value :m_StandbyUpdate.PrimitiveValue;
        }
    }
}
