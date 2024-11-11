namespace Application;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class DisplayPropertyAttribute : Attribute
{
    public string Name { get; set; }
    public DisplayPropertyAttribute(string name)
    {
            Name = name;
    }
}
