using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuScreen : MonoBehaviour
{
    // UIDocument is hierarchial tree of elements
    [SerializeField] private UIDocument document;
    [SerializeField] private StyleSheet styleSheet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate());
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        Generate();
    }

    // Function defined by me
    private IEnumerator Generate()
    {
        yield return null;
        // The canvas object
        var root = document.rootVisualElement;
        root.styleSheets.Add(styleSheet);

        // Clear everytime you regenerate
        root.Clear();

        // Make a Title
        var titleLabel = new Label("Octocat World");

        // Add to your user interface
        root.Add(titleLabel);

        // Create a visual element
        var container = Create("container");

        // Add to your user interface
        root.Add(container);
    }

    VisualElement Create(string className)
    {
        return Create<VisualElement>(className);
    }

    // Return T means turn the function into a generic 
    T Create<T>(string className) where T : VisualElement, new()
    {
        var element1 = new T();
        element1.AddToClassList(className);
        return element1;
    }
}
