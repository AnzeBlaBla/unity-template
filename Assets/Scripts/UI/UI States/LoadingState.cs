using UnityEngine;
using UnityEngine.UI;

public sealed class LoadingState : UIState
{
    private Image progressImage;


    public override void onEnter()
    {
        base.onEnter();

        progressImage = GetElement("LoadingBar").GetComponent<Image>();
    }

    public override State Update()
    {
        float progress = SceneLoader.Instance.totalLoadingProgress;
        progressImage.fillAmount = progress;
        
        return base.Update();
    }
}