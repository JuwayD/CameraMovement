using System;
using System.Collections.Generic;
using UnityEngine;

namespace CameraMovement
{
    /// <summary>
    /// 相机运镜控制区接口
    /// </summary>
    public interface ICameraMovementControlField
    {
        /// <summary>
        /// 作用于哪个cinemachine组件
        /// </summary>
        public Type AttachControlField { get;}

        /// <summary>
        /// 添加配置数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="id"></param>
        /// <param name="priority"></param>
        public void AddByConfig(CameraMovementControlConfigBase source,int id,int priority);

        /// <summary>
        /// 移除配置数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="id"></param>
        /// <param name="priority"></param>
        public void RemoveByConfig(CameraMovementControlConfigBase source,int id,int priority);

        /// <summary>
        /// 控制cinemachine的数据
        /// </summary>
        /// <param name="target"></param>
        public void ControlCinemachine(object target, Dictionary<int, RuntimeTemplate> templateDict);
    }
    
    /// <summary>
    /// 相机运镜控制区配置信息
    /// </summary>
    public abstract class CameraMovementControlConfigBase:ScriptableObject
    {
        /// <summary>
        /// 作用于哪中控制区
        /// </summary>
        public abstract Type AttachControlField { get; }
    }

}