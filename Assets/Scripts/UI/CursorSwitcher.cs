using UnityEngine;

namespace UI
{
    public class CursorSwitcher : MonoBehaviour
    {
        [SerializeField] private Texture2D cursor;

        public void ChangeCursorToCustom() => SetCursor(cursor);
        public void ResetCursorToDefault() => SetCursor(null);

        private void SetCursor(Texture2D texture) {
            Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
        }
    }
}