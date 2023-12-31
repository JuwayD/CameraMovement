using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = System.Diagnostics.Debug;
using Object = UnityEngine.Object;

namespace CameraMovement
{
    public static class GenerateScriptTool
    {
        [MenuItem("Tools/CameraMovement/GenerateAll")]
        public static void GenerateAll()
        {
            GenerateControlFieldConfigScript();
            GenerateDataFieldConfigScript();
            AssetDatabase.Refresh();
            GenerateControlFieldScript();
        }
        
        [MenuItem("Tools/CameraMovement/GenerateControlFieldConfigScript")]
        public static void GenerateControlFieldConfigScript()
        {
            // 获取当前应用程序域中加载的所有程序集
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // 使用 LINQ 查询来查找所有实现了指定接口的类型
            IEnumerable<Type> implementingTypes = assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => (typeof(CinemachineComponentBase).IsAssignableFrom(type) 
                                || typeof(CinemachineExtension).IsAssignableFrom(type) 
                                || typeof(CinemachineVirtualCameraBase).IsAssignableFrom(type)) 
                               && !type.IsInterface && !type.IsAbstract);
            CodeGenerator.GenerateTypeList.Clear();
            foreach (var type in implementingTypes)
            {
                CodeGenerator.GenerateCodeForSerializableType(type, "Control", $"{Application.dataPath}/CameraMovement/ControlConfigScript", checkSerializable: false, needClass: true, implementInterface: "CameraMovementControlConfigBase");
            }
            AssetDatabase.Refresh();
        }
        
        [MenuItem("Tools/CameraMovement/GenerateDataFieldConfigScript")]
        public static void GenerateDataFieldConfigScript()
        {
            // 获取当前应用程序域中加载的所有程序集
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // 使用 LINQ 查询来查找所有实现了ICameraMovementDataField接口的类型
            IEnumerable<Type> implementingTypes = assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(ICameraMovementDataField).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
            CodeGenerator.GenerateTypeList.Clear();
            foreach (var type in implementingTypes)
            {
                CodeGenerator.GenerateCodeForSerializableType(type, "Data", $"{Application.dataPath}/CameraMovement/DataConfigScript", checkSerializable: false, needClass: true, implementInterface: "CameraMovementDataConfigBase", memberCheck: info => !info.GetCustomAttribute<ContextDescriptionAttribute>()?.isReadOnly ?? false);
            }
            AssetDatabase.Refresh();
        }
        
