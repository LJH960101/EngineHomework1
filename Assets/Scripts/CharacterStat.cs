using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    protected float _power = 10.0f;
    public float Power { get { return _power; } }

    protected float _maxHp = 100.0f;
    public float MaxHp { get { return _maxHp; } }

    protected float _hp = 100.0f;
    public float Hp { get { return _hp; } }

    protected float _moveSpeed = 3.0f;
    public float MoveSpeed { get { return _moveSpeed; } }

    protected float _turnSpeed = 540.0f;
    public float TurnSpeed { get { return _turnSpeed; } }

    protected float _attackRange = 2.0f;
    public float AttackRange { get { return _attackRange; } }
    
    [HideInInspector]
    public CharacterStat lastHitBy = null;
    [SerializeField]
    protected StatData statData;

    GameObject _hpObj;
    TextMesh _hpTextMesh;
    protected virtual void Awake()
    {
        _turnSpeed = statData.TurnSpeed;
        _hpObj = transform.Find("HP").gameObject;
        _hpTextMesh = _hpObj.GetComponent<TextMesh>();
    }

    public void TakeDamage(CharacterStat from, float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, _maxHp);
        if(_hp <= 0)
        {
            if (lastHitBy == null)
                lastHitBy = from;

            GetComponent<FSMManager>().SetDeadState();
            from.GetComponent<FSMManager>().NotifyTargetKilled();
        }
    }

    private static float CalcDamage(CharacterStat from, CharacterStat to)
    {
        return from.Power;
    }

    public static void ProcessDamage(CharacterStat from, CharacterStat to)
    {
        float finalDamage = CalcDamage(from, to);
        to.TakeDamage(from, finalDamage);
    }

    public static void ProcessDamage(CharacterStat from, CharacterStat to, int damage)
    {
        float finalDamage = damage;
        to.TakeDamage(from, finalDamage);
    }

    protected virtual void Update()
    {
        // 체력 게이지의 값을 수정하고 회전을 카메라에 맞춘다.
        _hpTextMesh.text = (_hp / _maxHp * 100f) + "%";
        _hpObj.transform.rotation = Camera.main.transform.rotation;
    }
}
