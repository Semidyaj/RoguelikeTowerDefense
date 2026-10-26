using UnityEngine;

namespace RoguelikeTD.UI.MainMenu
{
    public class MainMenuUIRoot : MonoBehaviour
    {
        [field: SerializeField] public Transform HUDLayer {  get; private set; }
        [field: SerializeField] public Transform PopupsLayer {  get; private set; }
        [field: SerializeField] public Transform VFXUnderPopups {  get; private set; }
        [field: SerializeField] public Transform VFXOverPopups {  get; private set; }
    }
}
