using System;
using System.Collections.Generic;
namespace Project10.Views
{
    public interface IForm
    {
        List<String> ValidateForm();
        void Set(Object t);
        void Reset();
        bool ValidateAndCreateObject();
        bool ValidateAndUpdateObject(Object o);
    }
}