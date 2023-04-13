namespace DanielXOO.Serilog.Sinks.Kafka.Configurations;

public static class KafkaSinkConfigurations
{
    public static string VerboseTopic { get; set; } = "verbose-logs";
    
    public static string DebugTopic { get; set; } = "debug-logs";
    
    public static string InformationTopic { get; set; } = "information-logs";
    
    public static string WarningTopic { get; set; } = "warning-logs";
    
    public static string ErrorTopic { get; set; } = "error-logs";
    
    public static string FatalTopic { get; set; } = "fatal-logs";
}