using System;
using System.Reflection;
using UnityEngine;

/// <summary>
/// 角色控制器状态
/// </summary>
[Serializable]
public class HeroControllerState
{
    public bool facingRight;//方向朝右
    public bool onGround;//正在地面上
    public bool jumping;//正在跳跃
    public bool wallJumping;//正在翻墙跳
    public bool doubleJumping;//正在二段跳
    public bool nailCharging;//正在骨钉蓄力
    public bool shadowDashing;//正在暗影冲刺
    public bool swimming;//正在游泳
    public bool falling;//正在降落
    public bool dashing;//正在冲刺
    public bool superDashing;//正在超级冲刺
    public bool superDashOnWall;//准备在墙上超级冲刺
    public bool backDashing;//正在向下冲刺
    public bool touchingWall;//正在碰到墙
    public bool wallSliding;//正在墙上滑行（向下）
    public bool transitioning;//正在转移
    public bool attacking;//正在攻击
    public bool lookingUp;//正在向上看
    public bool lookingDown;//正在向下看
    public bool lookingUpAnim;//向上看动画
    public bool lookingDownAnim;//向下看动画
    public bool altAttack;//二次攻击
    public bool upAttacking;//正在向上攻击
    public bool downAttacking;//正在向下攻击
    public bool bouncing;//正在弹起
    public bool shroomBouncing;//正在蘑菇弹起
    public bool recoilingRight;//后坐力向右
    public bool recoilingLeft;//后坐力向左
    public bool dead;//死亡
    public bool hazardDeath;//危险死亡
    public bool hazardRespawning;//危险重生
    public bool willHardLand;//将会重重落地
    public bool recoilFrozen;//后坐力定住
    public bool recoiling;//正在后坐力
    public bool invulnerable;//无敌
    public bool casting;//正在法术
    public bool castRecoiling;//正在施放法术后的后坐力
    public bool preventDash;//阻止冲刺
    public bool preventBackDash;//阻止向下冲刺
    public bool dashCooldown;//冲刺冷却中
    public bool backDashCooldown;//向下冲刺冷却中
    public bool nearBench;//靠近椅子
    public bool inWalkZone;//在只能行走的区域
    public bool isPaused;//被暂停了
    public bool onConveyor;//在电梯里
    public bool onConveyorV;//在V电梯里
    public bool inConveyorZone;//在电梯的区域
    public bool spellQuake;//下砸法术
    public bool freezeCharge;//冻结充能
    public bool focusing;//聚集
    public bool inAcid;//在酸水区域
    public bool slidingLeft;//向左滑行
    public bool slidingRight;//向右滑行
    public bool touchingNonSlider;//碰到不能滑行的区域
    public bool wasOnGround;//之前在地面上

    public HeroControllerState()
    {
	facingRight = false;//初始朝左
	Reset();
    }

    /// <summary>
    /// 重置玩家状态
    /// </summary>
    public void Reset()
    {
	onGround = false;
	jumping = false;
	falling = false;
	dashing = false;
	swimming = false;
	backDashing = false;
	touchingWall = false;
	wallSliding = false;
	transitioning = false;
	attacking = false;
	lookingUp = false;
	lookingDown = false;
	altAttack = false;
	upAttacking = false;
	downAttacking = false;
	bouncing = false;
	dead = false;
	hazardDeath = false;
	willHardLand = false;
	recoiling = false;
	recoilFrozen = false;
	invulnerable = false;
	casting = false;
	castRecoiling = false;
	preventDash = false;
	preventBackDash = false;
	dashCooldown = false;
	backDashCooldown = false;
    }
}
