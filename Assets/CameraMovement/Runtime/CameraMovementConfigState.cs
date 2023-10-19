using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CameraMovement
{
    [CreateAssetMenu(menuName = "创建相机配置状态")]
    [LabelText("TypeName")]
    public class CameraMovementConfigState : SerializedScriptableObject
    {
        public string TypeName;
        
        [ListDrawerSettings(ListElementLabelName = "Title")]
        public List<CameraMovementConfig> ConfigList;
    }
}