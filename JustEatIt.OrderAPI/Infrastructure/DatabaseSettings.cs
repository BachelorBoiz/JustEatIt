﻿namespace JustEatIt.OrderAPI.Infrastructure;

public class DatabaseSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string OrdersCollectionName { get; set; }
}