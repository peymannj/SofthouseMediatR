namespace SofthouseCommon.Constants;

public static class MessageBrokerSettings
{
    public static string ExchangeName = "softhouse";
    
    public static string QueueName = "car-report";
    
    public static string CarTopicRout = "car.*";
    
    public static string CarCreatedRout = "car.created";

    public static string CarUpdatedRout = "car.updated";
    
    public static string CarDeletedRout = "car.deleted";
    
    public static int PrefetchCount = 10;
}
