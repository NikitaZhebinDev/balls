using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChooseSection : MonoSingleton<ChooseSection> {

    
    public Color32 colorFalse;
    public Color32 colorTrue;


    public Image[] sections;
    public Image imageRays;


    public Image panelSection;
    public Text textSection;
    public Color32[] colorPanelSections;



    private void Update()
    {

        for (int i = 0; i < sections.Length; i++)
        {
            if (ShopScroll1.Instance.selectedPanel == i)
            {
                sections[i].color = colorTrue;
            }
            else
            {
                sections[i].color = colorFalse;
            }

            switch (ShopScroll1.Instance.selectedPanel)
            {
                case 0: textSection.text = "Standart"; panelSection.color = colorPanelSections[0]; imageRays.color = colorPanelSections[0]; break;
                case 1: textSection.text = "Rare"; panelSection.color = colorPanelSections[1]; imageRays.color = colorPanelSections[1]; break;
                case 2: textSection.text = "Gold"; panelSection.color = colorPanelSections[2]; imageRays.color = colorPanelSections[2]; break;
                case 3: textSection.text = "Epic"; panelSection.color = colorPanelSections[3]; imageRays.color = colorPanelSections[3]; break;
            }

            

        }
        
    }





}
