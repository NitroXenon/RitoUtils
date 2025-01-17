﻿namespace RitoWarsPacketReader.Server.GameData
{
    enum GameCmd : uint
    {
        PKT_S2C_MoveAns = 0x61,
    };

    //Currently attuned to GAME_VERSION [Game.h]
    enum PacketCmd : uint
    {
        PKT_KeyCheck = 0x00,
        PKT_C2S_HeartBeat = 0x08,
        PKT_C2S_SellItem = 0x09,
        PKT_S2C_RemoveItem = 0x0B,
        PKT_S2C_NextAutoAttack = 0x0C,

        PKT_S2C_EndSpawn = 0x11,
        PKT_C2S_QueryStatusReq = 0x14,
        PKT_S2C_SkillUp = 0x15,
        PKT_C2S_Ping_Load_Info = 0x16,
        PKT_S2C_BeginAutoAttack = 0x1A,
        PKT_S2C_EditBuff = 0x1C,
        PKT_C2S_SwapItems = 0x20,
        PKT_S2C_AddGold = 0x22,

        PKT_S2C_PlayerInfo = 0x2A,

        PKT_S2C_ViewAns = 0x2C,
        PKT_C2S_ViewReq = 0x2E,
        PKT_S2C_ChampionRespawn = 0x2F,

        PKT_S2C_StopAutoAttack = 0x34,
        PKT_S2C_DeleteObject = 0x35, // not sure what this is, happens when turret leaves vision
        PKT_C2S_SkillUp = 0x39,
        PKT_S2C_SpawnProjectile = 0x3B,
        PKT_S2C_SwapItems = 0x3E,
        PKT_S2C_LevelUp = 0x3F,
        PKT_S2C_AttentionPing = 0x40,

        PKT_S2C_Emotion = 0x42,
        PKT_S2C_Announce = 0x45,
        PKT_C2S_AutoAttackOption = 0x47,
        PKT_C2S_Emotion = 0x48,
        PKT_S2C_HeroSpawn = 0x4C,

        // Packet 0xC0 format is [Net ID 1] [Net ID 2], purpose still unknown
        PKT_S2C_GameTimer = 0xC1,
        PKT_S2C_GameTimerUpdate = 0xC2,

        PKT_S2C_FaceDirection = 0x50,
        PKT_S2C_LeaveVision = 0x51,
        PKT_C2S_StartGame = 0x52,
        PKT_S2C_SynchVersion = 0x54,
        PKT_C2S_ScoreBord = 0x56,
        PKT_C2S_AttentionPing = 0x57,
        PKT_S2C_DestroyProjectile = 0x5A,
        PKT_S2C_StartGame = 0x5C,
        PKT_S2C_ChampionDie = 0x5E,

        PKT_S2C_StartSpawn = 0x62,
        PKT_C2S_ClientReady = 0x64,
        PKT_S2C_Dash = 0x64,
        PKT_S2C_DamageDone = 0x65,
        PKT_S2C_LoadHero = 0x65,
        PKT_S2C_LoadName = 0x66,
        PKT_S2C_LoadScreenInfo = 0x67,
        PKT_ChatBoxMessage = 0x68,
        PKT_S2C_SetTarget = 0x6A,
        PKT_S2C_SetAnimation = 0x6B,
        PKT_S2C_ShowProjectile = 0x6E,
        PKT_S2C_BuyItemAns = 0x6F,
        PKT_S2C_AddBuff = 0xB7,

        PKT_C2S_MoveReq = 0x72,
        PKT_C2S_MoveConfirm = 0x77,
        PKT_S2C_RemoveBuff = 0x7B,

        PKT_C2S_LockCamera = 0x81,
        PKT_C2S_BuyItemReq = 0x82,
        PKT_S2C_SetCooldown = 0x85,
        PKT_S2C_SpawnParticle = 0x87,
        PKT_S2C_QueryStatusAns = 0x88,
        PKT_C2S_Exit = 0x8F,

        PKT_World_SendGameNumber = 0x92,
        PKT_S2C_Ping_Load_Info = 0x95,
        PKT_C2S_CastSpell = 0x9A,
        PKT_S2C_TurretSpawn = 0x9D,
        PKT_S2C_NPC_Hide = 0x9E, // (4.18) not sure what this became

        PKT_C2S_Surrender = 0xa4,
        PKT_C2S_StatsConfirm = 0xA8,
        PKT_S2C_SetHealth = 0xAE,
        PKT_C2S_Click = 0xAF,

        PKT_S2C_SpellAnimation = 0xB0,
        PKT_S2C_CastSpellAns = 0xB5,
        PKT_S2C_ObjectSpawn = 0xBA,
        PKT_C2S_SynchVersion = 0xBD,
        PKT_C2S_CharLoaded = 0xBE,

        PKT_S2C_SetTarget2 = 0xC0,
        PKT_S2C_CharStats = 0xC4,
        PKT_S2C_FogUpdate2 = 0x23,
        PKT_S2C_LevelPropSpawn = 0xD0,

        PKT_S2C_DebugMessage = 0xF7,
        PKT_S2C_Extended = 0xFE,

        PKT_Batch = 0xFF
    };

    enum ExtendedPacketCmd : uint
    {
        EPKT_S2C_OnAttack = 0x0F,
        EPKT_S2C_ChampionDeathTimer = 0x17,
        EPKT_S2C_NPC_Die = 0x26,
    };

    enum MoveType : uint
    {
        EMOTE = 1,
        MOVE = 2,
        ATTACKMOVE = 7,
        STOP = 10,
    };

    enum ChatType : uint
    {
        CHAT_ALL = 0,
        CHAT_TEAM = 1,
    };

//#define CHL_MAX = 7
    enum Channel : uint
    {
        CHL_HANDSHAKE = 0,
        CHL_C2S = 1,
        CHL_GAMEPLAY = 2,
        CHL_S2C = 3,
        CHL_LOW_PRIORITY = 4,
        CHL_COMMUNICATION = 5,
        CHL_LOADING_SCREEN = 7,
    };

    enum SpellIds : uint
    {
        SPL_Revive = 0x05C8B3A5,
        SPL_Smite = 0x065E8695,
        SPL_Exhaust = 0x08A8BAE4,
        SPL_Barrier = 0x0CCFB982,
        SPL_Teleport = 0x004F1364,
        SPL_Ghost = 0x064ACC95,
        SPL_Heal = 0x0364AF1C,
        SPL_Cleanse = 0x064D2094,
        SPL_Clarity = 0x03657421,
        SPL_Ignite = 0x06364F24,
        SPL_Promote = 0x0410FF72,
        SPL_Clair = 0x09896765,
        SPL_Flash = 0x06496EA8,
        SPL_Test = 0x0103D94C,
    };
    
    enum MasterMask : uint
    {
        MM_One = 0x01,
        MM_Two = 0x02,
        MM_Three = 0x04,
        MM_Four = 0x08,
        MM_Five = 0x10,
    };
}
