using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LEaderBoardSCoreManager : MonoBehaviour
{
   [SerializeField]
   private TextMeshProUGUI inputScore;
   [SerializeField]
   private TextMeshProUGUI inputName;

   public UnityEvent<string, int> submitScoreEvent;
   
   public void SubmitScore(){
    submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
   }
}
