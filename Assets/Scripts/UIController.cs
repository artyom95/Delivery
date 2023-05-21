using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _winPanel;
    [SerializeField]
    private GameObject _losePanel;
    // Start is called before the first frame update
  

   public void TurnOnWinPanel()
   {
       _winPanel.SetActive(true);
   }
   public void TurnOnLosePanel()
   {
       _losePanel.SetActive(true);
   }
}
