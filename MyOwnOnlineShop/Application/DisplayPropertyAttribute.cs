namespace Application;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class DisplayPropertyAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}
