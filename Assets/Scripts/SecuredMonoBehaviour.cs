using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;
using System.Text;

public abstract class SecuredBehaviourScript : MonoBehaviour
{

    public abstract void AwakeCustom();

    Button[] buttons;
    List<string> methodsToSecureLocal;


    void Awake()
    {
        GetButtonOnClickListenerMethods();
        WriteMethodsToLog();
        AwakeCustom();
    }


    public virtual void ShowOnClickMethodsOnScreen()
    {

        StringBuilder methods = new StringBuilder();
        methods.AppendLine("Alle Methodennamen der Scene, die ausgeführt werden, wenn ein Button OnClickEvent ausgelöst wird");
        methods.AppendLine("");
        if (ClickMethodsObserver.Current.Methods.Any())
        {
            foreach (string methodname in ClickMethodsObserver.Current.Methods)
            {
                methods.AppendLine(methodname);
            }
        }
        EditorUtility.DisplayDialog("", methods.ToString(), "Yes", "No");
    }

    UnityEvent m_MyEvent = new UnityEvent();


    public void GetButtonOnClickListenerMethods()
    {
        if (methodsToSecureLocal == null)
        {
            methodsToSecureLocal = new List<string>();
        }
        buttons = GetComponents<UnityEngine.UI.Button>();
        foreach (Button button in buttons)
        {

            for (int i = 0; i < button.onClick.GetPersistentEventCount(); i++)
            {
                string methodToSecure = $"{button.name} : {button.onClick. GetPersistentMethodName(i)}";
                methodsToSecureLocal.Add(methodToSecure);
                ClickMethodsObserver.Current.AddMethodToSecure(methodToSecure);
                if (!ClickMethodsObserver.Current.Methods.Any(m => m.Equals(methodToSecure)))
                {
                    button.onClick.RemoveAllListeners();
                }
            }
        }
    }

    public void WriteMethodsToLog()
    {
        if (ClickMethodsObserver.Current.Methods.Any())
        {
            foreach (string methodname in ClickMethodsObserver.Current.Methods)
            {
                Debug.Log(methodname);
            }
        }
    }
}
