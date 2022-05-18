var arguments = ParseArguments(args);

foreach(var argument in arguments)
{
    Console.WriteLine($"You specified the argument {argument.ArgumentType} with data of '{argument.Data}'");
}




IEnumerable<Argument> ParseArguments(string[] args)
{
    foreach(var arg in args)
    {
        var parts = arg.Split('=');

        yield return new Argument
        (
            ParseArgumentName(parts[0]),
            parts.Length > 1 ? parts[1] : ""
        );
    }

}

ArgumentType ParseArgumentName(string argument)
{
    return argument switch
    {
        "/uninstall" => ArgumentType.Uninstall,
        "/quiet" => ArgumentType.Quiet,
        "/APP_UNINSTALL_CODE" => ArgumentType.UninstallCode,
        _ => throw new ArgumentException("Unknown argument was specified")
    };
}

enum ArgumentType
{
    Uninstall,
    Quiet,
    UninstallCode
}

class Argument
{
    public Argument(ArgumentType argumentType, string data)
    {
        ArgumentType = argumentType;
        Data = data;
    }

    public ArgumentType ArgumentType { get; set; }
    public string Data { get; set; }
}