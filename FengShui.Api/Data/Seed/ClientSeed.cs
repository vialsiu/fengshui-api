//-----the clients, birth year and formula are there for their kua number
using FengShui.Api.Models;

namespace FengShui.Api.Data.Seed;

/// <summary>
/// the clients the game starts with
/// </summary>
public static class ClientSeed
{
    /// <summary>
    /// all the starting clients
    /// </summary>
    public static readonly Client[] All =
    [
        new Client { Id = 1, Name = "Maya Lennon", Age = 34, BirthYear = 1992, KuaFormula = KuaFormula.Female },
        //--ruth has two requests, the twins' room and the living room
        new Client { Id = 2, Name = "Ruth Okafor", Age = 41, BirthYear = 1985, KuaFormula = KuaFormula.Female },
        new Client { Id = 3, Name = "Tom Brennan", Age = 22, BirthYear = 2004, KuaFormula = KuaFormula.Male },
        new Client { Id = 4, Name = "Declan Murphy", Age = 52, BirthYear = 1974, KuaFormula = KuaFormula.Male }
    ];
}
