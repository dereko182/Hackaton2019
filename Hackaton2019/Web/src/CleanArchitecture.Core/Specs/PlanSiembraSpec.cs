using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CleanArchitecture.Core.Specs
{
    public class PlanSiembraSpec
    : BaseSpecification<PlanSiembra>
    {
        public PlanSiembraSpec() : base(x=>true)
        {
            AddInclude(x => x.Cultivo);
            //AddInclude("Ranchos.Lotes");
        }
    }
}

