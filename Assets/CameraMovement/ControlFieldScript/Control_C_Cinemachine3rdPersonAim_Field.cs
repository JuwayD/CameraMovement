using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_Cinemachine3rdPersonAim_Field :ICameraMovementControlField<Cinemachine.Cinemachine3rdPersonAim>
    {
       public  Type AttachControlField => typeof(Cinemachine.Cinemachine3rdPersonAim);

       [UnityEngine.TooltipAttribute("Objects with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
            public DataMixer <System.String> IgnoreTag;
       [UnityEngine.TooltipAttribute("How far to project the object detection ray")]
            public DataMixer <System.Single> AimDistance;
        public float AimDistanceAlertInit;
        public float AimDistanceDiff;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.Cinemachine3rdPersonAim target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_Cinemachine3rdPersonAim_Config source = (CameraMovement.Control_C_Cinemachine3rdPersonAim_Config)sourceConfig;
            if(source.IgnoreTag.IsUse)
            {
                IgnoreTag.Add(new MixItem<System.String>(id, priority, source.IgnoreTag.CalculatorExpression, source.IgnoreTag.Value, source.IgnoreTag.IsUse));
            }
            if(source.AimDistance.IsUse)
            {
                AimDistance.Add(new MixItem<System.Single>(id, priority, source.AimDistance.CalculatorExpression, source.AimDistance.Value, source.AimDistance.IsUse));
               var targetValue = (AimDistance.IsExpression ? AimDistance.Value : AimDistance.PrimitiveValue);
               AimDistanceDiff = targetValue - target.AimDistance;
               AimDistanceAlertInit = target.AimDistance - templateDict[AimDistance.Id].Config.alertCurve.Evaluate(templateDict[AimDistance.Id].CostTime / templateDict[AimDistance.Id].Config.duration) * (AimDistanceDiff);
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.Cinemachine3rdPersonAim target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_Cinemachine3rdPersonAim_Config source = (CameraMovement.Control_C_Cinemachine3rdPersonAim_Config)sourceConfig;
            if(source.IgnoreTag.IsUse)
            {
                IgnoreTag.Remove(new MixItem<System.String>(id, priority, source.IgnoreTag.CalculatorExpression, source.IgnoreTag.Value, source.IgnoreTag.IsUse));
            }
            if(source.AimDistance.IsUse)
            {
                AimDistance.Remove(new MixItem<System.Single>(id, priority, source.AimDistance.CalculatorExpression, source.AimDistance.Value, source.AimDistance.IsUse));
               var targetValue = (AimDistance.IsExpression ? AimDistance.Value : AimDistance.PrimitiveValue);
               AimDistanceDiff = targetValue - target.AimDistance;
               AimDistanceAlertInit = target.AimDistance - templateDict[AimDistance.Id].Config.alertCurve.Evaluate(templateDict[AimDistance.Id].CostTime / templateDict[AimDistance.Id].Config.duration) * (AimDistanceDiff);
            }
        }
        public void RemoveAll()
        {
            IgnoreTag.RemoveAll();
            AimDistance.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.Cinemachine3rdPersonAim target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (IgnoreTag.IsUse) target.IgnoreTag = IgnoreTag.PrimitiveValue;
            if (AimDistance.IsUse && templateDict.ContainsKey(AimDistance.Id))
            {
                var targetValue = (AimDistance.IsExpression ? AimDistance.Value : AimDistance.PrimitiveValue);
                target.AimDistance = Mathf.Approximately(0, templateDict[AimDistance.Id].Config.duration) ? targetValue : AimDistanceAlertInit + templateDict[AimDistance.Id].Config.alertCurve.Evaluate(templateDict[AimDistance.Id].CostTime / templateDict[AimDistance.Id].Config.duration) * AimDistanceDiff;
            }
        }
    }
}
