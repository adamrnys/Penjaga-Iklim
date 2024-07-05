using UnityEngine;
using UnityEngine.UI;

public class NyawaBar : MonoBehaviour
{
   [SerializeField] private Nyawa playerNyawa;
   [SerializeField] private Image totalhealthBar;
   [SerializeField] private Image currenthealthBar;

   private void Start()
   {
        totalhealthBar.fillAmount = playerNyawa.currentNyawa / 10;
   }
   private void Update()
   {
        currenthealthBar.fillAmount = playerNyawa.currentNyawa / 10;
   }
}