        [MenuItem("Tools/CameraMovement/GenerateControlFieldScript")]
        public static void GenerateControlFieldScript()
        {
            // 获取当前应用程序域中加载的所有程序集
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // 使用 LINQ 查询来查找所有实现了指定接口的类型
            IEnumerable<Type> implementingTypes = assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => (typeof(CinemachineComponentBase).IsAssignableFrom(type) 
                                || typeof(CinemachineExtension).IsAssignableFrom(type) 
                                || typeof(CinemachineVirtualCameraBase).IsAssignableFrom(type)) 
                               && !type.IsInterface && !type.IsAbstract);
            CodeGenerator.GenerateTypeList.Clear();
            foreach (var type in implementingTypes)
            {
                CodeGenerator.GenerateCodeForSerializableType(type, "Control", $"{Application.dataPath}/CameraMovement/ControlFieldScript", checkSerializable: false, needClass: true, implementInterface: "ICameraMovementControlField");
            }
            AssetDatabase.Refresh();
        }

    }

    public static class CodeGenerator
    {
        public static List<Type> GenerateTypeList = new List<Type>();
        
        public static void GenerateCodeForSerializableType(Type type, string prefix, string outputDirectory,
            bool checkSerializable = true, bool needClass = false, string implementInterface = "",
            Func<FieldInfo, bool> memberCheck = null)
        {
            if (GenerateTypeList.Contains(type))
            {
                return;
            }
            if (!checkSerializable || type.IsSerializable)
            {
                var name = autoGetArrayElementTypeFullName(type);
                name = simplifyTypeName(name);
                //构造前缀，如果实现的是field接口那么久继承field接口，
                StringBuilder code = new StringBuilder(
                    $"using System;\nusing System.Collections.Generic;\nusing UnityEngine;\nusing UnityEditor;\nusing CameraMovement;\n\nnamespace CameraMovement{{\n" +
                    $"    public {(needClass ? "class" : "struct")} {prefix}_{name}_{(implementInterface.Contains("Field") ? "Field" : "Config")} :{implementInterface}{(implementInterface.Contains("Field") ? $"<{autoGetArrayElementTypeFullName(type)}>" : "")}\n    {{\n" +
                    $"       public {(implementInterface.Contains("Field") ? "" : "override")} Type Attach{prefix}Field => typeof({getFullName(type)});\n\n");
                // 如果类型不可序列化，继续检查它的字段和属性
                Debug.Assert(type != null, nameof(type) + " != null");
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                foreach (var field in fields)
                {
                    Type fieldType = field.FieldType;
                    if (fieldType.IsArray)
                    {
                        Type elementType = field.FieldType.GetElementType();
                        if ((elementType.FullName.Contains("DataMixer") && elementType.FullName.Contains("CameraMovement") && mapTypeCheck(elementType.GenericTypeArguments[0]) || mapTypeCheck(elementType)) && (memberCheck?.Invoke(field) ?? true))
                        {
                            // 如果字段是基元类型，为它进行封装
                            code.Append(generateCodeForSerializableStructWithBool(field, implementInterface.Contains("Config"), fieldType.IsArray));
                        
                        }
                        else if(elementType.IsSerializable && (memberCheck?.Invoke(field) ?? true))
                        {
                            // 如果字段是非基元类型,且可序列化，递归调用该函数
                            GenerateCodeForSerializableType(elementType, prefix, outputDirectory, needClass: true, implementInterface: implementInterface);
                            string attributes = getCustomAttributesString(field);
                            string typeName = elementType.IsArray ? elementType.GetElementType()?.FullName : elementType.FullName;
                            typeName = simplifyTypeName(typeName);
                            code.Append($"{attributes}    public {prefix}_{typeName}_{(implementInterface.Contains("Field") ? "Field" : "Config")}[] {field.Name};\n");
                        }
                    }
                    else
                    {
                        if ((fieldType.FullName.Contains("DataMixer") && fieldType.FullName.Contains("CameraMovement") && mapTypeCheck(fieldType.GenericTypeArguments[0]) || mapTypeCheck(fieldType)) && (memberCheck?.Invoke(field) ?? true))
                        {
                            // 如果字段是基元类型，为它进行封装
                            code.Append(generateCodeForSerializableStructWithBool(field, implementInterface.Contains("Config"), fieldType.IsArray));
                        
                        }
                        else if(fieldType.IsSerializable && (memberCheck?.Invoke(field) ?? true))
                        {
                            // 如果字段是非基元类型,且可序列化，递归调用该函数
                            GenerateCodeForSerializableType(fieldType, prefix, outputDirectory, needClass: true, implementInterface: implementInterface);
                            string attributes = getCustomAttributesString(field);
                            string typeName = fieldType.IsArray ? fieldType.GetElementType()?.FullName : fieldType.FullName;
                            typeName = simplifyTypeName(typeName);
                            code.Append($"{attributes}    public {prefix}_{typeName}_{(implementInterface.Contains("Field") ? "Field" : "Config")} {field.Name};\n");
                        }
                    }
                }
                
                //如果需要实现Field相关接口
                if (implementInterface.Contains("Field") && type.FullName != null)
                {
                    // 获取当前应用程序域中加载的所有程序集
                    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

                    // 使用 LINQ 查询来查找所有实现了指定接口的类型
                    IEnumerable<Type> implementingTypes = assemblies
                        .SelectMany(assembly => assembly.GetTypes())
                        .Where(type => (typeof(CameraMovementControlConfigBase).IsAssignableFrom(type) ) 
                                       && !type.IsInterface && !type.IsAbstract);
                    string typeName = type.IsArray ? type.GetElementType()?.FullName : type.FullName;
                    typeName = simplifyTypeName(typeName);
                    Type sourceType = null;
                    //遍历所有实现了controlConfig接口的类，如果名字里包含正在遍历的对象的名字那么就是这个类型
                    foreach (var implementingType in implementingTypes)
                    {
                        if (!string.IsNullOrEmpty(typeName) && (implementingType.FullName?.Contains(typeName) ?? false))
                        {
                            sourceType = implementingType;
                            break;
                        }
                    }
                    if (sourceType != null)
                    {
                        code.Append(generateUpdateMethodCode(sourceType, type, fields, prefix + "_", "_" + (implementInterface.Contains("Field") ? "Field" : "Config")));
                        code.Append(generateUpdateMethodCode(sourceType, type, fields, prefix + "_", "_" + (implementInterface.Contains("Field") ? "Field" : "Config"), true));
                        code.Append(generateRemoveAllMethodCode(sourceType, fields));
                    }
                }
                
                //如果需要实现Field相关接口
                if (implementInterface.Contains("Field") && type.FullName != null)
                {
                    code.Append(GenerateCinemachineControl(type, fields, $"{prefix}_{name}_{(implementInterface.Contains("Field") ? "Field" : "Config")}"));
                }
                
                GenerateTypeList.Add(type);
                code.Append("    }\n}\n");
                // 将代码写入文件
                string filePath = Path.Combine(outputDirectory, prefix + "_" + name + "_" + (implementInterface.Contains("Field") ? "Field" : "Config") + ".cs");
                File.WriteAllText(filePath, code.ToString());
            }
        }

        /// <summary>
        /// 获取元素类型没有元素则是当前类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string autoGetArrayElementTypeFullName(Type type)
        {
            string name = type.IsArray ? getFullName(type.GetElementType()) : getFullName(type);
            return name;
        }

        /// <summary>
        /// 需要用曲线计算的字段初始值的后缀
        /// </summary>
        const string CURVE_FIELD_POST_FIX_ = "AlertInit";
        /// <summary>
        /// 使用曲线计算的字段的差值后缀
        /// </summary>
        const string CURVE_FIELD_Diff_ = "Diff";
        private static string generateCodeForSerializableStructWithBool(FieldInfo field, bool useConfig = false,
            bool IsArray = false)
        {
            //包装进容器

            if (IsArray)
            {
                var fieldType = field.FieldType.FullName.Contains("DataMixer") && field.FieldType.FullName.Contains("CameraMovement")
                    ? field.FieldType.GetElementType().GenericTypeArguments[0]
                    : field.FieldType.GetElementType();
                string attributes = getCustomAttributesString(field);
                string code = $"";
                code += $"{attributes}        public {(useConfig ? "ConfigItem" : "DataMixer")}<{getFullName(fieldType)}>[] {field.Name};\n";
                if (!useConfig && (field.FieldType == typeof(float) || field.FieldType == typeof(double)))//如果是控制区或者数据区字段为其生成用于存储曲线变化开始前的值，方便后续曲线运算
                {
                    code += $"        public float[] {field.Name}{CURVE_FIELD_POST_FIX_};\n";
                    code += $"        public float[] {field.Name}{CURVE_FIELD_Diff_};\n";
                }
                return code;
            }
            else
            {
                var fieldType = field.FieldType.FullName.Contains("DataMixer") && field.FieldType.FullName.Contains("CameraMovement")
                    ? field.FieldType.GenericTypeArguments[0]
                    : field.FieldType;
                string attributes = getCustomAttributesString(field);
                string code = $"";
                code += $"{attributes}        public {(useConfig ? "ConfigItem" : "DataMixer")} <{getFullName(fieldType)}> {field.Name};\n";
                if (!useConfig && (field.FieldType == typeof(float) || field.FieldType == typeof(double)))//如果是控制区或者数据区字段为其生成用于存储曲线变化开始前的值，方便后续曲线运算
                {
                    code += $"        public float {field.Name}{CURVE_FIELD_POST_FIX_};\n";
                    code += $"        public float {field.Name}{CURVE_FIELD_Diff_};\n";
                }
                return code;
            }
        }
        
        //获取attribute
        private static string getCustomAttributesString(MemberInfo member)
        {
            string attributes = string.Empty;
            object[] customAttributes = member.GetCustomAttributes(true);

            foreach (object attribute in customAttributes)
            {
                var fullName = getFullName(attribute.GetType());
                if (attribute is TooltipAttribute toolTip)
                {
                    attributes += $"       [{fullName}(\"{toolTip.tooltip}\")]\n    ";
                }
                else if (attribute is HeaderAttribute header)
                {
                    attributes += $"       [{fullName}(\"{header.header}\")]\n    ";
                }
                else if (attribute is ContextDescriptionAttribute { isReadOnly: false } description)
                {
                    attributes += $"       [{typeof(TooltipAttribute).FullName}(\"{description.description}\")]\n    ";
                }
                else if (attribute is HideInInspector or NonSerializedAttribute)
                {
                    attributes += $"       [{fullName}]\n    ";
                }
            }

            return attributes;
        }

        private static string getFullName(Type type)
        {
            return type.FullName?.Replace('+', '.') ?? "";
        }

        #region 映射部分

        /// <summary>
        /// 生成控制区数据更新方法的代码
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="cinemachineType"></param>
        /// <param name="targetFields"></param>
        /// <param name="prefix"></param>
        /// <param name="postfix"></param>
        /// <param name="isRemove"></param>
        private static string generateUpdateMethodCode(Type sourceType, Type cinemachineType, FieldInfo[] targetFields,
            string prefix,
            string postfix,
            bool isRemove = false)
        {
            // 获取源类型和目标类型的所有字段
            FieldInfo[] sourceFields = sourceType.GetFields();

            StringBuilder codeBuilder = new StringBuilder();

            // 生成函数签名
            var methodPrefix = isRemove ? "Remove" : "Add";
            codeBuilder.AppendLine($"        public void {methodPrefix}ByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref {autoGetArrayElementTypeFullName(cinemachineType)} target, Dictionary<int, RuntimeTemplate> templateDict)");
            codeBuilder.AppendLine("        {");
            codeBuilder.AppendLine($"            if(sourceConfig == null) return;");
            codeBuilder.AppendLine($"            if(sourceConfig.AttachControlField != AttachControlField) return;");
            codeBuilder.AppendLine($"            {sourceType.FullName} source = ({sourceType.FullName})sourceConfig;");

            foreach (var targetField in targetFields)
            {
                // 查找具有相同名称的源字段
                var sourceField = sourceFields.FirstOrDefault(f => f.Name == targetField.Name);

                if (sourceField != null)
                {
                        // 生成基元类型字段赋值语句
                        if (targetField.FieldType.IsArray)
                        {
                            var name = autoGetArrayElementTypeFullName(targetField.FieldType);
                            name = prefix + simplifyTypeName(name) + postfix;
                            //如果不是移除就需要把字段先创建出来
                            if (!mapTypeCheck(targetField.FieldType.GetElementType()) && !isRemove) codeBuilder.AppendLine($"                if(source.{sourceField.Name} != null && {targetField.Name} == null) {targetField.Name} = new {name}[source.{sourceField.Name}.Length];");
                            codeBuilder.AppendLine($"            for(int i = 0;i < ({sourceField.Name}?.Length ?? 0);i++)");
                            codeBuilder.AppendLine($"            {{");
                            if (mapTypeCheck(targetField.FieldType.GetElementType()))//是映射类型就直接添加删除对应字段
                            {
                                codeBuilder.AppendLine($"                if(source.{sourceField.Name}[i].IsUse)");
                                codeBuilder.AppendLine($"                {{");
                                codeBuilder.AppendLine($"                    {targetField.Name}[i].{methodPrefix}(new MixItem<{getFullName(targetField.FieldType.GetElementType())}>(id, priority, source.{sourceField.Name}[i].CalculatorExpression, source.{sourceField.Name}[i].Value, source.{sourceField.Name}[i].IsUse));");
                                if (sourceField.FieldType.GenericTypeArguments.Length != 0 && (sourceField.FieldType.GenericTypeArguments[0] == typeof(float) || sourceField.FieldType.GenericTypeArguments[0] == typeof(double)))
                                {
                                    codeBuilder.AppendLine($"                   var targetValue = ({targetField.Name}[i].IsExpression ? {targetField.Name}[i].Value : {targetField.Name}[i].PrimitiveValue);");
                                    codeBuilder.AppendLine($"                   {targetField.Name}{CURVE_FIELD_Diff_}[i] = targetValue - target.{targetField.Name}[i];");
                                    codeBuilder.AppendLine($"                   if(templateDict[{targetField.Name}.Id].Config.alertCurve != null) {targetField.Name}{CURVE_FIELD_POST_FIX_}[i] = target.{targetField.Name}[i] - templateDict[{targetField.Name}.Id].Config.alertCurve.Evaluate(templateDict[{targetField.Name}.Id].CostTime / templateDict[{targetField.Name}.Id].Config.duration) * ({targetField.Name}{CURVE_FIELD_Diff_}[i]);");
                                }
                                codeBuilder.AppendLine($"                }}");
                            }
                            else//不是就递归调用
                            {
                                if (!isRemove)
                                {
                                    codeBuilder.AppendLine($"                if({targetField.Name}[i] == null) {targetField.Name}[i] = new {name}();");
                                }
                                codeBuilder.AppendLine($"                {targetField.Name}?[i]?.{methodPrefix}ByConfig(source.{sourceField.Name}[i], id, priority, ref target.{sourceField.Name}[i], templateDict);");
                            }
                            codeBuilder.AppendLine($"            }}");
                        }
                        else
                        {
                            if (mapTypeCheck(targetField.FieldType)) //是映射类型就直接添加删除对应字段
                            {
                                codeBuilder.AppendLine($"            if(source.{sourceField.Name}.IsUse)");
                                codeBuilder.AppendLine($"            {{");
                                codeBuilder.AppendLine($"                {targetField.Name}.{methodPrefix}(new MixItem<{getFullName(targetField.FieldType)}>(id, priority, source.{sourceField.Name}.CalculatorExpression, source.{sourceField.Name}.Value, source.{sourceField.Name}.IsUse));");
                                if (sourceField.FieldType.GenericTypeArguments.Length != 0 && (sourceField.FieldType.GenericTypeArguments[0] == typeof(float) || sourceField.FieldType.GenericTypeArguments[0] == typeof(double)))
                                {
                                    codeBuilder.AppendLine($"               var targetValue = ({targetField.Name}.IsExpression ? {targetField.Name}.Value : {targetField.Name}.PrimitiveValue);");
                                    codeBuilder.AppendLine($"               {targetField.Name}{CURVE_FIELD_Diff_} = targetValue - target.{targetField.Name};");
                                    codeBuilder.AppendLine($"               if(templateDict[{targetField.Name}.Id].Config.alertCurve != null) {targetField.Name}{CURVE_FIELD_POST_FIX_} = target.{targetField.Name} - templateDict[{targetField.Name}.Id].Config.alertCurve.Evaluate(templateDict[{targetField.Name}.Id].CostTime / templateDict[{targetField.Name}.Id].Config.duration) * ({targetField.Name}{CURVE_FIELD_Diff_});");
                                }
                                codeBuilder.AppendLine($"            }}");
                            }
                            else
                            {
                                if (!isRemove)
                                {
                                    var name = autoGetArrayElementTypeFullName(targetField.FieldType);
                                    name = prefix + simplifyTypeName(name) + postfix;
                                    codeBuilder.AppendLine($"            if(source.{sourceField.Name} != null && {targetField.Name} == null) {targetField.Name} = new {name}();");
                                }
                                codeBuilder.AppendLine($"            {targetField.Name}?.{methodPrefix}ByConfig(source.{sourceField.Name}, id, priority, ref target.{sourceField.Name}, templateDict);");
                            }
                        }
                }
            }

            codeBuilder.AppendLine("        }");

            return codeBuilder.ToString();
        }

        private static string generateRemoveAllMethodCode(Type sourceType, FieldInfo[] targetFields)
        {
            // 获取源类型和目标类型的所有字段
            FieldInfo[] sourceFields = sourceType.GetFields();

            StringBuilder codeBuilder = new StringBuilder();

            // 生成函数签名
            codeBuilder.AppendLine($"        public void RemoveAll()");
            codeBuilder.AppendLine("        {");

            foreach (var targetField in targetFields)
            {
                // 查找具有相同名称的源字段
                var sourceField = sourceFields.FirstOrDefault(f => f.Name == targetField.Name);

                if (sourceField != null)
                {
                    // 生成基元类型字段赋值语句
                    if (targetField.FieldType.IsArray)
                    {
                        codeBuilder.AppendLine($"            for(int i = 0;i < {targetField.Name}.Length;i++)");
                        codeBuilder.AppendLine($"            {{");
                        codeBuilder.AppendLine($"                {targetField.Name}[i].RemoveAll();");
                        codeBuilder.AppendLine($"            }}");
                    }
                    else
                    {
                        codeBuilder.AppendLine($"            {targetField.Name}.RemoveAll();");
                    }
                }
            }

            codeBuilder.AppendLine("        }");

            return codeBuilder.ToString();
        }

        /// <summary>
        /// 生成cinemachine控制代码
        /// </summary>
        /// <param name="type1">cinemachine扩展，相机，组件</param>
        /// <param name="fields2">控制区字段</param>
        /// <param name="controlTypeName"></param>
        /// <returns></returns>
        public static string GenerateCinemachineControl(Type type1, FieldInfo[] fields2, string controlTypeName)
        {
    
            FieldInfo[] fields1 = type1.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    
            StringBuilder code = new StringBuilder();
            code.AppendLine($"        public void ControlCinemachine(ref {autoGetArrayElementTypeFullName(type1)} target, Dictionary<int, RuntimeTemplate> templateDict)");
            code.AppendLine("        {");
            
            foreach (FieldInfo field2 in fields2)
            {
                string fieldName = field2.Name;
                
                FieldInfo correspondingField = Array.Find(fields1, f => f.Name == fieldName);

                if (correspondingField != null)
                {
                    if (field2.FieldType is { IsSerializable: true, IsArray: true } && correspondingField.FieldType.IsArray)
                    {
                        // 对于数组类型的字段，需要根据其元素类型生成代码
                        code.AppendLine($"            // 处理数组字段 {field2.Name}");
                        code.AppendLine($"            for (int i = 0; i < ({field2.Name}?.Length ?? 0); i++)");
                        code.AppendLine($"            {{");
                        code.AppendLine($"                // 生成递归代码");
                        if (field2.FieldType.IsSerializable && mapTypeCheck(field2.FieldType.GetElementType()))
                        {
                            if (field2.FieldType.GetElementType() == typeof(float) || field2.FieldType.GetElementType() == typeof(double))
                            {
                                code.AppendLine($"              if ({correspondingField.Name}[i].IsUse && templateDict.ContainsKey({correspondingField.Name}.Id))");
                                code.AppendLine($"              {{");
                                code.AppendLine($"                  var targetValue = ({correspondingField.Name}[i].IsExpression ? {correspondingField.Name}[i].Value : {correspondingField.Name}[i].PrimitiveValue);");
                                code.AppendLine($"                  target.{field2.Name}[i] = Mathf.Approximately(0, templateDict[{correspondingField.Name}.Id].Config.duration) ? targetValue : {correspondingField.Name}{CURVE_FIELD_POST_FIX_}[i] + templateDict[{correspondingField.Name}.Id].Config.alertCurve.Evaluate(templateDict[{correspondingField.Name}.Id].CostTime / templateDict[{correspondingField.Name}.Id].Config.duration) * {correspondingField.Name}{CURVE_FIELD_Diff_}[i];");
                                code.AppendLine($"              }}");
                            }
                            else if (field2.FieldType.GetElementType() == typeof(string))
                            {
                                code.AppendLine($"                if ({correspondingField.Name}[i].IsUse) target.{field2.Name}[i] = {correspondingField.Name}[i].PrimitiveValue;");
                            }
                            else if (field2.FieldType.GetElementType() == typeof(bool))
                            {
                                code.AppendLine($"                if ({correspondingField.Name}[i].IsUse) target.{field2.Name}[i] = {correspondingField.Name}[i].IsExpression ? !Mathf.Approximately({correspondingField.Name}[i].Value, 0) : {correspondingField.Name}[i].PrimitiveValue;");
                            }
                            else
                            {
                                code.AppendLine($"                if ({correspondingField.Name}[i].IsUse) target.{field2.Name}[i] = ({correspondingField.Name}[i].IsExpression ? ({getFullName(field2.FieldType.GetElementType())}){correspondingField.Name}[i].Value : ({getFullName(field2.FieldType.GetElementType())}){correspondingField.Name}[i].PrimitiveValue);");
                            }
                        }
                        else if (field2.FieldType.IsSerializable && !mapTypeCheck(field2.FieldType))
                        {
                            // 对于非基元类型的字段，需要生成递归代码
                            code.AppendLine($"            // 处理字段 {field2.Name}");
                            code.AppendLine($"            // 生成递归代码");
                            code.AppendLine($"            {correspondingField.Name}[i]?.ControlCinemachine(ref target.{field2.Name}[i], templateDict);");
                        }
                        code.AppendLine($"            }}");
                    }
                    else if (field2.FieldType.IsSerializable && mapTypeCheck(field2.FieldType))
                    {
                        if (field2.FieldType == typeof(float) || field2.FieldType == typeof(double))
                        {
                            code.AppendLine($"            if ({correspondingField.Name}.IsUse && templateDict.ContainsKey({correspondingField.Name}.Id))");
                            code.AppendLine($"            {{");
                            code.AppendLine($"                var targetValue = ({correspondingField.Name}.IsExpression ? {correspondingField.Name}.Value : {correspondingField.Name}.PrimitiveValue);");
                            code.AppendLine($"                target.{field2.Name} = Mathf.Approximately(0, templateDict[{correspondingField.Name}.Id].Config.duration) ? targetValue : {correspondingField.Name}{CURVE_FIELD_POST_FIX_} + templateDict[{correspondingField.Name}.Id].Config.alertCurve.Evaluate(templateDict[{correspondingField.Name}.Id].CostTime / templateDict[{correspondingField.Name}.Id].Config.duration) * {correspondingField.Name}{CURVE_FIELD_Diff_};");
                            code.AppendLine($"            }}");
                        }
                        else if (field2.FieldType == typeof(string))
                        {
                            code.AppendLine($"            if ({correspondingField.Name}.IsUse) target.{field2.Name} = {correspondingField.Name}.PrimitiveValue;");
                        }
                        else if (field2.FieldType == typeof(bool))
                        {
                            code.AppendLine($"            if ({correspondingField.Name}.IsUse) target.{field2.Name} = {correspondingField.Name}.IsExpression ? !Mathf.Approximately({correspondingField.Name}.Value, 0) : {correspondingField.Name}.PrimitiveValue;");
                        }
                        else
                        {
                            code.AppendLine($"            if ({correspondingField.Name}.IsUse) target.{field2.Name} = {correspondingField.Name}.IsExpression ? ({getFullName(field2.FieldType)}){correspondingField.Name}.Value :{correspondingField.Name}.PrimitiveValue;");
                        }
                    }
                    else if (field2.FieldType.IsSerializable && !mapTypeCheck(field2.FieldType))
                    {
                        // 对于非基元类型的字段，需要生成递归代码
                        code.AppendLine($"            // 处理字段 {field2.Name}");
                        code.AppendLine($"            // 生成递归代码");
                        code.AppendLine($"            {correspondingField.Name}?.ControlCinemachine(ref target.{field2.Name}, templateDict);");
                    }
                }
            }
            
            code.AppendLine("        }");
            return code.ToString();
        }

        /// <summary>
        /// 检查一个类型是否需要映射
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool mapTypeCheck(Type type)
        {
            return type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(Vector3) || type == typeof(Vector3Int) || type == typeof(Matrix4x4) || type == typeof(AnimationCurve) || type == typeof(Quaternion);
        }

        private static string simplifyTypeName(string fullName)
        {
            // 替换非字母数字字符为下划线
            string simplifiedName = Regex.Replace(fullName, "[^a-zA-Z0-9_]+", "_");

            // 分割类型名称
            string[] typeParts = simplifiedName.Split('_');

            // 简化类型名称为每个单词的首字母组合
            for (int i = 0; i < typeParts.Length - 1; i++)
            {
                StringBuilder resultBuilder = new StringBuilder();

                foreach (char character in typeParts[i])
                {
                    if (Char.IsUpper(character))
                    {
                        resultBuilder.Append(character);
                    }
                }

                typeParts[i] = resultBuilder.ToString();
            }

            // 重新组合类型名称
            string simplifiedTypeName = string.Join("_", typeParts);

            return simplifiedTypeName;
        }
        
        #endregion
    }

}