using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineFreeLook_Field :ICameraMovementControlField
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
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> LookAtTargetAttachment;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFreeLook_Config source = (CameraMovement.Control_C_CinemachineFreeLook_Config)sourceConfig;
            if(source.m_CommonLens.IsUse) m_CommonLens.Add(new MixItem<System.Boolean>(id, priority, source.m_CommonLens.CalculatorExpression, source.m_CommonLens.Value));
            m_Lens.AddByConfig(source.m_Lens, id, priority);
            m_Transitions.AddByConfig(source.m_Transitions, id, priority);
            m_YAxis.AddByConfig(source.m_YAxis, id, priority);
            m_YAxisRecentering.AddByConfig(source.m_YAxisRecentering, id, priority);
            m_XAxis.AddByConfig(source.m_XAxis, id, priority);
            m_Heading.AddByConfig(source.m_Heading, id, priority);
            m_RecenterToTargetHeading.AddByConfig(source.m_RecenterToTargetHeading, id, priority);
            if(source.m_BindingMode.IsUse) m_BindingMode.Add(new MixItem<Cinemachine.CinemachineTransposer.BindingMode>(id, priority, source.m_BindingMode.CalculatorExpression, source.m_BindingMode.Value));
            if(source.m_SplineCurvature.IsUse) m_SplineCurvature.Add(new MixItem<System.Single>(id, priority, source.m_SplineCurvature.CalculatorExpression, source.m_SplineCurvature.Value));
            for(int i = 0;i < m_Orbits.Length;i++)
            {
                m_Orbits[i].AddByConfig(source.m_Orbits[i], id, priority);            }

            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].AddByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].AddByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Add(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFreeLook_Config source = (CameraMovement.Control_C_CinemachineFreeLook_Config)sourceConfig;
            if(source.m_CommonLens.IsUse) m_CommonLens.Remove(new MixItem<System.Boolean>(id, priority, source.m_CommonLens.CalculatorExpression, source.m_CommonLens.Value));
            m_Lens.RemoveByConfig(source.m_Lens, id, priority);
            m_Transitions.RemoveByConfig(source.m_Transitions, id, priority);
            m_YAxis.RemoveByConfig(source.m_YAxis, id, priority);
            m_YAxisRecentering.RemoveByConfig(source.m_YAxisRecentering, id, priority);
            m_XAxis.RemoveByConfig(source.m_XAxis, id, priority);
            m_Heading.RemoveByConfig(source.m_Heading, id, priority);
            m_RecenterToTargetHeading.RemoveByConfig(source.m_RecenterToTargetHeading, id, priority);
            if(source.m_BindingMode.IsUse) m_BindingMode.Remove(new MixItem<Cinemachine.CinemachineTransposer.BindingMode>(id, priority, source.m_BindingMode.CalculatorExpression, source.m_BindingMode.Value));
            if(source.m_SplineCurvature.IsUse) m_SplineCurvature.Remove(new MixItem<System.Single>(id, priority, source.m_SplineCurvature.CalculatorExpression, source.m_SplineCurvature.Value));
            for(int i = 0;i < m_Orbits.Length;i++)
            {
                m_Orbits[i].RemoveByConfig(source.m_Orbits[i], id, priority);            }

            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].RemoveByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].RemoveByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Remove(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value));
        }
        public void RemoveAll()
        {
            m_CommonLens.RemoveAll();
            m_Lens.RemoveAll();
            m_Transitions.RemoveAll();
            m_YAxis.RemoveAll();
            m_YAxisRecentering.RemoveAll();
            m_XAxis.RemoveAll();
            m_Heading.RemoveAll();
            m_RecenterToTargetHeading.RemoveAll();
            m_BindingMode.RemoveAll();
            m_SplineCurvature.RemoveAll();
            for(int i = 0;i < m_Orbits.Length;i++)
            {
                m_Orbits[i].RemoveAll();            }

            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].RemoveAll();            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].RemoveAll();            }

            m_Priority.RemoveAll();
            FollowTargetAttachment.RemoveAll();
            LookAtTargetAttachment.RemoveAll();
            m_StandbyUpdate.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineFreeLook)targetObj;
            target.m_CommonLens = !Mathf.Approximately(m_CommonLens.Value, 0);
            // 处理字段 m_Lens
            // 生成递归代码
            m_Lens.ControlCinemachine(target.m_Lens, templateDict);
            // 处理字段 m_Transitions
            // 生成递归代码
            m_Transitions.ControlCinemachine(target.m_Transitions, templateDict);
            // 处理字段 m_YAxis
            // 生成递归代码
            m_YAxis.ControlCinemachine(target.m_YAxis, templateDict);
            // 处理字段 m_YAxisRecentering
            // 生成递归代码
            m_YAxisRecentering.ControlCinemachine(target.m_YAxisRecentering, templateDict);
            // 处理字段 m_XAxis
            // 生成递归代码
            m_XAxis.ControlCinemachine(target.m_XAxis, templateDict);
            // 处理字段 m_Heading
            // 生成递归代码
            m_Heading.ControlCinemachine(target.m_Heading, templateDict);
            // 处理字段 m_RecenterToTargetHeading
            // 生成递归代码
            m_RecenterToTargetHeading.ControlCinemachine(target.m_RecenterToTargetHeading, templateDict);
            target.m_BindingMode = (Cinemachine.CinemachineTransposer.BindingMode)m_BindingMode.Value;
            if (templateDict.ContainsKey(m_SplineCurvature.Id))
                target.m_SplineCurvature = templateDict[m_SplineCurvature.Id].Config.alertCurve.Evaluate(templateDict[m_SplineCurvature.Id].CostTime / templateDict[m_SplineCurvature.Id].Config.duration) * m_SplineCurvature.Value;
            target.m_SplineCurvature = (System.Single)m_SplineCurvature.Value;
            // 处理数组字段 m_Orbits
            for (int i = 0; i < m_Orbits.Length; i++)
            {
                // 生成递归代码
                m_Orbits[i].ControlCinemachine(target.m_Orbits[i], templateDict);
            }
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
            target.m_Priority = (System.Int32)m_Priority.Value;
            target.m_StandbyUpdate = (Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode)m_StandbyUpdate.Value;
        }
    }
}
