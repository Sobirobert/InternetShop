using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validation;

public class ValidationResult
{
    private readonly List<string> _errors = new List<string>();

    public bool IsValid => _errors.Count == 0;
    public IReadOnlyList<string> Errors => _errors.AsReadOnly();

    public void AddError(string error)
    {
        _errors.Add(error);
    }
}
