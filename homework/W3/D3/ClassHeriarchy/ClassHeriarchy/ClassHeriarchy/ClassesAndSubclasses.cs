using System;
using System.Collections.Generic;
using System.Text;

namespace ClassHeriarchy
{
    class ClassesAndSubclasses
    {
        public ClassesAndSubclasses(Type parent, bool isXamarinForms)
        {
            Type = parent;
            IsXamarinForms = isXamarinForms;
            Subclasses = new List<ClassesAndSubclasses>();
        }

        public Type Type { get; private set; }
        public bool IsXamarinForms { get; private set; }
        public List<ClassesAndSubclasses> Subclasses { get; private set; }
    }
}
