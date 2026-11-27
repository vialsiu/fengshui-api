//-------every rule code the rules engine knows how to check, the database only holds the wording
namespace FengShui.Api.RulesEngine;

/// <summary>
/// the codes of the checks written in code, a rule in the database has to use one of these
/// </summary>
public static class RuleCodes
{
    //---bedroom
    /// <summary>feet pointing straight at the door</summary>
    public const string Coffin = "coffin";
    /// <summary>the bed can see the door</summary>
    public const string BedSeesDoor = "bed_sees_door";
    /// <summary>headboard against a solid wall</summary>
    public const string BedSolidWall = "bed_solid_wall";
    /// <summary>bed not under the window</summary>
    public const string BedUnderWindow = "bed_under_window";
    /// <summary>no mirror facing the bed</summary>
    public const string MirrorFacesBed = "mirror_faces_bed";

    //-----study
    /// <summary>the desk can see the door</summary>
    public const string DeskSeesDoor = "desk_sees_door";
    /// <summary>desk in the knowledge area</summary>
    public const string DeskKnowledge = "desk_knowledge";

    //----living room
    /// <summary>sofa back against a wall</summary>
    public const string SofaSolidWall = "sofa_solid_wall";
    /// <summary>the sofa can see the door</summary>
    public const string SofaSeesDoor = "sofa_sees_door";

    //--------any room
    /// <summary>nothing blocking the door</summary>
    public const string DoorClear = "door_clear";
    /// <summary>qi can flow from the door to the window</summary>
    public const string QiReachesWindow = "qi_reaches_window";
    /// <summary>no corners qi can't reach</summary>
    public const string NoStuckCorners = "no_stuck_corners";
    /// <summary>a plant in the wealth area</summary>
    public const string PlantWealth = "plant_wealth";

    //------depends on the client's kua number
    /// <summary>head points a good direction</summary>
    public const string KuaBed = "kua_bed";
    /// <summary>facing a good direction at the desk</summary>
    public const string KuaDesk = "kua_desk";

    //---a set makes "is this a real code?" a quick lookup
    //--ref https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1
    /// <summary>
    /// every code above
    /// </summary>
    public static readonly IReadOnlySet<string> All = new HashSet<string>
    {
        Coffin, BedSeesDoor, BedSolidWall, BedUnderWindow, MirrorFacesBed,
        DeskSeesDoor, DeskKnowledge,
        SofaSolidWall, SofaSeesDoor,
        DoorClear, QiReachesWindow, NoStuckCorners, PlantWealth,
        KuaBed, KuaDesk
    };
}