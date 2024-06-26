using UnityEngine;
using UnityEditor;

namespace Unity.VisualScripting
{
    public class AssemblyOptionsSettings
    {
        private const string CompleteLabel = "Regenerate Nodes";
        private readonly PluginConfigurationItemMetadata _assemblyOptionsMetadata;

        private bool _showAssembly = false;
        private const string TitleAssembly = "Node Library";
        private const string DescriptionAssembly = "Choose the assemblies in which you want to look for nodes.\n"
            + "By default, all project and Unity assemblies are included.\n"
            + "Unless you use a third-party plugin distributed as a DLL, you shouldn't need to change this.";

        private ProjectAssemblyOptionsListInspector _assemblyOptionsInspector;

        public AssemblyOptionsSettings(BoltCoreConfiguration coreConfig)
        {
            _assemblyOptionsMetadata = coreConfig.GetMetadata(nameof(coreConfig.assemblyOptions));
            _assemblyOptionsInspector = new ProjectAssemblyOptionsListInspector(_assemblyOptionsMetadata);
        }

        private static class Styles
        {
            public static readonly GUIStyle background;
            public static readonly GUIStyle defaultsButton;
            public const float OptionsWidth = 250;

            static Styles()
            {
                background = new GUIStyle(LudiqStyles.windowBackground);
                background.padding = new RectOffset(20, 20, 20, 20);

                defaultsButton = new GUIStyle("Button");
                defaultsButton.padding = new RectOffset(10, 10, 4, 4);
            }
        }

        public void OnGUI()
        {
            _showAssembly = EditorGUILayout.Foldout(_showAssembly, new GUIContent(TitleAssembly, DescriptionAssembly));

            if (_showAssembly)
            {
                GUILayout.BeginVertical(Styles.background, GUILayout.ExpandHeight(true));

                var height = _assemblyOptionsInspector.GetCachedHeight(Styles.OptionsWidth, GUIContent.none, null);

                EditorGUI.BeginChangeCheck();

                var position = GUILayoutUtility.GetRect(Styles.OptionsWidth, height);

                _assemblyOptionsInspector.Draw(position, GUIContent.none);

                if (EditorGUI.EndChangeCheck())
                {
                    _assemblyOptionsMetadata.SaveImmediately(true);
                    Codebase.UpdateSettings();
                }

                if (GUILayout.Button("Reset to Defaults", Styles.defaultsButton) && EditorUtility.DisplayDialog("Reset the Node Library", "Reset the Node Library to its default state?", "Reset to Default", "Cancel"))
                {
                    _assemblyOptionsMetadata.Reset(true);
                    _assemblyOptionsMetadata.SaveImmediately(true);
                }

                LudiqGUI.EndVertical();
            }

            if (GUILayout.Button(CompleteLabel, Styles.defaultsButton))
            {
                UnitBase.Rebuild();

                EditorUtility.DisplayDialog("Visual Script", "Regenerate Nodes completed", "OK");
            }
        }
    }
}
