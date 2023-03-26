using SpaceProgram.DataLayer.EntityFramework;

namespace SpaceProgram.DataLayer.Repositories;

public abstract class SqlServerRepository
{
    protected SpaceProgramDatabase Database { get; } = new();
}