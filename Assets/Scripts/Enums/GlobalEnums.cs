using System;

namespace GlobalEnums
{
	public enum AchievementType
	{
		Null = -1,
		Normal = 0,
		Hidden = 1,
	}

	public enum AchievementValueType
	{
		Bool = 0,
		Int = 1,
		Float = 2
	}

	public enum ActiveInputType
	{
		KEYBOARD = 0,
		CONTROLLER = 1
	}

	public enum ActorStates
	{
		grounded = 0,
		idle = 1,
		running = 2,
		airborne = 3,
		wall_sliding = 4,
		hard_landing = 5,
		dash_landing = 6,
		no_input = 7,
		previous  = 8
	}

	public enum AfterEvent
	{
		TIME = 0,
		TK2D_ANIM_END = 1,
		LEVEL_UNLOAD = 2,
		AUDIO_CLIP_END = 3
	}

	public enum AttackDirection
	{
		normal = 0,
		upward = 1,
		downward = 2
	}

	public enum BuildTypes
	{
		Regular = 0,
		Chinese = 1
	}

	public enum ButtonSkinType
	{
		BLANK = 0,
		SQUARE = 1,
		WIDE = 2,
		CIRCLE = 3,
		OVAL = 4,
		CONTROLLER = 5
	}

	public enum CameraFadeInType
	{
		NORMAL = 0,
		SLOW = 1,
		INSTANT = 2
	}

	public enum CameraFadeType
	{
		LEVEL_TRANSITION = 0,
		HERO_DEATH = 1,
		HERO_HAZARD_DEATH = 2,
		JUST_FADE = 3,
		START_FADE = 4
	}

	public enum CancelAction
	{
		DoNothing = 0,
		GoToMainMenu = 1,
		GoToOptionsMenu = 2,
		GoToVideoMenu = 3,
		GoToPauseMenu = 4,
		LeaveOptionsMenu = 5,
		GoToExitPrompt = 6,
		GoToProfileMenu = 7,
		GoToControllerMenu = 8,
		ApplyRemapGamepadSettings = 9,
		ApplyAudioSettings = 10,
		ApplyVideoSettings = 11,
		ApplyGameSettings = 12,
		ApplyKeyboardSettings = 13,
		GoToExtrasMenu = 14,
		ApplyControllerSettings = 15,
		GoToExplicitSwitchUser = 16,
		ReturnToProfileMenu = 17
	}

	public enum CollisionSide
	{
		top = 0,
		left = 1,
		right = 2,
		bottom = 3,
		other = 4
	}

	public enum ControllerProfile
	{
		Default = 0,
		Custom = 1
	}

	public enum DamageMode
	{
		FULL_DAMAGE = 0,
		HAZARD_ONLY = 1,
		NO_DAMAGE = 2
	}

	public enum GamepadState
	{
		DETACHED = 0,
		ATTACHED = 1,
		ACTIVATED = 2
	}

	public enum GamepadType
	{
		NONE =0,
		UNKNOWN = 1,
		XBOX_ONE = 2,
		XBOX_360 = 3,
		PS4 = 4,
		PS_VITA = 5,
		WII_U_GAMEPAD = 6,
		WII_U_PRO_CONTROLLER = 7,
		PS3_WIN = 8,
		SWITCH_JOYCON_DUAL = 9,
		SWITCH_PRO_CONTROLLER = 10
	}

	public enum GameState
	{
		INACTIVE = 0,
		MAIN_MENU = 1,
		LOADING = 2,
		ENTERING_LEVEL = 3,
		PLAYING = 4,
		PAUSED = 5,
		EXITING_LEVEL = 6,
		CUTSCENE = 7,
		PRIMER = 8
	}

	public enum GatePosition
	{
		top = 0,
		right = 1,
		left = 2,
		bottom = 3,
		door = 4,
		unknown = 5
	}

	/// <summary>
	/// Hazard指在酸水岩浆等的非自然死亡
	/// </summary>
	public enum HazardType
	{
		NON_HAZARD = 0,
		SPIKES = 1,
		ACID = 2,
		LAVA = 3,
		PIT = 4
	}

	public enum HeroActionButton
	{
		JUMP = 0,
		ATTACK = 1,
		DASH = 2,
		SUPER_DASH = 3,
		CAST = 4,
		QUICK_MAP = 5,
		INVENTORY = 6,
		MENU_SUBMIT = 7,
		MENU_CANCEL = 8,
		DREAM_NAIL = 9,
		UP = 10,
		DOWN = 11,
		LEFT = 12,
		RIGHT = 13,
		QUICK_CAST = 14,
		MENU_PANE_LEFT = 15,
		MENU_PANE_RIGHT = 16
	}

