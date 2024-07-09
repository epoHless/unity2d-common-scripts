using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace epoHless.Framework.Editor
{
    [CustomEditor(typeof(Global), true)]
    public class GlobalEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            
            var global = (Global) target;

            for (var index = 0; index < global.Subsystems.Count; index++)
            {
                var subsystem = global.Subsystems[index];
                using (new GUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField(subsystem.GetType().Name);

                    if (GUILayout.Button("Pause"))
                    {
                        subsystem.Shutdown();
                    }

                    if (GUILayout.Button("Resume"))
                    {
                        subsystem.Initialize();
                    }

                    if (GUILayout.Button("Remove"))
                    {
                        global.RemoveSubsystem(subsystem);
                    }
                }
            }

            if (GUILayout.Button("Add Subsystem"))
            {
                var types = new Reflection().GetAllSubsystems();

                var menu = new GenericMenu();
                
                foreach (var type in types)
                {
                    menu.AddItem(new GUIContent(type.Name), false, () =>
                    {
                        var subsystem = (Subsystem) System.Activator.CreateInstance(type);
                        global.AddSubsystem(subsystem);
                    });
                }

                menu.ShowAsContext();
            }
            
            if(GUI.changed) EditorUtility.SetDirty(target);
        }

        private class Reflection
        {
            public List<System.Type> GetAllSubsystems()
            {
                var types = new List<System.Type>();
                
                foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.IsSubclassOf(typeof(Subsystem)))
                        {
                            types.Add(type);
                        }
                    }
                }

                return types;
            }   
        }
    }
}