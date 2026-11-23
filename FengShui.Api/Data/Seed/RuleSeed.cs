//------the feng shui rules the layout checker tests against
using FengShui.Api.Models;

namespace FengShui.Api.Data.Seed;

/// <summary>
/// the rules the game starts with
/// </summary>
public static class RuleSeed
{
    /// <summary>
    /// all the starting rules
    /// </summary>
    public static readonly Rule[] All =
    [
        //---bedroom
        //----ref https://www.homesandgardens.com/interior-design/how-to-design-a-bedroon-using-feng-shui
        //-------ref https://www.homebeautiful.com.au/bedroom-ideas/feng-shui-for-bedroom/
        new Rule { Id = 1, Code = "coffin", Title = "Feet not pointing at the door", Category = RuleCategory.Room, Severity = Severity.Suggestion, RoomKind = RoomKind.Bedroom,
            Why = "Lying with your feet straight towards the door is called the coffin position. It's how the dead are carried out, so it's said to drain your energy while you sleep." },
        new Rule { Id = 2, Code = "bed_sees_door", Title = "The bed can see the door", Category = RuleCategory.Room, Severity = Severity.Suggestion, RoomKind = RoomKind.Bedroom,
            Why = "This is the command position. Seeing who comes in without being in line with the door lets your body relax properly." },
        new Rule { Id = 3, Code = "bed_solid_wall", Title = "Headboard against a solid wall", Category = RuleCategory.Room, Severity = Severity.Suggestion, RoomKind = RoomKind.Bedroom,
            Why = "A wall behind your head gives support, like having someone watching your back." },
        new Rule { Id = 4, Code = "bed_under_window", Title = "Bed not under the window", Category = RuleCategory.Room, Severity = Severity.Tip, RoomKind = RoomKind.Bedroom,
            Why = "Qi rushes in and out of a window, so sleeping right under one leaves you restless." },
        new Rule { Id = 5, Code = "mirror_faces_bed", Title = "No mirror facing the bed", Category = RuleCategory.Room, Severity = Severity.Tip, RoomKind = RoomKind.Bedroom,
            Why = "A mirror bounces energy around the room all night, which is the opposite of what you want while sleeping." },

        //------study
        //--ref https://www.hunker.com/13728369/feng-shui-home-office-ideas-and-inspiration
        //-----ref https://www.officernd.com/blog/feng-shui-office-layout/
        new Rule { Id = 6, Code = "desk_sees_door", Title = "The desk can see the door", Category = RuleCategory.Room, Severity = Severity.Suggestion, RoomKind = RoomKind.Study,
            Why = "Sitting with your back to the door keeps part of you on alert, so it's harder to focus." },
        new Rule { Id = 7, Code = "desk_knowledge", Title = "Desk in the knowledge area", Category = RuleCategory.Room, Severity = Severity.Tip, RoomKind = RoomKind.Study,
            Why = "The knowledge area of the bagua is about study and self growth, the best place to learn." },

        //----living room
        //---ref https://idealhome.co.uk/living-room/where-to-place-a-sofa-for-feng-shui
        new Rule { Id = 8, Code = "sofa_solid_wall", Title = "Sofa back against a wall", Category = RuleCategory.Room, Severity = Severity.Suggestion, RoomKind = RoomKind.Living,
            Why = "A sofa floating in the room with its back to the door never feels fully relaxing." },
        new Rule { Id = 9, Code = "sofa_sees_door", Title = "The sofa can see the door", Category = RuleCategory.Room, Severity = Severity.Tip, RoomKind = RoomKind.Living,
            Why = "The command position works for the main seat in a living room too." },

        //--------any room
        //------ref https://www.extraspace.com/blog/home-organization/home-organization-tips/feng-shui-rules-to-follow-for-a-balanced-home/
        //----ref https://www.flexispot.com/spine-care-center/the-secret-to-enhancing-the-flow-of-energy-in-your-office-desk-with-these-feng-shui-principles
        new Rule { Id = 10, Code = "door_clear", Title = "Nothing blocking the door", Category = RuleCategory.General, Severity = Severity.Suggestion,
            Why = "The door is the mouth of qi. If it can't open fully, new energy and opportunities can't come in." },
        new Rule { Id = 11, Code = "qi_reaches_window", Title = "Qi can flow from the door to the window", Category = RuleCategory.General, Severity = Severity.Suggestion,
            Why = "Energy should be able to move gently through the room instead of getting blocked." },
        new Rule { Id = 12, Code = "no_stuck_corners", Title = "No stuck corners", Category = RuleCategory.General, Severity = Severity.Tip,
            Why = "Spaces that qi can't reach go stale, and stale energy builds up as stress." },
        new Rule { Id = 13, Code = "plant_wealth", Title = "A plant in the wealth area", Category = RuleCategory.General, Severity = Severity.Tip,
            Why = "Healthy plants are wood energy, and wood feeds growth in the wealth corner." },

        //---depends on the client's kua number
        new Rule { Id = 14, Code = "kua_bed", Title = "Head points a good direction", Category = RuleCategory.Personal, Severity = Severity.Suggestion, RoomKind = RoomKind.Bedroom,
            Why = "Everyone has four lucky directions from their kua number. Sleeping with your head towards one helps you rest." },
        new Rule { Id = 15, Code = "kua_desk", Title = "Facing a good direction at the desk", Category = RuleCategory.Personal, Severity = Severity.Tip, RoomKind = RoomKind.Study,
            Why = "Facing one of your lucky directions while you work is said to help success and focus." }
    ];
}