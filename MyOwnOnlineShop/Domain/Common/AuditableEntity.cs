namespace Domain.Common;
public abstract record AuditableEntity(DateTime Created, string? CreatedBy, DateTime? LastModified, string? LastModifiedBy);