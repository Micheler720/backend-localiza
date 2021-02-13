using System;

namespace Domains.UseCase.CategoryServices.Exceptions
{
    [Serializable]
    public class CategoryNotFoundException: Exception
    {
        public CategoryNotFoundException(string message) : base(message) { }
        
    }
}