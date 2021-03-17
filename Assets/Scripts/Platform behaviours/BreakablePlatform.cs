public class BreakablePlatform : NormalPlatform
{
    protected override void PlatformEffect()
    {
        gameObject.SetActive(false);
    }
}