	public enum HeroSounds
	{
		FOOTSTEPS_RUN = 0,
		FOOTSTEPS_WALK = 1,
		JUMP = 2,
		WALLJUMP = 3,
		SOFT_LANDING = 4,
		HARD_LANDING = 5,
		BACKDASH = 6,
		DASH = 7,
		TAKE_HIT = 8,
		WALLSLIDE = 9,
		NAIL_ART_CHARGE = 10,
		NAIL_ART_READY = 11,
		FALLING = 12
	}

	/// <summary>
	/// 角色切换场景的状态
	/// </summary>
	public enum HeroTransitionState
	{
		WAITING_TO_TRANSITION = 0,
		EXITING_SCENE = 1,
		WAITING_TO_ENTER_LEVEL = 2,
		ENTERING_SCENE = 3,
		DROPPING_DOWN = 4
	}

	public enum HeroType
	{
		PEANUT,
		SUICA,
		ZABIN = 2
	}

	public enum LocationType
	{
		NONE = 0,
		INTERIOR = 1,
		EXTERIOR = 2,
		EXTERIOR_WINDY = 3
	}

	public enum MainMenuState
	{
		LOGO = 0,
		MAIN_MENU = 1,
		OPTIONS_MENU = 2,
		GAMEPAD_MENU = 3,
		KEYBOARD_MENU = 4,
		SAVE_PROFILES = 5,
		AUDIO_MENU = 6,
		VIDEO_MENU = 7,
		EXIT_PROMPT = 8,
		OVERSCAN_MENU = 9,
		GAME_OPTIONS_MENU = 10,
		ACHIEVEMENTS_MENU = 11,
		QUIT_GAME_PROMPT = 12,
		RESOLUTION_PROMPT = 13,
		BRIGHTNESS_MENU = 14,
		PAUSE_MENU = 15,
		PLAY_MODE_MENU = 16,
		EXTRAS_MENU = 17,
		REMAP_GAMEPAD_MENU = 18,
		EXTRAS_CONTENT_MENU = 19,
		ENGAGE_MENU = 20,
		NO_SAVE_MENU = 21
	}

	public enum MapZone
    {
		NONE = 0,
		TEST_AREA = 1,
		KING_PASS, 
		PENGUIN_PERCH, //企鹅栖息地
		ABYSMAL_CLIFF, //万丈悬崖
		BRITHGLESS_CAVE5, //无光山洞
		WHITE_PALACE,
		GODS_GLORY
    }

	public enum PhysLayers
	{
		DEFAULT = 0,
		IGNORE_RAYCAST = 2,
		WATER = 4,
		UI = 5,
		TERRAIN = 8,
		PLAYER = 9,
		TRANSITION_GATES = 10,
		ENEMIES = 11,
		PROJECTILES = 12,
		HERO_DETECTOR = 13,
		TERRAIN_DETECTOR = 14,
		ENEMY_DETECTOR = 15,
		ITEM = 16,
		HERO_ATTACK = 17,
		PARTICLE = 18,
		INTERACTIVE_OBJECT = 19,
		HERO_BOX = 20,
		GRASS = 21,
		ENEMY_ATTACK = 22,
		DAMAGE_ALL = 23,
		BOUNCER = 24,
		SOFT_TERRAIN = 25,
		CORPSE = 26,
		UGUI = 27,
		MAP_PIN = 30
	}

	public enum SceneType
	{
		GAMEPLAY = 0,
		MENU = 1,
		LOADING = 2,
		CUTSCENE = 3,
		TESt = 4
	}

	/// <summary>
	/// 跳过剧情的模式
	/// </summary>
	public enum SkipPromptMode
	{
		SKIP_PROMPT = 0,
		SKIP_INSTANT = 1,
		NOT_SKIPPABLE = 2,
		NOT_SKIPPABLE_DUE_TO_LOADING = 3
	}

	public enum SupportedLanguages
	{
		EN = 44,
		FR = 82,
		DE = 37,
		ZH = 199,
		ES = 57,
		KO = 117,
		JA = 109,
		IT = 105,
		PT = 147,
		RU = 154
	}

	public enum TestingLanguages
	{
		EN = 44,
		FR = 82,
		DE = 37,
		ZH = 199,
		ES = 57,
		KO = 117,
		JA = 109,
		IT = 105,
		PT = 147,
		RU = 154
	}

	public enum UIState
	{
		INACTIVE = 0,
		MAIN_MENU_HOME = 1,
		LOADING = 2,
		CUTSCENE = 3,
		PLAYING = 4,
		PAUSED = 5,
		OPTIONS = 6
	}
}
