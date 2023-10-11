using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_LensSettings_Field :ICameraMovementControlField<Cinemachine.LensSettings>
    {
       public  Type AttachControlField => typeof(Cinemachine.LensSettings);

       [UnityEngine.TooltipAttribute("This is the camera view in degrees. Display will be in vertical degress, unless the associated camera has its FOV axis setting set to Horizontal, in which case display will be in horizontal degress.  Internally, it is always vertical degrees.  For cinematic people, a 50mm lens on a super-35mm sensor would equal a 19.6 degree FOV")]
            public DataMixer <System.Single> FieldOfView;
       [UnityEngine.TooltipAttribute("When using an orthographic camera, this defines the half-height, in world coordinates, of the camera view.")]
            public DataMixer <System.Single> OrthographicSize;
       [UnityEngine.TooltipAttribute("This defines the near region in the renderable range of the camera frustum. Raising this value will stop the game from drawing things near the camera, which can sometimes come in handy.  Larger values will also increase your shadow resolution.")]
            public DataMixer <System.Single> NearClipPlane;
       [UnityEngine.TooltipAttribute("This defines the far region of the renderable range of the camera frustum. Typically you want to set this value as low as possible without cutting off desired distant objects")]
            public DataMixer <System.Single> FarClipPlane;
       [UnityEngine.TooltipAttribute("Camera Z roll, or tilt, in degrees.")]
            public DataMixer <System.Single> Dutch;
       [UnityEngine.TooltipAttribute("Allows you to select a different camera mode to apply to the Camera component when Cinemachine activates this Virtual Camera.  The changes applied to the Camera component through this setting will remain after the Virtual Camera deactivation.")]
            public DataMixer <Cinemachine.LensSettings.OverrideModes> ModeOverride;
        public DataMixer <UnityEngine.Camera.GateFitMode> GateFit;
        public DataMixer <System.Single> FocusDistance;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_LensSettings_Config source = (CameraMovement.Control_C_LensSettings_Config)sourceConfig;
            if(source.FieldOfView.IsUse) FieldOfView.Add(new MixItem<System.Single>(id, priority, source.FieldOfView.CalculatorExpression, source.FieldOfView.Value, source.FieldOfView.IsUse));
            if(source.OrthographicSize.IsUse) OrthographicSize.Add(new MixItem<System.Single>(id, priority, source.OrthographicSize.CalculatorExpression, source.OrthographicSize.Value, source.OrthographicSize.IsUse));
            if(source.NearClipPlane.IsUse) NearClipPlane.Add(new MixItem<System.Single>(id, priority, source.NearClipPlane.CalculatorExpression, source.NearClipPlane.Value, source.NearClipPlane.IsUse));
            if(source.FarClipPlane.IsUse) FarClipPlane.Add(new MixItem<System.Single>(id, priority, source.FarClipPlane.CalculatorExpression, source.FarClipPlane.Value, source.FarClipPlane.IsUse));
            if(source.Dutch.IsUse) Dutch.Add(new MixItem<System.Single>(id, priority, source.Dutch.CalculatorExpression, source.Dutch.Value, source.Dutch.IsUse));
            if(source.ModeOverride.IsUse) ModeOverride.Add(new MixItem<Cinemachine.LensSettings.OverrideModes>(id, priority, source.ModeOverride.CalculatorExpression, source.ModeOverride.Value, source.ModeOverride.IsUse));
            if(source.GateFit.IsUse) GateFit.Add(new MixItem<UnityEngine.Camera.GateFitMode>(id, priority, source.GateFit.CalculatorExpression, source.GateFit.Value, source.GateFit.IsUse));
            if(source.FocusDistance.IsUse) FocusDistance.Add(new MixItem<System.Single>(id, priority, source.FocusDistance.CalculatorExpression, source.FocusDistance.Value, source.FocusDistance.IsUse));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_LensSettings_Config source = (CameraMovement.Control_C_LensSettings_Config)sourceConfig;
            if(source.FieldOfView.IsUse) FieldOfView.Remove(new MixItem<System.Single>(id, priority, source.FieldOfView.CalculatorExpression, source.FieldOfView.Value, source.FieldOfView.IsUse));
            if(source.OrthographicSize.IsUse) OrthographicSize.Remove(new MixItem<System.Single>(id, priority, source.OrthographicSize.CalculatorExpression, source.OrthographicSize.Value, source.OrthographicSize.IsUse));
            if(source.NearClipPlane.IsUse) NearClipPlane.Remove(new MixItem<System.Single>(id, priority, source.NearClipPlane.CalculatorExpression, source.NearClipPlane.Value, source.NearClipPlane.IsUse));
            if(source.FarClipPlane.IsUse) FarClipPlane.Remove(new MixItem<System.Single>(id, priority, source.FarClipPlane.CalculatorExpression, source.FarClipPlane.Value, source.FarClipPlane.IsUse));
            if(source.Dutch.IsUse) Dutch.Remove(new MixItem<System.Single>(id, priority, source.Dutch.CalculatorExpression, source.Dutch.Value, source.Dutch.IsUse));
            if(source.ModeOverride.IsUse) ModeOverride.Remove(new MixItem<Cinemachine.LensSettings.OverrideModes>(id, priority, source.ModeOverride.CalculatorExpression, source.ModeOverride.Value, source.ModeOverride.IsUse));
            if(source.GateFit.IsUse) GateFit.Remove(new MixItem<UnityEngine.Camera.GateFitMode>(id, priority, source.GateFit.CalculatorExpression, source.GateFit.Value, source.GateFit.IsUse));
            if(source.FocusDistance.IsUse) FocusDistance.Remove(new MixItem<System.Single>(id, priority, source.FocusDistance.CalculatorExpression, source.FocusDistance.Value, source.FocusDistance.IsUse));
        }
        public void RemoveAll()
        {
            FieldOfView.RemoveAll();
            OrthographicSize.RemoveAll();
            NearClipPlane.RemoveAll();
            FarClipPlane.RemoveAll();
            Dutch.RemoveAll();
            ModeOverride.RemoveAll();
            GateFit.RemoveAll();
            FocusDistance.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.LensSettings target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (FieldOfView.IsUse && templateDict.ContainsKey(FieldOfView.Id))
                target.FieldOfView = Mathf.Approximately(0, templateDict[FieldOfView.Id].Config.duration) ? (FieldOfView.IsExpression ? FieldOfView.Value : FieldOfView.PrimitiveValue) : templateDict[FieldOfView.Id].Config.alertCurve.Evaluate(templateDict[FieldOfView.Id].CostTime / templateDict[FieldOfView.Id].Config.duration) * (FieldOfView.IsExpression ? FieldOfView.Value : FieldOfView.PrimitiveValue);
            if (OrthographicSize.IsUse && templateDict.ContainsKey(OrthographicSize.Id))
                target.OrthographicSize = Mathf.Approximately(0, templateDict[OrthographicSize.Id].Config.duration) ? (OrthographicSize.IsExpression ? OrthographicSize.Value : OrthographicSize.PrimitiveValue) : templateDict[OrthographicSize.Id].Config.alertCurve.Evaluate(templateDict[OrthographicSize.Id].CostTime / templateDict[OrthographicSize.Id].Config.duration) * (OrthographicSize.IsExpression ? OrthographicSize.Value : OrthographicSize.PrimitiveValue);
            if (NearClipPlane.IsUse && templateDict.ContainsKey(NearClipPlane.Id))
                target.NearClipPlane = Mathf.Approximately(0, templateDict[NearClipPlane.Id].Config.duration) ? (NearClipPlane.IsExpression ? NearClipPlane.Value : NearClipPlane.PrimitiveValue) : templateDict[NearClipPlane.Id].Config.alertCurve.Evaluate(templateDict[NearClipPlane.Id].CostTime / templateDict[NearClipPlane.Id].Config.duration) * (NearClipPlane.IsExpression ? NearClipPlane.Value : NearClipPlane.PrimitiveValue);
            if (FarClipPlane.IsUse && templateDict.ContainsKey(FarClipPlane.Id))
                target.FarClipPlane = Mathf.Approximately(0, templateDict[FarClipPlane.Id].Config.duration) ? (FarClipPlane.IsExpression ? FarClipPlane.Value : FarClipPlane.PrimitiveValue) : templateDict[FarClipPlane.Id].Config.alertCurve.Evaluate(templateDict[FarClipPlane.Id].CostTime / templateDict[FarClipPlane.Id].Config.duration) * (FarClipPlane.IsExpression ? FarClipPlane.Value : FarClipPlane.PrimitiveValue);
            if (Dutch.IsUse && templateDict.ContainsKey(Dutch.Id))
                target.Dutch = Mathf.Approximately(0, templateDict[Dutch.Id].Config.duration) ? (Dutch.IsExpression ? Dutch.Value : Dutch.PrimitiveValue) : templateDict[Dutch.Id].Config.alertCurve.Evaluate(templateDict[Dutch.Id].CostTime / templateDict[Dutch.Id].Config.duration) * (Dutch.IsExpression ? Dutch.Value : Dutch.PrimitiveValue);
            if (ModeOverride.IsUse) target.ModeOverride = ModeOverride.IsExpression ? (Cinemachine.LensSettings.OverrideModes)ModeOverride.Value :ModeOverride.PrimitiveValue;
            if (GateFit.IsUse) target.GateFit = GateFit.IsExpression ? (UnityEngine.Camera.GateFitMode)GateFit.Value :GateFit.PrimitiveValue;
            if (FocusDistance.IsUse && templateDict.ContainsKey(FocusDistance.Id))
                target.FocusDistance = Mathf.Approximately(0, templateDict[FocusDistance.Id].Config.duration) ? (FocusDistance.IsExpression ? FocusDistance.Value : FocusDistance.PrimitiveValue) : templateDict[FocusDistance.Id].Config.alertCurve.Evaluate(templateDict[FocusDistance.Id].CostTime / templateDict[FocusDistance.Id].Config.duration) * (FocusDistance.IsExpression ? FocusDistance.Value : FocusDistance.PrimitiveValue);
        }
    }
}
