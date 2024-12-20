﻿namespace WebAPI.Helpers;
public class SortingHelper
{
    public static KeyValuePair<string, string>[] GetSortFields()
    {
        return new[] { SortFields.Title, SortFields.CreationDate };
    }
}

public class SortFields
{
    public static KeyValuePair<string, string> Title { get; } = new KeyValuePair<string, string>("title", "Title");
    public static KeyValuePair<string, string> CreationDate { get; } = new KeyValuePair<string, string>("creation date", "Created");
}