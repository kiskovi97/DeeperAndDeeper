using UnityEngine;

namespace Assets.Scripts
{
    class LevelDesignsUI : MonoBehaviour
    {
        [SerializeField] private LevelDesignUI prefab;
        [SerializeField] private Transform levelsBase;
        [SerializeField] private GameObject ui;

        private void Awake()
        {
            ui.SetActive(true);
            var levelDesigns = Resources.LoadAll<LevelDesign>("ScriptObjects/LevelDesign");
            foreach(var level in levelDesigns)
            {
                var levelUI = Instantiate(prefab, levelsBase);
                levelUI.SetLevelDesign(level, () =>
                {
                    ui.SetActive(false);
                    GameState.LoadTutorial();
                });
            }
        }
    }
}
