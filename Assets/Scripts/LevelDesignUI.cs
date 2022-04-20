using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class LevelDesignUI : MonoBehaviour
    {
        [SerializeField] private Image images;
        [SerializeField] private Image selectiableImage;
        [SerializeField] private Button button;

        private LevelDesign levelDesign;
        private Action onClicked;

        public void SetLevelDesign(LevelDesign levelDesign, Action onClicked)
        {
            this.levelDesign = levelDesign;
            this.onClicked = onClicked;
            if (images != null)
                images.sprite = levelDesign.Image;
            if (button != null)
            {
                button.interactable = levelDesign.bought;
                button.onClick.AddListener(OnButtonClicked);
            }
            if (selectiableImage != null)
                selectiableImage.enabled = levelDesign.bought;
        }

        private void OnDestroy()
        {
            if (button != null)
                button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            GridGenerator.SetLevelDesigns(levelDesign);
            onClicked?.Invoke();
        }
    }
}
