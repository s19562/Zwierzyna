using System;
using System.Collections.Generic;

namespace Zwierzoki.ModelsF
{
    public partial class Procesja
    {
        public Procesja()
        {
            ProcedureAnimal = new HashSet<ProcedureAnimal>();
        }

        public int IdProcedure { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProcedureAnimal> ProcedureAnimal { get; set; }
    }
}
