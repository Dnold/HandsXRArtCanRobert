using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
[System.Serializable]
public class ColorSelection
{
    public Material material;
    public string colorName;
}
public class CubeUITransformer : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    [SerializeField]
    public ColorSelection[] colorSelections;
    public TMP_Dropdown colorDropDown;
    public Slider scaleSlider;
    public Transform startTransform;
    [SerializeField]
    public ColorSelection defaultColorSelection;
    float currentScale = 0.5f;

    private void Start()
    {
        currentScale = scaleSlider.value;
        colorDropDown.options.Clear();
        foreach (var colorSelection in colorSelections)
        {
            colorDropDown.options.Add(new TMP_Dropdown.OptionData(colorSelection.colorName));
        }
        
       
        
    }
    public void SpawnNewObject()
    {
        GameObject newCube = Instantiate(objectPrefabs[Random.Range(0,objectPrefabs.Length+1)], startTransform.position, startTransform.rotation);
        newCube.transform.localScale = Vector3.one * currentScale;
        var renderer = newCube.GetComponent<Renderer>();
        int index = colorDropDown.value;
        if (index >= 0 && index < colorSelections.Length)
        {
            if(index == 0)
            {
                return;
            }
            var selectedColor = colorSelections[index];
            renderer.material = selectedColor.material;
        }

    }
    //void ResetCube()
    //{
    //    cube.transform.position = startTransform.position;
    //    cube.transform.rotation = startTransform.rotation;
    //    cube.transform.localScale = startTransform.localScale;
    //    scaleSlider.value = startTransform.localScale.x;
    //    var renderer = cube.GetComponent<Renderer>();
    //    renderer.material = defaultColorSelection.material;
    //    colorDropDown.value = colorSelections.ToList().FindIndex(c => c.colorName == defaultColorSelection.colorName);
    //}
    public void OnColorChanged()
    {
        //int index = colorDropDown.value;
        //if (index < 0 || index >= colorSelections.Length) return;
        //var selectedColor = colorSelections[index];
        //var renderer = cube.GetComponent<Renderer>();
        //renderer.material = selectedColor.material;
    }
    public void OnScaleChanged()
    {
        currentScale = scaleSlider.value;
    }
    public void OnReset()
    {
        //ResetCube();
    }
 



}
