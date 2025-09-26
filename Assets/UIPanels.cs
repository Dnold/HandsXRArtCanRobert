using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class UIPanels : MonoBehaviour
{
    public List<UIPanel> panels = new List<UIPanel>();
    public UIPanel currentActive;

    public void ActivatePanel(int id)
    {
        foreach (var panel in panels)
        {
            if (panel.panelID == id)
            {
                panel.isActive = true;
                currentActive = panel;
                panel.gameObject.SetActive(true);
            }
            else
            {
                panel.isActive = false;
                panel.gameObject.SetActive(false);
            }
        }
    }

}
