using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpriteInfo
{
    public float time;
    public string spriteName;
}

public class AnmationSpriteExtractor : EditorWindow
{
    private AnimationClip animationClip;
    private List<SpriteInfo> spriteInfoList = new List<SpriteInfo>();

    [MenuItem("Window/Animation Sprite Extractor")]

    public static void ShowWindow()
    {
        GetWindow<AnmationSpriteExtractor>("Animation Sprite Extractor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Extract Sprites Info form Animation Clip", EditorStyles.boldLabel);

        animationClip = EditorGUILayout.ObjectField("Animation Clip", animationClip, typeof(AnimationClip), true) as AnimationClip;

        if (animationClip != null)
        {
            if (GUILayout.Button("Extract Sprites Info"))
            {
                ExtractSpriteInfo(animationClip);
            }

            if (spriteInfoList.Count > 0)
            {
                GUILayout.Label("Sprite Info : " , EditorStyles.boldLabel);
                foreach (var spriteInfo in spriteInfoList)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Time:" , GUILayout.Width(50));
                    GUILayout.Label(spriteInfo.time.ToString(), GUILayout.Width(100));
                    GUILayout.Label("sprite : ", GUILayout.Width(50));
                    GUILayout.Label(spriteInfo.spriteName, GUILayout.Width(200));
                    GUILayout.EndHorizontal();

                }
            }
        }
    }

    private void ExtractSpriteInfo(AnimationClip Clip)
    {
        spriteInfoList.Clear();
        var bindings = AnimationUtility.GetObjectReferenceCurveBindings(Clip);

        foreach (var binding in bindings)
        {
            if (binding.propertyName.Contains("Sprite"))
            {
                var keyframes = AnimationUtility.GetObjectReferenceCurve(Clip, binding);

                foreach (var keyframe in keyframes)
                {
                    Sprite sprite = keyframe.value as Sprite;
                    if (sprite != null)
                    {
                        spriteInfoList.Add(new SpriteInfo { time = keyframe.time, spriteName = sprite.name });
                    }
                }
            }
        }
    }
}
