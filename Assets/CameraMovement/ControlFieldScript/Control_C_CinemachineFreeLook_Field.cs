using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineFreeLook_Field :ICameraMovementControlField<Cinemachine.CinemachineFreeLook>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineFreeLook);

       [UnityEngine.TooltipAttribute("If enabled, this lens setting will apply to all three child rigs, otherwise the child rig lens settings will be used")]
            public DataMixer <System.Boolean> m_CommonLens;
       [UnityEngine.TooltipAttribute("Specifies the lens properties of this Virtual Camera.  This generally mirrors the Unity Camera's lens settings, and will be used to drive the Unity camera when the vcam is active")]
        public Control_C_LensSettings_Field m_Lens;
    public Control_C_CVCB_TransitionParams_Field m_Transitions;
       [UnityEngine.HeaderAttribute("Axis Control")]
           [UnityEngine.TooltipAttribute("The Vertical axis.  Value is 0..1.  Chooses how to blend the child rigs")]
        public Control_C_AxisState_Field m_YAxis;
       [UnityEngine.TooltipAttribute("Controls how automatic recentering of the Y axis is accomplished")]
        public Control_C_AS_Recentering_Field m_YAxisRecentering;
       [UnityEngine.TooltipAttribute("The Horizontal axis.  Value is -180...180.  This is passed on to the rigs' OrbitalTransposer component")]
        public Control_C_AxisState_Field m_XAxis;
       [UnityEngine.TooltipAttribute("The definition of Forward.  Camera will follow behind.")]
        public Control_C_COT_Heading_Field m_Heading;
       [UnityEngine.TooltipAttribute("Controls how automatic recentering of the X axis is accomplished")]
        public Control_C_AS_Recentering_Field m_RecenterToTargetHeading;
       [UnityEngine.HeaderAttribute("Orbits")]
           [UnityEngine.TooltipAttribute("The coordinate space to use when interpreting the offset from the target.  This is also used to set the camera's Up vector, which will be maintained when aiming the camera.")]
            public DataMixer <Cinemachine.CinemachineTransposer.BindingMode> m_BindingMode;
       [UnityEngine.TooltipAttribute("Controls how taut is the line that connects the rigs' orbits, which determines final placement on the Y axis")]
            public DataMixer <System.Single> m_SplineCurvature;
        public float m_SplineCurvatureAlertInit;
       [UnityEngine.TooltipAttribute("The radius and height of the three orbiting rigs.")]
        public Control_C_CFL_Orbit_Field[] m_Orbits;
       [UnityEngine.HideInInspector]
        public Control_S_String_Field[] m_ExcludedPropertiesInInspector;
       [UnityEngine.HideInInspector]
        public Control_C_CC_Stage_Field[] m_LockStageInInspector;
       [UnityEngine.TooltipAttribute("The priority will determine which camera becomes active based on the state of other cameras and this camera.  Higher numbers have greater priority.")]
            public DataMixer <System.Int32> m_Priority;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> FollowTargetAttachment;
        public float FollowTargetAttachmentAlertInit;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> LookAtTargetAttachment;
        public float LookAtTargetAttachmentAlertInit;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineFreeLook target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFreeLook_Config source = (CameraMovement.Control_C_CinemachineFreeLook_Config)sourceConfig;
                if(source.m_CommonLens.IsUse)
                {
                    m_CommonLens.Add(new MixItem<System.Boolean>(id, priority, source.m_CommonLens.CalculatorExpression, source.m_CommonLens.Value, source.m_CommonLens.IsUse));
                }
                if(source.m_Lens != null && m_Lens == null) m_Lens = new Control_C_LensSettings_Field();
            m_Lens?.AddByConfig(source.m_Lens, id, priority, ref target.m_Lens, templateDict);
                if(source.m_Transitions != null && m_Transitions == null) m_Transitions = new Control_C_CVCB_TransitionParams_Field();
            m_Transitions?.AddByConfig(source.m_Transitions, id, priority, ref target.m_Transitions, templateDict);
                if(source.m_YAxis != null && m_YAxis == null) m_YAxis = new Control_C_AxisState_Field();
            m_YAxis?.AddByConfig(source.m_YAxis, id, priority, ref target.m_YAxis, templateDict);
                if(source.m_YAxisRecentering != null && m_YAxisRecentering == null) m_YAxisRecentering = new Control_C_AS_Recentering_Field();
            m_YAxisRecentering?.AddByConfig(source.m_YAxisRecentering, id, priority, ref target.m_YAxisRecentering, templateDict);
                if(source.m_XAxis != null && m_XAxis == null) m_XAxis = new Control_C_AxisState_Field();
            m_XAxis?.AddByConfig(source.m_XAxis, id, priority, ref target.m_XAxis, templateDict);
                if(source.m_Heading != null && m_Heading == null) m_Heading = new Control_C_COT_Heading_Field();
            m_Heading?.AddByConfig(source.m_Heading, id, priority, ref target.m_Heading, templateDict);
                if(source.m_RecenterToTargetHeading != null && m_RecenterToTargetHeading == null) m_RecenterToTargetHeading = new Control_C_AS_Recentering_Field();
            m_RecenterToTargetHeading?.AddByConfig(source.m_RecenterToTargetHeading, id, priority, ref target.m_RecenterToTargetHeading, templateDict);
                if(source.m_BindingMode.IsUse)
                {
                    m_BindingMode.Add(new MixItem<Cinemachine.CinemachineTransposer.BindingMode>(id, priority, source.m_BindingMode.CalculatorExpression, source.m_BindingMode.Value, source.m_BindingMode.IsUse));
                }
                if(source.m_SplineCurvature.IsUse)
                {
                    m_SplineCurvature.Add(new MixItem<System.Single>(id, priority, source.m_SplineCurvature.CalculatorExpression, source.m_SplineCurvature.Value, source.m_SplineCurvature.IsUse));
                   var targetValue = (m_SplineCurvature.IsExpression ? m_SplineCurvature.Value : m_SplineCurvature.PrimitiveValue);
                   m_SplineCurvatureAlertInit = target.m_SplineCurvature - templateDict[m_SplineCurvature.Id].Config.alertCurve.Evaluate(templateDict[m_SplineCurvature.Id].CostTime / templateDict[m_SplineCurvature.Id].Config.duration) * (targetValue - m_SplineCurvatureAlertInit);
                }
            for(int i = 0;i < (source.m_Orbits?.Length ?? 0);i++)
            {
                if(source.m_Orbits != null && m_Orbits == null) m_Orbits = new Control_C_CFL_Orbit_Field[source.m_Orbits.Length];
                m_Orbits?[i].AddByConfig(source.m_Orbits[i], id, priority, ref target.m_Orbits[i], templateDict);            }

            for(int i = 0;i < (source.m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                if(source.m_ExcludedPropertiesInInspector != null && m_ExcludedPropertiesInInspector == null) m_ExcludedPropertiesInInspector = new Control_S_String_Field[source.m_ExcludedPropertiesInInspector.Length];
                m_ExcludedPropertiesInInspector?[i].AddByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority, ref target.m_ExcludedPropertiesInInspector[i], templateDict);            }

            for(int i = 0;i < (source.m_LockStageInInspector?.Length ?? 0);i++)
            {
                if(source.m_LockStageInInspector != null && m_LockStageInInspector == null) m_LockStageInInspector = new Control_C_CC_Stage_Field[source.m_LockStageInInspector.Length];
                m_LockStageInInspector?[i].AddByConfig(source.m_LockStageInInspector[i], id, priority, ref target.m_LockStageInInspector[i], templateDict);            }

                if(source.m_Priority.IsUse)
                {
                    m_Priority.Add(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
                }
                if(source.FollowTargetAttachment.IsUse)
                {
                    FollowTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
                   var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
                   FollowTargetAttachmentAlertInit = target.FollowTargetAttachment - templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (targetValue - FollowTargetAttachmentAlertInit);
                }
                if(source.LookAtTargetAttachment.IsUse)
                {
                    LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
                   var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
                   LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment - templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (targetValue - LookAtTargetAttachmentAlertInit);
                }
                if(source.m_StandbyUpdate.IsUse)
                {
                    m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineFreeLook target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFreeLook_Config source = (CameraMovement.Control_C_CinemachineFreeLook_Config)sourceConfig;
                if(source.m_CommonLens.IsUse)
                {
                    m_CommonLens.Remove(new MixItem<System.Boolean>(id, priority, source.m_CommonLens.CalculatorExpression, source.m_CommonLens.Value, source.m_CommonLens.IsUse));
                }
            m_Lens?.RemoveByConfig(source.m_Lens, id, priority, ref target.m_Lens, templateDict);
            m_Transitions?.RemoveByConfig(source.m_Transitions, id, priority, ref target.m_Transitions, templateDict);
            m_YAxis?.RemoveByConfig(source.m_YAxis, id, priority, ref target.m_YAxis, templateDict);
            m_YAxisRecentering?.RemoveByConfig(source.m_YAxisRecentering, id, priority, ref target.m_YAxisRecentering, templateDict);
            m_XAxis?.RemoveByConfig(source.m_XAxis, id, priority, ref target.m_XAxis, templateDict);
            m_Heading?.RemoveByConfig(source.m_Heading, id, priority, ref target.m_Heading, templateDict);
            m_RecenterToTargetHeading?.RemoveByConfig(source.m_RecenterToTargetHeading, id, priority, ref target.m_RecenterToTargetHeading, templateDict);
                if(source.m_BindingMode.IsUse)
                {
                    m_BindingMode.Remove(new MixItem<Cinemachine.CinemachineTransposer.BindingMode>(id, priority, source.m_BindingMode.CalculatorExpression, source.m_BindingMode.Value, source.m_BindingMode.IsUse));
                }
                if(source.m_SplineCurvature.IsUse)
                {
                   var targetValue = (m_SplineCurvature.IsExpression ? m_SplineCurvature.Value : m_SplineCurvature.PrimitiveValue);
                   m_SplineCurvatureAlertInit = target.m_SplineCurvature - templateDict[m_SplineCurvature.Id].Config.alertCurve.Evaluate(templateDict[m_SplineCurvature.Id].CostTime / templateDict[m_SplineCurvature.Id].Config.duration) * (targetValue - m_SplineCurvatureAlertInit);
                    m_SplineCurvature.Remove(new MixItem<System.Single>(id, priority, source.m_SplineCurvature.CalculatorExpression, source.m_SplineCurvature.Value, source.m_SplineCurvature.IsUse));
                }
            for(int i = 0;i < (source.m_Orbits?.Length ?? 0);i++)
            {
                m_Orbits?[i].RemoveByConfig(source.m_Orbits[i], id, priority, ref target.m_Orbits[i], templateDict);            }

            for(int i = 0;i < (source.m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                m_ExcludedPropertiesInInspector?[i].RemoveByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority, ref target.m_ExcludedPropertiesInInspector[i], templateDict);            }

            for(int i = 0;i < (source.m_LockStageInInspector?.Length ?? 0);i++)
            {
                m_LockStageInInspector?[i].RemoveByConfig(source.m_LockStageInInspector[i], id, priority, ref target.m_LockStageInInspector[i], templateDict);            }

                if(source.m_Priority.IsUse)
                {
                    m_Priority.Remove(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
                }
                if(source.FollowTargetAttachment.IsUse)
                {
                   var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
                   FollowTargetAttachmentAlertInit = target.FollowTargetAttachment - templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (targetValue - FollowTargetAttachmentAlertInit);
                    FollowTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
                }
                if(source.LookAtTargetAttachment.IsUse)
                {
                   var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
                   LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment - templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (targetValue - LookAtTargetAttachmentAlertInit);
                    LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
                }
                if(source.m_StandbyUpdate.IsUse)
                {
                    m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
                }
        }
        public void RemoveAll()
        {
            m_CommonLens.RemoveAll();
            m_Lens?.RemoveAll();
            m_Transitions?.RemoveAll();
            m_YAxis?.RemoveAll();
            m_YAxisRecentering?.RemoveAll();
            m_XAxis?.RemoveAll();
            m_Heading?.RemoveAll();
            m_RecenterToTargetHeading?.RemoveAll();
            m_BindingMode.RemoveAll();
            m_SplineCurvature.RemoveAll();
            for(int i = 0;i < (m_Orbits?.Length ?? 0);i++)
            {
                m_Orbits?[i].RemoveAll();            }

            for(int i = 0;i < (m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                m_ExcludedPropertiesInInspector?[i].RemoveAll();            }

            for(int i = 0;i < (m_LockStageInInspector?.Length ?? 0);i++)
            {
                m_LockStageInInspector?[i].RemoveAll();            }

            m_Priority.RemoveAll();
            FollowTargetAttachment.RemoveAll();
            LookAtTargetAttachment.RemoveAll();
            m_StandbyUpdate.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineFreeLook target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_CommonLens.IsUse) target.m_CommonLens = m_CommonLens.IsExpression ? !Mathf.Approximately(m_CommonLens.Value, 0) : m_CommonLens.PrimitiveValue;
            // 处理字段 m_Lens
            // 生成递归代码
            m_Lens?.ControlCinemachine(ref target.m_Lens, templateDict);
            // 处理字段 m_Transitions
            // 生成递归代码
            m_Transitions?.ControlCinemachine(ref target.m_Transitions, templateDict);
            // 处理字段 m_YAxis
            // 生成递归代码
            m_YAxis?.ControlCinemachine(ref target.m_YAxis, templateDict);
            // 处理字段 m_YAxisRecentering
            // 生成递归代码
            m_YAxisRecentering?.ControlCinemachine(ref target.m_YAxisRecentering, templateDict);
            // 处理字段 m_XAxis
            // 生成递归代码
            m_XAxis?.ControlCinemachine(ref target.m_XAxis, templateDict);
            // 处理字段 m_Heading
            // 生成递归代码
            m_Heading?.ControlCinemachine(ref target.m_Heading, templateDict);
            // 处理字段 m_RecenterToTargetHeading
            // 生成递归代码
            m_RecenterToTargetHeading?.ControlCinemachine(ref target.m_RecenterToTargetHeading, templateDict);
            if (m_BindingMode.IsUse) target.m_BindingMode = m_BindingMode.IsExpression ? (Cinemachine.CinemachineTransposer.BindingMode)m_BindingMode.Value :m_BindingMode.PrimitiveValue;
            if (m_SplineCurvature.IsUse && templateDict.ContainsKey(m_SplineCurvature.Id))
            {
                var targetValue = (m_SplineCurvature.IsExpression ? m_SplineCurvature.Value : m_SplineCurvature.PrimitiveValue);
                target.m_SplineCurvature = Mathf.Approximately(0, templateDict[m_SplineCurvature.Id].Config.duration) ? targetValue : m_SplineCurvatureAlertInit + templateDict[m_SplineCurvature.Id].Config.alertCurve.Evaluate(templateDict[m_SplineCurvature.Id].CostTime / templateDict[m_SplineCurvature.Id].Config.duration) * (targetValue - m_SplineCurvatureAlertInit);
            }
            // 处理数组字段 m_Orbits
            for (int i = 0; i < (target.m_Orbits?.Length ?? 0); i++)
            {
                // 生成递归代码
                m_Orbits?[i].ControlCinemachine(ref target.m_Orbits[i], templateDict);
            }
            // 处理数组字段 m_ExcludedPropertiesInInspector
            for (int i = 0; i < (target.m_ExcludedPropertiesInInspector?.Length ?? 0); i++)
            {
                // 生成递归代码
                m_ExcludedPropertiesInInspector?[i].ControlCinemachine(ref target.m_ExcludedPropertiesInInspector[i], templateDict);
            }
            // 处理数组字段 m_LockStageInInspector
            for (int i = 0; i < (target.m_LockStageInInspector?.Length ?? 0); i++)
            {
                // 生成递归代码
                m_LockStageInInspector?[i].ControlCinemachine(ref target.m_LockStageInInspector[i], templateDict);
            }
            if (m_Priority.IsUse) target.m_Priority = m_Priority.IsExpression ? (System.Int32)m_Priority.Value :m_Priority.PrimitiveValue;
            if (FollowTargetAttachment.IsUse && templateDict.ContainsKey(FollowTargetAttachment.Id))
            {
                var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
                target.FollowTargetAttachment = Mathf.Approximately(0, templateDict[FollowTargetAttachment.Id].Config.duration) ? targetValue : FollowTargetAttachmentAlertInit + templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (targetValue - FollowTargetAttachmentAlertInit);
            }
            if (LookAtTargetAttachment.IsUse && templateDict.ContainsKey(LookAtTargetAttachment.Id))
            {
                var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
                target.LookAtTargetAttachment = Mathf.Approximately(0, templateDict[LookAtTargetAttachment.Id].Config.duration) ? targetValue : LookAtTargetAttachmentAlertInit + templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (targetValue - LookAtTargetAttachmentAlertInit);
            }
            if (m_StandbyUpdate.IsUse) target.m_StandbyUpdate = m_StandbyUpdate.IsExpression ? (Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode)m_StandbyUpdate.Value :m_StandbyUpdate.PrimitiveValue;
        }
    }
}
