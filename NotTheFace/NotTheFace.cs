using JetBrains.Annotations;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Servers;

namespace NotTheFace;

[UsedImplicitly]
[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class NotTheFace(DatabaseServer databaseServer, ISptLogger<NotTheFace> logger) : IOnLoad
{
    public Task OnLoad()
    {
        var bots = databaseServer.GetTables().Bots;
        bots.Core.CANSHOOTTOHEAD = false;
        logger.Info("[NTF] Bots will now aim centre-mass. This isn't perfect.");
        return Task.CompletedTask;
    }
}