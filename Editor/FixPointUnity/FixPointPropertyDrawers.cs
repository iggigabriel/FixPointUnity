using UnityEngine;
using UnityEditor;

namespace FixPointUnity.Editor
{
    [CustomPropertyDrawer(typeof(F32))]
    internal class F32PropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var rawProperty = property.FindPropertyRelative("Raw");

            var rawValue = Fixed32.ToFloat(rawProperty.intValue);

            EditorGUI.BeginChangeCheck();

            rawValue = EditorGUI.FloatField(position, label, rawValue);

            if (EditorGUI.EndChangeCheck()) rawProperty.intValue = Fixed32.FromFloat(rawValue);

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(F64))]
    internal class F64PropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var rawProperty = property.FindPropertyRelative("Raw");

            var rawValue = Fixed64.ToDouble(rawProperty.longValue);

            EditorGUI.BeginChangeCheck();

            rawValue = EditorGUI.DoubleField(position, label, rawValue);

            if (EditorGUI.EndChangeCheck()) rawProperty.longValue = Fixed64.FromDouble(rawValue);

            EditorGUI.EndProperty();
        }
    }

    internal abstract class VecPropertyDrawer : PropertyDrawer
    {
        protected abstract GUIContent[] Labels { get; }
        protected abstract float[] Values { get; }

        protected abstract float FromRaw(SerializedProperty property);
        protected abstract void ToRaw(SerializedProperty property, float value);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            for (int i = 0; i < Labels.Length; i++)
            {
                Values[i] = FromRaw(property.FindPropertyRelative($"Raw{Labels[i]}"));
            }

            EditorGUI.BeginChangeCheck();

            EditorGUI.MultiFloatField(position, label, Labels, Values);

            if (EditorGUI.EndChangeCheck())
            {
                for (int i = 0; i < Labels.Length; i++)
                {
                    ToRaw(property.FindPropertyRelative($"Raw{Labels[i]}"), Values[i]);
                }
            }

            EditorGUI.EndProperty();
        }
    }

    internal abstract class F32VecPropertyDrawer : VecPropertyDrawer
    {
        protected override float FromRaw(SerializedProperty property) => Fixed32.ToFloat(property.intValue);
        protected override void ToRaw(SerializedProperty property, float value) => property.intValue = Fixed32.FromFloat(value);
    }

    internal abstract class F64VecPropertyDrawer : VecPropertyDrawer
    {
        protected override float FromRaw(SerializedProperty property) => Fixed64.ToFloat(property.longValue);
        protected override void ToRaw(SerializedProperty property, float value) => property.longValue = Fixed64.FromFloat(value);
    }

    [CustomPropertyDrawer(typeof(F32Vec2))]
    internal class F32Vec2PropertyDrawer : F32VecPropertyDrawer
    {
        static readonly GUIContent[] labels = new GUIContent[] {
            new GUIContent("X"),
            new GUIContent("Y"),
        };

        static readonly float[] values = new float[2];

        protected override GUIContent[] Labels => labels;
        protected override float[] Values => values;
    }

    [CustomPropertyDrawer(typeof(F32Vec3))]
    internal class F32Vec3PropertyDrawer : F32VecPropertyDrawer
    {
        static readonly GUIContent[] labels = new GUIContent[] {
            new GUIContent("X"),
            new GUIContent("Y"),
            new GUIContent("Z"),
        };

        static readonly float[] values = new float[3];

        protected override GUIContent[] Labels => labels;
        protected override float[] Values => values;
    }

    [CustomPropertyDrawer(typeof(F32Vec4))]
    internal class F32Vec4PropertyDrawer : F32VecPropertyDrawer
    {
        static readonly GUIContent[] labels = new GUIContent[] {
            new GUIContent("X"),
            new GUIContent("Y"),
            new GUIContent("Z"),
            new GUIContent("W"),
        };

        static readonly float[] values = new float[4];

        protected override GUIContent[] Labels => labels;
        protected override float[] Values => values;
    }


    [CustomPropertyDrawer(typeof(F64Vec2))]
    internal class F64Vec2PropertyDrawer : F32VecPropertyDrawer
    {
        static readonly GUIContent[] labels = new GUIContent[] {
            new GUIContent("X"),
            new GUIContent("Y"),
        };

        static readonly float[] values = new float[2];

        protected override GUIContent[] Labels => labels;
        protected override float[] Values => values;
    }

    [CustomPropertyDrawer(typeof(F64Vec3))]
    internal class F64Vec3PropertyDrawer : F32VecPropertyDrawer
    {
        static readonly GUIContent[] labels = new GUIContent[] {
            new GUIContent("X"),
            new GUIContent("Y"),
            new GUIContent("Z"),
        };

        static readonly float[] values = new float[3];

        protected override GUIContent[] Labels => labels;
        protected override float[] Values => values;
    }

    [CustomPropertyDrawer(typeof(F64Vec4))]
    internal class F64Vec4PropertyDrawer : F32VecPropertyDrawer
    {
        static readonly GUIContent[] labels = new GUIContent[] {
            new GUIContent("X"),
            new GUIContent("Y"),
            new GUIContent("Z"),
            new GUIContent("W"),
        };

        static readonly float[] values = new float[4];

        protected override GUIContent[] Labels => labels;
        protected override float[] Values => values;
    }
}


