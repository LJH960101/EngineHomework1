# 엔진기초 첫번째 과제

## 과제 요구사항

고블린의 전투를 구현하는 과제.

플레이어와 몬스터의 로직 구현은 FSM 다이어그램에 기초해 만들 것.

스탯 데이터는 ScriptableObject를 사용해 별도의 에셋으로 뺄 것.

## 개요

WASD로 움직이며 보스의 패턴을 피하며 클릭으로 공격하여 적을 무찌르는 게임.

고블린과 슬라임 몬스터가 존재함.

## 몬스터 패턴

### 슬라임 패턴

```
순찰 : 적을 찾음
추격 : 찾은 적을 쫒아감
공격 : 전방의 적을 공격함
죽음
```

### 고블린 패턴

```
* 기본공격을 제외한 모든 공격패턴은 전조 현상을 보인다.

추격 : 적의 주변에 빠르게 이동함
기본공격 : 전방의 천천히 적을 공격함
힐윈드 : 360도 무기를 휘둘러 공격함
빠른 전진 공격 : 전방에 달려가면서 적을 휘두르며 공격함
소환 : 슬라임을 소환함
```

### 스탯 데이터

```
AutoDestroyTime : 시체가 사라지는 시간
TurnSpeed : 모든 캐릭터가 도는 속도

플레이어
PlayerMaxHp
PlayerAttackRange
PlayerMoveSpeed
PlayerPower

슬라임
SlimeMaxHp
SlimeAttackRange
SlimeMoveSpeed
SlimePower

고블린
GoblinMaxHp
GoblinAttackRange
GoblinMoveSpeed
GoblinPower
GoblinHillWindDamageRate : 힐윈드 패턴에서 들어가는 공격력 비례랑
GoblinRushDamageRate : 질주 패턴에서 들어가는 공격력 
```
