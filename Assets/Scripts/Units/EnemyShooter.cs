public class EnemyShooter : AttackComponent
{
    private Health _playerHealth;
    public override bool CanAttack => true;
    private void Start()
    {
        _playerHealth = ServiceLocator.Instance.GetService<Player>().GetComponent<Health>();
    }
    
    public override void Attack()
    {
        _playerHealth.TookDamage();
    }
}
