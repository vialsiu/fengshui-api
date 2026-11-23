using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FengShui.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedGameData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Age", "BirthYear", "KuaFormula", "Name" },
                values: new object[,]
                {
                    { 1, 34, 1992, "Female", "Maya Lennon" },
                    { 2, 41, 1985, "Female", "Ruth Okafor" },
                    { 3, 22, 2004, "Male", "Tom Brennan" },
                    { 4, 52, 1974, "Male", "Declan Murphy" }
                });

            migrationBuilder.InsertData(
                table: "FurnitureTypes",
                columns: new[] { "Id", "Code", "Element", "Height", "IsFlat", "Name", "Width" },
                values: new object[,]
                {
                    { 1, "bed", "Earth", 8, false, "Double bed", 6 },
                    { 2, "single_bed", "Earth", 8, false, "Single bed", 4 },
                    { 3, "nightstand", "Wood", 2, false, "Nightstand", 2 },
                    { 4, "wardrobe", "Wood", 2, false, "Wardrobe", 4 },
                    { 5, "dresser", "Wood", 2, false, "Dresser", 4 },
                    { 6, "desk", "Wood", 3, false, "Desk", 5 },
                    { 7, "chair", "Metal", 2, false, "Desk chair", 2 },
                    { 8, "bookshelf", "Wood", 1, false, "Bookshelf", 4 },
                    { 9, "sofa", "Earth", 4, false, "Sofa", 8 },
                    { 10, "armchair", "Earth", 3, false, "Armchair", 3 },
                    { 11, "coffee_table", "Wood", 2, false, "Coffee table", 4 },
                    { 12, "tv_unit", "Fire", 2, false, "TV unit", 6 },
                    { 13, "rug", "Earth", 6, true, "Rug", 8 },
                    { 14, "plant", "Wood", 2, false, "Plant", 2 },
                    { 15, "lamp", "Fire", 1, false, "Floor lamp", 1 },
                    { 16, "mirror", "Water", 1, false, "Mirror", 3 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Cols", "DoorFrom", "DoorTo", "DoorWall", "Kind", "Name", "NorthWall", "PlayerId", "Rows", "WindowFrom", "WindowTo", "WindowWall" },
                values: new object[,]
                {
                    { 1, 14, 2, 6, "Bottom", "Bedroom", "Maya's bedroom", "Top", null, 16, 5, 11, "Top" },
                    { 2, 16, 11, 15, "Left", "Bedroom", "The twins' bedroom", "Right", null, 16, 4, 10, "Right" },
                    { 3, 20, 15, 19, "Bottom", "Living", "The Okafor living room", "Left", null, 18, 4, 12, "Top" },
                    { 4, 12, 2, 6, "Right", "Study", "Tom's study", "Bottom", null, 12, 4, 9, "Left" },
                    { 5, 14, 10, 14, "Top", "Study", "Declan's home office", "Bottom", null, 12, 3, 9, "Bottom" }
                });

            migrationBuilder.InsertData(
                table: "Rules",
                columns: new[] { "Id", "Category", "Code", "RoomKind", "Severity", "Title", "Why" },
                values: new object[,]
                {
                    { 1, "Room", "coffin", "Bedroom", "Suggestion", "Feet not pointing at the door", "Lying with your feet straight towards the door is called the coffin position. It's how the dead are carried out, so it's said to drain your energy while you sleep." },
                    { 2, "Room", "bed_sees_door", "Bedroom", "Suggestion", "The bed can see the door", "This is the command position. Seeing who comes in without being in line with the door lets your body relax properly." },
                    { 3, "Room", "bed_solid_wall", "Bedroom", "Suggestion", "Headboard against a solid wall", "A wall behind your head gives support, like having someone watching your back." },
                    { 4, "Room", "bed_under_window", "Bedroom", "Tip", "Bed not under the window", "Qi rushes in and out of a window, so sleeping right under one leaves you restless." },
                    { 5, "Room", "mirror_faces_bed", "Bedroom", "Tip", "No mirror facing the bed", "A mirror bounces energy around the room all night, which is the opposite of what you want while sleeping." },
                    { 6, "Room", "desk_sees_door", "Study", "Suggestion", "The desk can see the door", "Sitting with your back to the door keeps part of you on alert, so it's harder to focus." },
                    { 7, "Room", "desk_knowledge", "Study", "Tip", "Desk in the knowledge area", "The knowledge area of the bagua is about study and self growth, the best place to learn." },
                    { 8, "Room", "sofa_solid_wall", "Living", "Suggestion", "Sofa back against a wall", "A sofa floating in the room with its back to the door never feels fully relaxing." },
                    { 9, "Room", "sofa_sees_door", "Living", "Tip", "The sofa can see the door", "The command position works for the main seat in a living room too." },
                    { 10, "General", "door_clear", null, "Suggestion", "Nothing blocking the door", "The door is the mouth of qi. If it can't open fully, new energy and opportunities can't come in." },
                    { 11, "General", "qi_reaches_window", null, "Suggestion", "Qi can flow from the door to the window", "Energy should be able to move gently through the room instead of getting blocked." },
                    { 12, "General", "no_stuck_corners", null, "Tip", "No stuck corners", "Spaces that qi can't reach go stale, and stale energy builds up as stress." },
                    { 13, "General", "plant_wealth", null, "Tip", "A plant in the wealth area", "Healthy plants are wood energy, and wood feeds growth in the wealth corner." },
                    { 14, "Personal", "kua_bed", "Bedroom", "Suggestion", "Head points a good direction", "Everyone has four lucky directions from their kua number. Sleeping with your head towards one helps you rest." },
                    { 15, "Personal", "kua_desk", "Study", "Tip", "Facing a good direction at the desk", "Facing one of your lucky directions while you work is said to help success and focus." }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "ClientId", "Concern", "Note", "Quote", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, "Sleep", "I removed my wardrobe, plant and dresser from my room first to make it easier for you. Please don't forget to put them back!", "I haven't slept properly since I moved in.", 1 },
                    { 2, 2, "Family", "Both beds are out in the hall, they're too heavy for me to put back on my own.", "The boys fight every single night at bedtime.", 2 },
                    { 3, 2, "Family", null, "We never sit together in the living room anymore.", 3 },
                    { 4, 3, "Focus", "I took the desk apart to get it up the stairs, sorry! It's in pieces by the door.", "I can't get anything done on my thesis in here.", 4 },
                    { 5, 4, "Money", null, "Money comes in and goes straight back out again.", 5 }
                });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "Id", "FurnitureTypeId", "Owned", "RequestId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 3, 2, 1 },
                    { 3, 4, 1, 1 },
                    { 4, 5, 1, 1 },
                    { 5, 14, 1, 1 },
                    { 6, 16, 1, 1 },
                    { 7, 2, 2, 2 },
                    { 8, 3, 1, 2 },
                    { 9, 8, 1, 2 },
                    { 10, 13, 1, 2 },
                    { 11, 15, 1, 2 },
                    { 12, 9, 1, 3 },
                    { 13, 10, 2, 3 },
                    { 14, 11, 1, 3 },
                    { 15, 12, 1, 3 },
                    { 16, 13, 1, 3 },
                    { 17, 14, 2, 3 },
                    { 18, 6, 1, 4 },
                    { 19, 7, 1, 4 },
                    { 20, 8, 2, 4 },
                    { 21, 15, 1, 4 },
                    { 22, 6, 1, 5 },
                    { 23, 7, 1, 5 },
                    { 24, 10, 1, 5 },
                    { 25, 8, 1, 5 },
                    { 26, 14, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Layouts",
                columns: new[] { "Id", "Kind", "Name", "PlayerId", "RequestId", "RoomId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Start", "Maya's bedroom as it is", null, 1, 1, new DateTime(2026, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "Start", "The twins' bedroom as it is", null, 2, 2, new DateTime(2026, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "Start", "The Okafor living room as it is", null, 3, 3, new DateTime(2026, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "Start", "Tom's study as it is", null, 4, 4, new DateTime(2026, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "Start", "Declan's home office as it is", null, 5, 5, new DateTime(2026, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Placements",
                columns: new[] { "Id", "Col", "FurnitureTypeId", "LayoutId", "Rotation", "Row" },
                values: new object[,]
                {
                    { 1, 4, 1, 1, 0, 1 },
                    { 2, 2, 3, 1, 0, 1 },
                    { 3, 10, 3, 1, 0, 1 },
                    { 4, 6, 16, 1, 0, 16 },
                    { 5, 15, 3, 2, 0, 1 },
                    { 6, 1, 8, 2, 90, 11 },
                    { 7, 5, 13, 2, 0, 6 },
                    { 8, 16, 15, 2, 0, 16 },
                    { 9, 7, 9, 3, 0, 9 },
                    { 10, 15, 10, 3, 0, 15 },
                    { 11, 1, 10, 3, 0, 1 },
                    { 12, 9, 11, 3, 0, 6 },
                    { 13, 9, 12, 3, 0, 17 },
                    { 14, 1, 13, 3, 0, 12 },
                    { 15, 19, 14, 3, 0, 1 },
                    { 16, 1, 14, 3, 0, 5 },
                    { 17, 6, 7, 4, 0, 6 },
                    { 18, 1, 8, 4, 0, 1 },
                    { 19, 5, 8, 4, 0, 12 },
                    { 20, 12, 15, 4, 0, 12 },
                    { 21, 9, 6, 5, 0, 4 },
                    { 22, 10, 7, 5, 0, 2 },
                    { 23, 1, 10, 5, 0, 1 },
                    { 24, 3, 8, 5, 0, 12 },
                    { 25, 13, 14, 5, 0, 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Placements",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FurnitureTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Layouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Layouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Layouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Layouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Layouts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
