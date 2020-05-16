﻿using System;
using System.Collections.Generic;

namespace Zwierzoki.ModelsF
{
    public partial class ProcedureAnimal
    {
        public int ProcedureIdProcedure { get; set; }
        public int AnimalIdAnimal { get; set; }
        public DateTime Date { get; set; }

        public virtual Animal AnimalIdAnimalNavigation { get; set; }
        public virtual Procesja ProcedureIdProcedureNavigation { get; set; }
    }
}
