public abstract class EnemyHealth : Health
{
    protected override void Death()
    {
        EventBus.EnemyDeath.Publish();
    }

    //for debug
    private void OnMouseDown()
    {
        GetDamage(1);
    }
    //for debug
}
