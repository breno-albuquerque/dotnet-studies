// Demo
var vault = Vault.Locked;

Console.WriteLine(vault);

Console.WriteLine(vault = VaultHandler.Handle(vault, Action.TypePassword, false));
Console.WriteLine(vault = VaultHandler.Handle(vault, Action.TypePassword, true));

public static class VaultHandler
{
    public static Vault Handle(Vault vault, Action action, bool passwordMatches) =>
        (vault, action, passwordMatches) switch
        {
            (Vault.Opened, Action.Close, _) => Vault.Opened,
            (Vault.Closed, Action.Open, _) => Vault.Opened,
            (Vault.Locked, Action.TypePassword, true) => Vault.Closed,
            (Vault.Locked, Action.TypePassword, false) => Vault.PermanentlyLocked,
            _ => vault
        };
}


public enum Vault
{
    Opened,
    Closed,
    Locked,
    PermanentlyLocked
}

public enum Action
{
    Open,
    Close,
    TypePassword,
}

