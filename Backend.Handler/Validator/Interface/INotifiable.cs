using System.Collections.Generic;

namespace Backend.Handler.Validator.Interface
{
    public interface INotifiable
    {
        bool Valid { get; }
        List<string> Notifications { get; }
    }
}
